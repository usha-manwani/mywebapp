﻿$ = jQuery.noConflict();
var ipAddress;
var userid;
$(function () {
    

    var QueryString = getRequests();
    ipAddress = QueryString["ip"];
    userid = QueryString["username"];
    document.getElementById("ipadd").innerText = ipAddress;
    //if url === "index.html?test1=t1&test2=t2&test3=t3"
    console.log(QueryString["ip"]); //logs t1

    var status = document.getElementById("deviceStatusHidden");

    allGrey();
    sysGrey();

    var chat = $.connection.myHub;

    chat.client.logoutTempUsers = function (s) {
        if (userid == s) {
            alert("You are going to logout!!");
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 05 02 1F 2A");
            var loc = "../logout.aspx?ip=" + ipAddress;
            window.href.location = loc;
        }
        
    }
    //sessionStorage.setItem('ipofremote', ipAddress);
    chat.client.broadcastMessage = function (name, message) {
        
        var status = document.getElementById("deviceStatusHidden");
        if (name == ipAddress) {
            var lastStatus = status.value;
            console.log("data received from " + ipAddress + "  " + message);
            if (lastStatus == "Offline") {
                var statusshow = document.getElementById("devicestatus");
                statusshow.innerHTML = "在线";
                document.getElementById("deviceStatusHidden").value = "Online";
                statusshow.style.color = "lightgreen";
                statusshow.style.fontWeight = "bolder";
            }
            else {
                var statusshow = document.getElementById("devicestatus");
                statusshow.innerHTML = "在线";
                document.getElementById("deviceStatusHidden").value = "Online";
                statusshow.style.color = "lightgreen";
                statusshow.style.fontWeight = "bolder";
            }
            var arraydata = message.split(',');
            if (arraydata[0] == "NetworkControl") {
                if (arraydata[1] == 'PanelKey') {
                    if (arraydata[2] == "PCON") {
                        var imgpc = document.getElementById("ppower");
                        imgpc.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                        $(imgpc).addClass('oncolor');
                    }

                    else {
                        var imgpc = document.getElementById("ppower");
                        imgpc.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                        $(imgpc).removeClass('oncolor');
                    }

                }
                else if (arraydata[1] == "Heartbeat") {
                    if (arraydata[3] == '待机') {
                        var img = document.getElementById("syspower");
                        img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        closedstatus(arraydata);
                        $(img).removeClass('oncolor');
                        if (arraydata[12] == '锁定') {//Locked
                            var src = document.getElementById('lock');
                            src.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_262.png";
                            $(src).addClass('oncolor');
                        }
                        else if (arraydata[12] == '解锁') {
                            //chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 02 2c 34");
                            var src = document.getElementById('lock');
                            src.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_264.png";
                            $(src).addClass('oncolor');
                        }
                    }
                    else {
                        var img = document.getElementById("syspower");
                        img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $(img).addClass('oncolor');
                        addclickeffect();
                        //}
                        //else {
                        //    var img = document.getElementById("syspower");
                        //    img.src = "Images/greyed/sysgrey.png";
                        //    $(img).removeClass('oncolor');
                        //}
                        if (arraydata[5] == '已开机') {//On
                            var imgpc = document.getElementById("ppower");
                            imgpc.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                            $(imgpc).addClass('oncolor');
                        }
                        else {
                            var imgpc = document.getElementById("ppower");
                            imgpc.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                            $(imgpc).removeClass('oncolor');
                        }
                        if (arraydata[12] == '锁定') {//Locked
                            var src = document.getElementById('lock');
                            src.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_262.png";
                            $(src).addClass('oncolor');
                        }
                        else {
                            var src = document.getElementById('lock');
                            src.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_264.png";
                            $(src).addClass('oncolor');
                        }
                        if (arraydata[9] == '停') {
                            var img = document.getElementById("Scdown");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $(img).addClass('oncolor');
                        }
                        else if (arraydata[9] == '降') {//Down
                            var img = document.getElementById("Scdown");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $(img).addClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $(img).removeClass('oncolor');
                        }
                        else if (arraydata[9] == '升') {//Up
                            var img = document.getElementById("Scup");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $(img).addClass('oncolor');
                            var img = document.getElementById("Scdown");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $(img).removeClass('oncolor');
                        }
                        if (arraydata[8] == '开') {//Open
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $(curtain).removeClass('oncolor');
                        }
                        else if (arraydata[8] == '关') {//Close
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $(curtain).removeClass('oncolor');

                        }
                        else if (arraydata[8] == '停')//Stop
                        {
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $(curtain).removeClass('oncolor');

                        }
                        switch (arraydata[11]) {
                            case '台式电脑'://Desktop
                                var img = document.getElementById('desktop1');
                                img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $(img).addClass('oncolor');
                                document.getElementById('laptop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $(document.getElementById('laptop1')).removeClass('oncolor');
                                document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
                                $(document.getElementById('Moremedia')).removeClass('oncolor');
                                break;
                            case '手提电脑'://Laptop
                                var img = document.getElementById('laptop1');
                                img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $(img).addClass('oncolor');
                                document.getElementById('desktop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $(document.getElementById('desktop1')).removeClass('oncolor');
                                document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
                                $(document.getElementById('Moremedia')).removeClass('oncolor');
                                break;
                            case '数码展台':
                                var img = document.getElementById('Moremedia');
                                img.src = "../Images/AllImages/images/图标_194.png";
                                $(img).addClass('oncolor');
                                document.getElementById('laptop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $(document.getElementById('laptop1')).removeClass('oncolor');
                                document.getElementById('desktop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $(document.getElementById('desktop1')).removeClass('oncolor');
                                break;

                        }

                        if (arraydata[6] == '已关机') {//Closed
                            var proj1 = document.getElementById('projgreen');
                            proj1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                            $(proj1).removeClass('oncolor');
                            var proj2 = document.getElementById('projred');
                            proj2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                            $(proj2).addClass('oncolor');
                        }
                        else {
                            var proj1 = document.getElementById('projgreen');
                            proj1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                            $(proj1).addClass('oncolor');
                            var proj2 = document.getElementById('projred');
                            proj2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                            $(proj2).removeClass('oncolor');
                        }
                        if (arraydata[10] == '关') {//Off
                            var light1 = document.getElementById("lighton");
                            light1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
                            $(light1).removeClass('oncolor');
                            var light2 = document.getElementById("lightoff");
                            light2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
                            $(light2).addClass('oncolor');
                        }
                        else {
                            var light1 = document.getElementById("lighton");
                            light1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
                            $(light1).addClass('oncolor');
                            var light2 = document.getElementById("lightoff");
                            light2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
                            $(light2).removeClass('oncolor');
                        }

                    }
                }
            }
            else {
                if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            var img = document.getElementById("syspower");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                            $(img).addClass('oncolor');
                            
                            break;
                        case 'projopen':
                            var proj1 = document.getElementById('projgreen');
                            proj1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                            $(proj1).addClass('oncolor');
                            var proj2 = document.getElementById('projred');
                            proj2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                            $(proj2).removeClass('oncolor');
                            break;
                        case 'projoff':
                            var proj1 = document.getElementById('projgreen');
                            proj1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                            $(proj1).removeClass('oncolor');
                            var proj2 = document.getElementById('projred');
                            proj2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                            $(proj2).addClass('oncolor');
                            break;
                        case 'SystemOff':
                            var img = document.getElementById("syspower");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                            $(img).removeClass('oncolor');
                            break;
                        case 'DSDown':
                            var img = document.getElementById("Scdown");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $(img).addClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $(img).removeClass('oncolor');
                            break;
                        case 'DSUp':
                            var img = document.getElementById("Scup");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $(img).addClass('oncolor');
                            var img = document.getElementById("Scdown");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $(img).removeClass('oncolor');
                            break;
                        case 'DSStop':
                            var img = document.getElementById("Scdown");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $(img).addClass('oncolor');
                            break;
                        case 'volplus':
                            if (document.getElementById("volchange").innerText >= 50) {
                                var img = document.getElementById("volsymbol");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                            }
                            break;
                        case 'volminus':
                            if (document.getElementById("volchange").innerText <= 50) {
                                var img = document.getElementById("volsymbol");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                            }
                            break;
                        case 'mute':
                            if (document.getElementById("volchange").innerText == 0) {
                                var img = document.getElementById("volsymbol");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/总音量静音.png";
                            }
                            break;
                        case 'wirelessvolplus':
                            if (document.getElementById("micchange").innerText >= 50) {
                                var img = document.getElementById("micIcon");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                            }
                            break;
                        case 'wirelessvolminus':
                            if (document.getElementById("micchange").innerText <= 50) {
                                var img = document.getElementById("micIcon");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                            }
                            break;
                        case 'wirelessmute':
                            if (document.getElementById("micchange").innerText == 0) {
                                var img = document.getElementById("micIcon");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦静音.png";
                            }
                            break;
                        case 'wiredvolplus':
                            if (document.getElementById("wiredmicchange").innerText >= 50) {
                                var img = document.getElementById("wiredmicIcon");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                            }
                            break;
                        case 'wiredvolminus':
                            if (document.getElementById("wiredmicchange").innerText <= 50) {
                                var img = document.getElementById("wiredmicIcon");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                            }
                            break;
                        case 'wiredmute':
                            if (document.getElementById("wiredmicchange").innerText == 0) {
                                var img = document.getElementById("wiredmicIcon");
                                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦静音.png";
                            }
                            break;
                        case 'curtain1open':
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $(curtain).removeClass('oncolor');
                            break;
                        case 'curtain1close':
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $(curtain).removeClass('oncolor');
                            break;
                        case 'curtain1stop':
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $(curtain).removeClass('oncolor');
                            break;
                        default:
                            break;
                    }
                }
                else if (arraydata[1] == "LEDIndicator") {
                    if (arraydata[5] == "CentralLock") {
                        var imglock = document.getElementById('lock');
                        document.getElementById('lock').src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_262.png";
                        $(imglock).addClass('oncolor');
                    }
                    else if (arraydata[5] == "CentralLockoff") {
                        var imglock = document.getElementById('lock');
                        document.getElementById('lock').src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_264.png";
                        $(imglock).addClass('oncolor');
                    }
                    if (arraydata[2] == "SystemSwitchOn") {
                        var img = document.getElementById("syspower");
                        img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $(img).addClass('oncolor');
                        //if (arraydata[4] == "Computer") {
                        //    var imgpc = document.getElementById("ppower");
                        //    var source = imgpc.getAttribute('class');
                        //    imgpc.setAttribute('src', "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png");
                        //    if (source.includes('oncolor')) {
                        //        $(imgpc).removeClass('oncolor');
                        //    }
                        //    else {
                        //        // imgpc.setAttribute('src', "Images/greyed/pcgrey.png");
                        //        $(imgpc).addClass('oncolor');
                        //    }
                        //}
                        switch (arraydata[3]) {
                            case 'Desktop':
                                var img = document.getElementById('desktop1');
                                img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $(img).addClass('oncolor');
                                document.getElementById('laptop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $(document.getElementById('laptop1')).removeClass('oncolor');
                                document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
                                $(document.getElementById('Moremedia')).removeClass('oncolor');
                                break;
                            case 'Laptop':
                                var img = document.getElementById('laptop1');
                                img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $(img).addClass('oncolor');
                                document.getElementById('desktop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $(document.getElementById('desktop1')).removeClass('oncolor');
                                document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
                                $(document.getElementById('Moremedia')).removeClass('oncolor');
                                break;
                            case 'DigitalCurtain':
                                var img = document.getElementById('Moremedia');
                                img.src = "../Images/AllImages/images/图标_194.png";
                                $(img).addClass('oncolor');
                                document.getElementById('laptop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $(document.getElementById('laptop1')).removeClass('oncolor');
                                document.getElementById('desktop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $(document.getElementById('desktop1')).removeClass('oncolor');
                                break;
                        }
                        
                    }
                    else if (arraydata[2] == "SystemSwitchOff") {
                        var img = document.getElementById("syspower");
                        img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $(img).removeClass('oncolor');

                    }
                }

            }
            
            if (arraydata[2] == 'Offline' || arraydata[1] == 'Unsuccessful' || arraydata[2] == '离线') {
                allGrey();
                document.getElementById("devicestatus").innerHTML = "离线"; //Offline
                document.getElementById("deviceStatusHidden").value = "Offline";
                document.getElementById("devicestatus").style.color = "white";
            }
        }
    };

    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        AllNormal();
        
        chat.server.sendControlKeys(ipAddress, "8B B9 00 04 05 02 1E 29");
        chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
        chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 02 2d 35");
        SetVolume = function (val) {
            var lastVal = this.document.getElementById("volchange").innerText;
            var img = document.getElementById("volsymbol");
            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
            if (lastVal > val && val > 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 21 2B");
                if (parseInt(lastVal) > 10) {
                    document.getElementById("vol-control").value = parseInt(lastVal) - 10;
                    this.document.getElementById("volchange").innerText = parseInt(lastVal) - 10;
                }
                else {
                    document.getElementById("vol-control").value = 0;
                    this.document.getElementById("volchange").innerText = 0;
                }
            }
            else if (val == 0) {
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/总音量静音.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 22 2C");
                this.document.getElementById("volchange").innerText = 0;
                document.getElementById("vol-control").value = 0;
            }
            else if (lastVal < val) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 2A");
                if (parseInt(lastVal) < 90) {
                    document.getElementById("vol-control").value = parseInt(lastVal) + 10;
                    this.document.getElementById("volchange").innerText = parseInt(lastVal) + 10;
                }
                else {
                    document.getElementById("vol-control").value = 99;
                    this.document.getElementById("volchange").innerText = 99;

                }

            }

        };
        MicControl = function (val) {
            var lastVal = this.document.getElementById("micchange").innerText;
            var img = document.getElementById("micIcon");
            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
            if (lastVal > val && val > 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 74 7e");
                if (parseInt(lastVal) > 10) {
                    document.getElementById("mic-control").value = parseInt(lastVal) - 10;
                    this.document.getElementById("micchange").innerText = parseInt(lastVal) - 10;
                }
                else {
                    document.getElementById("mic-control").value = 0;
                    this.document.getElementById("micchange").innerText = 0;

                }
            }
            else if (val == 0) {
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦静音.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 75 7f");
                this.document.getElementById("micchange").innerText = 0;
                document.getElementById("mic-control").value = 0;
            }
            else if (lastVal < val) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 73 7d");
                if (parseInt(lastVal) < 90) {
                    document.getElementById("mic-control").value = parseInt(lastVal) + 10;
                    this.document.getElementById("micchange").innerText = parseInt(lastVal) + 10;
                }
                else {
                    document.getElementById("mic-control").value = 99;
                    this.document.getElementById("micchange").innerText = 99;

                }
            }

        };
        WiredMicControl = function (val) {
            var lastVal = this.document.getElementById("wiredmicchange").innerText;
            if (lastVal > val && val > 0) {
                var img = document.getElementById("wiredmicIcon");
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 24 2e");
                if (parseInt(lastVal) > 10) {
                    document.getElementById("wiredmic-control").value = parseInt(lastVal) - 10;
                    this.document.getElementById("wiredmicchange").innerText = parseInt(lastVal) - 10;
                }
                else {
                    document.getElementById("wiredmic-control").value = 0;
                    this.document.getElementById("wiredmicchange").innerText = 0;

                }
            }
            else if (val == 0) {
                var img = document.getElementById("wiredmicIcon");
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦静音.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 25 2f");
                this.document.getElementById("wiredmicchange").innerText = 0;
                document.getElementById("wiredmic-control").value = 0;
            }
            else if (lastVal < val) {

                var img = document.getElementById("wiredmicIcon");

                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";

                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 23 2d");
                if (parseInt(lastVal) < 90) {
                    document.getElementById("wiredmic-control").value = parseInt(lastVal) + 10;
                    this.document.getElementById("wiredmicchange").innerText = parseInt(lastVal) + 10;
                }
                else {
                    document.getElementById("wiredmic-control").value = 99;
                    this.document.getElementById("wiredmicchange").innerText = 99;

                }
            }

        };

        $(document).on("click", "#lock", function () {
            var imgpc = document.getElementById('lock');
            var source = imgpc.getAttribute('src');
            if (source == "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_262.png")
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 02 2d 35");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 02 2c 34");
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
            if ($(this).hasClass("oncolor")) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 05 02 1F 2A");
                chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 05 02 1E 29");
                chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
            }
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
        $(document).on("click", "#projgreen", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 33 3D");
        });
        $(document).on("click", "#projred", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 43 4D");
        });
        $(document).on("click", "#Moremedia", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 12 1c");
        });
    });

});
function getRequests() {
    var s1 = location.search.substring(1, location.search.length).split('&'),
        r = {}, s2, i;
    for (i = 0; i < s1.length; i += 1) {
        s2 = s1[i].split('=');
        r[decodeURIComponent(s2[0]).toLowerCase()] = decodeURIComponent(s2[1]);
    }
    return r;
};
function allGrey() {

    var img = document.getElementById("ppower");
    img.src = "../Images/greyed/pcgrey.png";
    $(img).removeClass("imgclick oncolor");

    var img = document.getElementById("lock");
    img.src = "../Images/greyed/lock1.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Scup");
    img.src = "../Images/greyed/scup.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Scdown");
    img.src = "../Images/greyed/scdown.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("scStop");
    img.src = "../Images/greyed/scstop.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("desktop1");
    img.src = "../Images/greyed/desktop.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("laptop1");
    img.src = "../Images/greyed/laptop.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainOpen");
    img.src = "../Images/greyed/copengrey.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainClose");
    img.src = "../Images/greyed/cclosegrey.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainStop");
    img.src = "../Images/greyed/cstopgrey.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("projgreen");
    img.src = "../Images/greyed/proj1.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("projred");
    img.src = "../Images/greyed/proj2.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("lighton");
    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("lightoff");
    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Moremedia");
    img.src = "../Images/AllImages/images/图标_194.png";
    $(img).removeClass("imgclick oncolor");


}
function sysGrey() {
    var img = document.getElementById("syspower");
    img.src = "../Images/greyed/sysgrey.png";
    $(img).removeClass("imgclick oncolor");
    $("#vol-control").prop("disabled", true);
    $("#mic-control").prop("disabled", true);
    $("#wiredmic-control").prop("disabled", true);

}

function AllNormal() {
    var img = document.getElementById("syspower");
    img.src = "../Images/greyed/sysgrey.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("ppower");
    img.src = "../Images/greyed/pcgrey.png";
    $(img).addClass("imgclick");

    var img = document.getElementById("lock");
    img.src = "../Images/greyed/lock1.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("Scup");
    img.src = "../Images/greyed/scup.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("Scdown");
    img.src = "../Images/greyed/scdown.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("scStop");
    img.src = "../Images/greyed/scstop.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("desktop1");
    img.src = "../Images/greyed/desktop.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("laptop1");
    img.src = "../Images/greyed/laptop.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainOpen");
    img.src = "../Images/greyed/copengrey.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainClose");
    img.src = "../Images/greyed/cclosegrey.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainStop");
    img.src = "../Images/greyed/cstopgrey.png";
    $(img).addClass("imgclick");
    var img = document.getElementById("projgreen");
    img.src = "../Images/greyed/proj1.png";
    $(img).addClass("imgclick");

    var img = document.getElementById("projred");
    img.src = "../Images/greyed/proj2.png";
    $(img).addClass("imgclick");

    var img = document.getElementById("lighton");
    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
    $(img).addClass("imgclick");

    var img = document.getElementById("lightoff");
    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
    $(img).addClass("imgclick");

    var img = document.getElementById("Moremedia");
    img.src = "../Images/AllImages/images/图标_194.png";
    $(img).addClass("imgclick");


}

function closedstatus(arraydata) {

    var imgpc = document.getElementById("ppower");
    imgpc.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";

    $(imgpc).removeClass('imgclick oncolor');

    if (arraydata[12] == 'Locked') {
        var src = document.getElementById('lock');
        src.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_214.png";
        $(src).addClass('imgclick');
        $(src).removeClass('oncolor');
    }
    else {
        var src = document.getElementById('lock');
        src.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_216.png";
        //$(src).addClass(' oncolor').removeClass('imgclick');
        $(src).removeClass('oncolor');
        $(src).addClass('imgclick');
    }
    //if (arraydata[9] == 'Stop') {
    var img = document.getElementById("Scdown");
    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
    $(img).removeClass('imgclick oncolor');
    var img = document.getElementById("Scup");
    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png"
    $(img).removeClass('imgclick oncolor');
    var img = document.getElementById("scStop");
    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
    $(img).removeClass('imgclick oncolor');

    var curtain = document.getElementById('CurtainOpen');
    curtain.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
    $(curtain).removeClass('imgclick oncolor');
    var curtain = document.getElementById('CurtainClose');
    curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
    $(curtain).removeClass('imgclick oncolor');
    var curtain = document.getElementById('CurtainStop');
    curtain.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
    $(curtain).removeClass('imgclick oncolor');

    var img = document.getElementById('desktop1');
    img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
    $(img).removeClass('imgclick oncolor');
    document.getElementById('laptop1').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
    $(document.getElementById('laptop1')).removeClass('imgclick oncolor');
    document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
    $(document.getElementById('Moremedia')).removeClass('imgclick oncolor');


    if (arraydata[6] == 'Closed') {
        var proj1 = document.getElementById('projgreen');
        proj1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
        $(proj1).removeClass('imgclick oncolor');
        var proj2 = document.getElementById('projred');
        proj2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
        $(proj2).removeClass('imgclick oncolor');
    }
    else {
        var proj1 = document.getElementById('projgreen');
        proj1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
        $(proj1).removeClass('imgclick oncolor');
        var proj2 = document.getElementById('projred');
        proj2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
        $(proj2).removeClass('imgclick oncolor');
    }
    if (arraydata[10] == 'Off') {
        var light1 = document.getElementById("lighton");
        light1.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
        $(light1).removeClass('imgclick oncolor');
        var light2 = document.getElementById("lightoff");
        light2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
        //$(light2).addClass('oncolor');
        $(light2).removeClass('imgclick oncolor');
    }
    else {
        var light1 = document.getElementById("lighton");
        light1.src = "../Images/greyed/lightgrey.png";
        // $(light1).addClass('oncolor');
        $(light1).removeClass('imgclick oncolor');
        var light2 = document.getElementById("lightoff");
        light2.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
        $(light2).removeClass('imgclick oncolor');
    }

}

function addclickeffect() {
    var img = document.getElementById("syspower");

    $(img).addClass("imgclick");
    var img = document.getElementById("ppower");

    $(img).addClass("imgclick");

    var img = document.getElementById("lock");

    $(img).addClass("imgclick");
    var img = document.getElementById("Scup");

    $(img).addClass("imgclick");
    var img = document.getElementById("Scdown");

    $(img).addClass("imgclick");
    var img = document.getElementById("scStop");

    $(img).addClass("imgclick");
    var img = document.getElementById("desktop1");

    $(img).addClass("imgclick");
    var img = document.getElementById("laptop1");

    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainOpen");

    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainClose");

    $(img).addClass("imgclick");
    var img = document.getElementById("CurtainStop");

    $(img).addClass("imgclick");
    var img = document.getElementById("projgreen");

    $(img).addClass("imgclick");

    var img = document.getElementById("projred");

    $(img).addClass("imgclick");

    var img = document.getElementById("lighton");

    $(img).addClass("imgclick");

    var img = document.getElementById("lightoff");

    $(img).addClass("imgclick");

    var img = document.getElementById("Moremedia");

    $(img).addClass("imgclick");

    $("#vol-control").prop("disabled", false);
    $("#mic-control").prop("disabled", false);
    $("#wiredmic-control").prop("disabled", false);

}