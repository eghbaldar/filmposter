/////////////////////////////////////////////////////////////////
//
// DevelopeR: Alimohammad Eghbaldar
// https://eghbaldar.ir
//
// Features:
//----> 1: Check the extension and size of file
//----> Sample:
// var file = this.files[0];
// if (checkSizeExtension(file, ["jpg", "png", "bmp", "jpeg"], "2097152",true)) {}
//
//----> Sample:
// KingCheckSizeExtension(file, ["jpg", "png", "bmp", "jpeg"], "11200", true);
/////////////////////////////////////////////////////////////////checkSizeExtension

//////////////////////////////////////////////////////////////////
//
// Some points:
// (1) to clear: $("#fileIcon").val(null);
// (2) to change lable: $("#fileIcon").next('.custom-file-label').html('Choose file');
//
//////////////////////////////////////////////////////////////////

function KingCheckSizeExtension(file, arr_extensions, size, alertMode) {
    var getextension = /[^.]+$/.exec(file.name);
    if (parseInt(arr_extensions.indexOf(getextension.toString().trim().toLowerCase())) > -1) {
        var fileSize = size;
        if (file.size < fileSize) {

            return true;
        }   
        else {
            var sizeToMG = (((size / 1024) / 1024)).toFixed(2);
            if (alertMode) {
                Swal.fire({
                    title: 'خطا در بارگذاری!',
                    text: 'حداکثر حجم فایل باید کمتر از  ' + sizeToMG.toString() + ' مگابایت باشد',
                    icon: 'warning',
                    showCancelButton: false,
                    confirmButtonColor: '#000222',
                    confirmButtonText: 'متوجه شدم'
                });
            }
            return false;
        }
    }
    else {
        if (alertMode) {
            Swal.fire({
                title: 'خطا در بارگذاری!',
                text: 'فرمت فایل  ' + getextension.toString() + ' قابل قبول نمی‌باشد.',
                icon: 'warning',
                showCancelButton: false,
                confirmButtonColor: '#000222',
                confirmButtonText: 'متوجه شدم'
            });
        }
        return false;
    }
}
function KingCheckHasFile(controlId) {
    // for example: alert(KingCheckHasFile("#fileIcon"));
    if ($(controlId)[0].files.length > 0) return true; else return false;
}