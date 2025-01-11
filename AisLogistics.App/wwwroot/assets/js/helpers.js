(function ($) {
    $.extend({
        pageBlock: function () {
            $.blockUI({
                message:
                    '<div><p class="mb-0">Пожалуйста, подождите...</p> <div class="sk-wave m-0 d-inline-flex"><div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div> <div class="sk-rect sk-wave-rect"></div></div> </div>',
                css: {
                    backgroundColor: 'transparent',
                    color: '#fff',
                    border: '0'
                },
                overlayCSS: {
                    opacity: 0.5
                }
            });
        },
        /**/
        nameof: (element) => {
            return element.attr("name");
        },
        /***** russian plural *****/
        declOfNum: function (n, titles) {
            return titles[(n % 10 === 1 && n % 100 !== 11) ? 0 : n % 10 >= 2 && n % 10 <= 4 && (n % 100 < 10 || n % 100 >= 20) ? 1 : 2]
        },
        /*Отображение уведомления.*/
        notifi: function (type, title, text) {
            toastr[type](text, title, {
                closeButton: true,
                tapToDismiss: false,
                timeOut: "6000"
            });
        },
        customValidate: {
            snils: (snils) => {
                var result = false;
                var error;
                if (typeof snils === 'number') {
                    snils = snils.toString();
                } else if (typeof snils !== 'string') {
                    snils = '';
                }
                if (!snils.length) {
                    error = 'СНИЛС пуст';
                } else if (/[^0-9]/.test(snils)) {
                    error = 'СНИЛС может состоять только из цифр';
                } else if (snils.length !== 11) {
                    error = 'СНИЛС может состоять только из 11 цифр';
                } else {
                    var sum = 0;
                    for (var i = 0; i < 9; i++) {
                        sum += parseInt(snils[i]) * (9 - i);
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
                    if (checkDigit === parseInt(snils.slice(-2))) {
                        result = true;
                    } else {
                        error = 'Неправильное контрольное число';
                    }
                }
                console.log(result);
                console.log(error);
                return {
                    valid: result,
                    message: error,
                };
            }
        }
    });
})(jQuery);