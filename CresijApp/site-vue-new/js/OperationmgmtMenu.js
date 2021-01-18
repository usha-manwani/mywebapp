$(document).ready(function () {
    console.log("calling the user sub menu");
    $.ajax({
        type: "POST",
        url: "../Services/UserAuthorisation.asmx/GetUserSubMenu",
        data: JSON.stringify({subMenuType:"operatesubmenu"}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var data = response.d.SubMenu;
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
        },
        error: OnErrorCallSubMenu
    });

});

function OnErrorCallSubMenu(response) {
    console.log(response);
}