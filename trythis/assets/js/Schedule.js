$(function () {
    $(document).on('click', '.rowstylealt', function () {
        $(this).addClass("selected").siblings().removeClass("selected");
    });
    $(document).on('click', '.rowstyle', function () {
        $(this).addClass("selected").siblings().removeClass("selected");
    });
    $(document).on('click', '.datepicker', function () {
        $(this).datepicker({ dateFormat: 'dd/mm/yy' });
    });
});
function checkTime() {
    var tab = document.getElementById("txtTime");
    for (i = 0; i < tab.length; i++) {
        alert("gone");
    }
}
function timeset2() {
    alert("same time");
}
function timesetSame() {
    var message = ' <%=Resources.Resource.AlertTime%>'
    alert(message);
}
function timewrong() {
    var message = ' <%=Resources.Resource.AlertTime2%>'
    alert(message);
}
function confirm() {
    var message = ' <%=Resources.Resource.AlertTime3%>'
    alert(message);
}
function timevalue() {
    alert("please use different time hours!!")
}
function timeset() {
    var message = ' <%=Resources.Resource.AlertTime4%>'
    alert(message);
}
function importFile() {
    document.getElementById('uploadDiv').style.display = "block";
}
function importEmptyFile() {
    var message = ' <%=Resources.Resource.AlertTime5%>'
    alert(message);
}
function AlertSuccess() {
    var message = ' <%=Resources.Resource.AlertTime3%>'
    alert(message);
}
function AlertFail() {
    var message = ' <%=Resources.Resource.AlertError1%>'
    alert(message);
}
function fileFormat() {
    var message = ' <%=Resources.Resource.AlertTime6%>'
    alert(message);
}
function text_changed(textobj) {
    var val = textobj.value;
    var regex = /^[0-9]+$/;
    if (val.match(regex)) {
        if (val > 10 || val < 0 && val != "") {
            alert("Please insert correct value. you can delay the boot from 0 to 10 minutes only.");
            textobj.value = "";
        }
    }
    else {
        if (val != "") {
            var message = ' <%=Resources.Resource.AlertError2%>'
            alert(message);
            textobj.value = "";
        }
    }
}
