function updateCounter(e, max) {
    var id = $(e).attr('id');
    var maxChar = max;
    var pCount = 0;
    var pVal = $(e).val();
    pCount = pVal.length;
    $("#" + id + "Counter").text(pCount + ' / ' + maxChar);
}