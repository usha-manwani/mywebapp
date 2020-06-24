$(function () {
    console.log("checking user session");
    var loginid = sessionStorage.getItem("LoginId");
    var username = sessionStorage.getItem("userName");
    
    if ((loginid == "" || loginid == undefined || loginid.length == 0 || loginid == null) && (username == "" || username == undefined || username.length == 0 || username == null)) {
        console.log("no login id");
        sessionStorage.setItem("LoginId", null);
        sessionStorage.setItem("userName", null);
        window.location = "login.html";
    }
});
