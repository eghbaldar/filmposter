/*
Developed by Alimohammad Eghbaldar (The King)
    https://eghbaldar.ir
    info@eghbaldar.ir

References:
1) https://select2.org/
2) https://stackoverflow.com/questions/66839318/select2-set-default-value-for-list-of-dropdown-items-data-obtained-from-c-shar
*/
document.addEventListener('DOMContentLoaded', function () {
    $('.kingSelector2').select2();
    $(".kingSelector2").select2({
        width: 'resolve'
    });
    // set their click handlers
    $('.ParentHolderSelect').click(function () {
        $(this).find('select').each(function () {

            $(this).select2('open');

        });
    });
    // set their default values
    $('.ParentHolderSelect select').each(function () {
        var defaultItems = $(this).attr("data-defaultItems");
        if (defaultItems != '' && defaultItems != null)
            SetKingSelector2Ids(($(this).attr("id")), defaultItems);
    });
});
function SetKingSelector2Ids(elementId, items) {
    // fill up the items arugment with this strucutre: "1,2,5,6,..."
    var Items = items.toString().split(",");
    $('#' + elementId).val(Items);
    $('#' + elementId).trigger('change');
}
function GetKingSelector2Ids(elementId) {
    var selectedValues = $('#' + elementId).select2('data');
    var selectedIds = selectedValues.map(function (item) {
        return item.id;
    });
    return selectedIds;
}