console.log("login page");

function Login() {
    
    var userid = $("#userid").val();
    var password = $("#password").val();
    if (userid.trim().length > 0 && password.trim().length > 0) {
        var data = [];
        data.push(userid);
        data.push(password);
        var jsonData = JSON.stringify({
            data: data
        });
        $.ajax({
            type: "POST",
            url: "../Services/UserLogs.asmx/Login",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessLogin,
            error: OnErrorCall_
        });
    }
    else {
        alert("please insert LoginID and password");
    }
}

function OnSuccessLogin(response) {
    var data = response.d;
    var dd = data[0];
    sessionStorage.setItem("LoginId", dd[0]);
    sessionStorage.setItem("userName", dd[1]);
    window.location.href = "home.html";

}
function OnErrorCall_(response) {
    console.log(response);
    alert("UserId or password is Incorrect. Please try again!");
}