function AddNewUser() {
    var myarray = new Array();
    myarray[0] = document.getElementById("id").value;
    myarray[1] = document.getElementById("name").value;    
    myarray[2] = document.getElementById("persontype").innerText;
    myarray[3] = $('#selectedbuilding option:selected').text();
    myarray[4] = document.getElementById("status").innerText;
    myarray[5] = document.getElementById("phone").value;
    myarray[6] = document.getElementById("notes").value;
    myarray[7] = document.getElementById("pass").value;
    myarray[8] = document.getElementById("confirmpass").value;
    if (myarray[8] != myarray[7]) {
        alert("password doesnt match!!");
    }
    else {


        var jsonData = JSON.stringify({
            userdata: myarray
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

$("#AddUser").off('click').on('click', function () {
    console.log("clicked on save button");
    AddNewUser();
});

function OnSuccess_(response) {
    var idata = response.d;
    console.log("saved successfully ");
    $(".jmodal").fadeOut("fast");
    $("#sec_box").load("window/p-data/002.html");
}
function OnErrorCall_(respo) {
    console.log(respo);
}
$(function () {
    console.log("add user data");
    $.ajax({
        type: "POST",
        url: "../Services/ScheduleData.asmx/GetBuilding",
        //data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessBuilding,
        error: OnErrorCall_
    });
});

function OnSuccessBuilding(respo) {
    var data = respo.d;
    var inner = [];
    for (i = 0; i < data.length; i++) {
        inner += '<option class="option" value="' + data[i] + '">' + data[i] + '</option>';
    }
    document.getElementById("selectedbuilding").innerHTML = inner;

    
}
function OnErrorCall_(respo) {
    console.log(respo);
}
