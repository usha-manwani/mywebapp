/* global $ */
function Login() {
  var userid = $("#userid").val();
  var password = $("#password").val();
  if (userid.trim().length > 0 && password.trim().length > 0) {
    var d = { password: password, loginID: userid };
    var jsonData = JSON.stringify({
      data: d,
    });
    $.ajax({
      type: "POST",
      url: "../Services/UserLogs.asmx/Login",
      data: jsonData,
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: OnSuccessLogin,
      error: OnErrorCall_,
    });
  } else {
    $('.messagebox').text("please insert LoginID and password");
    $('.alert').addClass('show').show()
  }
}

function OnSuccessLogin(response) {
  var data = response.d;
  if (data["status"] == "success") {
    var dd = data["value"];
    sessionStorage.setItem("userName", dd["userName"]);
    window.location.replace("home.html");
  } else {
    $('.messagebox').text("LoginID or password incorrect");
    $('.alert').addClass('show').show()
  }
}
function OnErrorCall_(response) {
  console.log(response);
  $('.messagebox').text("UserId or password is Incorrect. Please try again!");
  $('.alert').addClass('show').show()
}
