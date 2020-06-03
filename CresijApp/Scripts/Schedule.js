$ = jQuery.noConflict();
console.log("schedule page");

$(function () {

    var jsonData = JSON.stringify({
        name: ""
    });
    //$.ajax({
    //    type: "POST",
    //    url: "../Services/ScheduleData.asmx/GetSchedule",
    //    data: jsonData,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: OnSuccess_,
    //    error: OnErrorCall_
    //});
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCall_
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetTotalWeek",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessWeekNum,
        error: OnErrorCall_
    });
});

function OnSuccessWeekNum(respo) {
    var data = respo.d;
    var inner = [];
    for (i = 1; i <= data[0]; i++) {
        inner += '<div class="option"><input type="radio" name="weeklist" value= "' + i + '"><label>' + i + '</label></div>';
    }
    document.getElementById("weeklist").innerHTML = inner;
}
function OnSuccessBuilding(respo) {
    var data = respo.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
        inner += '<option class="option" value="' + data[i] + '">' + data[i] + '</option>';
    }
    document.getElementById("selectedbuilding").innerHTML = inner;

    var building = $('#selectedbuilding option:selected').text();
    var dd = $('input[name = "ScheduleDate"]').val();
    getSchedule(dd, building);
}

function OnSuccess_(response) {
    var idata = response.d;
    console.log("success schedule");
    FillSchedule(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}

function FillSchedule(data1) {

    $("#scheduletable tr:gt(0)").remove();
    if (data1.length > 0) {
        for (i = 0; i < data1.length; i++) {
            var data = data1[i];
            var blue = "state1";
            var row = document.createElement("tr");
            var column = row.insertCell(0);
            column.innerText = data[0];
            column.classList = "text-center";
            var column1 = row.insertCell(1);
            var column2 = row.insertCell(2);
            if (data[1] != " ") {
                var d, classcolor;
                if (data[1].indexOf(":") != -1) {
                    d = data[1].split(":")[0];
                    classcolor = setcolor(data[1]);
                }
                else {
                    d = data[1];
                    classcolor = blue;
                }

                column1.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column2.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }
            else {
                column1.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column2.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }

            var column3 = row.insertCell(3);
            var column4 = row.insertCell(4);
            if (data[3] != " ") {
                var d, classcolor;
                if (data[3].indexOf(":") != -1) {
                    d = data[3].split(":")[0];
                    classcolor = setcolor(data[3]);
                }
                else {
                    d = data[3];
                    classcolor = blue;
                }
                column3.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column4.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }
            else {
                column3.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column4.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }

            var column5 = row.insertCell(5);
            var column6 = row.insertCell(6);
            if (data[5] != " ") {
                var d, classcolor;
                if (data[5].indexOf(":") != -1) {
                    d = data[5].split(":")[0];
                    classcolor = setcolor(data[5]);
                }
                else {
                    d = data[5];
                    classcolor = blue;
                }
                column5.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column6.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';

            }
            else {
                column5.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column6.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }

            var column7 = row.insertCell(7);
            var column8 = row.insertCell(8);
            if (data[7] != " ") {
                var d, classcolor;
                if (data[7].indexOf(":") != -1) {
                    d = data[7].split(":")[0];
                    classcolor = setcolor(data[7]);
                }
                else {
                    d = data[7];
                    classcolor = blue;
                }
                column7.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column8.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }
            else {
                column7.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column8.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }

            var column9 = row.insertCell(9);
            var column10 = row.insertCell(10);
            if (data[9] != " ") {
                var d, classcolor;
                if (data[9].indexOf(":") != -1) {
                    d = data[9].split(":")[0];
                    classcolor = setcolor(data[9]);
                }
                else {
                    d = data[9];
                    classcolor = blue;
                }
                column9.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column10.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }
            else {
                column9.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column10.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }

            var column11 = row.insertCell(11);
            var column12 = row.insertCell(12);
            if (data[11] != " ") {
                var d, classcolor;
                if (data[11].indexOf(":") != -1) {
                    d = data[11].split(":")[0];
                    classcolor = setcolor(data[11]);
                }
                else {
                    d = data[11];
                    classcolor = blue;
                }
                column11.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column12.innerHTML = '<div class="coursebox ' + classcolor + '">' + d + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }
            else {
                column11.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
                column12.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div>';
            }

            $("#scheduletable").find('tbody').append($(row));
        }
    }
}

function setcolor(data) {
    if (data.indexOf('reserve') != -1) {
        if (data.indexOf('Pending') != -1) {
            colorclass = "state7";
        }
        else {
            colorclass = "state4";
        }
    }
    else if (data.indexOf('transfer') != -1) {
        if (data.indexOf('pending') != -1) {
            colorclass = "state9";
        }
        else {
            colorclass = "state2";
        }
    }
    else {
        colorclass = "state1";
    }
    return colorclass;

}

$('input[name = "buildinglist"]').off("change").on("change", function () {
    var adata = [];
    adata[1] = $('#buildingname').text();
    adata[0] = $('input[name = "appointmentDate"]').val();
    getSchedule(adata[0], adata[1]);

});
//function handleClick(mybuilding) {
//    console.log(mybuilding.value);
//}
function brd() {
    alert($('[name="buildinglist"]:checked').val());
}

$('.searchfilter').off("click").on("click", function () {
    var info = []
    var adata = [];
    adata[0] = $('#selectedbuilding').val();
    adata[2] = $('input[name = "ScheduleDate"]').val();
    adata[1] = $('input[name = "semesterlist"]:checked').val();
    console.log("date value " + !isNaN(Date.parse(adata[2])) + " length " + adata[2].length);
    if (isNaN(Date.parse(adata[2]))) {
        adata[2] = $('input[name = "weeklist"]:checked').val();
    } else {
    
}
    if (adata[0] == undefined && adata[1] == undefined && adata[2] == undefined) {
        alert("please select proper options to get the information");
    }
    else {

        console.log(Date.parse(adata[2]) + " parse date");
        if (!(adata[0] == null || adata[0] == undefined || adata[0].length == 0) &&
            !(adata[1] == null || adata[1] == undefined || adata[1].length == 0)) {
            if (!isNaN(Date.parse(adata[2])) && adata[2].length==10) {
                var info = [];
                info.push(adata[2]);
                info.push(adata[0]);
                var jsonData = JSON.stringify({
                    name: info
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetClassesByDateAndBuilding", // Get schedule for selected building with date and sem.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
            else if (!(adata[2] == null || adata[2] == undefined || adata[2].length == 0)) {
                var jsonData = JSON.stringify({
                    name: adata
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetScheduleByBuildWeekSem", // Get schedule for selected building with week and sem.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
            else {
                var info = [];
                info.push(adata[0]);
                info.push(adata[1]);
                var jsonData = JSON.stringify({
                    name: info
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetScheduleByBuildSem", // Get schedule for selected building and sem.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
        }

        else if (!(adata[0] == null || adata[0] == undefined || adata[0].length == 0)) {
            if (!isNaN(Date.parse(adata[2]))) {
                var info = [];
                info.push(adata[2]);
                info.push(adata[0]);
                var jsonData = JSON.stringify({
                    name: info
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetClassesByDateAndBuilding", // Get schedule for selected building with date.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
            else if (!(adata[2] == null || adata[2] == undefined || adata[2].length == 0)) {
                alert("please select semester with week to get the information");
            }
            else {
                var info = [];
                info.push(adata[0]);

                var jsonData = JSON.stringify({
                    name: info
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetScheduleByBuild", // Get schedule for selected building.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
        }
        else if (!(adata[1] == null || adata[1] == undefined || adata[1].length == 0)) {
            if (!isNaN(Date.parse(adata[2]))) {
                var info = [];
                info.push(adata[1]);
                info.push(adata[2]);
                var jsonData = JSON.stringify({
                    name: info
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetScheduleByDate", // Get schedule for selecteddate and sem.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
            else if (!(adata[2] == null || adata[2] == undefined || adata[2].length == 0)) {
                var info = [];
                info.push(adata[1]);
                info.push(adata[2]);
                var jsonData = JSON.stringify({
                    name: info
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetScheduleByWeekSem", // Get schedule for selected week and sem.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
            else {
                var info = [];
                info.push(adata[1]);

                var jsonData = JSON.stringify({
                    name: info
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetScheduleBySem", // Get schedule for selected building and sem.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }

        }
        else {
            if (!isNaN(Date.parse(adata[2]))) {
                var jsonData = JSON.stringify({
                    date: adata[2]
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetScheduleForDate", // Get schedule for selected building with date
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
            else if (!(adata[2] == null || adata[2] == undefined || adata[2].length == 0)) {
                alert("please select semester with week to get the information");
            }

        }
    }
    //var jsonData = JSON.stringify({
    //    name: adata
    //});
    //$.ajax({
    //    type: "POST",
    //    url: "../Services/ScheduleData.asmx/GetScheduleByFilter",
    //    data: jsonData,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: OnSuccess_,
    //    error: OnErrorCall_
    //});


});

function getSchedule(date, building) {
    var data = [];
    data[0] = date;
    data[1] = building;
    var jsonData = JSON.stringify({
        name: data
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetClassesByDateAndBuilding",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
}