$(document).ready(function () {
    var tabcontent;
    tabcontent = document.getElementsByClassName("TabcontentClass");
    for (i = 0; i < tabcontent.length; i++) {
        if (tabcontent[i].className == "TabcontentClass active") {
            document.getElementById(tabcontent[i].id).style.display = "block";
        }
    }
});
function tabNavigation(evt, tabName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("TabcontentClass");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(tabName).style.display = "block";
    $("#" + tabName).prop('hidden', false);
    //alert(evt.currentTarget.className);
    evt.currentTarget.className += " active";
}

////////////////////////////////////////////////
// when you want to change the tabPage manually
// developed by the King [blog.eghbaldar.ir]
////////////////////////////////////////////////
function tabNavigationByTabName(tabName, indexPage) {
    var i, tabcontent, tablinks;

    tabcontent = $("body").find(".TabcontentClass");
    for (i = 0; i < tabcontent.length; i++) {
        $(tabcontent[i]).prop('hidden', true);
    }

    tablinks = $("body").find(".tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    $("#"+tabName).prop('hidden', false);
    $("#" + tabName).css('display', 'inline');
    tablinks[indexPage].className += " active";
}
////////////////////////////////////////////////
// Get the NAME of ACTIVATE TAB
// developed by the King [blog.eghbaldar.ir]
////////////////////////////////////////////////
function tabNavigationGetActiveTabText(tabName) {
    // developed by the King [blog.eghbaldar.ir]
    var activeTab = document.querySelector('.' + tabName + '.active');
    if (activeTab) {
        return $(activeTab).text();
    } else {
        return null; // No active tab found
    }
}
