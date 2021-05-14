function showLoader() {
    $("#divLoader").show();
}
function hideLoader() {
    $("#divLoader").hide();
}
$(document).ajaxSend(function (event, request, settings) {
    showLoader();
});

$(document).ajaxComplete(function (event, request, settings) {
    hideLoader();
});
