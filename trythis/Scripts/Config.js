$(function () {
    var chat = $.connection.myHub;
    chat.client.broadcastMessage = function (name, message) {
        var arraydata = message.split(',');
        if (arraydata[0] == "config") {
            var delay = document.getElementById("delaymin");
            switch (arraydata[1]) {
                case "1":
                    delay.selectedIndex = "0";
                    break;
                case "2":
                    delay.selectedIndex = "1";
                    break;
                case "3":
                    delay.selectedIndex = "2";
                    break;
                case "4":
                    delay.selectedIndex = "3";
                    break;
                case "5":
                    delay.selectedIndex = "4";
                    break;
                case "6":
                    delay.selectedIndex = "5";
                    break;
                case "7":
                    delay.selectedIndex = "6";
                    break;
                case "8":
                    delay.selectedIndex = "7";
                    break;
                case "9":
                    delay.selectedIndex = "8";
                    break;
            }
        }     
    };
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        $(document).on('click', '#readConfig', function () {
            chat.server.sendControlKeys("192.168.1.26","8B B9 00 03 03 02 08");
        });
    });
});
