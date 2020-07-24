$ = jQuery.noConflict();
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetTransferedSchedule",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    $(document).off("click").on("click", ".taskmodal", function () {
        console.log("finish...");

        var _this = this;

        let rowitem = $(_this).parents("tr");
        if (rowitem.find("td:eq(6)").html() != "pending") {
            $("#savesuccess").attr("onclick", "");
            $("#rejectapplication").attr("onclick", "");
        }

        $("#coursename").html(rowitem.find("td:eq(8)").html());
        $("#class").html(rowitem.find("td:eq(2)").html());
        $("#time").html(rowitem.find("td:eq(3)").html());
        $("#teacher").html(rowitem.find("td:eq(4)").html());
        $("#reason").html(rowitem.find("td:eq(7)").html());
        $("#scheduleid").html(rowitem.find("td:eq(9)").html());

        //$(".taskmodal:visible tr:eq(1) td:eq(1)").html(">>" + rowitem.find("td:eq(1)").text());

        document.getElementById('taskmodal').style.display = 'block';


    })
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
    $("#pendingSchedule tr:gt(0)").remove();
    var innerhtm = [];
    for (i = 0; i < idata.length; i++) {
        var j = i + 1;
        var c = "", statusclass="";
        var data = idata[i];
        var oldtime = data[2].split(',');
        var newtime = data[3].split(',');
        switch (data[7]) {
            case "pending":
                c = "tr_bg_alert";
                statusclass = "orange";
                break;
            case "approved":
                c = "tr_bg_suc";
                statusclass = "green";
                break;
            case "expired":
                c = "tr_bg_disable";
                statusclass = "gray";
                break;
            case "rejected":
                c = "tr_bg_danger";
                statusclass = "red";
                break;
        }
        innerhtm += '<tr class="bbwhite '+c+'">' +
            '<td style="width:50px; text-align:center;"><input type="checkbox" name="tiaoke"></td>' +
            '<td>' + j + '</td><td>' + data[0] + ' <i class="fa fa-arrow-circle-right gray"></i> ' + data[1] + '</td>' +
            '<td>week' + oldtime[0] + ', ' + oldtime[1] + ', ' + oldtime[2] +
            '节'+' <i class="fa fa-arrow-circle-right gray"></i>week' + newtime[0] + ', ' + newtime[1] + ', ' + newtime[2] + '节'+'</td>' +
            '<td>' + data[4] + '<i class="fa fa-arrow-circle-right gray"></i> ' + data[5] + '</td>' +
            '<td>多媒体教室</td>' + '<td class="' + statusclass + '">' + data[7] + '</td><td style="display:none">' + data[8] + '</td>' +
            '<td style="display:none">' + data[9] + '</td>' + '<td style="display:none">' + data[10] + '</td>'+
            '<td><a name="viewdetails"'+
            'class="jbtn_xs btn_blue vis taskmodal"><i class="fa fa-eye"></i> 查看</a></td></tr>';
    }

    $("#pendingSchedule").find('tbody').append(innerhtm);
}



function savenewstat() {

    SaveCurrentStatus("approved", $("#scheduleid").text());
    console.log("save func worked");
    document.getElementById('taskmodal').style.display = 'none';
}
function Rejectnewstat() {
    SaveCurrentStatus("rejected", $("#scheduleid").text());
    console.log("Reject func worked");
    document.getElementById('taskmodal').style.display = 'none';
}

function SaveCurrentStatus(stat, id) {
    var a=[];
    a[0] = stat;
    a[1] = id;
    var jsonData = JSON.stringify({
        name: a
    });
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/SaveScheduleStatus",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessStatus,
        error: OnErrorCallStatus
    });
}
function OnSuccessStatus(respo) {
    alert("successfully saved");
    $("#sec_box").load("window/p-course/002-2.html");
}
function OnErrorCallStatus(respo) {
    console.log(respo);
}