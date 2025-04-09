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
    // set defaultvalue [today date]
    const today = new Date();
    const [sy, sm, sd] = farvardin.gregorianToSolar(today.getFullYear(), today.getMonth() + 1, today.getDate());
    const formatted = `${sy}/${sm.toString().padStart(2, '0')}/${sd.toString().padStart(2, '0')}`;
    document.getElementById("txtProductionDate").value = formatted;
};
// the following function will be called when you are submiting the form and needing to convert the Persian date to Gregorian date
window.getGregorianProductionDate = () => {
    const [shamsiYear, shamsiMonth, shamsiDay] = $("#txtProductionDate").val().split('/').map(Number);
    const [gy, gm, gd] = farvardin.solarToGregorian(shamsiYear, shamsiMonth, shamsiDay);
    return `${gy}-${gm.toString().padStart(2, '0')}-${gd.toString().padStart(2, '0')}`;
};
// ================================================================
