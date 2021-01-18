$ = jQuery.noConflict();

function OnSuccess_(response) {
    var idata = response.d;
    if (idata > 0) {
        $("#sec_box").loadPageScript("window/p-data/001.html");
        $("#left_menu").loadPageScript("components/left_menu.html");
    }
}
function OnErrorCall_(respo) {
    console.log(respo);
}
$(document).ready(function () {
    $("#deleteorglink").on('click', function () {
        console.log("org id: " + $("#orgsno").val());
        var jsonData = JSON.stringify({
            sno: $("#orgsno").val()
        });
        $.ajax({
            type: "POST",
            url: "../Services/DeleteOrgData.asmx/DeleteBuilding",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_,
            error: OnErrorCall_
        });
    });
})