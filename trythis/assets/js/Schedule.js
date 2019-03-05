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
    alert("Start Time and End Time should be different !!");
}
function timewrong() {
    alert("Please insert time in right format\n Correct Format Should be for example - '00:00-00:00'");
}
function confirm() {
    alert("Schedule Saved Successfully!!");
}
function timevalue() {
    alert("please use different time hours!!")
}
function timeset() {
    alert("Please enter correct time!!\n Time is in 24 hour Format!! Start time should be earlier than stop time!!\n eg. - 22:00 - 23:59")
}
function importFile() {
    document.getElementById('uploadDiv').style.display = "block";
}
function importEmptyFile() {
    alert("Schedule data in excel file is not in required format.\n Please create excel file as below table format!!");
}
function AlertSuccess() {
    alert("Schedule successfully saved!!");
}
function AlertFail() {
    alert("Some error occured!! Please try again!!");
}
function fileFormat() {
    alert("Please insert data in excel without leave initial row(s)and column(s)!!");
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
            alert("please enter valid number!");
            textobj.value = "";
        }
    }
}
