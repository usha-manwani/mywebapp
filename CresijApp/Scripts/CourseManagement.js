$ = jQuery.noConflict();
$(function () {
    var jsonData = JSON.stringify({
        name: ""
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetSchedule",
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

function FillSchedule(data1) {
    $("#scheduletable tr:gt(0)").remove();
    console.log("get sc");
    if (data1.length > 0) {
        for (i = 0; i < data1.length; i++) {
            var data = data1[i];
            var row = document.createElement("tr");
            var column = row.insertCell(0);
            column.innerText = data[0];
            column.classList = "text-center";
            var column1 = row.insertCell(1);
           
            if (data[1] != " ") {                              
                column1.innerHTML = '<div class="coursebox state1 tk">' + data[1] + '<span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html?index='
                    + data[0].replace(" ", "%20") + '&' + data[1].replace(" ", "%20") +
                    '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div>';
            }
            else {
                column1.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box">'+
                    '<i class="fa fa-exchange"></i> 调课</a></div> ';
            }
            var column2 = row.insertCell(2);

            if (data[2] != " ") {
                column2.innerHTML = '<div class="coursebox state2 tk">' + data[2] + '<span class="intro">课</span>' +
                    '<a class="action JURL " j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[2].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column2.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column3 = row.insertCell(3);

            if (data[3] != " ") {
                
                column3.innerHTML = '<div class="coursebox state1 tk">' + data[3] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[3].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column3.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column4 = row.insertCell(4);

            if (data[4] != " ") {
                column4.innerHTML = '<div class="coursebox state2 tk">' + data[4] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[4].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column4.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column5 = row.insertCell(5);

            if (data[5] != " ") {
                
                column5.innerHTML = '<div class="coursebox state2 tk">' + data[5] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[5].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column5.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column6 = row.insertCell(6);

            if (data[6] != " ") {
                column6.innerHTML = '<div class="coursebox state1 tk">' + data[6] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[6].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column6.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column7 = row.insertCell(7);

            if (data[7] != " ") {
                column7.innerHTML = '<div class="coursebox state2 tk">' + data[7] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[7].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column7.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column8 = row.insertCell(8);
            if (data[8] != " ") {
                column8.innerHTML = '<div class="coursebox state1 tk">' + data[8] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[8].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column8.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column9 = row.insertCell(9);
            if (data[9] != " ") {
                column9.innerHTML = '<div class="coursebox state1 tk">' + data[9] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[9].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column9.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column10 = row.insertCell(10);
            if (data[10] != " ") {
                column10.innerHTML = '<div class="coursebox state1 tk">' + data[10] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[10].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column10.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column11 = row.insertCell(11);

            if (data[11] != " ") {
                column11.innerHTML = '<div class="coursebox state1 tk">' + data[11] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[11].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column11.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            var column12 = row.insertCell(12);

            if (data[12] != " ") {
                column12.innerHTML = '<div class="coursebox state1 tk">' + data[12] + '<span class="intro">课</span>' +
                    '<a class="action JURL disp" j-page-href="window/p-course/002-1-1.html?index=' + data[0].replace(" ", "%20") +
                    '&' + data[12].replace(" ", "%20") + '" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }
            else {
                column12.innerHTML = '<div class="coursebox state0"><span class="intro">课</span>' +
                    '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a></div >';
            }

            $("#scheduletable").find('tbody').append($(row));
        }
    }
}

