$ = jQuery.noConflict();
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetBuildingByID",
        data: JSON.stringify({id: $("#orgsno").val()}),
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
    var idata = response.d.value;
    document.getElementById("tbdept").value = idata.buildingName;
    document.getElementById("tbbuscode").value = idata.buildingCode;
    document.getElementById("tbque").value= idata.queue;
    $("#tbtype option:selected").val(idata.public);
    document.getElementById("tbnotes").value = idata.remarks;

}
function OnErrorCall_(respo) {
    console.log(respo);
}

function EditOrganisation() {
    var jsonData = JSON.stringify({data:{
        buildingName:document.getElementById("tbdept").value,
        buildingCode: document.getElementById("tbbuscode").value,
        queue:document.getElementById("tbque").value,
        accessType: $("#tbtype").val(),
        notes:document.getElementById("tbnotes").value, 
        id: $("#orgsno").val()}});
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateBuildingData",
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
    $("#left_menu").loadPageScript("components/left_menu.html");
    $("#sec_box").loadPageScript("window/p-data/001.html");

}
function OnErrorCall(respo) {
    console.log(respo);
}