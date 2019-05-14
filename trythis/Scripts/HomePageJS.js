﻿var ipAddress;
$(function () {
    if (document.getElementById("devicestatus").innerHTML == "Offline") {
        allGrey();
        sysGrey();
    }
    var chat = $.connection.myHub;
    ipAddress = document.getElementById("InputIP").value;
    document.getElementById("MainContent_masterchildBody_iptocam").value = ipAddress;
    
    console.log("IP address from InputIP is " + document.getElementById("MainContent_masterchildBody_iptocam").value);
    //sessionStorage.setItem('ipofremote', ipAddress);
    chat.client.broadcastMessage = function (name, message) {
        var f = document.getElementById("devicestatus");
        var lastStatus = f.innerHTML;
        if (name == ipAddress) {
            console.log("data received from " + ipAddress + "  " + message);
            if (lastStatus == "Offline") {
                AllNormal();
            }            
                f.innerHTML = "Online";
                f.style.color = "lightgreen";
                f.style.fontWeight = "bolder";
            //setInterval(function () {
            //    f.style.visibility = (f.style.visibility == 'hidden' ? '' : 'hidden');
            //}, 2000);
            var arraydata = message.split(',');
            if (arraydata[1] == "Heartbeat") {
                
                if (arraydata[3] == 'OPEN') {
                    var img = document.getElementById("syspower");
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                    $(img).addClass('oncolor');
                }
                else {
                    var img = document.getElementById("syspower");
                    img.src = "Images/greyed/sysgrey.png";
                    $(img).removeClass('oncolor');
                }
                if (arraydata[5] == 'On') {
                    var imgpc = document.getElementById("ppower");
                    imgpc.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                    $(imgpc).addClass('oncolor');
                }
                else {
                    var imgpc = document.getElementById("ppower");
                    imgpc.src = "Images/greyed/pcgrey.png";
                    $(imgpc).removeClass('oncolor');
                }
                if (arraydata[12] == 'Locked') {
                    var src = document.getElementById('lock');
                    src.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_214.png";
                    $(src).addClass('oncolor');
                }
                else {
                    var src = document.getElementById('lock');
                    src.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_216.png";
                    $(src).addClass('oncolor');
                }
                if (arraydata[9] == 'Stop') {
                    var img = document.getElementById("Scdown");
                    img.src = "Images/greyed/scdown.png";
                    $(img).removeClass('oncolor');
                    var img = document.getElementById("Scup");
                    img.src = "Images/greyed/scup.png";
                    $(img).removeClass('oncolor');
                    var img = document.getElementById("scStop");
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                    $(img).addClass('oncolor');                    
                }
                else if (arraydata[9] == 'Down') {
                    var img = document.getElementById("Scdown");
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                    $(img).addClass('oncolor');
                    var img = document.getElementById("Scup");
                    img.src = "Images/greyed/scup.png";
                    $(img).removeClass('oncolor');
                    var img = document.getElementById("scStop");
                    img.src = "Images/greyed/scstop.png";
                    $(img).removeClass('oncolor');
                }
                else if (arraydata[9] == 'Up') {
                    var img = document.getElementById("Scup");
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                    $(img).addClass('oncolor');
                    var img = document.getElementById("Scdown");
                    img.src = "Images/greyed/scdown.png";
                    $(img).removeClass('oncolor');
                    var img = document.getElementById("scStop");
                    img.src = "Images/greyed/scstop.png";
                    $(img).removeClass('oncolor');
                }
                if (arraydata[8] == 'Open') {
                    var curtain = document.getElementById('CurtainOpen');
                    curtain.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                    $(curtain).addClass('oncolor');
                    var curtain = document.getElementById('CurtainClose');
                    curtain.src = "Images/greyed/cclosegrey.png";
                    $(curtain).removeClass('oncolor');
                    var curtain = document.getElementById('CurtainStop');
                    curtain.src = "Images/greyed/cstopgrey.png";
                    $(curtain).removeClass('oncolor');
                }
                else if (arraydata[8] == 'Close') {
                    var curtain = document.getElementById('CurtainClose');
                    curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                    $(curtain).addClass('oncolor');
                    var curtain = document.getElementById('CurtainStop');
                    curtain.src = "Images/greyed/cstopgrey.png";
                    $(curtain).removeClass('oncolor');
                    var curtain = document.getElementById('CurtainOpen');
                    curtain.src = "Images/greyed/copengrey.png";
                    $(curtain).removeClass('oncolor');

                }
                else (arraydata[8] == 'Stop')
                {
                    var curtain = document.getElementById('CurtainClose');
                    curtain.src = "Images/greyed/cclosegrey.png";
                    $(curtain).removeClass('oncolor');
                    var curtain = document.getElementById('CurtainStop');
                    curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                    $(curtain).addClass('oncolor');
                    var curtain = document.getElementById('CurtainOpen');
                    curtain.src = "Images/greyed/copengrey.png";
                    $(curtain).removeClass('oncolor');

                }
                switch (arraydata[11]) {
                    case 'Desktop':
                        var img = document.getElementById('desktop1');
                        img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                        $(img).addClass('oncolor');
                        document.getElementById('laptop1').src = "Images/greyed/laptop.png";
                        $(document.getElementById('laptop1')).removeClass('oncolor');
                        document.getElementById('Moremedia').src = "Images/greyed/more.png";
                        $(document.getElementById('Moremedia')).removeClass('oncolor');
                        break;
                    case 'Laptop':
                        var img = document.getElementById('laptop1');
                        img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                        $(img).addClass('oncolor');
                        document.getElementById('desktop1').src = "Images/greyed/desktop.png";
                        $(document.getElementById('desktop1')).removeClass('oncolor');
                        document.getElementById('Moremedia').src = "Images/greyed/more.png";
                        $(document.getElementById('Moremedia')).removeClass('oncolor');
                        break;
                    default:
                        var img = document.getElementById('Moremedia');
                        img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
                        $(img).addClass('oncolor');
                        document.getElementById('laptop1').src = "Images/greyed/laptop.png";
                        $(document.getElementById('laptop1')).removeClass('oncolor');
                        document.getElementById('desktop1').src = "Images/greyed/desktop.png";
                        $(document.getElementById('desktop1')).removeClass('oncolor');
                        break;

                }

                if (arraydata[6] == 'Closed') {
                    var proj1 = document.getElementById('projgreen');
                    proj1.src = "Images/greyed/proj1.png";
                    $(proj1).removeClass('oncolor');
                    var proj2 = document.getElementById('projred');
                    proj2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                    $(proj2).addClass('oncolor');
                } 
                else {
                    var proj1 = document.getElementById('projgreen');
                    proj1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                    $(proj1).addClass('oncolor');
                    var proj2 = document.getElementById('projred');
                    proj2.src = "Images/greyed/proj2.png";
                    $(proj2).removeClass('oncolor');
                }
                if (arraydata[10] == 'Off') {
                    var light1 = document.getElementById("lighton");
                    light1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
                    $(light1).removeClass('oncolor');
                    var light2 = document.getElementById("lightoff");
                    light2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
                    $(light2).addClass('oncolor');
                }
                else {
                    var light1 = document.getElementById("lighton");
                    light1.src = "Images/greyed/lightgrey.png";
                    $(light1).addClass('oncolor');
                    var light2 = document.getElementById("lightoff");
                    light2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
                    $(light2).removeClass('oncolor');
                }
            }
            else {
                if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            var img = document.getElementById("syspower");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                            $(img).addClass('oncolor');
                            break;
                        case 'SystemOff':
                            var img = document.getElementById("syspower");
                            img.src = "Images/greyed/sysgrey.png";
                            $(img).removeClass('oncolor');
                            
                            break;
                        case 'DSDown':
                            var img = document.getElementById("Scdown");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $(img).addClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "Images/greyed/scup.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/greyed/scstop.png";
                            $(img).removeClass('oncolor');
                            break;
                        case 'DSUp':
                            var img = document.getElementById("Scup");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $(img).addClass('oncolor');
                            var img = document.getElementById("Scdown");
                            img.src = "Images/greyed/scdown.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/greyed/scstop.png";
                            $(img).removeClass('oncolor');
                            break;
                        case 'DSStop':
                            var img = document.getElementById("Scdown");
                            img.src = "Images/greyed/scdown.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "Images/greyed/scup.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $(img).addClass('oncolor');
                            break;
                        case 'volplus':
                            if (document.getElementById("volchange").innerText >= 50) {
                                var img = document.getElementById("volsymbol");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                            }
                            break;
                        case 'volminus':
                            if (document.getElementById("volchange").innerText <= 50) {
                                var img = document.getElementById("volsymbol");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                            }
                            break;
                        case 'mute':
                            if (document.getElementById("volchange").innerText == 0) {
                                var img = document.getElementById("volsymbol");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量静音.png";
                            }
                            break;
                        case 'wirelessvolplus':
                            if (document.getElementById("micchange").innerText >= 50) {
                                var img = document.getElementById("micIcon");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                            }
                            break;
                        case 'wirelessvolminus':
                            if (document.getElementById("micchange").innerText <= 50) {
                                var img = document.getElementById("micIcon");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                            }
                            break;
                        case 'wirelessmute':
                            if (document.getElementById("micchange").innerText == 0) {
                                var img = document.getElementById("micIcon");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦静音.png";
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (arraydata[1] == "LEDIndicator") {
                    if (arraydata[2] == "SystemSwitchOn") {
                        var img = document.getElementById("syspower");
                        img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $(img).addClass('oncolor');
                        
                        if (arraydata.length > 4) {
                            var imgpc = document.getElementById("ppower");
                            switch (arraydata[4]) {
                                case 'ComputerOff':
                                    imgpc.src = "Images/greyed/pcgrey.png";
                                    $(imgpc).removeClass('oncolor');
                                    break;
                                case 'ComputerOn':
                                    imgpc.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                                    $(imgpc).addClass('oncolor');
                                    break;
                            }
                            switch (arraydata[3]) {
                                case 'Desktop':
                                    var img = document.getElementById('desktop1');
                                    img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                    $(img).addClass('oncolor');
                                    document.getElementById('laptop1').src = "Images/greyed/laptop.png";
                                    $(document.getElementById('laptop1')).removeClass('oncolor');
                                    document.getElementById('Moremedia').src = "Images/greyed/more.png";
                                    $(document.getElementById('Moremedia')).removeClass('oncolor');
                                    break;
                                case 'Laptop':
                                    var img = document.getElementById('laptop1');
                                    img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                    $(img).addClass('oncolor');
                                    document.getElementById('desktop1').src = "Images/greyed/desktop.png";
                                    $(document.getElementById('desktop1')).removeClass('oncolor');
                                    document.getElementById('Moremedia').src = "Images/greyed/more.png";
                                    $(document.getElementById('Moremedia')).removeClass('oncolor');
                                    break;
                                default:
                                    var img = document.getElementById('Moremedia');
                                    img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
                                    $(img).addClass('oncolor');
                                    document.getElementById('laptop1').src = "Images/greyed/laptop.png";
                                    $(document.getElementById('laptop1')).removeClass('oncolor');
                                    document.getElementById('desktop1').src = "Images/greyed/desktop.png";
                                    $(document.getElementById('desktop1')).removeClass('oncolor');
                                    break;
                            }

                        }
                    }
                    else {
                        var img = document.getElementById("syspower");
                        img.src = "Images/greyed/sysgrey.png";
                        $(img).removeClass('oncolor');
                        
                        
                    }
                }

            }
            if (arraydata[0] == "Temp") {
                document.getElementById("tempvalue").innerHTML = arraydata[1] +" °C";
                document.getElementById("humidvalue").innerHTML = arraydata[2] + "%";
                document.getElementById("pmvalue").innerHTML = arraydata[3] + " µg/m3";
                if (arraydata[5] != "--") {
                    document.getElementById("co2").innerHTML = arraydata[10] + "ppm";
                    document.getElementById("intensityvalue").innerHTML = arraydata[13] + "nits";
                    document.getElementById("methanalvalue").innerHTML = arraydata[11] + "mg/m3";
                    document.getElementById("voltvalue").innerHTML = arraydata[5] + "V";

                    document.getElementById("I1").innerHTML = (((arraydata[6] / 1000) * arraydata[5]) / 1000).toFixed(2) + "KW";
                    
                    document.getElementById("I2").innerHTML = (((arraydata[7] / 1000) * arraydata[5]) / 1000).toFixed(2) + "KW";
                    
                    
                    document.getElementById("I3").innerHTML = (((arraydata[8] / 1000) * arraydata[5]) / 1000).toFixed(2) + "KW";
                    
                    document.getElementById("I4").innerHTML = (((arraydata[9] / 1000) * arraydata[5]) / 1000).toFixed(2) + "KW";
                    
                }
            }
            if (arraydata[2] == 'Offline' || arraydata[1] =='Unsuccessful') {
                allGrey();
                document.getElementById("devicestatus").innerHTML = "Offline";
                document.getElementById("devicestatus").style.color = "white";
            }
        }        
    };

    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
        SetVolume = function (val) {
            var lastVal = this.document.getElementById("volchange").innerText;
            if (lastVal > val) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 21 25");
            }
            else if (val == 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 22 26");
            }
            else if (lastVal < val) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 24");
            }
            this.document.getElementById("volchange").innerText = val;
            console.log('After: ' + val);
        };
        MicControl = function (val) {
            var lastVal = this.document.getElementById("micchange").innerText;
            if (lastVal > val) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 74 7e");
            }
            else if (val == 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 75 7f");
            }
            else if (lastVal < val) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 73 7d");
            }
            this.document.getElementById("micchange").innerText = val;
            console.log('After: ' + val);
        };
        $(document).on("click", "#lock", function () {
            var src = document.getElementById('lock');
            if (src.src.indexOf("Images/AllImages/全部按钮/控制全页面-显示状态/lock1.png") != -1)
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
        });
        $(document).on("click", "#Scup", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 76 80");
        });
        $(document).on("click", "#Scdown", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 56 60");
        });
        $(document).on("click", "#scStop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 66 70");
        });
        $(document).on("click", "#CurtainOpen", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 77 81");
        });
        $(document).on("click", "#CurtainStop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 67 71");
        });
        $(document).on("click", "#CurtainClose", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 57 61");
        });
        $(document).on("click", "#syspower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 18 22");
        });
        $(document).on("click", "#ppower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 17 21");
        });
        $(document).on("click", "#desktop1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 10 1A");
        });
        $(document).on("click", "#laptop1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 11 1b");
        });
    });
  
})

function allGrey(){
  
    var img = document.getElementById("ppower");
    img.src = "Images/greyed/pcgrey.png" ;
    $(img).removeClass("imgclick oncolor");
   
    var img = document.getElementById("lock");
    img.src = "Images/greyed/lock1.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Scup");
    img.src = "Images/greyed/scup.png"; 
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Scdown");
    img.src = "Images/greyed/scdown.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("scStop");
    img.src = "Images/greyed/scstop.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("desktop1");
    img.src = "Images/greyed/desktop.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("laptop1");
    img.src = "Images/greyed/laptop.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainOpen");
    img.src = "Images/greyed/copengrey.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainClose");
    img.src = "Images/greyed/cclosegrey.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainStop");
    img.src = "Images/greyed/cstopgrey.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("projgreen");
    img.src = "Images/greyed/proj1.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("projred");
    img.src = "Images/greyed/proj2.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("lighton");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png" ;
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("lightoff");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Moremedia");
    img.src = "Images/greyed/more.png";
    $(img).removeClass("imgclick oncolor");
    $("#vol-control").prop("disabled", true);
    $("#mic-control").prop("disabled", true);
    $("#yellowbuttons").removeClass("imgclick");
    
}
function sysGrey() {
    var img = document.getElementById("syspower");
    img.src = "Images/greyed/sysgrey.png";
    $(img).removeClass("imgclick oncolor");
}

function AllNormal() {
    var img = document.getElementById("syspower");
    img.src = "Images/greyed/sysgrey.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("ppower");
    img.src = "Images/greyed/pcgrey.png";
    $(img).addClass("imgclick");
    
    var img = document.getElementById("lock");
    img.src = "Images/greyed/lock1.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("Scup");
    img.src = "Images/greyed/scup.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("Scdown");
    img.src = "Images/greyed/scdown.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("scStop");
    img.src = "Images/greyed/scstop.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("desktop1");
    img.src = "Images/greyed/desktop.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("laptop1");
    img.src = "Images/greyed/laptop.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainOpen");
    img.src = "Images/greyed/copengrey.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainClose");
    img.src = "Images/greyed/cclosegrey.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainStop");
    img.src = "Images/greyed/cstopgrey.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("projgreen");
    img.src = "Images/greyed/proj1.png";
    $(img).addClass("imgclick");
    console.log("noerror5");
    var img = document.getElementById("projred");
    img.src = "Images/greyed/proj2.png" ;
    $(img).addClass("imgclick");
    console.log("noerror2");
    var img = document.getElementById("lighton");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
    $(img).addClass("imgclick");
    console.log("noerror1");
    var img = document.getElementById("lightoff");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
    $(img).addClass("imgclick");
    console.log("noerror3");
    var img = document.getElementById("Moremedia");
    img.src = "Images/greyed/more.png";
    $(img).addClass("imgclick");
    console.log("noerror4");
    $("#vol-control").prop("disabled", false);
    $("#mic-control").prop("disabled", false);
    $("#yellowbuttons").addClass("imgclick");
}


function Cam1(ipadd) {
    var player1 = document.getElementById('plugin_inst_1');
    document.getElementById('src1').value = ipadd;
    player1.play(ipadd);
    var player2 = document.getElementById('plugin_inst_2');

    var src2 = document.getElementById("src2");
    var videostream = ipadd + "cam/realmonitor?channel=1&subtype=1";
    player2.play(videostream);
    src2.value = videostream;
    
}
function Cam2(ipadd) {
    var player2 = document.getElementById('plugin_inst_3');
    var src3 = document.getElementById("src3");
    var videostream = ipadd + "cam/realmonitor?channel=1&subtype=1";
    src3.value = videostream;
    player2.play(videostream);
    
}
function Cam3(ipadd) {
    var player2 = document.getElementById('plugin_inst_4');
    var src4 = document.getElementById("src4");
    var videostream = ipadd + "cam/realmonitor?channel=1&subtype=1";
    src4.value = videostream;
    player2.play(videostream);
    
}
function Cam4(ipadd) {
    var player2 = document.getElementById('plugin_inst_5');
    var src5 = document.getElementById("src5");
    var videostream = ipadd + "cam/realmonitor?channel=1&subtype=1";
    src5.value = videostream;
    player2.play(videostream);
    
}

