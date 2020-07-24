function getCourseSubMenu() {
    console.log("calling the course sub menu");
    
    var data = [];
    var userid = sessionStorage.getItem("LoginId")
    if (userid != null && userid != undefined && userid.length > 0) {
        data[0] = userid;
        data[1] = "coursesubmenu";
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

};

function OnSuccessSubmenu(response) {
    var data = response.d;
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
    
}
function OnErrorCallSubMenu(response) {
    console.log(response);
}