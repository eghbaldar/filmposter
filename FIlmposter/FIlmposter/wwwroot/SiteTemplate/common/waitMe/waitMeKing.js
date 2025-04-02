var ROOT = '@Url.Content("~")' + '/common/waitMe/loading.gif';
// BUTTON LOADING
function run_waitMe(el, num, effect) {
    text = 'Please wait...';
    fontSize = '';
    switch (num) {
        case 1:
            maxSize = '';
            textPos = 'vertical';
            break;
        case 2:
            text = '';
            maxSize = 30;
            textPos = 'vertical';
            break;
        case 3:
            maxSize = 30;
            textPos = 'horizontal';
            fontSize = '18px';
            break;
    }    
    el.waitMe({
        effect: effect,
        text: text,
        bg: 'rgba(255,255,255,0.7)',
        color: 'blue',
        maxSize: maxSize,
        waitTime: -1,
        source: ROOT,
        textPos: textPos,
        fontSize: fontSize,
        onClose: function (el) { }
    });
}
// with ID
function btnWaitMe_Start(e) {
    $('#' + e).attr('disabled', 'disabled !important'); // disable submit button temporary
    run_waitMe($('#' + e), 2, 'pulse');
}
function btnWaitMe_Stop(e) {
    $('#' + e).attr('disabled', false); // enable submit button
    $('.containerBlock > form').waitMe('hide');
    $('#' + e).waitMe('hide');
}
// with Class
function btnWaitMe_Class_Start(e) {
    $('.' + e).attr('disabled', 'disabled !important'); // disable submit button temporary
    run_waitMe($('.' + e), 2, 'pulse');
}
function btnWaitMe_Class_Stop(e) {
    $('.' + e).attr('disabled', false); // enable submit button
    $('.containerBlock > form').waitMe('hide');
    $('.' + e).waitMe('hide');
}
// LOADING PAGE AFTER FUNCTION CALLING
function pageWaitMe() {

    // Ensure that the spinner is only added once
    if ($('.waitMe_container').length === 0) {
        // Add necessary styles dynamically
        const styles = `
        <style id="waitMeStyles">

              /* Fullscreen light gray overlay */
            .waitMe_container {
                position: fixed;
                top: 0;
                left: 0;
                width: 100vw;
                height: 100vh;
                background: rgba(211, 211, 211, 0.3) !important; /* Light gray backdrop with transparency */
                z-index: 9999;
                display: flex;
                justify-content: center;
                align-items: center;
            }
            /* Loader (spinner) style */
            .waitMe_container.spinner {
                border: 8px solid #f3f3f3;
                border-top: 8px solid #3498db;
                border-radius: 50%;
                width: 80px;
                height: 80px;
                animation: spin 2s linear infinite;
            }

            /* Spin animation */
            @keyframes spin {
                0% { transform: rotate(0deg); }
                100% { transform: rotate(360deg); }
            }
        </style>
        `;

        // Append the dynamic styles to the head
        $('head').append(styles);

        // preloading ...
        // Add loader container
        //$('body').addClass('waitMe_body');
        //var img = '/SiteTemplate/assets/imgs/template/loading.gif';
        //elem = $('<div class="waitMe_container"><img src="' + img + '" alt="Loading..."></div>');
        //$('body').prepend(elem); // Add the loader to the body
    }
}
function pageWaitMeRemove() {
    $('body.waitMe_body').find('.waitMe_container:not([data-waitme_id])').remove();
    $('body.waitMe_body').removeClass('waitMe_body hideMe');
}
// After each _PostBack
$(document).ready(function () {
    pageWaitMe("progress");
});
// Remove the loader once the page is fully loaded
$(window).on('load', function () {
    // Remove loader and associated styles when the page is fully loaded
    $('.waitMe_container').remove(); // Remove the loader container
    $('body').removeClass('waitMe_body'); // Remove any additional classes
    $('#waitMeStyles').remove(); // Remove the dynamically added styles
});
// Lock the page
function lockTheEntirePage(type) {
    switch (type) {
        case "on":
            $('body').addClass('lockWaitAllPage');
            break;
        case "off":
            $('body').removeClass('lockWaitAllPage');
            break;
    }
}
