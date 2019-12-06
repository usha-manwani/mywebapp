
var chat = $.connection.myHub;
$.connection.hub.start({ waitForPageLoad: false }).done(function () {
    console.log("connection with server established");
    $(document).on("click", "#ContentPlaceHolder1_childmastercontent_Btnon", function () {
        var data = document.getElementById("ContentPlaceHolder1_childmastercontent_ipadd").value;
        var ip = data.split(',');
        for (i = 0; i < ip.length; i++) {
            chat.server.sendControlKeys(ip[i], "8B B9 00 04 05 02 1E 29");
        }
    });
    $(document).on("click", "#ContentPlaceHolder1_childmastercontent_BtnOff", function () {
        var data = document.getElementById("ContentPlaceHolder1_childmastercontent_ipadd").value;
        var ip = data.split(',');
        for (i = 0; i < ip.length; i++) {
            chat.server.sendControlKeys(ip[i], "8B B9 00 04 05 02 1F 2A");
        }
    });
    $(document).on("click", "#ContentPlaceHolder1_childmastercontent_BtnLock", function () {
        var data = document.getElementById("ContentPlaceHolder1_childmastercontent_ipadd").value;
        var ip = data.split(',');
        for (i = 0; i < ip.length; i++) {
            chat.server.sendControlKeys(ip[i], "8B B9 00 04 02 04 2c 36");
        }
    });
    $(document).on("click", "#ContentPlaceHolder1_childmastercontent_BtnUnlock", function () {
        var data = document.getElementById("ContentPlaceHolder1_childmastercontent_ipadd").value;
        var ip = data.split(',');
        for (i = 0; i < ip.length; i++) {
            chat.server.sendControlKeys(ip[i], "8B B9 00 04 02 04 2d 37");
        }
    });
    
    
});




