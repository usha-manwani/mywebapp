$jq = jQuery.noConflict();
var ipAddress;
$jq(function () {
    if (document.getElementById("deviceStatusHidden").value == "Offline") {
        allGrey();
        sysGrey();
    }
    var chat = $jq.connection.myHub;
    ipAddress = document.getElementById("InputIP").value;
    document.getElementById("MainContent_masterchildBody_iptocam").value = ipAddress;
    console.log("IP address from InputIP is " + document.getElementById("MainContent_masterchildBody_iptocam").value);
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
            //setInterval(function () {
            //    f.style.visibility = (f.style.visibility == 'hidden' ? '' : 'hidden');
            //}, 2000);
            var arraydata = message.split(',');
            if (arraydata[0] == "NetworkControl") {
                if (arraydata[1] == 'PanelKey') {
                    if (arraydata[2] == "ComputerSystemON") {
                        var imgpc = document.getElementById("ppower");
                        imgpc.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                        $jq(imgpc).addClass('oncolor');
                    }

                    else {
                        var imgpc = document.getElementById("ppower");
                        imgpc.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                        $jq(imgpc).removeClass('oncolor');
                    }

                }
                else if (arraydata[1] == "Heartbeat") {
                    if (arraydata[3] == '待机') {
                        var img = document.getElementById("syspower");
                        img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        closedstatus(arraydata);
                        $jq(img).removeClass('oncolor');
                    }
                    else {
                        var img = document.getElementById("syspower");
                        img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $jq(img).addClass('oncolor');
                        addclickeffect();
                        //}
                        //else {
                        //    var img = document.getElementById("syspower");
                        //    img.src = "Images/greyed/sysgrey.png";
                        //    $jq(img).removeClass('oncolor');
                        //}
                        if (arraydata[5] == '已开机') {//On
                            var imgpc = document.getElementById("ppower");
                            imgpc.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                            $jq(imgpc).addClass('oncolor');
                        }
                        else {
                            var imgpc = document.getElementById("ppower");
                            imgpc.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
                            $jq(imgpc).removeClass('oncolor');
                        }
                        if (arraydata[12] == '锁定') {//Locked
                            var src = document.getElementById('lock');
                            src.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_262.png";
                            $jq(src).addClass('oncolor');
                        }
                        else {
                            var src = document.getElementById('lock');
                            src.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_264.png";
                            $jq(src).addClass('oncolor');
                        }
                        if (arraydata[9] == '停') {
                            var img = document.getElementById("Scdown");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $jq(img).removeClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $jq(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $jq(img).addClass('oncolor');
                        }
                        else if (arraydata[9] == '降') {//Down
                            var img = document.getElementById("Scdown");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $jq(img).addClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $jq(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $jq(img).removeClass('oncolor');
                        }
                        else if (arraydata[9] == '升') {//Up
                            var img = document.getElementById("Scup");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $jq(img).addClass('oncolor');
                            var img = document.getElementById("Scdown");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $jq(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $jq(img).removeClass('oncolor');
                        }
                        if (arraydata[8] == '开') {//Open
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $jq(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $jq(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $jq(curtain).removeClass('oncolor');
                        }
                        else if (arraydata[8] == '关') {//Close
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $jq(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $jq(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $jq(curtain).removeClass('oncolor');

                        }
                        else if (arraydata[8] == '停')//Stop
                        {
                            var curtain = document.getElementById('CurtainClose');
                            curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
                            $jq(curtain).removeClass('oncolor');
                            var curtain = document.getElementById('CurtainStop');
                            curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
                            $jq(curtain).addClass('oncolor');
                            var curtain = document.getElementById('CurtainOpen');
                            curtain.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
                            $jq(curtain).removeClass('oncolor');

                        }
                        switch (arraydata[11]) {
                            case '台式电脑'://Desktop
                                var img = document.getElementById('desktop1');
                                img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $jq(img).addClass('oncolor');
                                document.getElementById('laptop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $jq(document.getElementById('laptop1')).removeClass('oncolor');
                                document.getElementById('Moremedia').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
                                $jq(document.getElementById('Moremedia')).removeClass('oncolor');
                                break;
                            case '手提电脑'://Laptop
                                var img = document.getElementById('laptop1');
                                img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $jq(img).addClass('oncolor');
                                document.getElementById('desktop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $jq(document.getElementById('desktop1')).removeClass('oncolor');
                                document.getElementById('Moremedia').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
                                $jq(document.getElementById('Moremedia')).removeClass('oncolor');
                                break;
                            default:
                                var img = document.getElementById('Moremedia');
                                img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
                                $jq(img).addClass('oncolor');
                                document.getElementById('laptop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $jq(document.getElementById('laptop1')).removeClass('oncolor');
                                document.getElementById('desktop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $jq(document.getElementById('desktop1')).removeClass('oncolor');
                                break;

                        }

                        if (arraydata[6] == '已关机') {//Closed
                            var proj1 = document.getElementById('projgreen');
                            proj1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                            $jq(proj1).removeClass('oncolor');
                            var proj2 = document.getElementById('projred');
                            proj2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                            $jq(proj2).addClass('oncolor');
                        }
                        else {
                            var proj1 = document.getElementById('projgreen');
                            proj1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                            $jq(proj1).addClass('oncolor');
                            var proj2 = document.getElementById('projred');
                            proj2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                            $jq(proj2).removeClass('oncolor');
                        }
                        if (arraydata[10] == '关') {//Off
                            var light1 = document.getElementById("lighton");
                            light1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
                            $jq(light1).removeClass('oncolor');
                            var light2 = document.getElementById("lightoff");
                            light2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
                            $jq(light2).addClass('oncolor');
                        }
                        else {
                            var light1 = document.getElementById("lighton");
                            light1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
                            $jq(light1).addClass('oncolor');
                            var light2 = document.getElementById("lightoff");
                            light2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
                            $jq(light2).removeClass('oncolor');
                        }

                    }
                }
            }
            else {
                if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            var img = document.getElementById("syspower");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                            $jq(img).addClass('oncolor');
                            if (arraydata[2] == 'projopen') {
                                var proj1 = document.getElementById('projgreen');
                                proj1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                                $jq(proj1).addClass('oncolor');
                                var proj2 = document.getElementById('projred');
                                proj2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                                $jq(proj2).removeClass('oncolor');
                            }
                            else if (arraydata[2] == 'projoff') {
                                var proj1 = document.getElementById('projgreen');
                                proj1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
                                $jq(proj1).removeClass('oncolor');
                                var proj2 = document.getElementById('projred');
                                proj2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
                                $jq(proj2).addClass('oncolor');
                                
                            }
                            break;
                        case 'SystemOff':
                            var img = document.getElementById("syspower");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                            $jq(img).removeClass('oncolor');
                            break;
                        case 'DSDown':
                            var img = document.getElementById("Scdown");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $jq(img).addClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $jq(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $jq(img).removeClass('oncolor');
                            break;
                        case 'DSUp':
                            var img = document.getElementById("Scup");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $jq(img).addClass('oncolor');
                            var img = document.getElementById("Scdown");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $jq(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $jq(img).removeClass('oncolor');
                            break;
                        case 'DSStop':
                            var img = document.getElementById("Scdown");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
                            $jq(img).removeClass('oncolor');
                            var img = document.getElementById("Scup");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
                            $jq(img).removeClass('oncolor');
                            var img = document.getElementById("scStop");
                            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
                            $jq(img).addClass('oncolor');
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
                        $jq(img).addClass('oncolor');
                        //if (arraydata[4] == "Computer") {
                        //    var imgpc = document.getElementById("ppower");
                        //    var source = imgpc.getAttribute('class');
                        //    imgpc.setAttribute('src', "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png");
                        //    if (source.includes('oncolor')) {
                        //        $jq(imgpc).removeClass('oncolor');
                        //    }
                        //    else {
                        //        // imgpc.setAttribute('src', "Images/greyed/pcgrey.png");
                        //        $jq(imgpc).addClass('oncolor');
                        //    }
                        //}
                        switch (arraydata[3]) {
                            case 'Desktop':
                                var img = document.getElementById('desktop1');
                                img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $jq(img).addClass('oncolor');
                                document.getElementById('laptop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $jq(document.getElementById('laptop1')).removeClass('oncolor');
                                document.getElementById('Moremedia').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
                                $jq(document.getElementById('Moremedia')).removeClass('oncolor');
                                break;
                            case 'Laptop':
                                var img = document.getElementById('laptop1');
                                img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $jq(img).addClass('oncolor');
                                document.getElementById('desktop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $jq(document.getElementById('desktop1')).removeClass('oncolor');
                                document.getElementById('Moremedia').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
                                $jq(document.getElementById('Moremedia')).removeClass('oncolor');
                                break;
                            default:
                                var img = document.getElementById('Moremedia');
                                img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
                                $jq(img).addClass('oncolor');
                                document.getElementById('laptop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                                $jq(document.getElementById('laptop1')).removeClass('oncolor');
                                document.getElementById('desktop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                                $jq(document.getElementById('desktop1')).removeClass('oncolor');
                                break;
                        }
                        if (arraydata[5] == "CentralLock") {
                            var imglock = document.getElementById('lock');
                            document.getElementById('lock').src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_262.png";
                            $jq(imglock).addClass('oncolor');
                        }
                        else {
                            var imglock = document.getElementById('lock');
                            document.getElementById('lock').src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_264.png";
                            $jq(imglock).addClass('oncolor');
                        }
                    }
                    else if (arraydata[2] == "SystemSwitchOff") {
                        var img = document.getElementById("syspower");
                        img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $jq(img).removeClass('oncolor');

                    }
                }
                else if (arraydata[1] == "PanelKey") {
                    if (arraydata[2] == "PCON")
                        $jq('#ppower').closest("td").find("img").attr('src', "../Images/中控首页按钮/on/pcon.png");

                    else if (arraydata[2] == "PCOFF")
                        $jq('#ppower').closest("td").find("img").attr('src', "../Images/AllImages/images/图标_212.png");

                }
            }
            if (arraydata[0] == "Temp") {
                document.getElementById("tempvalue").innerHTML = arraydata[1] + " °C";
                document.getElementById("humidvalue").innerHTML = arraydata[2] + "%";
                document.getElementById("pmvalue").innerHTML = arraydata[3] + " µg/m3";
                if (arraydata[5] != "--") {
                    document.getElementById("co2").innerHTML = arraydata[10] + "ppm";
                    document.getElementById("intensityvalue").innerHTML = arraydata[13] + "nits";
                    document.getElementById("methanalvalue").innerHTML = arraydata[11] + "mg/m3";
                    document.getElementById("voltvalue").innerHTML = arraydata[5] + "V";
                    document.getElementById("I1").innerHTML = (((arraydata[6] / 1000.00) * arraydata[5]) / 1000.00).toFixed(2) + "KW";
                    document.getElementById("I2").innerHTML = (((arraydata[7] / 1000.00) * arraydata[5]) / 1000.00).toFixed(2) + "KW";
                    document.getElementById("I3").innerHTML = (((arraydata[8] / 1000.00) * arraydata[5]) / 1000.00).toFixed(2) + "KW";
                    document.getElementById("I4").innerHTML = (((arraydata[9] / 1000.00) * arraydata[5]) / 1000.00).toFixed(2) + "KW";

                }
            }
            if (arraydata[2] == 'Offline' || arraydata[1] == 'Unsuccessful' || arraydata[2] =='离线') {
                allGrey();
                document.getElementById("devicestatus").innerHTML = "Offline";
                document.getElementById("deviceStatusHidden").value = "Offline";
                document.getElementById("devicestatus").style.color = "white";
            }
        }
    };

    $jq.connection.hub.start({ waitForPageLoad: false }).done(function () {
        AllNormal();
        chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
        
        SetVolume = function (val) {
            var lastVal = this.document.getElementById("volchange").innerText;
            var img = document.getElementById("volsymbol");
            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
            if (lastVal > val && val > 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 21 2B");

            }
            else if (val == 0) {
                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量静音.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 22 2C");
            }
            else if (lastVal < val) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 2A");

            }
            this.document.getElementById("volchange").innerText = val;
            console.log('After: ' + val);
        };
        MicControl = function (val) {
            var lastVal = this.document.getElementById("micchange").innerText;
            var img = document.getElementById("micIcon");
            img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
            if (lastVal > val && val > 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 74 7e");
            }
            else if (val == 0) {
                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦静音.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 75 7f");
            }
            else if (lastVal < val) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 73 7d");
            }
            this.document.getElementById("micchange").innerText = val;
            console.log('After: ' + val);
        };

        $jq(document).on("click", "#lock", function () {
            var imgpc = document.getElementById('lock');
            var source = imgpc.getAttribute('src');
            if (source == "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_262.png")
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
        });
        $jq(document).on("click", "#Scup", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 76 80");
        });
        $jq(document).on("click", "#Scdown", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 56 60");
        });
        $jq(document).on("click", "#scStop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 66 70");
        });
        $jq(document).on("click", "#CurtainOpen", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 77 81");
        });
        $jq(document).on("click", "#CurtainStop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 67 71");
        });
        $jq(document).on("click", "#CurtainClose", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 57 61");
        });
        $jq(document).on("click", "#syspower", function () {
            if ($jq(this).hasClass("oncolor")) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 05 02 1F 2A");
                chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
            }                
            else
            {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 05 02 1E 29");
                chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
            }                
        });
        $jq(document).on("click", "#ppower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 17 21");
        });
        $jq(document).on("click", "#desktop1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 10 1A");
        });
        $jq(document).on("click", "#laptop1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 11 1b");
        });
        $jq(document).on("click", "#projgreen", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 33 3D");
        });
        $jq(document).on("click", "#projred", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 43 4D");
        });
    });

});

function allGrey(){
  
    var img = document.getElementById("ppower");
    img.src = "Images/greyed/pcgrey.png" ;
    $jq(img).removeClass("imgclick oncolor");
   
    var img = document.getElementById("lock");
    img.src = "Images/greyed/lock1.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Scup");
    img.src = "Images/greyed/scup.png"; 
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Scdown");
    img.src = "Images/greyed/scdown.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("scStop");
    img.src = "Images/greyed/scstop.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("desktop1");
    img.src = "Images/greyed/desktop.png";
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("laptop1");
    img.src = "Images/greyed/laptop.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainOpen");
    img.src = "Images/greyed/copengrey.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainClose");
    img.src = "Images/greyed/cclosegrey.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("CurtainStop");
    img.src = "Images/greyed/cstopgrey.png";
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("projgreen");
    img.src = "Images/greyed/proj1.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("projred");
    img.src = "Images/greyed/proj2.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("lighton");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png" ;
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("lightoff");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
    $jq(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Moremedia");
    img.src = "Images/greyed/more.png";
    $jq(img).removeClass("imgclick oncolor");
   
    
}
function sysGrey() {
    var img = document.getElementById("syspower");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
    $jq(img).removeClass("imgclick oncolor");
    $jq("#vol-control").prop("disabled", true);
    $jq("#mic-control").prop("disabled", true);
    $jq("#yellowbuttons").removeClass("imgclick");
}

function AllNormal() {
    var img = document.getElementById("syspower");
    img.src = "Images/greyed/sysgrey.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("ppower");
    img.src = "Images/greyed/pcgrey.png";
    $jq(img).addClass("imgclick");
    
    var img = document.getElementById("lock");
    img.src = "Images/greyed/lock1.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("Scup");
    img.src = "Images/greyed/scup.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("Scdown");
    img.src = "Images/greyed/scdown.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("scStop");
    img.src = "Images/greyed/scstop.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("desktop1");
    img.src = "Images/greyed/desktop.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("laptop1");
    img.src = "Images/greyed/laptop.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("CurtainOpen");
    img.src = "Images/greyed/copengrey.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("CurtainClose");
    img.src = "Images/greyed/cclosegrey.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("CurtainStop");
    img.src = "Images/greyed/cstopgrey.png";
    $jq(img).addClass("imgclick");
    var img = document.getElementById("projgreen");
    img.src = "Images/greyed/proj1.png";
    $jq(img).addClass("imgclick");
    
    var img = document.getElementById("projred");
    img.src = "Images/greyed/proj2.png" ;
    $jq(img).addClass("imgclick");
   
    var img = document.getElementById("lighton");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
    $jq(img).addClass("imgclick");
   
    var img = document.getElementById("lightoff");
    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
    $jq(img).addClass("imgclick");
   
    var img = document.getElementById("Moremedia");
    img.src = "Images/greyed/more.png";
    $jq(img).addClass("imgclick");
    
    $jq("#vol-control").prop("disabled", false);
    $jq("#mic-control").prop("disabled", false);
    $jq("#yellowbuttons").addClass("imgclick");
}


function Cam1(ipadd) {
    var player1 = document.getElementById('plugin_inst_1');
    document.getElementById('src1').value = ipadd + "cam/realmonitor?channel=1&subtype=2";
    player1.play(ipadd);
    var player2 = document.getElementById('plugin_inst_2');

    var src2 = document.getElementById("src2");
    var videostream = ipadd + "cam/realmonitor?channel=1&subtype=2";
    player2.play(videostream);
    src2.value = videostream;
    
}
function Cam2(ipadd) {
    var player2 = document.getElementById('plugin_inst_3');
    var src3 = document.getElementById("src3");
    var videostream = ipadd + "cam/realmonitor?channel=1&subtype=2";
    src3.value = videostream;
    player2.play(videostream);
    
}
function Cam3(ipadd) {
    var player2 = document.getElementById('plugin_inst_4');
    var src4 = document.getElementById("src4");
    var videostream = ipadd + "cam/realmonitor?channel=1&subtype=2";
    src4.value = videostream;
    player2.play(videostream);
    
}
function Cam4(ipadd) {
    var player2 = document.getElementById('plugin_inst_5');
    var src5 = document.getElementById("src5");
    var videostream = ipadd + "cam/realmonitor?channel=1&subtype=2";
    src5.value = videostream;
    player2.play(videostream);
    
}

function closedstatus(arraydata){

   

    //}
    //else {
    //    var img = document.getElementById("syspower");
    //    img.src = "Images/greyed/sysgrey.png";
    //    $jq(img).removeClass('oncolor');
    //}
    //if (arraydata[5] == 'On') {
        var imgpc = document.getElementById("ppower");
        imgpc.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
        //$jq(imgpc).addClass('oncolor').removeClass('imgclick');
        $jq(imgpc).removeClass('imgclick oncolor');
    //}
    //else {
    //    var imgpc = document.getElementById("ppower");
    //    imgpc.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png";
    //    $jq(imgpc).removeClass('imgclick oncolor');
    //}
    if (arraydata[12] == 'Locked') {
        var src = document.getElementById('lock');
        src.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_214.png";
       
        $jq(src).removeClass('imgclick oncolor');
    }
    else {
        var src = document.getElementById('lock');
        src.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_216.png";
        //$jq(src).addClass(' oncolor').removeClass('imgclick');
        $jq(src).removeClass('imgclick oncolor');
    }
    //if (arraydata[9] == 'Stop') {
        var img = document.getElementById("Scdown");
        img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
        $jq(img).removeClass('imgclick oncolor');
        var img = document.getElementById("Scup");
        img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png"
        $jq(img).removeClass('imgclick oncolor');
        var img = document.getElementById("scStop");
        img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
        $jq(img).removeClass('imgclick oncolor');
    //}
    //else if (arraydata[9] == 'Down') {
    //    var img = document.getElementById("Scdown");
    //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
    //    $jq(img).removeClass('imgclick');
    //    var img = document.getElementById("Scup");
    //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png"
    //    $jq(img).removeClass('imgclick oncolor');
    //    var img = document.getElementById("scStop");
    //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
    //    $jq(img).removeClass('imgclick oncolor');
    //}
    //else if (arraydata[9] == 'Up') {
    //    var img = document.getElementById("Scup");
    //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png";
    //    $jq(img).removeClass('imgclick  oncolor');
    //    var img = document.getElementById("Scdown");
    //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png";
    //    $jq(img).removeClass('imgclick oncolor');
    //    var img = document.getElementById("scStop");
    //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png";
    //    $jq(img).removeClass('imgclick oncolor');
    //}
    //if (arraydata[8] == 'Open') {
        var curtain = document.getElementById('CurtainOpen');
        curtain.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
        $jq(curtain).removeClass('imgclick oncolor');
        var curtain = document.getElementById('CurtainClose');
        curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
        $jq(curtain).removeClass('imgclick oncolor');
        var curtain = document.getElementById('CurtainStop');
        curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
        $jq(curtain).removeClass('imgclick oncolor');
    //}
    //else if (arraydata[8] == 'Close') {
    //    var curtain = document.getElementById('CurtainClose');
    //    curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
    //    $jq(curtain).addClass('oncolor').removeClass('imgclick');
    //    var curtain = document.getElementById('CurtainStop');
    //    curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
    //    $jq(curtain).removeClass('imgclick oncolor');
    //    var curtain = document.getElementById('CurtainOpen');
    //    curtain.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
    //    $jq(curtain).removeClass('imgclick oncolor');

    //}
    //else (arraydata[8] == 'Stop')
    //{
    //    var curtain = document.getElementById('CurtainClose');
    //    curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png";
    //    $jq(curtain).removeClass('imgclick oncolor');
    //    var curtain = document.getElementById('CurtainStop');
    //    curtain.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png";
    //    $jq(curtain).addClass('oncolor').removeClass('imgclick');
    //    var curtain = document.getElementById('CurtainOpen');
    //    curtain.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_106.png";
    //    $jq(curtain).removeClass('imgclick oncolor');

    //}
    //switch (arraydata[11]) {
    //    case 'Desktop':
            var img = document.getElementById('desktop1');
            img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
            $jq(img).removeClass('imgclick oncolor');
            document.getElementById('laptop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
            $jq(document.getElementById('laptop1')).removeClass('imgclick oncolor');
            document.getElementById('Moremedia').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
            $jq(document.getElementById('Moremedia')).removeClass('imgclick oncolor');
    //        break;
    //    case 'Laptop':
    //        var img = document.getElementById('laptop1');
    //        img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
    //        $jq(img).addClass('oncolor').removeClass('imgclick');
    //        document.getElementById('desktop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
    //        $jq(document.getElementById('desktop1')).removeClass('imgclick oncolor');
    //        document.getElementById('Moremedia').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
    //        $jq(document.getElementById('Moremedia')).removeClass('imgclick oncolor');
    //        break;
    //    default:
    //        var img = document.getElementById('Moremedia');
    //        img.src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_162.png";
    //        $jq(img).addClass('oncolor').removeClass('imgclick');
    //        document.getElementById('laptop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
    //        $jq(document.getElementById('laptop1')).removeClass('imgclick oncolor');
    //        document.getElementById('desktop1').src = "Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
    //        $jq(document.getElementById('desktop1')).removeClass('imgclick oncolor');
    //        break;

    //}

    if (arraydata[6] == 'Closed') {
        var proj1 = document.getElementById('projgreen');
        proj1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
        $jq(proj1).removeClass('imgclick oncolor');
        var proj2 = document.getElementById('projred');
        proj2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
        $jq(proj2).removeClass('imgclick oncolor');
    }
    else {
        var proj1 = document.getElementById('projgreen');
        proj1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png";
        $jq(proj1).removeClass('imgclick oncolor');
        var proj2 = document.getElementById('projred');
        proj2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png";
        $jq(proj2).removeClass('imgclick oncolor');
    }
    if (arraydata[10] == 'Off') {
        var light1 = document.getElementById("lighton");
        light1.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png";
        $jq(light1).removeClass('imgclick oncolor');
        var light2 = document.getElementById("lightoff");
        light2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
        //$jq(light2).addClass('oncolor');
        $jq(light2).removeClass('imgclick oncolor');
    }
    else {
        var light1 = document.getElementById("lighton");
        light1.src = "Images/greyed/lightgrey.png";
       // $jq(light1).addClass('oncolor');
        $jq(light1).removeClass('imgclick oncolor');
        var light2 = document.getElementById("lightoff");
        light2.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png";
        $jq(light2).removeClass('imgclick oncolor');
    }
    
}

function addclickeffect() {
    var img = document.getElementById("syspower");
        
        $jq(img).addClass("imgclick");
        var img = document.getElementById("ppower");
       
        $jq(img).addClass("imgclick");

        var img = document.getElementById("lock");
        
        $jq(img).addClass("imgclick");
        var img = document.getElementById("Scup");
        
        $jq(img).addClass("imgclick");
        var img = document.getElementById("Scdown");
        
        $jq(img).addClass("imgclick");
        var img = document.getElementById("scStop");
        
        $jq(img).addClass("imgclick");
        var img = document.getElementById("desktop1");
       
        $jq(img).addClass("imgclick");
        var img = document.getElementById("laptop1");
        
        $jq(img).addClass("imgclick");
        var img = document.getElementById("CurtainOpen");
       
        $jq(img).addClass("imgclick");
        var img = document.getElementById("CurtainClose");
        
        $jq(img).addClass("imgclick");
        var img = document.getElementById("CurtainStop");
        
        $jq(img).addClass("imgclick");
        var img = document.getElementById("projgreen");
        
        $jq(img).addClass("imgclick");

        var img = document.getElementById("projred");
       
        $jq(img).addClass("imgclick");

        var img = document.getElementById("lighton");
       
        $jq(img).addClass("imgclick");

        var img = document.getElementById("lightoff");
       
        $jq(img).addClass("imgclick");

        var img = document.getElementById("Moremedia");
       
        $jq(img).addClass("imgclick");

        $jq("#vol-control").prop("disabled", false);
        $jq("#mic-control").prop("disabled", false);
       
}
//Remote Control Frame
var modal = document.getElementById("RemoteControl");

function DisplayModal() {
    if (document.getElementById("devicestatus").innerHTML == "离线") {
        $("#yellowbuttons").removeClass("imgclick");
    }
    else {
        $("#yellowbuttons").removeClass("imgclick");
        document.getElementById('RemoteControl').style.display = "block";
    }
};


