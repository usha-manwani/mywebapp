function AddNewOrganisation() {
    var myarray = new Array();
    myarray[0] = document.getElementById("tbdept").value;
    myarray[1] = document.getElementById("tbbuscode").value;
    myarray[2] = $("#tbhighoff").val();
    myarray[3]= document.getElementById("tbque").value;
    myarray[4] = $("#tbtype").val(); 
    myarray[5] = document.getElementById("tbnotes").value;
    
    var jsonData = JSON.stringify({
        org: myarray
    });
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/SaveOrgData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    
}

//$(document).on("click", "#savedetail", function () {
    
//});
$("#savedetail").off('click').on('click', function () {
    console.log("clicked on save button");
    AddNewOrganisation();
});

function OnSuccess_(response) {
    var idata = response.d;
    console.log("saved successfully " + idata);
    
    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/001.html");
    
}
function OnErrorCall_(respo) {
    console.log(respo);
}
