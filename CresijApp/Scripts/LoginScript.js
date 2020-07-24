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
    if (data.length > 0) {
    var dd = data[0];
        var ptype = dd[2];
        if (ptype == 'longterm') {
            sessionStorage.setItem("LoginId", dd[0]);
            sessionStorage.setItem("userName", dd[1]);
            window.location.href = "home.html";
        }
        else if (ptype == "temporary") {
            var len = moment(dd[3]).toDate();
            var time1 = dd[4];
            var dates = moment(len).format('YYYY-MM-DD');
            var comparedate = moment(new Date()).format('YYYY-MM-DD');
            if (dates >= comparedate) {
                var today = new Date();
                var time2 = today.getHours() + ":" + today.getMinutes();
                if (time1 > time2) {
                    sessionStorage.setItem("LoginId", dd[0]);
                    sessionStorage.setItem("userName", dd[1]);
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