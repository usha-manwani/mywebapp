﻿$(function () {
    // Declare a proxy to reference the hub.
   
    var chat = $.connection.myHub;

    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message. 
        var tab = document.getElementById("MainContent_masterchildBody_GridView1");
        for (i = 0; i < tab.rows.length; i++) {
            var cellIp = tab.rows[i].cells[1];
            var arraydata = message.split(',');
            if (cellIp.innerHTML == name)
            {
                
                if (arraydata[1] == "Heartbeat") {
                    if (arraydata.length > 18) {
                        for (j = 2; j < 15; j++) {
                            tab.rows[i].cells[j].innerHTML = arraydata[j];
                        }
                    }
                    else {
                        for (j = 2; j < arraydata.length - 1; j++) {
                            tab.rows[i].cells[j].innerHTML = arraydata[j];
                        }
                    }
                }
                else if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            tab.rows[i].cells[3].innerHTML = 'OPEN';
                            break;
                        case 'SystemOff':
                            tab.rows[i].cells[3].innerHTML = 'CLOSED';
                            break;
                        case 'DSDown':
                            tab.rows[i].cells[9].innerHTML = 'Down';
                            break;
                        case 'DSStop':
                            tab.rows[i].cells[9].innerHTML = 'Stop';
                            break;
                        case 'DSUp':
                            tab.rows[i].cells[9].innerHTML = 'Up';
                            break;
                        default:
                            break;
                    }
                }
                else if (arraydata[1] == "LEDIndicator") {
                    if (arraydata[2] == "SystemSwitchOn") {
                        if (arraydata.length > 4) {
                            switch (arraydata[4]) {
                                case 'ComputerOff':
                                    tab.rows[i].cells[5].innerHTML = 'Off';
                                    break;
                                case 'ComputerOn':
                                    tab.rows[i].cells[5].innerHTML = 'On';
                                    break;
                            }

                        }
                        tab.rows[i].cells[3].innerHTML = "OPEN";
                        switch (arraydata[3]) {
                            case 'Desktop':
                                tab.rows[i].cells[11].innerHTML = 'Desktop';
                                break;
                            case 'Laptop':
                                tab.rows[i].cells[11].innerHTML = 'Laptop';
                                break;
                            case 'DigitalCurtain':
                                tab.rows[i].cells[11].innerHTML = 'Digital Curtain';
                                break;
                            case 'DigitalScreen':
                                tab.rows[i].cells[11].innerHTML = 'Digital Screen';
                                break;
                            case 'DVD':
                                tab.rows[i].cells[11].innerHTML = 'DVD';
                                break;
                            case 'TV':
                                tab.rows[i].cells[11].innerHTML = 'TV';
                                break;
                            case 'VideoCamera':
                                tab.rows[i].cells[11].innerHTML = 'Video Camera';
                                break;
                            case 'Blu-RayDVD':
                                tab.rows[i].cells[11].innerHTML = 'Blu-Ray DVD';
                                break;
                            case 'RecordingSystem':
                                tab.rows[i].cells[11].innerHTML = 'Recording System';
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
                        tab.rows[i].cells[3].innerHTML = "CLOSED";
                    }
                }
                else if (arraydata[0] == "Temp") {
                    tab.rows[i].cells[15].innerHTML = arraydata[1];
                    tab.rows[i].cells[16].innerHTML = arraydata[2];
                    tab.rows[i].cells[17].innerHTML = arraydata[3];
                    tab.rows[i].cells[18].innerHTML = arraydata[4];
                }

                else if (arraydata[2] == 'Offline') {
                    for (j = 2; j < arraydata.length - 1; j++) {
                        tab.rows[i].cells[j].innerHTML = arraydata[j];
                    }
                }
                break;
                //else if (arraydata[1] == "PanelKey") {
                //    switch (arraydata[2]) {
                //        case 'ComputerSystemON':
                //            tab.rows[i].cells[5].innerHTML = 'On';
                //            break;  
                //        case 'ComputerSystemOFF':
                //                tab.rows[i].cells[5].innerHTML = 'Off';
                //            break;
                //        default:
                //            break;
                //    }
                //}
            }
        }
    };
    chat.client.updatelog = function () {
        alert("inside grid");
        _doPostBack("<%=up1.UniqueID %>", "");

    };
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        alert('connected');
        chat.server.sendData();
        $(document).on("click", "#refresh", function () {
           
            //Call the Send method on the hub.
            chat.server.sendData();            
        });
    });
});