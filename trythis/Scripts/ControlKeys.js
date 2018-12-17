﻿$(function () {
     //window.addEventListener('resize', () => {
     //    var size = $(window).width();
     //    if (size <= 768) {

     //    }

     //});
    var ipAddress;
    var chat = $.connection.myHub;
     chat.client.broadcastMessage = function (name, message) {
         tbleupdate(name, message);
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
        alert("connection done");
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
                $(this).removeClass("fa-volume-mute");
                $(this).addClass("fa-volume-up");
                $(this).removeClass("red");
                $(this).addClass("iconColor");
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 2a");
            }            
        });
        $(document).on('click', "*[name='lockIcon']", function () {          
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
        $(document).on('click', '.aclass', function () {
            alert(this.innerHTML);             
            ipAddress = $(this).closest('tr').find('input').val();         
            openRemote(ipAddress);
        });
        $(document).on('click', '.trying', function () {
            if ($(this).hasClass("fa-angle-double-up")) {
                $(this).removeClass("fa-angle-double-up").addClass("fa-angle-double-down")
                $(this).parent('header').addClass("header1");
            } else {
                $(this).removeClass("fa-angle-double-down").addClass("fa-angle-double-up");
                $(this).parent('header').removeClass("header1");
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
        $(document).on("click", "#systempower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 18 22");
        });
        $(document).on("click", "#pcpower", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 17 21");
        });
    });
});
function createDivs() {
    var chkds = $("input[name='toggle']:checkbox");
    chkds.checked = true;
   
    var deviceidsloc = $('#dev').val();
    if (deviceidsloc != "" && deviceidsloc != undefined) {
        var dev = deviceidsloc.split(",");
        var counter = 0;
        for (i = 0; i < dev.length; i++) {            
            
            var ip = dev[i].split(":");
            var rows = document.getElementById("smallcontrol");
            var DIV = document.createElement("div");
            DIV.className = "col-xs-12 col-md-4 ";
            rows.appendChild(DIV);
            var table = document.createElement("table");
            table.className = "table1234";
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
          //  cell22.setAttribute("colspan", "2");
            //ss
            var cell23 = row2.insertCell(2);
           // cell23.setAttribute("colspan", "2");
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
            cell33.title = "PC";
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
    if (chknot ) {
        alert(ipofdevice + "  " + chknot);
    }
    else {
        alert("you are wrong");
    }
}

function openRemote(ipofremote) {
    var iplabel = document.getElementById("MainContent_masterBody_deviceips");
    iplabel.innerText = ipofremote;
    document.getElementById("control").style.display = "block";
    document.getElementById("smallcontrol").style.display = "none";
    
}
window.onclick = function (event) {
    if (event.target == modal) {
        document.getElementById("control").style.display = "none";
    }
}

 function closexx () {
     document.getElementById("control").style.display = "none";
     document.getElementById("smallcontrol").style.display = "block";
     //document.getElementById("smallcontrol").addClass = "newspaper";
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




