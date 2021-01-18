

function OnSuccess(response) {
    var idata = response.d;
    console.log("saved class successfully " + idata);
    $(".jmodal").fadeOut("fast");
    $("#sec_box").loadPageScript("window/p-data/003.html");
    $("#left_menu").loadPageScript("components/left_menu.html");
}
function OnErrorCall(respo) {
    console.log(respo);
}
function EditClassData() {
    var data = {}
    data.className = document.getElementById("className").value
    data.buildingName = $("#buildinglist").data("data-value").value;
    data.floor = $("#floorlist").data("data-value").value;
    data.seat = document.getElementById("tbseat").value;
    data.camIpS = document.getElementById("camsip").value;
    data.camIpT = document.getElementById("camnip").value;
    data.camSmac = document.getElementById("camsmac").value;
    data.camTmac = document.getElementById("camnmac").value;
    data.camPort = document.getElementById("camport").value;
    data.camId = document.getElementById("camlogin").value;
    data.camPass = document.getElementById("campass").value;
    data.centralControlIp = document.getElementById("ccip").value;
    data.centralControlMac = document.getElementById("ccmac").value;
    data.desktopIp = document.getElementById("deskip").value;
    data.desktopMac = document.getElementById("deskmac").value;
    data.recorderIp = document.getElementById("recip").value;
    data.recorderMac = document.getElementById("recmac").value;
    data.callHelpIp = document.getElementById("callhelpip").value;
    data.callHelpMac = document.getElementById("callhelpmac").value;
    data.classID = $("#classid").val(); 
    var jsonData = JSON.stringify({data: data});
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateClassData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnErrorCall
    });

}

$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {         
            if (response.d.status === "success") {
                $.initSelectBox({name: 'buildinglist', data: response.d.value.map(function(i,k){return {value:i.BuildingId, label:i.BuildingName}})})
                
                $.ajax({
                    type: "POST",
                    url: "../Services/GetOrganisationData.asmx/GetClassDataById",
                    data: JSON.stringify({ id: $("#classid").val()}),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var data = response.d.value;
                        $("#buildinglist").setSelectVal(data.Building)
                        GetFloorList($("#buildinglist").data("data-value").value, data.Floor);
                        document.getElementById("className").value = data.Classname;    
                        document.getElementById("tbseat").value = data.Seat ;
                        document.getElementById("ccip").value = data.Ccip;
                        document.getElementById("camsip").value = data.CamipS;
                        document.getElementById("camnip").value = data.CamipT ;
                        document.getElementById("deskip").value = data.DesktopIp;
                        document.getElementById("recip").value = data.RecorderIp;
                        document.getElementById("ccmac").value = data.CCmac ;
                        
                        document.getElementById("camsmac").value = data.CamSmac;
                        document.getElementById("camport").value = data.CamPort ;
                        document.getElementById("camlogin").value = data.Camuserid;
                        document.getElementById("campass").value = data.Campass ;
                        document.getElementById("camnmac").value= data.CamTmac ;
                        document.getElementById("deskmac").value = data.Desktopmac;
                        document.getElementById("recmac").value = data.Recordermac ;
                        document.getElementById("callhelpip").value = data.CallHelpIP;
                        document.getElementById("callhelpmac").value = data.CallHelpmac;
                    },
                    error: OnErrorCall
                });
            }           
        },
        error: OnErrorCall_
    });
    $("#buildinglist").on('list-change', function () {
        GetFloorList($("#buildinglist").data("data-value").value);
    });
    $("#EditClassDetail").on('click', function () {
        console.log("clicked on save button");
        EditClassData();
    });
})

function GetFloorList(building, floor) {
    var jsonData = JSON.stringify({
        building: building
    });
    return $.ajax({
        type: "POST",
        url: "../Services/GetOrganisationData.asmx/GetFloorlist",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.initSelectBox({name: 'floorlist', data: response.d.value.map(function(i,k){return {value:i.FloorId, label:i.FloorName}})})   
            $("#floorlist").setSelectVal(floor)                            
        },
        error: OnErrorCall
    });
}
