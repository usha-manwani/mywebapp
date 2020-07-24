$(document).ready(function () {
    ("#EditTeacherDetail").on('click', function () {
        console.log("clicked on save button");
        EditTeacherData();
    });
})

function OnSuccess(response) {
    var idata = response.d;
    console.log("saved successfully " + idata);

    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/004.html");

}
function OnErrorCall(respo) {
    console.log(respo);
}

function EditTeacherData() {
    var myarray = new Array();
    myarray[0] = document.getElementById("teacherid").value;
    myarray[1] = document.getElementById("tname").value;
    myarray[2] = $('input[name=gender]:checked').attr("value");
    myarray[3] = document.getElementById("age").value;
    myarray[4] = $('input[name=fac]:checked').attr("value");
    myarray[5] = document.getElementById("phone").value;
    myarray[6] = document.getElementById("idcard").value;
    myarray[7] = document.getElementById("onecard").value;
    var jsonData = JSON.stringify({
        teacher: myarray
    });
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateTeacherData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnErrorCall
    });

}
