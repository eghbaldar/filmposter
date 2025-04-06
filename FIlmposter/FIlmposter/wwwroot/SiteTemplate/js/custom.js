window.scrollToElements = function (elements) {

    // Filter out any file input elements from the array of elements
    // اگه کد زیر نمیذاشتم، هنگام رفتن روی کنترل خطا داشتیم
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
