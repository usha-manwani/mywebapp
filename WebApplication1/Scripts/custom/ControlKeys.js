$(function () {

    var getSessionValue = $('#sessionInput').val();
    alert("Selected Multimedia ControlDevice IP is " + getSessionValue);
    var ipAddress = getSessionValue;

    var chat = $.connection.hubMessage;
    chat.client.broadcastMessage = function (name, message) {
        if (name == ipAddress) {
            var arraydata = message.split(',');
            if (arraydata[1] == "Heartbeat") {
                if (arraydata[3] == 'OPEN') {
                    var img = document.getElementById("systempower");
                    img.src = "Images/powerOn.png";
                }
                else {
                    var img = document.getElementById("systempower");
                    img.src = "Images/powerOff.png";
                }
                if (arraydata[5] == 'On') {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/powerOn.png";
                }
                else {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/powerOff.png";
                }
                if (arraydata[12] == 'Locked') {
                    var src = document.getElementById('syslock');
                    src.src = "Images/lock.png";
                }
                else {
                    var src = document.getElementById('syslock');
                    src.src = "Images/unlock.png";
                }
                if (arraydata[13] == 'Locked') {
                    var src = document.getElementById('podiumlock');
                    src.src = "Images/lock.png";
                }
                else {
                    var src = document.getElementById('podiumlock');
                    src.src = "Images/unlock.png";
                }
                if (arraydata[14] == 'Locked') {
                    var src = document.getElementById('classlock');
                    src.src = "Images/lock.png";
                }
                else {
                    var src = document.getElementById('classlock');
                    src.src = "Images/unlock.png";
                }
                switch (arraydata[11]) {
                    case 'Desktop':
                        document.getElementById('desktop').checked = true;
                        break;
                    case 'Laptop':
                        document.getElementById('laptop').checked = true;
                        break;
                    case 'Digital Curtain':
                        document.getElementById('platform').checked = true;
                        break;
                    case 'Digital Screen':
                        document.getElementById('digitalEquipment').checked = true;
                        break;
                    case 'DVD':
                        document.getElementById('dvd').checked = true;
                        break;
                    case 'TV':
                        document.getElementById('tv').checked = true;
                        break;
                    case 'Video Camera':
                        document.getElementById('camera').checked = true;
                        break;
                    case 'Blu-Ray DVD':
                        document.getElementById('bluray').checked = true;
                        break;
                    case 'Recording System':
                        document.getElementById('recorder').checked = true;
                        break;
                }

                if (arraydata[13] == 'Closed') {

                } else {

                }

            }
            else {
                for (j = 2; j < arraydata.length; j++) {
                    if (arraydata[1] == "KeyValue") {
                        switch (arraydata[2]) {
                            case 'SystemON':
                                var img = document.getElementById("systempower");
                                img.src = "Images/powerOn.png";
                                break;
                            case 'SystemOff':
                                var img = document.getElementById("systempower");
                                img.src = "Images/powerOff.png";
                                break;
                            default:
                                break
                        }
                    }
                    else if (arraydata[1] == "LEDIndicator") {

                        if (arraydata[2] == "SystemSwitchOn") {
                            var img = document.getElementById("systempower");
                            img.src = "Images/powerOn.png";
                            if (arraydata.length > 4) {
                                var imgpc = document.getElementById("pcpower");
                                switch (arraydata[4]) {
                                    case 'ComputerOff':

                                        imgpc.src = "Images/powerOff.png";
                                        break;
                                    case 'ComputerOn':
                                        imgpc.src = "Images/powerOn.png";
                                        break;
                                }

                            }
                            switch (arraydata[3]) {


                                case 'Desktop':
                                    document.getElementById('desktop').checked = true;

                                    break;
                                case 'Laptop':
                                    document.getElementById('laptop').checked = true;
                                    break;
                                case 'DigitalCurtain':
                                    document.getElementById('platform').checked = true;
                                    break;
                                case 'DigitalScreen':
                                    document.getElementById('digitalEquipment').checked = true;
                                    break;
                                case 'DVD':
                                    document.getElementById('dvd').checked = true;
                                    break;
                                case 'TV':
                                    document.getElementById('tv').checked = true;
                                    break;
                                case 'VideoCamera':
                                    document.getElementById('camera').checked = true;
                                    break;
                                case 'Blu-RayDVD':
                                    document.getElementById('bluray').checked = true;
                                    break;
                                case 'RecordingSystem':
                                    document.getElementById('recorder').checked = true;
                                    break;
                                case 'TurnOffLights':
                                    tab.rows[i].cells[10].innerHTML = 'Off';
                                    break;
                                case 'CentralLocking':
                                    tab.rows[i].cells[12].innerHTML = 'Locked';
                                    break;
                                case 'PodiumLock':
                                    tab.rows[i].cells[13].innerHTML = 'Locked';
                                    break;
                                case 'ClassLock':
                                    tab.rows[i].cells[14].innerHTML = 'Locked';
                                    break;

                            }
                        }
                        else if (arraydata[2] == "SystemSwitchOff") {
                            var img = document.getElementById("systempower");
                            img.src = "Images/powerOff.png";
                        }
                    }

                }
            }
        };
    };
    var tryingToReconnect = false;

    $.connection.hub.reconnecting(function () {
        tryingToReconnect = true;
        alert("trying to reconnect");
    });

    $.connection.hub.reconnected(function () {
        tryingToReconnect = false;
        alert("reconnected");
    });

    $.connection.hub.disconnected(function () {
        if (tryingToReconnect) {
            alert("hub disconnected");
        }
    });

    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        chat.server.sendData();
        $(document).on("click", "#systempower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 18 22");
        });
        $(document).on("click", "#syslock", function () {
            var src = document.getElementById('syslock');
            if (src.src == "Images/unlock.png")
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
        });
        $(document).on("click", "#podiumlock", function () {
            var src = document.getElementById('podiumlock');
            if (src.src == "Images/unlock.png")
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2e 38");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2f 39");
        });
        $(document).on("click", "#classlock", function () {
            var src = document.getElementById('classlock');
            if (src.src == "Images/unlock.png")
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5f 69");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 60 6A");
        });
        $(document).on("click", "#dsup", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5f 6A");
        });
        $(document).on("click", "#dcopen", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#dsstop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#dcstop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#dsdown", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#dcclose", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#desktop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 10 1A");
        });
        $(document).on("click", "#laptop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 11 1b");
        });
        $(document).on("click", "#platform", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 12 1c");
        });
        $(document).on("click", "#digitalEquipment", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 13 1d");
        });
        $(document).on("click", "#dvd", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 14 1e");
        });
        $(document).on("click", "#tv", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 15 1f");
        });
        $(document).on("click", "#bluray", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 1a 24");
        });
        $(document).on("click", "#camera", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 16 20");
        });
        $(document).on("click", "#recorder", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 19 23");
        });
        $(document).on("click", "#projectorOn", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 33 3d");
        });
        $(document).on("click", "#projectorOff", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 43 4d");
        });
        $(document).on("click", "#hdmi", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 34 3E");
        });
        $(document).on("click", "#projVideo", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 35 3f");
        });
        $(document).on("click", "#vga", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 44 4e");
        });
        $(document).on("click", "#volminus", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 21 2b");
        });
        $(document).on("click", "#volplus", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 2a");
        });
        $(document).on("click", "#mute", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 22 2c");
        });
        $(document).on("click", "#wiredvolplus", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 23 2d");
        });
        $(document).on("click", "#wiredmute", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 25 2f");
        });
        $(document).on("click", "#wiredvolminus", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 24 2e");
        });
        $(document).on("click", "#wirelessvolplus", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 73 7d");
        });
        $(document).on("click", "#wirelessvolminus", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 74 7e");
        });
        $(document).on("click", "#wirelessmute", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 75 7f");
        });
    });
});