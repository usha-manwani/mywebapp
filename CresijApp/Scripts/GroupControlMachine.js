var chat;
console.log("group control");
function ConnectToHub() {
    
 chat = $.connection.myHub;
    
    chat.client.broadcastMessage = function (name, message) {
        console.log(message);
        var checkboxlist = $('.ipaddressclassname');
        var data = message.split(',');
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
                    if (data[8] == "On")
                        $(this).closest('.eqp-ctrl-pannel').find(".podiumcurtainclass").removeClass(".j-eqm-*").addClass("j-eqm-green");
                    else
                        $(this).closest('.eqp-ctrl-pannel').find(".podiumcurtainclass").removeClass(".j-eqm-*").addClass("j-eqm-red");
                    if (data[10] == "On")
                        $(this).closest('.eqp-ctrl-pannel').find(".lightclass1").removeClass(".j-eqm-*").addClass("j-eqm-green");
                    else
                        $(this).closest('.eqp-ctrl-pannel').find(".lightclass1").removeClass(".j-eqm-*").addClass("j-eqm-red");
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
       

    };

    var oldvol = 0, micoldvol = 0, wirelessoldvol = 0;
    chat.client.envMessage = function (name, message) {
        var ip = $("#controlip").val();
        console.log(ip);
        if (name == ip) {
            var data = message.split(',');
            console.log("index of status data : " + data.indexOf("StatusData") != -1);
            if (data.indexOf("StatusData") != -1) {
                
                if (data[3] == "Open") {
                    console.log("system on of : " + $("input:checkbox[name=systemonoff]"));
                    var th = $("input:checkbox[name=systemonoff]");
                    console.log("this : " + th[0]);
                    th[0].checked = true;
                    $(th[0]).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }
                else {
                    console.log("system on of : " + $("input:checkbox[name=systemonoff]"));
                    var th = $("input:checkbox[name=systemonoff]");
                    console.log("this : " + th[0]);
                    th[0].checked = false;
                    $(th[0]).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
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
                    $(".projector1")[0].checked = true;
                    var pj = $(".projector1")[0];
                    $(pj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }

                else {
                    $(".projector1")[0].checked = false;
                    var pj = $(".projector1")[0];
                    $(pj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                    
                if (data[9] == "Off") {
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
                    console.log("desktop html :" + $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".computersignal").is(':checked'));
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".computersignal").prop("checked", "checked") ;
                }
                    
                else if (data[11] == "hdmi")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".notebookhdmi").prop("checked", "checked") ;
                else
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".digitaldevice").prop("checked", "checked") ;

            }

            else {
                if (data[0] == "projectoron") {
                    $(".projector1")[0].checked = true;
                    var pj = $(".projector1")[0];
                    $(pj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }
                else {
                    $(".projector1")[0].checked = false;
                    var pj = $(".projector1")[0];
                    $(pj).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }

                if (data[0] == "computeron") $(".computeronoff").checked = true;
                else $(".computeronoff").checked = false;
                if (data[3] == "systemon") $(".systemonoff").checked = true;
                else $(".systemonoff").checked = true;
                if (data.indexOf("sound" != -1)) {
                    if (data[0] == "wiredmic") {
                        if (data[1] == "increase") {
                            $(".wiredmicvolume").val($(".wiredmicvolume").val() + 10);

                        }
                        else
                            $(".wiredmicvolume").val($(".wiredmicvolume").val() - 10);
                    }
                    if (data[0] == "wirelessmic") {
                        if (data[1] == "increase") {
                            $(".wirelessmicvolume").val($(".wirelessmicvolume").val() + 10);

                        }
                        else
                            $(".wirelessmicvolume").val($(".wirelessmicvolume").val() - 10);
                    }
                    if (data[0] == "volume") {
                        if (data[1] == "increase") {
                            $(".volume").val($(".volume").val() + 10);

                        }
                        else
                            $(".volume").val($(".volume").val() - 10);
                    }
                }
                if (data[0] == "screen1fall") {
                    $(".screen1").find(".fa-arrow-down").parent().addClass("active");
                    $(".screen1").find(".fa-arrow-up").parent().removeClass("active");
                    $(".screen1").find(".fa-pause").parent().removeClass("active");
                }
                else {
                    $(".screen1").find(".fa-arrow-down").parent().removeClass("active");
                    $(".screen1").find(".fa-arrow-up").parent().addClass("active");
                    $(".screen1").find(".fa-pause").parent().removeClass("active");
                }

                if (data[0] == "screen2fall") {
                    $(".screen2").find(".fa-arrow-down").parent().addClass("active");
                    $(".screen2").find(".fa-arrow-up").parent().removeClass("active");
                    $(".screen2").find(".fa-pause").parent().removeClass("active");
                }
                else {
                    $(".screen2").find(".fa-arrow-down").parent().removeClass("active");
                    $(".screen2").find(".fa-arrow-up").parent().addClass("active");
                    $(".screen2").find(".fa-pause").parent().removeClass("active");
                }

                if (data[0] == "frontlighton")
                    $(".lightcontrol1").checked = true;
                else if (data[0] == "frontlightoff")
                    $(".lightcontrol1").checked = false;
                else if (data[0] == "rearlighton")
                    $(".lightcontrol2").checked = true;
                else
                    $(".lightcontrol2").checked = false;

                if (data[0] == "signalsourcelaptop")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".notebookvga").checked = true;
                else if (data[0] == "signalsourcedesktop")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".computersignal").checked = true;
                else if (data[11] == "signalsourcedigitalstand")
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".notebookhdmi").checked = true;
                else
                    $('input[name="c001-2"]').closest('.digitaldevicesgroup').find(".digitaldevice").checked = true;

                if (data[0] == "panelLocked") {
                    $(".panellockunlock")[0].checked = true;
                    var pnlock = $(".panellockunlock")[0];
                    $(pnlock).closest('.jf-12').find(".j-status-light-sm").removeClass('light-green').addClass('light-red');
                }
                else {
                    $(".panellockunlock")[0].checked = false;
                    var pnlock = $(".panellockunlock")[0];
                    $(pnlock).closest('.jf-12').find(".j-status-light-sm").removeClass('light-red').addClass('light-green');
                }

            }
        }
    };
    $.connection.hub.start({ waitForPageLoad: false }).done(function () {
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
            $(".wiredmicvolume").val($(".wiredmicvolume").val() + 10);
            var newvol = $(this).val();
            if (oldvol > newvol) {
                oldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 01 02 FF FF FF FF A0 A1 A2 A3");//decrease vol
            }
            else if (oldvol < newvol) {
                oldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 01 01 FF FF FF FF A0 A1 A2 A3");//increase vol
            }

        });
        $(".wirelessmicvolume").on("change", function () {
            var newvol = $(this).val();
            if (oldvol > newvol) {
                oldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 02 02 FF FF FF FF A0 A1 A2 A3");//decrease vol
            }
            else if (oldvol < newvol) {
                oldvol = newvol;
                chat.server.sendControlKeys(ip, "FF FE 49 02 02 01 FF FF FF FF A0 A1 A2 A3");//increase vol
            }

        });

        //screen control
        $(".screen1").on("click", function () {
            if ($(this).find('.fa-arrow-up').length != 0) {
                chat.server.sendControlKeys(ip, "FF FE 32 01 02 FF FF FF FF A0 A1 A2 A3");//screen up
            }
            else if ($(this).find('.fa-pause').length != 0) {
                chat.server.sendControlKeys(ip, "");//screen pause not done
            }
            else if ($(this).find('.fa-arrow-down').length != 0) {
                chat.server.sendControlKeys(ip, "FF FE 32 01 02 FF FF FF FF A0 A1 A2 A3");//screen down
            }

        });
        $(".screen2").on("click", function () {
            if ($(this).find('.fa-arrow-up').length != 0) {
                chat.server.sendControlKeys(ip, "FF FE 35 01 02 FF FF FF FF A0 A1 A2 A3");//screen up
            }
            else if ($(this).find('.fa-pause').length != 0) {
                chat.server.sendControlKeys(ip, "");//screen pause not done
            }
            else if ($(this).find('.fa-arrow-down').length != 0) {
                chat.server.sendControlKeys(ip, "FF FE 35 01 02 FF FF FF FF A0 A1 A2 A3");//screen down
            }

        });

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
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "FF FE 39 01 01 FF FF FF FF A0 A1 A2 A3");//projector2 on
            else
                chat.server.sendControlKeys(ip, "FF FE 39 01 02 FF FF FF FF A0 A1 A2 A3");//projector2 off

        });

        //power control
        $(".powerprojector").on("click", function () { //not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "");//power projector on
            else
                chat.server.sendControlKeys(ip, "");//power projector off

        });
        $(".powercomputer").on("click", function () { //not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "");//power computer on
            else
                chat.server.sendControlKeys(ip, "");//power computeroff off
        });
        $(".powervolume").on("click", function () {//not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "");//power sound on
            else
                chat.server.sendControlKeys(ip, "");//power sound off
        });
        $('.powerother').on("click", function () {//not done
            if ($(this).is(':checked'))
                chat.server.sendControlKeys(ip, "");//power other on
            else
                chat.server.sendControlKeys(ip, "");//power other off

        });

        //curtain control
        $(".curtain1").on("click", function () { //not done
            if ($(this).find('.fa-arrow-up').length != 0) {
                chat.server.sendControlKeys(ip, "");//curtain open
            }
            else if ($(this).find('.fa-pause').length != 0) {
                chat.server.sendControlKeys(ip, "");//curtain pause
            }
            else if ($(this).find('.fa-arrow-down').length != 0) {
                chat.server.sendControlKeys(ip, "");//curtain close
            }

        });
        $(".curtain2").on("click", function () { //not done
            if ($(this).find('.fa-arrow-up').length != 0) {
                chat.server.sendControlKeys(ip, "");//curtain open
            }
            else if ($(this).find('.fa-pause').length != 0) {
                chat.server.sendControlKeys(ip, "");//curtain pause
            }
            else if ($(this).find('.fa-arrow-down').length != 0) {
                chat.server.sendControlKeys(ip, "");//curtain close
            }

        });

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
    //    //$('.batchbootup').on("click", function () {
    //    //    var iplist = [];
    //    //    $('input[name="classipAddress"]:checked').each(function () {
    //    //       iplist.push($(this).val());
    //    //    })
    //    //    for (i = 0; i < iplist.length; i++)
    //    //        chat.server.sendControlKeys(iplist[i], "FF FE 37 01 01 FF FF FF FF A0 A1 A2 A3");

    //    //});
    //    //$('.batchshutdown').on("click", function () {
    //    //    var iplist = [];
    //    //    $('input[name="classipAddress"]:checked').each(function () {
    //    //        iplist.push($(this).val());
    //    //    })
    //    //    for (i = 0; i < iplist.length; i++)            
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