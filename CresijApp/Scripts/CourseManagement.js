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
function FillSchedule(idata) {
    var scheduledata = data[0];
    var day = data[1];
    var classname = data[2];
    $("#scheduletable tr:gt(0)").remove();
    if (classname.length > 0) {

    }

    var tabhtml = '<tr><td class="text-center">601</td><td><div class="coursebox state0">' +
        '大学英语①<span class="intro">课</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state1 tk">大学英语①<span class="intro">课</span>' +
        // <--IMPORTANT: class = tk means right bottom button could be actived -->
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state2 tk ">大学英语①<span class="intro">调</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state3 tk">大学英语①<span class="intro">可预约</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state4 tk">大学英语①<span class="intro">已预约</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state0">大学英语①<span class="intro">课</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state0">大学英语①<span class="intro">课</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state0">大学英语①<span class="intro">课</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state0">大学英语①<span class="intro">课</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td><td><div class="coursebox state0">大学英语①<span class="intro">课</span>' +
        '<a class="action JURL" j-page-href="window/p-course/002-1-1.html" j-page-box="#sec_box"><i class="fa fa-exchange"></i> 调课</a>' +
        '</div></td></tr>';
}

