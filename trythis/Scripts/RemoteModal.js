
var ipAddress = "";
function uncheck() {
    $('#desktop').closest("td").find("img").attr('src', "Images/AllImages/images/图标_158.png");

    $('#laptop').closest("td").find("img").attr('src', "Images/AllImages/images/图标_160.png");

    $('#platform').closest("td").find("img").attr('src', "Images/AllImages/images/图标_194.png");

    $('#digitalEquipment').closest("td").find("img").attr('src', "Images/AllImages/images/图标_194.png");

    $('#dvd').closest("td").find("img").attr('src', "Images/AllImages/images/图标_246.png");

    $('#bluray').closest("td").find("img").attr('src', "Images/AllImages/images/图标_272.png");

    $('#tv').closest("td").find("img").attr('src', "Images/AllImages/images/图标_298.png");

    $('#camera').closest("td").find("img").attr('src', "Images/AllImages/images/图标_220.png");
    $('#recorder').closest("td").find("img").attr('src', "Images/AllImages/images/图标_324.png");
}

function offdevices() {
    $('#systempower').closest("td").find("img").attr('src', "Images/AllImages/images/图标_212.png");
    $('#pcpower').closest("td").find("img").attr('src', "Images/AllImages/images/图标_212.png");
    $('#sysLock').closest("td").find("img").attr('src', "Images/AllImages/images/图标_214.png");
    $('#podiumLock').closest("td").find("img").attr('src', "Images/AllImages/images/图标_262.png");
    $('#classLock').closest("td").find("img").attr('src', "Images/AllImages/images/图标_236.png");
}
$(function () {
    $("#lightIcons8").hide();
    $("#lightIcons3").hide();
    $("#lightIcons4").hide();
    $("#lightIcons5").hide();
    $("#lightIcons6").hide();
    $("#lightIcons7").hide();
    $("#lightIcons2").hide();
    $("#light1").closest("td").css("background-color", "#4ecdc4");
    $("#screenIcons2").hide();
    $("#curtainIcons1").hide();
    $("#curtainIcons2").hide();
    $("#curtainIcons3").hide();
    $("#curtainIcons4").hide();
    $("#curtainIcons5").hide();
    $("#curtainIcons6").hide();
    $("#screen1").closest("td").css("background-color", "#4ecdc4");
    $("#screenOptions").show();
    $("#curtainOptions").hide();
    $("#ac1div").show();
    $("#ac2div").hide();
    $("#ac3div").hide();
    $("#ac4div").hide();
    $("#air1div").hide();
    $("#air2div").hide();
    $("#air3div").hide();
    $("#air4div").hide();
    $("#ac1").closest("td").css("background-color", "#4ecdc4");
    var chat = $.connection.myHub;
  //ipAddress = parent.getElementById("InputIP").value;
   // ipAddress = sessionStorage.getItem('ipofremote');
    ipAddress = document.getElementById("sessionInputIP").value;
   // console.log(ipAddress);
    chat.client.broadcastMessage = function (name, message) {
       // console.log(name + "    and  " + ipAddress);
        if (name == ipAddress) {
            
            var arraydata = message.split(',');
            if (arraydata[1] == "Heartbeat") {
                if (arraydata[3] == '待机') {
                    var img = document.getElementById("systempower");
                    img.src = "Images/AllImages/images/图标_210.png";
                    NoNotification(arraydata);
                }
                else {
                    var img = document.getElementById("systempower");
                    img.src = "Images/中控首页按钮/on/systemon.png"; 

                    if (arraydata[5] == '已开机') {//on
                        var imgpc = document.getElementById("pcpower");
                        imgpc.src = "Images/中控首页按钮/on/pcon.png";
                    }
                    else {
                        var imgpc = document.getElementById("pcpower");
                        imgpc.src = "Images/AllImages/images/图标_212.png";
                    }

                    if (arraydata[9] == '停') {
                        $('#screendown1').closest("td").find("img").attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_134.png");
                        $('#screenstop1').closest("td").find("img").attr('src', "Images/中控首页按钮/on/screenstop.png");
                        $('#screenup1').closest("td").find("img").attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_132.png");

                    }
                    else if (arraydata[9] == '降') {
                        $('#screendown1').attr('src', "Images/中控首页按钮/on/screendown.png");
                        $('#screenstop1').attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_136.png");
                        $('#screenup1').attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_132.png");

                    }
                    else if (arraydata[9] == '升') {
                        $('#screendown1').attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_134.png");
                        $('#screenstop1').attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_136.png");
                        $('#screenup1').attr('src', "Images/中控首页按钮/on/screenup.png");

                    }
                    if (arraydata[12] == '锁定') {
                        var src = document.getElementById('sysLock');
                        src.src = "Images/中控首页按钮/on/lock1.png";
                    }
                    else {
                        var src = document.getElementById('sysLock');
                        src.src = "Images/中控首页按钮/on/lock1open.png";
                    }
                    if (arraydata[13] == '锁定') {
                        var src = document.getElementById('podiumLock');
                        src.src = "Images/中控首页按钮/on/lock2.png";
                    }
                    else {
                        var src = document.getElementById('podiumLock');
                        src.src = "Images/中控首页按钮/on/lock2open.png";
                    }
                    if (arraydata[14] == '锁定') {
                        var src = document.getElementById('classLock');
                        src.src = "Images/中控首页按钮/on/lock3.png";
                    }
                    else {
                        var src = document.getElementById('classLock');
                        src.src = "Images/中控首页按钮/on/lock3open.png";
                    }
                    uncheck();
                    switch (arraydata[11]) {
                        case '台式电脑':
                            var desk = document.getElementById('desktop');
                            document.getElementById('desktop').checked = true;
                            $(desk).closest("td").find("img").attr('src', "Images/中控首页按钮/on/desk1.png");

                            break;
                        case '手提电脑':
                            document.getElementById('laptop').checked = true;
                            var laptop = document.getElementById('laptop');
                            $(laptop).closest("td").find("img").attr('src', "Images/中控首页按钮/on/lap1.png");

                            break;
                        case '数码展台':
                            document.getElementById('platform').checked = true;
                            $('#platform').closest("td").find("img").attr('src', "Images/中控首页按钮/on/mediadevice.png");
                            break;
                        case '数码设备':
                            document.getElementById('digitalEquipment').checked = true;
                            $('#digitalEquipment').closest("td").find("img").attr('src', "Images/中控首页按钮/on/mediadevice.png");
                            break;
                        case 'DVD':
                            document.getElementById('dvd').checked = true;
                            $('#dvd').closest("td").find("img").attr('src', "Images/中控首页按钮/on/dvd.png");
                            break;
                        case '电视机':
                            document.getElementById('tv').checked = true;
                            $('#tv').closest("td").find("img").attr('src', "Images/中控首页按钮/on/tv.png");
                            break;
                        case '摄像机':
                            document.getElementById('camera').checked = true;
                            $('#camera').closest("td").find("img").attr('src', "Images/中控首页按钮/on/cam.png");
                            break;
                        case '蓝光DVD':
                            document.getElementById('bluray').checked = true;
                            $('#bluray').closest("td").find("img").attr('src', "Images/中控首页按钮/on/blu.png");
                            break;
                        case '录播':
                            document.getElementById('recorder').checked = true;
                            $('#recorder').closest("td").find("img").attr('src', "Images/中控首页按钮/on/recorder.png");
                            break;
                    }

                    if (arraydata[6] == '已关机') {

                        var src = document.getElementById("projectorOff");
                        src.src = "Images/中控首页按钮/on/projred.png";
                        document.getElementById("projectorOn").src = "Images/AllImages/images/图标_184.png";
                    } else {
                        var src = document.getElementById("projectorOn");
                        src.src = "Images/中控首页按钮/on/projgreen.png";
                        document.getElementById("projectorOff").src = "Images/AllImages/images/图标_186.png";
                    }
                }
            }
            else {

                if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            var img = document.getElementById("systempower");
                            img.src = "Images/中控首页按钮/on/systemon.png";
                            break;
                        case 'SystemOff':
                            var img = document.getElementById("systempower");
                            img.src = "Images/AllImages/images/图标_210.png";
                            break;
                        case 'DSDown':
                            $('#screendown1').attr('src', "Images/中控首页按钮/on/screendown.png");
                            $('#screenstop1').attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_136.png" );
                            $('#screenup1').attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_132.png");
                            break;
                        case 'DSUp':
                            $('#screendown1').attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_134.png");
                            $('#screenstop1').attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_136.png");
                            $('#screenup1').attr('src', "Images/中控首页按钮/on/screenup.png");
                            break;
                        case 'DSStop':
                            $('#screendown1').closest("td").find("img").attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_134.png");
                            $('#screenstop1').closest("td").find("img").attr('src',"Images/中控首页按钮/on/screenstop.png");
                            $('#screenup1').closest("td").find("img").attr('src', "Images/中控首页按钮/首页按钮-默认状态/控制页面_132.png");
                            break;
                        case 'projopen':
                            $('#projectorOn').closest("td").find("img").attr('src', "../Images/中控首页按钮/on/projgreen.png");
                            $('#projred').closest("td").find("img").attr('src', "../Images/AllImages/images/图标_186.png");                            
                            break;
                        case 'projoff':
                            $('#projectorOn').closest("td").find("img").attr('src', "../Images/AllImages/images/图标_184.png");
                            $('#projred').closest("td").find("img").attr('src', "../Images/中控首页按钮/on/projred.png");
                            break;
                        
                        case 'volplus':
                            if (document.getElementById("volValue").innerText >= 50) {
                                var img = document.getElementById("volicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                            }
                            break;
                        case 'volminus':
                            if (document.getElementById("volValue").innerText <= 50) {
                                var img = document.getElementById("volicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                            }
                            break;
                        case 'mute':
                            if (document.getElementById("volValue").innerText == 0) {
                                var img = document.getElementById("volicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量静音.png";
                            }
                            break;
                        case 'wirelessvolplus':
                            if (document.getElementById("wirelessValue").innerText >= 50) {
                                var img = document.getElementById("wirelessicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                            }
                            break;
                        case 'wirelessvolminus':
                            if (document.getElementById("wirelessValue").innerText <= 50) {
                                var img = document.getElementById("wirelessicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                            }
                            break;
                        case 'wirelessmute':
                            if (document.getElementById("wirelessValue").innerText == 0) {
                                var img = document.getElementById("wirelessicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦静音.png";
                            }
                            break;
                        case 'wiredvolplus':
                            if (document.getElementById("wiredValue").innerText >= 50) {
                                var img = document.getElementById("wiredicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                            }
                            break;
                        case 'wiredvolminus':
                            if (document.getElementById("wiredValue").innerText <= 50) {
                                var img = document.getElementById("wiredicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                            }
                            break;
                        case 'wiredmute':
                            if (document.getElementById("wiredValue").innerText == 0) {
                                var img = document.getElementById("wiredicons");
                                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/有线麦静音.png";
                            }
                            break;
                        
                        default:
                            break
                    }
                }
                else if (arraydata[1] == "LEDIndicator") {

                    if (arraydata[2] == "SystemSwitchOn") {
                        var img = document.getElementById("systempower");
                        img.src = "Images/中控首页按钮/on/systemon.png";
                        //if (arraydata[4] == "Computer") {
                        //    var imgpc = document.getElementById("pcpower");
                        //    var sourceof = imgpc.getAttribute('src');
                        //    if (sourceof == "Images/AllImages/images/图标_212.png") {
                        //        imgpc.src = "Images/中控首页按钮/on/pcon.png";
                        //    }
                        //    else {
                        //        imgpc.src = "Images/AllImages/images/图标_212.png";
                        //    }
                        //}
                        
                        uncheck();
                        switch (arraydata[3]) {
                            case 'Desktop':
                                document.getElementById('desktop').checked = true;
                                $('#desktop').closest("td").find("img").attr('src', "Images/中控首页按钮/on/desk1.png");
                                break;
                            case 'Laptop':
                                document.getElementById('laptop').checked = true;
                                $('#laptop').closest("td").find("img").attr('src', "Images/中控首页按钮/on/lap1.png");
                                break;
                            case 'DigitalCurtain':
                                document.getElementById('platform').checked = true;
                                $('#platform').closest("td").find("img").attr('src', "Images/中控首页按钮/on/mediadevice.png");
                                break;
                            case 'DigitalScreen':
                                document.getElementById('digitalEquipment').checked = true;
                                $('#digitalEquipment').closest("td").find("img").attr('src', "Images/中控首页按钮/on/mediadevice.png");
                                break;
                            case 'DVD':
                                document.getElementById('dvd').checked = true;
                                $('#dvd').closest("td").find("img").attr('src', "Images/中控首页按钮/on/dvd.png");
                                break;
                            case 'TV':
                                document.getElementById('tv').checked = true;
                                $('#tv').closest("td").find("img").attr('src', "Images/中控首页按钮/on/tv.png");
                                break;
                            case 'VideoCamera':
                                document.getElementById('camera').checked = true;
                                $('#camera').closest("td").find("img").attr('src', "Images/中控首页按钮/on/cam.png");
                                break;
                            case 'Blu-RayDVD':
                                document.getElementById('bluray').checked = true;
                                $('#bluray').closest("td").find("img").attr('src', "Images/中控首页按钮/on/blu.png");
                                break;
                            case 'RecordingSystem':
                                document.getElementById('recorder').checked = true;
                                $('#recorder').closest("td").find("img").attr('src', "Images/中控首页按钮/on/recorder.png");
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
                        if (arraydata[5] == "CentralLock") {

                            document.getElementById("sysLock").src = "Images/中控首页按钮/on/lock1.png";
                        }
                        else 
                            document.getElementById("sysLock").src = "Images/中控首页按钮/on/lock1open.png";                            
                        
                               
                        if (arraydata[6] == "PodiumLockoff") {

                            document.getElementById("podiumLock").src = "Images/中控首页按钮/on/lock2open.png";
                        }
                        else {
                            document.getElementById("podiumLock").src = "Images/中控首页按钮/on/lock2.png";
                        }                        
                            
                        if (arraydata[7] == "ClassLockoff") {

                            document.getElementById("classLock").src = "Images/中控首页按钮/on/lock3open.png";
                        }
                        else                        
                           document.getElementById("classLock").src = "Images/中控首页按钮/on/lock3.png";                                                     
                    }
                    else if (arraydata[2] == "SystemSwitchOff") {
                        
                        var img = document.getElementById("systempower");
                        img.src = "Images/AllImages/images/图标_210.png";
                    }
                }
                else if (arraydata[1] == "PanelKey") {
                    if (arraydata[2] == "PCON")
                        $('#pcpower').closest("td").find("img").attr('src', "../Images/中控首页按钮/on/pcon.png");

                    else if (arraydata[2] == "PCOFF")
                        $('#pcpower').closest("td").find("img").attr('src', "../Images/AllImages/images/图标_212.png");

                }
            }
        };
    };
    var tryingToReconnect = false;

    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        console.log("connected to server signalR");
        ipAddress = document.getElementById("sessionInputIP").value;
        //ipAddress = sessionStorage.getItem('ipofremote');
        chat.server.checkStatus(ipAddress);
        $(document).on("click", "#screen1", function () {
            var tble = document.getElementById("curtainTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#screenIcons1").show();
            $("#screenIcons2").hide();
            $("#curtainIcons1").hide();
            $("#curtainIcons2").hide();
            $("#curtainIcons3").hide();
            $("#curtainIcons4").hide();
            $("#curtainIcons5").hide();
            $("#curtainIcons6").hide();
            $("#screenOptions").show();
            $("#curtainOptions").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#screen2", function () {
            var tble = document.getElementById("curtainTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#screenIcons1").hide();
            $("#screenIcons2").show();
            $("#curtainIcons1").hide();
            $("#curtainIcons2").hide();
            $("#curtainIcons3").hide();
            $("#curtainIcons4").hide();
            $("#curtainIcons5").hide();
            $("#curtainIcons6").hide();
            $("#screenOptions").show();
            $("#curtainOptions").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#curtain1", function () {
            var tble = document.getElementById("curtainTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#screenIcons1").hide();
            $("#screenIcons2").hide();
            $("#curtainIcons1").show();
            $("#curtainIcons2").hide();
            $("#curtainIcons3").hide();
            $("#curtainIcons4").hide();
            $("#curtainIcons5").hide();
            $("#curtainIcons6").hide();
            $("#screenOptions").hide();
            $("#curtainOptions").show();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#curtain2", function () {
            var tble = document.getElementById("curtainTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#screenIcons1").hide();
            $("#screenIcons2").hide();
            $("#curtainIcons1").hide();
            $("#curtainIcons2").show();
            $("#curtainIcons3").hide();
            $("#curtainIcons4").hide();
            $("#curtainIcons5").hide();
            $("#curtainIcons6").hide();
            $("#screenOptions").hide();
            $("#curtainOptions").show();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#curtain3", function () {
            var tble = document.getElementById("curtainTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#screenIcons1").hide();
            $("#screenIcons2").hide();
            $("#curtainIcons1").hide();
            $("#curtainIcons2").hide();
            $("#curtainIcons3").show();
            $("#curtainIcons4").hide();
            $("#curtainIcons5").hide();
            $("#curtainIcons6").hide();
            $("#screenOptions").hide();
            $("#curtainOptions").show();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#curtain4", function () {
            var tble = document.getElementById("curtainTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#screenIcons1").hide();
            $("#screenIcons2").hide();
            $("#curtainIcons1").hide();
            $("#curtainIcons2").hide();
            $("#curtainIcons3").hide();
            $("#curtainIcons4").show();
            $("#curtainIcons5").hide();
            $("#curtainIcons6").hide();
            $("#screenOptions").hide();
            $("#curtainOptions").show();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#curtain5", function () {
            var tble = document.getElementById("curtainTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#screenIcons1").hide();
            $("#screenIcons2").hide();
            $("#curtainIcons1").hide();
            $("#curtainIcons2").hide();
            $("#curtainIcons3").hide();
            $("#curtainIcons4").hide();
            $("#curtainIcons5").show();
            $("#curtainIcons6").hide();
            $("#screenOptions").hide();
            $("#curtainOptions").show();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#curtain6", function () {
            var tble = document.getElementById("curtainTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#screenIcons1").hide();
            $("#screenIcons2").hide();
            $("#curtainIcons1").hide();
            $("#curtainIcons2").hide();
            $("#curtainIcons3").hide();
            $("#curtainIcons4").hide();
            $("#curtainIcons5").hide();
            $("#curtainIcons6").show();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#light1", function () {
            var tble = document.getElementById("myTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#lightIcons1").show();
            $("#lightIcons8").hide();
            $("#lightIcons3").hide();
            $("#lightIcons4").hide();
            $("#lightIcons5").hide();
            $("#lightIcons6").hide();
            $("#lightIcons7").hide();
            $("#lightIcons2").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
            console.log("click worked");
        });

        $(document).on("click", "#light2", function () {
            var tble = document.getElementById("myTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#lightIcons1").hide();
            $("#lightIcons8").hide();
            $("#lightIcons3").hide();
            $("#lightIcons4").hide();
            $("#lightIcons5").hide();
            $("#lightIcons6").hide();
            $("#lightIcons7").hide();
            $("#lightIcons2").show();
            $(this).closest("td").css("background-color", "#4ecdc4");
            console.log("click worked");
        });

        $(document).on("click", "#light3", function () {
            $("#lightIcons1").hide();
            $("#lightIcons8").hide();
            $("#lightIcons3").show();
            $("#lightIcons4").hide();
            $("#lightIcons5").hide();
            $("#lightIcons6").hide();
            $("#lightIcons7").hide();
            $("#lightIcons2").hide();
            var tble = document.getElementById("myTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $(this).closest("td").css("background-color", "#4ecdc4");
            console.log("click worked");
        });

        $(document).on("click", "#light4", function () {
            $("#lightIcons1").hide();
            $("#lightIcons8").hide();
            $("#lightIcons3").hide();
            $("#lightIcons4").show();
            $("#lightIcons5").hide();
            $("#lightIcons6").hide();
            $("#lightIcons7").hide();
            $("#lightIcons2").hide();
            var tble = document.getElementById("myTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $(this).closest("td").css("background-color", "#4ecdc4");
            console.log("click worked");
        });

        $(document).on("click", "#light5", function () {
            $("#lightIcons1").hide();
            $("#lightIcons8").hide();
            $("#lightIcons3").hide();
            $("#lightIcons4").hide();
            $("#lightIcons5").show();
            $("#lightIcons6").hide();
            $("#lightIcons7").hide();
            $("#lightIcons2").hide();
            var tble = document.getElementById("myTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $(this).closest("td").css("background-color", "#4ecdc4");
            console.log("click worked");
        });

        $(document).on("click", "#light6", function () {
            $("#lightIcons1").hide();
            $("#lightIcons8").hide();
            $("#lightIcons3").hide();
            $("#lightIcons4").hide();
            $("#lightIcons5").hide();
            $("#lightIcons6").show();
            $("#lightIcons7").hide();
            $("#lightIcons2").hide();
            var tble = document.getElementById("myTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $(this).closest("td").css("background-color", "#4ecdc4");
            console.log("click worked");
        });

        $(document).on("click", "#light7", function () {
            $("#lightIcons1").hide();
            $("#lightIcons8").hide();
            $("#lightIcons3").hide();
            $("#lightIcons4").hide();
            $("#lightIcons5").hide();
            $("#lightIcons6").hide();
            $("#lightIcons7").show();
            $("#lightIcons2").hide();
            var tble = document.getElementById("myTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $(this).closest("td").css("background-color", "#4ecdc4");
            
        });

        $(document).on("click", "#light8", function () {
            $("#lightIcons1").hide();
            $("#lightIcons8").show();
            $("#lightIcons3").hide();
            $("#lightIcons4").hide();
            $("#lightIcons5").hide();
            $("#lightIcons6").hide();
            $("#lightIcons7").hide();
            $("#lightIcons2").hide();
            var tble = document.getElementById("myTable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $(this).closest("td").css("background-color", "#4ecdc4");
            
        });

        $(document).on("click", "#ac1", function () {
            var tble = document.getElementById("actable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#ac1div").show();
            $("#ac2div").hide();
            $("#ac3div").hide();
            $("#ac4div").hide();
            $("#air1div").hide();
            $("#air2div").hide();
            $("#air3div").hide();
            $("#air4div").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#ac2", function () {
            var tble = document.getElementById("actable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#ac1div").hide();
            $("#ac2div").show();
            $("#ac3div").hide();
            $("#ac4div").hide();
            $("#air1div").hide();
            $("#air2div").hide();
            $("#air3div").hide();
            $("#air4div").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#ac3", function () {
            var tble = document.getElementById("actable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#ac1div").hide();
            $("#ac2div").hide();
            $("#ac3div").show();
            $("#ac4div").hide();
            $("#air1div").hide();
            $("#air2div").hide();
            $("#air3div").hide();
            $("#air4div").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#ac4", function () {
            var tble = document.getElementById("actable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#ac1div").hide();
            $("#ac2div").hide();
            $("#ac3div").hide();
            $("#ac4div").show();
            $("#air1div").hide();
            $("#air2div").hide();
            $("#air3div").hide();
            $("#air4div").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#air1", function () {
            var tble = document.getElementById("actable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#ac1div").hide();
            $("#ac2div").hide();
            $("#ac3div").hide();
            $("#ac4div").hide();
            $("#air1div").show();
            $("#air2div").hide();
            $("#air3div").hide();
            $("#air4div").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#air2", function () {
            var tble = document.getElementById("actable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#ac1div").hide();
            $("#ac2div").hide();
            $("#ac3div").hide();
            $("#ac4div").hide();
            $("#air1div").hide();
            $("#air2div").show();
            $("#air3div").hide();
            $("#air4div").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#air3", function () {
            var tble = document.getElementById("actable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#ac1div").hide();
            $("#ac2div").hide();
            $("#ac3div").hide();
            $("#ac4div").hide();
            $("#air1div").hide();
            $("#air2div").hide();
            $("#air3div").show();
            $("#air4div").hide();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#air4", function () {
            var tble = document.getElementById("actable");
            $(tble).find('td').each(function (column, td) {
                $(td).css("background-color", "transparent");
            });
            $("#ac1div").hide();
            $("#ac2div").hide();
            $("#ac3div").hide();
            $("#ac4div").hide();
            $("#air1div").hide();
            $("#air2div").hide();
            $("#air3div").hide();
            $("#air4div").show();
            $(this).closest("td").css("background-color", "#4ecdc4");
        });

        $(document).on("click", "#tvoff", function () {
            var src1 = this;
            if (this.src.indexOf("Images/AllImages/子菜单/默认状态/电视机控制/子菜单_23.png") != -1) {
                console.log("comparison ok");
                console.log(this.src);
            }
            console.log("first " + src1.src);
            console.log("second " + this.src);

        });

        

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "", function () { });

        $(document).on("click", "#sysLock", function () {
            var img = $(this).attr("src");            
            if (img == "Images/中控首页按钮/on/lock1.png")            
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
            //var img = $(this).attr("src");
            //if (img == "Images/中控首页按钮/on/lock1.png" ) {
            //    chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
            //}
            //else {              
            //    chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
            //}
        });
        $(document).on("click", "#podiumLock", function () {
            var img = $(this).attr("src");
            if (img == "Images/中控首页按钮/on/lock2.png")
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2f 39");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2e 38");
        });
        $(document).on("click", "#classLock", function () {
            var img = $(this).attr("src");
            if (img== "Images/中控首页按钮/on/lock3.png")
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 60 6A" );
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5f 69");
        });
        $(document).on("click", "#screenup1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 76 80");
        });
        $(document).on("click", "#dcopen", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 77 81");
        });
        $(document).on("click", "#screenstop1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 66 70");
        });
        $(document).on("click", "#dcstop", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 67 71");
        });
        $(document).on("click", "#screendown1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 56 60");
        });
        $(document).on("click", "#dcclose", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 57 61");
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
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 33 3D");
        });
        $(document).on("click", "#projectorOff", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 43 4D");
        });

        $(document).on("click", "#projSleep", function () {            
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 45 4F");           
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

        $(document).on("click", "#systempower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 18 22");
        });
        $(document).on("click", "#pcpower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 17 21");
        });
        $(document).on("change", "*[name ='test']", function () {
        });
        RemoteVol = function (val) {
            var lastVal = this.document.getElementById("volValue").innerText;
            if (lastVal > val && val > 0) {
                var img = document.getElementById("volicons");
                //if (val > 50) {
                //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                //}
                //else {
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                //}
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 21 2B");
            }
            else if (val == 0) {
                
                var img = document.getElementById("volicons");
                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量静音.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 22 2C");
            }
            else if (lastVal < val) {
                var img = document.getElementById("volicons");
                //if (val > 50) {
                //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
                //}
                //else {
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png";
               // }
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 2A");
            }
            this.document.getElementById("volValue").innerText = val;
            
            console.log('After: ' + val);
        };
        WirelessRemoteMic = function (val) {
            var lastVal = this.document.getElementById("wirelessValue").innerText;
            if (lastVal > val && val > 0) {
                var img = document.getElementById("wirelessicons");
                //if (val < 50) {
                //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                //}
                //else {
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                //}
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 74 7e");
            }
            else if (val == 0) {
                
                var img = document.getElementById("wirelessicons");
                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦静音.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 75 7f");
            }
            else if (lastVal < val) {
                var img = document.getElementById("wirelessicons");
                //if (val < 50) {
                //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                //}
                //else {
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png";
                //}
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 73 7d");
            }
            this.document.getElementById("wirelessValue").innerText = val;
            console.log('After: ' + val);
        };
        WiredRemoteMic = function (val) {
            var lastVal = this.document.getElementById("wiredValue").innerText;
            if (lastVal > val && val > 0) {
                var img = document.getElementById("wiredicons");
                //if (val > 50) {
                //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                //}
                //else {
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                //}
                
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 24 2e");
            }
            else if (val == 0) {
                var img = document.getElementById("wiredicons");
                img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/有线麦静音.png";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 25 2f");
            }
            else if (lastVal < val) {

                var img = document.getElementById("wiredicons");
                //if (val > 50) {
                //    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                //}
                //else {
                    img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png";
                //}
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 23 2d");
            }
            this.document.getElementById("wiredValue").innerText = val;
            console.log('After: ' + val);
        };
    });

});
function NoNotification(arraydata) {
    var imgpc = document.getElementById("pcpower");
    imgpc.src = "Images/AllImages/images/图标_212.png";
    if (arraydata[12] == 'Locked') {
        var src = document.getElementById('sysLock');
        src.src = "Images/AllImages/images/图标_262.png";
    } 
    else {
        var src = document.getElementById('sysLock');
        src.src = "Images/AllImages/images/图标_264.png";
    }
    if (arraydata[13] == 'Locked') {
        var src = document.getElementById('podiumLock');
        src.src = "Images/AllImages/images/PodiumLock.png";
    }
    else {
        var src = document.getElementById('podiumLock');
        src.src = "Images/AllImages/images/图标_216.png";
    }
    if (arraydata[14] == 'Locked') {
        var src = document.getElementById('classLock');
        src.src = "Images/AllImages/images/图标_236.png";
    }
    else {
        var src = document.getElementById('classLock');
        src.src = "Images/AllImages/images/图标_238.png";
    }
    uncheck();
    

    if (arraydata[6] == 'Closed') {

        var src = document.getElementById("projectorOff");
        src.src = "Images/AllImages/images/图标_186.png";
        //document.getElementById("projectorOn").src = "Images/AllImages/images/图标_184.png";
    } else {
        //document.getElementById("projectorOff").src = "Images/AllImages/images/图标_186.png";
        var src = document.getElementById("projectorOn");
        src.src = "Images/AllImages/images/图标_184.png";
    }
}
window.SetVolume = function (val) {
    console.log('After: ' + val / 100);
}
function openCity(evt, cityName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}



