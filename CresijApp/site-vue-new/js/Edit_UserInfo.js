$ = jQuery.noConflict();
$(document).ready(function () {
    console.log("Edit user data");
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {            
            if (response.d.status === "success") {
                $.initSelectBox({name: 'selectedbuilding', data: response.d.value.map(function(i,k){return {value:i.BuildingId, label:i.BuildingName}})})
            }
        },
        error: OnErrorCall_
    });
    document.getElementById("id").value = $("#userId").val();
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetUserByID",
        data: JSON.stringify({id: $("#userId").val()}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessUser,
        error: OnErrorCall_
    });
    $("#EditUser").on('click', function () {
        console.log("clicked on save button");
        EditUser();
    });
    $("input[name='usertype']").on("change", function () {
        if ($(this).val() == "temporary") {
            $("#daterow").attr("style", "display:table-row");
        }
        else {
            $("#daterow").attr("style", "display:none");
        }
    })
});


function OnSuccessUser(response) {
    var data = response.d.value;
    document.getElementById("name").value = data.UserName;
    document.getElementById("persontype").innerText = data.PersonType;
    if (data.PersonType == "longterm") {
        $("#daterow").attr("style", "display:none");
    }
    else {
        $("#daterow").attr("style", "display:table-row");
    }
    document.getElementById("phone").value= data.Password;
    document.getElementById("notes").value = data.phone;
    document.getElementById("pass").value = data.Notes;
    document.getElementById("validtime").value = data.validityDate;
    var len = moment(data.expiretime).toDate();
    var dates = moment(len).format('YYYY-MM-DD');
    if (dates == '0001-01-01') {
        dates = moment(new Date()).format('YYYY-MM-DD');
    }
    document.getElementById("userdate").value = dates;
    console.log("edit date time " + len);
   
    
    $('.datetimepicker').datetimepicker({
        format: 'YYYY-MM-DD',
        locale: 'zh-cn',
        defaultDate: dates,
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

function EditUser() {
    var myarray = new Array();
    var myarray = new Array();
    myarray[0] = document.getElementById("id").value;
    myarray[1] = document.getElementById("name").value;
    myarray[2] = document.getElementById("persontype").innerText;
    myarray[3] = $('#selectedbuilding').data("data-value").value;
   // myarray[4] = document.getElementById("status").innerText;
    myarray[4] = document.getElementById("phone").value;
    myarray[5] = document.getElementById("notes").value;
    myarray[6] = document.getElementById("pass").value;
    myarray[7] = document.getElementById("userdate").value;
    myarray[8] = document.getElementById("validtime").value;
    var jsonData = JSON.stringify({
        userdata: myarray
    });
    $.ajax({
        type: "POST",
        url: "../Services/SaveOrganisationData.asmx/UpdateUserData",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
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


