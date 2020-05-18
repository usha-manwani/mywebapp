$ = jQuery.noConflict();
console.log("schedule page");
//$(function () {

//    var date = new Date();
//    var d = date.getDate();
//    var m = date.getMonth() + 1; //Month from 0 to 11
//    var y = date.getFullYear();
//    var dd= '' + y + '-' + (m <= 9 ? '0' + m : m) + '-' + (d <= 9 ? '0' + d : d);
      
//    var jsonData = JSON.stringify({
//        date: dd
//    });
//    $.ajax({
//        type: "POST",
//        url: "../Services/ScheduleData.asmx/GetScheduleForDate",
//        data: jsonData,
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: OnSuccess_,
//        error: OnErrorCall_
//    });
//});

function OnSuccess_(response) {
    var idata = response.d;
    console.log("success schedule");
    FillSchedule(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}

function FillSchedule(data1) {
    
    date = $('input[name = "appointmentDate"]').val();
    $("#scheduletable tr:gt(0)").remove();
    if (data1.length > 0) {
        for (i = 0; i < data1.length; i++) {
            var data = data1[i];
            var row = document.createElement("tr");
            var column = row.insertCell(0);
            column.innerText = data[0];
            column.classList = "text-center";
            var column1 = row.insertCell(1);
            
            if (data[1] != " ") {
                column1.innerHTML = '<div class="coursebox state1">' + data[1] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column1.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=1,2&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column2 = row.insertCell(2);

            if (data[1] != " ") {
                column2.innerHTML = '<div class="coursebox state2">' + data[1] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column2.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=1,2&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column3 = row.insertCell(3);

            if (data[3] != " ") {
                column3.innerHTML = '<div class="coursebox state1">' + data[3] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column3.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=3,4&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column4 = row.insertCell(4);

            if (data[3] != " ") {
                column4.innerHTML = '<div class="coursebox state2">' + data[3] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column4.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=3,4&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column5 = row.insertCell(5);

            if (data[5] != " ") {
                column5.innerHTML = '<div class="coursebox state2">' + data[5] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column5.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=5,6&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column6 = row.insertCell(6);

            if (data[5] != " ") {
                column6.innerHTML = '<div class="coursebox state1">' + data[5] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column6.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=5,6&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column7 = row.insertCell(7);

            if (data[7] != " ") {
                column7.innerHTML = '<div class="coursebox state2">' + data[7] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column7.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=7,8&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column8 = row.insertCell(8);
            if (data[7] != " ") {
                column8.innerHTML = '<div class="coursebox state1">' + data[7] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column8.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=7,8&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column9 = row.insertCell(9);
            if (data[9] != " ") {
                column9.innerHTML = '<div class="coursebox state1">' + data[9] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column9.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=9,10&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column10 = row.insertCell(10);
            if (data[9] != " ") {
                column10.innerHTML = '<div class="coursebox state1">' + data[9] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column10.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=9,10&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column11 = row.insertCell(11);

            if (data[11] != " ") {
                column11.innerHTML = '<div class="coursebox state1">' + data[11] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column11.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=11,12&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }
            var column12 = row.insertCell(12);

            if (data[11] != " ") {
                column12.innerHTML = '<div class="coursebox state1">' + data[11] + '<span class="intro">课</span>' +
                    '<a class="action" data-toggle="modal" datatarget="#tk_modal"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column12.innerHTML = '<div class="coursebox state3 JURL" j-page-href="window/p-course/003-1-1.html?section=11,12&class=' + data[0] + '" j-page-box="#sec_box">' +
                    '宋青书<span class="intro">可预约</span></div >';
            }

            $("#scheduletable").find('tbody').append($(row));
        }
    }
   
}

$(function () {
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCall
    });
})

function OnSuccessBuilding(respo) {
    var data = respo.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
        inner += '<option class="option" value="' + data[i] + '">' + data[i] + '</option>';
    }
    document.getElementById("selectedbuilding").innerHTML = inner;
    
    var building = $('#selectedbuilding option:selected').text();
    var dd = $('input[name = "appointmentDate"]').val();
    getSchedule(dd, building);
    //var date = new Date();
    //var d = date.getDate();
    //var m = date.getMonth() + 1; //Month from 0 to 11
    //var y = date.getFullYear();    
    //var dd = '' + y + '-' + (m <= 9 ? '0' + m : m) + '-' + (d <= 9 ? '0' + d : d);
    
}

$("#selectedbuilding").off("change").on("change", function () {
    var adata = [];
    
    adata[1] = $('#selectedbuilding option:selected').text();
    adata[0] = $('input[name = "appointmentDate"]').val();
    getSchedule(adata[0], adata[1]);

});

$('input[name = "appointmentDate"]').off("input").on("input",function () {
    var adata = [];
    adata[1] = $('#selectedbuilding option:selected').text();
    adata[0] = $('input[name = "appointmentDate"]').val();
    getSchedule(adata[0], adata[1]);
});

function OnSuccessClass(response) {
    var idata = response.d;
    console.log("success schedule");
    FillSchedule(idata);
}

function OnErrorCall(respo) {
    console.log(respo);
}

function getSchedule(date,building) {
    var data = [];
    data[0] = date;
    data[1] = building;
    var jsonData = JSON.stringify({
        name:data
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



