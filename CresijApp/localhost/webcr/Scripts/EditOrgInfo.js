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
    $("#updateorgdetail").on('click', function () {
        console.log("clicked on save button");
        EditOrganisation();
    });
});
function OnSuccess_(response) {
    var data = response.d;
    var idata = data[0];
    document.getElementById("tbdept").value = idata[1];
    console.log(document.getElementById("tbdept"));
    document.getElementById("tbbuscode").value = idata[2];
    $("#tbhighoff").val(idata[3]);
    document.getElementById("tbque").value= idata[4];
    $("#tbtype option:selected").val(idata[5]);
    document.getElementById("tbnotes").value = idata[6];

}
function OnErrorCall_(respo) {
    console.log(respo);
}

function EditOrganisation() {
    var myarray = new Array();
    console.log($("#tbhighoff option:selected").val());
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


function OnSuccess(response) {
    var idata = response.d;
    console.log("saved successfully " + idata);

    $(".jmodal").fadeOut("fast");
    $("#left_menu").load("components/left_menu.html");
    $("#sec_box").load("window/p-data/001.html");

}
function OnErrorCall(respo) {
    console.log(respo);
}