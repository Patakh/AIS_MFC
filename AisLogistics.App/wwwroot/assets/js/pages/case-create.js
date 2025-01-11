$(function () {
    "use strict";
    const createCaseWizard = document.querySelector('#create-case-wizard'),
        createCaseWizardForm = createCaseWizard.querySelector('#create-case-wizard-form'),
        createCaseWizardFormStep1 = createCaseWizardForm.querySelector('#service-step'),
        createCaseWizardFormStep2 = createCaseWizardForm.querySelector('#personal-info-step'),
        createCaseWizardFormStep3 = createCaseWizardForm.querySelector('#additional-data-step'),
        createCaseWizardFormStep5 = createCaseWizardForm.querySelector('#final-step'),
        createCaseWizardNext = [].slice.call(createCaseWizardForm.querySelectorAll('.btn-next')),
        createCaseWizardPrev = [].slice.call(createCaseWizardForm.querySelectorAll('.btn-prev')),
        skipThreeStep = $("#skip-three-step"),
        createCaseWizardAdditionalForm = $("#additional-data"),
        pickadate = $(".pickadate"),
        btnNextSecondStep = $('#btn-next-second-step'),
        btnFormSubmit = $('#btn-form-submit'),
        servicesTable = $('#services-table'),
        serviceProcedureTable = $('#service-procedure-table'),
        serviceProcedureTableContainer = $('#service-procedure-table-container '),
        serviceTariffTable = $('#service-tariff-table'),
        serviceTariffTableContainer = $('#service-tariff-table-container '),
        serviceProviderTable = $('#service-provider-table'),
        servicesTableSearch = $("#services-table-search"),
        servicesTableOffice = $("#services-table-office"),
        servicesTableCustomerTypes = $("#services-table-customerTypes"),
        servicesTableHashtag = $("[data-hashtag-value]"),
        checksCustomerAddressCoincide = $('#customerAddressCoincide'),
        checksRepresentativeAddressCoincide = $('#representativeAddressCoincide'),
        representativeWizardForm = $('#representative-info'),
        customerPhysicalWrapper = $('#wrapperCustomerPhysical'),
        customerLegalWrapper = $('#wrapperCustomerLegal'),
        representativeAlertForm = $('#wrapperRepresentativeAlert'),
        customerPhysicalAlertWrapper = $('#wrapperCustomerAlert'), 
        showBlancsSidebar = $('#blancs-tab'),
        showFilesSidebar = $('#files-tab'),
        showStagesSidebar = $('[data-service-stages]'),
        customer = {
            documentsIdentityId: $("#customer_SDocumentsIdentityId"),
            documentSerial: $("#customer_DocumentSerial"),
            documentNumber: $("#customer_DocumentNumber"),
            documentIssueDate: $("#customer_DocumentIssueDate"),
            documentCode: $("#customer_DocumentCode"),
            documentIssueBody: $("#customer_DocumentIssueBody"),
            documentBirthPlace: $("#customer_DocumentBirthPlace"),
            address: $("#customer_CustomerAddress"),
            addressResidence: $("#customer_CustomerAddressResidence"),
            addressTemp: $("#customer_CustomerAddressTemp"),
            firstName: $("#customer_FirstName"),
            lastName: $("#customer_LastName"),
            secondName: $("#customer_SecondName"),
            gender: $("[name='customer.CustomerGender']"),
            snils: $("#customer_CustomerSnils"),
            inn: $("#customer_CustomerInn"),
            phone1: $("#customer_CustomerPhone1"),
            phone2: $("#customer_CustomerPhone2"),
            isGetCustomerSnils: $('#isGetCustomerSnils'),
            isGetCustomerInn: $('#isGetCustomerInn')
        },
        customerLegal = {
            type: $("#customerLegal_SServicesCustomerTypeId"),
            name: $("#customerLegal_CustomerName"),
            address: $("#customerLegal_CustomerAddress"),
            inn: $("#customerLegal_CustomerInn"),
            kpp: $("#customerLegal_CustomerKpp"),
            ogrn: $("#customerLegal_CustomerOgrn"),
            okato: $("#customerLegal_CustomerOkato"),
            oktmo: $("#customerLegal_CustomerOktmo"),
            firstName: $("#customerLegal_HeadFirstName"),
            lastName: $("#customerLegal_HeadLastName"),
            secondName: $("#customerLegal_HeadSecondName"),
            position: $("#customerLegal_HeadPosition"),
            phone1: $("#customerLegal_CustomerPhone1"),
            phone2: $("#customerLegal_CustomerPhone2")
        },
        representative = {
            documentsIdentityId: $("#representative_SDocumentsIdentityId"),
            documentSerial: $("#representative_DocumentSerial"),
            documentNumber: $("#representative_DocumentNumber"),
            documentIssueDate: $("#representative_DocumentIssueDate"),
            documentCode: $("#representative_DocumentCode"),
            documentIssueBody: $("#representative_DocumentIssueBody"),
            documentBirthPlace: $("#representative_DocumentBirthPlace"),
            address: $("#representative_CustomerAddress"),
            addressResidence: $("#representative_CustomerAddressResidence"),
            addressTemp: $("#representative_CustomerAddressTemp"),
            firstName: $("#representative_FirstName"),
            lastName: $("#representative_LastName"),
            secondName: $("#representative_SecondName"),
            gender: $("[name='representative.CustomerGender']"),
            snils: $("#representative_CustomerSnils"),
            inn: $("#representative_CustomerInn"),
            phone1: $("#representative_CustomerPhone1"),
            phone2: $("#representative_CustomerPhone2"),
            isGetCustomerSnils: $('#isGetRepresentativeSnils'),
            isGetCustomerInn: $('#isGetRepresentativeInn')
        },
        stageReceived = 1,
        stageСonsultation = 34;

    var FormValidation1 = null,
        FormValidation2 = null,
        FormValidation3 = null,
        CustomerInfo = null;

    const setGender = {
        identify: (type) => {
            if (type === "MALE")
                $(customer.gender[0]).prop("checked", true);
            else
                $(customer.gender[1]).prop("checked", true);
        }
    };

    const setGenderRepresentative = {
        identify: (type) => {
            if (type === "MALE")
                $(representative.gender[0]).prop("checked", true);
            else
                $(representative.gender[1]).prop("checked", true);
        }
    };

    const serviceProcedureTableVisibility = {
        show: () => {
            serviceProcedureTableContainer.removeClass("d-none");
            serviceProcedureTable.DataTable().ajax.reload();
            window.scrollBy(0, 1000);
        },
        hide: () => {
            btnNextSecondStepActive.disabled();
            serviceProcedureTableContainer.addClass("d-none");
        }
    };

    const serviceTariffTableVisibility = {
        show: () => {
            serviceTariffTableContainer.removeClass("d-none");
            serviceTariffTable.DataTable().ajax.reload();
           /* serviceProviderTable.DataTable().ajax.reload();*/
            window.scrollBy(0, 1000);
        },
        hide: () => {
            btnNextSecondStepActive.disabled();
            serviceTariffTableContainer.addClass("d-none");
        }
    };

    const btnNextSecondStepActive = {
        enabled: () => {
            btnNextSecondStep.attr("disabled", false);
        },
        disabled: () => {
            btnNextSecondStep.attr("disabled", true);
        }
    };

    const btnFormSubmitActive = {
        enabled: () => {
            btnFormSubmit.attr("disabled", false);
        },
        disabled: () => {
            btnFormSubmit.attr("disabled", true);
        }
    };

    const findCustomerByDocument = {
        load: (type) => {
            if (type == 1) {
                if (customer.documentSerial.inputmask("isComplete") === true && customer.documentNumber.inputmask("isComplete") === true) {
                    $.ajax({
                        url: '/Cases/FindCustomerByDocumentDataJson',
                        type: 'POST',
                        data: {
                            serial: customer.documentSerial.val(),
                            number: customer.documentNumber.val()
                        },
                        success: function (data) {
                            if (!data) return;
                            createCaseWizardFormStep2.querySelectorAll('input[type="text"]').forEach((e) => {
                                let name = e.name.split('.')[1];
                                if (e.name.split('.')[0] !== "customer") return;
                                if (!name) return;
                                let newValue = data[name.charAt(0).toLowerCase() + name.slice(1)];
                                if (!newValue) return;
                                if (e.classList.contains("pickadate")) newValue = moment(newValue).format("DD.MM.YYYY");
                                e.value = newValue;
                            });
                            setGender.identify(data["customerGender"] === 1 ? "MALE" : "FEMALE");
                            if (data['customerSnils'] != null && data['customerSnils'] != "") $(customer.isGetCustomerSnils).prop("checked", false);
                            if (data['customerInn'] != null && data['customerInn'] != "") $(customer.isGetCustomerInn).prop("checked", false);
                            if (data["addressDetails"] != null) {
                                fillAddress(data["addressDetails"], $('#CustomerAddressDetails'));
                            }
                            toastr.success('<p style="line-height: 1.2;" class="mt-1 small">Данные заполнились автоматически.</p><button type="button" class="btn btn-sm btn-secondary">Отменить</button>', 'Найден заявитель', {
                                timeOut: 3500, extendedTimeOut: 3500, preventDuplicates: true,
                                onclick: function () { findCustomerByDocument.clear(); }
                            });
                        }
                    });
                }
                else return;
            }
            else if (type == 2) {
                if (representative.documentSerial.inputmask("isComplete") === true && representative.documentNumber.inputmask("isComplete") === true) {
                    $.ajax({
                        url: '/Cases/FindCustomerByDocumentDataJson',
                        type: 'POST',
                        data: {
                            serial: representative.documentSerial.val(),
                            number: representative.documentNumber.val()
                        },
                        success: function (data) {
                            if (!data) return;
                            createCaseWizardFormStep2.querySelectorAll('input[type="text"]').forEach((e) => {
                                let name = e.name.split('.')[1];
                                if (e.name.split('.')[0] !== "representative") return;
                                if (!name) return;
                                let newValue = data[name.charAt(0).toLowerCase() + name.slice(1)];
                                if (!newValue) return;
                                if (e.classList.contains("pickadate")) newValue = moment(newValue).format("DD.MM.YYYY");
                                e.value = newValue;
                            });
                            setGenderRepresentative.identify(data["customerGender"] === 1 ? "MALE" : "FEMALE");
                            if (data['customerSnils'] != null && data['customerSnils'] != "") $(representative.isGetCustomerSnils).prop("checked", false);
                            if (data['customerInn'] != null && data['customerInn'] != "") $(representative.isGetCustomerInn).prop("checked", false);
                            if (data["addressDetails"] != null) {
                                fillAddress(data["addressDetails"], $('#RepresentativeAddressDetails'));
                            }
                            toastr.success('<p style="line-height: 1.2;" class="mt-1 small">Данные заполнились автоматически.</p><button type="button" class="btn btn-sm btn-secondary">Отменить</button>', 'Найден заявитель', {
                                timeOut: 3500, extendedTimeOut: 3500, preventDuplicates: true,
                                onclick: function () { findCustomerByDocument.clear(); }
                            });
                        }
                    });
                }
                else return;

            }
            else if (type == 3) {
                if (customerLegal.inn.inputmask("isComplete") === true) {
                    $.ajax({
                        url: '/Cases/FindLegalByInnDataJson',
                        type: 'POST',
                        data: {
                            inn: customerLegal.inn.val(),
                        },
                        success: function (data) {
                            if (!data) return;
                            createCaseWizardFormStep2.querySelectorAll('input[type="text"]').forEach((e) => {
                                let name = e.name.split('.')[1];
                                if (e.name.split('.')[0] !== "customerLegal") return;
                                if (!name) return;
                                let newValue = data[name.charAt(0).toLowerCase() + name.slice(1)];
                                if (!newValue) return;
                                if (e.classList.contains("pickadate")) newValue = moment(newValue).format("DD.MM.YYYY");
                                e.value = newValue;
                            });
                            toastr.success('<p style="line-height: 1.2;" class="mt-1 small">Данные заполнились автоматически.</p><button type="button" class="btn btn-sm btn-secondary">Отменить</button>', 'Найден заявитель', {
                                timeOut: 3500, extendedTimeOut: 3500, preventDuplicates: true,
                                onclick: function () { findCustomerByDocument.clear(); }
                            });
                        }
                    });
                }
                else return;
            }
        },
        clear: () => {
            createCaseWizardFormStep2.querySelectorAll('input[type="text"]').forEach((e) => { e.value = ""; });
            setGender.identify("MALE");
        }
    };

    const additionalForms = {
        load: () => {
            let action = serviceProcedureTable.DataTable().rows({ selected: true }).data()[0]['additionalFormPath'];
            if (!action) {
                var newDiv = document.createElement("div");
                newDiv.classList.add("text-center")
                newDiv.innerHTML = "<p>Нет данных</p>";
                createCaseWizardAdditionalForm.html(newDiv);
                return;
            };
            $.ajax({
                url: `/Cases/${action}`,
                type: 'Get',
                success: function (content) {
                    if (!content) {
                        var newDiv = document.createElement("div");
                        newDiv.innerHTML = "<p>Нет данных</p>";
                        createCaseWizardAdditionalForm.html(newDiv);
                        return;
                    };

                    createCaseWizardAdditionalForm.html(content);
                    additionalForms.initValidation();
                }
            });
        },
        clear: () => {
            additionalForms.removeValidation();
            createCaseWizardAdditionalForm.empty();
            if (typeof additionalFormValidation === "function")
                additionalFormValidation = null;
        },
        initValidation: () => {
            if (typeof additionalFormValidation !== "function") return;
            let rules = additionalFormValidation();
            rules.forEach(obj => {
                Object.entries(obj).forEach(([key, value]) => {
                    FormValidation2.addField(key, value);
                });
            });
        },
        removeValidation: () => {
            if (typeof additionalFormValidation !== "function") return;
            let rules = additionalFormValidation();
            rules.forEach(obj => {
                Object.entries(obj).forEach(([key]) => {
                    FormValidation2.removeField(key);
                });
            });
        }
    }

    const initComponents = () => {
        const validationStepper = new Stepper(createCaseWizard, { linear: true });
        FormValidation1 = FormValidation.formValidation(createCaseWizardFormStep1, {
            plugins: {
                trigger: new FormValidation.plugins.Trigger(),
                submitButton: new FormValidation.plugins.SubmitButton()
            }
        }).on('core.form.valid', () => {
            additionalForms.load();
            validationStepper.next();
        });


        function selectCustomer(e) {
            if (e === '1912196') {
                visibliBlock(customerLegalWrapper, true);
                visibliBlock(representativeWizardForm, true);
                visibliBlock(representativeAlertForm, true);
                visibliBlock(customerPhysicalWrapper, false);
                visibliBlock(customerPhysicalAlertWrapper, false);
                skipThreeStep.removeClass('disabled');
                FormValidation2 = FormValidation.formValidation(createCaseWizardFormStep2, {
                    locale: 'ru_RU',
                    localization: FormValidation.locales.ru_RU,
                    fields: {
                        'customer.DocumentSerial': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.DocumentNumber': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.DocumentIssueDate': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.LastName': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.FirstName': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.DocumentBirthDate': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.DocumentBirthPlace': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.DocumentCode': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.DocumentIssueBody': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customer.CustomerSnils': {
                            validators: {
                                callback: {
                                    callback: validateSnils,
                                    enabled: true
                                }
                            }
                        },
                        'representative.DocumentSerial': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.DocumentNumber': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.DocumentIssueDate': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.LastName': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.FirstName': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.DocumentBirthDate': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.DocumentBirthPlace': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.DocumentCode': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.DocumentIssueBody': {
                            validators: {
                                notEmpty: {
                                    enabled: false
                                }
                            }
                        },
                        'representative.CustomerSnils': {
                            validators: {
                                callback: {
                                    callback: validateSnils,
                                    enabled: false
                                }
                            }
                        }
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger(),
                        bootstrap5: new FormValidation.plugins.Bootstrap5(),
                        autoFocus: new FormValidation.plugins.AutoFocus(),
                        submitButton: new FormValidation.plugins.SubmitButton()
                    },
                    init: instance => {
                        instance.on('plugins.message.placed', function (e) {
                            //* Move the error message out of the `input-group` element
                            if (e.element.parentElement.classList.contains('input-group')) {
                                e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
                            }
                        });
                    }
                }).on('core.form.valid', () => { validationStepper.next(); });
            }
            else {
                visibliBlock(customerPhysicalWrapper, true);
                visibliBlock(customerPhysicalAlertWrapper, true);
                visibliBlock(customerLegalWrapper, false);
                visibliBlock(representativeWizardForm, false);
                visibliBlock(representativeAlertForm, false);
                skipThreeStep.addClass('disabled');
                FormValidation2 = FormValidation.formValidation(createCaseWizardFormStep2, {
                    locale: 'ru_RU',
                    localization: FormValidation.locales.ru_RU,
                    fields: {
                        'customerLegal.CustomerInn': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customerLegal.CustomerName': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'customerLegal.CustomerAddress': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.DocumentSerial': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.DocumentNumber': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.DocumentIssueDate': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.LastName': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.FirstName': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.DocumentBirthDate': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.DocumentBirthPlace': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.DocumentCode': {
                            validators: {
                                notEmpty: {
                                    enabled: true
                                }
                            }
                        },
                        'representative.DocumentIssueBody': {
                            validators: {
                                notEmpty: {}
                            }
                        },
                        'representative.CustomerSnils': {
                            validators: {
                                callback: {
                                    callback: validateSnils,
                                    enabled: true,
                                }
                            }
                        }
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger(),
                        bootstrap5: new FormValidation.plugins.Bootstrap5(),
                        autoFocus: new FormValidation.plugins.AutoFocus(),
                        submitButton: new FormValidation.plugins.SubmitButton()
                    },
                    init: instance => {
                        instance.on('plugins.message.placed', function (e) {
                            //* Move the error message out of the `input-group` element
                            if (e.element.parentElement.classList.contains('input-group')) {
                                e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
                            }
                        });
                    }
                }).on('core.form.valid', () => { validationStepper.next(); });

            }
        }

        selectCustomer(servicesTableCustomerTypes.val());


        FormValidation3 = FormValidation.formValidation(createCaseWizardFormStep3, {
            plugins: {
                trigger: new FormValidation.plugins.Trigger(),
                submitButton: new FormValidation.plugins.SubmitButton()
            }
        }).on('core.form.valid', () => {
            validationStepper.next();
        });

        if (config.debug) {
            btnNextSecondStepActive.enabled();
            btnFormSubmitActive.enabled();
            for (const [key] of Object.entries(FormValidation2.getFields())) {
                FormValidation2.removeField(key);
            }
        }

        servicesTableOffice.select2({
            placeholder: "Орган власти",
            language: 'ru',
            allowClear: true
        });

        servicesTableCustomerTypes.select2({
            language: 'ru'
        });

        /* init Service DataTable */
        servicesTable.DataTable({
            sDom: "<'row'<'col-sm-12'tr>><'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            select: {
                info: false
            },
            drawCallback: function () {
                this.trigger("deselect");
            },
            ajax: {
                url: "/Cases/GetServicesDataJson",
                type: "POST",
                data: function (data) {
                    data.query = servicesTableSearch.val();
                    data.officeId = servicesTableOffice.val();
                    data.customresType = servicesTableCustomerTypes.val();
                }
            },
            columns: [
                {
                    title: "Услуга",
                    data: "name",
                    render: function (data, type, row) {
                        let content = "";
                        content += `<div class="r-s-14">${data}</div>`;
                        content += `<div class="r-l-12">${row.providerName}</div>`;
                        return content;
                    }
                },
                {
                    title: 'Действия',
                    target: -1,
                    select: false,
                    render: function (data, type, row) {
                        let favorite = row.isFavorite ? "favorite" : "";
                        return `<span class="service-favorite" id="service-favorite" data-service-id="${row.id}" data-bs-toggle="tooltip" title="Избранное"><svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-star ${favorite}"><polygon points="12 2 15.09 8.26 22 9.27 17 14.14 18.18 21.02 12 17.77 5.82 21.02 7 14.14 2 9.27 8.91 8.26 12 2"></polygon></svg></span >`;
                    }
                }
            ]
        })
            .on('select', () => { serviceProcedureTableVisibility.show(); })
            .on('deselect', () => {
                serviceProcedureTableVisibility.hide();
                serviceTariffTableVisibility.hide();
            })
            .on('click', '#service-favorite', function (e) { favoriteStarOnClick(e) });

        servicesTableSearch.on('input', _.debounce(() => { servicesTable.DataTable().ajax.reload(null, true); }, 500));

        servicesTableSearch.on('search', _.debounce(() => { servicesTable.DataTable().ajax.reload(null, true); }, 500));

        servicesTableOffice.on('change', _.debounce(() => { servicesTable.DataTable().ajax.reload(null, true); }, 500));

        servicesTableCustomerTypes.on('change', _.debounce((e) => {
            servicesTable.DataTable().ajax.reload(null, true);
            selectCustomer($(e.currentTarget).val());
        }, 500));

        servicesTableHashtag.each(function () {
            $(this).on('click', function () {
                let $this = $(this).data("hashtagValue");
                let search = servicesTableSearch.val();
                servicesTableSearch.val(search + $this);
                servicesTableSearch.trigger("search");
            });
        });

        const caseFavorite = {
            set: (id) => {
                fetch(`/Cases/SetServiceFavorite?id=${id}`);
            },
            remove: (id) => {
                fetch(`/Cases/RemoveServiceFavorite?id=${id}`);
            }
        }

        function favoriteStarOnClick(e) {
            let th = e.currentTarget;
            $(th).find('svg').toggleClass('favorite');
            e.stopPropagation();
            let id = $(th).data('service-id');
            // show toast only have favorite class
            if ($(th).find('svg').hasClass('favorite')) {
                caseFavorite.set(id);
                toastr['success']('Услуга добавлена в избранное', 'Готово', {
                    closeButton: true,
                    tapToDismiss: false,
                    rtl: false
                });
            }
            else {
                caseFavorite.remove(id);
                //servicesTable.DataTable().ajax.reload(null, true);
            }
        };


        /* init Service procedure DataTable */
        serviceProcedureTable.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>",
            displayLength: 6,
            serverSide: true,
            ordering: false,
            filter: false,
            deferLoading: 0,
            select: {
                info: false
            },
            ajax: {
                url: "/Cases/GetServiceProceduresDataJson",
                type: "POST",
                data: function (data) {
                    data.serviceId = servicesTable.DataTable().rows({ selected: true }).data()[0]['id'];
                }
            },
            drawCallback: function (settings) {
                if (settings.json != null) {
                    let count = settings.json.data.length;
                    if (count == 1) {
                        var api = this.api();
                        api.rows().select()
                    }
                }
            },
            columns: [
                {
                    data: 'name',
                    render: function (data, type, row) {
                        let content = "";
                        content += `<div class="r-s-14">${data}</div>`;
                        return content;
                    }
                }
            ]
        })
            .on('select', () => { serviceTariffTableVisibility.show(); })
            .on('deselect', () => { serviceTariffTableVisibility.hide(); });


        /* init Service Tariff DataTable */
        serviceTariffTable.DataTable({
            sDom: "<'row'<'col-sm-12'tr>>",
            displayLength: 6,
            serverSide: true,
            ordering: false,
            filter: false,
            deferLoading: 0,
            select: {
                info: false
            },
            ajax: {
                url: "/Cases/GetServiceTariffDataJson",
                type: "POST",
                data: function (data) {
                    data.procedureId = serviceProcedureTable.DataTable().rows({ selected: true }).data()[0]['id'];
                    data.type = servicesTableCustomerTypes.val();
                }
            },
            drawCallback: function (settings) {
                if (settings.json != null) {
                    let count = settings.json.data.length;
                    if (count == 1) {
                        var api = this.api();
                        api.rows().select()
                    }
                }
            },
            columns: [
                {
                    data: 'tariffTypeName'
                },
                {
                    data: 'tariffOiv',
                    render: function (data, type, row) {
                        if (row.tariffOiv === 0) return "<span>Бесплатно</span>";
                        return `${numeral(row.tariffOiv).format('0,0.00')} &#x20bd;`;
                    }
                },
                {
                    data: 'tariffMfc',
                    render: function (data, type, row) {
                        if (row.tariffMfc === 0)
                            return "-";
                        return `${numeral(row.tariffMfc).format('0,0.00')} &#x20bd;`;
                    }
                },
                {
                    data: 'countDayProcessing',
                    render: function (data, type, row) {
                        if (row.weekTypeId === 1)
                            return `${data} <small>${$.declOfNum(data, ["рабочий день", "рабочих дня", "рабочих дней"])}</small>`;
                        return `${data} <small>${$.declOfNum(data, ["календарный день", "календарных дня", "календарных дней"])}</small>`;
                    }
                },
                {
                    data: 'countDayExecuting',
                    render: function (data, type, row) {
                        if (row.weekTypeId === 1)
                            return `${data} <small>${$.declOfNum(data, ["рабочий день", "рабочих дня", "рабочих дней"])}</small>`;
                        return `${data} <small>${$.declOfNum(data, ["календарный день", "календарных дня", "календарных дней"])}</small>`;
                    }
                },
                {
                    data: 'countDayReturn',
                    render: function (data, type, row) {
                        if (row.weekTypeId === 1)
                            return `${data} <small>${$.declOfNum(data, ["рабочий день", "рабочих дня", "рабочих дней"])}</small>`;
                        return `${data} <small>${$.declOfNum(data, ["календарный день", "календарных дня", "календарных дней"])}</small>`;
                    }
                },
            ]
        })
            .on('select', () => { btnNextSecondStepActive.enabled(); })
            .on('deselect', () => { btnNextSecondStepActive.disabled(); });

        /*suggestions*/
        pickadate.datepicker({
            language: "ru",
            autoclose: true,
            endDate: "-0",
            orientation: "bottom"
        });


        /*Adrress customer search Gar*/
        let Customeraddresses = new Map();

        customer.address.on('input', function () {
            let adr = $(this).val();
            let $adrList = $('#customerAddress').find('.address-list');
            if (adr.length > 3) {
                $adrList.empty();
                Customeraddresses.clear();
                GetAddressGar(adr, $adrList, Customeraddresses);
            }
            else if (adr.length > 1) {
                $adrList.hide(0);
                $adrList.empty();
                Customeraddresses.clear();
            }
        });

        customer.address.focusout(function () {
            let $adrList = $('#customerAddress').find('.address-list');
            $adrList.delay(150).hide(0);
        });

        customer.address.focus(function () {
            let $adrList = $('#customerAddress').find('.address-list');
            if ($adrList.children().length > 0 && $(this).val().length) $adrList.show();
        });

        $('#customerAddress .address-list').on('click',
            function (event) {

                let $selectedAdr = $(event.target);
                if ($selectedAdr.attr('data-index') !== undefined) {
                    customer.address.val($selectedAdr.text());
                    $('#CustomerAddressDetails').find('[data-clean]').each(function (idx) {
                        $(this).val('');
                    });
                    fillAddress(Customeraddresses.get($selectedAdr.attr('data-index')), $('#CustomerAddressDetails'));
                }
            }
        );
        /*Adrress customer search Gar*/

        /*Adrress representative search Gar*/
        let Representativeaddresses = new Map();

        representative.address.on('input', function () {
            let adr = $(this).val();
            let $adrList = $('#representativeAddress').find('.address-list');
            if (adr.length > 3) {
                $adrList.empty();
                Representativeaddresses.clear();
                GetAddressGar(adr, $adrList, Representativeaddresses);
            }
            else if (adr.length > 1) {
                $adrList.hide(0);
                $adrList.empty();
                Representativeaddresses.clear();
            }
        });

        representative.address.focusout(function () {
            let $adrList = $('#representativeAddress').find('.address-list');
            $adrList.delay(150).hide(0);
        });

        representative.address.focus(function () {
            let $adrList = $('#representativeAddress').find('.address-list');
            if ($adrList.children().length > 0 && $(this).val().length) $adrList.show();
        });

        $('#representativeAddress .address-list').on('click',
            function (event) {
                let $selectedAdr = $(event.target);
                if ($selectedAdr.attr('data-index') !== undefined) {
                    representative.address.val($selectedAdr.text());
                    $('#RepresentativeAddressDetails').find('[data-clean]').each(function (idx) {
                        $(this).val('');
                    });
                    fillAddress(Representativeaddresses.get($selectedAdr.attr('data-index')), $('#RepresentativeAddressDetails'));
                }
            }
        );
        /*Adrress representative search Gar*/

        /*Sinls and Inn check*/
        customer.isGetCustomerSnils.on('click', function () {
            if ($(this).is(':checked')) {
                customer.snils.val('');
                customer.snils.attr('disabled', 'disabled');
                FormValidation2.disableValidator('customer.CustomerSnils');
                $('#isGetCustomerSnils_info').removeClass('d-none');
            }
            else {
                $('#isGetCustomerSnils_info').addClass('d-none');
                FormValidation2.enableValidator('customer.CustomerSnils');
                customer.snils.removeAttr('disabled');
            }
        });

        customer.isGetCustomerInn.on('click', function () {
            if ($(this).is(':checked')) {
                customer.inn.val('');
                customer.inn.attr('disabled', 'disabled');
                //FormValidation2.disableValidator('customer.CustomerInn');
                $('#isGetCustomerInn_info').removeClass('d-none');
            }
            else {
                $('#isGetCustomerInn_info').addClass('d-none');
                //FormValidation2.enableValidator('customer.CustomerInn');
                customer.inn.removeAttr('disabled');
            }
        });

        representative.isGetCustomerSnils.on('click', function () {
            if ($(this).is(':checked')) {
                representative.snils.val('');
                representative.snils.attr('disabled', 'disabled');
                FormValidation2.disableValidator('representative.CustomerSnils');
                $('#isGetRepresentativeSnils_info').removeClass('d-none');
            }
            else {
                $('#isGetRepresentativeSnils_info').addClass('d-none');
                FormValidation2.enableValidator('representative.CustomerSnils');
                representative.snils.removeAttr('disabled');
            }
        });

        representative.isGetCustomerInn.on('click', function () {
            if ($(this).is(':checked')) {
                representative.inn.val('');
                representative.inn.attr('disabled', 'disabled');
                //FormValidation2.disableValidator('representative.CustomerInn');
                $('#isGetRepresentativeInn_info').removeClass('d-none');
            }
            else {
                representative.inn.removeAttr('disabled');
                //FormValidation2.enableValidator('representative.CustomerInn');
                $('#isGetRepresentativeInn_info').addClass('d-none');
            }
        });
        /*Sinls check*/

        /*inputmask*/
        pickadate.inputmask("99.99.9999", { clearIncomplete: true, showMaskOnHover: false });
        customer.documentSerial.inputmask("99 99", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); customer.documentNumber.focus(); } });
        customer.documentNumber.inputmask("999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
        customer.documentCode.inputmask("999-999", { clearIncomplete: true, showMaskOnHover: false });
        customer.snils.inputmask("999-999-999 99", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { $(customer.isGetCustomerSnils).prop("checked", false) } });
        customer.inn.inputmask("999999999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { $(customer.isGetCustomerInn).prop("checked", false) } });
        customer.phone1.inputmask("+7(999) 999-99-99", { clearIncomplete: true, showMaskOnHover: false });
        customer.phone2.inputmask("+7(999) 999-99-99", { clearIncomplete: true, showMaskOnHover: false });
        customer.documentsIdentityId.select2({ language: "ru", minimumResultsForSearch: -1 });

        /*inputmask*/
        representative.documentSerial.inputmask("99 99", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(2); representative.documentNumber.focus(); } });
        representative.documentNumber.inputmask("999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(2); } });
        representative.documentCode.inputmask("999-999", { clearIncomplete: true, showMaskOnHover: false });
        representative.snils.inputmask("999-999-999 99", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { $(representative.isGetCustomerSnils).prop("checked", false) } });
        representative.inn.inputmask("999999999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { $(representative.isGetCustomerInn).prop("checked", false) } });
        representative.phone1.inputmask("+7(999) 999-99-99", { clearIncomplete: true, showMaskOnHover: false });
        representative.phone2.inputmask("+7(999) 999-99-99", { clearIncomplete: true, showMaskOnHover: false });
        representative.documentsIdentityId.select2({ language: "ru", minimumResultsForSearch: -1 });

        /*inputmask*/
        customerLegal.phone1.inputmask("+7(999) 999-99-99", { clearIncomplete: true, showMaskOnHover: false });
        customerLegal.phone2.inputmask("+7(999) 999-99-99", { clearIncomplete: true, showMaskOnHover: false });
        customerLegal.inn.inputmask("9999999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(3); } });
        customerLegal.ogrn.inputmask("9999999999999", { clearIncomplete: true, showMaskOnHover: false });
        customerLegal.kpp.inputmask("999999999", { clearIncomplete: true, showMaskOnHover: false });
        customerLegal.okato.inputmask("99999999999", { clearIncomplete: true, showMaskOnHover: false });
        customerLegal.oktmo.inputmask("99999999999", { clearIncomplete: true, showMaskOnHover: false });
        customerLegal.type.select2({ language: "ru", minimumResultsForSearch: -1 });

        customer.documentsIdentityId.on('change', function () {
            let v = $(this).val();
            switch (v) {
                case "21":
                    customer.documentSerial.inputmask("99 99", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); customer.documentNumber.focus(); } });
                    customer.documentNumber.inputmask("999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    customer.documentCode.removeAttr('disabled');
                    customer.documentCode.parent('[data-document-code]').removeClass('d-none');
                    FormValidation2.enableValidator('customer.DocumentSerial');
                    FormValidation2.enableValidator('customer.DocumentNumber');
                    FormValidation2.enableValidator('customer.DocumentCode');
                    FormValidation2.enableValidator('customer.DocumentIssueDate');
                    FormValidation2.enableValidator('customer.DocumentIssueBody');
                    break;
                case "3":
                    customer.documentSerial.inputmask("", { regex: "^[XIVLMC]{1,4}-[А-ЯЁ]{2}$", clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); customer.documentNumber.focus(); } });
                    customer.documentNumber.inputmask("999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    customer.documentCode.parent('[data-document-code]').addClass('d-none');
                    customer.documentCode.attr('disabled', 'disabled');
                    FormValidation2.disableValidator('customer.DocumentCode');
                    FormValidation2.enableValidator('customer.DocumentSerial');
                    FormValidation2.enableValidator('customer.DocumentNumber');
                    FormValidation2.enableValidator('customer.DocumentIssueDate');
                    FormValidation2.enableValidator('customer.DocumentIssueBody');
                    break;
                case "22":
                    customer.documentSerial.inputmask("", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); customer.documentNumber.focus(); } });
                    customer.documentNumber.inputmask("999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    customer.documentCode.parent('[data-document-code]').addClass('d-none');
                    customer.documentCode.attr('disabled', 'disabled');
                    FormValidation2.enableValidator('customer.DocumentNumber');
                    FormValidation2.enableValidator('customer.DocumentIssueDate');
                    FormValidation2.enableValidator('customer.DocumentIssueBody');
                    FormValidation2.disableValidator('customer.DocumentSerial');
                    FormValidation2.disableValidator('customer.DocumentCode');
                    break;
                default:
                    customer.documentSerial.inputmask("", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    customer.documentNumber.inputmask("", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    customer.documentCode.parent('[data-document-code]').addClass('d-none');
                    customer.documentCode.attr('disabled', 'disabled');
                    FormValidation2.disableValidator('customer.DocumentSerial');
                    FormValidation2.disableValidator('customer.DocumentNumber');
                    FormValidation2.disableValidator('customer.DocumentCode');
                    FormValidation2.disableValidator('customer.DocumentIssueDate');
                    FormValidation2.disableValidator('customer.DocumentIssueBody');
                    break;
            }
        });

        representative.documentsIdentityId.on('change', function () {
            let v = $(this).val();
            switch (v) {
                case "21":
                    representative.documentSerial.inputmask("99 99", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); customer.documentNumber.focus(); } });
                    representative.documentNumber.inputmask("999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    representative.documentCode.removeAttr('disabled');
                    representative.documentCode.parent('[data-document-code]').removeClass('d-none');
                    FormValidation2.enableValidator('representative.DocumentSerial');
                    FormValidation2.enableValidator('representative.DocumentNumber');
                    FormValidation2.enableValidator('representative.DocumentCode');
                    FormValidation2.enableValidator('representative.DocumentIssueDate');
                    FormValidation2.enableValidator('representative.DocumentIssueBody');
                    break;
                case "3":
                    representative.documentSerial.inputmask("", { regex: "^[XIVLMC]{1,4}-[А-ЯЁ]{2}$", clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); customer.documentNumber.focus(); } });
                    representative.documentNumber.inputmask("999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    representative.documentCode.parent('[data-document-code]').addClass('d-none');
                    representative.documentCode.attr('disabled', 'disabled');
                    FormValidation2.disableValidator('representative.DocumentCode');
                    FormValidation2.enableValidator('representative.DocumentSerial');
                    FormValidation2.enableValidator('representative.DocumentNumber');
                    FormValidation2.enableValidator('representative.DocumentIssueDate');
                    FormValidation2.enableValidator('representative.DocumentIssueBody');
                    break;
                case "22":
                    representative.documentSerial.inputmask("", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); customer.documentNumber.focus(); } });
                    representative.documentNumber.inputmask("999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    representative.documentCode.parent('[data-document-code]').addClass('d-none');
                    representative.documentCode.attr('disabled', 'disabled');
                    FormValidation2.enableValidator('representative.DocumentNumber');
                    FormValidation2.enableValidator('representative.DocumentIssueDate');
                    FormValidation2.enableValidator('representative.DocumentIssueBody');
                    FormValidation2.disableValidator('representative.DocumentSerial');
                    FormValidation2.disableValidator('representative.DocumentCode');
                    break;
                default:
                    representative.documentSerial.inputmask("", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    representative.documentNumber.inputmask("", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(1); } });
                    representative.documentCode.parent('[data-document-code]').addClass('d-none');
                    representative.documentCode.attr('disabled', 'disabled');
                    FormValidation2.disableValidator('representative.DocumentSerial');
                    FormValidation2.disableValidator('representative.DocumentNumber');
                    FormValidation2.disableValidator('representative.DocumentCode');
                    FormValidation2.disableValidator('representative.DocumentIssueDate');
                    FormValidation2.disableValidator('representative.DocumentIssueBody');
                    break;
            }
        });

        customerLegal.type.on('change', function () {
            let v = $(this).val();
            switch (v) {
                case "1915767":
                    customerLegal.inn.inputmask("999999999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(3); } });
                    customerLegal.ogrn.inputmask("999999999999999", { clearIncomplete: true, showMaskOnHover: false });
                    break;
                default:
                    customerLegal.inn.inputmask("9999999999", { clearIncomplete: true, showMaskOnHover: false, oncomplete: function () { findCustomerByDocument.load(3); } });
                    customerLegal.ogrn.inputmask("9999999999999", { clearIncomplete: true, showMaskOnHover: false });
                    break;
            }
        });


        checksCustomerAddressCoincide.on('click', function () {
            let address = createCaseWizardFormStep2.querySelector('#customer_CustomerAddress').value;
            if (address == "") {
                toastr['warning']('Адрес регистрации заявителя не заполнен', 'Предупреждение', {
                    closeButton: true,
                    tapToDismiss: false,
                    rtl: false
                });
                $(this).prop('checked', false);
            }
            else {
                createCaseWizardFormStep2.querySelector('#customer_CustomerAddressResidence').value = address;
            }
        });

        checksRepresentativeAddressCoincide.on('click', function () {
            let address = createCaseWizardFormStep2.querySelector('#representative_CustomerAddress').value;
            if (address == "") {
                toastr['warning']('Адрес регистрации представителя не заполнен', 'Предупреждение', {
                    closeButton: true,
                    tapToDismiss: false,
                    rtl: false
                });
                $(this).prop('checked', false);
            }
            else {
                createCaseWizardFormStep2.querySelector('#representative_CustomerAddressResidence').value = address;
            }
        });

        createCaseWizardNext.forEach(item => {
            item.addEventListener('click', event => {
                switch (validationStepper._currentIndex) {
                    case 0:
                        FormValidation1.validate();
                        break;

                    case 1:
                        FormValidation2.validate();
                        if (servicesTableCustomerTypes.val() === '1912196')
                            CustomerInfo = `${createCaseWizardFormStep2.querySelector('#customer_LastName').value}
                                               ${createCaseWizardFormStep2.querySelector('#customer_FirstName').value}
                                               ${createCaseWizardFormStep2.querySelector('#customer_SecondName').value}
                                               ${createCaseWizardFormStep2.querySelector('#customer_DocumentBirthDate').value}`;
                        else {
                            CustomerInfo = `${createCaseWizardFormStep2.querySelector('#customerLegal_CustomerName').value}
                                               ${createCaseWizardFormStep2.querySelector('#customerLegal_CustomerAddress').value}
                                               ${createCaseWizardFormStep2.querySelector('#customerLegal_CustomerInn').value}`;
                        }
                        break;

                    case 2:
                        FormValidation3.validate();
                        break;
                };
                window.scrollTo(0, 0);
            });
        });

        createCaseWizardPrev.forEach(item => {
            item.addEventListener('click', event => {
                switch (validationStepper._currentIndex) {
                    case 3:
                        validationStepper.previous();
                        break;

                    case 2:
                        validationStepper.previous();
                        break;

                    case 1:
                        if (FormValidation2 != null) {
                            for (const [key] of Object.entries(FormValidation2.getFields())) {
                                FormValidation2.removeField(key);
                            }
                        }
                        additionalForms.clear();
                        validationStepper.previous();
                        break;

                    case 0:
                    default:
                        break;
                };
                window.scrollTo(0, 0);
            });
        });

        skipThreeStep.on('click', (e) => {
            if ($(e.currentTarget).hasClass('disabled')) {
                return false;
            }
            else {
                visibliBlock(representativeWizardForm, representativeWizardForm.is(':visible'));


                if (representativeWizardForm.is(':visible')) {
                    visibliBlock(representativeAlertForm, false);
                    visibliBlock(customerPhysicalAlertWrapper, true);
                    FormValidation2.enableValidator('representative.DocumentSerial');
                    FormValidation2.enableValidator('representative.DocumentNumber');
                    FormValidation2.enableValidator('representative.DocumentIssueDate');
                    FormValidation2.enableValidator('representative.LastName');
                    FormValidation2.enableValidator('representative.FirstName');
                    FormValidation2.enableValidator('representative.DocumentBirthDate');
                    FormValidation2.enableValidator('representative.DocumentBirthPlace');
                    FormValidation2.enableValidator('representative.DocumentCode');
                    FormValidation2.enableValidator('representative.DocumentIssueBody');
                    FormValidation2.enableValidator('representative.CustomerSnils');
                }
                else {
                    visibliBlock(representativeAlertForm, true);
                    visibliBlock(customerPhysicalAlertWrapper, false);
                    FormValidation2.disableValidator('representative.DocumentSerial');
                    FormValidation2.disableValidator('representative.DocumentNumber');
                    FormValidation2.disableValidator('representative.DocumentIssueDate');
                    FormValidation2.disableValidator('representative.LastName');
                    FormValidation2.disableValidator('representative.FirstName');
                    FormValidation2.disableValidator('representative.DocumentBirthDate');
                    FormValidation2.disableValidator('representative.DocumentBirthPlace');
                    FormValidation2.disableValidator('representative.DocumentCode');
                    FormValidation2.disableValidator('representative.DocumentIssueBody');
                    FormValidation2.disableValidator('representative.CustomerSnils');
                }
            }
        });

        btnFormSubmit.on("click", () => {
            Swal.fire({
                width: 600,
                title: 'Вы уверены?',
                html: `<div class="swall-html-content"><b class="swall-content-text">Наименовние услуги: </b> <br><span class="swall-content-text">${servicesTable.DataTable().rows({ selected: true }).data()[0]['name']}</span> <br>
                       <b class="swall-content-text">Орган власти: </b><br><span class="swall-content-text">${servicesTable.DataTable().rows({ selected: true }).data()[0]['providerName']}</span> <br>
                       <b class="swall-content-text">Заявитель: </b><br><span class="swall-content-text">${CustomerInfo}</span> <br></div>
                       <h5 class="mt-3 text-centr">Внимательно проверьте введенные данные</h5>`,
                showDenyButton: true,
                showCancelButton: true,
                confirmButtonText: 'Сохранить',
                denyButtonText: 'Сохранить как Консультация',
                cancelButtonText: 'Отмена',
                customClass: {
                    confirmButton: 'btn btn-success me-3',
                    denyButton: 'btn btn-warning me-3',
                    cancelButton: 'btn btn-label-secondary',
                    title: 'title-content',
                },
                backdrop: true,
                allowOutsideClick: () => !Swal.isLoading(),
            }).then((result) => {
                if (result.isConfirmed || result.isDenied) {

                    const formData = new FormData(createCaseWizardForm);
                    const additionalDataInputs = createCaseWizardAdditionalForm.find(':input');
                   
                    formData.append("serviceId", servicesTable.DataTable().rows({ selected: true }).data()[0]['id']);
                    formData.append("procedureId", serviceProcedureTable.DataTable().rows({ selected: true }).data()[0]['id']);
                    formData.append("tariffId", serviceTariffTable.DataTable().rows({ selected: true }).data()[0]['id']);

                    if (additionalDataInputs) {
                        formData.append("additionalData", JSON.stringify(additionalDataInputs.serializeToJSON()));
                        Object.entries(additionalDataInputs.serializeArray()).forEach(([key, value]) => {
                            let name = value["name"];
                            if (name) formData.delete(name);
                        })
                    }

                    var object = {}; 
                    formData.forEach(function (value, key) {
                        object[key] = value;
                    });

                    let stage = result.isConfirmed ? stageReceived : stageСonsultation;
                    formData.append("stageId", stage);

                    $.ajax({
                        url: '/Cases/CreateSave',
                        type: 'POST',
                        data: formData,
                        processData: false,
                        contentType: false,
                        beforeSend: () => {
                            $.pageBlock();
                            btnFormSubmit.spinnerBtn("start");
                        },
                        complete: () => {
                            $.unblockUI();
                            btnFormSubmit.spinnerBtn("stop");
                        },
                        success: (content) => {
                            $('#final-step').empty();
                            $('#final-step').html(content);
                            validationStepper.next();
                            createCaseWizardFormStep1.remove();
                            createCaseWizardFormStep2.remove();
                            createCaseWizardFormStep3.remove();
                        }
                    }); 
                }
            });
        });
    };

    const initMain = () => {
        initComponents();
    }

    initMain();
});



function Select2Build() {
    $('select.select2-search').select2({
        //dropdownParent: $("#mainModal")
    });
    $('select.select2-nosearch').select2({
        //dropdownParent: $("#mainModal"),
        minimumResultsForSearch: Infinity
    });
    $('select.select2-tags').select2({
        //dropdownParent: $("#mainModal"),
        tags: true
    });
}


function getDictionariesDataBase() {
    let dicts = new Set();
    $('[data-dictionary-database]').each(function () {
        let $this = $(this);
        let options = $this.data('dictionary-database');
        if (!dicts.has(options.dictionary)) {
            dicts.add(options.dictionary);
            $.get(`/Cases/DataBaseGetDictionary`,
                {
                    type: options.dictionary
                },
                function (dictionary) {
                    if (dictionary.error) return;
                    fillDataBaseSelect(options.dictionary, dictionary);
                });
        }
    });
};

function fillSelect(dictName, dictionary) {
    $.each($(`[data-dictionary*='"${dictName}"']`),
        function () {
            let $this = $(this);
            let items = dictionary;
            $this.empty();
            if (!$this.hasClass('required')) {
                $this.append(new Option('Не выбрано', ''));
            }
            if ($this.is('[data-value-value]')) {
                items.dictionary.forEach(function (item) {
                    $this.append(new Option(item.value, item.value));
                });
            } else {
                items.dictionary.forEach(function (item) {
                    $this.append(new Option(item.value, item.key));
                });
            }

            if ($this.data('dictionary').default_value) {
                let defVal = $this.data('dictionary').default_value;
                if (defVal) {
                    $this.val(defVal).trigger('update');
                    $this.attr('data-def', defVal);
                }
            } else {
                $this.val(items.defaultKey).trigger('update');
                $this.attr('data-def', items.defaultKey);
            }
        });
}

function getDictionaries(isAsync = true) {
    let dicts = new Set();
    $('[data-dictionary]').each(function () {
        let $this = $(this);
        let options = $this.data('dictionary');
        if (!dicts.has(options.dictionary)) {
            dicts.add(options.dictionary);
            $.ajax({
                    url: '/SmevBase/SmevGetDictionary',
                    type: 'POST',
                    async: isAsync,
                    data: { type: options.dictionary },
                    success: function (dictionary) {
                        fillSelect(options.dictionary, dictionary);
                    }
                });
        }
    });
};

function fillSelect(dictName, dictionary) {
    $.each($(`[data-dictionary*='"${dictName}"']`), function () {
        let $this = $(this);
        let items = dictionary;
        $this.empty();
        if (!$this.hasClass('required')) {
            $this.append(new Option('Не выбрано', ''));
        }
        if ($this.is('[data-value-value]')) {
            items.dictionary.forEach(function (item) {
                $this.append(new Option(item.value, item.value));
            });
        } else {
            items.dictionary.forEach(function (item) {
                $this.append(new Option(item.value, item.key));
            });
        }

        if ($this.data('dictionary').default_value) {
            let defVal = $this.data('dictionary').default_value;
            if (defVal) {
                $this.val(defVal).trigger('update');
                $this.attr('data-def', defVal);
            }
        } else {
            $this.val(items.defaultKey).trigger('update');
            $this.attr('data-def', items.defaultKey);
        }
    });
}


function createAddressText(adr) {
    let elements = [];

    if (adr.region) {
        elements.push(`${adr.region.shortName} ${adr.region.value}`);
    }
    if (adr.area) {
        elements.push(`${adr.area.shortName} ${adr.area.value}`);
    }
    if (adr.city) {
        elements.push(`${adr.city.shortName} ${adr.city.value}`);
    }
    if (adr.cityAndRuralSettlements) {
        elements.push(`${adr.cityAndRuralSettlements.shortName} ${adr.cityAndRuralSettlements.value}`);
    }
    if (adr.intracityDistrict) {
        elements.push(`${adr.intracityDistrict.shortName} ${adr.intracityDistrict.value}`);
    }
    if (adr.settlement) {
        elements.push(`${adr.settlement.shortName} ${adr.settlement.value}`);
    }
    if (adr.street) {
        elements.push(`${adr.street.shortName} ${adr.street.value}`);
    }
    if (adr.house) {
        if (adr.house.houseNum) elements.push(`д ${adr.house.houseNum}`);
        if (adr.house.buildNum) elements.push(`корп ${adr.house.buildNum}`);
        if (adr.house.structNum) elements.push(`стр ${adr.house.structNum}`);
    }
    if (adr.room) {
        elements.push(`кв ${adr.room.flatNumber}`);
    }

    return elements.join(', ');
}

function fillAddress(adrData, $addressBlock) {
    if (adrData.region) {
        $addressBlock.find('[id$="Region_ShortName"]').val(adrData.region.shortName);
        $addressBlock.find('[id$="Region_Name"]').val(adrData.region.name);
        $addressBlock.find('[id$="Region_Value"]').val(adrData.region.value);
        $addressBlock.find('[id$="Region_ObjectGuid"]').val(adrData.region.objectGuid);
        $addressBlock.find('[id$="Region_RegionCode"]').val(adrData.region.regionCode);
    }

    if (adrData.area) {
        $addressBlock.find('[id$="Area_ShortName"]').val(adrData.area.shortName);
        $addressBlock.find('[id$="Area_Name"]').val(adrData.area.name);
        $addressBlock.find('[id$="Area_Value"]').val(adrData.area.value);
        $addressBlock.find('[id$="Area_ObjectGuid"]').val(adrData.area.objectGuid);
    }

    if (adrData.cityAndRuralSettlements) {
        $addressBlock.find('[id$="CityAndRuralSettlements_ShortName"]').val(adrData.cityAndRuralSettlements.shortName);
        $addressBlock.find('[id$="CityAndRuralSettlements_Name"]').val(adrData.cityAndRuralSettlements.name);
        $addressBlock.find('[id$="CityAndRuralSettlements_Value"]').val(adrData.cityAndRuralSettlements.value);
        $addressBlock.find('[id$="CityAndRuralSettlements_ObjectGuid"]').val(adrData.cityAndRuralSettlements.objectGuid);
    }

    if (adrData.city) {
        $addressBlock.find('[id$="City_ShortName"]').val(adrData.city.shortName);
        $addressBlock.find('[id$="City_Name"]').val(adrData.city.name);
        $addressBlock.find('[id$="City_Value"]').val(adrData.city.value);
        $addressBlock.find('[id$="City_ObjectGuid"]').val(adrData.city.objectGuid);
    }

    if (adrData.settlement) {
        $addressBlock.find('[id$="Settlement_ShortName"]').val(adrData.settlement.shortName);
        $addressBlock.find('[id$="Settlement_Name"]').val(adrData.settlement.name);
        $addressBlock.find('[id$="Settlement_Value"]').val(adrData.settlement.value);
        $addressBlock.find('[id$="Settlement_ObjectGuid"]').val(adrData.settlement.objectGuid);
    }

    if (adrData.intracityDistrict) {
        $addressBlock.find('[id$="IntracityDistrict_ShortName"]').val(adrData.intracityDistrict.shortName);
        $addressBlock.find('[id$="IntracityDistrict_Name"]').val(adrData.intracityDistrict.name);
        $addressBlock.find('[id$="IntracityDistrict_Value"]').val(adrData.intracityDistrict.value);
        $addressBlock.find('[id$="IntracityDistrict_ObjectGuid"]').val(adrData.intracityDistrict.objectGuid);
    }

    if (adrData.street) {
        $addressBlock.find('[id$="Street_ShortName"]').val(adrData.street.shortName);
        $addressBlock.find('[id$="Street_Name"]').val(adrData.street.name);
        $addressBlock.find('[id$="Street_Value"]').val(adrData.street.value);
        $addressBlock.find('[id$="Street_ObjectGuid"]').val(adrData.street.objectGuid);
    }

    if (adrData.house) {
        $addressBlock.find('[id$="House_HouseNum"]').val(adrData.house.houseNum);
        $addressBlock.find('[id$="House_BuildNum"]').val(adrData.house.buildNum);
        $addressBlock.find('[id$="House_StructNum"]').val(adrData.house.structNum);
        $addressBlock.find('[id$="House_ObjectGuid"]').val(adrData.house.objectGuid);
        $addressBlock.find('[id$="House_PostalCode"]').val(adrData.house.postalCode);
        $addressBlock.find('[id$="House_Okato"]').val(adrData.house.okato);
        $addressBlock.find('[id$="House_Oktmo"]').val(adrData.house.oktmo);
    }

    if (adrData.room) {
        $addressBlock.find('[id$="Room_FlatType"]').val(adrData.room.flatType);
        $addressBlock.find('[id$="Room_FlatNumber"]').val(adrData.room.flatNumber);
        $addressBlock.find('[id$="Room_ObjectGuid"]').val(adrData.room.objectGuid);
    }
}

function GetAddressGar(searchAddress, $addressBlock, addressMap) {
    $.ajax({
        url: '/SmevBase/GarSearchAddressExtended',
        type: 'POST',
        data: {
            SearchText: searchAddress
        },
        beforeSend: function () {
            $addressBlock.empty();
            addressMap.clear();
        },
        success: function (data) {
            if (data.result != null && data.result.length > 0) {
                $addressBlock.empty();
                addressMap.clear();
                $addressBlock.append('<lh><small>Выберите вариант или продолжите ввод</small></lh>')
                data.result.forEach((item, index) => {
                    $addressBlock.append(`<li data-index='${index}'>${createAddressText(item)}</li>`);
                    addressMap.set(`${index}`, item);
                });
                $addressBlock.show();
            }
        }
    });
}

function findCustomerByDocumentAdditional(ser, num) {
    let dataform;
    $.ajax({
        url: '/Cases/FindCustomerByDocumentDataJson',
        type: 'POST',
        async: false,
        data: {
            serial: ser,
            number: num
        },
        success: function (data) {
            dataform = data;
        },
        error: () => {
            dataform = null;
        }
    });
    return dataform;
};

function fillDataBaseSelect(dictName, dictionary) {
    $.each($(`[data-dictionary-database*='"${dictName}"']`), function () {
        let $this = $(this);
        let items = dictionary;
        $this.empty();
        console.log(items);
        if (!$this.hasClass('required')) {
            $this.append(new Option('Не выбрано', ''));
        }
        if ($this.is('[data-value-value]')) {
            items.forEach(function (item) {
                $this.append(new Option(item.value, item.value));
            });
        } else {
            items.forEach(function (item) {
                $this.append(new Option(item.value, item.key));
            });
        }

        if ($this.data('dictionary-database').default_value) {
            let defVal = $this.data('dictionary-database').default_value;
            if (defVal) {
                $this.val(defVal).trigger('update');
                $this.attr('data-def', defVal);
            }
        } else {
            $this.val(items.defaultKey).trigger('update');
            $this.attr('data-def', items.defaultKey);
        }
    });
};

function visibliBlock(wrapper, property) {
    switch (property) {
        case true:
            wrapper.hide();
            wrapper.find('input, select').each(function () {
                $(this).prop('disabled', true);
                $(this).removeClass('is-invalid')
            });

            break;
        case false:
            wrapper.find('input, select').each(function () {
                $(this).prop('disabled', false);
                $(this).removeClass('is-invalid')
            });
            wrapper.show();
            break;
    }
}
 
