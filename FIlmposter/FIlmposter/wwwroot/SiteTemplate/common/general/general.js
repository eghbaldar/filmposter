/////////////////////////////////////////////////////////////////
//
// DevelopeR: Alimohammad Eghbaldar
// https://eghbaldar.ir
//
// Features:
//----> 1: Warning Style Functions [change style when somethings happens at the client side]
//---------> Sample:
//---------> KingWarningStyle("#txtAttachmentTitle", 0);
//---------> KingWarningStyleOff("#txtAttachmentTitle", 0);
//
//----> 2: Check the validation a link [change the entered link in a way of checking two things: 1) the validation of own link struction 2) to comply the link with a parameter by the name of 'domain']
//---------> KingIsUrlValidWithDomain & KingIsUrlValidWithoutDomain
//---------> Sample:
//---------> 
//
/////////////////////////////////////////////////////////////////

// Warning Style
function KingWarningStyle(controlId, type) {
    switch (type) {
        case 0: // border-bottom
            $(controlId).trigger('focus');
            $(controlId).css("border-bottom", "2px dashed #ff8585");
            break;
    }
}
function KingWarningStyleOff(controlId, type) {
    switch (type) {
        case 0: // border-bottom
            $(controlId).next('input[type="text"]').trigger('focus');
            $(controlId).css("border-bottom", "1px solid #dee2e6");
            break;
    }
}
// Check the validation a link
function KingIsUrlValidWithDomain(link, domain) {
    var res = link.match(/(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@@:%_\+.~#?&//=]*)/g);
    if (res != null) {
        var length = domain.length;
        var hostname = link.substring(0, length);
        if (hostname == domain)
            return true;
        else
            return false;
    }
    return false;
};
function KingIsUrlValidWithoutDomain(link) {
    var res = link.match(/(http(s)?:\/\/.)?(www\.)?[-a-zA-Z0-9@@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@@:%_\+.~#?&//=]*)/g);
    if (res != null) {
        return true;
    }
    return false;
};
// give a data and get the time ago based on the following structure
function KingGetTimeAgo(date) {
    var currentDate = new Date();
    var timeDiff = currentDate.getTime() - date.getTime();
    var seconds = Math.floor(timeDiff / 1000);
    var minutes = Math.floor(seconds / 60);
    var hours = Math.floor(minutes / 60);
    var days = Math.floor(hours / 24);
    var weeks = Math.floor(days / 7);
    var months = Math.floor(days / 30);
    var years = Math.floor(days / 365);

    if (seconds < 60) {
        return seconds + " sec ago";
    } else if (minutes < 60) {
        return minutes + " min ago";
    } else if (hours < 24) {
        return hours + " hour ago";
    } else if (days < 7) {
        return days + " day ago";
    } else if (weeks < 4) {
        return weeks + " week ago";
    } else if (months < 12) {
        return months + " month ago";
    } else {
        return years + " year ago";
    }
}
// return only time or date from datetime: for example '2022-03-15T12:30:45'
function KingSeparateOnlyTimeFromDatetime(datetimeString) {
    var d = (datetimeString.split(' ')[1]).split(':');
    return d[0] + ':' + d[1];
}
function KingSeparateOnlyDateFromDatetime(datetimeString) {
    return (datetimeString.replace('T', ' ').split(' ')[0]);
}
function kingConvertMildaToShamsiDate(datetimeString) {
    var date = new Date(datetimeString);
    return convertedDate = date.toLocaleDateString('fa-IR');
}
function KingConvertEnglishNumberToPersianNumber(input) {
    const englishToPerianMap = {
        '0': '۰',
        '1': '۱',
        '2': '۲',
        '3': '۳',
        '4': '۴',
        '5': '۵',
        '6': '۶',
        '7': '۷',
        '8': '۸',
        '9': '۹',
    };
    return input.toString().replace(/\d/g, (digit) => englishToPerianMap[digit]);
}
function KingConvertPersianNumberToEnglishNumber(input) {
    const persianToEnglishMap = {
        '۰': '0',
        '۱': '1',
        '۲': '2',
        '۳': '3',
        '۴': '4',
        '۵': '5',
        '۶': '6',
        '۷': '7',
        '۸': '8',
        '۹': '9',
    };

    return input.toString().replace(/[۰-۹]/g, (digit) => persianToEnglishMap[digit]);
}
// Check null, 'null', ''
// how to use? alert(EnglishTitle.val().isEmptyKing());
// result null or empty returns TRUE
// result filled up returns FALSE
String.prototype.isEmptyKing = function () {
    return (this.length === 0 || !this.trim() || this.trim() == '' || this.toLowerCase().trim() == 'null');
};
function isEmptyKing(str) {
    if (str === null || str.length === 0 || !str.trim() || str.trim() === '')
        return true;
    else
        return false;
}

// Defination an attribute to prevent entering characters (only numbers)
document.addEventListener('DOMContentLoaded', function () {
    $('input[onlynumber]').keydown(function (event) {
        // Allow only numeric keys: 0-9, numpad 0-9, backspace, and delete
        if (
            event.keyCode !== 8 && // Backspace
            event.keyCode !== 46 && // Delete
            (event.keyCode < 48 || event.keyCode > 57) && // 0-9
            (event.keyCode < 96 || event.keyCode > 105) // Numpad 0-9
        ) {
            event.preventDefault();
        }
    });
    $('input[nospace]').keydown(function (event) {
        // Prevent spaces from being entered
        if (event.keyCode === 32) {
            // Prevent the default behavior of the key press event
            event.preventDefault();
        }
    });
    $('input[onlyEnglishalphabet]').keypress(function (event) {
        // Allow only alphabetic characters
        var char = String.fromCharCode(event.which);
        if (!/[a-zA-Z\s]/.test(char)) {
            event.preventDefault();

            // Create a tooltip or display an error message
            $(this).tooltip({
                title: 'تنها از حروف انگلیسی استفاده کنید.',
                trigger: 'manual',
                placement: 'bottom'
            }).tooltip('show');

            // Remove the tooltip after a short delay
            setTimeout(function () {
                $(this).tooltip('hide');
            }.bind(this), 2000);
        }
    });

    $('input[onlyFarsialphabet]').keypress(function (event) {
        // Allow only alphabetic characters
        var char = String.fromCharCode(event.which);
        if (!/[\u0600-\u06FF\s]/.test(char)) {
            event.preventDefault();

            // Create a tooltip or display an error message
            $(this).tooltip({
                title: 'تنها از حروف فارسی استفاده کنید.',
                trigger: 'manual',
                placement: 'bottom'
            }).tooltip('show');

            // Remove the tooltip after a short delay
            setTimeout(function () {
                $(this).tooltip('hide');
            }.bind(this), 2000);
        }
    });
    $('input[onlyEnglishFarsialphabet]').keypress(function (event) {
        // Allow both English and Farsi characters
        var char = String.fromCharCode(event.which);
        if (!/[a-zA-Z\u0600-\u06FF]/.test(char)) {
            event.preventDefault();
        }
    });

    const allowedChars = /^[a-zA-Z0-9@._\-!#$%&'*+/=?^_`{|}~]+$/;
    $('input[onlyEmail]').keypress(function (event) {
        const char = String.fromCharCode(event.which);

        if (!allowedChars.test(char)) {
            event.preventDefault();
            $(this).tooltip({
                title: 'کارکتر وارد شده مطابق با الگوی ایمیل‌های استاندارد نمی‌باشد.',
                trigger: 'manual',
                placement: 'bottom'
            }).tooltip('show');

            // Hide the tooltip after 3 seconds (3000 milliseconds)
            setTimeout(() => {
                $(this).tooltip('hide');
            }, 3000);
        }
    });

});
function validateIranianCellNumber(phoneNumber) {
    // Remove any non-numeric characters from the phone number
    phoneNumber = phoneNumber.replace(/\D/g, '');
    // Check if the phone number starts with 09 or 9
    if (!/^(?:09|9)\d{9}$/.test(phoneNumber)) {
        return false;
    }
    return true;
}

// check email address format
function KingValidEmail(email) {
    // Define the email regular expression pattern
    var emailPattern = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;

    // Check if the email matches the pattern
    return emailPattern.test(email);
}

// copy a text
function KingCopyText(text) {
    navigator.clipboard.writeText(text);
}

// close a modal
function CloseModal(modalId) {
    $("#" + modalId).modal('hide');
}

// money formation
function formatMoney(amount) {
    let amountString = amount.toString();
    let formattedAmount = '';

    for (let i = amountString.length - 1, j = 1; i >= 0; i--, j++) {
        formattedAmount = amountString[i] + formattedAmount;
        if (j % 3 === 0 && i !== 0) {
            formattedAmount = '.' + formattedAmount;
        }
    }

    return formattedAmount;
}

// limit characters for inputs
function limitDigits(input, maxNum) {
    // sample:  oninput="limitDigits(this,11)"
    const value = input.value;

    if (value.length > maxNum) {
        input.value = value.slice(0, maxNum);
    }
}