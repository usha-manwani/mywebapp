$ = jQuery.noConflict();
$(document).ready(function () {
    console.log("Edit user data");
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCall_
    });
    console.log("User id" + $("#userId").val());
    document.getElementById("id").value = $("#userId").val();
    var jsonData = JSON.stringify({
        name: $("#userId").val()
    });
    $.ajax({
        type: "POST",
        url: "../Services/getOrganisationData.asmx/GetUserOnDemand",
        data: jsonData,
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
function OnSuccessBuilding(respo) {
    var data = respo.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
        inner += '<option class="option" value="' + data[i] + '">' + data[i] + '</option>';
    }
    document.getElementById("selectedbuilding").innerHTML = inner;


}

function OnSuccessUser(response) {
    var idata = response.d;
    var data = idata[0];
    var userid = sessionStorage.getItem("LoginId");
    if (userid != data[1]) {
        $("#pass").prop("disabled", "disabled");        
    }
    else {
        $("#pass").prop("disabled", "");        
    }
    document.getElementById("id").value = data[1];
    document.getElementById("name").value = data[2];
    document.getElementById("persontype").innerText = data[3];
    if (data[3] == "永久") {
        $("#daterow").attr("style", "display:none");
    }
    else {
        $("#daterow").attr("style", "display:table-row");
    }
    //$('#selectedbuilding option:selected').text() = data[3];
    //document.getElementById("status").innerText == data[5];
    document.getElementById("phone").value= data[8];
    document.getElementById("notes").value = data[6];
    document.getElementById("pass").value = data[7];
    document.getElementById("validtime").value = data[10];
    var len = moment(data[9]).toDate();
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
    myarray[3] = $('#selectedbuilding option:selected').text();
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
    $("#sec_box").load("window/p-data/002.html");
}
function OnErrorCall_(respo) {
    console.log(respo);
}


