function checkStrength(password) {
    var val = password;
    var meter = document.getElementById("meter");
    var no = 0;
    if (val != "") {
        // If the password length is less than or equal to 6
        if (val.length <= 6) no = 1;

        // If the password length is greater than 6 and contain any lowercase alphabet or any number or any special character
        if (val.length > 6 && (val.match(/[a-z]/) || val.match(/\d+/) || val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/))) no = 2;

        // If the password length is greater than 6 and contain alphabet,number,special character respectively
        if (val.length > 6 && ((val.match(/[a-z]/) && val.match(/\d+/)) || (val.match(/\d+/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)) || (val.match(/[a-z]/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)))) no = 3;

        // If the password length is greater than 6 and must contain alphabets,numbers and special characters
        if (val.length > 6 && val.match(/[a-z]/) && val.match(/\d+/) && val.match(/.[!,@@,#,$,%,^,&,*,?,_,~,-,(,)]/)) no = 4;

        if (no == 1) {
            $("#meter").animate({ width: '25px' }, 300);
            meter.style.backgroundColor = "red";
            return false // means invalidated
        }

        if (no == 2) {
            $("#meter").animate({ width: '25px' }, 300);
            meter.style.backgroundColor = "#F5BCA9";
            return false // means invalidated
        }

        if (no == 3) {
            $("#meter").animate({ width: '25px' }, 300);
            meter.style.backgroundColor = "#FF8000";
            return false // means invalidated
        }

        if (no == 4) {
            $("#meter").animate({ width: '25px' }, 300);
            meter.style.backgroundColor = "#00FF40";
            return true // means validated
        }
    }

    else {
        meter.style.backgroundColor = "white";
        return false // means invalidated
    }
}

function generatePass(pass, rePass) {

    let passMadeUp = '';
    let str = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ' +
        'a%b!cd_e+fg(hi/%jklm*n[%op]qrs/tu|vwxyz%01%23$456@@78%9@@#$';

    for (let i = 1; i <= 25; i++) {
        let char = Math.floor(Math.random()
            * str.length + 1);

        passMadeUp += str.charAt(char)
    }
    $(pass).val(passMadeUp);
    $(rePass).val(passMadeUp);
    //$(pass).get(0).type = 'text';
    if (!checkStrength(passMadeUp))
        validationColorSet(pass, rePass);
    else
        validationColorClear(pass, rePass);    
}

function matchPassword(pass, rePass) {
    //check validation status of rePass
    var rePass = $(rePass);
    var pass = $(pass);
    if (rePass.val() == '' || pass.val() == '') {
        if (rePass.val() == '') rePass.css("background-color", "#fcc"); else rePass.css("background-color", "#fff");
        if (pass.val() == '') pass.css("background-color", "#fcc"); else pass.css("background-color", "#fff");
        return;
    }
    //check match pass and rePass
    if (pass.val() != rePass.val()) {
        validationColorSet(pass, rePass);
        Swal.fire({
            title: 'Error!',
            text: 'پسوردها مطابقت ندارند.',
            icon: 'error',
            confirmButtonColor: '#ff5722',
            confirmButtonText: 'متوجه شدم',
        }).then((result) => {
            return false;
        });
        return false;
    }
    else {
        if (!checkStrength(pass.val())) {
            validationColorSet(pass, rePass);
            Swal.fire({
                title: 'Error!',
                text: 'پسورد به اندازی کافی قوی انتخاب نشده است.',
                icon: 'error',
                confirmButtonColor: '#ff5722',
                confirmButtonText: 'متوجه شدم',
            }).then((result) => {
                return false;
            })
            return false;
        };
    }
    validationColorClear(pass, rePass);
    return true;
}

function showPassword(sender, object) {
    var x = document.getElementById(sender);
    if (x.type == "text") {
        x.type = "password";
        $(object).toggleClass('fa-eye-slash').toggleClass('fa-eye');
    }
    else {
        x.type = "text";
        $(object).toggleClass('fa-eye-slash').toggleClass('fa-eye');
    }
}

function checkPassMatchRePass(originalPass, repeatedPass, warningSpan) {

    var Pass = $(originalPass);
    if (checkStrength(Pass.val())) {
        Pass.css("background-color", "#fff");
        var rePass = $(repeatedPass);
        if (Pass.val() != rePass.val()) {
            $(warningSpan).slideDown();
            $(warningSpan).text("Passwords do not match.");
            Pass.css("background-color", "#fcc");
            rePass.css("background-color", "#fcc");
            return false;
        }
        else {
            $(warningSpan).text("");
            Pass.css("background-color", "#fff");
            rePass.css("background-color", "#fff");
            $(warningSpan).text("");
            $(warningSpan).slideUp();
            return true;
        }
    }
    else {
        Pass.css("background-color", "#fcc");
        return false;
    }
}

function validationColorSet(pass, rePass) {
    $(pass).css("background-color", "#fcc");
    $(rePass).css("background-color", "#fcc");
}
function validationColorClear(pass, rePass) {
    $(pass).css("background-color", "#fff");
    $(rePass).css("background-color", "#fff");
}
function validationColorDisabled(pass, rePass) {
    $(pass).css("background-color", "#E9ECEF");
    $(rePass).css("background-color", "#E9ECEF");
}

function PasswordCheckbox(e) {
    var check = $(e).is(":checked");
    if (check) {
        InitialKingPass('#spanGeneratePass', '#txtPassword', '#txtRePassword');
    }
    else {
        ResetKingPassword('#spanGeneratePass', '#spanInvalidRePassword', '#txtPassword', '#txtRePassword');
    }
}

function ResetKingPassword(spanGeneration, warningSpan, pass, rePass) {

    $(warningSpan).slideUp();
    $(spanGeneration).css("pointer-events", "none");
    $("#spanPassVisibilty").css("pointer-events", "none");

    $(pass).val('');
    $(rePass).val('');
    $(pass).attr('disabled', 'disabled');
    $(rePass).attr('disabled', 'disabled');

    var meter = document.getElementById("meter");
    meter.style.backgroundColor = "#fff";

    validationColorDisabled(pass, rePass);
 
}

function InitialKingPass(spanGeneration, pass, rePass) {

    $(spanGeneration).css("pointer-events", "auto");
    $(pass).removeAttr('disabled');
    $(rePass).removeAttr('disabled');

    validationColorClear(pass, rePass);

    $("#spanPassVisibilty").css("cursor", "pointer");
    $(spanGeneration).css("cursor", "pointer");
    $("#spanPassNotMatch").css("cursor", "pointer");

}