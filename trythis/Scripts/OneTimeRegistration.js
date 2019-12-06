$(function () {
    $("#MainContent_datepicker").datetimepicker(
        {
            format:'yyyy-mm-dd',
            minView:2,
            todayHighlight: true,
            autoclose: true,
        });

    $("#MainContent_starttimepicker").datetimepicker(
        {
            format: 'hh:ii',            
            startView: 1,
            maxView: 1,
            showMeridian: false,
            todayHighlight: true,
            autoclose: true,
            viewSelect: 'hour',
            setStartDate:'2019-12-06',
        });
    $("#MainContent_stoptimepicker").datetimepicker(
        {
            format: 'hh:ii',
            pickDate: false,
            startView: 1,
            maxView: 1,
            showMeridian: false,
            todayHighlight: true,
            autoclose: true,
            viewSelect:'hour',
        });
    $(".timepicker").find('thead th').remove();
    $(".timepicker").find('thead').append($('<th class="switch">').text('Pick Time'));
    
});

function SuccessRegistration(ip,message) {
    alert(message);
    window.location.href = "../Scan/MobileLogin.aspx?ip=" + ip;
}

function showtip() {
    $('#passlength').attr('style', 'display:block');
}

function hidetip() {
    $('#passlength').attr('style', 'display:none');
}

