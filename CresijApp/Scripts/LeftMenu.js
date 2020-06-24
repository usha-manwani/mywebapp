$(function () {
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCall_
    });
})

function OnSuccessBuilding(respo) {
    var data = respo.d;
    for (i = 0; i < data.length; i++) {
        var d = data[i];
        var jsonData = JSON.stringify({
            building: d[0]
        });
        $.ajax({
            type: "POST",
            url: "../Services/GetSetSystemConfigInfo.asmx/GetFloorClassByBuilding",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessClass,
            error: OnErrorCall_
        });
    }

}
function OnErrorCall_(respo) {
    console.log(respo);
}

function OnSuccessClass(respo) {
    console.log("got classes and floor");
    var data = respo.d;
    var building = data[0];
    var innerrow = [];
    innerrow += '<div class="left-menu-container"><div class="left-menu-building building-unchecked">' +
        '<i class="fa L-CTRL-01 fa-minus-square mr-1"></i><label><input type="checkbox" name="yuyue">' +
        '<i class="fa fa-check jcheckbox mr-1 check-building"></i>' + building + '</label></div>' +
        '<div class="left-menu-building-dropbox">'
    for (i = 1; i < data.length; i++) {
        var d = data[i];
        var classnames = d[1].split(',');
        console.log(classnames);
        var classrow = [];
        classrow += '<div class="left-menu-room" style="display:none;">';
        for (j = 0; j < classnames.length; j++) {
            classrow += '<label class="j-room"><input type="checkbox" name="yuyue"><i class="fa fa-check jcheckbox mr-1"></i>' + classnames[j] + '</label>';
        }
        classrow += '</div>';
        
        var floor = d[0];
        innerrow += '<div class="left-menu-level level-unchecked">' +
            '<i class="fa fa-plus-square mr-1 L-CTRL-02"></i><label class="check-level"><input type="checkbox" name="yuyue">' +
            '<i class="fa fa-check jcheckbox mr-1 check-level"></i><b>' + floor + '</b></label></div>' + classrow ;
        console.log(innerrow);
        
    }
    innerrow += '</div></div>';
    console.log(innerrow);
    $("#leftmenudata").append($(innerrow));
}