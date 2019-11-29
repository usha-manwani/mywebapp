$(function () {
    // Declare a proxy to reference the hub. 
    var chat = $.connection.myHub;
    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        // Html encode display name and message.
        var data = message.split(",");
        var table = document.getElementById("MainContent_GridView1");
        var tbody = document.createElement("tbody");
        var tr = document.createElement("tr");
        for (j = 0; j < message.length; j++)
        // Add the message to the page. 
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').val(prompt('Enter your name: ', ''));
    // Set initial focus to message input box.  
    $('#message').focus();
    // Start the connection.

    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub. 
            chat.server.sendMessage($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment. 
            $('#message').val('').focus();
        });
    });
});
