$(document).ready(function () {
    console.log("calling the user sub menu");
    
    var data = [];
    var userid = sessionStorage.getItem("LoginId")
    if (userid != null && userid != undefined && userid.length > 0) {
        data[0] = userid;
        data[1] = "basicdatasubmenu";
        var jsonData = JSON.stringify({
            data: data
        });
        $.ajax({
            type: "POST",
            url: "../Services/UserAuthorisation.asmx/GetUserSubMenu",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessSubmenu,
            error: OnErrorCallSubMenu
        });

    }

});

function OnSuccessSubmenu(response) {
    var data = response.d;
    var menus = data.join(",");
    if (menus.indexOf("basicdatasubmenu1") != -1) {
        $("#basicdatasubmenu1").attr("style", "display:block");
    }
    if (menus.indexOf("basicdatasubmenu2") != -1) {
        $("#basicdatasubmenu2").attr("style", "display:block");
    }
    if (menus.indexOf("basicdatasubmenu3") != -1) {
        $("#basicdatasubmenu3").attr("style", "display:block");
    }
    if (menus.indexOf("basicdatasubmenu4") != -1) {
        $("#basicdatasubmenu4").attr("style", "display:block");
    }
    if (menus.indexOf("basicdatasubmenu5") != -1) {
        $("#basicdatasubmenu5").attr("style", "display:block");
    }
    if (menus.indexOf("basicdatasubmenu6") != -1) {
        $("#basicdatasubmenu6").attr("style", "display:block");
    }
}
function OnErrorCallSubMenu(response) {
    console.log(response);
}