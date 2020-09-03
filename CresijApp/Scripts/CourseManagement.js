$ = jQuery.noConflict();
console.log("course management ");
$(document).ready(function () {
    var jsonData = JSON.stringify({
        name: ""
    });
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
    $('.searchfilter').off("click").on("click", function () {
        var userid = sessionStorage.getItem("LoginId");
        var adata = [];
        adata[0] = $('input[name = "ScheduleDate"]').val();
        if (isNaN(Date.parse(adata[0]))) {
            adata[0] = $('#selectedbuilding').val();
            adata[1] = $('#semesterlist').val();
            adata[2] = $('#weeklist').val();
            adata[3] = $('#dayslist').val();
            adata[4] = userid;
            if (!(adata[0] == null || adata[0] == undefined || adata[0].length == 0) &&
                !(adata[1] == null || adata[1] == undefined || adata[1].length == 0) &&
                !(adata[2] == null || adata[2] == undefined || adata[2].length == 0) &&
                !(adata[2] == null || adata[2] == undefined || adata[2].length == 0)) {
                var info = [];
                info.push(adata[0]);
                info.push(adata[1]);
                info.push(adata[2]);
                info.push(adata[3]);
                info.push(userid);
                var jsonData = JSON.stringify({
                    name: info
                });
                $.ajax({
                    type: "POST",
                    url: "../Services/ScheduleData.asmx/GetTransferScheduleByBuildSemDay", // Get schedule for selected building and sem.
                    data: jsonData,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess_,
                    error: OnErrorCall_
                });
            }
            else {
                alert("please select proper options to get the information");
            }
        }
        else {
            adata[0] = $('#selectedbuilding').val();
            adata[1] = $('input[name = "ScheduleDate"]').val();
            if (!(adata[0] == null || adata[0] == undefined || adata[0].length == 0) &&
                !(adata[1] == null || adata[1] == undefined || adata[1].length == 0)) {
                if (!isNaN(Date.parse(adata[1])) && adata[1].length == 10) {
                    var info = [];
                    info.push(adata[0]);
                    info.push(adata[1]);
                    info.push(userid);
                    var jsonData = JSON.stringify({
                        name: info
                    });
                    $.ajax({
                        type: "POST",
                        url: "../Services/ScheduleData.asmx/GetScheduleForTransferByDate",
                        data: jsonData,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: OnSuccess_,
                        error: OnErrorCall_
                    });

                    var date = new Date(adata[1]);
                    var today = new Date(date.getFullYear(), date.getMonth(), date.getDate());
                    $('.datetimepicker').datepicker('setDate', today);
                }

            }

            else {
                alert("please select proper options to get the information");
            }

        }
        $("#selectdatediv").attr("style", "pointer-events:auto");

        $("#weeklist").attr("style", "pointer-events:auto");
        $("#dayslist").attr("style", "pointer-events:auto");
        $("#semdiv").attr("style", "pointer-events:auto");
        console.log("search button clicked");
       
    });

    $('#weeklist').on("change", function () {
        console.log("week change event");

        $("#selectdatediv").attr("style", "pointer-events:none");
        $('.datetimepicker').datepicker('setDate', "");
    });

    $('#selectdatediv').on("click", function () {
        console.log("date change event");

        $("#weeklist").attr("style", "pointer-events:none");
        $("#dayslist").attr("style", "pointer-events:none");
        $("#semdiv").attr("style", "pointer-events:none");

    })

});
function OnSuccessWeekNum(respo) {
    var data = respo.d;
    var inner = [];
    for (i = 1; i <= data[0]; i++) {
        inner += '<option class="option" value="' + i + '">' + i + '</option>';
    }
    document.getElementById("weeklist").innerHTML = inner;
}
function OnSuccessBuilding(response) {
    var data = response.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
        inner += '<option class="option" value="' + data[i] + '">' + data[i] + '</option>';
    }
    document.getElementById("selectedbuilding").innerHTML = inner;

    var building = $('#selectedbuilding option:selected').text();
   
    getSchedule(building);
   
}
function getSchedule(building) {
    var info = [];
    info.push(building);
    info.push($('input[name = "ScheduleDate"]').val());
    var userid = sessionStorage.getItem("LoginId");
    info.push(userid);
    var jsonData = JSON.stringify({
        name: info
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetScheduleForTransfer",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
}
function OnSuccess_(response) {
    var idata = response.d;
    FillSchedule(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
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
function FillSchedule(data1) {
    $("#scheduletable tr:gt(0)").remove();
    console.log("get sc");
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
                var d, classcolor, datatype, course;
                if (data[1].indexOf(":") != -1) {
                    d = data[1].split(":")[0];
                    course = data[1].split(":")[2];
                    if (data[1].indexOf('reserve') != -1)
                        datatype = 'reserve';
                    else if (data[1].indexOf('transfer') != -1)
                        datatype = 'transfer';
                    else datatype = "";
                    classcolor = setcolor(data[1]);
                }
                else {
                    d = data[1];
                    course = "";
                    classcolor = blue;
                }
                column1.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html?index='
                    + d + '&' + datatype +' " j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div>';
                column2.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL " j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype  +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column1.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box">' +
                    '<i class="fa fa-exchange"></i> 调课</a></div> ';
                column2.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            
            var column3 = row.insertCell(3);
            var column4 = row.insertCell(4);
            if (data[3] != " ") {
                var d, classcolor, datatype;
                if (data[3].indexOf(":") != -1) {
                    d = data[3].split(":")[0];
                    course = data[3].split(":")[2];
                    if (data[3].indexOf('reserve') != -1)
                        datatype = 'reserve';
                    else if (data[3].indexOf('transfer') != -1)
                        datatype = 'transfer';
                    else datatype = "";
                    classcolor = setcolor(data[3]);
                }
                else {
                    d = data[3];
                    course = "";
                    classcolor = blue;
                }
                column3.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column4.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column3.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column4.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            
            var column5 = row.insertCell(5);
            var column6 = row.insertCell(6);
            if (data[5] != " ") {
                var d, classcolor, datatype;
                if (data[5].indexOf(":") != -1) {
                    d = data[5].split(":")[0];
                    course = data[5].split(":")[2];
                    if (data[5].indexOf('reserve') != -1)
                        datatype = 'reserve';
                    else if (data[5].indexOf('transfer') != -1)
                        datatype = 'transfer';
                    else datatype = "";
                    classcolor = setcolor(data[5]);
                }
                else {
                    d = data[5];
                    course = "";
                    classcolor = blue;
                }
                column5.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column6.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column5.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column6.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            
            var column7 = row.insertCell(7);
            var column8 = row.insertCell(8);
            if (data[7] != " ") {
                var d, classcolor, datatype;
                if (data[7].indexOf(":") != -1) {
                    d = data[7].split(":")[0];
                    course = data[7].split(":")[2];
                    if (data[7].indexOf('reserve') != -1)
                        datatype = 'reserve';
                    else if (data[7].indexOf('transfer') != -1)
                        datatype = 'transfer';
                    else datatype = "";
                    classcolor = setcolor(data[7]);
                }
                else {
                    d = data[7];
                    course = "";
                    classcolor = blue;
                }
                column7.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column8.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column7.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column8.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
                        
            var column9 = row.insertCell(9);
            var column10 = row.insertCell(10);
            if (data[9] != " ") {
                var d, classcolor, datatype;
                if (data[9].indexOf(":") != -1) {
                    d = data[9].split(":")[0];
                    course = data[9].split(":")[2];
                    if (data[9].indexOf('reserve') != -1)
                        datatype = 'reserve';
                    else if (data[9].indexOf('transfer') != -1)
                        datatype = 'transfer';
                    else datatype = "";
                    classcolor = setcolor(data[9]);
                }
                else {
                    d = data[9];
                    course = "";
                    classcolor = blue;
                }
                column9.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column10.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column9.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column10.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column11 = row.insertCell(11);
            var column12 = row.insertCell(12);
            if (data[11] != " ") {
                var d, classcolor, datatype;
                if (data[11].indexOf(":") != -1) {
                    d = data[11].split(":")[0];
                    course = data[11].split(":")[2];
                    if (data[11].indexOf('reserve') != -1)
                        datatype = 'reserve';
                    else if (data[11].indexOf('transfer') != -1)
                        datatype = 'transfer';
                    else datatype = "";
                    classcolor = setcolor(data[11]);
                }
                else {
                    d = data[11];
                    course = "";
                    classcolor = blue;
                }
                column11.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column12.innerHTML = '<div class="coursebox ' + classcolor + ' tk">' + course + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + d + '&' + datatype +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column11.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
                column12.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            
            $("#scheduletable").find('tbody').append($(row));
        }
    }
}

