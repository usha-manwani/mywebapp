$(function () {
    // Declare a proxy to reference the hub.
   
    var chat = $.connection.myHub;

    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message. 
        var tab = document.getElementById("MainContent_masterchildBody_GridView1");
        for (i = 0; i < tab.rows.length; i++) {
            var cellIp = tab.rows[i].cells[2];
            var arraydata = message.split(',');
            if (cellIp.innerHTML == name)
            {
                
                if (arraydata[1] == "Heartbeat") {
                    if (arraydata.length > 18) {
                        for (j = 3; j < 16; j++) {
                            tab.rows[i].cells[j].innerHTML = arraydata[j-1];
                        }
                    }
                    else {
                        for (j = 3; j < arraydata.length - 1; j++) {
                            tab.rows[i].cells[j].innerHTML = arraydata[j-1];
                        }
                    }
                }
                else if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            tab.rows[i].cells[4].innerHTML = 'OPEN';
                            break;
                        case 'SystemOff':
                            tab.rows[i].cells[4].innerHTML = 'CLOSED';
                            break;
                        case 'DSDown':
                            tab.rows[i].cells[10].innerHTML = 'Down';
                            break;
                        case 'DSStop':
                            tab.rows[i].cells[10].innerHTML = 'Stop';
                            break;
                        case 'DSUp':
                            tab.rows[i].cells[10].innerHTML = 'Up';
                            break;
                        default:
                            break;
                    }
                }
                else if (arraydata[1] == "LEDIndicator") {
                    if (arraydata[2] == "SystemSwitchOn") {
                        tab.rows[i].cells[4].innerHTML = "OPEN";
                            if (arraydata[4] == "Computer") {
                                if (tab.rows[i].cells[6].innerHTML == 'On') {
                                    tab.rows[i].cells[6].innerHTML = 'Off';
                                }                                    
                                   else
                                    tab.rows[i].cells[6].innerHTML = 'On';                                   
                            }
                       
                        switch (arraydata[3]) {
                            case 'Desktop':
                                tab.rows[i].cells[12].innerHTML = 'Desktop';
                                break;
                            case 'Laptop':
                                tab.rows[i].cells[12].innerHTML = 'Laptop';
                                break;
                            case 'DigitalCurtain':
                                tab.rows[i].cells[12].innerHTML = 'Digital Curtain';
                                break;
                            case 'DigitalScreen':
                                tab.rows[i].cells[12].innerHTML = 'Digital Screen';
                                break;
                            case 'DVD':
                                tab.rows[i].cells[12].innerHTML = 'DVD';
                                break;
                            case 'TV':
                                tab.rows[i].cells[12].innerHTML = 'TV';
                                break;
                            case 'VideoCamera':
                                tab.rows[i].cells[12].innerHTML = 'Video Camera';
                                break;
                            case 'Blu-RayDVD':
                                tab.rows[i].cells[12].innerHTML = 'Blu-Ray DVD';
                                break;
                            case 'RecordingSystem':
                                tab.rows[i].cells[12].innerHTML = 'Recording System';
                                break;
                            case 'TurnOffLights':
                                tab.rows[i].cells[11].innerHTML = 'Off';
                                break;
                            case 'CentralLocking':
                                tab.rows[i].cells[13].innerHTML = 'Locked';
                                break;
                            case 'PodiumLock':
                                tab.rows[i].cells[14].innerHTML = 'Locked';
                                break;
                            case 'ClassLock':
                                tab.rows[i].cells[15].innerHTML = 'Locked';
                                break;

                        }
                        if (arraydata[5] == "CentralLock") {
                            if (tab.rows[i].cells[13].innerHTML == 'Locked')
                                tab.rows[i].cells[13].innerHTML = 'Unlocked'; 
                            else{
                                tab.rows[i].cells[13].innerHTML = 'Locked'
                            }
                        }
                        if (arraydata[5] == "PodiumLock") {
                            if (tab.rows[i].cells[14].innerHTML == 'Locked')
                                tab.rows[i].cells[14].innerHTML = 'Unlocked';
                            else{
                                tab.rows[i].cells[14].innerHTML = 'Locked'
                            }
                        }
                        if (arraydata[5] == "ClassLock") {
                            if (tab.rows[i].cells[15].innerHTML == 'Locked')
                                tab.rows[i].cells[15].innerHTML = 'Unlocked';
                            else{
                                tab.rows[i].cells[15].innerHTML = 'Locked'
                            }
                        }
                    }
                    else if (arraydata[2] == "SystemSwitchOff") {
                        tab.rows[i].cells[4].innerHTML = "CLOSED";
                    }
                }
                else if (arraydata[0] == "Temp") {
                    tab.rows[i].cells[16].innerHTML = arraydata[1];
                    tab.rows[i].cells[17].innerHTML = arraydata[2];
                    tab.rows[i].cells[18].innerHTML = arraydata[3];
                    tab.rows[i].cells[19].innerHTML = arraydata[4];
                }

                else if (arraydata[2] == 'Offline') {
                    tab.rows[i].cells[3].innerHTML = 'Offline';
                    for (j = 4; j < arraydata.length - 1; j++) {
                        tab.rows[i].cells[j].innerHTML = arraydata[j];
                    }
                }
                else if (arraydata[1] == 'Unsuccessful') {
                    tab.rows[i].cells[3].innerHTML = 'Offline';
                    for (j = 4; j < arraydata.length - 1; j++) {
                        tab.rows[i].cells[j].innerHTML = arraydata[j];
                    }
                }
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
        //alert("inside grid");
        _doPostBack("<%=up1.UniqueID %>", "");

    };
    $.connection.hub.start().done(function () {
       
        chat.server.sendData();
        $(document).on("click", "#refresh", function () {
           
            //Call the Send method on the hub.
            chat.server.sendData();            
        });
        $(document).on("change", "#MainContent_masterchildBody_ddlins", function () {
            chat.server.sendData();
        });
    });
});

