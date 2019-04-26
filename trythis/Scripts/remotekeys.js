$(function(){
    var chat = $.connection.myHub;
    var ipAddress = "192.168.1.26";
    var tryingToReconnect = false;
    $.connection.hub.reconnecting(function () {
        tryingToReconnect = true;
        console.log("trying to reconnect");
    });
    $.connection.hub.reconnected(function () {
        tryingToReconnect = false;
        console.log("reconnected");
    });
    $.connection.hub.disconnected(function () {
        if (tryingToReconnect) {
            console.log("hub disconnected");
        }
    });
    chat.client.broadcastMessage = function (name, message) {
        if (name == ipAddress) {
            var arraydata = message.split(',');
            if (arraydata[1] == "Heartbeat") {
                if (arraydata[3] == 'OPEN') {
                    var img = document.getElementById("systempower");
                    img.src = "Images/icons/switchgreen.png";
                }
                else {
                    var img = document.getElementById("systempower");
                    img.src = "Images/icons/switchred.png";
                }
                if (arraydata[5] == 'On')
                {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/icons/pcgreen.png";
                }
                else
                {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/icons/pcred.png";
                }
                if (arraydata[12] == 'Locked')
                {
                    var src = document.getElementById('syslock');
                    src.src = "Images/icons/lockred.png";
                }
                else
                {
                    var src = document.getElementById('syslock');
                    src.src = "Images/icons/unlockgreen.png";
                }
                if (arraydata[13] == 'Locked')
                {
                    var src = document.getElementById('podiumlock');
                    src.src = "Images/icons/lockred.png";
                }
                else
                {
                    var src = document.getElementById('podiumlock');
                    src.src = "Images/icons/unlockgreen.png";
                }
                if (arraydata[14] == 'Locked')
                {
                    var src = document.getElementById('classlock');
                    src.src = "Images/icons/lockred.png";
                }
                else
                {
                    var src = document.getElementById('classlock');
                    src.src = "Images/icons/unlockgreen.png";
                }
                uncheck();
                switch (arraydata[11])
                {
                    case 'Desktop':
                        var desk = document.getElementById('desktop');
                        document.getElementById('desktop').checked = true;
                        $(desk).closest("td").find("img").attr('src', "Images/icons/deskgreen.png");

                        break;
                    case 'Laptop':
                        document.getElementById('laptop').checked = true;
                        var laptop = document.getElementById('laptop');
                        $(laptop).closest("td").find("img").attr('src', "Images/icons/lapgreen.png");

                        break;
                    case 'Digital Curtain':
                        document.getElementById('platform').checked = true;
                        $('#platform').closest("td").find("img").attr('src', "Images/icons/CurtainOpenGreen.png");
                        break;
                    case 'Digital Screen':
                        document.getElementById('digitalEquipment').checked = true;
                        $('#digitalEquipment').closest("td").find("img").attr('src', "Images/icons/scgreen.png");
                        break;
                    case 'DVD':
                        document.getElementById('dvd').checked = true;
                        $('#dvd').closest("td").find("img").attr('src', "Images/icons/dvd3.png");
                        break;
                    case 'TV':
                        document.getElementById('tv').checked = true;
                        $('#tv').closest("td").find("img").attr('src', "Images/icons/tvgreen.png");
                        break;
                    case 'Video Camera':
                        document.getElementById('camera').checked = true;
                        $('#camera').closest("td").find("img").attr('src', "Images/icons/camgreen.png");
                        break;
                    case 'Blu-Ray DVD':
                        document.getElementById('bluray').checked = true;
                        $('#bluray').closest("td").find("img").attr('src', "Images/icons/blu3.png");
                        break;
                    case 'Recording System':
                        document.getElementById('recorder').checked = true;
                        $('#recorder').closest("td").find("img").attr('src', "Images/icons/vidgreen.png");
                        break;
                }
                if (arraydata[6] == 'Closed')
                {
                    var src = document.getElementById("projectorOn");
                    src.src = "Images/icons/project3.png";
                }
                else
                {
                    var src = document.getElementById("projectorOn");
                    src.src = "Images/icons/project2.png";
                }
            }
            else
            {                
                    if (arraydata[1] == "KeyValue") {
                        switch (arraydata[2]) {
                            case 'SystemON':
                                var img = document.getElementById("systempower");
                                img.src = "Images/icons/switchgreen.png";
                                break;
                            case 'SystemOff':
                                var img = document.getElementById("systempower");
                                img.src = "Images/icons/switchred.png";
                                break;
                            case 'DSDown':
                                $('#dsdown').closest("td").find("img").attr('src', "Images/icons/scdowngreen.png");
                                $('#dsstop').closest("td").find("img").attr('src', "Images/icons/scstopred.PNG");
                                $('#dsup').closest("td").find("img").attr('src', "Images/icons/scupred.PNG");
                                break;
                            case 'DSUp':
                                $('#dsdown').closest("td").find("img").attr('src', "Images/icons/scdownred.PNG");
                                $('#dsstop').closest("td").find("img").attr('src', "Images/icons/scstopred.PNG");
                                $('#dsup').closest("td").find("img").attr('src', "Images/icons/scup.png");
                                break;
                            case 'DSStop':
                                $('#dsdown').closest("td").find("img").attr('src', "Images/icons/scdownred.PNG");
                                $('#dsstop').closest("td").find("img").attr('src', "Images/icons/scstopgreen.png");
                                $('#dsup').closest("td").find("img").attr('src', "Images/icons/scupred.PNG");
                                break;
                            default:
                                break
                        }
                    }
                    else if (arraydata[1] == "LEDIndicator") {
                        if (arraydata[2] == "SystemSwitchOn") {
                            var img = document.getElementById("systempower");
                            img.src = "Images/icons/switchgreen.png";
                            if (arraydata.length > 4) {
                                var imgpc = document.getElementById("pcpower");
                                switch (arraydata[4]) {
                                    case 'ComputerOff':
                                        imgpc.src = "Images/icons/pcred.png";
                                        break;
                                    case 'ComputerOn':
                                        imgpc.src = "Images/icons/pcgreen.png";
                                        break;
                                }
                            }
                            uncheck();
                            switch (arraydata[3]) {
                                case 'Desktop':
                                    document.getElementById('desktop').checked = true;
                                    $('#desktop').closest("td").find("img").attr('src', "Images/icons/deskgreen.png");
                                    break;
                                case 'Laptop':
                                    document.getElementById('laptop').checked = true;
                                    $('#laptop').closest("td").find("img").attr('src', "Images/icons/lapgreen.png");
                                    break;
                                case 'DigitalCurtain':
                                    document.getElementById('platform').checked = true;
                                    $('#platform').closest("td").find("img").attr('src', "Images/icons/curtain3.png");
                                    break;
                                case 'DigitalScreen':
                                    document.getElementById('digitalEquipment').checked = true;
                                    $('#digitalEquipment').closest("td").find("img").attr('src', "Images/icons/scgreen.png");
                                    break;
                                case 'DVD':
                                    document.getElementById('dvd').checked = true;
                                    $('#dvd').closest("td").find("img").attr('src', "Images/icons/dvd3.png");
                                    break;
                                case 'TV':
                                    document.getElementById('tv').checked = true;
                                    $('#tv').closest("td").find("img").attr('src', "Images/icons/tvgreen.png");
                                    break;
                                case 'VideoCamera':
                                    document.getElementById('camera').checked = true;
                                    $('#camera').closest("td").find("img").attr('src', "Images/icons/camgreen.png");
                                    break;
                                case 'Blu-RayDVD':
                                    document.getElementById('bluray').checked = true;
                                    $('#bluray').closest("td").find("img").attr('src', "Images/icons/blu3.png");
                                    break;
                                case 'RecordingSystem':
                                    document.getElementById('recorder').checked = true;
                                    $('#recorder').closest("td").find("img").attr('src', "Images/icons/vidgreen.png");
                                    break;
                            }
                        }
                        else if (arraydata[2] == "SystemSwitchOff") {
                            var img = document.getElementById("systempower");
                            img.src = "Images/icons/switchred.png";
                        }
                    }                
            }
        };
    };
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        console.log("connection started");
        $(document).on('click', '.toggle', function () {
            if (!$(this).next().hasClass('in')) {
                $(this).parent().children('.collapse').collapse('hide');
            }
            $(this).next().collapse('toggle');
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
            //$('[class^="displaynone"]').hide();
        });
        $(document).on("click", "#dvd", function () {            
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 14 1e");
        });
        $(document).on("click", "#tv", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 15 1f");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target');
            $(target).show();
        });
        $(document).on("click", "#bluray", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 1a 24");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target');
            $(target).show();
        });
        $(document).on("click", "#systempower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 18 22");            
        });
        $(document).on("click", "#pcpower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 17 21");
        });
        $(document).on("click", "#camera", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 16 20");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        });
        $(document).on("click", "#recorder", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 19 23");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        });
        $(document).on("click", "#volctrl", function () {            
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#sysctrl", function () {
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#projctrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#scrctrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#micCtrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#lightctrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#mediactrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        });
    })
    
    function uncheck() {
        $('#desktop').closest("td").find("img").attr('src', "Images/icons/deskwhite.png");
        $('#laptop').closest("td").find("img").attr('src', "Images/icons/lapwhite.png");
        $('#platform').closest("td").find("img").attr('src', "Images/icons/curtain1.png");
        $('#digitalEquipment').closest("td").find("img").attr('src', "Images/icons/scwhite.png");
        $('#dvd').closest("td").find("img").attr('src', "Images/icons/dvd1.png");
        $('#bluray').closest("td").find("img").attr('src', "Images/icons/blu1.png");
        $('#tv').closest("td").find("img").attr('src', "Images/icons/tvwhite.png");
        $('#camera').closest("td").find("img").attr('src', "Images/icons/camwhite.png");
        $('#recorder').closest("td").find("img").attr('src', "Images/icons/vidwhite.png");
    };   
})
