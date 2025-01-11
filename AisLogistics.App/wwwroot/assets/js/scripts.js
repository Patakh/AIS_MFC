// Глобальные переменные

//locale moment
if (window.moment) {
    moment.locale('ru');
}

const validateSnils = function (input) {
    const value = input.value.replace(/[^0-9]/g, "");
    if (value === '') {
        return { valid: true };
    }

    var sum = 0;
    for (var i = 0; i < 9; i++) {
        sum += parseInt(value[i]) * (9 - i);
    }
    var checkDigit = 0;
    if (sum < 100) {
        checkDigit = sum;
    } else if (sum > 101) {
        checkDigit = parseInt(sum % 101);
        if (checkDigit === 100) {
            checkDigit = 0;
        }
    }
    if (checkDigit === parseInt(value.slice(-2))) {
        return { valid: true };
    } else {
        return {
            valid: false,
            message: 'Некорректный снилс',
        };
    }

    return { valid: true };
};

const switchStage = function (stage) {
    let colorStage = "";
    switch (stage) {
        case 'Принято':
            colorStage = "warning";
            break;
        case 'Обработка':
            colorStage = "success";
            break;
        case 'Курьер':
            colorStage = "warning";
            break;
        case 'Передано в ОИВ':
            colorStage = "success";
            break;
        case 'На выдачу':
            colorStage = "warning";
            break;
        case 'Выдано':
            colorStage = "success";
            break;
        case 'Ошибка':
            colorStage = "danger";
            break;
        case 'Прекращено заявителем':
            colorStage = "success";
            break;
        case 'Архив':
            colorStage = "warning";
            break;
        case 'Исполнено':
            colorStage = "success";
            break;
        case 'Приостановка':
            colorStage = "warning";
            break;
        case 'Ожидание':
            colorStage = "success";
            break;
        case 'Отказ ОИВ':
            colorStage = "warning";
            break;
        case 'Оператор':
            colorStage = "success";
            break;
        case 'Возврат ОИВ':
            colorStage = "warning";
            break;
        case 'Невостребованный':
            colorStage = "success";
            break;
        case 'Выдано в ОИВ':
            colorStage = "success";
            break;
        case 'Консультация':
            colorStage = "success";
            break;
    };
    return colorStage;
};

const RussianNameProcessor = {
    sexM: 'm',
    sexF: 'f',
    gcaseIm: 'nominative', gcaseNom: 'nominative',      // именительный
    gcaseRod: 'genitive', gcaseGen: 'genitive',        // родительный
    gcaseDat: 'dative',                                       // дательный
    gcaseVin: 'accusative', gcaseAcc: 'accusative',      // винительный
    gcaseTvor: 'instrumentative', gcaseIns: 'instrumentative', // творительный
    gcasePred: 'prepositional', gcasePos: 'prepositional',   // предложный

    rules: {
        lastName: {
            exceptions: [
                '	дюма,тома,дега,люка,ферма,гамарра,петипа,шандра . . . . .',
                '	гусь,ремень,камень,онук,богода,нечипас,долгопалец,маненок,рева,кива . . . . .',
                '	вий,сой,цой,хой -я -ю -я -ем -е'
            ],
            suffixes: [
                'f	б,в,г,д,ж,з,й,к,л,м,н,п,р,с,т,ф,х,ц,ч,ш,щ,ъ,ь . . . . .',
                'f	ска,цка  -ой -ой -ую -ой -ой',
                'f	ая       --ой --ой --ую --ой --ой',
                '	ская     --ой --ой --ую --ой --ой',
                'f	на       -ой -ой -у -ой -ой',

                '       орн,слон а у а ом е',
                '	иной -я -ю -я -ем -е',
                '	уй   -я -ю -я -ем -е',
                '	ца   -ы -е -у -ей -е',

                '	рих  а у а ом е',

                '	ия                      . . . . .',
                '	иа,аа,оа,уа,ыа,еа,юа,эа . . . . .',
                '	их,ых                   . . . . .',
                '	о,е,э,и,ы,у,ю           . . . . .',

                '	ова,ева            -ой -ой -у -ой -ой',
                '	га,ка,ха,ча,ща,жа  -и -е -у -ой -е',
                '	ца  -и -е -у -ей -е',
                '	а   -ы -е -у -ой -е',

                '	ь   -я -ю -я -ем -е',

                '	ия  -и -и -ю -ей -и',
                '	я   -и -е -ю -ей -е',
                '	ей  -я -ю -я -ем -е',

                '	ян,ан,йн   а у а ом е',

                '	ынец,обец  --ца --цу --ца --цем --це',
                '	онец,овец  --ца --цу --ца --цом --це',

                '	ц,ч,ш,щ   а у а ем е',

                '	ай  -я -ю -я -ем -е',
                '	гой,кой  -го -му -го --им -м',
                '	ой  -го -му -го --ым -м',
                '	ах,ив   а у а ом е',

                '	ший,щий,жий,ний  --его --ему --его -м --ем',
                '	кий,ый   --ого --ому --ого -м --ом',
                '	ий       -я -ю -я -ем -и',

                '	ок  --ка --ку --ка --ком --ке',
                '	ец  --ца --цу --ца --цом --це',

                '	в,н   а у а ым е',
                '	б,г,д,ж,з,к,л,м,п,р,с,т,ф,х   а у а ом е'
            ]
        },
        firstName: {
            exceptions: [
                '	лев    --ьва --ьву --ьва --ьвом --ьве',
                '	павел  --ла  --лу  --ла  --лом  --ле',
                'm	шота   . . . . .',
                'm	пётр   ---етра ---етру ---етра ---етром ---етре',
                'f	рашель,нинель,николь,габриэль,даниэль   . . . . .'
            ],
            suffixes: [
                '	е,ё,и,о,у,ы,э,ю   . . . . .',
                'f	б,в,г,д,ж,з,й,к,л,м,н,п,р,с,т,ф,х,ц,ч,ш,щ,ъ   . . . . .',

                'f	ь   -и -и . ю -и',
                'm	ь   -я -ю -я -ем -е',

                '	га,ка,ха,ча,ща,жа  -и -е -у -ой -е',
                '	ша  -и -е -у -ей -е',
                '	а   -ы -е -у -ой -е',
                '	ия  -и -и -ю -ей -и',
                '	я   -и -е -ю -ей -е',
                '	ей  -я -ю -я -ем -е',
                '	ий  -я -ю -я -ем -и',
                '	й   -я -ю -я -ем -е',
                '	б,в,г,д,ж,з,к,л,м,н,п,р,с,т,ф,х,ц,ч	 а у а ом е'
            ]
        },
        middleName: {
            suffixes: [
                '	ич   а  у  а  ем  е',
                '	на  -ы -е -у -ой -е'
            ]
        }
    },

    initialized: false,
    init: function () {
        if (this.initialized) return;
        this.prepareRules();
        this.initialized = true;
    },

    prepareRules: function () {
        for (var type in this.rules) {
            for (var key in this.rules[type]) {
                for (var i = 0, n = this.rules[type][key].length; i < n; i++) {
                    this.rules[type][key][i] = this.rule(this.rules[type][key][i]);
                }
            }
        }
    },

    rule: function (rule) {
        var m = rule.match(/^\s*([fm]?)\s*(\S+)\s+(\S+)\s+(\S+)\s+(\S+)\s+(\S+)\s+(\S+)\s*$/);
        if (m) return {
            sex: m[1],
            test: m[2].split(','),
            mods: [m[3], m[4], m[5], m[6], m[7]]
        }
        return false;
    },

    // склоняем слово по указанному набору правил и исключений
    word: function (word, sex, wordType, gcase) {
        // исходное слово находится в именительном падеже
        if (gcase == this.gcaseNom) return word;

        // составные слова
        if (word.match(/[-]/)) {
            var list = word.split('-');
            for (var i = 0, n = list.length; i < n; i++) {
                list[i] = this.word(list[i], sex, wordType, gcase);
            }
            return list.join('-');
        }

        // Иванов И. И.
        if (word.match(/^[А-ЯЁ]\.?$/i)) return word;

        this.init();
        var rules = this.rules[wordType];

        if (rules.exceptions) {
            var pick = this.pick(word, sex, gcase, rules.exceptions, true);
            if (pick) return pick;
        }
        var pick = this.pick(word, sex, gcase, rules.suffixes, false);
        return pick || word;
    },

    // выбираем из списка правил первое подходящее и применяем
    pick: function (word, sex, gcase, rules, matchWholeWord) {
        wordLower = word.toLowerCase();
        for (var i = 0, n = rules.length; i < n; i++) {
            if (this.ruleMatch(wordLower, sex, rules[i], matchWholeWord)) {
                return this.applyMod(word, gcase, rules[i]);
            }
        }
        return false;
    },

    // проверяем, подходит ли правило к слову
    ruleMatch: function (word, sex, rule, matchWholeWord) {
        if (rule.sex == this.sexM && sex == this.sexF) return false; // male by default
        if (rule.sex == this.sexF && sex != this.sexF) return false;
        for (var i = 0, n = rule.test.length; i < n; i++) {
            var test = matchWholeWord ? word : word.substr(Math.max(word.length - rule.test[i].length, 0));
            if (test == rule.test[i]) return true;
        }
        return false;
    },

    // склоняем слово (правим окончание)
    applyMod: function (word, gcase, rule) {
        switch (gcase) {
            case this.gcaseNom: var mod = '.'; break;
            case this.gcaseGen: var mod = rule.mods[0]; break;
            case this.gcaseDat: var mod = rule.mods[1]; break;
            case this.gcaseAcc: var mod = rule.mods[2]; break;
            case this.gcaseIns: var mod = rule.mods[3]; break;
            case this.gcasePos: var mod = rule.mods[4]; break;
            default: throw "Unknown grammatic case: " + gcase;
        }
        for (var i = 0, n = mod.length; i < n; i++) {
            var c = mod.substr(i, 1);
            switch (c) {
                case '.': break;
                case '-': word = word.substr(0, word.length - 1); break;
                default: word += c;
            }
        }
        return word;
    }
};

const RussianName = function (lastName, firstName, middleName, sex) {
    if (typeof firstName == 'undefined') {
        var m = lastName.match(/^\s*(\S+)(\s+(\S+)(\s+(\S+))?)?\s*$/);
        if (!m) throw "Cannot parse supplied name";
        if (m[5] && m[3].match(/(ич|на)$/) && !m[5].match(/(ич|на)$/)) {
            // Иван Петрович Сидоров
            lastName = m[5];
            firstName = m[1];
            middleName = m[3];
            this.fullNameSurnameLast = true;
        } else {
            // Сидоров Иван Петрович
            lastName = m[1];
            firstName = m[3];
            middleName = m[5];
        }
    }
    this.ln = lastName;
    this.fn = firstName || '';
    this.mn = middleName || '';
    this.sex = sex || this.getSex();
};

RussianName.prototype = {
    // constants
    sexM: RussianNameProcessor.sexM,
    sexF: RussianNameProcessor.sexF,
    gcaseIm: RussianNameProcessor.gcaseIm, gcaseNom: RussianNameProcessor.gcaseNom, // именительный
    gcaseRod: RussianNameProcessor.gcaseRod, gcaseGen: RussianNameProcessor.gcaseGen, // родительный
    gcaseDat: RussianNameProcessor.gcaseDat,                                           // дательный
    gcaseVin: RussianNameProcessor.gcaseVin, gcaseAcc: RussianNameProcessor.gcaseAcc, // винительный
    gcaseTvor: RussianNameProcessor.gcaseTvor, gcaseIns: RussianNameProcessor.gcaseIns, // творительный
    gcasePred: RussianNameProcessor.gcasePred, gcasePos: RussianNameProcessor.gcasePos, // предложный

    fullNameSurnameLast: false,

    ln: '', fn: '', mn: '', sex: '',
    // если пол явно не указан, его можно легко узнать по отчеству
    getSex: function () {
        if (this.mn.length > 2) {
            switch (this.mn.substr(this.mn.length - 2)) {
                case 'ич': return this.sexM;
                case 'на': return this.sexF;
            }
        }
        return '';
    },

    fullName: function (gcase) {
        return (
            (this.fullNameSurnameLast ? '' : this.lastName(gcase) + ' ')
            + this.firstName(gcase) + ' ' + this.middleName(gcase) +
            (this.fullNameSurnameLast ? ' ' + this.lastName(gcase) : '')
        ).replace(/^ +| +$/g, '');
    },
    lastName: function (gcase) {
        return RussianNameProcessor.word(this.ln, this.sex, 'lastName', gcase);
    },
    firstName: function (gcase) {
        return RussianNameProcessor.word(this.fn, this.sex, 'firstName', gcase);
    },
    middleName: function (gcase) {
        return RussianNameProcessor.word(this.mn, this.sex, 'middleName', gcase);
    }
};

(function (window, undefined) {
    'use strict';

    /***** local dataTable *****/
    $.extend(true, $.fn.dataTable.defaults, {
        "language": {
            "url": "/assets/vendor/libs/datatables/i18n/ru.json"
        }
    });
    $(document).on("click", ".sidebar-overlay, .sidebar-content .close", function () {
        $(".sidebar-content").removeClass("show");
        $(".sidebar-overlay").remove();
    });

    /***** show modal *****/
    $(document).on("click", "[data-btn-type='modal']", function (e) {
        e.stopPropagation();
        e.preventDefault();
        $('[data-bs-toggle="tooltip"], .tooltip').tooltip("hide");
        var url = $(this).attr("href"),
            modalContainerId = $("#mainModal");
        $.ajax({
            url: url,
            beforeSend: () => {
                modalContainerId.html('<div class="modal-dialog modal-dialog-centered"><div class="modal-content"><div class="modal-body"><div class="d-flex h-100 justify-content-center align-items-center"><div class="text-center"><p class="mb-0">Пожалуйста, подождите...</p> <div class="sk-wave sk-dark m-0 d-inline-flex"><div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div></div></div></div></div></div></div>').modal("show");
            },
            success: _.debounce((data) => {
                modalContainerId.html(data);
            }, 400), //TODO для красоты (¬‿¬)
            error: (data) => {
                setTimeout(function () { modalContainerId.modal("hide"); }, 400)
                console.error(data);
            }
        });
    });

    /***** add table modal *****/
    $(document).on("click", "[data-btn-type='add']", function () {
        var tableName = $(this).data("for-table");
        var $thisTable = $(`#${tableName}`);
        var params = $(this).data("btn-params");
        var addUrl = $thisTable.data("action-add");
        var changingModalContainerId = $thisTable.data("changingModalContainerId");
        changingModalContainerId = changingModalContainerId ? changingModalContainerId : "mainModal";
        $.ajax({
            url: addUrl,
            data: params,
            async: false,
            success: (data) => {
                $("#" + changingModalContainerId).html(data);
                $("#" + changingModalContainerId).modal("show");
            },
            error: (data, textStatus) => {
            }
        });
    });

    /***** edit table modal *****/
    $(document).on("click", "a[data-btn-type='edit']", function (e) {
        e.stopPropagation();
        e.preventDefault();
        var parentId = $(this).data("parent");
        var $parent = $(parentId);
        if ($parent.length <= 0) {
            $parent = $(this).closest("table");
        }
        var params = $(this).data("btn-params");
        var editUrl = $parent.data("action-edit");
        var changingModalContainerId = $parent.data("changingModalContainerId");
        changingModalContainerId = changingModalContainerId ? changingModalContainerId : "mainModal";
        $.ajax({
            url: editUrl,
            data: params,
            async: false,
            success: (data) => {
                $("#" + changingModalContainerId).html(data);
                $("#" + changingModalContainerId).modal("show");
            },
            error: (data, textStatus) => {
            }
        });
    });

    /***** delete *****/
    $(document).on("click", "a[data-btn-type='remove']", function (e) {
        e.stopPropagation();
        e.preventDefault();
        var $parent = $(this).closest("table");;
        var params = $(this).data("btn-params");
        var removeUrl = $parent.data("action-remove");
        if (typeof removeUrl == "undefined") {
            removeUrl = $(this).data("actionRemove");
        };
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
                    params.comment = comment;
                    $.ajax({
                        type: 'POST',
                        url: removeUrl,
                        data: params,
                        async: false,
                        beforeSend: () => {
                            Swal.showLoading();
                        },
                        complete: () => {
                            Swal.hideLoading();
                        },
                        success: (data) => {
                            if ($parent!=null) {
                                $parent.trigger("reload");
                            }
                            else {
                                document.location.reload();
                            }
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

    /***** close *****/
    $(document).on("click", "a[data-btn-type='close']", function (e) {
        e.stopPropagation();
        e.preventDefault();
        var parentId = $(this).data("parent");
        var isParent = $(parentId).length <= 0;
        var $parent = $(parentId);
        if ($parent.length <= 0) {
            $parent = $(this).closest("table");
        }
        var params = $(this).data("btn-params");
        var removeUrl = $parent.data("action-remove");
        if (typeof removeUrl == "undefined") {
            removeUrl = $(this).data("actionRemove");
        };
        Swal.fire({
            title: 'Закрыть',
            //input: 'textarea',
            showCancelButton: true,
            confirmButtonText: 'Да',
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
            preConfirm: () => {
                $.ajax({
                    type: 'POST',
                    url: removeUrl,
                    data: params,
                    async: false,
                    beforeSend: () => {
                        Swal.showLoading();
                    },
                    complete: () => {
                        Swal.hideLoading();
                    },
                    success: (data) => {
                        if (!isParent) {
                            $parent.trigger("reload");
                        }
                        else {
                            document.location.reload();
                        }
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
    });

    /***** close *****/
    $(document).on("click", "a[data-btn-type='copy']", function (e) {
        e.stopPropagation();
        e.preventDefault();
        var parentId = $(this).data("parent");
        var isParent = $(parentId).length <= 0;
        var $parent = $(parentId);
        if ($parent.length <= 0) {
            $parent = $(this).closest("table");
        }
        var params = $(this).data("btn-params");
        var copyUrl = $parent.data("action-copy");
        if (typeof copyUrl == "undefined") {
            copyUrl = $(this).data("actionCopy");
        };
        Swal.fire({
            title: 'Копировать',
            /*input: 'textarea',*/
            showCancelButton: true,
            confirmButtonText: 'Да',
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
            preConfirm: () => {
                /*if (comment === '') {
                    Swal.showValidationMessage(`Введите комменетарий`);
                } else {
                    params.comment = comment;*/
                    $.ajax({
                        type: 'POST',
                        url: copyUrl,
                        data: params,
                        async: false,
                        beforeSend: () => {
                            Swal.showLoading();
                        },
                        complete: () => {
                            Swal.hideLoading();
                        },
                        success: (data) => {
                            if (!isParent) {
                                $parent.trigger("reload");
                            }
                            else {
                                document.location.reload();
                            }
                        },
                        error: (data, textStatus) => {
                            $.notifi('error', 'Ошибка', data.responseText);
                        }
                    });
                /*}*/
            },
            allowOutsideClick: () => !Swal.isLoading()
        }).then((comment) => {
            //$.notifi('success', 'Готово', 'Запись успешно удалена');
        });
    });


})(window);

/***** custom spinnerBtn plugin *****/
(function ($) {
    const params = {
        content: ""
    };
    var methods = {
        init: function (options) {
            console.log(options);
            console.log('init');
        },
        start: function () {
            var id = this.attr('id');
            var $btn = $(`button[id="${id}"]`);
            if ($btn.length <= 0) { $btn = $(`button[type="submit"][form="${id}"]`); }
            params.content = $btn.html();
            $btn.prop('disabled', true);
            $btn.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Подождите...');

        },
        stop: function () {
            var id = this.attr('id');
            var $btn = $(`button[id="${id}"]`);
            if ($btn.length <= 0) { $btn = $(`button[type="submit"][form="${id}"]`); }
            $btn.prop('disabled', false);
            $btn.html(params.content);
        }
    };

    $.fn.spinnerBtn = function (methodOrOptions) {
        if (methods[methodOrOptions]) {
            return methods[methodOrOptions].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof methodOrOptions === 'object' || !methodOrOptions) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + methodOrOptions + ' does not exist on jQuery.tooltip');
        }
    };
})(jQuery);

// jQuery SerializeToJSON v1.4.1
// github.com/raphaelm22/jquery.serializeToJSON
!function (e) { "function" == typeof define && define.amd ? define(["jquery"], e) : "object" == typeof module && module.exports ? module.exports = function (r, t) { return void 0 === t && (t = "undefined" != typeof window ? require("jquery") : require("jquery")(r)), e(t), t } : e(jQuery) }(function (e) { "use strict"; e.fn.serializeToJSON = function (r) { var t = { settings: e.extend(!0, {}, e.fn.serializeToJSON.defaults, r), getValue: function (r) { var t = r.val(); if (r.is(":radio") && (t = r.filter(":checked").val() || null), r.is(":checkbox") && (t = e(r).prop("checked")), this.settings.parseBooleans) { var n = (t + "").toLowerCase(); "true" !== n && "false" !== n || (t = "true" === n) } var i = this.settings.parseFloat.condition; return void 0 !== i && ("string" == typeof i && r.is(i) || "function" == typeof i && i(r)) && (t = this.settings.parseFloat.getInputValue(r), t = Number(t), this.settings.parseFloat.nanToZero && isNaN(t) && (t = 0)), t }, createProperty: function (r, t, n, i) { for (var a = r, s = 0; s < n.length; s++) { var u = n[s]; if (s === n.length - 1) { var l = i.is("select") && i.prop("multiple"); l && null !== t ? (a[u] = new Array, Array.isArray(t) ? e(t).each(function () { a[u].push(this) }) : a[u].push(t)) : "undefined" != typeof a[u] ? i.is("[type='hidden']") || (a[u] = t) : a[u] = t } else { var o = /\[\w+\]/g.exec(u), c = null != o && o.length > 0; if (c) { u = u.substr(0, u.indexOf("[")), this.settings.associativeArrays ? a.hasOwnProperty(u) || (a[u] = {}) : Array.isArray(a[u]) || (a[u] = new Array), a = a[u]; var f = o[0].replace(/[\[\]]/g, ""); u = f } a.hasOwnProperty(u) || (a[u] = {}), a = a[u] } } }, includeUncheckValues: function (r, t) { e(":radio", r).each(function () { var r = 0 === e("input[name='" + this.name + "']:radio:checked").length; r && t.push({ name: this.name, value: null }) }), e("select[multiple]", r).each(function () { null === e(this).val() && t.push({ name: this.name, value: null }) }) }, serializeArray: function (e) { var r = /\r?\n/g, t = /^(?:submit|button|image|reset|file)$/i, n = /^(?:input|select|textarea|keygen)/i, i = /^(?:checkbox|radio)$/i; return e.map(function () { var e = jQuery.prop(this, "elements"); return e ? jQuery.makeArray(e) : this }).filter(function () { var e = this.type; return this.name && !jQuery(this).is(":disabled") && n.test(this.nodeName) && !t.test(e) && (this.checked || !i.test(e)) }).map(function (e, t) { var n = jQuery(this).val(); return null == n ? null : Array.isArray(n) ? jQuery.map(n, function (e) { return { name: t.name, value: e.replace(r, "\r\n"), elem: t } }) : { name: t.name, value: n.replace(r, "\r\n"), elem: t } }).get() }, serializer: function (r) { var t = this, n = this.serializeArray(e(r)); this.includeUncheckValues(r, n); var i = {}; for (var a in n) if (n.hasOwnProperty(a)) { var s = n[a], u = e(s.elem), l = t.getValue(u), o = s.name.split("."); t.createProperty(i, l, o, u) } return i } }; return t.serializer(this) }, e.fn.serializeToJSON.defaults = { associativeArrays: !0, parseBooleans: !0, parseFloat: { condition: void 0, nanToZero: !0, getInputValue: function (e) { return e.val().split(",").join("") } } } });