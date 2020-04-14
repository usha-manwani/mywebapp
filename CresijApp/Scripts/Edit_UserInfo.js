$ = jQuery.noConflict();
$(document).ready(function () {

    console.log("User id" + $("#userId").val());
    document.getElementById("id").value = $("#userId").val();
    //var jsonData = JSON.stringify({
    //    name: $("#orgsno").val()
    //});
    //$.ajax({
    //    type: "POST",
    //    url: "../Services/getOrganisationData.asmx/GetOrgOnDemand",
    //    data: jsonData,
    //    contentType: "application/json; charset=utf-8",
    //    dataType: "json",
    //    success: OnSuccess_,
    //    error: OnErrorCall_
    //});
});

function EditUser() {
    var myarray = new Array();
    myarray[0] = document.getElementById("userId").value;
    myarray[1] = document.getElementById("name").value;
    myarray[2] = document.getElementById("persontype").value;
    myarray[3] = document.getElementById("dept").value;   
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
