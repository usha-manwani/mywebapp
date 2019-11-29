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
                            if (j == 5)
                                continue;
                            alliprows[i].cells[j].innerHTML = arraydata[j-1];
                        }
                    }
                    else {
                        for (j = 3; j < arraydata.length - 1; j++) {
                            if (j == 5)
                                continue;
                            alliprows[i].cells[j].innerHTML = arraydata[j-1];
                        }
                    }
                }
                else if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            alliprows[i].cells[4].innerHTML = '运行中';//OPEN
                            break;
                        case 'SystemOff':
                            alliprows[i].cells[4].innerHTML = '待机';//CLOSED
                            break;
                        case 'DSDown':
                            alliprows[i].cells[10].innerHTML = '降';//Down
                            break;
                        case 'DSStop':
                            alliprows[i].cells[10].innerHTML = '停';//Stop
                            break;
                        case 'DSUp':
                            alliprows[i].cells[10].innerHTML = '升';//Up
                            break;
                        case 'projopen':
                            alliprows[i].cells[7].innerHTML = '已开机';
                            break;
                        case 'projoff':
                            alliprows[i].cells[7].innerHTML = '已关机';
                            break;                        
                        default:
                            break;
                    }
                }
                else if (arraydata[1] == "LEDIndicator") {
                    if (arraydata[2] == "SystemSwitchOn") {
                        alliprows[i].cells[4].innerHTML = "运行中"; //Open
                            //if (arraydata[4] == "Computer") {
                            //    if (alliprows[i].cells[6].innerHTML == '已开机') {//On
                            //        alliprows[i].cells[6].innerHTML = '已关机';//Off
                            //    }                                    
                            //       else
                            //        alliprows[i].cells[6].innerHTML = '已开机';   //On                                
                            //}
                       
                        switch (arraydata[3]) {
                            case 'Desktop':
                                alliprows[i].cells[12].innerHTML = '台式电脑';//Desktop
                                break;
                            case 'Laptop':
                                alliprows[i].cells[12].innerHTML = '手提电脑';//Laptop
                                break;
                            case 'DigitalCurtain':
                                alliprows[i].cells[12].innerHTML = '数码展台';//Digital Curtain
                                break;
                            case 'DigitalScreen':
                                alliprows[i].cells[12].innerHTML = '数码设备';//Degital Screen
                                break;
                            case 'DVD':
                                alliprows[i].cells[12].innerHTML = 'DVD';//DVD
                                break;
                            case 'TV':
                                alliprows[i].cells[12].innerHTML = '电视机';//TV
                                break;
                            case 'VideoCamera':
                                alliprows[i].cells[12].innerHTML = '摄像机';//Video Camera
                                break;
                            case 'Blu-RayDVD':
                                alliprows[i].cells[12].innerHTML = '蓝光DVD';//Blu-Ray DVD
                                break;
                            case 'RecordingSystem':
                                alliprows[i].cells[12].innerHTML = '录播'; //Recording System
                                break;
                            case 'TurnOffLights':
                                alliprows[i].cells[11].innerHTML = '关'; //Off
                                break;
                            case 'CentralLocking':
                                alliprows[i].cells[13].innerHTML = '锁定'; //Locked
                                break;
                            case 'PodiumLock':
                                alliprows[i].cells[14].innerHTML = '锁定';//Locked
                                break;
                            case 'ClassLock':
                                alliprows[i].cells[15].innerHTML = '锁定';//Locked
                                break;

                        }
                        if (arraydata[5] == "CentralLock") {
                            if (alliprows[i].cells[13].innerHTML == '锁定')//Locked
                                alliprows[i].cells[13].innerHTML = '解锁'; //Unlock
                            else{
                                alliprows[i].cells[13].innerHTML = '锁定'//Locked
                            }
                        }
                        if (arraydata[5] == "PodiumLock") {
                            if (alliprows[i].cells[14].innerHTML == '锁定')//Locked
                                alliprows[i].cells[14].innerHTML = '解锁';//Unlock
                            else{
                                alliprows[i].cells[14].innerHTML = '锁定'//Locked
                            }
                        }
                        if (arraydata[5] == "ClassLock") {
                            if (alliprows[i].cells[15].innerHTML == '锁定')//Locked
                                alliprows[i].cells[15].innerHTML = '解锁';//Unlock
                            else{
                                alliprows[i].cells[15].innerHTML = '锁定'//Locked
                            }
                        }
                    }
                    else if (arraydata[2] == "SystemSwitchOff") {
                        alliprows[i].cells[4].innerHTML = "待机";//CLOSED
                    }
                }
                else if (arraydata[1] == "PanelKey") {
                    if (arraydata[2] == "PCON")
                        alliprows[i].cells[6].innerHTML = '已开机';

                    else if (arraydata[2] == "PCOFF")
                        alliprows[i].cells[6].innerHTML = '已关机';

                }
                else if (arraydata[0] == "Temp") {
                    alliprows[i].cells[16].innerHTML = arraydata[1];
                    alliprows[i].cells[17].innerHTML = arraydata[2];
                    alliprows[i].cells[18].innerHTML = arraydata[3];
                    alliprows[i].cells[19].innerHTML = arraydata[4];
                }

                else if (arraydata[2] == 'Offline') {
                    alliprows[i].cells[3].innerHTML = '离线'; //Offline
                    for (j = 4; j < arraydata.length - 1; j++) {
                        alliprows[i].cells[j].innerHTML = '--';
                    }
                }
                else if (arraydata[1] == 'Unsuccessful') {
                    alliprows[i].cells[3].innerHTML = '离线';//Offline
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




