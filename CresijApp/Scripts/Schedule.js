$ = jQuery.noConflict();
$(function () {
    var jsonData = JSON.stringify({
        name: ""
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetCourse",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
});

function OnSuccess_(response) {
    var idata = response.d;
    FillSchedule(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}

function FillSchedule(data) {
    var scheduledata = data[2];
    var day = data[0];
    var classname = data[1];
    $("#scheduletable tr:gt(0)").remove();
    if (classname.length > 0) {
        for (i = 0; i < classname.length; i++) {
            var row = document.createElement("tr");
            var column = row.insertCell(0);
            column.innerText = classname[i];
            column.classList = "text-center";
            var column1 = row.insertCell(1);

            if (day[i] == 1) {
                column1.innerHTML = '<div class="coursebox state1">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column1.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column2 = row.insertCell(2);

            if (day[i] == 2) {
                column2.innerHTML = '<div class="coursebox state2">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column2.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column3 = row.insertCell(3);

            if (day[i] == 3) {
                column3.innerHTML = '<div class="coursebox state1">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column3.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column4 = row.insertCell(4);

            if (day[i] == 4) {
                column4.innerHTML = '<div class="coursebox state2">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column4.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column5 = row.insertCell(5);

            if (day[i] == 5) {
                column5.innerHTML = '<div class="coursebox state2">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column5.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column6 = row.insertCell(6);

            if (day[i] == 6) {
                column6.innerHTML = '<div class="coursebox state1">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column6.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column7 = row.insertCell(7);

            if (day[i] == 7) {
                column7.innerHTML = '<div class="coursebox state2">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column7.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column8 = row.insertCell(8);
            if (day[i] == 8) {
                column8.innerHTML = '<div class="coursebox state1">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column8.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column9 = row.insertCell(9);
            if (day[i] == 9) {
                column9.innerHTML = '<div class="coursebox state1">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column9.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column10 = row.insertCell(10);
            if (day[i] == 10) {
                column10.innerHTML = '<div class="coursebox state1">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column10.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column11 = row.insertCell(11);

            if (day[i] == 11) {
                column11.innerHTML = '<div class="coursebox state1">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column11.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column12 = row.insertCell(12);

            if (day[i] == 12) {
                column12.innerHTML = '<div class="coursebox state1">' + scheduledata[i] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column12.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }

            $("#scheduletable").find('tbody').append($(row));
        }
    }
}

