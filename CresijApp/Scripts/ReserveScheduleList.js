

$ = jQuery.noConflict();
$(function GetOrgData() {
    
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetReserveSchedule",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
});
function OnSuccess_(response) {
    var idata = response.d;
    FillReserveData(idata);
}
function OnErrorCall_(respo) {
    console.log(respo);
}
function FillReserveData(idata) {
    $("#table_reserveList tr:gt(0)").remove();
    console.log("got user data ");
    var rowshtml = [];
    for (i = 0; i < idata.length; i++) {
        var col = idata[i];
        switch (col[6]) {
            case "Pending":
                c = "tr_bg_alert";
                statusclass = "orange";
                break;
            case "Approved":
                c = "tr_bg_suc";
                statusclass = "green";
                break;
            case "Expired":
                c = "tr_bg_disable";
                statusclass = "gray";
                break;
            case "Rejected":
                c = "tr_bg_danger";
                statusclass = "red";
                break;
        }
        var j = i + 1;
        rowshtml += '<tr class="bbwhite tr_bg_alert">' +
            '<td style="width:50px; text-align:center;"><input type="checkbox" name="tiaoke"></td>' +
            '<td>' + j + '</td><td>' + col[0] + '教室预约</td>' +
            '<td>' + col[1] + '</td><td>' + col[2] + '</td>' +
            '<td>' + col[3] + '</td><td>' + col[4] + '</td>' +
            '<td>' + col[5] + '</td><td class="' + statusclass + '">' + col[6] + '</td>' +
            '<td style="display:none">' + col[7] + '</td>' +   
            '<td style="display:none">' + col[8] + '</td>' +
            '<td style="display:none">' + col[9] + '</td>' +
            '<td style="display:none">' + col[10] + '</td>' +
            '<td style="display:none">' + col[11] + '</td>' +
            '<td style="display:none">' + col[12] + '</td>' +
            '<td style="display:none">' + col[13] + '</td>' +
            '<td style="display:none">' + col[14] + '</td>' +
            '<td style="display:none">' + col[15] + '</td>' +
            '<td style="display:none">' + col[0] + '</td>' +
            '<td><a name="viewdetails"' +
                'class="jbtn_xs btn_blue vis taskmodal"><i class="fa fa-eye"></i> 查看</a></td></tr>';
    }
    $("#table_reserveList").find('tbody').append(rowshtml);
}

$(document).off("click").on("click", ".taskmodal", function () {
    console.log("finish...");
    var _this = this;

    let rowitem = $(_this).parents("tr");
    console.log(rowitem.find("td:eq(2)").html());
    console.log(rowitem.find("td:eq(3)").text());
    $("#schoolyeardisc").html(rowitem.find("td:eq(10)").html());
    $("#semesterdisc").html(rowitem.find("td:eq(11)").html());
    $("#daydisc").html(rowitem.find("td:eq(3)").html());
    $("#sectiondisc").html(rowitem.find("td:eq(6)").html());
    $("#weekdisc").html(rowitem.find("td:eq(12)").html());
    $("#datedisc").html(rowitem.find("td:eq(3)").html());
    $("#classdisc").html(rowitem.find("td:eq(5)").html());
    $("#unitdisc").html(rowitem.find("td:eq(13)").html());
    $("#phonedisc").html(rowitem.find("td:eq(14)").html());
    $("#namedisc").html(rowitem.find("td:eq(4)").html());
    $("#personiddisc").html(rowitem.find("td:eq(18)").html());
    $("#mobiledisc").html(rowitem.find("td:eq(15)").html());
    $("#purposedisc").html(rowitem.find("td:eq(7)").html());
    $("#reasondisc").html(rowitem.find("td:eq(16)").html());
    $("#equipdisc").html(rowitem.find("td:eq(17)").html());
    $("#iddisc").html(rowitem.find("td:eq(9)").html());
    
    //$(".taskmodal:visible tr:eq(1) td:eq(1)").html(">>" + rowitem.find("td:eq(1)").text());

    document.getElementById('taskmodal').style.display = 'block';
})

function savenewstat() {

    SaveCurrentStatus("Approved", $("#iddisc").text());
    console.log("save func worked");
    document.getElementById('taskmodal').style.display = 'none';
}
function Rejectnewstat() {
    SaveCurrentStatus("Rejected", $("#iddisc").text());
    console.log("Reject func worked");
    document.getElementById('taskmodal').style.display = 'none';
}

function SaveCurrentStatus(stat, id) {
    var a = [];
    a[0] = stat;
    a[1] = id;
    var jsonData = JSON.stringify({
        name: a
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/ChangeReserveStatus",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessStatus,
        error: OnErrorCallStatus
    });
}
function OnSuccessStatus(respo) {
    alert("successfully saved");
    $("#sec_box").load("window/p-course/003-2.html");
}
function OnErrorCallStatus(respo) {
    console.log(respo);
}