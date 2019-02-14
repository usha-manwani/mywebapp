$(function(){
    var chat = $.connection.myHub;
    var ipAddress = "192.168.1.26";
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
        alert("connection started");
        $(document).on('click', '.toggle', function () {
            if (!$(this).next().hasClass('in')) {
                $(this).parent().children('.collapse').collapse('hide');
            }
            $(this).next().collapse('toggle');
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
            //$('[class^="displaynone"]').hide();
        });
        $(document).on("click", "#dvd", function () {
            
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 14 1e");
        });
        $(document).on("click", "#tv", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 15 1f");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target');
            $(target).show();
        });
        $(document).on("click", "#bluray", function () {
            chat.server.sendControlKeys(ipAddress, "8B B9 00 04 02 04 1a 24");
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target');
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
        $(document).on("click", "#volctrl", function () {
            
            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#sysctrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#projctrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#scrctrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#micCtrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#lightctrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
        $(document).on("click", "#mediactrl", function () {

            $('[class^="displaynone"]').hide();
            var target = $(this).attr('data-target')
            $(target).show();
        })
    })
})
