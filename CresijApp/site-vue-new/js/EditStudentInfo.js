$(document).ready(function () {
    var rowData = $("tr:contains('"+$("#studentid").val()+"')").find("td").map((_,i)=>{return $(i).text()})
    $("#studentid").val(rowData[1]);
    $("#name").val(rowData[2]);
    $('#genderlist').setSelectVal2(rowData[3]);
    $("#age").val(rowData[4]);
    $('#faclist').setSelectVal2(rowData[5]);
    $("#phone").val(rowData[6]);
    $("#idcard").val(rowData[7]);
    $("#onecard").val(rowData[8]);
    $("#EditStudentDetail").on('click', function () {
        console.log("clicked on save button");
        EditStudentData();
    });
})


function OnErrorCall(respo) {
    console.log(respo);
}

function EditStudentData() {
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateStudentData",
        data: JSON.stringify({
            data:{
                studentId:document.getElementById("studentid").value,
                studentName:document.getElementById("name").value,
                gender: $('input[name=gender]:checked').attr("value"),
                age:document.getElementById("age").value,
                faculty: $('input[name=fac]:checked').attr("value"),
                phone: document.getElementById("phone").value,
                idCard: document.getElementById("idcard").value,
                oneCard: document.getElementById("onecard").value    
            }
        }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            $(".jmodal").fadeOut("fast");
            $("#sec_box").loadPageScript("window/p-data/005.html");
        },
        error: OnErrorCall
    });

}