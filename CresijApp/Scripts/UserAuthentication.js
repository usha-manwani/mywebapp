function SaveUserAuthentication() {
    var userid = sessionStorage.getItem("LoginId")
    if (userid != null && userid != undefined && userid.length > 0) {
        var us = $("#userId").val();
        var myarray = new Array();
        console.log("save auth ");
        var authmenu = [];
        $("input[name='authenticationmenu']:checked").each(function () {
            authmenu.push($(this).val());

        });
        myarray[0] = authmenu.join(",");
        var authloc = [];
        $("input[name='classlist']:checked").each(function () {
            authloc.push($(this).val());


        });
        myarray[1] = authloc.join(",");
        myarray[2] = userid;
        myarray[3] = us;
        var jsonData = JSON.stringify({
            name: myarray
        });
        $.ajax({
            type: "POST",
            url: "../Services/UserAuthorisation.asmx/SaveUserAuthentications",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessSaveAuth,
            error: OnErrorCallSaveAuth
        });

    }
   
}

function OnSuccessSaveAuth(response) {

    var data = response.d;
    if (data > 0) {
        alert("User authorisation details successfully saved");
        $(".jmodal").fadeOut("fast");
    }
}

function OnErrorCallSaveAuth(respo) {
    console.log(respo);
    console.log(respo.message);
}