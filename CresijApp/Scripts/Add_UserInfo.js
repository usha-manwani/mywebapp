function AddNewUser() {
    var myarray = new Array();
    myarray[0] = document.getElementById("id").value;
    myarray[1] = document.getElementById("name").value;    
    myarray[2] = document.getElementById("persontype").value;
    myarray[3] = document.getElementById("dept").value;
    myarray[4] = "not active";
    myarray[5] = document.getElementById("phone").value;
    myarray[6] = document.getElementById("notes").value;
    myarray[7] = document.getElementById("pass").value;
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
