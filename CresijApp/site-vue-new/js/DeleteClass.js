$ = jQuery.noConflict();

function OnSuccess_(response) {
    var idata = response.d;
    console.log("value of data " + idata);
    $("#left_menu").loadPageScript("components/left_menu.html");
    $("#sec_box").loadPageScript("window/p-data/003.html");

}
function OnErrorCall_(respo) {
    console.log(respo);
}
$(document).ready(function () {
    $("#deleteClass").on('click', function () {
        console.log("class id: " + $("#classid").val());
        var jsonData = JSON.stringify({
            id: $("#classid").val()
        });
        $.ajax({
            type: "POST",
            url: "../Services/DeleteOrgData.asmx/DeleteClass",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_,
            error: OnErrorCall_
        });
    });
})