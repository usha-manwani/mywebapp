$ = jQuery.noConflict();
var ipAddress = "";
var chat ;
$(document).ready(function () {
    disableAll();
    chat = $.connection.myHub;
    chat.client.broadcastMessage = function (name, message) {
        ipAddress = $('#ipadd').prop('innerText');
        if (name == ipAddress) {
            enableAll();
            $('#ipstatus').prop('innerText','Online')
            console.log(message);
            var arraydata = message.split(',');
            if (arraydata[0] == "NetworkControl") {
                if (arraydata[1] == 'PanelKey') {
                    if (arraydata[2] == "PCON") {
                        $('#computer').prop('checked', true);
                    }

                    else {
                        $('#computer').prop('checked', false);
                    }

                }
                else if (arraydata[1] == "Heartbeat") {
                    if (arraydata[12] == '锁定') {//Locked
                        $('#systemlock').prop('checked', false);
                    }
                    else if (arraydata[12] == '解锁') { //unlocked
                        $('#systemlock').prop('checked', true);
                    };

                    if (arraydata[3] == '待机') {
                        $('#system').prop('checked', false);
                        $("input[name='signal'][value='desktop']").prop('checked', false);
                        $("input[name='signal'][value='laptop']").prop('checked', false);
                        $("input[name='signal'][value='othersignal']").prop('checked', false);
                        $('#computer').prop('checked', false);
                        $('#systemlock').prop('checked', false);
                        $("input[name='screen'][value='down']").prop('checked', false);
                        $("input[name='screen'][value='up']").prop('checked', false);
                        $("input[name='screen'][value='stop']").prop('checked', false);
                    }
                    else {
                        $('#system').prop('checked', true);
                        if (arraydata[5] == '已开机') {//On
                            $('#computer').prop('checked', true);
                        }
                        else {
                            $('#computer').prop('checked', false);
                        }

                        switch (arraydata[11]) {
                            case '台式电脑'://Desktop
                                $("input[name='signal'][value='desktop']").prop('checked', true);
                                break;
                            case '手提电脑'://Laptop
                                $("input[name='signal'][value='laptop']").prop('checked', true);
                                break;
                            case '数码展台':
                                $("input[name='signal'][value='othersignal']").prop('checked', true);
                                break;
                        }
                        if (arraydata[9] == '停') {
                            $("input[name='screen'][value='stop']").prop('checked', true);
                        }
                        else if (arraydata[9] == '降') {//Down
                            $("input[name='screen'][value='down']").prop('checked', true);
                        }
                        else if (arraydata[9] == '升') {//Up
                            $("input[name='screen'][value='up']").prop('checked', true);
                        }
                        if (arraydata[6] == '已关机') {//Closed
                            $('#projector1').prop('checked', false);
                        }
                        else {
                            $('#projector1').prop('checked', true);
                        }
                    }
                }                
            }
            else {
                if (arraydata[1] == "KeyValue") {
                    switch (arraydata[2]) {
                        case 'SystemON':
                            $('#system').prop('checked', true);

                            break;
                        case 'SystemOff':
                            $('#system').prop('checked', false);
                            break;
                        case 'DSDown':
                            $("input[name='screen'][value='down']").prop('checked', true);
                            break;
                        case 'DSUp':
                            $("input[name='screen'][value='up']").prop('checked', true);
                            break;
                        case 'DSStop':
                            $("input[name='screen'][value='stop']").prop('checked', true);
                            break;
                    }
                }
                else if (arraydata[1] == "LEDIndicator") {
                    if (arraydata[5] == "CentralLock") {
                        $('#systemlock').prop('checked', false);
                    }
                    else if (arraydata[5] == "CentralLockoff") {
                        $('#systemlock').prop('checked', true);
                    }
                    if (arraydata[2] == "SystemSwitchOn") {
                        $('#system').prop('checked', true);
                        if (arraydata[4] == "Computer") {
                            $('#computer').prop('checked', true);
                        }
                        switch (arraydata[3]) {
                            case 'Desktop':
                                $("input[name='signal'][value='desktop']").prop('checked', true);
                                break;
                            case 'Laptop':
                                $("input[name='signal'][value='laptop']").prop('checked', true);
                                break;
                            case 'DigitalCurtain':
                                $("input[name='signal'][value='othersignal']").prop('checked', true);
                                break;
                        }
                    }
                    else if (arraydata[2] == "SystemSwitchOff") {
                        $('#system').prop('checked', false);
                        
                    }
                }
            }
            if (arraydata[2] == 'Offline' || arraydata[1] == 'Unsuccessful' || arraydata[2] == '离线') {
                $('#system').prop('checked', false);
                $("input[name='signal'][value='desktop']").prop('checked', false);
                $("input[name='signal'][value='laptop']").prop('checked', false);
                $("input[name='signal'][value='othersignal']").prop('checked', false);
                $('#computer').prop('checked', false);
                $('#systemlock').prop('checked', false);
                $('#projector1').prop('checked', false);
                $('#projector2').prop('checked', false);
                $("input[name='screen'][value='down']").prop('checked', false);
                $("input[name='screen'][value='up']").prop('checked', false);
                $("input[name='screen'][value='stop']").prop('checked', false);
            }
        };
    }
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        getfirstclass();
        ipAddress = $('#ipadd').prop('innerText');
        console.log("hub connected , Hub id " + $.connection.hub.id);
        chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
        SetVolume = function (val){            
            var lastVal = this.document.getElementById("volchange").innerText;
            if (lastVal > val.value && val.value > 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 21 2B");
                if (parseInt(lastVal) > 10) {
                    val.value = parseInt(lastVal) - 10;
                    this.document.getElementById("volchange").innerText = parseInt(lastVal) - 10;
                }
                else {
                    
                    this.document.getElementById("volchange").innerText = val.value;
                }
            }
            else if (val.value == 0) {
                
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 22 2C");
                this.document.getElementById("volchange").innerText = 0;
                val.value = 0;

            }
            else if (lastVal < val.value) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 20 2A");
                if (parseInt(lastVal) < 90) {
                    val.value = parseInt(lastVal) + 10;
                    this.document.getElementById("volchange").innerText = parseInt(lastVal) + 10;
                }
                else {
                    
                    this.document.getElementById("volchange").innerText = val.value;
                }
            }
        };
        MicControl = function (val) {
            var lastVal = this.document.getElementById("micchange").innerText;

            if (lastVal > val.value && val.value > 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 74 7e");
                if (parseInt(lastVal) > 10) {
                    val.value = parseInt(lastVal) - 10;
                    this.document.getElementById("micchange").innerText = parseInt(lastVal) - 10;
                }
                else {
                     
                    this.document.getElementById("micchange").innerText = val.value;

                }
            }
            else if (val.value == 0) {
                
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 75 7f");
                this.document.getElementById("micchange").innerText = 0;
                val.value = 0;
            }
            else if (lastVal < val.value) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 73 7d");
                if (parseInt(lastVal) < 90) {
                    val.value = parseInt(lastVal) + 10;
                    this.document.getElementById("micchange").innerText = parseInt(lastVal) + 10;
                }
                else {
                   
                    this.document.getElementById("micchange").innerText = val.value;

                }
            }

        };
        WiredMicControl = function (val) {
            var lastVal = this.document.getElementById("wiredmicchange").innerText;
            if (lastVal > val.value && val.value > 0) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 24 2e");
                if (parseInt(lastVal) > 10) {
                    val.value = parseInt(lastVal) - 10;
                    this.document.getElementById("wiredmicchange").innerText = val.value;
                }
                else {

                    this.document.getElementById("wiredmicchange").innerText = val.value;

                }
            }
            else if (val.value == 0) {

                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 25 2f");
                this.document.getElementById("wiredmicchange").innerText = 0;
                val.value = 0;
            }
            else if (lastVal < val.value) {

                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 23 2d");
                if (parseInt(lastVal) < 90)
                {
                    val.value = parseInt(lastVal) + 10;
                    this.document.getElementById("wiredmicchange").innerText = val.value;
                }
                else
                {
                    this.document.getElementById("wiredmicchange").innerText = val.value;
                }
            }
            else
            {

            }

        };
        $(document).on("change", "#system", function () {
            if (this.checked) {                
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 05 02 1E 29");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 05 02 1F 2A");
            }                
            chat.server.sendControlKeys(ipAddress, "8B B9 00 03 05 01 09");
        });
        $(document).on("change", "#computer", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 17 21");

        });
        $(document).on("change", "#systemlock", function () {
            if (this.checked) {
                
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2d 37");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 2c 36");
            }
            
        });
        $(document).on("change", "input[name='signal']", function () {
            if (this.value == 'laptop')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 11 1b");

            else if (this.value = 'desktop')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 10 1A");
            else {
                $("input[name='signal'][value='desktop']").prop('checked', false);
                $("input[name='signal'][value='laptop']").prop('checked', false);
                $("input[name='signal'][value='othersignal']").prop('checked', false);
                 }
        });
        $(document).on("change", "input[name='screen']", function () {
            if (this.value == 'up')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 76 80");

            else if (this.value = 'down')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 56 60");
            else if (this.value = 'stop')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 66 70");
        });
        $(document).on("change", "#projector1", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 33 3D");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 43 4D");
            }
        });
        $(document).on("change", "#projector2", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 33 3D");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 43 4D");
            }
        });

        $(document).on("change", "#light1", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 78 82");
        });
        $(document).on("change", "#light2", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 68 72");
        });
        $(document).on("change", "input[name='env']", function () {
            if (this.value == 'open')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 46 50");
            else if (this.value = 'close')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 47 51");
            else if (this.value = 'stop')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 48 52");
        });
        $(document).on("change", "input[name='env2']", function () {
            if (this.value == 'open')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 49 53");
            else if (this.value = 'close')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 4a 54");
            else if (this.value = 'stop')
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 4b 55");
        });
        $(document).on("change", "#ac1", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 59 63");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5A 64");
            }
        });
        $(document).on("change", "#ac2", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 59 63");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5A 64");
            }
        });
        $(document).on("change", "#ac2", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 59 63");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5A 64");
            }
        });
        $(document).on("change", "#ac2", function () {
            if (this.checked) {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 59 63");
            }
            else {
                chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 5A 64");
            }
        });
    });

    $(document).on('click', "#btncontrol", function () {
        //$('#control').prop('style', 'display:block');
        //$("#envcontrol").prop('style', 'display:none');
        document.getElementById('control').style.display = 'block';
        document.getElementById('envcontrol').style.display = 'none';
        $(this).addClass('active btn-primary')
        $(this).removeClass('btn-secondary');
        $("#btnenvcontrol").removeClass('active btn-primary')
        $("#btnenvcontrol").addClass('btn-secondary');
    });

    $(document).on('click', "#btnenvcontrol", function () {
        //$("#envcontrol").prop('style', 'display:block');
        //$("#control").prop('style', 'display:none');
        document.getElementById('control').style.display = 'none';
        document.getElementById('envcontrol').style.display = 'block';
        $(this).addClass('active btn-primary')
        $(this).removeClass('btn-secondary');
        $("#btncontrol").removeClass('active btn-primary')
        $("#btncontrol").addClass(' btn-secondary');
    });

    $(document).on("click", '.getclassid', function () {
        var id = $(this).prop('id');
        var name = $(this).prop('innerText');
        $('#LocationName').prop('innerText', name);
        $('#headClass').prop('innerText', name);
        GetIpOnLocation(id);
    });
});

function disableAll() {
    $("input[name='signal'][value='desktop']").prop('disabled', true);
    $("input[name='signal'][value='laptop']").prop('disabled', true);
    $("input[name='signal'][value='othersignal']").prop('disabled', true);
    $('#computer').prop('disabled', true);
    $('#computer').prop('checked', false);
    $('#systemlock').prop('disabled', true);
    $("input[name='screen'][value='down']").prop('disabled', true);
    $("input[name='screen'][value='up']").prop('disabled', true);
    $("input[name='screen'][value='stop']").prop('disabled', true);
    $('#system').prop('disabled', true);
    $('#projector1').prop('disabled', true);
    $('#projector2').prop('disabled', true);
}

function enableAll() {
    $("input[name='signal'][value='desktop']").prop('disabled', false);
    $("input[name='signal'][value='laptop']").prop('disabled', false);
    $("input[name='signal'][value='othersignal']").prop('disabled', false);
    $('#computer').prop('disabled', false);
    $('#systemlock').prop('disabled', false);
    $("input[name='screen'][value='down']").prop('disabled', false);
    $("input[name='screen'][value='up']").prop('disabled', false);
    $("input[name='screen'][value='stop']").prop('disabled', false);
    $('#system').prop('disabled', false);
    $('#projector1').prop('disabled', false);
    $('#projector2').prop('disabled', false);
}



function getfirstclass() {
    disableAll();
    var loc = document.getElementsByClassName('getclassid');
    var name = loc[0].innerText;
    var id = loc[0].id;
    $('#LocationName').prop('innerText', name);
    $('#headClass').prop('innerText', name);
    GetIpOnLocation(id);
    
}

function GetIpOnLocation(id) {
    var jsonData = JSON.stringify({
        name: id
    });
    $.ajax({
        type: "POST",
        url: "../Services/GetSideMenu.asmx/GetApAdd",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccessip,
        error: OnErrorCallip
    });
    function OnSuccessip(response){
        var data = response.d;
        var ip = data[0];
        $('#ipadd').prop('innerText', ip);
        chat.server.sendControlKeys(ip, "8B B9 00 03 05 01 09");
    }
    function OnErrorCallip(resp){
        console.log(resp);
    }
    callCam(id);
}







