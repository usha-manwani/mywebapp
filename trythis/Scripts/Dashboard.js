
    // Declare a proxy to reference the hub.

    var chat = $.connection.myHub;

chat.client.TotalCount = function (count) {
    var counts = document.getElementById("TotalMachines");
    counts.innerText = count;
    };
    $.connection.hub.start().done(function () {
        chat.server.countTotal();
    });
