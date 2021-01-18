function AddNewStudent() {
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/SaveStudentData",
        data: JSON.stringify({
            data:{
                studentId:document.getElementById("id").value,
                studentName:document.getElementById("name").value,
                gender: $('input[name=gender]:checked').attr("value"),
                age:document.getElementById("age").value,
                faculty: $('input[name=fac]:checked').attr("value"),
                phone: document.getElementById("phone").value,
                idCard: document.getElementById("idcard").value,
                oneCard: document.getElementById("onecard").value    
            }}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            alert("saved successfully ");
            $(".jmodal").fadeOut("fast");
            $("#sec_box").loadPageScript("window/p-data/005.html");
        },
        error: OnErrorCall_
    });
}

$(document).ready(function () {
    $("#AddStudentDetail").on('click', function () {
        console.log("clicked on save button");
        AddNewStudent();
    });
})


function OnErrorCall_(respo) {
    console.log(respo);
}
