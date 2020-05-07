$('#submitButton').off('click').on('click', function SubmitInfo() {
    console.log("submit button clicked");
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
        var section = [];
        $('input[name = "Section"]').each(function () {
            if (this.checked) {                
                var starttime = $(this).children('input[name = "starttime"]').val();
                var stoptime = $(this).children('input[name = "stoptime"]').val();
                section.push($(this).val());
                section.push(starttime);
                section.push(stoptime);
                valor.push(section);
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

    var semstartdate = $('input[name = "semstartDate"]').val();
    var totalweeks = $('input[name = "totalweek"]').val();
    var totalweeks = $('input[name = "semester"]:checked').val();
});

$('#SchoolLogo').on('change', function () {

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
});

