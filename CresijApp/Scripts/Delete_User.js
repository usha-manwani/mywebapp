$ = jQuery.noConflict();

function OnSuccess_(response) {
    var idata = response.d;
    console.log("value of data " + idata);

    $("#sec_box").load("window/p-data/002.html");

}
function OnErrorCall_(respo) {
    console.log(respo);
}
$("#deleteUser").off('click').on('click', function () {
    console.log("user id: " + $("#userId").val());
    var jsonData = JSON.stringify({
        id: $("#userId").val()
    });
    $.ajax({
        type: "POST",
        url: "../Services/DeleteOrgData.asmx/DeleteUser",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
});