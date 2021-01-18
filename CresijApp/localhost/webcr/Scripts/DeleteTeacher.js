$ = jQuery.noConflict();

function OnSuccess_(response) {
    var idata = response.d;
    if (idata > 0) {
        $("#sec_box").load("window/p-data/004.html");
    }
}
function OnErrorCall_(respo) {
    console.log(respo);
}
$(document).ready(function () {
    $("#deleteTeacher").on('click', function () {
        console.log("org id: " + $("#teacherid").val());
        var jsonData = JSON.stringify({
            id: $("#teacherid").val()
        });
        $.ajax({
            type: "POST",
            url: "../Services/DeleteOrgData.asmx/DeleteTeacher",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_,
            error: OnErrorCall_
        });
    });
})