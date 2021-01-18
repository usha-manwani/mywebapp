$(function () {
    console.log("checking user session");
    var username = sessionStorage.getItem("userName");
    
    if ((username == "" || username == undefined || username.length == 0 || username == null)) {
        console.log("no login id");
        sessionStorage.setItem("userName", null);
        window.location = "./login.html";
    }
});
