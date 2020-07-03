$ = jQuery.noConflict();
$(document).ready(function () {
    console.log("Edit user data");
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCall_
    });
    console.log("User id" + $("#userId").val());
    document.getElementById("id").value = $("#userId").val();
    var jsonData = JSON.stringify({
        name: $("#userId").val()
    });
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetUserOnDemand",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessUser,
        error: OnErrorCall_
    });
});
function OnSuccessBuilding(respo) {
    var data = respo.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
        inner += '<option class="option" value="' + data[i] + '">' + data[i] + '</option>';
    }
    document.getElementById("selectedbuilding").innerHTML = inner;


}
function OnSuccessUser(response) {
    var idata = response.d;
    var data = idata[0];
    document.getElementById("id").value = data[1];
    document.getElementById("name").value = data[2];
    document.getElementById("persontype").innerText = data[3];
    //$('#selectedbuilding option:selected').text() = data[3];
    //document.getElementById("status").innerText == data[5];
    document.getElementById("phone").value= data[8];
    document.getElementById("notes").value = data[6];
    document.getElementById("pass").value = data[7];
}
function EditUser() {
    var myarray = new Array();
    var myarray = new Array();
    myarray[0] = document.getElementById("id").value;
    myarray[1] = document.getElementById("name").value;
    myarray[2] = document.getElementById("persontype").innerText;
    myarray[3] = $('#selectedbuilding option:selected').text();
   // myarray[4] = document.getElementById("status").innerText;
    myarray[4] = document.getElementById("phone").value;
    myarray[5] = document.getElementById("notes").value;
    myarray[6] = document.getElementById("pass").value;
    var jsonData = JSON.stringify({
        userdata: myarray
    });
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateUserData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
}

$("#EditUser").off('click').on('click', function () {
    console.log("clicked on save button");
    EditUser();
});

function OnSuccess_(response) {
    var idata = response.d;
    console.log("saved successfully ");
    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/002.html");
}
function OnErrorCall_(respo) {
    console.log(respo);
}
