var sendingForm = $('#reportForm'),
    btnSubmit = $('#reportSubmit'),
    btnPrint = $('#reportPrint'),
    btnDownload = $('#reportDownload'),
    datePeriod = $('#date-range'),
    providers = $('#providerId'),
    mfc = $('#mfcId'),
    sps = $('#spsId'),
    employees = $('#employeeId'),
    services = $('#serviceId'),
    smev = $('#smevId'),
    smevRequest = $('#smevRequestId');
    
$(document).ready(function () {

    $('select.select2-search').select2({});

    $('select.select2-nosearch').select2({
        minimumResultsForSearch: Infinity
    });

    $('select.select2-tags').select2({
        tags: true
    });

    if (datePeriod.length) {
        datePeriod.datepicker({
            language: "ru",
            endDate: '-1d',
            toggleActive: true
        });
    }

    if (providers.length) {
        $.ajax({
            type: 'Get',
            url: '/Filters/GetProvidersDataJson',
            data: {},
            beforeSend: () => {
                providers.empty();
                providers.prop("disabled", true);
            },
            success: function (data) {
                data.forEach(function (item) {
                    let selected = item.id === '00000000-0000-0000-0000-000000000000'; 
                    providers.append($("<option></option>")
                    .attr("value", item.id)
                    .text(item.officeName)
                    .prop("selected", selected));
                });

                providers.trigger("change");
            },
            complete: () => {
                providers.prop("disabled", false);
            }
        });
    }


    if (services.length) {
        providers.on('change',function (e) {

            let isAll = false;
            let guidEmpty = '00000000-0000-0000-0000-000000000000';
            let arr = [];

            $.each($(e.target).val(), function (index, val) {
                if (val === guidEmpty) {
                    isAll = true;

                }
                arr.push({ name: 'providersId', value: val });
            })

            
            if (isAll && services.find('option[value="00000000-0000-0000-0000-000000000000"]').length == 0) {
                services.append($("<option></option>")
                .attr("value", guidEmpty)
                .text("Все")
                .prop("selected", "selected"));
                services.prop("disabled", false);
            }
            else {
                $.ajax({
                    type: 'Get',
                    url: '/Filters/GetServicesForProviderDataJson',
                    data: arr,
                    beforeSend: () => {
                        services.empty();
                        services.prop("disabled", true);
                    },
                    success: function (data) {
                        data.forEach(function (item) {

                            let selected = item.id === '00000000-0000-0000-0000-000000000000';

                            services.append($("<option></option>")
                            .attr("value", item.id)
                            .text(item.serviceName)
                            .prop("selected", selected));
                        });
                    },
                    complete: () => {
                        services.prop("disabled", false);
                    }
                });
            }
        });
    }

    if (mfc.length) {
        $.ajax({
            type: 'Get',
            url: '/Filters/GetReceptionOfficeDataJson',
            data: { isAll: $(mfc).data("all") },
            beforeSend: () => {
                mfc.empty();
                mfc.prop("disabled", true);
            },
            success: function (data) {
                if (data.length === 1) {
                    data.forEach(function (item) {
                        mfc.append($("<option></option>")
                        .attr("value", item.id)
                        .text(item.officeName)
                        .prop("selected", "selected"));
                    });
                }
                else {
                    data.forEach(function (item) {

                        let selected = item.id === '00000000-0000-0000-0000-000000000000';

                        mfc.append($("<option></option>")
                        .attr("value", item.id)
                        .text(item.officeName)
                        .prop("selected", selected));
                    });
                }
                mfc.trigger("change");
            },
            complete: () => {
                mfc.prop("disabled", false);
            }
        });

    }

    if (employees.length) {
        mfc.on('change',function (e) {

            let isAll = false;
            let guidEmpty = '00000000-0000-0000-0000-000000000000';
            let arr = [];

            $.each($(e.target).val(), function (index, val) {
                if (val === guidEmpty) {
                    isAll = true;

                }
                arr.push({ name: 'employeeId', value: val });
            })

            if (isAll && employees.find('option[value="00000000-0000-0000-0000-000000000000"]').length ==0) {
                employees.append($("<option></option>")
                .attr("value", guidEmpty)
                .text("Все")
                .prop("selected", "selected"));

                employees.prop("disabled", false);
            }
            else {

                $.ajax({
                    type: 'Get',
                    url: '/Filters/GetEmployeesForReceptionOfficeDataJson',
                    data: arr,
                    beforeSend: () => {
                        employees.empty();
                        employees.prop("disabled", true);
                    },
                    success: function (data) {
                        if (data.length === 1) {
                            data.forEach(function (item) {
                                employees.append($("<option></option>")
                                .attr("value", item.id)
                                .text(item.officeName)
                                .prop("selected", "selected"));
                            });
                        }
                        else {
                            data.forEach(function (item) {

                                let selected = item.id === '00000000-0000-0000-0000-000000000000';

                                employees.append($("<option></option>")
                                .attr("value", item.id)
                                .text(item.officeName)
                                .prop("selected", selected));
                            });
                        }
                    },
                    complete: () => {
                        employees.prop("disabled", false);
                    }
                });
            }
        });
    }

    if (smev.length) {
        $.ajax({
            type: 'Get',
            url: '/Filters/GetSmevServicesDataJson',
            data: {},
            beforeSend: () => {
                smev.empty();
                smev.prop("disabled", true);
            },
            success: function (data) {
                data.forEach(function (item) {
                    let selected = item.id === '00000000-0000-0000-0000-000000000000';

                    smev.append($("<option></option>")
                    .attr("value", item.id)
                    .text(item.smevName)
                    .prop("selected", selected));
                });

                smev.trigger("change");
            },
            complete: () => {
                smev.prop("disabled", false);
            }
        });
    }

    if (smevRequest.length) {
        smev.on('change',function (e) {

            let isAll = false;
            let guidEmpty = '00000000-0000-0000-0000-000000000000';
            let arr = [];

            $.each($(e.target).val(), function (index, val) {
                if (val === guidEmpty) {
                    isAll = true;

                }
                arr.push({ name: 'smevId', value: val });
            })

            if (isAll && smevRequest.find('option[value="00000000-0000-0000-0000-000000000000"]').length == 0) {
                smevRequest.append($("<option></option>")
                .attr("value", -1)
                .text("Все")
                .prop("selected", "selected"));

                smevRequest.prop("disabled", false);

            }
            else {
                $.ajax({
                    type: 'Get',
                    url: '/Filters/GetRequestForSmevServicesDataJson',
                    data: arr,
                    beforeSend: () => {
                        smevRequest.empty();
                        smevRequest.prop("disabled", true);
                    },
                    success: function (data) {
                        data.forEach(function (item) {
                            let selected = item.id === -1;

                            smevRequest.append($("<option></option>")
                            .attr("value", item.id)
                            .text(item.requestName)
                            .prop("selected", selected));
                        });
                        
                    },
                    complete: () => {
                        smevRequest.prop("disabled", false);
                    }
                });
            }
        });
    }

    if (sps.length) {
        $.ajax({
            type: 'Get',
            url: '/Filters/GetSpsMfcDataJson',
            data: {},
            beforeSend: () => {
                sps.empty();
                sps.prop("disabled", true);
            },
            success: function (data) {
                data.forEach(function (item) {
                    let selected = item.id === 0;

                    sps.append($("<option></option>")
                        .attr("value", item.id)
                        .text(item.office_name)
                        .prop("selected", selected));
                });
            },
            complete: () => {
                sps.prop("disabled", false);
            }
        });
    }
});