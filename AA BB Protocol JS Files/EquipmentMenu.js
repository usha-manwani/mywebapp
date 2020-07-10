$(function () {
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
function OnSuccessBuilding(response) {
    var data = response.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
        inner += '<option class="option" value="' + data[i] + '">' + data[i] + '</option>';
    }
    document.getElementById("buildinglist").innerHTML = inner;
    GetClassList();
}
function OnErrorCall_(respo) {
    console.log(respo);
}
$("#buildinglist").off("change").on("change", function () {  
    
    GetClassList();
});

function GetClassList() {
    console.log($('#buildinglist option:selected').text());
    var adata ;
    adata= $('#buildinglist option:selected').text();
    //adata[1] = $('#floorlist option:selected').text();
    document.getElementById("equipcontrol").innerHTML = "";
    var jsonData = JSON.stringify({
        data: adata
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetOrganisationData.asmx/GetIPClassByBuilding",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessClass,
        error: OnErrorCall_
    });
}

function OnSuccessClass(response) {
    document.getElementById("floorlist").innerHTML = '<option class="option">--select--</option>';
    var data = response.d;
    if (data.length > 0) {
        var inner = [];
        var val = [];
        for (i = 0; i < data.length; i++) {
            var dd = data[i];
            val.push(dd[1]);
        }
        var unique = val.filter(function (itm, k, val) {
            return k == val.indexOf(itm);
        });
        inner += '<option class="option">--select--</option>';
         
        for (j = 0; j < unique.length; j++) {
            inner += '<option class="option" value="' + unique[j] + '">' + unique[j] + '</option>';
        }
        document.getElementById("floorlist").innerHTML = inner;
       
        var eprows = [];
        for (i = 0; i < data.length; i++) {
            var dd = data[i];
            eprows += '<div class="eqp-ctrl-pannel no-gutters row mb-4">' + '<div class="col-12 row stat-card no-gutters overflow-hidden border-white jtab-comp">' +
                '<div class="col-4 bg_gray2 pt-3 float-left j-eqm-tabs" style="height:154px;">' + '<div class="ml-3 gray"><label><input type="checkbox" name="classipAddress" value="' +
                dd[2]+'">' +'<i class="fa fa-check jcheckbox mr-2"></i></label>' +
                '<a class="JURL" j-page-href="window/p-equipment/002.html?ip='+dd[2]+'" j-page-box="#sec_box" j-menu-href="window/menus/m-equipment-02.html"' +
                ' j-menu-box="#jpagetitle" j-pannel-href="window/p-equipment/ctrl-pannels/assist.html" j-pannel-box="#ctrl_pannels">' +
                '第一教学楼<div class="ml-3 pl-2 gray mb-2 float-left col-12 p-0 jfont22">' + dd[0] + '</div></a></div>' +
                '<div class="mt-3 ml-3 row clearfix col-12 p-0"><span class="j-status-light light-red mr-2 status-dot" data-toggle="tooltip"' +
                ' data-placement="bottom" title="该教室有设备故障"></span><span class="jf-12 font-weight-normal gray">' +
                '<label><input type="checkbox" class="j-single ipaddressclassname" value="' + dd[2] +'"> <span class="jswift" style="width:60px;"><i class="jswift-btn">' +
                '</i><i class="on"></i><i class="off"></i></span></label></span></div>' +
                '<div class="jtab-2"><div jtab-order="0" class="tabbox-2 active">教<br>辅</div><div jtab-order="1" class="tabbox-2">环<br>境</div></div>'+
                '</div>' +
                '<div class="col-8 row pt-3 float-left">' +
                '<div class="row jtab-box-2" style="margin-left:5%; display:inherit;">' +
                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray projectorclass"><i class="fa fa-desktop fa-lg gray align-middle my-2 "></i><div class="align-middle mb-1">投影</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray computerclass"><i class="fa fa-desktop fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">电脑</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray volumeclass"><i class="fa fa-volume-up fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">音响</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray curtainclassicon"><i class="fa fa-columns fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">幕布</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray signalclass"><i class="fa fa-signal fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">信号源</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray systemlockclass"><i class="fa fa-unlock-alt fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">面板锁</div></div></div>' +
                '</div>' +

                '<div class="row jtab-box-2" style="margin-left:5%; display:none;">' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray lightclass1"><i class="fa fa-lightbulb-o fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">课室灯光</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray classroomcurtainsclass"><i class="fa fa-columns fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">课室窗帘</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray acclass"><i class="fa fa-snowflake-o fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">空调</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray podiumlightclass"><i class="fa fa-lightbulb-o fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">讲台灯光</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray podiumcurtainclass"><i class="fa fa-columns fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">讲台窗帘</div></div></div>' +

                '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray freshairclass"><i class="fa gray align-middle my-2">' +
                '<svg class="svg-2 fill-gray" xmlns="http://www.w3.org/2000/svg" viewbox="0 0 18.56 16.81">' +
                '<g><path d="M15,7.2H0v-2H15a1.6,1.6,0,1,0-1.6-1.6h-2A3.6,3.6,0,1,1,15,7.2Z" /><rect class="cls-1" y="10" width="17.55" height="2" />' +
                '<rect class="cls-1" y="14.81" width="17.55" height="2" /></g></svg>' +
                '</i><div class="align-middle mb-1">新风系统</div></div></div>' +
                '</div>' +
                '</div>'+
                '</div></div>';
        }
        document.getElementById("equipcontrol").innerHTML = eprows;
        
    }
}

function GetIPList() {
    var adata=[];
    adata[0] = $('#buildinglist option:selected').text();
    adata[1] = $('#floorlist option:selected').text();
    document.getElementById("equipcontrol").innerHTML = "";
    var jsonData = JSON.stringify({
        data: adata
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetOrganisationData.asmx/GetIPClassByBuildingFloor",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessClassIp,
        error: OnErrorCall_
    });
}

function OnSuccessClassIp(idata) {
    
    var data = idata.d;
    var eprows = [];
    for (i = 0; i < data.length; i++) {
        var dd = data[i];
        eprows += '<div class="eqp-ctrl-pannel no-gutters row mb-4">' + '<div class="col-12 row stat-card no-gutters overflow-hidden border-white jtab-comp">' +
            '<div class="col-4 bg_gray2 pt-3 float-left j-eqm-tabs" style="height:154px;">' + '<div class="ml-3 gray"><label><input type="checkbox" name="classipAddress" value="' +
            dd[1] + '">' + '<i class="fa fa-check jcheckbox mr-2"></i></label>' +
            '<a class="JURL" j-page-href="window/p-equipment/002.html?ip=' + dd[1] + '" j-page-box="#sec_box" j-menu-href="window/menus/m-equipment-02.html"' +
            ' j-menu-box="#jpagetitle" j-pannel-href="window/p-equipment/ctrl-pannels/assist.html" j-pannel-box="#ctrl_pannels">' +
            '第一教学楼<div class="ml-3 pl-2 gray mb-2 float-left col-12 p-0 jfont22">' + dd[0] + '</div></a></div>' +
            '<div class="mt-3 ml-3 row clearfix col-12 p-0"><span class="j-status-light light-red mr-2 status-dot" data-toggle="tooltip"' +
            ' data-placement="bottom" title="该教室有设备故障"></span><span class="jf-12 font-weight-normal gray">' +
            '<label><input type="checkbox" class="j-single ipaddressclassname" value="' + dd[1] + '"> <span class="jswift" style="width:60px;"><i class="jswift-btn">' +
            '</i><i class="on"></i><i class="off"></i></span></label></span></div>' +
            '<div class="jtab-2"><div jtab-order="0" class="tabbox-2 active">教<br>辅</div><div jtab-order="1" class="tabbox-2">环<br>境</div></div>' +
            '</div>' +
            '<div class="col-8 row pt-3 float-left">' +
            '<div class="row jtab-box-2" style="margin-left:5%; display:inherit;">' +
            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray projectorclass"><i class="fa fa-desktop fa-lg gray align-middle my-2 "></i><div class="align-middle mb-1">投影</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray computerclass"><i class="fa fa-desktop fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">电脑</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray volumeclass"><i class="fa fa-volume-up fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">音响</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray curtainclassicon"><i class="fa fa-columns fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">幕布</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray signalclass"><i class="fa fa-signal fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">信号源</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray systemlockclass"><i class="fa fa-unlock-alt fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">面板锁</div></div></div>' +
            '</div>' +

            '<div class="row jtab-box-2" style="margin-left:5%; display:none;">' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray lightclass1"><i class="fa fa-lightbulb-o fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">课室灯光</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray classroomcurtainsclass"><i class="fa fa-columns fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">课室窗帘</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray acclass"><i class="fa fa-snowflake-o fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">空调</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray podiumlightclass"><i class="fa fa-lightbulb-o fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">讲台灯光</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray podiumcurtainclass"><i class="fa fa-columns fa-lg gray align-middle my-2"></i><div class="align-middle mb-1">讲台窗帘</div></div></div>' +

            '<div class="col-4 pb-3 text-center"><div class="col-12 j-eqm-gray freshairclass"><i class="fa gray align-middle my-2">' +
            '<svg class="svg-2 fill-gray" xmlns="http://www.w3.org/2000/svg" viewbox="0 0 18.56 16.81">' +
            '<g><path d="M15,7.2H0v-2H15a1.6,1.6,0,1,0-1.6-1.6h-2A3.6,3.6,0,1,1,15,7.2Z" /><rect class="cls-1" y="10" width="17.55" height="2" />' +
            '<rect class="cls-1" y="14.81" width="17.55" height="2" /></g></svg>' +
            '</i><div class="align-middle mb-1">新风系统</div></div></div>' +
            '</div>' +
            '</div>' +
            '</div></div>';
    }
    document.getElementById("equipcontrol").innerHTML = eprows;
}