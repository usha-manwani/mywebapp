$ = jQuery.noConflict();
$(document).ready(function () {
   
    console.log("org sno "+ $("#orgsno").val());
    var jsonData = JSON.stringify({
        name: $("#orgsno").val()
    });
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetOrgOnDemand",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
});
function OnSuccess_(response) {
    var idata = response.d;
    
    document.getElementById("tbdept").value = idata[0];
    console.log(document.getElementById("tbdept"));
    document.getElementById("tbbuscode").value = idata[1];
    $("#tbhighoff").val(idata[2]);
    document.getElementById("tbque").value= idata[3];
    $("#tbtype").val(idata[4]);
    document.getElementById("tbnotes").value = idata[5];

}
function OnErrorCall_(respo) {
    console.log(respo);
}

function EditOrganisation() {
    var myarray = new Array();
    myarray[0] = document.getElementById("tbdept").value;
    myarray[1] = document.getElementById("tbbuscode").value;
    myarray[2] = $("#tbhighoff").val();
    myarray[3] = document.getElementById("tbque").value;
    myarray[4] = $("#tbtype").val();
    myarray[5] = document.getElementById("tbnotes").value;
    myarray[6]= $("#orgsno").val();
    var jsonData = JSON.stringify({
        org: myarray
    });
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateOrgData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnErrorCall
    });

}

//$(document).on("click", "#savedetail", function () {

//});
$("#updateorgdetail").off('click').on('click', function () {
    console.log("clicked on save button");
    EditOrganisation();
});

function OnSuccess(response) {
    var idata = response.d;
    console.log("saved successfully " + idata);

    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/001.html");

}
function OnErrorCall(respo) {
    console.log(respo);
}