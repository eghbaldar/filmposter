function validateInput(input) {
    // Check for symbols
    if (/[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/.test(input)) {
        KingSweetAlert(false, "استفاده از کارکترها در عنوان فارسی مجاز نمی باشد.");
        return false;
    }

    // Check for more than one space between words
    if (/\s{2}/.test(input)) {
        KingSweetAlert(false, "وارد کردن بیش از یک فاصله بین کلمات عنوان فارسی مجاز نمی باشد.");
        return false;
    }

    // Check for sentence starting with a number
    if (/^\d/.test(input)) {
        KingSweetAlert(false, "عنوان نباید با عدد شروع شود.");
        return false;
    }

    return true;
}

//// Example usage:
//if (!validateInput($("#txtTitleFa").val())) {
//    return;
//}