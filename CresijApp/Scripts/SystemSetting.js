console.log("page loaded");
$(document).ready(function () {
    ('#submitButton').on('click', function SubmitInfo() {
        uploadlogo();
        console.log("submit button clicked");

    });
})

//$('#SchoolLogo').on('change',

function uploadlogo() {

    var logo = document.getElementById("SchoolLogo");
    var files = logo.files;
    if (files[0] != undefined && files[0] != null && files.length != 0) {
        $.ajax({
            url: '../../../Services/Handler.ashx',
            type: 'POST',
            data: new FormData($('form')[0]),
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $("#fileProgress").hide();
                $("#lblMessage").html("<b>" + file.name + "</b> has been uploaded.");
                $("#filepath").val(file.path);
                console.log("logo");
                SaveAllData();
            },
            error: function () {
                $("#fileProgress").hide();
                $("#lblMessage").html("<b>" + file.name + "</b> couldnt be uploaded.");
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $("progress").show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $("#fileProgress").attr({
                                value: e.loaded,
                                max: e.total
                            });
                        }
                    }, false);
                }
                return fileXhr;
            }
        });
    }
    else
        SaveAllData();
}
//});

function SaveAllData() {
    var scname = document.getElementsByName("SchoolName")[0].value;

    var scengname = document.getElementsByName("SchoolEngName")[0].value;

    var logo = $("#filepath").val();

    //reserve info
    if ($('input[name = "ReserveNonWorkDay"]').is(':checked'))
        var reservenonworkday = $('input[name = "ReserveNonWorkDay"]').val();
    else
        var reservenonworkday = "No";

    if ($('input[name = "ReserveAutoReview"]').is(':checked'))
        var reserveautoreview = $('input[name = "ReserveAutoReview"]').val();
    else
        var reserveautoreview = "No";
    var reservestartdate = $('input[name = "ReserveStartDate"]').val();
    var reservestopdate = $('input[name = "ReserveStopDate"]').val();
    //transfer info
    if ($('input[name = "TransferNonWorkDay"]').is(':checked'))
        var transfernonworkday = $('input[name = "TransferNonWorkDay"]').val();
    else
        var transfernonworkday = "No";

    if ($('input[name = "TransferAutoReview"]').is(':checked'))
        var transferautoreview = $('input[name = "TransferAutoReview"]').val();
    else
        var transferautoreview = "No";
    var transferstartdate = $('input[name = "TransferStartDate"]').val();
    var transferstopdate = $('input[name = "TransferStopDate"]').val();

    var sections = (function () {
        var valor = [];

        $('input[name = "Section"]').each(function () {
            if (this.checked) {
                var starttime = $(this).closest('td').find($('input[name = "starttime"]')).val();

                var stoptime = $(this).closest('td').find($('input[name = "stoptime"]')).val();
                var item = {
                    "Section": $(this).val(),
                    "Starttime": starttime,
                    "Stoptime": stoptime
                }
                valor.push(item);

            }
        });
        return valor;
    })();

    var days = (function () {

        var day = [];
        $('input[name = "weekday"]').each(function () {
            if (this.checked) {
                day.push($(this).val());
            }
        });
        return day;
    })();

    if ($("#holidaycheckbox").checked)
        var autoholiday = "Yes";
    else autoholiday = "No";
    var semstartdate = $('input[name = "semstartDate"]').val();
    var totalweeks = $('input[name = "totalweek"]').val();
    var semno = $('input[name = "semester"]:checked').val();
    var semname = $('#semname').text();
    var object = {
        "Schoolname": scname,
        "Schooleng": scengname,
        "Logourl": logo,
        "Resnonwork": reservenonworkday,
        "Resauto": reserveautoreview,
        "Resstartdate": reservestartdate,
        "Resstopdate": reservestopdate,
        "Transfernonwork": transfernonworkday,
        "Transferauto": transferautoreview,
        "Transferstart": transferstartdate,
        "Transferstop": transferstopdate,
        "Sectionselected": sections,
        "Dayselected": days,
        "Semesterstart": semstartdate,
        "Weeks": totalweeks,
        "Semesterno": semno,
        "Semestername": semname,
        "Autoholiday": autoholiday
    };

    var jsonData = JSON.stringify({
        data: object
    });

    $.ajax({
        type: 'POST',
        url: '../Services/SystemSetting.asmx/SaveSystemInfo',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        traditional: true,
        processData: false,
        data: jsonData,
        success: function (response) {
            alert("saved successfully");
            console.log(response.d);
        },
        error: function (respo) {
            alert("some issue occured");
            console.log(respo);
        }
    });
}

