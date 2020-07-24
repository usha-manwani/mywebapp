$(document).ready(function () {
    console.log("calling the user top menu");
    var userid = sessionStorage.getItem("LoginId")
    if (userid != null && userid != undefined && userid.length > 0) {
        var jsonData = JSON.stringify({
            userid: userid
        });
        $.ajax({
            type: "POST",
            url: "../Services/UserAuthorisation.asmx/GetUserTopMenu",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessTopmenu,
            error: OnErrorCallTopMenu
        });

    }
    
});

function OnSuccessTopmenu(response) {
    console.log("Got the user top menu");
    var data = response.d;
    var menus = data.join(",");
    console.log("top menu list " + menus);
    if (menus.indexOf("equipment") != -1) {
        $("#machinetopmenu").attr("style", "display:block");
    }
    if (menus.indexOf("course") != -1) {
        $("#coursetopmenu").attr("style", "display:block");
    }
    if (menus.indexOf("strategy") != -1) {
        $("#strategytopmenu").attr("style", "display:block");
    }
    if (menus.indexOf("operate") != -1) {
        $("#operationtopmenu").attr("style", "display:block");        
    }
    if (menus.indexOf("basicdata") != -1) {
        $("#basicdatatopmenu").attr("style", "display:block");
    }
    if (menus.indexOf("settings") != -1) {
        $("#systemsettingtopmenu").attr("style", "display:block");
    }
    if (menus.indexOf("logs") != -1) {
        $("#logstopmenu").attr("style", "display:block");
    }


}

function OnErrorCallTopMenu(response) {
    console.log("Top menu error " + response);
}