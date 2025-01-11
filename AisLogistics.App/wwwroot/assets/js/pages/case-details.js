'use strict';

var btns = {
    showDocumentsSidebar: $('[data-service-documents]'),
    showDocumentsResultsSidebar: $('[data-service-results]'),
    showSmevsSidebar: $('[data-service-smevs]'),
    showPaymentsSidebar: $('[data-service-payments]'),
},
    additionalForm = $('[data-service-additional]'),
    showStagesSidebar = $('[data-service-stages]'),
    showBlancsSidebar = $('#blancs-tab'),
    showFilesSidebar = $('#files-tab'),
    compose = $('.compose-case'),
    caseAppDetailScroll = $('.case-scroll-area'),
    menuToggle = $('.menu-toggle'),
    sidebarToggle = $('.sidebar-toggle'),
    sidebarLeft = $('.sidebar-left'),
    sidebarMenuList = $('.sidebar-menu-list'),
    caseUserList = $('.case-user-list'),
    caseScrollArea = $('.case-scroll-area'),
    caseDetails = $('#case-app-details'),
    listGroupMsg = $('.list-group-messages'),
    favoriteStar = $('.case-application .case-favorite'),
    overlay = $('.body-content-overlay'),
    blancs = $("#blancsAndFiles-content"),
    blanckDetailScroll = $('.blancs-scroll-area'),
    documentsServiceAddbtn = $('#documentsServiceAdd'),
    documentsServiceRefreshbtn = $('#documentsServiceRefresh'),
    service = $('[data-service-id]');


const sidebar = {
    _data: {
        url: "",
        data: ""
    },
    _load: (data, url) => {
        sidebar._data.url = url;
        sidebar._data.data = data;
        $.ajax({
            url: url,
            type: 'GET',
            data: data,
            beforeSend: () => {
                caseDetails.html('<div class="d-flex h-100 justify-content-center align-items-center"><div class="text-center"><p class="mb-0">Пожалуйста, подождите...</p> <div class="sk-wave sk-dark m-0 d-inline-flex"><div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div></div></div></div>');
                caseDetailsContent.show();
            },
            success: (content) => caseDetailsContent.change(content),
            //complete: () => caseDetailsContent.show()
        });
    },
    _reload: () => sidebar._load(sidebar._data.data, sidebar._data.url),
    stage: {
        load: (id) => sidebar._load({ id: id }, '/Cases/ServiceStages')
    },
    smev: {
        load: (id) => sidebar._load({ id: id }, '/Cases/ServiceSmevCompleted'),
        reload: () => sidebar._reload()
    },
    payments: {
        load: (id) => sidebar._load({ id: id }, '/Cases/ServicePaymentsCompleted'),
        reload: () => sidebar._reload()
    },
    document: {
        load: (id) => sidebar._load({ id: id }, '/Cases/ServiceDocuments'),
        reload: () => sidebar._reload()
    },
    results: {
        load: (id) => sidebar._load({ id: id }, '/Cases/ServiceDocumentsResults'),
        reload: () => sidebar._reload()
    }
}

const caseDetailsContent = {
    show: () => {
        caseDetails.addClass('show');
        tooltip.hideAll();
    },
    hide: () => {
        caseDetails.removeClass('show');
        goBack.destroy();
        caseDetailsContent.destroy();
        tooltip.hideAll();
    },
    change: (content) => {
        caseDetails.html(content);
        caseScrollAreaInit();
        tooltip.init();
        tooltip.hideAll();
        goBack.init();
    },
    destroy: _.debounce(() => {
        caseDetails.empty();
    }, 300)
}

const tooltip = {
    init: () => {
        const tooltipTriggerList = [].slice.call(caseDetails.find('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl);
        });
    },
    hideAll: () => {
        $('[data-bs-toggle="tooltip"], .tooltip').tooltip("hide");
    }
}

const caseScrollAreaInit = () => {
    let caseScrollArea = $('.case-scroll-area');
    if (caseScrollArea.length) {
        new PerfectScrollbar(caseScrollArea[0]);
    }
}

const goBack = {
    element: "",
    init: () => {
        this.element = $('.go-back');
        if (this.element.length) {
            this.element.off('click').on('click', function (e) {
                e.stopPropagation();
                caseDetailsContent.hide();
            });
        }
    },
    destroy: () => {
        if (this.element.length) {
            this.element.off('click');
        }
    }
}

function activeServiceId () {
    return $(service).attr('data-service-id');
}

$(function () {

    const caseFavorite = {
        set: (id) => {
            fetch(`/Cases/SetCaseFavorite?id=${id}`);
        },
        remove: (id) => {
            fetch(`/Cases/RemoveCaseFavorite?id=${id}`);
        }
    }

    new PerfectScrollbar("#casesNotesList");

    const caseScrollUserListInit = () => {
        if (caseUserList.length) {
            new PerfectScrollbar(caseUserList[0]);
        }
    }


    if (btns.showDocumentsSidebar.length) {
        btns.showDocumentsSidebar.on('click', function (e) {
            sidebar.document.load(activeServiceId());
        });
    }

    if (btns.showDocumentsResultsSidebar.length) {
        btns.showDocumentsResultsSidebar.on('click', function (e) {
            sidebar.results.load(activeServiceId());
        });
    }

    if (btns.showSmevsSidebar.length) {
        btns.showSmevsSidebar.on('click', function (e) {
            sidebar.smev.load(activeServiceId());
        });
    }

    if (btns.showPaymentsSidebar.length) {
        btns.showPaymentsSidebar.on('click', function (e) {
            sidebar.payments.load(activeServiceId());
        });
    }


    if (showStagesSidebar.length) {
        showStagesSidebar.on('click', function (e) {
            ServiceStageAddModal(activeServiceId());
        });
    }

    if (showBlancsSidebar.length) {
        showBlancsSidebar.on('click', function (e) {
            ServiceBlancs(activeServiceId());
        });
    }

    if (showFilesSidebar.length) {
        showFilesSidebar.on('click', function (e) {
            ServiceFiles(activeServiceId());
        });

        if (additionalForm.length) {
            additionalForm.on('click', function (e) {
                additionalFormShow(activeServiceId());
            });
        }
    }

    if (documentsServiceAddbtn.length) {
        documentsServiceAddbtn.on('click', function (e) {
            documentsServiceAddModal(activeServiceId());
        });
    }

    if (documentsServiceRefreshbtn.length) {
        documentsServiceRefreshbtn.on('click', function (e) {
            documentsServiceRefresh(activeServiceId());
        });
    }

    // Main menu toggle should hide app menu
    if (menuToggle.length) {
        menuToggle.on('click', function (e) {
            sidebarLeft.removeClass('show');
            overlay.removeClass('show');
        });
    }

    // case sidebar toggle
    if (sidebarToggle.length) {
        sidebarToggle.on('click', function (e) {
            e.stopPropagation();
            sidebarLeft.toggleClass('show');
            overlay.addClass('show');
        });
    }

    // Overlay Click
    if (overlay.length) {
        overlay.on('click', function (e) {
            sidebarLeft.removeClass('show');
            overlay.removeClass('show');
        });
    }

    // Add class active on click of sidebar list
    if (listGroupMsg.find('a').length) {
        listGroupMsg.find('a').on('click', function () {
            if (listGroupMsg.find('a').hasClass('active')) {
                listGroupMsg.find('a').removeClass('active');
            }
            $(this).addClass('active');
        });
    }

    if ($('.app-action .nav').find('.nav-link').length) {
        $('.app-action .nav').find('.nav-link').on('click', function () {
            if ($('.app-action .nav').find('.nav-link').hasClass('active')) {
                $('.app-action .nav').find('.nav-link').removeClass('active');
            }
            $(this).addClass('active');
        });
    }


    if (blanckDetailScroll.length) {
        new PerfectScrollbar(".blancs-scroll-area");
    }

    if (caseAppDetailScroll.length) {
        new PerfectScrollbar(".case-scroll-area");
    };

    // Favorite star click
    if (favoriteStar.length) {
        favoriteStar.on('click', function (e) {
            $(this).find('svg').toggleClass('favorite');
            e.stopPropagation();
            let id = $(this).data('case-id');
            // show toast only have favorite class
            if ($(this).find('svg').hasClass('favorite')) {
                caseFavorite.set(id);
                toastr['success']('Услуга добавлена в избранное', 'Готово', {
                    closeButton: true,
                    tapToDismiss: false,
                    rtl: false
                });
            } else {
                caseFavorite.remove(id);
            }
        });
    }

    // For app sidebar on small screen
    if ($(window).width() > 768) {
        if (overlay.hasClass('show')) {
            overlay.removeClass('show');
        }
    }

    caseDetails.on('refresh', function () {
        sidebar._reload();
    });


    function ServiceStages(id) {
        $.ajax({
            url: '/Cases/ServiceStages',
            type: 'GET',
            data: {id:id},
            beforeSend: () => {
                $("#caseStages").empty();
                $("#caseStages").append('<div class="h-75 w-100 d-flex align-items-center justify-content-center"><div class="spinner-grow text-primary" role="status"></div></div>');
            },
            success: (content) => {
                $("#caseStages").empty()
                $("#caseStages").append(content);
            }
           /* complete: () => $("#caseStages").empty()*/
        });
    }

    function ServiceStageAddModal(id) {
        $.ajax({
            url: '/Cases/ServiceStageAddModal',
            type: 'Post',
            data: { id: id },
            beforeSend: () => {
        
            },
            success: (content) => {
                $("#mainModal").html(content).modal('show');
            }
            /* complete: () => $("#caseStages").empty()*/
        });
    }

    function ServiceBlancs(id) {
        $.ajax({
            url: '/Cases/BlanksListModal',
            type: 'GET',
            data: { id: id },
            beforeSend: () => {
                $("#blancsAndFiles-content").empty();
                $("#blancsAndFiles-content").append('<div class="h-75 w-100 d-flex align-items-center justify-content-center"><div class="spinner-grow text-primary" role="status"></div></div>');
            },
            success: (content) => {
                $("#blancsAndFiles-content").empty();
                $("#blancsAndFiles-content").append(content);
                new PerfectScrollbar(".blancs-scroll-area");
            }
            //complete: () => caseDetailsContent.show()
        });
    }

    function ServiceFiles(id) {
        $.ajax({
            url: '/Cases/FilesListModal',
            type: 'GET',
            data: { id: id },
            beforeSend: () => {
                $("#blancsAndFiles-content").empty();
                $("#blancsAndFiles-content").append('<div class="h-75 w-100 d-flex align-items-center justify-content-center"><div class="spinner-grow text-primary" role="status"></div></div>');
                
            },
            success: (content) => {
                $("#blancsAndFiles-content").empty();
                $("#blancsAndFiles-content").append(content);
                new PerfectScrollbar(".blancs-scroll-area");
            }
            //complete: () => caseDetailsContent.show()
        });
    }

    function additionalFormShow(id) {
        $.ajax({
            url: '/Cases/AdditionalFormChangeModal',
            type: 'Post',
            data: { id: id },
            beforeSend: () => {
              /*  caseDetails.html('<div class="d-flex h-100 justify-content-center align-items-center"><div class="text-center"><p class="mb-0">Пожалуйста, подождите...</p> <div class="sk-wave sk-dark m-0 d-inline-flex"><div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div></div></div></div>');*/
            },
            success: (content) => {
                $("#mainModal").html(content).modal('show');
            }
            /*complete: () => caseDetails.empty()*/
        });
    }

    function documentsServiceAddModal(id) {
        console.log(124124124);
        $.ajax({
            url: '/Cases/ServiceDocumentNewAddModal',
            type: 'Post',
            data: { serviceId: id },
            beforeSend: () => {
                /*  caseDetails.html('<div class="d-flex h-100 justify-content-center align-items-center"><div class="text-center"><p class="mb-0">Пожалуйста, подождите...</p> <div class="sk-wave sk-dark m-0 d-inline-flex"><div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div></div></div></div>');*/
            },
            success: (content) => {
                $("#mainModal").html(content).modal('show');
            }
            /*complete: () => caseDetails.empty()*/
        });
    }

    function documentsServiceRefresh(id) {
        Swal.fire({
            title: 'Обновить документы из справочника',
            showCancelButton: true,
            confirmButtonText: 'Обновить',
            cancelButtonText: 'Отмена',
            showLoaderOnConfirm: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            customClass: {
                confirmButton: 'btn btn-success',
                cancelButton: 'btn btn-secondary ms-2'
            },
            buttonsStyling: false,
            returnInputValueOnDeny: true,
            preConfirm: (comment) => {
                //params.comment = comment;
                $.ajax({
                    url: '/Cases/ServiceDocumentRefresh',
                    type: 'Post',
                    data: { serviceId: id },
                    async: false,
                    beforeSend: () => {
                        Swal.showLoading();
                    },
                    complete: () => {
                        Swal.hideLoading();
                    },
                    success: (data) => {
                        sidebar.document.reload();
                    },
                    error: (data, textStatus) => {
                        $.notifi('error', 'Ошибка', data.responseText);
                    }
                });
            },
            allowOutsideClick: () => !Swal.isLoading()
        }).then((comment) => {
            //$.notifi('success', 'Готово', 'Запись успешно удалена');
        });
    }


    if (service.length) {
        ServiceStages(activeServiceId());
        ServiceBlancs(activeServiceId());
        sidebar.document.load(activeServiceId());
    }

    $(document).on("click", "a.remove-file", function (e) {
        e.stopPropagation();
        e.preventDefault();
        var $this = $(this);
        var removeUrl = $this.attr("href");
        Swal.fire({
            title: 'Причина удаления записи',
            input: 'textarea',
            showCancelButton: true,
            confirmButtonText: 'Удалить',
            cancelButtonText: 'Отмена',
            showLoaderOnConfirm: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            customClass: {
                confirmButton: 'btn btn-danger',
                cancelButton: 'btn btn-secondary ms-2'
            },
            buttonsStyling: false,
            returnInputValueOnDeny: true,
            preConfirm: (comment) => {
                if (comment === '') {
                    Swal.showValidationMessage(`Введите комменетарий`);
                } else {
                    //params.comment = comment;
                    $.ajax({
                        type: 'POST',
                        url: removeUrl,
                        //data: params,
                        async: false,
                        beforeSend: () => {
                            Swal.showLoading();
                        },
                        complete: () => {
                            Swal.hideLoading();
                        },
                        success: (data) => {
                            sidebar.document.reload();
                        },
                        error: (data, textStatus) => {
                            $.notifi('error', 'Ошибка', data.responseText);
                        }
                    });
                }
            },
            allowOutsideClick: () => !Swal.isLoading()
        }).then((comment) => {
            //$.notifi('success', 'Готово', 'Запись успешно удалена');
        });
    });
    //caseScrollAreaInit();
    caseScrollUserListInit();
});


