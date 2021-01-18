

function AddNewClass() {
    var jsonData = JSON.stringify({
        data:{
            className: document.getElementById("className").value,
            buildingName: $("#buildinglist").data("data-value").value,
            floor: $("#floorlist").data("data-value").value,
            seat: document.getElementById("tbseat").value,
            camIpS: document.getElementById("camsip").value,
            camIpT: document.getElementById("camnip").value,
            camSmac: document.getElementById("camsmac").value,
            camTmac: document.getElementById("camnmac").value,
            camPort: document.getElementById("camport").value,
            camId: document.getElementById("camlogin").value,
            camPass: document.getElementById("campass").value,
            centralControlMac: document.getElementById("ccmac").value,
            centralControlIp: document.getElementById("ccip").value,   
            // document.getElementById("ccip").value
            desktopIp: document.getElementById("deskip").value,
            desktopMac: document.getElementById("deskmac").value,
            recorderIp: document.getElementById("recip").value,
            recorderMac: document.getElementById("recmac").value,
            callHelpIp: document.getElementById("callhelpip").value,
            callHelpMac: document.getElementById("callhelpmac").value
        }
    });
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/SaveClassData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
}

function OnSuccess_(response) {
   // var idata = response.d;
    console.log("class saved successfully ");
    $(".jmodal").fadeOut("fast");
    $("#sec_box").loadPageScript("window/p-data/003.html");
    $("#left_menu").loadPageScript("components/left_menu.html");
}
function OnErrorCall_(respo) {
    console.log(respo);
}

$(document).ready(function () {
    console.log("building fot");
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d.status === "success") {
                $.initSelectBox({name: 'buildinglist', data: response.d.value.map(function(i,k){return {value:i.BuildingId, label:i.BuildingName}})})
                GetFloorList($("#buildinglist").data("data-value").value,"")
            }
        },
        error: OnErrorCall_
    });
    $("#btnAddClass").on('click', function () {
        console.log("clicked on save button");
        AddNewClass();
    });
    $("#buildinglist").on('click', function () {
        GetFloorList($("#buildinglist").data("data-value").value);
    });
})


function GetFloorList(building, floor) {
    var jsonData = JSON.stringify({
        building: building
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetOrganisationData.asmx/GetFloorlist",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.initSelectBox({name: 'floorlist', data: response.d.value.map(function(i,k){return {value:i.FloorId, label:i.FloorName}})})   
            $("#floorlist").setSelectVal(floor)                            
        },
        error: OnErrorCall_
    });
}
