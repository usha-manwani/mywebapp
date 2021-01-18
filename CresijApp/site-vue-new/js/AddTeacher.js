function AddNewTeacher() {
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/SaveTeacherData",
        data: JSON.stringify({
            data:{
                teacherId:document.getElementById("teacherid").value,
                teacherName:document.getElementById("tname").value,
                gender: $('input[name=gender]:checked').attr("value"),
                age:document.getElementById("age").value,
                faculty: $('input[name=fac]:checked').attr("value"),
                phone: document.getElementById("phone").value,
                idCard: document.getElementById("idcard").value,
                oneCard: document.getElementById("onecard").value
            }}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function() {
            alert("saved successfully ");
            $(".jmodal").fadeOut("fast");
            $("#sec_box").loadPageScript("window/p-data/004.html");
        },
        error: OnErrorCall_
    });

}
$(document).ready(function(){
    $("#AddTeacherDetail").on('click', function () {
        AddNewTeacher();
    });
})
function OnErrorCall_(respo) {
    console.log(respo);
}


