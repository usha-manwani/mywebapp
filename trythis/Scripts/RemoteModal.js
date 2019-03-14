var ipAddress="";
function uncheck() {
    $('#desktop').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_158.png");

    $('#laptop').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_160.png");

    $('#platform').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_194.png");

    $('#digitalEquipment').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_194.png");

    $('#dvd').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_246.png");

    $('#bluray').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_272.png");

    $('#tv').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_298.png");

    $('#camera').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_220.png");
    $('#recorder').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_324.png");
}

function offdevices() {

    $('#systempower').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_212.png");
    $('#pcpower').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_212.png");
    $('#syslock').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_214.png");
    $('#podiumlock').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_262.png");
    $('#classlock').closest("td").find("img").attr('src', "Images/详细页图标/images/图标_236.png");
}


$(function () {   
     
    var chat = $.connection.myHub;
    ipAddress = document.getElementById("sessionInputIP").value;
    chat.client.broadcastMessage = function (name, message) {
       
        if (name == ipAddress) {
            var arraydata = message.split(',');
            if (arraydata[1] == "Heartbeat") {
                if (arraydata[3] == 'OPEN') {
                    var img = document.getElementById("systempower");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_02.png";
                }
                else {
                    var img = document.getElementById("systempower");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态2_01.png"  ;
                }
                if (arraydata[5] == 'On') {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_02.png";
                }
                else {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态2_01.png"  ;
                }
                if (arraydata[12] == 'Locked') {
                    var src = document.getElementById('syslock');
                    src.src = "Images/中控首页按钮/首页按钮-显示状态/面板锁定_07.png";
                }
                else {
                    var src = document.getElementById('syslock');
                    src.src = "Images/中控首页按钮/首页按钮-显示状态/面板锁定_09.png";
                }
                if (arraydata[13] == 'Locked') {
                    var src = document.getElementById('podiumlock');
                    src.src = "Images/中控首页按钮/首页按钮-显示状态/面板锁定_07.png";
                }
                else {
                    var src = document.getElementById('podiumlock');
                    src.src = "Images/中控首页按钮/首页按钮-显示状态/面板锁定_09.png";
                }
                if (arraydata[14] == 'Locked') {
                    var src = document.getElementById('classlock');
                    src.src = "Images/中控首页按钮/首页按钮-显示状态/面板锁定_07.png";
                }
                else {
                    var src = document.getElementById('classlock');
                    src.src = "Images/中控首页按钮/首页按钮-显示状态/面板锁定_09.png";
                }
                uncheck();
                switch (arraydata[11]) {
                    case 'Desktop':
                        var desk = document.getElementById('desktop');
                        document.getElementById('desktop').checked = true;
                        $(desk).closest("td").find("img").attr('src', "Images/中控首页按钮/首页按钮-鼠标经过状态/控制页面-鼠标经过页面_01_80.png");

                        break;
                    case 'Laptop':
                        document.getElementById('laptop').checked = true;
                        var laptop = document.getElementById('laptop');
                        $(laptop).closest("td").find("img").attr('src', "Images/中控首页按钮/首页按钮-鼠标经过状态/控制页面-鼠标经过页面_01_82.png");

                        break;
                    case 'Digital Curtain':
                        document.getElementById('platform').checked = true;
                        $('#platform').closest("td").find("img").attr('src', "Images/onimages/projector.png");
                        break;
                    case 'Digital Screen':
                        document.getElementById('digitalEquipment').checked = true;
                        $('#digitalEquipment').closest("td").find("img").attr('src', "Images/onimages/projector.png");
                        break;
                    case 'DVD':
                        document.getElementById('dvd').checked = true;
                        $('#dvd').closest("td").find("img").attr('src', "Images/onimages/dvdon.png");
                        break;
                    case 'TV':
                        document.getElementById('tv').checked = true;
                        $('#tv').closest("td").find("img").attr('src', "Images/onimages/tv.png");
                        break;
                    case 'Video Camera':
                        document.getElementById('camera').checked = true;
                        $('#camera').closest("td").find("img").attr('src', "Images/onimages/camera.png");
                        break;
                    case 'Blu-Ray DVD':
                        document.getElementById('bluray').checked = true;
                        $('#bluray').closest("td").find("img").attr('src', "Images/onimages/bluraydvd.png");
                        break;
                    case 'Recording System':
                        document.getElementById('recorder').checked = true;
                        $('#recorder').closest("td").find("img").attr('src', "Images/onimages/recorder.png");
                        break;
                }

                if (arraydata[6] == 'Closed') {
                    var src = document.getElementById("projectorOn");
                    src.src = "Images/offimages/proj1.png";
                } else {
                    var src = document.getElementById("projectorOn");
                    src.src = "Images/onimages/projectoron1.png";
                }

            }
            else {
                for (j = 2; j < arraydata.length; j++) {
                    if (arraydata[1] == "KeyValue") {
                        switch (arraydata[2]) {
                            case 'SystemON':
                                var img = document.getElementById("systempower");
                                img.src = "Images/onimages/syspoweron.png";
                                break;
                            case 'SystemOff':
                                var img = document.getElementById("systempower");
                                img.src = "Images/offimages/sysof.png";
                                break;
                            case 'DSDown':
                                $('#dsdown').closest("td").find("img").attr('src', "Images/onimages/down.png");
                                $('#dsstop').closest("td").find("img").attr('src', "Images/offimages/stopscreen.PNG");
                                $('#dsup').closest("td").find("img").attr('src', "Images/offimages/up.PNG");
                                break;
                            case 'DSUp':
                                $('#dsdown').closest("td").find("img").attr('src', "Images/offimages/screendown.PNG");
                                $('#dsstop').closest("td").find("img").attr('src', "Images/offimages/stopscreen.PNG");
                                $('#dsup').closest("td").find("img").attr('src', "Images/onimages/up.png");
                                break;
                            case 'DSStop':
                                $('#dsdown').closest("td").find("img").attr('src', "Images/offimages/screendown.PNG");
                                $('#dsstop').closest("td").find("img").attr('src', "Images/onimages/stop.png");
                                $('#dsup').closest("td").find("img").attr('src', "Images/offimages/up.PNG");
                                break;
                            default:
                                break
                        }
                    }
                    else if (arraydata[1] == "LEDIndicator") {

                        if (arraydata[2] == "SystemSwitchOn") {
                            var img = document.getElementById("systempower");
                            img.src = "Images/onimages/syspoweron.png";
                            if (arraydata.length > 4) {
                                var imgpc = document.getElementById("pcpower");
                                switch (arraydata[4]) {
                                    case 'ComputerOff':

                                        imgpc.src = "Images/offimages/pcof.png";
                                        break;
                                    case 'ComputerOn':
                                        imgpc.src = "Images/onimages/pcpoweron.png";
                                        break;
                                }

                            }
                            uncheck();
                            switch (arraydata[3]) {
                                case 'Desktop':
                                    document.getElementById('desktop').checked = true;
                                    $('#desktop').closest("td").find("img").attr('src', "Images/onimages/desktop.png");
                                    break;
                                case 'Laptop':
                                    document.getElementById('laptop').checked = true;
                                    $('#laptop').closest("td").find("img").attr('src', "Images/onimages/laptopon.png");
                                    break;
                                case 'DigitalCurtain':
                                    document.getElementById('platform').checked = true;
                                    $('#platform').closest("td").find("img").attr('src', "Images/onimages/projector.png");
                                    break;
                                case 'DigitalScreen':
                                    document.getElementById('digitalEquipment').checked = true;
                                    $('#digitalEquipment').closest("td").find("img").attr('src', "Images/onimages/projector.png");
                                    break;
                                case 'DVD':
                                    document.getElementById('dvd').checked = true;
                                    $('#dvd').closest("td").find("img").attr('src', "Images/onimages/dvdon.png");
                                    break;
                                case 'TV':
                                    document.getElementById('tv').checked = true;
                                    $('#tv').closest("td").find("img").attr('src', "Images/onimages/tv.png");
                                    break;
                                case 'VideoCamera':
                                    document.getElementById('camera').checked = true;
                                    $('#camera').closest("td").find("img").attr('src', "Images/onimages/camera.png");
                                    break;
                                case 'Blu-RayDVD':
                                    document.getElementById('bluray').checked = true;
                                    $('#bluray').closest("td").find("img").attr('src', "Images/onimages/bluraydvd.png");
                                    break;
                                case 'RecordingSystem':
                                    document.getElementById('recorder').checked = true;
                                    $('#recorder').closest("td").find("img").attr('src', "Images/onimages/recorder.png");
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
                            img.src = "Images/offimages/sysof.png";
                        }
                    }

                }
            }
        };
    };
    var tryingToReconnect = false;

   

    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
   
        ipAddress=document.getElementById("sessionInputIP").value;               
        chat.server.sendData();
       
       
       
        $(document).on("click", "#syslock", function () {
            var src = document.getElementById('syslock');
            if (src.src.indexOf("Images/详细页图标/images/图标_236.png") != -1)
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
        });
        $(document).on("click", "#podiumlock", function () {
            var src = document.getElementById('podiumlock');
            if (src.src.indexOf("Images/详细页图标/images/图标_238.png") != -1)
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2e 38");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2f 39");
        });
        $(document).on("click", "#classlock", function () {
            var src = document.getElementById('classlock');
            if (src.src.indexOf("Images/详细页图标/images/图标_264.png") != -1)
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
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 77 81");
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
            $('[class^="displaynone"]').hide();
        });
        $(document).on("click", "#laptop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 11 1b");
            $('[class^="displaynone"]').hide();
        });
        $(document).on("click", "#platform", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 12 1c");
            $('[class^="displaynone"]').hide();
        });
        $(document).on("click", "#digitalEquipment", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 13 1d");
            $('[class^="displaynone"]').hide();
        });
        $(document).on("click", "#dvd", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 14 1e");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        });
        $(document).on("click", "#tv", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 15 1f");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        });
        $(document).on("click", "#bluray", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 1a 24");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();

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
        $(document).on("click", "#systempower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 18 22");
        });
        $(document).on("click", "#pcpower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 17 21");
        });
        $(document).on("change", "*[name ='test']", function () {




        });
    });

}) 