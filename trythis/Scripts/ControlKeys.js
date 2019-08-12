﻿$(function () {
    var ipAddress = "";
    var chat = $.connection.myHub;
    chat.client.broadcastMessage = function (name, message) {
         
         tbleupdate(name, message);
        if (name == ipAddress) {
            var arraydata = message.split(',');
            if (arraydata[1] == "Heartbeat") {
                if (arraydata[3] == 'OPEN') {
                    var img = document.getElementById("systempower");
                    img.src = "Images/onimages/syspoweron.png";
                }
                else {
                    var img = document.getElementById("systempower");
                    img.src = "Images/offimages/sysof.png";
                }
                if (arraydata[5] == 'On') {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/onimages/pcpoweron.png";
                }
                else {
                    var imgpc = document.getElementById("pcpower");
                    imgpc.src = "Images/offimages/pcof.png";
                }
                if (arraydata[12] == 'Locked') {
                    var src = document.getElementById('syslock');
                    src.src = "Images/onimages/syslock.png";
                }
                else {
                    var src = document.getElementById('syslock');
                    src.src = "Images/onimages/sysunlock.png";
                }
                if (arraydata[13] == 'Locked') {
                    var src = document.getElementById('podiumlock');
                    src.src = "Images/onimages/podiumlock.png";
                }
                else {
                    var src = document.getElementById('podiumlock');
                    src.src = "Images/onimages/podiumunlock.png";
                }
                if (arraydata[14] == 'Locked') {
                    var src = document.getElementById('classlock');
                    src.src = "Images/onimages/classlock.png";
                }
                else {
                    var src = document.getElementById('classlock');
                    src.src = "Images/onimages/classunlock.png";
                }
                uncheck();
                switch (arraydata[11]) {
                    case 'Desktop':
                        var desk = document.getElementById('desktop');
                        document.getElementById('desktop').checked = true;
                        $(desk).closest("td").find("img").attr('src', "Images/onimages/desktop.png");                        
                        
                        break;
                    case 'Laptop':
                        document.getElementById('laptop').checked = true;
                        var laptop = document.getElementById('laptop');
                        $(laptop).closest("td").find("img").attr('src',"Images/onimages/laptopon.png");
                       
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
                }
                else {
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
                            if (arraydata.length > 4)
                            {
                                var imgpc = document.getElementById("pcpower");
                                switch (arraydata[4])
                                {
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

    $.connection.hub.start({ waitForPageLoad: false }).done(function () {        
        createDivs();
        var chkbox = document.getElementsByName("toggle");        
        for (k = 0; k < chkbox.length; k++) {            
            chat.server.sendControlKeys(chkbox[k].value, "8B B9 00 03 05 01 09");
        }
        chat.server.sendData();
        $(document).on('change', "input[name='toggle']:checkbox", function () {
                ipAddress = this.value;
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 18 22");
        });
        $(document).on('click', "*[name='volIcon']", function () {           
            var vol = $(this).closest('table').find('input').val();
            if ($(this).hasClass("fa-volume-up")) {
                $(this).removeClass("fa-volume-up");
                $(this).addClass("fa-volume-mute");
                $(this).addClass("red");
                chat.server.sendControlKeys(vol, "8B B9 00 04 02 04 22 2c");
            }                
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 2a");
                $(this).removeClass("fa-volume-mute");
                $(this).addClass("fa-volume-up");
                $(this).removeClass("red");
                $(this).addClass("iconColor");
                
            }            
        });
        $(document).on('click', "*[name='lockIcon']",function () {          
            var lock = $(this).closest('table').find('input').val();
            chat.server.sendControlKeys(lock, "8B B9 00 04 02 04 2d 37");           
        });
        $(document).on('click', "*[name='desktopIcon']", function () {           
            var desktop = $(this).closest('table').find('input').val();
            chat.server.sendControlKeys(desktop, "8B B9 00 04 02 04 17 21");           
        });
        $(document).on('click', "*[name='projIcon']", function () {            
            var rgb = this.style.color;
            var colCode= '#' + rgb.substr(4, rgb.indexOf(')') - 4).split(',').map((color) => parseInt(color).toString(16)).join('');
            var proj = $(this).closest('table').find('input').val();
            if (colCode == "#67ec3a") {
                this.style.color = "white";
                chat.server.sendControlKeys(proj, "8B B9 00 04 02 04 43 4d");    
            }                
            else {
                this.style.color = "#67ec3a";
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 33 3d");               
            }
            alert(proj);
        });
        //$(document).on('click', '.aclass', function () {
                      
        //    ipAddress = $(this).closest('tr').find('input').val();
        //    sessionStorage.setItem('ipofremote', ipAddress);
        //    console.log(ipAddress);
        //    openRemote(ipAddress);
        //    chat.server.sendData(); 
        //});        
        $(document).on('click', '.trying', function () {
            
            if ($(this).hasClass("fa-angle-up")) {                
                $(this).removeClass("fa-angle-up").addClass("fa-angle-down");                
                 
            } else {                
                $(this).removeClass("fa-angle-down").addClass("fa-angle-up");
                          
            }
        });
        $(document).on("click", "#syslock", function () {
            var src = document.getElementById('syslock');
            if (src.src.indexOf("Images/unlock.png") != -1)
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
        });
        $(document).on("click", "#podiumlock", function () {
            var src = document.getElementById('podiumlock');
            if (src.src.indexOf("Images/unlock.png") != -1)
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2e 38");
            else
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2f 39");
        });
        $(document).on("click", "#classlock", function () {
            var src = document.getElementById('classlock');
            if (src.src.indexOf("Images/unlock.png") != -1)
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
        $(document).on("change", "*[name ='classnames']", function () {
            console.log("clicked Class Name");
            var val = $(this).closest('.tdcenter').find('input:checkbox').attr('value');
            console.log(val);
        });
        $(document).on("click", "#btnOff", function () {
            var checkedids = document.getElementsByName('selectclass');
            for (i = 0; i < checkedids.length; i++) {
                if (checkedids[i].checked) {
                    var ipadd = checkedids[i].value;
                    chat.server.sendControlKeys(ipadd, "8B B9 00 04 02 04 C1 CB");
                }
            }
        });
        $(document).on("click", "#btnOn", function () {
            var checkedids = document.getElementsByName('selectclass');
            for (i = 0; i < checkedids.length; i++) {
                if (checkedids[i].checked) {
                    var ipadd = checkedids[i].value;
                    chat.server.sendControlKeys(ipadd, "8B B9 00 04 02 04 C0 CA");
                }
            }
        });
        $(document).on("click", "#SelectAll", function () {
            var checkedids = document.getElementsByName('selectclass');
            for (i = 0; i < checkedids.length; i++) {
                checkedids[i].checked = true;
            }
        });
        $(document).on("click", "#UnselectAll", function () {
            var checkedids = document.getElementsByName('selectclass');
            for (i = 0; i < checkedids.length; i++) {
                checkedids[i].checked = false;
            }
        });
    });
});
function createDivs() {
    var chkds = $("input[name='toggle']:checkbox");
    chkds.checked = true;    
    var deviceidsloc = $('#dev1').val();
    console.log(deviceidsloc);
    if (deviceidsloc != "" && deviceidsloc != undefined) {
        var dev = deviceidsloc.split(",");
        var counter = 0;
        for (i = 0; i < dev.length; i++) {           
            var ip = dev[i].split(":");
            var rows = document.getElementById("smallcontrol");
            var DIV = document.createElement("div");
            DIV.name = "controldivs";
            DIV.className = "col-xl-3 col-md-6 col-lg-4 col-sm-6 fixwidth";
            rows.appendChild(DIV);
            var checkselect = document.createElement("input");
            checkselect.type = "checkbox";
            checkselect.name = "selectclass";
            checkselect.value = ip[0];
            checkselect.className = "chk";
            DIV.appendChild(checkselect);
            var table = document.createElement("table");
            table.className = "table1234 shadows";
            //row1
            var row1 = table.insertRow(0);
            row1.style.textAlign = "center";
            //classname
            var cell1 = row1.insertCell(0);
            var a1 = document.createElement("a");           
            a1.name = "classnames";            
            a1.innerHTML = ip[1];
            cell1.appendChild(a1);
            a1.className = "aclass";
            a1.style.color = "white";        
            cell1.className = 'tdcenter';
            cell1.title = "click to open Remote Control";
           //on/off
            var cell12 = row1.insertCell(1);
           // cell12.setAttribute("colspan", "3");
            var div1 = document.createElement("div");
            div1.className = "switch";
            var chk = document.createElement("input");
            chk.type = "checkbox";
            chk.name = "toggle";
            chk.className = "tdcenter";
            chk.value = ip[0];
            
           // chk.onchange = function () { isRemote(this.value, this.checked) };
            div1.appendChild(chk);
            var label1 = document.createElement("label");
            label1.htmlFor = "toggle";
            var i1 = document.createElement("i");
            label1.appendChild(i1);
            var span1 = document.createElement("span");
            div1.appendChild(label1);
            div1.appendChild(span1);           
            cell12.appendChild(div1);
            cell12.title = "System On/Off";
            //row 2
            var row2 = table.insertRow(1);
            row2.className = "trstyle";
            //proj
            var cell21 = row2.insertCell(0);
           // cell21.setAttribute("colspan", "2");
            cell21.className = "tdcenter";
            cell21.title = "Projector";
            cell21.style.color = "white";
            cell21.innerHTML = '<i style="font-size:1.5em" class="fa fa-hdd" aria-hidden=true name="projIcon"></i>';
            //ss
            var cell22 = row2.insertCell(1);
            cell22.className = "tdcenter";
            cell22.title = "Curtain/Screen Status";
            cell22.style.color = "white";
            cell22.innerHTML = '<img src= "Images/imgs/curtain32.png" height="32" width="32" id="curtainMain" />';
          
            //ss
            var cell23 = row2.insertCell(2);
            cell23.title = "Media Signal";
            cell23.className = "tdcenter";
            cell23.style.color = "white";
            cell23.innerHTML = '<i style="font-size:1.5em" class="fa fa-window-restore"  aria-hidden=true name="mediaIcon"></i>';
           
            //row3
            var row3 = table.insertRow(2);
            row3.className = "trstyle";
            //vol
            var cell31 = row3.insertCell(0);
          //  cell31.setAttribute("colspan", "2");
            cell31.className = 'tdcenter ';           
            cell31.innerHTML = '<i style="font-size:1.5em" class="fa fa-volume-up" aria-hidden=true name="volIcon"></i>';
            cell31.title = "volume";
            cell31.style.color = "white";
            //lock
            var cell32 = row3.insertCell(1);
          //  cell32.setAttribute("colspan", "2");
            cell32.className = 'tdcenter ';
            cell32.innerHTML = '<i style="font-size:1.5em" class="fa fa-lock " aria-hidden=true name="lockIcon"> </i > ';
            cell32.title = "system lock";
            cell32.style.color = "white";
            //desktop
            var cell33 = row3.insertCell(2);
           // cell33.setAttribute("colspan", "2");
            cell33.className = 'tdlast';
            cell33.title = "PC On/Off";
            cell33.style.color = "white";
            cell33.innerHTML = '<i style="font-size:1.5em" class="fa fa-desktop " aria-hidden=true name="desktopIcon"></i>';
            DIV.appendChild(table);
        }
    }
    else
    {
        var rows = document.getElementById("smallcontrol");
        var DIV = document.createElement("div");
        DIV.className = "col-md-3";
        rows.appendChild(DIV);
        DIV.innerHTML='<h3 style="color: Black;">No Devices to show!!</h3>'
    }
}

function volume(texter) {
    var tt = texter.innerHTML;
    tt.setAttribute("color", "green");
}
function changeColor() {
    var rr = document.getElementsByClassName("table1234");
    for (i = 0; i < rr.length; i++) {

    }
}

function isRemote(ipofdevice, chknot) {
    if (chknot) {
        console.log(ipofdevice + "  " + chknot);
    }
    else {
        console.log("you are wrong");
    }
}

function openRemote(ipofremote) {
    uncheck();
    offdevices();
    var iplabel = document.getElementById("MainContent_masterchildBody_masterBody_deviceips");
    iplabel.innerText = ipofremote;
    
   
   document.getElementById("control").style.display = "block";
   document.getElementById("smallcontrol").style.display = "none";    
}
//window.onclick = function (event) {
//    if (event.target == modal) {
        
//       document.getElementById("control").style.display = "none";
       
//    }
//}

function closexx() {
    
    document.getElementById("control").style.display = "none";
     document.getElementById("smallcontrol").style.display ="flex";
    document.getElementById("smallcontrol").addClass = "clearfix";
    
}

function tbleupdate(name, message) {
    var chkbox = document.getElementsByName("toggle");
    var arraydata = message.split(',');
    for (k = 0; k < chkbox.length; k++) {
        if (chkbox[k].value == name) {
            
            if (arraydata[1] == "Heartbeat") {
                if (arraydata[3] == 'OPEN') {
                    chkbox[k].checked = true;
                }
                else {
                    chkbox[k].checked = false;
                }

                if (arraydata[5] == 'On') {
                    var desktop = $(chkbox[k]).closest('table').find("*[name='desktopIcon']");
                    desktop.addClass("iconColor");
                    desktop.removeClass("red");
                   
                }
                else {
                    var desktop = $(chkbox[k]).closest('table').find("*[name='desktopIcon']");
                    desktop.removeClass("iconColor");
                    desktop.addClass("red");
                }
                if (arraydata[12] == 'Locked') {
                    var syslocked = $(chkbox[k]).closest('table').find("*[name='lockIcon']");                    
                    syslocked.addClass("fa-lock");                   
                    syslocked.removeClass("fa-unlock");
                    syslocked.removeClass("iconColor");
                    syslocked.addClass("red");
                }
                else {
                    var syslocked = $(chkbox[k]).closest('table').find("*[name='lockIcon']");                    
                    syslocked.addClass("fa-unlock");
                    syslocked.addClass("iconColor");
                    syslocked.removeClass("fa-lock");
                    syslocked.removeClass("red");
                }
                if (arraydata[6] == 'Closed') {
                    var proj = $(chkbox[k]).closest('table').find("*[name='projIcon']");
                    proj.addClass("red");
                    proj.removeClass("iconColor");
                }
                else {
                    var proj = $(chkbox[k]).closest('table').find("*[name='projIcon']");
                    proj.addClass("iconColor");
                    proj.removeClass("red");
                }
               
                switch (arraydata[11]) {
                    case "Desktop":
                        var media = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                        media.removeClass("^='fa-'");
                        media.title = "desktop";
                        media.addClass("fa-desktop");
                        media.addClass("iconColor");
                        break;
                    case "Laptop":
                        var laptop = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");                                                
                        laptop.removeClass("^='fa-'");                       
                        laptop.addClass("iconColor");
                        laptop.addClass("fa-laptop");                        
                        break;
                    case "Digital Curtain":
                        var curtain = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                        curtain.removeClass("^='fa-'");
                        curtain.addClass("fa-window-maximize");
                        curtain.addClass("iconColor");  
                        var cur = $(chkbox[k]).closest('table').find("#curtainMain");
                        if (arraydata[8] == 'Stop') {

                            $(cur).attr('src', 'Images/imgs/curtainclose32.png');
                        }
                        else {
                            if (arraydata[8] == 'close') {

                                cur.src = 'Images/imgs/curtain32.png';
                            }
                            else {
                                cur.src = 'Images/imgs/curtainopen32.png';
                            }
                        }
                        break;
                    case "Video Camera":
                        var camera = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                        camera.removeClass("^='fa-'");
                        camera.addClass("fa-camera");
                        camera.addClass("iconColor");
                        
                        break;
                    case "Digital Screen":
                        var sc = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                        sc.removeClass("^='fa-'");
                        sc.addClass("iconColor");
                        sc.addClass("fa-mobile");
                       
                        break;
                    case "TV":
                        var tv = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                        tv.removeClass("^='fa-'");
                        tv.addClass("iconColor");
                        tv.addClass("fa-tv");
                        break;
                    case "Blu-Ray DVD":
                        var blu = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                        blu.removeClass("^='fa-'");
                        blu.addClass("iconColor");
                        blu.addClass("fa-compact-disc");
                        break;
                    case "DVD":
                        var dvd = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                        dvd.removeClass("^='fa-'");
                        dvd.addClass("iconColor");
                        dvd.addClass("fa-compact-disc");
                        break;
                    case 'Recording System':
                        var rec = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                        rec.removeClass("^='fa-'");
                        rec.addClass("iconColor");
                        rec.addClass("fa-camera");
                        break;
                        
                }
            }
            else if (arraydata[1] == "LEDIndicator") {
                if (arraydata[2] == "SystemSwitchOn") {
                    chkbox[k].checked = true;
                    switch (arraydata[4]) {
                        case "ComputerOff":
                            var desktop = $(chkbox[k]).closest('table').find("*[name='desktopIcon']");
                            desktop.removeClass("iconColor");
                            desktop.addClass("red");
                            break;
                        case "ComputerOn":
                            var desktop = $(chkbox[k]).closest('table').find("*[name='desktopIcon']");
                            desktop.addClass("iconColor");
                            desktop.removeClass("red");
                            break;
                    }
                    switch (arraydata[3]) {
                        case 'Desktop':
                            var media = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            media.removeClass("^='fa-'");
                            media.title = "desktop";
                            media.addClass("fa-desktop");
                            media.addClass("iconColor");
                            break;
                        case 'Laptop':
                            var laptop = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            laptop.removeClass("^='fa-'");
                            laptop.addClass("iconColor");
                            laptop.addClass("fa-laptop"); 
                            break;
                        case 'DigitalCurtain':
                            var curtain = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            curtain.removeClass("^='fa-'");
                            curtain.addClass("fa-window-maximize");
                            curtain.addClass("iconColor"); 
                            var cur = $(chkbox[k]).closest('table').find("#curtainMain");
                            if (arraydata[8] == 'Stop') {
                                $(cur).attr('src', 'Images/imgs/curtainclose32.png');
                            }
                            else if (arraydata[8] == 'close') {
                                ur.src = 'Images/imgs/curtain32.png';
                            }
                            else {
                                cur.src = 'Images/imgs/curtainopen32.png';
                            }
                            break;
                        case 'DigitalScreen':
                            var sc = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            sc.removeClass("^='fa-'");
                            sc.addClass("iconColor");
                            sc.addClass("fa-mobile");
                            break;
                        case 'DVD':
                            var dvd = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            dvd.removeClass("^='fa-'");
                            dvd.addClass("iconColor");
                            dvd.addClass("fa-compact-disc");
                            break;
                        case 'VideoCamera':
                            var camera = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            camera.removeClass("^='fa-'");
                            camera.addClass("fa-camera");
                            camera.addClass("iconColor");
                            break;
                        case 'TV':
                            var tv = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            tv.removeClass("^='fa-'");
                            tv.addClass("iconColor");
                            tv.addClass("fa-tv");
                            break;
                        case 'Blu-RayDVD':
                            var blu = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            blu.removeClass("^='fa-'");
                            blu.addClass("iconColor");
                            blu.addClass("fa-compact-disc");
                            break;
                            break;
                        case 'RecordingSystem':
                            var rec = $(chkbox[k]).closest('table').find("*[name='mediaIcon']");
                            rec.removeClass("^='fa-'");
                            rec.addClass("iconColor");
                            rec.addClass("fa-camera");
                            break;
                    }                   
                }
                else {
                    chkbox[k].checked = false;
                    var desktop = $(chkbox[k]).closest('table').find("*[name='desktopIcon']");
                    desktop.removeClass("iconColor");
                    desktop.addClass("red");
                }            
            }
            else if (arraydata[1] == "KeyValue") {
                if (arraydata[2] == 'SystemON') {
                    chkbox[k].checked = true;
                }
                else {
                    chkbox[k].checked = false;
                }
            }           
        }
    }
}

function uncheck() {
    $('#desktop').closest("td").find("img").attr('src', "Images/offimages/desktop.png");

    $('#laptop').closest("td").find("img").attr('src', "Images/offimages/laptop.png");

    $('#platform').closest("td").find("img").attr('src', "Images/offimages/screen.png");

    $('#digitalEquipment').closest("td").find("img").attr('src', "Images/offimages/screen.png");

    $('#dvd').closest("td").find("img").attr('src', "Images/offimages/dvd.png");

    $('#bluray').closest("td").find("img").attr('src', "Images/offimages/bluraydvd.png");

    $('#tv').closest("td").find("img").attr('src', "Images/offimages/tv.png");

    $('#camera').closest("td").find("img").attr('src', "Images/offimages/camera.png");
    $('#recorder').closest("td").find("img").attr('src', "Images/offimages/recorder.png");
}

function offdevices() {
    
    $('#systempower').closest("td").find("img").attr('src', "Images/offimages/sysof.png");
    $('#pcpower').closest("td").find("img").attr('src', "Images/offimages/pcof.png");
    $('#syslock').closest("td").find("img").attr('src', "Images/offimages/sysunlock.png");
    $('#podiumlock').closest("td").find("img").attr('src', "Images/offimages/podiumunlock.png");
    $('#classlock').closest("td").find("img").attr('src', "Images/offimages/classunlock.png");
}
$(window).on('load', setWidth);
$(window).on('resize', setWidth);
function setWidth() {
    var width = $(window).width();

    if (width < 1401 && width > 1199) {
        var div = document.getElementsByClassName('fixwidth');
        if (div.length > 0) {
            for (i = 0; i < div.length; i++) {
                div[i].className = "col-xl-2 col-lg-6 fixwidth";
            }
        }
    }
    else {
        var div = document.getElementsByName('controldivs');
        if (div.length > 0) {
            for (i = 0; i < div.length; i++) {
                div[i].className = "col-xl-3 col-md-6 col-lg-4 col-sm-12 fixwidth";
            }
        }
    }
}



