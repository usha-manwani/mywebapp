﻿function displayoption() {
    var modal = document.getElementById("roleModal");
    modal.style.display = "block";
    return false;
}
function close3() {
    var modal = document.getElementById("roleModal");
    modal.style.display = "none";
}
function norole() {
    var message = ' <%=Resources.Resource.ApproveError%>'
    alert(message);
}
