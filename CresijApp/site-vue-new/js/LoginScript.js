/* global $ */
function logoinActiviti(password, userid, cb) {
  var fd = new FormData();
  fd.append("password", password);
  fd.append("username", userid);
  $.ajax({
    type: "POST",
    url: "/activiti/login",
    timeout: 10 * 1000, //超时时间设置，单位毫秒
    processData: false, // 告诉jQuery不要去处理发送的数据
    contentType: false, // 告诉jQuery不要去设置Content-Type请求头
    data: fd,
    success: cb,
    error: cb,
  });
}
function Login() {
  var userid = $("#userid").val();
  var password = $("#password").val();
  if (userid.trim().length > 0 && password.trim().length > 0) {
    var d = { password: password, loginID: $("#userid").val() };
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
    $(".messagebox").text("please insert LoginID and password");
    $(".alert")
      .addClass("show")
      .show();
  }
}

function OnSuccessLogin(response) {
  var data = response.d;
  if (data["status"] == "success") {
    var dd = data["value"];
    sessionStorage.setItem("userName", dd["userName"]);
    sessionStorage.setItem("userNameID", $("#userid").val());
    logoinActiviti($("#password").val(), $("#userid").val(), () => {
      setTimeout(() => {
        window.location.replace("home.html");
      }, 100);
    });
  } else {
    $(".messagebox").text("LoginID or password incorrect");
    $(".alert")
      .addClass("show")
      .show();
  }
}
function OnErrorCall_(response) {
  console.log(response);
  $(".messagebox").text("UserId or password is Incorrect. Please try again!");
  $(".alert")
    .addClass("show")
    .show();
}
