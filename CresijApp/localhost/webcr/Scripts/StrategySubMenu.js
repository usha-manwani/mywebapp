$(document).ready(function () {
    console.log("calling the user sub menu");
    var userid = sessionStorage.getItem("LoginId");
    var data = [];
   if (userid != null && userid != undefined && userid.length > 0) {
        data[0] = userid;
        data[1] = "strategysubmenu";
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
    if (menus.indexOf("strategysubmenu1") != -1) {
        $("#strategysubmenu1").attr("style", "display:block");
    }
    if (menus.indexOf("strategysubmenu2") != -1) {
        $("#strategysubmenu2").attr("style", "display:block");
    }
    //if (menus.indexOf("strategysubmenu3") != -1) {
    //    $("#strategysubmenu3").attr("style", "display:block");
    //}
    //if (menus.indexOf("strategysubmenu4") != -1) {
    //    $("#strategysubmenu4").attr("style", "display:block");
    //}
}
function OnErrorCallSubMenu(response) {
    console.log(response);
}