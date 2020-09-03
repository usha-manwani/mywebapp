

function OnSuccess(response) {
    var idata = response.d;
    console.log("saved class successfully " + idata);
    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/003.html");
    $("#left_menu").load("components/left_menu.html");
}
function OnErrorCall(respo) {
    console.log(respo);
}
function EditClassData() {
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
    myarray[19] = document.getElementById("classid").value;
    
    
    
    var jsonData = JSON.stringify({
        classdata: myarray
    });
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
        success: OnSuccessBuilding,
        error: OnErrorCall_
    });
    $("#buildinglist").on('click', function () {
        var building = $("input[name='building']:checked").val();

        GetFloorList(building);
    });
    $("#EditClassDetail").on('click', function () {
        console.log("clicked on save button");
        EditClassData();
    });
})

function OnSuccessClass(response) {
    console.log("fill edit info");
    var data = response.d;
    var myarray = data[0];
    GetFloorList(myarray[2], myarray[3]);
    document.getElementById("className").value = myarray[1];    
    document.getElementById("tbseat").value = myarray[4] ;
      document.getElementById("ccip").value = myarray[12];
     document.getElementById("camsip").value = myarray[5];
     document.getElementById("camnip").value = myarray[6] ;
      document.getElementById("deskip").value = myarray[14];
      document.getElementById("recip").value = myarray[16];
    document.getElementById("ccmac").value = myarray[13] ;
     
      document.getElementById("camsmac").value = myarray[7];
     document.getElementById("camport").value = myarray[9] ;
     document.getElementById("camlogin").value = myarray[10];
     document.getElementById("campass").value = myarray[11] ;
     document.getElementById("camnmac").value= myarray[8] ;
      
      document.getElementById("deskmac").value = myarray[15];
      
     document.getElementById("recmac").value = myarray[17] ;
      
    document.getElementById("callhelpip").value = myarray[18];
    document.getElementById("callhelpmac").value = myarray[19];
    var radioLength = $('input[name=building]').length;
    var radioObj = $('input[name=building]');
    for (var i = 0; i < radioLength; i++) {
        radioObj[i].checked = false;
        if (radioObj[i].value == myarray[2].toString()) {
            radioObj[i].checked = true;
            $("#buildingname").text(myarray[2].toString());
            
        }
    }
    var radioLength1 = $('input[name=floor]').length;
    var radioObj1 = $('input[name=floor]');
    for (var i = 0; i < radioLength1; i++) {
        radioObj1[i].checked = false;
        if (radioObj1[i].value == myarray[3].toString()) {
            radioObj1[i].checked = true;
            $("#floorname").text(myarray[3].toString());
        }
    }
    //$('input[name=building]:checked').val() = myarray[2];
    //$('input[name=floor]:checked').val() = myarray[3];
}

function OnSuccessBuilding(response) {
    var idata = response.d;
    var optionlist = [];
    for (i = 0; i < idata.length; i++) {
        var data = idata[i];
        optionlist += '<label><input type="radio" name="building" value="' + data[0] + '" checked>' + data[0] +'</label>';
    }
    $("#buildinglist").append(optionlist);
    var classid = $("#classid").val();
    var jsonData = JSON.stringify({
        classData: classid
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetOrganisationData.asmx/GetClassDataOnId",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessClass,
        error: OnErrorCall
    });

    
}



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
        error: OnErrorCall
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