console.log("login page");

function Login() {    
    var userid = $("#userid").val();
    var password = $("#password").val();
    if (userid.trim().length > 0 && password.trim().length > 0) {        
        var d = { password: password, loginID:userid };
        var jsonData = JSON.stringify({
            data:  d
        });
        $.ajax({
            type: "POST",
            url: "../Services/UserLogs.asmx/Login",
            data: jsonData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            beforeSend: function (xhr) {
                xhr.setRequestHeader("STicket", "<%=strSecTckt %>");
            },
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
    if (data["status"] == "success") {
        var dd = data["value"];
        var ptype = dd["personType"];
        if (ptype == '永久') {
            sessionStorage.setItem("LoginId", dd["loginID"]);
            sessionStorage.setItem("userName", dd["userName"]);  
            window.location.href = "home.html";
        }
        else if (ptype == "temporary") {
            var len = moment(dd["validTill"]).toDate();
            var time1 = dd["expireTime"];
            var dates = moment(len).format('YYYY-MM-DD');
            var comparedate = moment(new Date()).format('YYYY-MM-DD');
            if (dates >= comparedate) {
                var today = new Date();
                var time2 = today.getHours() + ":" + today.getMinutes();
                if (time1 > time2) {
                    sessionStorage.setItem("LoginId", dd["loginID"]);
                    sessionStorage.setItem("userName", dd["userName"]);
                    window.location.href = "home.html";
                }
                else
                    alert("Your Account has Expired!!");
            }
            else {
                alert("Your Account has Expired!!");
            }
        }        
    }
    else {
        alert("LoginID or password incorrect");
    }
}
function OnErrorCall_(response) {
    console.log(response);
    alert("UserId or password is Incorrect. Please try again!");
}