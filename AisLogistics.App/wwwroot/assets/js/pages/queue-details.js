var $divQueueMain = $("#electronicQueueContent");
let closeSubmenu = null;
let openSubmenu = null;
let officeTickets = [];
let deferredTickets = [];
let transferedTickets = [];
let offices = [];
let nextTicket = null;
let currentTicket = null;
let $registration = $divQueueMain.find('#scoreboard-registration');
let $afterCallTicketBlock = $divQueueMain.find('#afterCallTicketBlock');
let $scoreboard = $divQueueMain.find('#scoreboard');
let $scoreboardRedirectList = $divQueueMain.find('#scoreboardRedirectList');
let $callTicketBlock = $divQueueMain.find('[data-call]');
let $completeTicketBlock = $divQueueMain.find('[data-complete]');

refreshNum($divQueueMain);
RefreshDataQueue($divQueueMain);

$(document).ready(function () {
  let hubConnection = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();
  hubConnection.on("Queue", function (message) {
    refreshNum($divQueueMain);
  });

  hubConnection.start().catch(function (err) {
    return console.error(err.toString());
  });

  let submenuBtns = document.querySelectorAll('.scoreboard-dropdown .btn-submenu');
  let queuewidth = document.getElementById('electronicQueue');
  openSubmenu = (el) => {
    let openedSubmenu = document.querySelector('.scoreboard-submenu--open');
    if (openedSubmenu) {
      let btn = openedSubmenu.previousElementSibling.querySelector('.btn-submenu');
      openedSubmenu.classList.remove('scoreboard-submenu--open');
      queuewidth.classList.remove('dropdown-queue-max');
      btn.addEventListener('click', openSubmenu);
      btn.removeEventListener('click', closeSubmenu);
    }

    let currentScoreboard = el.target.closest('.btn-group').nextElementSibling;
    currentScoreboard.classList.add('scoreboard-submenu--open');
    queuewidth.classList.add('dropdown-queue-max');

    let submenuCurrent = el.target.closest('.btn-submenu')

    submenuCurrent.removeEventListener('click', openSubmenu);
    submenuCurrent.addEventListener('click', closeSubmenu);
  };

  closeSubmenu = (el) => {
    let currentScoreboard = el.target.closest('.btn-group').nextElementSibling;
    currentScoreboard.classList.remove('scoreboard-submenu--open');
    queuewidth.classList.remove('dropdown-queue-max');
    let submenuCurrent = el.target.closest('.btn-submenu')

    submenuCurrent.addEventListener('click', openSubmenu);
    submenuCurrent.removeEventListener('click', closeSubmenu);
  };

  submenuBtns.forEach(function (it) {
    it.addEventListener('click', openSubmenu);
  });
});

function hideBlocks() {
  $('#scoreboard').hide();
  $('#scoreboard ul').empty();
  $('#afterCallTicketBlock').hide();
  $('#scoreboardRedirectList').hide();
  $('#scoreboardPredRegistration').hide();
}

// очистка экрана от данных талона
function clearQueueWindow() {
  $('#electronicQueueActiveNum').text('---');
  $('#ticket_num').html('---');
  $('#ticket_id').val('');
  $('#ticket_type').val('');
}

function disableAllButtons(status) {
  if (status) {

  }
}

function timerDestroy() {
  $("#electronicQueueActiveTime").countdown('destroy');
  $("#queueActiveTime").countdown('destroy');
}

function closeAllSubmenu() {
  hideBlocks();

  //let queuewidth = document.getElementById('electronicQueue');
  //queuewidth.classList.remove('dropdown-queue-max');

  //document.querySelectorAll(`${id} .scoreboard-submenu`).forEach(item => {
  //    item.classList.remove('scoreboard-submenu--open');
  //})

  //document.querySelectorAll(`${id} .btn-submenu`).forEach(item => {
  //    item.addEventListener('click', openSubmenu);
  //    item.removeEventListener('click', closeSubmenu);
  //})
};

($divQueueMain);
$(document).on('show.bs.dropdown', '#electronicQueue', function () {//показываем блок            
  refreshNum($divQueueMain);
  RefreshDataQueue($divQueueMain);
});
$(document).on('hide.bs.dropdown', '#electronicQueue', function () {//скрываем блок    
  $('#electronicQueueActiveNum').text($('#ticket_num').html());
});

$(document).on('click', '[data-redirect-abon]', function () { //перенаправить заявителя в окно 
  let ip = $(this).data('redirectAbon'),
    num = $('#ticket_id').val();
  redirectAbon(ip, num);
});
$('#callNextTticketInQueue').on('click', function () { //вызов следующего заявителя или завершить    
  nextAbon();
});
$('[data-queue-next-vip]').on('click', function () { //вызов следующего заявителя за справкой или завершить
  var EndCall = $(this).data('queueNextVip'),
    Num = $('#ticket_id').val();
  nextAbonVip(Num, EndCall);
});

$('#transferTicket').on('click', function () { //передача талона  
  var $target = $('#scoreboardRedirectList ul');
  if ($('#ticket_id').val()) {
    $.ajax({
      url: "/Queue/jsonListWindow",
      type: "GET",
      beforeSend: function () {
        hideBlocks();
        $('#scoreboardRedirectList').show();
        $target.html('<div style="-webkit-box-pack: center;justify-content : center;-webkit-box-align: center;align-items : center;display: flex;height: 255px; margin-right: -5px;"><i class="fa fa-spin fa-spinner fa-2x" ></i></div>');
      },
      success: function (data) {
        console.log(data);
        if (data.error?.data?.message) {
          $target.html('Ошибка получения списка');
        }
        else if (data.result?.length > 0) {
          //$target.find('.modal-body').html('<ul class="list-unstyled"></ul>');
          $target.empty();
          $.map(data.result, function (item, index) {
            console.log(item.windowName);
            console.log($('#queueMyWindowNum').html());
            if (item.windowName != $('#queueMyWindowNum').html()) {
              $('<li>', {
                class: "d-flex justify-content-between align-items-center p-2 border-bottom",
                append: $('<b>', {
                  text: `${item.windowName}`,
                }).add($('<button>', {
                  class: "btn btn-lg waves-effect waves-light",
                  "data-toggle": "tooltip",
                  "data-placement": "left",
                  "data-container": "#scoreboardRedirectList",
                  "data-redirect-abon": `${item.windowIp}`,
                  "title": "Передать",
                  append: $('<i>', {
                    class: "bi bi-box-arrow-in-right",
                  }),
                  on: {
                    click: function (e) {
                      e.stopImmediatePropagation();
                      let ip = $(this).data('redirectAbon'),
                        num = $('#ticket_id').val();
                      console.log($(this));
                      redirectAbon(ip, num);
                    }
                  }
                }).tooltip())
              }).appendTo($target);
            }
          })

          new PerfectScrollbar('#scoreboardRedirectList ul');
        }
        else {
          $target.empty().append('<li class="d-flex justify-content-between align-items-center p-2 border-bottom"><span class="text-muted">Нет данных<span></li>')
        }
      }
    });
  } else {
    $target.html('Абонент еще не вызван');
  }
});
$('#postponeTicket').on('click', function () { //отложить заявителя 
  if ($('#ticket_id').val()) {
    console.log(currentTicket);
    $.ajax({
      url: "/Queue/jsonDelayAbon",
      data: { num: $('#ticket_id').val() },
      type: "POST",
      success: function (data) {
        if (data?.result) {
          toastr['success']('Талон отложен', 'Готово', {
            closeButton: true,
            tapToDismiss: false
          });
          clearQueueWindow();
          refreshNum($("#electronicQueueContent"));
          timerDestroy();
          $completeTicketBlock.hide();
          $callTicketBlock.show();
        }
        else {
          toastr['error']('Талон не отложен', 'Ошибка', {
            closeButton: true,
            tapToDismiss: false,
            rtl: false
          });
        }
      }
    });
  }
});

$('#clientNotCome').on('click', function () { //отложить заявителя   
  if ($('#ticket_id').val()) {
    console.log(currentTicket);
    $.ajax({
      url: "/Queue/jsonClientNotCome",
      data: { ticketId: $('#ticket_id').val() },
      type: "POST",
      beforeSend: function () {
        hideBlocks();
      },
      success: function (data) {
        if (data.result) {
          clearQueueWindow();
            timerDestroy();
            $callTicketBlock.show();
          console.log('статус талона изменен на "не явился"');
        } else {
          console.log('не удалось изменить статус талона на "не явился"');
        }
        refreshNum($("#electronicQueueContent"));
      }
    });
  }
});

$('#takeTicketToWork').on('click', function () { // взять в работу
  if ($('#ticket_id').val()) {
    console.log('take_ticket_to_work');
    $.ajax({
      url: "/Queue/jsonTakeTicketToWork",
      data: { ticketId: $('#ticket_id').val() },
      type: "POST",
      beforeSend: function () {
        hideBlocks();
      },
      success: function (data) {
          if (data.result) {
          $completeTicketBlock.show();
          console.log('талон взят в работу');
        } else {
          console.log('не удалось взять талон в работу');
          refreshNum($("#electronicQueueContent"));
        }
      }
    });
  }
});

$('#registration').on('click', function () {
  $('#scoreboardPredRegistration').slideToggle();
});

$('#completeTicket').on('click', function () { // завершить талон
  if ($('#ticket_id').val()) {
    console.log('complete_ticket');
    $.ajax({
      url: "/Queue/jsonCompleteTicket",
      data: { ticketId: $('#ticket_id').val() },
      type: "POST",
      beforeSend: function () {
        hideBlocks();
      },
      success: function (data) {
        if (data.result) {
          clearQueueWindow();
          toastr['success']('талон завершен', 'Готово', {
            closeButton: true,
            tapToDismiss: false
          });
          console.log('талон завершен');
            timerDestroy();
            $completeTicketBlock.hide();
            $callTicketBlock.show();

        } else {
          toastr['error']('талон не завершен', 'Ошибка', {
            closeButton: true,
            tapToDismiss: false
          });
          console.log('талон не завершен');
        }
        refreshNum($("#electronicQueueContent"));
      }
    });
  }
});

$('.count-abon').on('click', function () { // список заявителей в очереди
  var $target = $('#scoreboard ul');
  $('#scoreboard').show();
  $afterCallTicketBlock.hide();

  $.ajax({
    url: "/Queue/jsonListAbonInQueue",
    type: "GET",
    beforeSend: function () {
      $target.html('<div style="-webkit-box-pack: center;justify-content : center;-webkit-box-align: center;align-items : center;display: flex;height: 255px; margin-right: -5px;"><i class="fa fa-spin fa-spinner fa-2x" ></i></div>');
    },
    success: function (data) {
      console.log(data);
      //if (data.errorCode === 500) {
      //    $target.empty().append('<li class="text-center"><span class="text-muted">Ошибка получения списка</span></li>')
      //}
      if (data.error?.data?.message) {
        $target.empty().append(`<li class="text-center"><span class="text-muted">${data.error.data.message}</span></li>`)
      }
      else if (data.result?.length > 0) {
        $target.empty();
        officeTickets = [];
        $.map(data.result, function (value, index) {
          officeTickets.push(value);
          $('<li>', {
            class: "list-group-item text-primary ps-0",
            text: `${value.ticketNumberFull}`,
          }).appendTo($target);
        });
        nextTicket = officeTickets[0];
      }
      else {
        $target.empty().append('<li class="text-center"><span class="text-muted">Нет данных</span></li>')
      }
    }
  });
});

$('#transferedTickets').on('click', function () { //список переданных заявителей
  var $target = $('#scoreboard ul');
  hideBlocks();
  $('#scoreboard').show();

  $.ajax({
    url: "/Queue/jsonListAbonRedirect",
    type: "GET",
    beforeSend: function () {
      hideBlocks();
      $scoreboard.show();
      $target.html('<div style="-webkit-box-pack: center;justify-content : center;-webkit-box-align: center;align-items : center;display: flex;height: 255px; margin-right: -5px;"><i class="fa fa-spin fa-spinner fa-2x" ></i></div>');
    },
    success: function (data) {
      console.log(data);
      if (data.error) {
        $target.empty().append('<li class="text-center"><span class="text-muted">Ошибка получения списка</span></li>')
      } else if (data.result) {
        $target.empty();
        $.map(data.result, function (value, index) {
          $('<li>', {
            class: "list-group-item text-primary ps-0 cursor-pointer",
            "data-id": value.pk,
            "data-num": value.ticketNumberFull,
            text: `${value.ticketNumberFull}`,
            on: {
              click: function (e) {
                $('#ticket_num').html($(this).data('num'));
                $('#ticket_id').val($(this).data('id'));
                $('#ticket_type').val('transfered');
              }
            }
          }).appendTo($target);
        });
      } else {
        $target.empty().append('<li class="text-center"><span class="text-muted">Ошибка получения списка</span></li>')
      }
    }
  });
});
$('#deferredTickets').on('click', function () { //список отложенных заявителей
  var $target = $('#scoreboard ul');
  $('#scoreboard').show();
  $afterCallTicketBlock.hide();

  $.ajax({
    url: "/Queue/jsonListAbonDelay",
    type: "GET",
    beforeSend: function () {
      $target.html('<div style="-webkit-box-pack: center;justify-content : center;-webkit-box-align: center;align-items : center;display: flex;height: 255px; margin-right: -5px;"><i class="fa fa-spin fa-spinner fa-2x" ></i></div>');
    },
    success: function (data) {
      console.log(data);
      if (data?.result) {
        $target.empty();
        $.map(data.result, function (value, index) {
          $('<li>',
            {
              class: "list-group-item text-primary ps-0 cursor-pointer",
              "data-id": value.pk,
              "data-num": value.ticketNumberFull,
              text: `${value.ticketNumberFull}`,
              on: {
                click: function (e) {
                  $('#ticket_num').html($(this).data('num'));
                  $('#ticket_id').val($(this).data('id'));
                  $('#ticket_type').val('deferred');
                }
              }
            }).appendTo($target);
        });
      } else {
        $target.empty().append('<li class="text-center"><span class="text-muted">Ошибка получения списка</span></li>')
      }
    }
  });
});
$('[data-queue-reject-btn]').on('click', function () { // отклонить клиента
  let $this = $(this);
  if ($this.data('queueRejectBtn') == "yes") {
    $.ajax({
      url: "/Queue/jsonRejectAbon",
      type: "GET",
      success: function (data) {
        if (data.errorCode === 500) {
          Lobibox.notify('error', {
            size: 'mini',
            delay: false,
            position: 'top right',
            msg: data.ErrorText,
            soundPath: '../Content/libs/lobibox/sounds/',
            sound: 'error_sound'
          });
        } else {
          Lobibox.notify('success', {
            size: 'mini',
            delay: false,
            position: 'top right',
            msg: "Клиент отклонен!",
            soundPath: '../Content/libs/lobibox/sounds/',
            sound: 'error_sound'
          });
          $('[data-queue-reject-btn]').trigger('click');
          refreshNum($("#electronicQueueContent"));
        }
      }
    });
  }
  else {
    $('[data-queue-reject-btn]').trigger('click');
  }

});

$('#predRegistration').on('click', function () { // предзапись
  $.ajax({
    url: '/Queue/AddPreRegistrationModal',
    type: 'Post',
    beforeSend: function () {
      hideBlocks();
      $.pageBlock();
    },
    success: function (content) {
      $('#mainModal').html(content).modal('show');
    },
    error: function (XMLHttpRequest, textStatus, errorThrown) {
      $.unblockUI();

    },
    complete: function () {
      $.unblockUI();
    }
  });
});

$('#cancelRegistration').on('click', function () { // отмена
  $.ajax({
    url: '/Queue/AddCancelPreRegistrationModal',
    type: 'Post',
    beforeSend: function () {
      hideBlocks();
      $.pageBlock();
    },
    success: function (content) {
      $('#mainModal').html(content).modal('show');
    },
    error: function (XMLHttpRequest, textStatus, errorThrown) {
      $.unblockUI();
    },
    complete: function () {
      $.unblockUI();
    }
  });
});

function refreshNum($divUl) { //обновление данных 
  RefreshCountsQueue($divUl);
  //$.ajax({
  //  url: "/Queue/jsonNumAbonOnWindow",
  //  type: "GET",
  //  beforeSend: function () {
  //    //$divUl.find('#ticket_num').html(' --- ');
  //  },
  //  success: function (data) {
  //    RefreshDataQueue($divUl, data);      
  //  },
  //});
  closeAllSubmenu();
}

function queueTimer(el, t, method, serverTime) {  
  $(el).countdown({
    since: -((serverTime - t) / 1000),
    //until: +t,
    format: 'M:S',
    compact: true,
    //onExpiry: method
  });
}

function RefreshDataQueue(divUI) {
  $.ajax({
    url: "/Queue/jsonGetWindowInfo",
    type: "GET",
    beforeSend: function () {
      //$divUl.find('#ticket_num').html(' --- ');
    },
      success: function (data) {
      $completeTicketBlock.hide();
        console.log(data);
      if (data.window?.windowName) $('#queueMyWindowNum').html(data.window?.windowName ?? '');
      if (data.error != null) {
        divUI.html(`<span style="color: black!important;">Ошибка получения данных</span>`);
      }
      else if (data?.ticket.dTicket) {
        $callTicketBlock.hide();
        console.log(data)
        if (data.ticket.timeStartService == null) $afterCallTicketBlock.show();
        else $completeTicketBlock.show();
        $scoreboard.hide();
        $('#electronicQueueActiveNum').text(data.ticket.ticketNumberFull ?? '---');
        divUI.find('#ticket_id').val(data.ticket.dTicket);
        divUI.find('#ticket_num').html(data.ticket.ticketNumberFull ?? '---');
        //счетчик времени 
        $("#electronicQueueActiveTime").countdown('destroy');
        $("#queueActiveTime").countdown('destroy');        
        let qTime = new Date(data.ticket.timeStartService ?? data.ticket.timeCall);        
        let qsTime = new Date(data.ticket.serverTime);         
        queueTimer("#electronicQueueActiveTime", qTime, "none", qsTime);
        queueTimer("#queueActiveTime", qTime, "none", qsTime);        
      }
      else {
        $("#electronicQueueActiveTime").text('');
        $("#queueActiveTime").text('');
      }
    },
  });
}
function RefreshCountsQueue(divUI) {
  $.ajax({
    url: "/Queue/jsonCountAbon",
    type: "GET",
    beforeSend: function () {
      divUI.find('button').attr('disabled', true);
    },
    success: function (data) {
      if (data?.result) {
        $('#queueHeadCountAbon').text(Number(data.result.inQueueTotal) + Number(data.result.postponedCount) + Number(data.result.transferredCount));
        $('#transferedTicketsCount').text(data.result.transferredCount);
        $('#deferredTicketsCount').text(data.result.postponedCount);
        $('#ticketsInQueueCount').text(data.result.inQueueTotal);
      } else {
        divUI.html('<span style="color: black!important;">Сервис временно недоступен.</span>');
      }
    },
    complete: function () {
      divUI.find('button').attr('disabled', false);
    }
  });
}

function nextAbon() { //вызов следующего заявителя
  if ($('#ticket_type').val() && !$("#electronicQueueActiveTime").text()) {
    $.ajax({
      url: "/Queue/jsonCallAbon",
      type: "POST",
      data: { ticketId: $('#ticket_id').val() },
      beforeSend: function () {
        hideBlocks();
        $divQueueMain.find('#ticket_num').html('<div style="-webkit-box-pack: center;justify-content : center; color:black; -webkit-box-align: center;align-items : center;display: flex;height: 48px; margin-right: -5px;"><i class="fa fa-spin fa-spinner fa-2x" ></i></div>');
      },
      success: function (data) {
        console.log(`Вызов талона:`)
        if (data?.result) {
          console.log(`Вызов талона: ${data.result}`);
          $divQueueMain.find('#ticket_num').html(data.result);          
            RefreshDataQueue($divQueueMain);
            refreshNum($divQueueMain);
        } else {
          $divQueueMain.find('#ticket_num').html('---');
          toastr['error']('не удалось вызвать талон', 'Ошибка', {
            closeButton: true,
            tapToDismiss: false
          });
        }
      },
      complete: function (data) {
        //refreshNum($("#electronicQueueContent"));
      }
    });
  } else if ($('#ticket_num').html() == '---') {
    $.ajax({
      url: "/Queue/jsonNextAbon",
      type: "POST",
      //data: { EndCall: EndCall, Num: Num },
      beforeSend: function () {
        hideBlocks();
        $divQueueMain.find('#ticket_num').html('<div style="-webkit-box-pack: center;justify-content : center; color:black; -webkit-box-align: center;align-items : center;display: flex;height: 48px; margin-right: -5px;"><i class="fa fa-spin fa-spinner fa-2x" ></i></div>');
      },
      success: function (data) {
        console.log(`Вызов талона:`)
        if (data?.result?.pk) {
          console.log(`Вызов талона: ${data.result.ticketNumberFull}`)
          $('#ticket_id').val(data.result.pk);
          $('#electronicQueueContent #ticket_num').html(`${data.result.ticketNumberFull ?? '---'}`);          
          RefreshDataQueue($divQueueMain);
          refreshNum($divQueueMain);
        } else {
          $divQueueMain.find('#ticket_num').html('---');
          toastr['info']('В очереди нет новых талонов', 'Готово', {
            closeButton: true,
            tapToDismiss: false
          });
        }
      },
      complete: function (data) {
        //refreshNum($("#electronicQueueContent"));
      }
    });

  }
}
function nextAbonVip(Num, EndCall) { //вызов следующего заявителя за справкой
  $.ajax({
    url: "/Queue/jsonNextAbonVip",
    type: "POST",
    data: { EndCall: EndCall, Num: Num },
    success: function (data) {
      $('#electronicQueueContent #ticket_num').html(data.num);
    },
    complete: function (data) {
      $afterCallTicketBlock.show();
      $scoreboard.hide();
      refreshNum($("#electronicQueueContent"));
    }
  });
}
function nextRedirectAbon(Num) { //вызов переданного заявителя
  $.ajax({
    url: "/Queue/jsonNextAbonRedirect",
    type: "POST",
    data: { Num: Num },
    success: function (data) {
      $('#electronicQueueContent #ticket_num').html(data.num);
    },
    complete: function () {
      refreshNum($("#electronicQueueContent"));
    }
  });
}
function nextDeferredAbon(Num) { //вызов отложенного заявителя
  $.ajax({
    url: "/Queue/jsonNextAbonDelay",
    type: "POST",
    data: { Num: Num },
    success: function (data) {
      $('#electronicQueueContent #ticket_num').html(data.num);
    },
    complete: function () {
      refreshNum($("#electronicQueueContent"));
    }
  });
}
function redirectAbon(Ip, Num) { //метод перенаправления заявителя в окно
  $.ajax({
    url: "/Queue/jsonAbonRedirect",
    type: "POST",
    data: { windowIp: Ip, Num: Num },
    success: function (data) {
      if (data?.result) {
        toastr['success']('Талон переадресован', 'Готово', {
          closeButton: true,
          tapToDismiss: false
        });
        clearQueueWindow();
        refreshNum($("#electronicQueueContent"));
        timerDestroy();
        $completeTicketBlock.hide();
        $callTicketBlock.show();
      }
      else {
        toastr['error']('Талон не переадресован', 'Ошибка', {
          closeButton: true,
          tapToDismiss: false,
          rtl: false
        });
      }
    },
    complete: function () {
    }
  });
}





