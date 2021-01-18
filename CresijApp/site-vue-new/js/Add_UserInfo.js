function AddNewUser() {
    if (document.getElementById("pass").value !=document.getElementById("pass").value) {
        alert("password doesnt match!!");
    }
    else {
        var jsonData = JSON.stringify({
            data: {
                userName: document.getElementById("name").value,
                personType: document.getElementById("persontype").innerText,
                departmentName: $('#selectedbuilding').data("data-value").value,
                personnelStatus: document.getElementById("status").innerText,
                phone:document.getElementById("phone").value,
                notes:document.getElementById("notes").value,
                password:document.getElementById("pass").value ,
                expireDate: document.getElementById("userdate").value,
                expireTime: document.getElementById("validtime").value
            }
        });
        $.ajax({
            type: "POST",
            url: "../Services/SaveOrganisationData.asmx/AddUserData",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccess_,
            error: OnErrorCall_
        });
    }
}



function OnSuccess_(response) {
    var idata = response.d;
    console.log("saved successfully ");
    $(".jmodal").fadeOut("fast");
    $("#sec_box").loadPageScript("window/p-data/002.html");
}
function OnErrorCall_(respo) {
    console.log(respo);
}
$(document).ready(function () {
    console.log("add user data");
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (respo) {
            if (respo.d.status === "success") {
                $.initSelectBox({name: 'selectedbuilding', data: respo.d.value.map(function(i,k){return {value:i.BuildingId, label:i.BuildingName}})})
            }
        },
        error: OnErrorCall_
    });
    $("#AddUser").on('click', function () {
        console.log("clicked on save button");
        AddNewUser();
    });
    $("input[name='usertype']").on("change", function () {
        if ($(this).val() == "temporary") {
            $("#daterow").attr("style", "display:table-row");
            $('.datetimepicker').datetimepicker({
                format: 'YYYY-MM-DD',
                locale: 'zh-cn',
                defaultDate: new Date(),
                icons: {
                    previous: "fa fa-arrow-circle-left green",
                    next: "fa fa-arrow-circle-right green",
                }
            });
            $('.datetimepicker-clock').datetimepicker({
                format: 'LT',
                locale: 'zh-cn',
                icons: {
                    up: "fa fa-chevron-up green",
                    down: "fa fa-chevron-down green",
                }
            });
        }
        else {
            $("#daterow").attr("style", "display:none");
        }
    });
});

function OnErrorCall_(respo) {
    console.log(respo);
}


