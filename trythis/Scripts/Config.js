var chat = $.connection.myHub;
console.log(isHex(""));

$(function () {
   
    chat.client.broadcastMessage = function (name, message) {
        var arraydata = message.split(',');        
        if (arraydata[1] == "MacSuccess") {
            console.log(name);
            putTick(name);
            
        }
        else if (arraydata[1] == "MacFailure") {
            putWrongTick(name);
        }
        if (arraydata[0] == "config") {
            var delay = document.getElementById("delaymin");
            switch (arraydata[1]) {
                case "1":
                    delay.selectedIndex = "0";
                    break;
                case "2":
                    delay.selectedIndex = "1";
                    break;
                case "3":
                    delay.selectedIndex = "2";
                    break;
                case "4":
                    delay.selectedIndex = "3";
                    break;
                case "5":
                    delay.selectedIndex = "4";
                    break;
                case "6":
                    delay.selectedIndex = "5";
                    break;
                case "7":
                    delay.selectedIndex = "6";
                    break;
                case "8":
                    delay.selectedIndex = "7";
                    break;
                case "9":
                    delay.selectedIndex = "8";
                    break;
                
            }
            var delay1 = document.getElementById("delaysec");
            switch (arraydata[20]) {
                case "1":
                    delay1.selectedIndex = "0";
                    break;
                case "2":
                    delay1.selectedIndex = "1";
                    break;
                case "3":
                    delay1.selectedIndex = "2";
                    break;
                case "4":
                    delay1.selectedIndex = "3";
                    break;
                case "5":
                    delay1.selectedIndex = "4";
                    break;
                case "6":
                    delay1.selectedIndex = "5";
                    break;
                case "7":
                    delay1.selectedIndex = "6";
                    break;
                case "8":
                    delay1.selectedIndex = "7";
                    break;
                case "9":
                    delay1.selectedIndex = "8";
                    break;
                case "10":
                    delay1.selectedIndex = "9";
                    break;
                case "11":
                    delay1.selectedIndex = "10";
                    break;
                case "12":
                    delay1.selectedIndex = "11";
                    break;
                case "13":
                    delay1.selectedIndex = "12";
                    break;
                case "14":
                    delay1.selectedIndex = "13";
                    break;
            }
            if (arraydata[2]=="1")
                document.getElementById("cb3").checked = true;
            else
                document.getElementById("cb3").checked = false;
            if (arraydata[3] == "1")
                document.getElementById("cb1").checked = true;
            else
                document.getElementById("cb1").checked = false;
            if (arraydata[4] == "1")
                document.getElementById("cb2").checked = true;
            else
                document.getElementById("cb2").checked = false;
            if (arraydata[5] == "1")
                document.getElementById("cb4").checked = true;
            else
                document.getElementById("cb4").checked = false;
            if (arraydata[6] == "1")
                document.getElementById("cb5").checked = true;
            else
                document.getElementById("cb5").checked = false;
            if (arraydata[7] == "1")
                document.getElementById("cb6").checked = true;
            else
                document.getElementById("cb6").checked = false;
            if (arraydata[8] == "1")
                document.getElementById("cb7").checked = true;
            else
                document.getElementById("cb7").checked = false;
            if (arraydata[9] == "1")
                document.getElementById("cb8").checked = true;
            else
                document.getElementById("cb8").checked = false;
            if (arraydata[10] == "1")
                document.getElementById("cb9").checked = true;
            else
                document.getElementById("cb9").checked = false;
            if (arraydata[11] == "1")
                document.getElementById("cb10").checked = true;
            else
                document.getElementById("cb10").checked = false;
            if (arraydata[12] == "1")
                document.getElementById("cb11").checked = true;
            else
                document.getElementById("cb11").checked = false;
            if (arraydata[13] == "1")
                document.getElementById("cb14").checked = true;
            else
                document.getElementById("cb14").checked = false;
            if (arraydata[14] == "1")
                document.getElementById("cb12").checked = true;
            else
                document.getElementById("cb12").checked = false;
            if (arraydata[15] == "1")
                document.getElementById("cb13").checked = true;
            else
                document.getElementById("cb13").checked = false;
            if (arraydata[16] == "1")
                document.getElementById("cb15").checked = true;
            else
                document.getElementById("cb15").checked = false;
            if (arraydata[17] == "1")
                document.getElementById("cb16").checked = true;
            else
                document.getElementById("cb16").checked = false;
            if (arraydata[18] == "1")
                document.getElementById("cb17").checked = true;
            else
                document.getElementById("cb17").checked = false;
            if (arraydata[19] == "1")
                document.getElementById("cb18").checked = true;
            else
                document.getElementById("cb18").checked = false;
            if (arraydata[21] == "1")
                document.getElementById("cb19").checked = true;
            else
                document.getElementById("cb19").checked = false;
            if (arraydata[22] == "1")
                document.getElementById("cb20").checked = true;
            else
                document.getElementById("cb20").checked = false;
            if (arraydata[23] == "1")
                document.getElementById("cb21").checked = true;
            else
                document.getElementById("cb21").checked = false;
            var rr = parseInt(arraydata[24]).toString(16);
            var dd = hex2bin(rr);
            var alarmhigh = dd.split('');
            
            if (alarmhigh[0] == "1") {
                document.getElementById('cb29').checked = true;
            }
            if (alarmhigh[1] == "1") {
                document.getElementById('cb28').checked = true;
            }
            if (alarmhigh[2] == "1") {
                document.getElementById('cb27').checked = true;
            }
            if (alarmhigh[3] == "1") {
                document.getElementById('cb26').checked = true;
            }
            if (alarmhigh[4] == "1") {
                document.getElementById('cb25').checked = true;
            }
            if (alarmhigh[5] == "1") {
                document.getElementById('cb24').checked = true;
            }
            if (alarmhigh[6] == "1") {
                document.getElementById('cb23').checked = true;
            }
            if (alarmhigh[7] == "1") {
                document.getElementById('cb22').checked = true;
            }

            var rr1 = parseInt(arraydata[25]).toString(16);
            var dd1 = hex2bin(rr1);
            var alarmhigh1 = dd1.split('');
            if (alarmhigh1[0] == "1") {
                document.getElementById('cb37').checked = true;
            }
            if (alarmhigh1[1] == "1") {
                document.getElementById('cb36').checked = true;
            }
            if (alarmhigh1[2] == "1") {
                document.getElementById('cb35').checked = true;
            }
            if (alarmhigh1[3] == "1") {
                document.getElementById('cb34').checked = true;
            }
            if (alarmhigh1[4] == "1") {
                document.getElementById('cb33').checked = true;
            }
            if (alarmhigh1[5] == "1") {
                document.getElementById('cb32').checked = true;
            }
            if (alarmhigh1[6] == "1") {
                document.getElementById('cb31').checked = true;
            }
            if (alarmhigh1[7] == "1") {
                document.getElementById('cb30').checked = true;
            }

            var rr2 = parseInt(arraydata[26]).toString(16);
            var dd2 = hex2bin(rr2);
            var iohigh = dd2.split('');
            if (iohigh[0] == "1") {
                document.getElementById('cb45').checked = true;
            }
            if (iohigh[1] == "1") {
                document.getElementById('cb44').checked = true;
            }
            if (iohigh[2] == "1") {
                document.getElementById('cb43').checked = true;
            }
            if (iohigh[3] == "1") {
                document.getElementById('cb42').checked = true;
            }
            if (iohigh[4] == "1") {
                document.getElementById('cb41').checked = true;
            }
            if (iohigh[5] == "1") {
                document.getElementById('cb40').checked = true;
            }
            if (iohigh[6] == "1") {
                document.getElementById('cb39').checked = true;
            }
            if (iohigh[7] == "1") {
                document.getElementById('cb38').checked = true;
            }

            var rr3 = parseInt(arraydata[27]).toString(16);
            var dd3 = hex2bin(rr3);
            var iohigh1 = dd3.split('');
            if (iohigh1[0] == "1") {
                document.getElementById('cb53').checked = true;
            }
            if (iohigh1[1] == "1") {
                document.getElementById('cb52').checked = true;
            }
            if (iohigh1[2] == "1") {
                document.getElementById('cb51').checked = true;
            }
            if (iohigh1[3] == "1") {
                document.getElementById('cb50').checked = true;
            }
            if (iohigh1[4] == "1") {
                document.getElementById('cb49').checked = true;
            }
            if (iohigh1[5] == "1") {
                document.getElementById('cb48').checked = true;
            }
            if (iohigh1[6] == "1") {
                document.getElementById('cb47').checked = true;
            }
            if (iohigh1[7] == "1") {
                document.getElementById('cb46').checked = true;
            }
        }
        
    };
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        $(document).on('click', '#readConfig', function () {
            // uncheckall();
            var checkboxlist = document.getElementById("ddlClass");
            var checkbox = checkboxlist.getElementsByTagName("input");
            for (i = 0; i < checkbox.length; i++) {
                var this1 = checkbox[i];
                var checked = false;
                checked = this1.checked;
                console.log($(this1).val());
                if (checked) {
                    var ip = $(this1).val();
                    chat.server.sendControlKeys(ip, "8B B9 00 03 03 02 08");
                    break;
                }
            }            
           // chat.server.sendControlKeys("192.168.1.38","8B B9 00 03 03 02 08");
        });
        $(document).on('click', "#writeConfig", function () {
            var data1 = "8b b9 ";
            var data = "00 1E 03 03 ";
            
            var delaymins = document.getElementById('delaymin');
            data = data + delaymins[delaymins.selectedIndex].value + " ";
            
            if (document.getElementById('cb3').checked == true) {
                data = data + "01 ";                
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb1').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb2').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb4').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb5').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb6').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb7').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb8').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb9').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb10').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb11').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb14').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb12').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb13').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb15').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb16').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb17').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb18').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            var delaysecs = document.getElementById("delaysec");
            data = data + delaysecs[delaysecs.selectedIndex].value + " ";
            if (document.getElementById('cb19').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb20').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            if (document.getElementById('cb21').checked == true) {
                data = data + "01 ";
            }
            else {
                data = data + "00 ";
            }
            //***alarm values***//
            var alarm = "";
            if (document.getElementById('cb29').checked == true) {
                alarm = "1";
            }
            else {
                alarm = "0";
            }
            if (document.getElementById('cb28').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb27').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb26').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb25').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb24').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb23').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb22').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            data = data + bin2hex(alarm) + " ";

            alarm = "";
            if (document.getElementById('cb37').checked == true) {
                alarm = "1";
            }
            else {
                alarm = "0";
            }
            if (document.getElementById('cb36').checked == true) {
                alarm = alarm+"1";
            }
            else {
                alarm = alarm+"0";
            }
            if (document.getElementById('cb35').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb34').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb33').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb32').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb31').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            if (document.getElementById('cb30').checked == true) {
                alarm = alarm + "1";
            }
            else {
                alarm = alarm + "0";
            }
            data = data + bin2hex(alarm) + " ";

            var io = "";
            if (document.getElementById('cb45').checked == true) {
                io = "1";
            }
            else {
                io = "0";
            }
            if (document.getElementById('cb44').checked == true) {
                io = io+ "1";
            }
            else {
                io = io+ "0";
            }  
            if (document.getElementById('cb43').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }  
            if (document.getElementById('cb42').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }  
            if (document.getElementById('cb41').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }  
            if (document.getElementById('cb40').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }  
            if (document.getElementById('cb39').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            } 
            if (document.getElementById('cb38').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }
            data = data + bin2hex(io) + " ";

            io = "";
            if (document.getElementById('cb53').checked == true) {
                io = "1";
            }
            else {
                io = "0";
            }
            if (document.getElementById('cb52').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }
            if (document.getElementById('cb51').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }
            if (document.getElementById('cb50').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }
            if (document.getElementById('cb49').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }
            if (document.getElementById('cb48').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }
            if (document.getElementById('cb47').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }
            if (document.getElementById('cb46').checked == true) {
                io = io + "1";
            }
            else {
                io = io + "0";
            }
            data = data + bin2hex(io) + " ";
            //***calculate checksum***//
            var chk = data.split(' ');
            var chksum = 0;
            for (i = 0; i < chk.length-1; i++) {
                chksum = chksum + parseInt( chk[i], 16);
            }; 
            chksum = chksum & 255;
            var checksum = chksum.toString(16);
            data = data1 + data + checksum;
            var checkboxlist = document.getElementById("ddlClass");
            var checkbox = checkboxlist.getElementsByTagName("input");
            for (i = 0; i < checkbox.length; i++) {
                var this1 = checkbox[i];
                var checked = false;
                checked = this1.checked;
                console.log($(this1).val());
                if (checked) {
                    var ip = checkbox.value;
                    chat.server.sendControlKeys(ip, data);
                    
                }
            }
           // chat.server.sendControlKeys("192.168.1.38", data);            
        });
        $(document).on('click', "#projok", function () {
           
        });
        $(document).on('click', "powerok", function () {
            if (document.getElementById("bc1").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 78 82");
                    }
                    //chat.server.sendControlKeys("192.168.1.38", "8b b9 00 04 02 04 78 82");

                }
            }
                if (document.getElementById("bc2").checked == true) {
                    var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                    for (i = 0; i < checkbox.length; i++) {
                        if (checkbox.checked) {
                            var ip = checkbox.value;
                            chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                        }
                        // chat.server.sendControlKeys("192.168.1.38", "8b b9 00 04 02 04 68 72");
                    }
                }
            if (document.getElementById("bc3").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 58 62");
                    }
                }
                //chat.server.sendControlKeys("192.168.1.38", "8b b9 00 04 02 04 58 62");
            }
                
            
            if (document.getElementById("bc4").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 53 5d");
                    }
                }
               // chat.server.sendControlKeys("192.168.1.38", "8b b9 00 04 02 04 53 5d");
            }
            if (document.getElementById("bc5").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 54 5e");
                    }
                }
                //chat.server.sendControlKeys("192.168.1.38", "8b b9 00 04 02 04 54 5e");
            }
            if (document.getElementById("bc6").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 55 5F");
                    }
                }
                //chat.server.sendControlKeys("192.168.1.38", "8b b9 00 04 02 04 55 5F");
            }
            if (document.getElementById("bc7").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 78 82");
                    }
                }
                //chat.server.sendControlKeys("192.168.1.38", "8b b9 00 04 02 04 78 82");
            }
            if (document.getElementById("bc8").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
                //chat.server.sendControlKeys("192.168.1.38", "8b b9 00 04 02 04 68 72");
            }
            if (document.getElementById("bc9").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc10").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc11").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc12").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }

            }
            if (document.getElementById("bc13").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc14").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc15").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc16").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc17").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc18").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc19").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc20").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc21").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc22").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc23").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("bc24").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("w1").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("w11").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("w2").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("w22").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("w3").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("w33").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("w4").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("w44").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("air1").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("air11").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("air2").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
            if (document.getElementById("air22").checked == true) {
                var checkbox = document.getElementById("MainContent_masterchildBody_masterSideBody_ddlClass");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox.checked) {
                        var ip = checkbox.value;
                        chat.server.sendControlKeys(ip, "8b b9 00 04 02 04 68 72");
                    }
                }
            }
        });
        $(document).on('click', "camok", function () {
            
            if (document.getElementById("cam11").value!='')
                chat.server.sendControlKeys("", "");            
            if (document.getElementById("cam12").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam13").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam14").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam15").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam16").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam17").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam18").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam19").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam20").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam21").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam22").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("cam23").value != '')
                chat.server.sendControlKeys("", "");
        });
        $(document).on('click', "recok", function () {
            if (document.getElementById("sys1").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("sys2").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("sys3").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("sys4").value != '')
                chat.server.sendControlKeys("", "");
            if (document.getElementById("sys5").value != '')
                chat.server.sendControlKeys("", "");
        });
    });
    getAllClasses();
    
});

function bin2hex(b) {
    return b.match(/.{1,4}/g).reduce(function (acc, i) {
        return acc + parseInt(i, 2).toString(16);
    }, '');
}
function hex2bin(h) {    
    return ('00000000' + parseInt(h, 16).toString(2)).substr(-8);    
}

function uncheckall() {
    var check = document.getElementsByName("sys");
    for (i = 0; i < check.length; i++) {
        if (check[i].type == "checkbox") {
            check[i].checked = false;
        }
    }
}

function isHex(h) {
    return !isNaN(parseInt(h,16))
    //var re = /[0-9A-Fa-f]{6}/g;
    
    //if (re.test(h)) {
    //    re.lastIndex = 0;
    //    return true;
    //} else {
    //    re.lastIndex = 0;
    //    return false;
    //} 
}

function getAllClasses() {
    var jsonData = JSON.stringify({

        name: "name"
    });
    $.ajax({
        type: "POST",
        url: "Services/ChartData.asmx/GetInsIds",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        error: OnErrorCall
    });

    function OnSuccess(response) {
        var data = response.d;
        var ins = data[0];
        
        for (i = 0; i < ins.length; i++) {
            
            var jsonData = JSON.stringify({

                insid: ins[i]
            });
            $.ajax({
                type: "POST",
                url: "Services/ChartData.asmx/GetGradeIds",
                data: jsonData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccessGrade,
                error: OnErrorCall
            });
            function OnSuccessGrade(resp) {
                var data = resp.d;
                var grade = data[0];
                
               
                for (j = 0; j < grade.length; j++) {
                    
                    var jsonData = JSON.stringify({

                        gradeid: grade[j]
                    });
                    $.ajax({
                        type: "POST",
                        url: "Services/ChartData.asmx/GetIpClass",
                        data: jsonData,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: OnSuccessMachines,
                        error: OnErrorCall
                    });
                    function OnSuccessMachines(repo) {
                        showClass(repo);
                    }
                }
            }

        }
    }
    
   
    function OnErrorCall(respo) {
        console.log(respo);
    }
}

function showClass(response) {
    var data = response.d;
    var classname = data[0];
    var ip = data[1];
    var insname = data[2];
    var gradename = data[3];
    var maindiv = document.getElementById("macAddress");
    var table = document.createElement("table");
    $(table).addClass("macaddresstable");
    maindiv.appendChild(table);
    var mainrow = document.createElement("tr");
    table.appendChild(mainrow);
    var maincol = document.createElement("td");
    maincol.colSpan = 9;
    maincol.innerHTML = '<h4 style="color:#1e1e36;">' +
        '<span>' + insname + ' >> ' + gradename + '</span>' +
            '</h4><hr style="background-color:#1e1e36" />';
    mainrow.appendChild(maincol);
    for (i = 0; i < ip.length; i++) {
        var row = document.createElement("tr");
        $(row).addClass("trrow");
        table.appendChild(row);
        var col = document.createElement("td");
        col.style.width = "40%";
        col.innerHTML = '<label>' + classname[i] + '</label> <input type="hidden" name="ip" class="hiddenip" value="' + ip[i] + '" />';
        row.appendChild(col);
        var col1 = document.createElement("td");
        var ele = '<span style="float: left"><input type = "text" maxlength="2" ' +
            'class="form-control column"/></span >' +
            '<span style="float: right">:</span>';
        col1.innerHTML = ele;
        row.appendChild(col1);
        var col2 = document.createElement("td");
        var ele1 = '<span style="float: left"><input type = "text" maxlength="2" ' +
            'class="form-control column"/></span >' +
            '<span style="float: right">:</span>';
        col2.innerHTML = ele1;
        row.appendChild(col2);
        var col3 = document.createElement("td");
        var ele2 = '<span style="float: left"><input type = "text" maxlength="2" ' +
            'class="form-control column" /></span >' +
            '<span style="float: right">:</span>';
        col3.innerHTML = ele2;
        row.appendChild(col3);
        var col4 = document.createElement("td");
        var ele3 = '<span style="float: left"><input type = "text" maxlength="2" ' +
            'class="form-control column"/></span >' +
            '<span style="float: right">:</span>';
        col4.innerHTML = ele3;
        row.appendChild(col4);
        var col5 = document.createElement("td");
        var ele4 = '<span style="float: left"><input type = "text" maxlength="2" ' +
            'class="form-control column"/></span >' +
            '<span style="float: right">:</span>';
        col5.innerHTML = ele4;
        row.appendChild(col5);
        var col6 = document.createElement("td");
        var ele5 = '<span style="float: left"><input type = "text" maxlength="2" ' +
            'class="form-control column"/></span >';
        col6.innerHTML = ele5;
        row.appendChild(col6);
        var col7 = document.createElement("td");
        var ele6 = '<span ><img src="Images/done.png" height="25" width="25" class="tick" style="display:none"/>' +
            '<img src="Images/notdone.png" height="25" width="25" class="nottick" style="display:none"/></span > ';
        col7.innerHTML = ele6;       
        row.appendChild(col7);
        addEvent();
    }

   
}

function changeMac() {
    RemoveTicks();
    var table = document.getElementsByClassName("macaddresstable");
    var totaltable = table.length;
    console.log(totaltable);
    
    var rows1;
    try {
        for (z = 0; z < table.length; z++) {
           // console.log("i inside table loop" + z);
            var tb = table[z];
            rows1 = tb.rows;
            for (j = 1; j < rows1.length; j++) {
                var ip = $(rows1[j]).find('input[name="ip"]').val().trim();
                //console.log(ip);
                var sum;
                var cells = rows1[j].cells;
                var data = "";
                var d;
                sum = 0;
                
                for (k = 1; k < 7; k++) {
                    d = $(cells[k]).find('.column').val().trim();
                    if (isHex(d)) {
                        data = data + " " + d;
                        sum = sum + parseInt(d, 16);
                        //console.log(parseInt(d, 16));
                    }
                    else {
                        break;
                    }

                }
                if (sum == 0) {
                    continue;
                }
                else {
                    //console.log("sum=  "+sum+"  "+ip);
                    putWrongTick(ip);
                    sum = sum + 76;
                    var s = sum & 0xff;
                    if (s < 10) {
                        s = '0' + s;
                    }
                    // console.log(s.toString(16)+ "  "+sum + "   " + sum.toString(16));                
                    data = "8b b9 00 09 03 40" + data + " " + s.toString(16);
                    //console.log(data + "  " + ip);
                    var arr = data.split(' ');

                    if (arr.length == 13) {
                        //console.log("data length is right");
                        SendToMachine(ip, data);
                    }
                }
                
            }
        }   
    } 
    catch (error) {
        console.log(error);
    }
    return false;
}

function SendToMachine(ip, data) {
    chat.server.sendControlKeys(ip, data);
}
function putTick(ip) {
    var listofip = document.getElementsByClassName("hiddenip");    
    for (i = 0; i < listofip.length; i++) {        
        if ($(listofip[i]).val() == ip) {
           // console.log($(listofip[i]).val());
            var row = $(listofip[i]).closest('tr');
           // console.log(row.find('.tick'));
            $(row).find('.tick').css("display", "block");
            $(row).find('.nottick').css("display", "none");
                      
        }            
    }
    return false;
}

function putWrongTick(ip) {
    var listofip = document.getElementsByClassName("hiddenip");
    
    for (i = 0; i < listofip.length; i++) {
        if ($(listofip[i]).val() == ip) {
           // console.log(ip+"  not done");
            var row = $(listofip[i]).closest('tr');
           // console.log(row.find('.tick'));
            $(row).find('.tick').css("display", "none");
            $(row).find('.nottick').css("display", "block");
            //var maincol = row[0].cells;
            //var text = '<img src="Images/notdone.png" height="25" width="25" class="tick"/>';
            //maincol[7].innerHTML = text;
        }
    }
    return false;
}

function RemoveTicks() {
    var listofip = document.getElementsByClassName("hiddenip");
    for (i = 0; i < listofip.length; i++) {
        var row = $(listofip[i]).closest('tr');
        //console.log(row.find('.tick'));
        $(row).find('.tick').css("display", "none");
        $(row).find('.nottick').css("display", "none");
    }
    return false;
}

function addEvent() {
    //console.log("event");
    $(".column").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110]) !== -1 ||
            // Allow: Ctrl+A
            (e.keyCode == 65 && e.ctrlKey === true) ||
            // Allow: home, end, left, right
            (e.keyCode >= 35 && e.keyCode <= 39)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)
            || (e.shiftKey && (e.keyCode >= 65 && e.keyCode <= 70)) ||
            (e.keyCode >= 65 && e.keyCode <= 70)) {
            console.log(e.keyCode);

        }
        else {
            e.preventDefault();
        }
            
    });
}
    
