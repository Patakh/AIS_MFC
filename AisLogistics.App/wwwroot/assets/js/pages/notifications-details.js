
$(document).ready(function () {
    let hubConnectionAlert = new signalR.HubConnectionBuilder().withUrl("/NotificationHub").build();
    hubConnectionAlert.on("Alert", function (message) {
        NotificationCount($('#notificationCount'));
    });

    hubConnectionAlert.start().catch(function (err) {
        return console.error(err.toString());
    });

    function NotificationCount($targer) {
        $.ajax({
            url: "/Home/jsonNotificationCount",
            type: "GET",
            data: { employeeId: globalEmployeeId },
            success: function (count) {
                if (count > 0) {
                    $targer.html(count).show();
                } else if (count > 99) {
                    $targer.html('99+').show();
                }
                else {
                    $targer.hide();
                }
                AlertRefresh();
            }
        });
    }
    function AlertRefresh() {
        $.ajax({
            url: "/Home/Alert_employees_select",
            type: "GET",
            data: { employeeId: globalEmployeeId },
            beforeSend: function () {
                $('#notificationListContent').html('<div style="-webkit-box-pack: center;justify-content : center;-webkit-box-align: center;align-items : center;display: flex;height: 100%; margin-right: -5px;"><i class="fa fa-spin fa-spinner fa-2x" ></i></div>');
            },
            success: function (b) {
                $("#notificationListContent").html(b);
            },
            complete: function () {
                var count = $('#notificationListContent div.notify-item').length;
                if (count > 0) {
                    $('#notificationListCount').html(count > 99 ? "99+" : count).removeClass('d-none');
                }
            }
        });
    }


    const notificationRemoveAll = document.querySelector('.dropdown-notifications-all');
    const notificationMarkAsReadList = document.querySelectorAll('.dropdown-notifications-read');
    var notificationAll = document.querySelectorAll('.list-group-item-notification');
    var notificationBadge = document.querySelector('.header_notification .badge-notification');


    // Notification: all 
    if (notificationAll) {
        notificationAll.forEach(item => {
            //time ago
            const date = item.querySelector('small[data-timeago]');
            date.innerHTML = moment(date.dataset.timeago, "DD.MM.YYYY hh:mm:ss").fromNow();

            //if (!item.classList.contains("marked-as-read")) {
            //    item.addEventListener('mouseenter', event => {
            //        $.ajax({
            //            url: "/Notification/Read",
            //            data: { id: item.dataset.notification },
            //            complete: () => {
            //                item.closest('.dropdown-notifications-item').classList.add('marked-as-read');
            //            }
            //        });
            //    }, { once: true });
            //}
        });
    }
    // Notification: Mark as all as read
    /* if (notificationMarkAsReadAll) {
         notificationMarkAsReadAll.addEventListener('click', event => {
             $.ajax({
                 url: "/Notification/Read",
                 complete: () => {
                     notificationMarkAsReadList.forEach(item => {
                         item.closest('.dropdown-notifications-item').classList.add('marked-as-read');
                     });
                 }
             });
        });
     }*/
    // Notification: Remove
    const notificationArchiveMessageList = document.querySelectorAll('.dropdown-notifications-archive');
    notificationArchiveMessageList.forEach(item => {
        item.addEventListener('click', event => {
            let id = item.closest('.list-group-item-notification').dataset.notification;
            $.ajax({
                url: "/Notification/Remove",
                data: { id: id },
                complete: () => {
                    item.closest('.list-group-item-notification').remove();
                    notificationAll = document.querySelectorAll('.list-group-item-notification');
                    notificationBadge.innerHTML = notificationAll.length;
                    $('[data-bs-toggle="tooltip"], .tooltip').tooltip("hide");
                    if (notificationAll.length === 0) {
                        document.querySelector('.dropdown-notifications-list ul').innerHTML = '<li><p class="small text-muted py-5 mb-0 text-center">Нет новых уведомлений.</p></li>';
                        notificationBadge.remove();
                    }
                }
            });
        });
    });


    const notificationCasesMessageList = document.querySelectorAll('.dropdown-notifications-cases');
    notificationCasesMessageList.forEach(item => {
        item.addEventListener('click', event => {
            let id = item.closest('.list-group-item-notification').dataset.notification;
            let cases = item.textContent
            $.ajax({
                url: "/Notification/Remove",
                data: { id: id },
                complete: () => {
                    item.closest('.list-group-item-notification').remove();
                    notificationAll = document.querySelectorAll('.list-group-item-notification');
                    notificationBadge.innerHTML = notificationAll.length;
                    $('[data-bs-toggle="tooltip"], .tooltip').tooltip("hide");
                    if (notificationAll.length === 0) {
                        document.querySelector('.dropdown-notifications-list ul').innerHTML = '<li><p class="small text-muted py-5 mb-0 text-center">Нет новых уведомлений.</p></li>';
                        notificationBadge.remove();
                    }
                }
            });
            window.open(`/Cases/Details?id=${cases}`, "_self");
        });
    });


    if (notificationAll.length > 0) {
        notificationRemoveAll.addEventListener('click', () => {
            $.ajax({
                url: "/Notification/RemoveAll",
                data: {},
                beforeSend: () => {
                    $.pageBlock();
                },
                success: (responce) => {
                    if (responce) {
                        document.querySelector('.dropdown-notifications-list ul').innerHTML = '<li><p class="small text-muted py-5 mb-0 text-center">Нет новых уведомлений.</p></li>';
                        notificationBadge.remove();
                    }
                    else {
                        toastr['error']('При выполнение запроса', 'Ошибка', {
                            closeButton: true,
                            tapToDismiss: false,
                            rtl: false
                        });
                    }
                },
                complete: () => {
                    $.unblockUI();
                }
            });
        });
    }

});