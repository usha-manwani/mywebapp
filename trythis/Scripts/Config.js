$(function () {
    var chat = $.connection.myHub;
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        $(document).on('click', '#btnSetup', function () {

        });
    });
});
