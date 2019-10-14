<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="testapp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
<script src="Scripts/jquery.signalR-2.4.1.js"></script>
<script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
<script src="http://localhost:8080/signalr/hubs"></script>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
    <script>
    $.connection.hub.url = "http://localhost:8080/signalr";
    var chat = $.connection.serverHub;
    chat.client.addMessage = function (name, message) {
        // Html encode display name and message.
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        $('#discussion').append('<li><strong>' + encodedName
            + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</li>');
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').val(prompt('Enter your name:', ''));
    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            // Call the Send method on the hub.
            chat.server.send($('#displayname').val(), $('#message').val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();
        });
    });
</script>
</html>
