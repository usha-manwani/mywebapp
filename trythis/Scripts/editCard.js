function showGrid() {
    var tbscan = document.getElementById('tablescan');
    tbscan.style.display = "none";
    var gridmodal = document.getElementById('griddiv');
    gridmodal.style.display = "block";
    return false;
}
function hideGrid() {
    document.getElementById("checkcard").value = "";    
    var mymodal = document.getElementById('myModal');
    mymodal.style.display = 'none';
    alert("Please check status of card !! ");
    return false;
}
function HideTree() {
    var modal = document.getElementById('modalAccess');
    modal.style.display = "none";
    inputs = document.getElementsByTagName("input");
    for (i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            inputs[i].checked = false;
        }
    }
}
function xx() {
    var modal = document.getElementById('myModal');
    modal.style.display = "none";      
}
$(document).on("click", ".close1", function () {
    var modal = document.getElementById('modalAccess');
    modal.style.display = "none";
    inputs = document.getElementsByTagName("input");
    for (i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            inputs[i].checked = false;
        }
    }
});
$(document).on("click", ".linkcursor", function () {
    var modal = document.getElementById('modalAccess');
    modal.style.display = "block";
});

window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

$(document).on("click", '<%#btnToSelect.ClientID%>', function () {

    var modal = document.getElementById('modalAccess');
    modal.style.display = "none";
    inputs = document.getElementsByTagName("input");
    for (i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            inputs[i].checked = false;
        }
    }
});