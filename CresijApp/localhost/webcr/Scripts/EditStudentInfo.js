$(document).ready(function () {
    $("#EditStudentDetail").on('click', function () {
        console.log("clicked on save button");
        EditStudentData();
    });
})

function OnSuccess(response) {
    var idata = response.d;
    console.log("saved successfully " + idata);
    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/005.html");
}
function OnErrorCall(respo) {
    console.log(respo);
}

function EditStudentData() {
    var myarray = new Array();
    myarray[0] = document.getElementById("studentid").value;
    myarray[1] = document.getElementById("name").value;
    myarray[2] = $('input[name=gender]:checked').attr("value");
    myarray[3] = document.getElementById("age").value;
    myarray[4] = $('input[name=fac]:checked').attr("value");
    myarray[5] = document.getElementById("phone").value;
    myarray[6] = document.getElementById("idcard").value;
    myarray[7] = document.getElementById("onecard").value;
    var jsonData = JSON.stringify({
        student: myarray
    });
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateStudentData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnErrorCall
    });

}