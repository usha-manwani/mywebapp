$(document).ready(function () {
    // 获取当前行所有数据
    var rowData = $("tr:contains('"+$("#teacherid").val()+"')").find("td").map((_,i)=>{return $(i).text()})
    $("#teacherid").val(rowData[1]);
    $("#tname").val(rowData[2]);
    $('#genderlist').setSelectVal2(rowData[3]);
    $("#age").val(rowData[4]);
    $('#faclist').setSelectVal2(rowData[5]);
    $("#phone").val(rowData[6]);
    $("#idcard").val(rowData[7]);
    $("#onecard").val(rowData[8]);
    $("#EditTeacherDetail").on('click', function () {
        console.log("clicked on save button");
        EditTeacherData();
    });
})
function EditTeacherData() {
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateTeacherData",
        data: JSON.stringify({data:{
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
        success: function () {    
            $(".jmodal").fadeOut("fast");
            $("#sec_box").loadPageScript("window/p-data/004.html");
        
        },
        error:function (respo) {
            console.log(respo);
        }
    });

}
