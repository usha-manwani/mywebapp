$ = jQuery.noConflict();

function OnSuccess_(response) {
    var idata = response.d;
    console.log("value of data " + idata);
   
        $("#sec_box").load("window/p-data/005.html");
    
}
function OnErrorCall_(respo) {
    console.log(respo);
}
$(document).ready(function () {
    $("#deleteStudent").on('click', function () {
        console.log("student id: " + $("#studentid").val());
        var jsonData = JSON.stringify({
            id: $("#studentid").val()
        });
        $.ajax({
            type: "POST",
            url: "../Services/DeleteOrgData.asmx/DeleteStudent",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_,
            error: OnErrorCall_
        });
    });
})