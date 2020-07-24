$(document).ready(function () {
    console.log("calling the user sub menu");
    var userid = sessionStorage.getItem("LoginId");
    var data = [];
    if (userid != null && userid != undefined && userid.length > 0) {
        data[0] = userid;
        data[1] = "operatesubmenu";
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
    if (menus.indexOf("operatesubmenu1") != -1) {
        $("#operatesubmenu1").attr("style", "display:block");
    }
    if (menus.indexOf("operatesubmenu2") != -1) {
        $("#operatesubmenu2").attr("style", "display:block");
    }
    if (menus.indexOf("operatesubmenu3") != -1) {
        $("#operatesubmenu3").attr("style", "display:block");
    }
    if (menus.indexOf("operatesubmenu4") != -1) {
        $("#operatesubmenu4").attr("style", "display:block");
    }
}
function OnErrorCallSubMenu(response) {
    console.log(response);
}