
var sendingForm = $('#statisticsForm'),
    btnSubmit = $('#statisticsSubmit'),
    sendingSmevForm = $('#statisticsSmevForm'),
    btnSmevSubmit = $('#statisticsSmevSubmit'),
    $tableMfcData = $('#dataTableMfc'),
    $tableEmployeeData = $('#dataTableEmployee'),
    $tableProviderData = $('#dataTableProvider'),
    $tableServiceData = $('#dataTableService'),
    $tableCustomerTypeData = $('#dataTableCustomerType'),
    $tableServiceTypeData = $('#dataTableServiceType'),
    $tableInteractionTypeData = $('#dataTableInteractionType'),
    $tableSmevData = $('#dataTableSmev'),
    $tableSmevMfcData = $('#dataTableSmevMfc'),
    $tableSmevEmployeeData = $('#dataTableSmevEmployee'),
    datePeriod = $('[data-range]'),
    providers = $('[data-provider]'),
    mfc = $('[data-mfc]'),
    employees = $('[data-employee]'),
    services = $('[data-services]'),
    smev = $('[data-smev]'),
    smevRequest = $('[data-smevRequest]'),
    statisticsTypeDay = $('[data-type-day]'),
    statisticsTypeYear = $('[data-type-year]'),
    year = $('[data-year]'),
    serviceType = $('[data-service-type]'),
    customerType = $('[data-customer-type]'),
    interactionType = $('[data-interaction-type]'),
    stage = $('[data-stage]');

$(document).ready(function () {

        new PerfectScrollbar("#scrollspy-wrapper");

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

        if (statisticsTypeDay.length) {
            statisticsTypeDay.change(function () {
                if ($(this).parents('form').find('[data-year]').length) {
                    $(this).parents('form').find('.wrapper').hide();
                    $(this).parents('form').find('[data-year]').prop('disabled', true);
                }
                if ($(this).parents('form').find('[data-submit]').length) {
                    $(this).parents('form').find('[data-submit]').click();
                }
            });
        }

        if (statisticsTypeYear.length) {
            statisticsTypeYear.change(function () {
                if ($(this).parents('form').find('[data-year]').length) {
                    $(this).parents('form').find('[data-year]').prop('disabled', false);
                    $(this).parents('form').find('.wrapper').show();
                }
                if ($(this).parents('form').find('[data-submit]').length) {
                    $(this).parents('form').find('[data-submit]').click();
                }
            });
        }

        $('#statisticsForm select').change(function() {
            if ($(this).parents('form').find('[data-submit]').length) {
                    $(this).parents('form').find('[data-submit]').click();
            }
        });

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
                        providers.each(function (index) {
                            $(this).append($("<option></option>")
                                .attr("value", item.id)
                                .text(item.officeName)
                                .prop("selected", selected));
                        });

                    });

                    $('[data-provider]').change();
                },
                complete: () => {
                    providers.prop("disabled", false);
                }
            });
        }

        if (services.length) {
            $('[data-provider]').on('change',function (e) {

                let isAll = false;
                let guidEmpty = '00000000-0000-0000-0000-000000000000';
                let arr = [];

                if($(e.target).val()===guidEmpty) {
                    isAll = true;
                    arr.push({ name: 'providersId', value: $(e.target).val() });
                } 

                //$.each($(e.target).val(), function (index, val) {
                //    if (val === guidEmpty) {
                //        isAll = true;

                //    }
                //    arr.push({ name: 'providersId', value: val });
                //})

                if (isAll) {
                    $(e.target).parents('form').find('[data-services]').append($("<option></option>")
                        .attr("value", guidEmpty)
                        .text("Все")
                        .prop("selected", "selected"));
                    $(e.target).parents('form').find('[data-services]').prop("disabled", false);
                }
                else {
                    $.ajax({
                        type: 'Get',
                        url: '/Filters/GetServicesForProviderDataJson',
                        data: arr,
                        beforeSend: () => {
                            $(e.target).parents('form').find('[data-services]').empty();
                            $(e.target).parents('form').find('[data-services]').prop("disabled", true);
                        },
                        success: function (data) {
                            data.forEach(function (item) {

                                let selected = item.id === '00000000-0000-0000-0000-000000000000';

                                $(e.target).parents('form').find('[data-services]').append($("<option></option>")
                                    .attr("value", item.id)
                                    .text(item.serviceName)
                                    .prop("selected", selected));
                            });
                        },
                        complete: () => {
                            $(e.target).parents('form').find('[data-services]').prop("disabled", false);
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


                    data.forEach(function (item) {

                        mfc.each(function (index) {

                            if ($(this).data("all") == false) {

                                $(this).append($("<option></option>")
                                .attr("value", item.id)
                                .text(item.officeName)
                                .prop("selected", item.selected)); 
                            }
                            else {
                                let selected = item.id === '00000000-0000-0000-0000-000000000000';
                                $(this).append($("<option></option>")
                                    .attr("value", item.id)
                                    .text(item.officeName)
                                    .prop("selected", selected));
                            }
                        });
                    });



                    //if ($(mfc).data("all")==false) {
                            
                    //}
                    //else {
                    //    data.forEach(function (item) {

                    //        let selected = item.id === '00000000-0000-0000-0000-000000000000';

                    //         mfc.each(function (index) {
                    //            $(this).append($("<option></option>")
                    //                .attr("value", item.id)
                    //                .text(item.officeName)
                    //                .prop("selected", selected));
                    //        });
                    //    });
                    //}
                    mfc.change();
                },
                complete: () => {
                    mfc.prop("disabled", false);
                }
            });

        }

        if (employees.length) {
            mfc.on('change', function (e) {

                let isAll = false;
                let guidEmpty = '00000000-0000-0000-0000-000000000000';
                let arr = [];

                    if($(e.target).val()===guidEmpty) {
                    isAll = true;
                    arr.push({ name: 'employeeId', value: $(e.target).val() });
                } 

                //$.each($(e.target).val(), function (index, val) {
                //    if (val === guidEmpty) {
                //        isAll = true;

                //    }
                //    arr.push({ name: 'employeeId', value: val });
                //})

                if (isAll) {
                   
                        $(e.target).parents('form').find('[data-employee]').append($("<option></option>")
                        .attr("value", guidEmpty)
                        .text("Все")
                        .prop("selected", "selected"));

                        $(e.target).parents('form').find('[data-employee]').prop("disabled", false);
                }
                else {

                    $.ajax({
                        type: 'Get',
                        url: '/Filters/GetEmployeesForReceptionOfficeDataJson',
                        data: arr,
                        beforeSend: () => {
                                $(e.target).parents('form').find('[data-employee]').empty();
                            $(e.target).parents('form').find('[data-employee]').prop("disabled", true);
                        },
                        success: function (data) {
                            if (data.length === 1) {
                                data.forEach(function (item) {
                                        $(e.target).parents('form').find('[data-employee]').append($("<option></option>")
                                        .attr("value", item.id)
                                        .text(item.officeName)
                                        .prop("selected", "selected"));
                                });
                            }
                            else {
                                data.forEach(function (item) {

                                    let selected = item.id === '00000000-0000-0000-0000-000000000000';

                                        $(e.target).parents('form').find('[data-employee]').append($("<option></option>")
                                        .attr("value", item.id)
                                        .text(item.officeName)
                                        .prop("selected", selected));
                                });
                            }
                        },
                        complete: () => {
                            $(e.target).parents('form').find('[data-employee]').prop("disabled", false);
                        }
                    });
                }
            });
        }

        if (customerType.length) {
            $.ajax({
                type: 'Get',
                url: '/Filters/GetServiceCustomerTypeDataJson',
                data: { },
                beforeSend: () => {
                    customerType.empty();
                    customerType.prop("disabled", true);
                },
                success: function (data) {
                    if (data.length === 1) {
                        data.forEach(function (item) {
                            customerType.each(function (index) {
                                $(this).append($("<option></option>")
                                    .attr("value", item.id)
                                    .text(item.typeName)
                                    .prop("selected", "selected"));
                            })
                        });
                    }
                    else {
                        data.forEach(function (item) {

                            let selected = item.id === -1;

                            customerType.each(function (index) {
                                $(this).append($("<option></option>")
                                .attr("value", item.id)
                                .text(item.typeName)
                                .prop("selected", selected));
                            })
                        });
                    }
                },
                complete: () => {
                    customerType.prop("disabled", false);
                }
            });
        }

        if (serviceType.length) {
            $.ajax({
                type: 'Get',
                url: '/Filters/GetServiceTypeDataJson',
                data: { },
                beforeSend: () => {
                    serviceType.empty();
                    serviceType.prop("disabled", true);
                },
                success: function (data) {
                    if (data.length === 1) {
                        data.forEach(function (item) {

                            serviceType.each(function (index) {
                                $(this).append($("<option></option>")
                                    .attr("value", item.id)
                                    .text(item.name)
                                    .prop("selected", "selected"));
                            })
                        });
                    }
                    else {
                        data.forEach(function (item) {

                            let selected = item.id === -1;

                            serviceType.each(function (index) {
                                $(this).append($("<option></option>")
                                    .attr("value", item.id)
                                    .text(item.name)
                                    .prop("selected", selected));
                            })
                        });
                    } 
                },
                complete: () => {
                    serviceType.prop("disabled", false);
                }
            });

        }

        if (interactionType.length) {
            $.ajax({
                type: 'Get',
                url: '/Filters/GetServiceInteractionTypeDataJson',
                data: { },
                beforeSend: () => {
                    interactionType.empty();
                    interactionType.prop("disabled", true);
                },
                success: function (data) {
                    if (data.length === 1) {
                        data.forEach(function (item) {

                            interactionType.each(function (index) {
                                $(this).append($("<option></option>")
                                    .attr("value", item.id)
                                    .text(item.name)
                                    .prop("selected", "selected"));
                            })
                        });
                    }
                    else {
                        data.forEach(function (item) {

                            let selected = item.id === -1;

                            interactionType.each(function (index) {
                                $(this).append($("<option></option>")
                                    .attr("value", item.id)
                                    .text(item.name)
                                .prop("selected", selected));
                            })
                        });
                    }
                },
                complete: () => {
                    interactionType.prop("disabled", false);
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

                        smev.each(function (index) {
                                $(this).append($("<option></option>")
                                .attr("value", item.id)
                                .text(item.smevName)
                                .prop("selected", selected));
                        })
                    });

                    $('[data-smev]').change();
                },
                complete: () => {
                    smev.prop("disabled", false);
                }
            });
        }

        if (smevRequest.length) {
            $('[data-smev]').on('change', function (e) {

                let isAll = false;
                let guidEmpty = '00000000-0000-0000-0000-000000000000';
                let arr = [];

                if($(e.target).val()===guidEmpty) {
                    isAll = true;
                    arr.push({ name: 'smevId', value: $(e.target).val() });
                } 

                //$.each($(e.target).val(), function (index, val) {
                //    if (val === guidEmpty) {
                //        isAll = true;

                //    }
                //    arr.push({ name: 'smevId', value: val });
                //})

                if (isAll) {
                    $(e.target).parents('form').find('[data-smevRequest]').append($("<option></option>")
                        .attr("value", -1)
                        .text("Все")
                        .prop("selected", "selected"));

                    $(e.target).parents('form').find('[data-smevRequest]').prop("disabled", false);

                }
                else {
                    $.ajax({
                        type: 'Get',
                        url: '/Filters/GetRequestForSmevServicesDataJson',
                        data: arr,
                        beforeSend: () => {
                            $(e.target).parents('form').find('[data-smevRequest]').empty();
                            $(e.target).parents('form').find('[data-smevRequest]').prop("disabled", true);
                        },
                        success: function (data) {
                            data.forEach(function (item) {
                                let selected = item.id === -1;

                                $(e.target).parents('form').find('[data-smevRequest]').append($("<option></option>")
                                    .attr("value", item.id)
                                    .text(item.requestName)
                                    .prop("selected", selected));
                            });

                        },
                        complete: () => {
                            $(e.target).parents('form').find('[data-smevRequest]').prop("disabled", false);
                        }
                    });
                }
            });
        }

        btnSubmit.on('click', function (event) {
            event.preventDefault();
            event.stopPropagation();
            let formData = sendingForm.serialize();
            let $type_chart = 'line',
                $edizm = $(this).attr("data-edizm"),
                $names = $(this).attr("data-names");

            $.ajax({
                type: sendingForm.attr('method'),
                url: sendingForm.attr('action'),
                data: formData,
                beforeSend: () => {
                    $("#chart").html('<div class="h-75 w-100 d-flex align-items-center justify-content-center"><div class="spinner-grow text-primary" role="status"></div></div>');
                    btnSubmit.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>');
                    btnSubmit.prop('disabled', true);
                },
                success: function (dataJson) {
                    $("#chart").empty()
                    $('#graphic').addClass('show');
                    GenerateChart(dataJson, $type_chart, $names, $edizm, false);
                },
                complete: () => {
                    btnSubmit.prop('disabled', false);
                    btnSubmit.html('Cформировать')
                }
            });
        })

        function GenerateChart(data, type_chart, names, edizm, transform) {
            if (transform != true) {
                chart = c3.generate({
                    bindto: '#chart',
                    size: { height: 400 },
                    zoom: { enabled: true },
                    data: {
                        json: data,
                        type: type_chart,
                        labels: true,
                        names: { 'value': names },
                        keys: { x: 'name', value: ['value'] },
                    },
                    axis: {
                        x: {
                            type: 'category', tick: { rotate: 90, multiline: false }, label: { text: 'Период', position: 'outer-right' }
                        },
                        y: { label: { text: edizm, position: 'outer-top' } }
                    },
                    grid: { x: { show: true }, y: { show: true } }
                });
            }
            else {
                chart.transform(type_chart);
            }
        }

        btnSmevSubmit.on('click', function (event) {
            event.preventDefault();
            event.stopPropagation();
            let formData = sendingSmevForm.serialize();
            let $type_chart = 'line',
                $edizm = $(this).attr("data-edizm"),
                $names = $(this).attr("data-names");

            $.ajax({
                type: sendingSmevForm.attr('method'),
                url: sendingSmevForm.attr('action'),
                data: formData,
                beforeSend: () => {
                    $("#chartSmev").html('<div class="h-75 w-100 d-flex align-items-center justify-content-center"><div class="spinner-grow text-primary" role="status"></div></div>');
                    btnSubmit.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>');
                    btnSubmit.prop('disabled', true);
                },
                success: function (dataJson) {
                    $("#chartSmev").empty()
                    $('#graphic').addClass('show');
                    GenerateSmevChart(dataJson, $type_chart, $names, $edizm, false);
                },
                complete: () => {
                    btnSubmit.prop('disabled', false);
                    btnSubmit.html('Cформировать')
                }
            });
        })

        function GenerateSmevChart(data, type_chart, names, edizm, transform) {
            if (transform != true) {
                chart = c3.generate({
                    bindto: '#chartSmev',
                    size: { height: 400 },
                    zoom: { enabled: true },
                    data: {
                        json: data,
                        type: type_chart,
                        labels: true,
                        x: 'date'
                        //names: { 'value': names },
                        //keys: { x: 'name', value: ['value'] },
                    },
                    axis: {
                        x: {
                            type: 'category', tick: { rotate: 90, multiline: false }, label: { text: 'Период', position: 'outer-right' }
                        },
                        y: { label: { text: edizm, position: 'outer-top' } }
                    },
                    grid: { x: { show: true }, y: { show: true } }
                });
            }
            else {
                chart.transform(type_chart);
            }
        }

        if ($('[data-submit]').length) {
            $('[data-submit]').click();
        }

        $tableMfcData.DataTable({
            sDom:   "<'row'<'col-sm-12'tr>>" +
                    "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsMfcForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsMfcForm');
                    var formData = new FormData(form);
                            
                    for (var pair of formData.entries()) {
                        if (pair[1]) {data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {
                $('#statisticsMfcForm select').change(function () {
                        $tableMfcData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsMfcForm [data-range]').on('changeDate', function() {
                    $tableMfcData.DataTable().ajax.reload();
                    return false;
                });
            },
            columns: [
                { data: "name" },
                { data: "receivedCount" },
                { data: "receivedStateSum" },
                { data: "issuedCount" },
                { data: "consultationCount" },
                { data: "allCount" },
                { data: "refusalCount" },
                { data: "expiredCount" },
                { data: "expiredPercentCount" },
                { data: "serviceStateTaskCount" },
                { data: "serviceStateTaskPercentCount" },
            ]
        });

        $tableEmployeeData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsEmployeeForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsEmployeeForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {


                    $('#statisticsEmployeeForm select').change(function () {
                    $tableEmployeeData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsEmployeeForm [data-range]').on('changeDate', function () {
                    $tableEmployeeData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "receivedCount" },
                { data: "receivedStateSum" },
                { data: "issuedCount" },
                { data: "consultationCount" },
                { data: "allCount" },
                { data: "refusalCount" },
                { data: "expiredCount" },
                { data: "expiredPercentCount" },
                { data: "serviceStateTaskCount" },
                { data: "serviceStateTaskPercentCount" },
            ]
        });

        $tableProviderData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsProviderForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsProviderForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {

                    $('#statisticsProviderForm select').change(function () {
                    $tableProviderData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsProviderForm [data-range]').on('changeDate', function () {
                    $tableProviderData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "receivedCount" },
                { data: "receivedStateSum" },
                { data: "issuedCount" },
                { data: "consultationCount" },
                { data: "allCount" },
                { data: "refusalCount" },
                { data: "expiredCount" },
                { data: "expiredPercentCount" },
                { data: "serviceStateTaskCount" },
                { data: "serviceStateTaskPercentCount" },
            ]
        });

        $tableServiceData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsServiceForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsServiceForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {


                    $('#statisticsServiceForm select').change(function () {
                        $tableServiceData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsServiceForm [data-range]').on('changeDate', function () {
                    $tableServiceData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "receivedCount" },
                { data: "receivedStateSum" },
                { data: "issuedCount" },
                { data: "consultationCount" },
                { data: "allCount" },
                { data: "refusalCount" },
                { data: "expiredCount" },
                { data: "expiredPercentCount" },
                { data: "serviceStateTaskCount" },
                { data: "serviceStateTaskPercentCount" },
            ]
        });

        $tableCustomerTypeData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsCustomerTypeForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsCustomerTypeForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {


                    $('#statisticsCustomerTypeForm select').change(function () {
                    $tableCustomerTypeData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsCustomerTypeForm [data-range]').on('changeDate', function () {
                    $tableCustomerTypeData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "receivedCount" },
                { data: "receivedStateSum" },
                { data: "issuedCount" },
                { data: "consultationCount" },
                { data: "allCount" },
                { data: "refusalCount" },
                { data: "expiredCount" },
                { data: "expiredPercentCount" },
                { data: "serviceStateTaskCount" },
                { data: "serviceStateTaskPercentCount" },
            ]
        });

        $tableServiceTypeData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsServiceTypeForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsServiceTypeForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {

                $('#statisticsServiceTypeForm select').change(function () {
                    $tableServiceTypeData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsServiceTypeForm [data-range]').on('changeDate', function () {
                    $tableServiceTypeData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "receivedCount" },
                { data: "receivedStateSum" },
                { data: "issuedCount" },
                { data: "consultationCount" },
                { data: "allCount" },
                { data: "refusalCount" },
                { data: "expiredCount" },
                { data: "expiredPercentCount" },
                { data: "serviceStateTaskCount" },
                { data: "serviceStateTaskPercentCount" },
            ]
        });

        $tableInteractionTypeData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsInteractionTypeForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsInteractionTypeForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {

                $('#statisticsInteractionTypeForm select').change(function () {
                    $tableInteractionTypeData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsInteractionTypeForm [data-range]').on('changeDate', function () {
                    $tableInteractionTypeData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "receivedCount" },
                { data: "receivedStateSum" },
                { data: "issuedCount" },
                { data: "consultationCount" },
                { data: "allCount" },
                { data: "refusalCount" },
                { data: "expiredCount" },
                { data: "expiredPercentCount" },
                { data: "serviceStateTaskCount" },
                { data: "serviceStateTaskPercentCount" },
            ]
        });

        $tableSmevData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsSmevDataForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsSmevDataForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {

                $('#statisticsSmevDataForm select').change(function () {
                    $tableSmevData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsSmevDataForm [data-range]').on('changeDate', function () {
                    $tableSmevData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "sentCount" },
                { data: "receivedCount" },
            ]
        });

        $tableSmevMfcData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsSmevMfcForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsSmevMfcForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {

                $('#statisticsSmevMfcForm select').change(function () {
                    $tableSmevMfcData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsSmevMfcForm [data-range]').on('changeDate', function () {
                    $tableSmevMfcData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "sentCount" },
                { data: "receivedCount" },
            ]
        });

        $tableSmevEmployeeData.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            info: false,
            searchDelay: 1500,
            ajax: {
                url: $('#statisticsSmevEmployeeForm').attr('action'),
                type: "POST",
                data: function (data) {
                    let form = document.querySelector('#statisticsSmevEmployeeForm');
                    var formData = new FormData(form);

                    for (var pair of formData.entries()) {
                        if (pair[1]) { data[pair[0]] = pair[1]; }
                    }
                },
            },
            initComplete: function () {

                $('#statisticsSmevEmployeeForm select').change(function () {
                    $tableSmevEmployeeData.DataTable().ajax.reload();
                    return false;
                });

                $('#statisticsSmevEmployeeForm [data-range]').on('changeDate', function () {
                    $tableSmevEmployeeData.DataTable().ajax.reload();
                    return false;
                });

                //$('#statisticsEmployeeForm [data-mfc]').change();

            },
            columns: [
                { data: "name" },
                { data: "sentCount" },
                { data: "receivedCount" },
            ]
        });

        $('#statistics .nav-link').each(function () {
            $(this).click(function () { 
            $(this).parent().find('.nav-link.active').attr('class','nav-link');
            $(this).attr('class', 'nav-link active');

        })
        })

});
