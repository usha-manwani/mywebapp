function getCourseSubMenu() {
    console.log("calling the course sub menu");
    $.ajax({
        type: "POST",
        url: "../Services/UserAuthorisation.asmx/GetUserSubMenu",
        data: JSON.stringify({subMenuType:"coursesubmenu"}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var data = response.d.SubMenu;
            var menus = data.join(",");
            if (menus.indexOf("coursesubmenu1") != -1) {
                $("#coursesubmenu1").attr("style", "display:block");
            }
            if (menus.indexOf("coursesubmenu2") != -1) {
                $("#coursesubmenu2").attr("style", "display:block");
            }
            if (menus.indexOf("coursesubmenu3") != -1) {
                $("#coursesubmenu3").attr("style", "display:block");
            }
            if (menus.indexOf("coursesubmenu4") != -1) {
                $("#coursesubmenu4").attr("style", "display:block");
            }
            if (menus.indexOf("coursesubmenu5") != -1) {
                $("#coursesubmenu5").attr("style", "display:block");
            }
            
        },
        error: OnErrorCallSubMenu
    });

};


function OnErrorCallSubMenu(response) {
    console.log(response);
}