var days = ["sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
console.log("section " + $("#section").val());
console.log("section " + $("#classroom").val());
$(document).ready(function () {
    console.log("loaded 3-1-1");    
    
    var date = $('input[name = "appointmentDate"]').val();
    
    var jsonData = JSON.stringify({
        name: date
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetWeekYearSemester",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    $("#btnReserveClass").on('click', function () {
        console.log("clicked on save button");
        SaveReserveApplication();
    });
})

function OnSuccess_(response) {
    var data = response.d;
    $("#schoolyear").html(data[2]);
    $("#semestername").html(data[1]);
    var d = $('input[name = "appointmentDate"]').val();
    var a = d.split("-");
    var date = new Date(a[0], (a[1] - 1), a[2]);
    var daynum = date.getDay();
    var day = days[daynum];
    $("#day").html(day);
    $("#selectedsection").html($("#section").val());
    $("#week").html(data[0]);
    $("#selecteddate").html(d);
    $("#borrowingclass").attr('value', $('#classroom').val());
}

function OnErrorCall_(response) {
    console.log(response);
    alert("some error occures. Please try again");
}



function SaveReserveApplication() {

    var data = [];
    data[0] = $("#schoolyear").text();
    data[1] = $("#semestername").text();
    data[2] = $("#selecteddate").text();
    data[3] = $("#selectedsection").text().split(",")[0];
    data[4] = $("#week").text();
    data[5] = $("#borrowingclass").val();
    data[6] = $("#borrowingunit").val();
    data[7] = $("#workphone").val();
    data[8] = $("#appointment").val();
    data[9] = $("#personid").val();
    data[10] = $("#contactnumber").val();
    data[11] = $("#purpose").val();
    data[12] = $("#ReservationPurpose").val();
    
    var equip=[];
    $("input[name='reserveEquip'][type='checkbox']:checked").each(function () {
        equip.push($(this).val());
        
    });
    var d = equip.join(",");
    data[13] = d;
    var jsonData = JSON.stringify({
        name: data
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/SaveReserveSchedule",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessSave,
        error: OnErrorCall_
    });
}
function OnSuccessSave(response) {
    alert("YOur request has been saved.");
    $("#sec_box").load("window/p-course/003-1.html");
}