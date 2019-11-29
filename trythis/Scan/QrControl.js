var ip;

(function () {
    
    var chat = $.connection.myHub;
    chat.client.broadcastMessage = function (name, message) {
         ip = document.getElementById("MainContent_iptoControl").value;
        if (name == ip) {

            var arraydata = message.split(",");
            
             if (arraydata[2] == '离线' || arraydata[1] == 'Unsuccessful' || arraydata[2] == 'Offline') {
                var img = document.getElementById("syspower");
                img.src = "../Images/greyed/sysgrey.png";
                $(img).removeClass('oncolor');
                allGrey();
            }
            if (arraydata[1] == "Heartbeat") {
                if (arraydata[3] == '待机') {
                    var img = document.getElementById("syspower");
                    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                    closedstatus();

                    $(img).removeClass('oncolor');
                }
                else {
                    var img = document.getElementById("syspower");
                    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                    $(img).addClass('oncolor');
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
                    closedstatus();
                    addclickeffect();
                    switch (arraydata[11]) {
                        case '台式电脑'://Desktop
                            var img = document.getElementById('desktop');
                            img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                            $(img).addClass('oncolor');
                            document.getElementById('laptop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                            $(document.getElementById('laptop')).removeClass('oncolor');
                            document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
                            $(document.getElementById('Moremedia')).removeClass('oncolor');
                            break;
                        case '手提电脑'://Laptop
                            var img = document.getElementById('laptop');
                            img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                            $(img).addClass('oncolor');
                            document.getElementById('desktop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                            $(document.getElementById('desktop')).removeClass('oncolor');
                            document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
                            $(document.getElementById('Moremedia')).removeClass('oncolor');
                            break;
                        default:
                            var img = document.getElementById('Moremedia');
                            img.src = "../Images/AllImages/images/图标_194.png";
                            $(img).addClass('oncolor');
                            document.getElementById('laptop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                            $(document.getElementById('laptop')).removeClass('oncolor');
                            document.getElementById('desktop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                            $(document.getElementById('desktop')).removeClass('oncolor');
                            break;

                    }
                }
            }
            else if (arraydata[1] == "KeyValue") {
                switch (arraydata[2]) {
                    case 'SystemON':
                        var img = document.getElementById("syspower");
                        img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $(img).addClass('oncolor');
                        addclickeffect();
                        break;
                    case 'SystemOff':
                        var img = document.getElementById("syspower");
                        img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $(img).removeClass('oncolor');
                        closedstatus();
                        break;
                    case 'projopen':
                        var proj1 = document.getElementById('projgreen');
                        
                        $(proj1).addClass('oncolor');
                        var proj2 = document.getElementById('projred');
                        
                        $(proj2).removeClass('oncolor');
                        break;
                    case 'projoff':
                        var proj1 = document.getElementById('projgreen');
                        
                        $(proj1).removeClass('oncolor');
                        var proj2 = document.getElementById('projred');
                        
                        $(proj2).addClass('oncolor');
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
                    default:
                        break;
                }
            }
            else if (arraydata[1] == "LEDIndicator") {
                if (arraydata[2] == "SystemSwitchOn") {
                    var img = document.getElementById("syspower");
                    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                    $(img).addClass('oncolor');
                    addclickeffect();
                    switch (arraydata[3]) {
                        case 'Desktop':
                            var img = document.getElementById('desktop');
                            img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                            $(img).addClass('oncolor');
                            document.getElementById('laptop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                            $(document.getElementById('laptop')).removeClass('oncolor');
                            document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
                            $(document.getElementById('Moremedia')).removeClass('oncolor');
                            break;
                        case 'Laptop':
                            var img = document.getElementById('laptop');
                            img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                            $(img).addClass('oncolor');
                            document.getElementById('desktop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                            $(document.getElementById('desktop')).removeClass('oncolor');
                            document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
                            $(document.getElementById('Moremedia')).removeClass('oncolor');
                            break;
                        default:
                            var img = document.getElementById('Moremedia');
                            img.src = "../Images/AllImages/images/图标_194.png";
                            $(img).addClass('oncolor');
                            document.getElementById('laptop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
                            $(document.getElementById('laptop')).removeClass('oncolor');
                            document.getElementById('desktop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
                            $(document.getElementById('desktop')).removeClass('oncolor');
                            break;
                    }
                }
                else if (arraydata[2] == "SystemSwitchOff") {
                    var img = document.getElementById("syspower");
                    img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                    $(img).removeClass('oncolor');
                }
            }

            else if (arraydata[1] == "PanelKey") {
                if (arraydata[2] == "PCON")
                $('#ppower').closest("td").find("img").attr('src', "../Images/中控首页按钮/on/pcon.png");
               
               else if (arraydata[2] == "PCOFF")
                $('#ppower').closest("td").find("img").attr('src', "../Images/AllImages/images/图标_212.png");
                
            }
        }
    };
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {

        if (ip != "") {
            chat.server.sendControlKeys(ip, "8B B9 00 03 05 01 09");
        }
        $(document).on("click", "#syspower", function () {
            if ($(this).hasClass("oncolor"))
                chat.server.sendControlKeys(ip, "8B B9 00 04 05 02 1F 2A");
            else
                chat.server.sendControlKeys(ip, "8B B9 00 04 05 02 1E 29");
        });
        SetVolume = function (val) {
            var lastVal = this.document.getElementById("volchange").innerText;
            var img = document.getElementById("volsymbol");
            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
            if (lastVal > val && val > 0) {
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 21 2B");

            }
            else if (val == 0) {
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/总音量静音.png";
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 22 2C");
            }
            else if (lastVal < val) {
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 20 2A");

            }
            this.document.getElementById("volchange").innerText = val;
            //console.log('After: ' + val);
        };
        MicControl = function (val) {
            var lastVal = this.document.getElementById("micchange").innerText;
            var img = document.getElementById("micIcon");
            img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
            if (lastVal > val && val > 0) {
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 74 7e");
            }
            else if (val == 0) {
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦静音.png";
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 75 7f");
            }
            else if (lastVal < val) {
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 73 7d");
            }
            this.document.getElementById("micchange").innerText = val;
            console.log('After: ' + val);
        };
        WiredMicControl = function (val) {
            var lastVal = this.document.getElementById("wiredmicchange").innerText;
            if (lastVal > val && val > 0) {
                var img = document.getElementById("wiredmicIcon");                
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";               
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 24 2e");
            }
            else if (val == 0) {
                var img = document.getElementById("wiredmicIcon");
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦静音.png";
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 25 2f");
            }
            else if (lastVal < val) {

                var img = document.getElementById("wiredmicIcon");
                
                img.src = "../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                
                chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 23 2d");
            }
            this.document.getElementById("wiredmicchange").innerText = val;
        };
        $(document).on("click", "#desktop", function () {
            chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 10 1A");
        });
        $(document).on("click", "#laptop", function () {
            chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 11 1b");
        });
        $(document).on("click", "#Moremedia", function () {
            chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 12 1c");
        });
        $(document).on("click", "#ppower", function () {
            chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 17 21");
        });
        $(document).on("click", "#projgreen", function () {
            chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 33 3D");
        });
        $(document).on("click", "#projred", function () {
            chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 43 4D");
        });
    });
})(jQuery);

function allGrey() {
    var img = document.getElementById("desktop");
    img.src = "../Images/greyed/desktop.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("laptop");
    img.src = "../Images/greyed/laptop.png";
    $(img).removeClass("imgclick oncolor");
    var img = document.getElementById("Moremedia");
    img.src = "../Images/AllImages/images/图标_194.png";
    $(img).removeClass("imgclick oncolor");
    var proj1 = document.getElementById('projgreen');
    proj1.src = "../Images/greyed/proj1.png";
    $(proj1).removeClass('oncolor');
    var proj2 = document.getElementById('projred');
    proj2.src = "../Images/greyed/proj2.png";
    $(proj2).addClass('oncolor');
    break;
}

function addclickeffect() {
    var img = document.getElementById("syspower");

    $(img).addClass("imgclick");
    var img = document.getElementById("desktop");

    $(img).addClass("imgclick");
    var img = document.getElementById("laptop");

    $(img).addClass("imgclick");
    var img = document.getElementById("Moremedia");

    $(img).addClass("imgclick");
    var img = document.getElementById("ppower");

    $(img).addClass("imgclick");
    var img = document.getElementById("projgreen");

    $(img).addClass("imgclick");
    var img = document.getElementById("projred");

    $(img).addClass("imgclick");
}
function closedstatus() {
    var img = document.getElementById('desktop');
    img.src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_158.png";
    $(img).removeClass('imgclick oncolor');
    document.getElementById('laptop').src = "../Images/中控首页按钮/首页按钮-默认状态/控制页面_160.png";
    $(document.getElementById('laptop')).removeClass('imgclick oncolor');
    document.getElementById('Moremedia').src = "../Images/AllImages/images/图标_194.png";
    $(document.getElementById('Moremedia')).removeClass('imgclick oncolor');
    $('#ppower').closest("td").find("img").attr('src', "../Images/AllImages/images/图标_212.png");
    $('#projred').closest("td").find("img").attr('src', "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png");
    $('#projgreen').closest("td").find("img").attr('src', "../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png");
}
    