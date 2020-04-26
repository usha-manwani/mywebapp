$ = jQuery.noConflict();
$(function () {
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetTransferedSchedule",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
});
function OnSuccess_(response) {
        var idata = response.d;
        console.log(idata);
        FillChangeSchedule(idata);
    }
function OnErrorCall_(respo) {
        console.log(respo);
}

function FillChangeSchedule(idata) {



}
