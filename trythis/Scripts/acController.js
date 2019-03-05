$(function () {
    // Declare a proxy to reference the hub.
    var chat = $.connection.myHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) { };
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        $(document).on('click', "#c1open", function () {
            chat.server.sendControlKeys("","8B B9 00 04 02 04 77 81")
        });
        $(document).on('click', "#c1stop", function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 67 71")
        });
        $(document).on('click', "#c1close",function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 57 51")
        });
        $(document).on('click', "#c2open", function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 63 6d")
        });
        $(document).on('click', "#c2stop", function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 65 6F")
        });
        $(document).on('click', "#c2close",function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 64 6E")
        });
        $(document).on('click', "#c3open", function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 46 50")
        });
        $(document).on('click', "#c3stop", function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 48 52")
        });
        $(document).on('click', "#c3close",function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 47 51")
        });
        $(document).on('click', "#c4open", function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 49 53")
        });
        $(document).on('click', "#c4stop", function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 4b 55")
        });
        $(document).on('click', "#c4close",function () {
            chat.server.sendControlKeys("", "8B B9 00 04 02 04 4a 54")
        });
    });
});