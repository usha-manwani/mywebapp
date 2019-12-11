var ipAddress = "172.168.11.50";
$(function () {
    var chat = $.connection.myHub;
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        console.log("hub connected");
        SetVolume = function (val) {
            var lastVal = this.document.getElementById("volchange").innerText;

            if (lastVal > val.value && val.value > 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 21 2B");
                if (parseInt(lastVal) > 10) {
                    val.value = parseInt(lastVal) - 10;
                    this.document.getElementById("volchange").innerText = parseInt(lastVal) - 10;
                }
                else {
                    val.value = 0;
                    this.document.getElementById("volchange").innerText = 0;
                }

            }
            else if (val.value == 0) {
                
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 22 2C");
                this.document.getElementById("volchange").innerText = 0;
                val.value = 0;

            }
            else if (lastVal < val.value) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 2A");
                if (parseInt(lastVal) < 90) {
                    val.value = parseInt(lastVal) + 10;
                    this.document.getElementById("volchange").innerText = parseInt(lastVal) + 10;
                }
                else {
                    val.value = 99;
                    this.document.getElementById("volchange").innerText = 99;
                }

            }
        };
    });
    
});