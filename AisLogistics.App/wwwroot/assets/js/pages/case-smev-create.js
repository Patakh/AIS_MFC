'use strict';
var wizardSmevCreate = document.querySelector('#wizard-smev-create'),
    wizardSmevForm = wizardSmevCreate.querySelector('#wizard-smev-form'),
    wizardSmevFormStep1 = wizardSmevForm.querySelector('#smev-request'),
    wizardSmevFormStep2 = wizardSmevForm.querySelector('#smev-data'),
    wizardSmevFormStep3 = wizardSmevForm.querySelector('#smev-result'),
    wizardSmevFormSubmit = wizardSmevCreate.querySelector('#smev-create-wizard-form'),
    wizardSmevNext = [].slice.call(wizardSmevForm.querySelectorAll('.btn-next')),
    wizardSmevPrev = [].slice.call(wizardSmevForm.querySelectorAll('.btn-prev')),
    smevBlockInformation = [].slice.call(wizardSmevForm.querySelectorAll('.smev-information')),
    validationStepper = new Stepper(wizardSmevCreate, { linear: true }),
    SmevDataFormValidation = null,
    smevData = {
        serviceId: $('#ServiceId').val(),
        smevId: null,
        smevSubmitAction: null
    },
    smevFormSubmitBtn = $("#btn-submit-smev-form"),
    smevActiveTable = $('#smev-active-table'),
    smevActiveTableSearch = $("#smev-active-table-search"),
    smevActiveDetails = {
        icon: $('.smev-provider-icon'),
        provider: $('.smev-provider-name'),
        description: $('.smev-description'),
        days: $('.smev-reg-days')
    };
$(function () {
    $("#mainModal").on('hide.bs.modal', function () {
        sidebar.smev.reload();
    });

    const smevService = {
        details: {
            show: (data) => {
                let logoDictionary = {
                    "Пенсионный фонд Российской Федерации (ПФР)": "pfr.svg",
                    "Фонд социального страхования РФ (ФСС)": "fss.svg",
                    "Федеральная служба судебных приставов (ФССП)": "fssp.svg",
                    "АО \"Федеральная корпорация по развитию малого и среднего предпринимательства\"": "msp.svg",
                    "Федеральное агентство по управлению государственным имуществом РФ": "rosim.png",
                    "Федеральная служба государственной регистрации кадастра и картографии": "statereg.svg",
                    "Министерство внутренних дел Российской Федерации (МВД)": "mvd.png",
                    "Министерство цифрового развития, связи и массовых коммуникаций Российской Федерации (Минцифры)": "communications.png",
                    "Министерство труда и социального развития РД": "dagestan.png",
                    "Федеральная налоговая служба России (ФНС)": "tax.svg",
                    "Федеральная служба по надзору в сфере защиты прав потребителей и благополучия человека (Роспотребнадзор)": "welfare.png",
                    "Федеральная служба исполнения наказаний Российской Федерации (ФСИН)": "penitentiary.svg",
                    "Министерство образования и науки Республики Дагестан": "science.svg",
                    "Региональное бюро по технической инвентаризации и кадастровой оценке": "dagestan.png",
                    "Министерство юстиции Республики Дагестан": "justice.png",
                    "Министерство юстиции Российской Федерации (Минюст России)": "justice.png",
                    "Федеральное казначейство (ФК)": "money.png", 
                    "Социальный Фонд России (СФР)": "SFR.jpg",
                    "Министерство экономического развития РФ (Минэкономразвития)": "minek.svg"
                };

                smevActiveDetails.icon.attr("src", "/assets/svg/oiv/" + logoDictionary[data.provider]);
                smevActiveDetails.provider.text(data.provider);
                smevActiveDetails.description.text(data.description);
                smevActiveDetails.days.text(`до ${data.days} ${$.declOfNum(data.days, ["рабочего дня", "рабочих дней", "рабочих дней"])}`);
                smevBlockInformation[0].classList.remove("d-none");
                smevBlockInformation[1].classList.add("d-none");
                if (data.formPath && data.actionPath) {
                    wizardSmevNext[0].classList.add("btn-primary");
                    wizardSmevNext[0].classList.remove("btn-danger");
                    wizardSmevNext[0].removeAttribute("disabled");
                    wizardSmevNext[0].innerHTML = "Далее <i class=\"bi bi-chevron-right \"></i>";
                    smevData.smevId = data.id;
                    smevData.smevSubmitAction = data.actionPath;
                } else {
                    wizardSmevNext[0].classList.remove("btn-primary");
                    wizardSmevNext[0].classList.add("btn-danger");
                    wizardSmevNext[0].setAttribute("disabled", "disabled");
                    wizardSmevNext[0].innerText = "Запрос не реализован";
                }
                if (config.debug) {
                    smevBlockInformation[0].querySelectorAll(".debug").forEach(el => el.remove());
                    smevBlockInformation[0].querySelector("dl").insertAdjacentHTML('beforeend',
                        `<dt class="col-6 fw-normal debug">Id запроса</dt>
                            <dd class="col-6 text-end debug">${data.id}</dd>
                            <dt class="col-6 fw-normal debug">Url запроса</dt>
                            <dd class="col-6 text-end text-break debug">${data.actionPath}</dd>
                            <dt class="col-6 fw-normal debug">Url формы</dt>
                            <dd class="col-6 text-end text-break debug">${data.formPath}</dd>`);
                }
            },
            hide: () => {
                smevBlockInformation[1].classList.remove("d-none");
                smevBlockInformation[0].classList.add("d-none");
            }
        },
        form: {
            load: () => {
                if (smevData.smevId) {
                    $.ajax({
                        url: '/SmevBase/GetSmevForm',
                        type: 'GET',
                        async: false,
                        data: {
                            serviceId: smevData.serviceId,
                            smevId: smevData.smevId
                        },
                        beforeSend: () => {
                            //caseDetails.html('<div class="d-flex h-100 justify-content-center align-items-center"><div class="text-center"><p class="mb-0">Пожалуйста, подождите...</p> <div class="sk-wave sk-dark m-0 d-inline-flex"><div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div></div></div></div>');
                        },
                        success: (content) => {
                            $('#smev-data-form-content').html(content);
                            smevForm.init();
                        }
                    });
                }
            },
            submit: () => {
                var formData = new FormData(wizardSmevFormSubmit);
                formData.append("serviceId", smevData.serviceId);
                formData.append("smevId", smevData.smevId);
                $.ajax({
                    url: smevData.smevSubmitAction,
                    type: 'POST',
                    data: formData,
                    processData: false,
                    contentType: false,
                    beforeSend: () => {
                        $.pageBlock();
                        smevFormSubmitBtn.spinnerBtn("start");
                    },
                    complete: () => {
                        $.unblockUI();
                        smevFormSubmitBtn.spinnerBtn("stop");
                    },
                    error: (response) => {
                        $.notifi("error", "Ошибка", response.responseText);
                        console.error(response);
                    },
                    success: (content) => {
                        let iframe = wizardSmevFormStep3.querySelector("iframe");
                        iframe.setAttribute("src", content);
                        validationStepper.next();
                        //new PerfectScrollbar(wizardSmevForm);
                    }
                });
            }
        }
    }

    const initComponents = () => {
        // Smev request
        const FormValidation1 = FormValidation.formValidation(wizardSmevFormStep1,
            {
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    autoFocus: new FormValidation.plugins.AutoFocus(),
                    submitButton: new FormValidation.plugins.SubmitButton()
                }
            }).on('core.form.valid',
                function () {
                    validationStepper.next();
                    smevService.form.load();
                });

        // Data
        SmevDataFormValidation = FormValidation.formValidation(wizardSmevFormStep2,
            {
                locale: 'ru_RU',
                localization: FormValidation.locales.ru_RU,
                plugins: {
                    trigger: new FormValidation.plugins.Trigger(),
                    bootstrap5: new FormValidation.plugins.Bootstrap5({
                        // Use this for enabling/changing valid/invalid class
                        // eleInvalidClass: '',
                        eleValidClass: ''
                        // rowSelector: '.col-lg-6'
                    }),
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
            }).on('core.form.valid',
                function () {
                    smevService.form.submit();
                });

        /* init smev active DataTable */
        smevActiveTable.DataTable({
            sDom: "<'row'<'col-sm-12'tr>><'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
            processing: true,
            serverSide: true,
            ordering: false,
            filter: false,
            select: { info: false },
            search: { value: smevActiveTableSearch.val() },
            drawCallback: function () {
                this.trigger("deselect");
            },
            ajax: {
                url: "/Cases/GetServiceSmevActiveDataJson",
                type: "POST",
                data: function (data) {
                    data.serviceId = smevData.serviceId;
                    data.search["value"] = smevActiveTableSearch.val();
                }
            },
            columns: [
                {
                    title: "Запрос",
                    data: "name"
                }
            ]
        })
            .on('select', (e, dt, type, indexes) => {
                smevService.details.show(dt.rows(indexes).data()[0]);
            })
            .on('deselect', () => { smevService.details.hide(); });

        smevActiveTableSearch.on('keydown', _.debounce(() => {
            smevActiveTable.DataTable().ajax.reload(null, true);
        }, 500));

        wizardSmevNext.forEach(item => {
            item.addEventListener('click', event => {
                switch (validationStepper._currentIndex) {
                    case 0:
                        FormValidation1.validate();
                        break;

                    case 1:
                        SmevDataFormValidation.validate();
                        ShowErrorInputs();
                        break;
                }
            });
        });
        wizardSmevPrev.forEach(item => {
            item.addEventListener('click', event => {
                switch (validationStepper._currentIndex) {
                    case 2:
                        validationStepper.previous();
                        break;

                    case 1:
                        validationStepper.previous();
                        break;

                    case 0:

                    default:
                        break;
                }
            });
        });
    };


    const initMain = () => {
        initComponents();
    }

    initMain();
});

function getDictionaries(isAsync = true) {
    let dicts = new Set();
    $('#smev-data-form-content [data-dictionary]').each(function () {
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
    $.each($(`#smev-data-form-content [data-dictionary*='"${dictName}"']`),
        function () {
            let $this = $(this);
            let items = dictionary;
            $this.empty();
            if (!$this.hasClass('required')) {
                $this.append(new Option('Не выбрано', ''));
            }

            let defValue;
            if ($this.is('[data-value-value]')) {
                items.dictionary.forEach(function (item) {
                    if (item.key == items.defaultKey) defValue = item.value;
                    $this.append(new Option(item.value, item.value));
                });
            } else {
                items.dictionary.forEach(function (item) {
                    $this.append(new Option(item.value, item.key));
                });
            }

            if (items.defaultKey != null) {
                if (defValue) {
                    $this.val(defValue).trigger('update');}
                else {
                    $this.val(items.defaultKey).trigger('update');
                }
                $this.attr('data-def', items.defaultKey);
            } else {
                let defVal = $this.data('dictionary').default_value;
                if (defVal) {
                    $this.val(defVal).trigger('update');
                    $this.attr('data-def', defVal);
                }
            }
        });
}

function visibilityBlock($block, hide, isDisabled) {
    switch (hide) {
        case true:
            if ($block.hasClass('accordion')) {
                $block.find('.accordion-body').hide();
            } else {
                $block.hide();
            }
            break;
        case false:
            if ($block.hasClass('accordion')) {
                $block.find('.accordion-body').show();
            } else {
                $block.show();
            }
            break;
    }

    switch (isDisabled) {
        case true:
            $block.find('input, select').each(function () {
                if ($(this).attr('name') in SmevDataFormValidation.fields) {
                    removeValidation($(this));
                }
                $(this).prop('disabled', true);
            });
            break;
        case false:
            $block.find('input, select').each(function () {
                $(this).prop('disabled', false);
                if ($(this).hasClass('required')) {
                    addValidation($(this));
                }
            });
            $block.find('[data-disabled]').each(function () {
                visibilityBlock($(this), true, true);
            });
            break;
    }
}

function addValidation($el) {
    SmevDataFormValidation.addField($el.attr('name'),
        {
            validators: {
                notEmpty: {}
            }
        });
    SmevDataFormValidation.elements[$el.attr('name')] = [$el[0]];
    $el.addClass('required');
}

function removeValidation($el) {
    if ($el.attr('name') in SmevDataFormValidation.fields) {
        SmevDataFormValidation.removeField($el.attr('name'));
    }
}

function select2Init($block) {
    $block.find("select.select2-nosearch").each(function () {
        $(this).select2({
            dropdownParent: $("#mainModal"),
            minimumResultsForSearch: Infinity
        });
    });
    $block.find("select.select2-search").each(function () {
        $(this).select2({
            dropdownParent: $("#mainModal"),
        });
    });    
}

function dateInit($block) {
    $block.find(".pickdate").datepicker({
        language: "ru",
        autoclose: true
    }).inputmask("99.99.9999", { clearIncomplete: true, showMaskOnHover: false });
}

//Scan

function fileUploadInit($form) {
    $form.find('[data-upload-type]').on('click', function () {
        let uploadType = $(this).data('upload-type');
        $.get(`/Cases/ServiceDocumentAddModal`,
            {
                id: $('#ServiceId').val(), documentId: documentId, fileAddType: uploadType
            }, function (result) {
                $('#modalContainer').html(result).modal('show');
                $("#modalContainer #startScan").on("click", () => {
                    scanner.scan(displayImagesOnPage,
                        {
                            //"use_asprise_dialog": false,
                            "output_settings": [
                                {
                                    "type": "return-base64-thumbnail",
                                    "format": "jpg",
                                    "thumbnail_height": 200
                                },
                                {
                                    "type": "return-base64",
                                    "format": "jpg"
                                }
                            ],
                            "i18n": {
                                "lang": "ru"
                            }
                        }
                    );
                });

                let formId = "sendingForm";
                if (uploadType == "Scan") {
                    formId = "sendingForm1";
                    $("#modalContainer #sendingForm").attr('id', 'sendingForm1');
                    $("#modalContainer [form='sendingForm']").attr('form', 'sendingForm1');
                }

                $(`#modalContainer #${formId}`).submit(function (e) {
                    e.preventDefault();
                    var $form = $(this),
                        formAction = $form.attr("action"),
                        formDataToUpload = new FormData(this);
                    $('[data-scan-item]').each(function () {
                        var ImageURL = $(this).find('[name="imgCollection"]').attr('src');
                        var block = ImageURL.split(";");
                        var contentType = block[0].split(":")[1];
                        var realData = block[1].split(",")[1];
                        var blob = b64toBlob(realData, contentType);
                        formDataToUpload.append("files", blob, `${$(this).find('[name="imgNameCollection"]').val()}.jpg`);
                    });
                    $.ajax({
                        method: 'POST',
                        processData: false,
                        contentType: false,
                        url: formAction,
                        data: formDataToUpload,
                        beforeSend: () => {
                            $form.spinnerBtn("start");
                        },
                        complete: () => {
                            $form.spinnerBtn("stop");
                        },
                        success: function (data) {
                            $("#modalContainer").modal('hide');
                        }
                    });
                    return false;
                });
            });
    });
}

function displayImagesOnPage(successful, mesg, response) {
    if (!successful) {
        console.error('Failed: ' + mesg);
        //startScanButton.stop();
        return;
    }
    if (successful && mesg != null && mesg.toLowerCase().indexOf('user cancel') >= 0) {
        console.info('User cancelled');
        //startScanButton.stop();
        return;
    }
    var scannedImages = scanner.getScannedImages(response, true, false); // returns an array of ScannedImage
    for (var i = 0; (scannedImages instanceof Array) && i < scannedImages.length; i++) {
        var scannedImage = scannedImages[i];
        processScannedImage(scannedImage);
    }
    //startScanButton.stop();
}

// GAR

function addressSearchInit($block){
    $block.find('[data-address-search]').each(function () {
        var $input = $(this);
        let $adrList = $input.closest('[data-address]').find('.address-list');
        var url = '/SmevBase/GarSearchAddressExtended';
        $input.keyup(garRequest).focusin(() => {
            $adrList.show();
        }).focusout(() => {
            $adrList.delay(500).hide(0);
        });
    });
} 

function garRequest(event) {
    let $adrInput = $(event.target);
    let $adrBlock = $adrInput.closest('[data-address]');
    let $adrList = $adrBlock.find('.address-list');
    let query = $adrInput.val();

    addresses.clear();
    if (query.length > 2) {
        $.ajax({
            url: '/SmevBase/GarSearchAddressExtended',
            type: 'POST',
            data: { SearchText: query },
            success: function (data) {
                if (data.result.length > 0) {
                    $adrList.empty();
                    data.result.forEach((item, index) => {
                        $('.address-list').append(`<li data-index='${index}'>${createAddressText(item)}</li>`);
                        addresses.set(`${index}`, item);
                    });
                    $adrList.show();
                }
            }
        });
    } else {
        $adrInput.parent('.location-control').removeClass('open');
    }
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

var imagesScanned = [];

/** Processes a ScannedImage */
function processScannedImage(scannedImage) {
    //if (!$('#scan-content img').length) $('#scan-content').empty();
    $('#modalContainer #scan-content').append($('<div>',
        {
            class: 'col-sm-6 col-xl-4',
            append: $('<div>',
                {
                    class: 'gal-box',
                    'data-scan-item': '',
                    append: [
                        $('<a>',
                            {
                                class: 'image-popup',
                                title: 'Изображение',
                                href: scannedImage.src,
                                append: $('<img>',
                                    {
                                        class: 'img-fluid',
                                        name: 'imgCollection',
                                        src: scannedImage.src
                                    })
                            }), $('<div>',
                                {
                                    class: 'gall-info',
                                    append: $('<input>',
                                        {
                                            type: 'text',
                                            class: 'form-control-sm form-control',
                                            name: 'imgNameCollection',
                                            value: 'Изображение',
                                            on: {
                                                change: (e) => {
                                                    $(e.target).closest('[data-scan-item]').children('a').attr('title', e.target.value);
                                                }
                                            }
                                        })
                                })
                    ],
                })
        }));
    $('.image-popup').magnificPopup({
        type: 'image',
        closeOnContentClick: false,
        closeBtnInside: false,
        mainClass: 'mfp-with-zoom mfp-img-mobile',
        image: {
            verticalFit: true,
            titleSrc: function (item) {
                return item.el.attr('title');
            }
        },
        gallery: {
            enabled: true
        },
        zoom: {
            enabled: true,
            duration: 300, // don't foget to change the duration also in CSS
            easing: 'ease-in-out',
            opener: function (element) {
                return element.find('img');
            }
        }
    });
}

function b64toBlob(b64Data, contentType, sliceSize) {
    contentType = contentType || '';
    sliceSize = sliceSize || 512;
    var byteCharacters = atob(b64Data);
    var byteArrays = [];
    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);
        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    var blob = new Blob(byteArrays, { type: contentType });
    return blob;
}

//