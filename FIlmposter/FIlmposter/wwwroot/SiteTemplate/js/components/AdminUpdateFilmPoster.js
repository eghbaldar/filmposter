window.scrollToElements = function (elements) {

    // Filter out any file input elements from the array of elements
    // اگه کد زیر نمیذاشتم، هنگام رفتن روی کنترله «فایل» خطا داشتیم
    // منظور از روی کنترل
    // <input type='file' ...>
    // است!
    var validElements = elements.filter(function (element) {
        return element.tagName !== 'INPUT' || element.type !== 'file';
    });

    if (validElements.length > 0) {
        // Scroll to the first valid element
        var firstInvalidElement = validElements[0];
        firstInvalidElement.scrollIntoView({
            behavior: 'smooth',
            block: 'center' // Scroll to the center of the page
        });
        firstInvalidElement.focus(); // Focus the first valid element
    }
};
// ================================================================
// Persian Date Section
// the following fucntion will be fired from blazor.razor.cs method: OnAfterRenderAsync()
// for example check: AdminInsertFilmPoster.razor.cs
window.initializePersianDatePicker = function () {
    $(".shamsidate").persianDatepicker();
    // converte the date to shamsi based on the value is given based on ".shamsidate" class
    $(".shamsidate").each(function () {
        const input = this;

        const gregDate = new Date(input.value); // Parse current value if it exists

        // Fallback to today's date if the input is empty or invalid
        const sourceDate = isNaN(gregDate) ? new Date() : gregDate;

        const [sy, sm, sd] = farvardin.gregorianToSolar(
            sourceDate.getFullYear(),
            sourceDate.getMonth() + 1,
            sourceDate.getDate()
        );

        const formatted = `${sy}/${sm.toString().padStart(2, '0')}/${sd.toString().padStart(2, '0')}`;
        input.value = formatted;
    });
};
window.setShamsiProductionDate = function (gregorianDateStr) {
    // Convert Gregorian to Shamsi
    const gregDate = new Date(gregorianDateStr);
    const [sy, sm, sd] = farvardin.gregorianToSolar(
        gregDate.getFullYear(),
        gregDate.getMonth() + 1,
        gregDate.getDate()
    );

    const shamsi = `${sy}/${sm.toString().padStart(2, '0')}/${sd.toString().padStart(2, '0')}`;    
    const input = document.getElementById("txtProductionDate");
    if (input) {
        input.value = shamsi;
        // Reattach the Persian datepicker just in case it was lost
        $(input).persianDatepicker({
            initialValue: false
        });
    }
};

// the following function will be called when you are submiting the form and needing to convert the Persian date to Gregorian date
window.getGregorianProductionDate = () => {
    const [shamsiYear, shamsiMonth, shamsiDay] = $("#txtProductionDate").val().split('/').map(Number);
    const [gy, gm, gd] = farvardin.solarToGregorian(shamsiYear, shamsiMonth, shamsiDay);
    return `${gy}-${gm.toString().padStart(2, '0')}-${gd.toString().padStart(2, '0')}`;
};
// ================================================================
window.openFileBrowser = () => {
    document.getElementById('filePosterUpdate').click();
};
window.ChangeTheNewPoster = (src) => {
    $("#imgPoster").attr("src", src);
};