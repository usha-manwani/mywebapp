function AddNewOrganisation() {
    var myarray = new Array();
    console.log($("input[name = 'buildflooroption']:checked").val());
    
    if ($("input[name='buildflooroption']:checked").val() == 'floor') {
        myarray[0] = document.getElementById("tbdept").value;
        myarray[1] = document.getElementById("tbbuscode").value;
        myarray[2] = $("#tbhighoff").val();
        myarray[3] = document.getElementById("tbque").value;
        myarray[4] = $("#tbtype").val();
        myarray[5] = document.getElementById("tbnotes").value;

        var jsonData = JSON.stringify({
            org: myarray
        });
        $.ajax({
            type: "POST",
            url: "../Services/SaveOrganisationData.asmx/SaveOrgDataFloor",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_,
            error: OnErrorCall_
        });
    }
    else if ($("input[name='buildflooroption']:checked").val() == 'building') {
        myarray[0] = document.getElementById("tbdept").value;
        myarray[1] = document.getElementById("tbbuscode").value;
        //myarray[2] = $("#tbhighoff").val();
        myarray[2] = document.getElementById("tbque").value;
        myarray[3] = $("#tbtype").val();
        myarray[4] = document.getElementById("tbnotes").value;

        var jsonData = JSON.stringify({
            org: myarray
        });
        $.ajax({
            type: "POST",
            url: "../Services/SaveOrganisationData.asmx/SaveOrgDataBuilding",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_,
            error: OnErrorCall_
        });
    }
}
function OnSuccess_(response) {
    var idata = response.d;
    console.log("saved successfully " + idata);
    
    $(".jmodal").fadeOut("fast");
    $("#sec_box").loadPageScript("window/p-data/001.html");
    $("#left_menu").loadPageScript("components/left_menu.html");
}
function OnErrorCall_(respo) {
    console.log(respo);
}

$(document).ready(function () {
    console.log("add/edit org page");
    GetBuildingList();
    $("input[name='buildflooroption']").on('click', function () {
        if ($(this).val() == "floor") {
            $("#tbhighoff").prop("disabled", false);
            GetBuildingList();
        }
        else if ($(this).val() == "building") GetSchoolname();
    });
    $("#savedetail").on('click', function () {
        console.log("clicked on save button");
        AddNewOrganisation();
    });

})

function OnSuccessSchoolname(response) {
    var idata = response.d;
    var optionlist = [];
    for (i = 0; i < idata.length; i++) {
        var data = idata[i];
        optionlist += '<option value="' + data[0] + '">' + data[0] + '</option>';
    }
    $("#tbhighoff").prop("innerHTML", "");
    $("#tbhighoff").prop("disabled", false);
    $("#tbhighoff").append(optionlist);
}

function GetSchoolname() {
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetSchoolName",
        data: JSON.stringify({building: ""}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessSchoolname,
        error: OnErrorCall_
    });
}

function GetBuildingList() {
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {            
            if (response.d.status === "success") {
                $.initSelectBox({name: 'tbhighoff', data: response.d.value.map(function(i,k){return {value:i.BuildingId, label:i.BuildingName}})})    
            }
        },
        error: OnErrorCall_
    });
}