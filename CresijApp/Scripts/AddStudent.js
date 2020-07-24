function AddNewStudent() {
    var myarray = new Array();
    myarray[0] = document.getElementById("id").value;
    myarray[1] = document.getElementById("name").value;
    alert($('input[name=fac]:checked').attr("value"));
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
        url: "../Services/SaveOrganisationData.asmx/SaveStudentData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
}

$(document).ready(function () {
    ("#AddStudentDetail").on('click', function () {
        console.log("clicked on save button");
        AddNewStudent();
    });
})

function OnSuccess_(response) {
    var idata = response.d;
    alert("saved successfully ");
    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/005.html");
}
function OnErrorCall_(respo) {
    console.log(respo);
}
