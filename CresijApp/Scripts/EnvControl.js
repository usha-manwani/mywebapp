$ = jQuery.noConflict();
var ipAddress = "";
$(function () {
    var chat = $.connection.myHub;

    chat.client.envMessage = function (name, message) {
        if (name == ipAddress) {

        }
    };
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        console.log("hub connected , Hub id " + $.connection.hub.id);
        chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
        $(document).on("change", "#light1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 78 82");           
        });
        $(document).on("change", "#light2", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 68 72");
        });
        $(document).on("change", "input[name='env']", function () {
            if (this.value == 'open')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 46 50");
            else if (this.value = 'close')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 47 51");
            else if (this.value = 'stop')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 48 52");
        });
        $(document).on("change", "input[name='env2']", function () {
            if (this.value == 'open')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 49 53");
            else if (this.value = 'close')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 4a 54");
            else if (this.value = 'stop')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 4b 55");
        });
        $(document).on("change", "#ac1", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 59 63");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5A 64");
            }
        });
        $(document).on("change", "#ac2", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 59 63");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5A 64");
            }
        });
        $(document).on("change", "#ac2", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 59 63");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5A 64");
            }
        });
        $(document).on("change", "#ac2", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 59 63");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5A 64");
            }
        });
    });
});