$(function () {
    // Declare a proxy to reference the hub. 
    var chat = $.connection.myHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message. 
        var tab = document.getElementById("MainContent_GridView1");
        for (i = 0; i < tab.rows.length; i++) {
            var cellIp = tab.rows[i].cells[1];
            if (cellIp.innerHTML == name) {
                var arraydata = message.split(',');
                if (arraydata.length > 15) {
                    for (j = 2; j < arraydata.length - 1; j++) {
                        tab.rows[i].cells[j].innerHTML = arraydata[j];
                    }
                }
                else {
                    tab.rows[i].cells[11].innerHTML = arraydata[2];
                }
            } 
        }
    };
    $.connection.hub.start().done(function () {
        $('#refresh').click(function () {
            //Call the Send method on the hub.
            chat.server.sendData();            
        });
    });
});