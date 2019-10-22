$(function () {
    // Declare a proxy to reference the hub.
    
    var chat = $.connection.myHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message. 
        //var tab = document.getElementById("MainContent_masterchildBody_GridView1");
        var alliprows = document.getElementsByClassName("iprows");        
        for (i = 0; i < alliprows.length; i++) {
            var cellIp = alliprows[i].cells[2];
            var arraydata = message.split(',');
            if (cellIp.innerHTML == name)
            {                
                if (arraydata[1] == "Heartbeat") {
                    if (arraydata.length > 18) {
                        for (j = 3; j < 16; j++) {
                            alliprows[i].cells[j].innerHTML = arraydata[j-1];
                        }
                    }
                    else {
                        for (j = 3; j < arraydata.length - 1; j++) {
                            alliprows[i].cells[j].innerHTML = arraydata[j-1];
                        }
                    }
                }
                else if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            alliprows[i].cells[4].innerHTML = 'OPEN';
                            break;
                        case 'SystemOff':
                            alliprows[i].cells[4].innerHTML = 'CLOSED';
                            break;
                        case 'DSDown':
                            alliprows[i].cells[10].innerHTML = 'Down';
                            break;
                        case 'DSStop':
                            alliprows[i].cells[10].innerHTML = 'Stop';
                            break;
                        case 'DSUp':
                            alliprows[i].cells[10].innerHTML = 'Up';
                            break;
                        default:
                            break;
                    }
                }
                else if (arraydata[1] == "LEDIndicator") {
                    if (arraydata[2] == "SystemSwitchOn") {
                        alliprows[i].cells[4].innerHTML = "OPEN";
                            if (arraydata[4] == "Computer") {
                                if (alliprows[i].cells[6].innerHTML == 'On') {
                                    alliprows[i].cells[6].innerHTML = 'Off';
                                }                                    
                                   else
                                    alliprows[i].cells[6].innerHTML = 'On';                                   
                            }
                       
                        switch (arraydata[3]) {
                            case 'Desktop':
                                alliprows[i].cells[12].innerHTML = 'Desktop';
                                break;
                            case 'Laptop':
                                alliprows[i].cells[12].innerHTML = 'Laptop';
                                break;
                            case 'DigitalCurtain':
                                alliprows[i].cells[12].innerHTML = 'Digital Curtain';
                                break;
                            case 'DigitalScreen':
                                alliprows[i].cells[12].innerHTML = 'Digital Screen';
                                break;
                            case 'DVD':
                                alliprows[i].cells[12].innerHTML = 'DVD';
                                break;
                            case 'TV':
                                alliprows[i].cells[12].innerHTML = 'TV';
                                break;
                            case 'VideoCamera':
                                alliprows[i].cells[12].innerHTML = 'Video Camera';
                                break;
                            case 'Blu-RayDVD':
                                alliprows[i].cells[12].innerHTML = 'Blu-Ray DVD';
                                break;
                            case 'RecordingSystem':
                                alliprows[i].cells[12].innerHTML = 'Recording System';
                                break;
                            case 'TurnOffLights':
                                alliprows[i].cells[11].innerHTML = 'Off';
                                break;
                            case 'CentralLocking':
                                alliprows[i].cells[13].innerHTML = 'Locked';
                                break;
                            case 'PodiumLock':
                                alliprows[i].cells[14].innerHTML = 'Locked';
                                break;
                            case 'ClassLock':
                                alliprows[i].cells[15].innerHTML = 'Locked';
                                break;

                        }
                        if (arraydata[5] == "CentralLock") {
                            if (alliprows[i].cells[13].innerHTML == 'Locked')
                                alliprows[i].cells[13].innerHTML = 'Unlocked'; 
                            else{
                                alliprows[i].cells[13].innerHTML = 'Locked'
                            }
                        }
                        if (arraydata[5] == "PodiumLock") {
                            if (alliprows[i].cells[14].innerHTML == 'Locked')
                                alliprows[i].cells[14].innerHTML = 'Unlocked';
                            else{
                                alliprows[i].cells[14].innerHTML = 'Locked'
                            }
                        }
                        if (arraydata[5] == "ClassLock") {
                            if (alliprows[i].cells[15].innerHTML == 'Locked')
                                alliprows[i].cells[15].innerHTML = 'Unlocked';
                            else{
                                alliprows[i].cells[15].innerHTML = 'Locked'
                            }
                        }
                    }
                    else if (arraydata[2] == "SystemSwitchOff") {
                        alliprows[i].cells[4].innerHTML = "CLOSED";
                    }
                }
                else if (arraydata[0] == "Temp") {
                    alliprows[i].cells[16].innerHTML = arraydata[1];
                    alliprows[i].cells[17].innerHTML = arraydata[2];
                    alliprows[i].cells[18].innerHTML = arraydata[3];
                    alliprows[i].cells[19].innerHTML = arraydata[4];
                }

                else if (arraydata[2] == 'Offline') {
                    alliprows[i].cells[3].innerHTML = 'Offline';
                    for (j = 4; j < arraydata.length - 1; j++) {
                        alliprows[i].cells[j].innerHTML = '--';
                    }
                }
                else if (arraydata[1] == 'Unsuccessful') {
                    alliprows[i].cells[3].innerHTML = 'Offline';
                    for (j = 4; j < arraydata.length - 1; j++) {
                        alliprows[i].cells[j].innerHTML = arraydata[j];
                    }
                }
                //else if (arraydata[1] == "PanelKey") {
                //    switch (arraydata[2]) {
                //        case 'ComputerSystemON':
                //            alliprows[i].cells[5].innerHTML = 'On';
                //            break;  
                //        case 'ComputerSystemOFF':
                //                alliprows[i].cells[5].innerHTML = 'Off';
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
function triggerclick() {
    $('#refresh').trigger('click');
    console.log("after click");
}




