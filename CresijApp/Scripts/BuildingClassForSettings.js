$(function () {
    console.log("system setting config page");
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCall_
    });
    
});

function OnErrorCall_(respo) {
    console.log(respo);
    console.log(respo.d);
}
function OnSuccessBuilding(response) {
    var data = response.d;
    $("#buildingtable tr:gt(0)").remove();
    for (i = 0; i < data.length; i++) {
        var dd = data[i];
        console.log(dd);
        var jsonData = JSON.stringify({
            building: dd[0]
        });
        $.ajax({
            type: "POST",
            url: "../Services/GetSetSystemConfigInfo.asmx/GetFloorClassByBuilding",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessFloorClassroom,
            error: OnErrorCall_
        });
    }
}
function OnSuccessFloorClassroom(response) {
    var data = response.d;
    var html = [];
    if (data.length > 1) {
        html += '<tr><td class="th-1"><i class="ROOM_CTRL fa fa-minus-circle"></i><b><i class="fa fa-check jcheckbox check_all_tr"></i> ' + data[0] + '</b></td>' +
            '<td><table class="jroom_box" style="display:block;">';
        for (i = 1; i < data.length; i++) {
            var data1 = data[i];
            var classnames = data1[1].split(',');
            html += '<tr><td class="th-2"><b><i class="fa fa-check jcheckbox check_all_td"></i> ' + data1[0] + '</b></td><td>';
            for (j = 0; j < classnames.length; j++) {
                html += '<span><label><input type="checkbox" name="classlist"><i class="fa fa-check jcheckbox"></i> ' + classnames[j] + '</label></span>';
            }
            html += '</td></tr>';
        }
        html += '</table></td></tr>';

        $("#buildingtable").append(html);
    }

}