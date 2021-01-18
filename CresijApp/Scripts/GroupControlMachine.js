var chat;
var oldvol = 0, micoldvol = 0, wirelessoldvol = 0;
console.log(new Date());

function ConnectToHub() {
    
 chat = $.connection.myHub;
    
    chat.client.broadcastMessage = function (name, message) {
        console.log(message);
        var checkboxlist = $('.ipaddressclassname');
        if (checkboxlist.length > 0) {
            var data = message.split(',');
            if (data[0] == "offline") {
                $(checkboxlist).each(function () {
                    if ($(this).prop("value") == name) {
                        Offlinemachines($(this).closest("'.eqp-ctrl-pannel'"));
                    }
                })
            }

            if (data.indexOf("StatusData") != -1) {
                $(checkboxlist).each(function () {
                    if ($(this).prop("value") == name) {

                        if (data[2] == "Online") {
                            $(this).closest('.eqp-ctrl-pannel').find(".status-dot").prop("background-color", "green");

                        }

                        else {
                            $(this).closest('.eqp-ctrl-pannel').find(".status-dot").prop("background-color", "orange");

                        }

                        if (data[3] == "Open") {


                            this.checked = true;
                        }

                        else {

                            this.checked = false;
                        }

                        if (data[5] == "On")
                            $(this).closest('.eqp-ctrl-pannel').find(".computerclass").removeClass(".j-eqm-*").addClass("j-eqm-green");
                        else
                            $(this).closest('.eqp-ctrl-pannel').find(".computerclass").removeClass(".j-eqm-*").addClass("j-eqm-red");
                        if (data[6] == "On")
                            $(this).closest('.eqp-ctrl-pannel').find(".projectorclass").removeClass(".j-eqm-*").addClass("j-eqm-green");
                        else
                            $(this).closest('.eqp-ctrl-pannel').find(".projectorclass").removeClass(".j-eqm-*").addClass("j-eqm-red");
                        if (data[8] == "Up")
                            $(this).closest('.eqp-ctrl-pannel').find(".curtainclassicon").removeClass(".j-eqm-*").addClass("j-eqm-red");
                        else
                            $(this).closest('.eqp-ctrl-pannel').find(".curtainclassicon").removeClass(".j-eqm-*").addClass("j-eqm-green");
                        //if (data[9] == "Up")
                        //    $(this).closest('.eqp-ctrl-pannel').find(".screenclass").removeClass(".j-eqm-*").addClass("j-eqm-red");
                        //else
                        //    $(this).closest('.eqp-ctrl-pannel').find(".screenclass").removeClass(".j-eqm-*").addClass("j-eqm-green");
                        if (data[10] == "On")
                            $(this).closest('.eqp-ctrl-pannel').find(".lightclass1").removeClass(".j-eqm-*").addClass("j-eqm-green");
                        else
                            $(this).closest('.eqp-ctrl-pannel').find(".lightclass1").removeClass(".j-eqm-*").addClass("j-eqm-red");

                        if (data[11] == "laptop") {
                            $(this).closest('.eqp-ctrl-pannel').find(".signalclass").removeClass(".j-eqm-*").addClass("j-eqm-blue");
                            var icon = $(this).closest('.eqp-ctrl-pannel').find(".signalclass");
                            $(icon).find(".fa").removeClass(".fa-*").addClass("fa-laptop fa-lg");
                            $(icon).find(".mb-1").text("VGA");
                        }

                        else if (data[11] == "desktop") {
                            $(this).closest('.eqp-ctrl-pannel').find(".signalclass").removeClass(".j-eqm-*").addClass("j-eqm-blue");
                            var icon = $(this).closest('.eqp-ctrl-pannel').find(".signalclass");
                            $(icon).find(".fa").removeClass(".fa-*").addClass("fa-desktop fa-lg");
                            $(icon).find(".mb-1").text("电脑");
                        }

                        else if (data[11] == "hdmi") {
                            $(this).closest('.eqp-ctrl-pannel').find(".signalclass").removeClass(".j-eqm-*").addClass("j-eqm-blue");
                            var icon = $(this).closest('.eqp-ctrl-pannel').find(".signalclass");
                            $(icon).find(".fa").removeClass(".fa-*").addClass("fa-laptop fa-lg");
                            $(icon).find(".mb-1").text("HDMI");
                        }

                        else {
                            $(this).closest('.eqp-ctrl-pannel').find(".signalclass").removeClass(".j-eqm-*").addClass("j-eqm-blue");
                            var icon = $(this).closest('.eqp-ctrl-pannel').find(".signalclass");
                            $(icon).find(".fa").removeClass(".fa-*").addClass("fa-signal fa-lg");
                            $(icon).find(".mb-1").text("信号源");
                        }


                        if (data[15] == "On")
                            $(this).closest('.eqp-ctrl-pannel').find(".podiumlightclass").removeClass(".j-eqm-*").addClass("j-eqm-green");
                        else
                            $(this).closest('.eqp-ctrl-pannel').find(".podiumlightclass").removeClass(".j-eqm-*").addClass("j-eqm-red");
                        if (data[12] == "Unlock")
                            $(this).closest('.eqp-ctrl-pannel').find(".systemlockclass").removeClass(".j-eqm-*").addClass("j-eqm-green");
                        else
                            $(this).closest('.eqp-ctrl-pannel').find(".systemlockclass").removeClass(".j-eqm-*").addClass("j-eqm-red");

                    }
                })
            }
        }

    };

    
    chat.client.envMessage = function (name, message) {
        var ip = $("#controlip").val();
        
        
        if (name == ip) {
            $("#spanmachinestat").text("Online");
            var data = message.split(',');
            if (data[0] == "Offline") {
                OfflineSpecificmachine();
            }
            if (data.indexOf("StatusData") != -1) {
                
                if (data[3] == "Open") {
                    
                    var th = $(".systemonoff")[0];
                    
                    th.checked = true;
                    $(th).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }
                else {
                    
                    var th = $(".systemonoff")[0];
                    
                    th.checked = false;
                    $(th).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }


                if (data[5] == "On") {
                    $(".computeronoff")[0].checked = true;
                    var cm = $(".computeronoff")[0];
                    $(cm).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }

                else {
                    $(".computeronoff")[0].checked = false;
                    var cm = $(".computeronoff")[0];
                    $(cm).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                    

                if (data[6] == "On") {
                    var pj = document.getElementsByClassName("projector1")[0];
                    pj.checked = true;
                    //var pj = $(".projector1")[0];
                    $(pj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }

                else {
                    var pj = document.getElementsByClassName("projector1")[0];
                    pj.checked = false;
                    $(pj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }

                if (data[8] == "Down") {
                    $(".curtain1").find(".fa-arrow-down").parent().addClass("active");
                    $(".curtain1").find(".fa-arrow-up").parent().removeClass("active");
                    $(".curtain1").find(".fa-pause").parent().removeClass("active");
                }

                else {
                    $(".curtain1").find(".fa-arrow-down").parent().removeClass("active");
                    $(".curtain1").find(".fa-arrow-up").parent().addClass("active");
                    $(".curtain1").find(".fa-pause").parent().removeClass("active");
                }

                if (data[9] == "Down") {
                    $(".screen1").find(".fa-arrow-down").parent().addClass("active");
                    $(".screen1").find(".fa-arrow-up").parent().removeClass("active");
                    $(".screen1").find(".fa-pause").parent().removeClass("active");
                }

                else {
                    $(".screen1").find(".fa-arrow-down").parent().removeClass("active");
                    $(".screen1").find(".fa-arrow-up").parent().addClass("active");
                    $(".screen1").find(".fa-pause").parent().removeClass("active");
                }
                if (data[10] == "On") {
                    $(".lightcontrol1")[0].checked = true;
                    var lgt2 = $(".lightcontrol1")[0];
                    $(lgt2).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }

                else {
                    $(".lightcontrol1")[0].checked = false;
                    var lgt1 = $(".lightcontrol1")[0];
                    $(lgt1).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                    
                if (data[15] == "On") {
                    $(".lightcontrol2")[0].checked = true;
                    var lgt2 = $(".lightcontrol2")[0];
                    $(lgt2).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }

                else {
                    $(".lightcontrol2")[0].checked = false;
                    var lgt1 = $(".lightcontrol2")[0];
                    $(lgt1).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                    
                if (data[12] == "Unlock") {
                    $(".panellockunlock")[0].checked = true;
                    var pnlock = $(".panellockunlock")[0];
                    $(pnlock).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }

                else {
                    $(".panellockunlock")[0].checked = false;
                    var pnlock = $(".panellockunlock")[0];
                    $(pnlock).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                    

                if (data[11] == "laptop")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".notebookvga").prop("checked","checked") ;
                else if (data[11] == "desktop") {
                    
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".computersignal").prop("checked", "checked") ;
                }
                    
                else if (data[11] == "hdmi")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".notebookhdmi").prop("checked", "checked") ;
                else
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".digitaldevice").prop("checked", "checked");

                $('#voltage').text(data[18]);
                $('#powerwatt').text(data[19]+" ");

            }

            else {
                if (data[0] == "projectoron") {
                   // var pj = document.getElementsByClassName("projector1")[0];
                    $(".projector1")[0].checked = true;
                    var pj = $(".projector1")[0];
                    
                    $(pj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                   
                }
                else if (data[0] == "projectoroff"){
                    var pj = $(".projector1")[0];
                    $(".projector1")[0].checked = false;
                    $(pj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                    
                }

                if (data[0] == "computeron") {

                    $(".computeronoff").checked = true;
                    $(".computeronoff").closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }
                else if (data[0] == "computeroff") {
                    $(".computeronoff").checked = false;
                    $(".computeronoff").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                if (data[0] == "systemon") {
                    $(".systemonoff").checked = true;
                    $(".systemonoff").closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }
                else if (data[0] == "systemoff") {
                    $(".systemonoff").checked = true;
                    $(".systemonoff").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                if (data.indexOf("sound" != -1)) {
                    if (data[0] == "wiredmic") {
                        if (data[1] == "increase") {
                            console.log("current vol: " + $(".wiredmicvolume").val());
                            var vv = parseInt( $(".wiredmicvolume").val() );
                            $(".wiredmicvolume").val(vv);
                            micoldvol = vv;
                            console.log("wired volP: "+"vv: "+ vv+" "+$(".wiredmicvolume").val());
                        }
                        else {
                            $(".wiredmicvolume").val(parseInt($(".wiredmicvolume").val()) );
                            micoldvol = parseInt($(".wiredmicvolume").val()) ;
                        }
                            
                    }
                    if (data[0] == "wirelessmic") {
                        if (data[1] == "increase") {
                            $(".wirelessmicvolume").val(parseInt($(".wirelessmicvolume").val()) );
                            wirelessoldvol = parseInt($(".wirelessmicvolume").val()) ;
                        }
                        else {
                            $(".wirelessmicvolume").val(parseInt($(".wirelessmicvolume").val()) );
                            wirelessoldvol = parseInt($(".wirelessmicvolume").val()) ;
                        }
                           
                    }
                    if (data[0] == "volume") {
                        if (data[1] == "increase") {
                            $(".volume").val(parseInt($(".volume").val()));
                            oldvol = parseInt($(".volume").val()) ;
                        }
                        else {
                            $(".volume").val(parseInt($(".volume").val()));
                            oldvol = parseInt($(".volume").val()) ;
                        }
                           
                    }
                    
                }
                if (data[0] == "screen1fall") {
                    $(".screen1").find(".fa-arrow-down").parent().addClass("active");
                    $(".screen1").find(".fa-arrow-up").parent().removeClass("active");
                    $(".screen1").find(".fa-pause").parent().removeClass("active");
                    
                }
                else if(data[0] == "screen1rise"){
                    $(".screen1").find(".fa-arrow-down").parent().removeClass("active");
                    $(".screen1").find(".fa-arrow-up").parent().addClass("active");
                    $(".screen1").find(".fa-pause").parent().removeClass("active");
                    
                }

                if (data[0] == "curtain1fall") {
                    $(".curtain1").find(".fa-arrow-down").parent().addClass("active");
                    $(".curtain1").find(".fa-arrow-up").parent().removeClass("active");
                    $(".curtain1").find(".fa-pause").parent().removeClass("active");
                    
                }
                else if (data[0] == "curtain1rise"){
                    $(".curtain1").find(".fa-arrow-down").parent().removeClass("active");
                    $(".curtain1").find(".fa-arrow-up").parent().addClass("active");
                    $(".curtain1").find(".fa-pause").parent().removeClass("active");
                    
                }

                if (data[0] == "frontlighton") {
                    $(".lightcontrol1").checked = true;
                    $(".lightcontrol1").closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }
                   
                else if (data[0] == "frontlightoff") {
                    $(".lightcontrol1").checked = false;
                    $(".lightcontrol1").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                    
                else if (data[0] == "rearlighton") {
                    $(".lightcontrol2").checked = true;
                    $(".lightcontrol2").closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }
                   
                else if (data[0] == "rearlightoff") {
                    $(".lightcontrol2").checked = false;
                    $(".lightcontrol2").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                    

                if (data[0] == "signalsourcelaptop")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".notebookvga").checked = true;
                else if (data[0] == "signalsourcedesktop")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".computersignal").checked = true;
                else if (data[11] == "signalsourcedigitalstand")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".notebookhdmi").checked = true;
                else if (data[0] == "othersource")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".digitaldevice").checked = true;

                if (data[0] == "panelLocked") {
                    $(".panellockunlock")[0].checked = false;
                    var pnlock = $(".panellockunlock")[0];
                    $(pnlock).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                    
                }
                else if (data[0] == "panelUnlocked") {
                    $(".panellockunlock")[0].checked = true;
                    var pnlock = $(".panellockunlock")[0];
                    $(pnlock).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                    
                }
                if (data[0] == "PowerSupply") {
                    if (data[1] == "projectorpower") {
                        console.log("projector inner: " + $('input[name="powercheck"]').closest('.powerspan').innerHTML);
                        if (data[2] == "projectorpoweroff") {
                            var powerproj = $('input[name="powercheck"]').closest('.powerspan').find(".powerprojector");
                            $(powerproj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                            $(powerproj).checked = false;
                        }
                        else {
                            var powerproj = $('input[name="powercheck"]').closest('.powerspan').find(".powerprojector");
                            $(powerproj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                            $(powerproj).checked = true;
                        }
                    }
                    else if (data[1] == "computerpower") {
                        if (data[2] == "computerpoweroff") {

                            var powercomp = $('input[name="powercheck"]').closest('.powerspan').find(".powercomputer");
                            $(powercomp).checked = false;
                            $(powercomp).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                        }
                        else {
                            var powercomp = $('input[name="powercheck"]').closest('.powerspan').find(".powercomputer");
                            $(powercomp).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                            $(powercomp).checked = true;
                        }
                    }
                    else if (data[1] == "soundpower") {
                        if (data[2] == "soundpoweroff") {
                            var powersound = $('input[name="powercheck"]').closest('.powerspan').find(".powervolume");
                            $(powersound).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                            $(powersound).checked = false;
                        }
                        else {
                            var powersound = $('input[name="powercheck"]').closest('.powerspan').find(".powervolume");
                            $(powersound).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                            $(powersound).checked = true;
                        }

                            
                    }
                    else if (data[1] == "otherpower") {
                        if (data[2] == "otherpoweroff") {

                            var otherpower = $('input[name="powercheck"]').closest('.powerspan').find(".powerother");
                            $(otherpower).check = false;
                            $(otherpower).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                        }
                        else {
                            var otherpower = $('input[name="powercheck"]').closest('.powerspan').find(".powerother");
                            $(otherpower).check = true;
                            $(otherpower).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                        }

                            
                    }
                    else if (data[1] == "fullpower") {
                        if (data[2] == "fullpoweroff") {
                            $('input[name="powercheck"]').each(function () {
                                $(this).checked = false;
                                $(this).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                            })
                            
                        }
                        else {
                            $('input[name="powercheck"]').each(function () {
                                $(this).checked = true;
                                $(this).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                            })
                        } 
                    }
                }
                
                
            }
        }
    };
    chat.client.machineCounts = function (counts) {
        var count = counts.split(',');       
        $("#onlinedevicescount").text(count[0]);
        $("#offlinedevicecount").text(count[1]);
        $("#totaldevicescount").text(count[2]);
    }
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
        chat.server.countMachinesAll(1);
        var checkboxlist = $('.ipaddressclassname');
        $(checkboxlist).each(function () {
            var ips = $(this).prop("value");
            chat.server.sendControlKeys(ips, "FF FE 09 00 FF FF FF FF A0 A1 A2 A3");
        });
        var ip = $("#controlip").val();
        console.log("connection to signalR done ");
        //system control
       
        chat.server.sendControlKeys(ip, "FF FE 09 00 FF FF FF FF A0 A1 A2 A3");
        $(".systemonoff").on("click", function () {
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 37 01 01 FF FF FF FF A0 A1 A2 A3");//system on
            else
                chat.server.sendControlKeys(ip, "FF FE 37 01 00 FF FF FF FF A0 A1 A2 A3");//system off
        });
        $(".computeronoff").on("click", function () {

            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 33 01 01 FF FF FF FF A0 A1 A2 A3");//computer on
            else
                chat.server.sendControlKeys(ip, "FF FE 33 01 00 FF FF FF FF A0 A1 A2 A3");//computer off
        });
        $(".panellockunlock").on("click", function () {
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 42 01 00 FF FF FF FF A0 A1 A2 A3");//unlock
            else
                chat.server.sendControlKeys(ip, "FF FE 42 01 02 FF FF FF FF A0 A1 A2 A3");//lock
        });

        //sound control
        $(".volume").on("change", function () {
            var newvol = $(this).val();
            if (oldvol > newvol) {
                oldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 03 02 FF FF FF FF A0 A1 A2 A3");//decrease vol
            }
            else if (oldvol < newvol) {
                oldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 03 01 FF FF FF FF A0 A1 A2 A3");//increase vol
            }

        });
        $(".wiredmicvolume").on("change", function () {
            
            var newvol = $(this).val();
            if (micoldvol > newvol) {
                micoldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 01 02 FF FF FF FF A0 A1 A2 A3");//decrease vol
            }
            else if (micoldvol < newvol) {
                micoldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 01 01 FF FF FF FF A0 A1 A2 A3");//increase vol
            }

        });
        $(".wirelessmicvolume").on("change", function () {
            var newvol = $(this).val();
            if (wirelessoldvol > newvol) {
                wirelessoldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 02 02 FF FF FF FF A0 A1 A2 A3");//decrease vol
            }
            else if (wirelessoldvol < newvol) {
                wirelessoldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 02 01 FF FF FF FF A0 A1 A2 A3");//increase vol
            }

        });

        //screen control
        $(".screen1").on("click", function () {
            if ($(this).find('.fa-arrow-up').length != 0) {
                chat.server.sendControlKeys(ip, "FF FE 35 01 02 FF FF FF FF A0 A1 A2 A3");//screen up
            }
            else if ($(this).find('.fa-pause').length != 0) {
                chat.server.sendControlKeys(ip, "");//screen pause not done
            }
            else if ($(this).find('.fa-arrow-down').length != 0) {
                chat.server.sendControlKeys(ip, "FF FE 35 01 01 FF FF FF FF A0 A1 A2 A3");//screen down
            }

        });
        //$(".screen2").on("click", function () {
        //    if ($(this).find('.fa-arrow-up').length != 0) {
        //        chat.server.sendControlKeys(ip, "FF FE 35 01 02 FF FF FF FF A0 A1 A2 A3");//screen up
        //    }
        //    else if ($(this).find('.fa-pause').length != 0) {
        //        chat.server.sendControlKeys(ip, "");//screen pause not done
        //    }
        //    else if ($(this).find('.fa-arrow-down').length != 0) {
        //        chat.server.sendControlKeys(ip, "FF FE 35 01 02 FF FF FF FF A0 A1 A2 A3");//screen down
        //    }

        //});

        //light control
        $('.lightcontrol1').on("click", function () {
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 46 02 01 01 FF FF FF FF A0 A1 A2 A3");// front light on
            else
                chat.server.sendControlKeys(ip, "FF FE 46 02 01 02 FF FF FF FF A0 A1 A2 A3");//front light off

        });
        $('.lightcontrol2').on("click", function () {
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 46 02 02 01 FF FF FF FF A0 A1 A2 A3");//rear light on
            else
                chat.server.sendControlKeys(ip, "FF FE 46 02 02 02 FF FF FF FF A0 A1 A2 A3");//rear light off

        });

        //projector control
        $(".projector1").on("click", function () {
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 39 01 01 FF FF FF FF A0 A1 A2 A3");//projector on
            else
                chat.server.sendControlKeys(ip, "FF FE 39 01 02 FF FF FF FF A0 A1 A2 A3");//projector off

        });
        $(".projector2").on("click", function () { //not done
            //if ($(this).is(':checked'))
               // chat.server.sendControlKeys(ip, "FF FE 39 01 01 FF FF FF FF A0 A1 A2 A3");//projector2 on
            //else
               // chat.server.sendControlKeys(ip, "FF FE 39 01 02 FF FF FF FF A0 A1 A2 A3");//projector2 off

        });

        //power control
        $("#powerproj").on("click", function () { //not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 12 02 01 01 FF FF FF FF A0 A1 A2 A3");//power projector on
            else
                chat.server.sendControlKeys(ip, "FF FE 12 02 01 00 FF FF FF FF A0 A1 A2 A3");//power projector off

        });
        $(".powercomputer").on("click", function () { //not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 12 02 02 01 FF FF FF FF A0 A1 A2 A3");//power computer on
            else
                chat.server.sendControlKeys(ip, "FF FE 12 02 02 00 FF FF FF FF A0 A1 A2 A3");//power computeroff off
        });
        $(".powervolume").on("click", function () {//not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 12 02 03 01 FF FF FF FF A0 A1 A2 A3");//power sound on
            else
                chat.server.sendControlKeys(ip, "FF FE 12 02 03 00 FF FF FF FF A0 A1 A2 A3");//power sound off
        });
        $('.powerother').on("click", function () {//not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 12 02 04 01 FF FF FF FF A0 A1 A2 A3");//power other on
            else
                chat.server.sendControlKeys(ip, "FF FE 12 02 04 00 FF FF FF FF A0 A1 A2 A3");//power other off

        });

        //curtain control
        $(".curtain1").on("click", function () { //not done
            if ($(this).find('.fa-arrow-up').length != 0) {
                chat.server.sendControlKeys(ip, "FF FE 32 01 02 FF FF FF FF A0 A1 A2 A3");//curtain open
            }
            else if ($(this).find('.fa-pause').length != 0) {
                chat.server.sendControlKeys(ip, "");//curtain pause
            }
            else if ($(this).find('.fa-arrow-down').length != 0) {
                chat.server.sendControlKeys(ip, "FF FE 32 01 01 FF FF FF FF A0 A1 A2 A3");//curtain close
            }

        });
        //$(".curtain2").on("click", function () { //not done
        //    if ($(this).find('.fa-arrow-up').length != 0) {
        //        chat.server.sendControlKeys(ip, "FF FE 35 01 02 FF FF FF FF A0 A1 A2 A3");//curtain open
        //    }
        //    else if ($(this).find('.fa-pause').length != 0) {
        //        chat.server.sendControlKeys(ip, "");//curtain pause
        //    }
        //    else if ($(this).find('.fa-arrow-down').length != 0) {
        //        chat.server.sendControlKeys(ip, "FF FE 35 01 02 FF FF FF FF A0 A1 A2 A3");//curtain close
        //    }

        //});

        //AC Control
        $('.controlAc1').on("click", function () {//not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "");//ac on
            else
                chat.server.sendControlKeys(ip, "");//ac off

        });
        $('.controlAc2').on("click", function () {//not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "");//ac on
            else
                chat.server.sendControlKeys(ip, "");//ac off

        });
        $('.controlAc3').on("click", function () {//not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "");//ac on
            else
                chat.server.sendControlKeys(ip, "");//ac off

        });
        $('.controlAc4').on("click", function () {//not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "");//ac on
            else
                chat.server.sendControlKeys(ip, "");//ac off

        });

        //signal cource control
        $("input[name='c001-2']").on("change", function () { //partially done, need to do more
            if ($(this).hasClass('notebookvga'))
                chat.server.sendControlKeys(ip, "FF FE 48 01 02 FF FF FF FF A0 A1 A2 A3"); // laptop
            else if ($(this).hasClass('notebookhdmi'))
                chat.server.sendControlKeys(ip, "FF FE 48 01 03 FF FF FF FF A0 A1 A2 A3");
            else if ($(this).hasClass('computersignal'))
                chat.server.sendControlKeys(ip, "FF FE 48 01 01 FF FF FF FF A0 A1 A2 A3"); //desktop
            else if ($(this).hasClass('digitaldevice'))
                chat.server.sendControlKeys(ip, "FF FE 48 01 03 FF FF FF FF A0 A1 A2 A3"); //digital device
        });

        $('.batchbootup').on("click", function () {
            var iplist = [];
            $('input[name="classipAddress"]:checked').each(function () {
               iplist.push($(this).val());
            })
            for (i = 0; i < iplist.length; i++)
                chat.server.sendControlKeys(iplist[i], "FF FE 37 01 01 FF FF FF FF A0 A1 A2 A3");
        });
        $('.batchshutdown').on("click", function () {
            var iplist = [];
            $('input[name="classipAddress"]:checked').each(function () {
                iplist.push($(this).val());
            })
            for (i = 0; i < iplist.length; i++)            
                chat.server.sendControlKeys(iplist[i], "FF FE 37 01 00 FF FF FF FF A0 A1 A2 A3");

        }); 
    });
    
    //$.connection.hub.start({ waitForPageLoad: false }).done(function () {
    //    console.log("connection doen ");
    //    //$(".projectorclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');
    //    //    if ($(this).hasClass("j-eqm-green"))
    //    //        chat.server.sendControlKeys(ip, "FF FE 34 01 00 FF FF FF FF A0 A1 A2 A3");
    //    //    else //if ($(this).hasClass("j-eqm-red"))
    //    //        chat.server.sendControlKeys(ip, "FF FE 34 01 01 FF FF FF FF A0 A1 A2 A3");
    //    //})
       
    //    //$(".computerclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');
    //    //    if ($(this).hasClass("j-eqm-green"))
    //    //        chat.server.sendControlKeys(ip, "FF FE 33 01 00 FF FF FF FF A0 A1 A2 A3");
    //    //    else //if ($(this).hasClass("j-eqm-red"))
    //    //        chat.server.sendControlKeys(ip, "FF FE 33 01 01 FF FF FF FF A0 A1 A2 A3");
    //    //});
    //    //$(".volumeclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');
    //    //    if ($(this).hasClass("j-eqm-green"))
    //    //        chat.server.sendControlKeys(ip, "FF FE 33 01 00 FF FF FF FF A0 A1 A2 A3");
    //    //    else //if ($(this).hasClass("j-eqm-red"))
    //    //        chat.server.sendControlKeys(ip, "FF FE 33 01 01 FF FF FF FF A0 A1 A2 A3");
    //    //});
    //    //$(".projectorclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');

    //    //});
    //    //$(".signalclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');

    //    //});
    //    //$(".systemlockclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');

    //    //});
    //    //$(".lightclass1").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');

    //    //});
    //    //$(".classroomcurtainsclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');

    //    //});
    //    //$(".acclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');

    //    //});
    //    //$(".podiumlightclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');

    //    //});
    //    //$(".podiumcurtainclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');

    //    //});
    //    //$(".freshairclass").on("click", function () {
    //    //    var ip = $(this).closest('.eqp-ctrl-pannel').find('input[name="classipAddress"]').prop('value');
    //    //    chat.server.sendControlKeys(ip, "FF FE 37 01 01 FF FF FF FF A0 A1 A2 A3");
    //    //});
    //    //$('.ipaddressclassname').on("click", function () {
    //    //    var ip = $(this).prop('value');
    //    //    if ($(this).is(':checked'))
    //    //        chat.server.sendControlKeys(ip, "FF FE 37 01 01 FF FF FF FF A0 A1 A2 A3");
    //    //    else //if ($(this).hasClass("j-eqm-red"))
    //    //        chat.server.sendControlKeys(ip, "FF FE 37 01 00 FF FF FF FF A0 A1 A2 A3");
            
    //    //});
        

    //});
}
ConnectToHub();

function ClickHtml1() {
    
     console.log("assishtml 1");
     console.log(document.getElementsByClassName("assistdivclass")[0]);
    var div2 = document.getElementsByClassName("envdivclass")[0];
     
    div2.style.display = "none";
     var div1 = document.getElementsByClassName("assistdivclass")[0];
    div1.style.display = "block";
     

}

function ClickHtml2() {
    
    console.log("assishtml 2");
    console.log(document.getElementsByClassName("envdivclass")[0])
    var div2 = document.getElementsByClassName("envdivclass")[0];
    div2.style.display = "block";
    var div1 = document.getElementsByClassName("assistdivclass")[0];
    div1.style.display = "none";


}
function GetStatus() {

    
}

function Offlinemachines(item){

    $(item).find(".status-dot").prop("background-color", "red");
    $(item).find(".ipaddressclassname").checked = false;
    $(item).find(".computerclass").removeClass(".j-eqm-*").addClass("j-eqm-gray");
    $(item).find(".projectorclass").removeClass(".j-eqm-*").addClass("j-eqm-gray");
    $(item).find(".curtainclassicon").removeClass(".j-eqm-*").addClass("j-eqm-gray");
    $(item).find(".signalclass").removeClass(".j-eqm-*").addClass("j-eqm-gray");
    $(item).find(".podiumlightclass").removeClass(".j-eqm-*").addClass("j-eqm-gray");
    $(item).find(".systemlockclass").removeClass(".j-eqm-*").addClass("j-eqm-gray");
}

function OfflineSpecificmachine(item) {


    $("input:checkbox[name=systemonoff]").checked = false;
    $("input:checkbox[name=systemonoff]").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');

    $(".computeronoff").checked = false;
    $(".computeronoff").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');

    $(".panellockunlock").checked = false;
    $(".panellockunlock").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
    $(".projector1").checked = false;
    $(".projector1").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
    $('input[name="c001-2"]').prop("checked", false);

    $('input[name="powercheck"]').each(function () {
        $(this).checked = false;
        $(this).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
    });

    (".lightcontrol1").checked = false;
    $(".lightcontrol1").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');

    (".lightcontrol1").checked = false;
    $(".lightcontrol1").closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');

    $(".screen1").find(".fa-arrow-down").parent().removeClass("active");
    $(".screen1").find(".fa-arrow-up").parent().removeClass("active");
    $(".screen1").find(".fa-pause").parent().addClass("active");

    $(".curtain1").find(".fa-arrow-down").parent().removeClass("active");
    $(".curtain1").find(".fa-arrow-up").parent().removeClass("active");
    $(".curtain1").find(".fa-pause").parent().addClass("active");
    $(".volume").val(0);
    $(".wirelessmicvolume").val(0);
    $(".wiredmicvolume").val(0) ;
}