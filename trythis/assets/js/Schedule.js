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
    for (i = 0; i < tab.length;i++) {
        alert("gone");
    }

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