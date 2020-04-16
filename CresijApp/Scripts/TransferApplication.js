$ = jQuery.noConflict();
$(function () {
    var v = $("#schid").val();
    console.log(v);
    var ar = v.split("&");
    var classname = ar[0].replace("%20", ' ');
    var coursename = ar[1].replace("%20", ' ');
    console.log(classname);
    console.log(coursename);
    GetData(classname, coursename);
})

function GetData(classn, course) {
    var adata = [];
    adata[0] = classn;
    adata[1] = course;
    var jsonData = JSON.stringify({
        name: adata
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetCourseDetails",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
}
function OnSuccess_(response) {
    var idata = response.d;
    console.log(idata);
    FillEditSchedule(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}

function FillEditSchedule(data) {
    var idata = data[0];
    document.getElementById("coursename").innerText = idata[1];
    document.getElementById("location").innerText = idata[3] + "," + idata[2];
    document.getElementById("oldsession").innerText = idata[7];
    document.getElementById("oldweek").innerText = idata[4] + " - " + idata[5];
    document.getElementById("oldsession").innerText = idata[6] + " , " + idata[7];
    document.getElementById("beforelocation").innerText = idata[3] + ", " + idata[2];
    document.getElementById("oldteacher").innerText = idata[0];
}
$("#btnSaveTransfer").off('click').on('click', function () {
    console.log("clicked on save button");
    SaveTransfer();
});

function SaveTransfer() {
    var c = document.getElementById("location").innerText.split(",");
    var classname = c[1];
    var coursename = document.getElementById("coursename").innerText;
    var reason = document.getElementById("txtreason").innerText;
    var week = document.getElementById("newweek").innerText;
    var day = document.getElementById("weekday").innerText;
    var section = document.getElementById("section").innerText;
    var building = document.getElementById("building").innerText;
    var classroom = document.getElementById("classroom").innerText;
    var teacher = document.getElementById("newteacher").innerText;



}
