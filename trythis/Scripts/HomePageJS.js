$(function () {
    
    var chat = $.connection.myHub;
    var ipAddress = document.getElementById("InputIP").value;
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
                    img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态2_01.png";
                }
                if (arraydata[5] == 'On') {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_02.png";
                }
                else {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态2_01.png";
                }
                if (arraydata[12] == 'Locked') {
                    var src = document.getElementById('syslock');
                    src.src = "Images/详细页图标/全部按钮/控制全页面-鼠标经过状态/控制页面-鼠标经过页面_01_184.png";
                }
                else {
                    var src = document.getElementById('lock');
                    src.src = "Images/详细页图标/全部按钮/控制全页面-鼠标经过状态/控制页面-鼠标经过页面_01_186.png";
                }
                if (arraydata[9] == 'Stop') {
                    var img = document.getElementById("Scdown");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_134.png";
                    var img = document.getElementById("Scup");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_132.png";
                    var img = document.getElementById("scStop");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_58.png";
                }
                else if (arraydata[9] == 'Down') {
                    var img = document.getElementById("Scdown");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_56.png";
                    var img = document.getElementById("Scup");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_132.png";
                    var img = document.getElementById("scStop");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_136.png";
                }
                else if (arraydata[9] == 'Up') {
                    var img = document.getElementById("Scup");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_54.png";
                    var img = document.getElementById("Scdown");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_134.png";
                    var img = document.getElementById("scStop");
                    img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_136.png";
                }
                if (arraydata[8] == 'Open') {
                    var curtain = document.getElementById('CurtainOpen');
                    curtain.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_28.png";
                    var curtain = document.getElementById('CurtainClose');
                    curtain.src = "Images/icons/images/背景图-（03_49.png";
                    var curtain = document.getElementById('CurtainStop');
                    curtain.src = "Images/icons/images/背景图-（03_51.png";
                }
                else if (arraydata[8] == 'Close') {
                    var curtain = document.getElementById('CurtainClose');
                    curtain.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_30.png";
                    var curtain = document.getElementById('CurtainStop');
                    curtain.src = "Images/icons/images/背景图-（03_51.png";
                    var curtain = document.getElementById('CurtainOpen');
                    curtain.src = "Images/icons/images/背景图-（03_47.png";
                     
                }
                else (arraydata[8] == 'Stop')
                {
                    var curtain = document.getElementById('CurtainClose');
                    curtain.src = "Images/icons/images/背景图-（03_49.png";
                    var curtain = document.getElementById('CurtainStop');
                    curtain.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_32.png";
                    var curtain = document.getElementById('CurtainOpen');
                    curtain.src = "Images/icons/images/背景图-（03_47.png";
                    
                }
                
            }
            else {
                for (j = 2; j < arraydata.length; j++) {
                    if (arraydata[1] == "KeyValue") {
                        switch (arraydata[2]) {
                            case 'SystemON':
                                var img = document.getElementById("systempower");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_02.png";
                                break;
                            case 'SystemOff':
                                var img = document.getElementById("systempower");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态2_01.png";
                                break;
                            case 'DSDown':
                                var img = document.getElementById("Scdown");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_56.png";
                                var img = document.getElementById("Scup");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_132.png";
                                var img = document.getElementById("scStop");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_136.png";
                                break;
                            case 'DSUp':
                                var img = document.getElementById("Scup");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_54.png";
                                var img = document.getElementById("Scdown");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_134.png";
                                var img = document.getElementById("scStop");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_136.png";
                                break;
                            case 'DSStop':
                                var img = document.getElementById("Scdown");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_134.png";
                                var img = document.getElementById("Scup");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-默认状态/控制页面_132.png";
                                var img = document.getElementById("scStop");
                                img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_58.png";
                                break;
                            default:
                                break
                        }
                    }
                    else if (arraydata[1] == "LEDIndicator") {
                        if (arraydata[2] == "SystemSwitchOn") {
                            var img = document.getElementById("systempower");
                            img.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_02.png";
                            if (arraydata.length > 4) {
                                var imgpc = document.getElementById("pcpower");
                                switch (arraydata[4]) {
                                    case 'ComputerOff':
                                        imgpc.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态2_01.png";
                                        break;
                                    case 'ComputerOn':
                                        imgpc.src = "Images/详细页图标/全部按钮/控制全页面-显示状态/控制页面-显示状态_02.png";
                                        break;
                                }

                            }
                        }
                    }
                }
            }
            
        }
    };    

    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
       
        $(document).on("click", "#lock", function () {
            var src = document.getElementById('lock');
            if (src.src.indexOf("Images/详细页图标/全部按钮/控制全页面-鼠标经过状态/控制页面-鼠标经过页面_01_186.png") != -1)
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
        });
        $(document).on("click", "#Scup", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5f 6A");
        });
        $(document).on("click", "#Scdown", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#scStop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 77 81");
        });
        $(document).on("click", "#CurtainOpen", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#CurtainStop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#CurtainClose", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 05 5f 6A");
        });
        $(document).on("click", "#systempower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 18 22");
        });
        $(document).on("click", "#pcpower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 17 21");
        });
    });



})