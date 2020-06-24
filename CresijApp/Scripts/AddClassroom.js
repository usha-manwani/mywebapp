$("#btnAddClass").off('click').on('click', function () {
    console.log("clicked on save button");
    AddNewClass();
});

function AddNewClass() {
    var myarray = new Array();
    myarray[0] = document.getElementById("className").value;
    myarray[1] = $('input[name=building]:checked').attr("value");
    myarray[2] = $('input[name=floor]:checked').attr("value");
    myarray[3] = document.getElementById("tbseat").value;
    myarray[4] = document.getElementById("camsip").value;
    myarray[5] = document.getElementById("camnip").value;
    myarray[6] = document.getElementById("camsmac").value;
    myarray[7] = document.getElementById("camnmac").value;
    myarray[8] = document.getElementById("camport").value;
    myarray[9] = document.getElementById("camlogin").value;
    myarray[10] = document.getElementById("campass").value;
    myarray[11] = document.getElementById("ccip").value;
    myarray[12] = document.getElementById("ccmac").value;
    myarray[13] = document.getElementById("deskip").value;
    myarray[14] = document.getElementById("deskmac").value;
    myarray[15] = document.getElementById("recip").value;    
    myarray[16] = document.getElementById("recmac").value;   
    myarray[17] = document.getElementById("callhelpip").value;
    myarray[18] = document.getElementById("callhelpmac").value;
    var jsonData = JSON.stringify({
        classdata: myarray
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
    $("#sec_box").load("window/p-data/003.html");
    $("#left_menu").load("components/left_menu.html");
}
function OnErrorCall_(respo) {
    console.log(respo);
}

$(function () {
    console.log("building fot");
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCall_
    });

})

function OnSuccessBuilding(response) {
    var idata = response.d;
    var optionlist = [];
    for (i = 0; i < idata.length; i++) {
        var data = idata[i];
        optionlist += '<label><input type="radio" name="building" class="buildingclick" value="' + data[0] + '" checked>' + data[0] + '</label>';
    }
    $("#buildinglist").append(optionlist);
}

$("#buildinglist").on('click', function () {
    var building = $("input[name='building']:checked").val();
    console.log("building name : " + building);
    GetFloorList(building);
});
function GetFloorList(building) {
    var jsonData = JSON.stringify({
        building: building
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetOrganisationData.asmx/GetFloorlist",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessFloor,
        error: OnErrorCall_
    });
}
function OnSuccessFloor(response) {
    console.log("GetFloor Info");
    $("#floorlist").empty();
    var idata = response.d;
    var optionlist = [];
    for (i = 0; i < idata.length; i++) {
        var data = idata[i];
        optionlist += '<label><input type="radio" name="floor" value="' + data[0] + '" checked>' + data[0] + '</label>';
    }
    $("#floorlist").append(optionlist);
}