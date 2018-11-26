﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication1._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="Scripts/jquery-3.3.1.js" type="text/javascript"></script>
   <script src="Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
    <!--Reference the SignalR library. -->
        <script src="Scripts/jquery.signalR-2.3.0.js"></script>
    <script src="Scripts/jquery.signalR-2.3.0.min.js"></script>
    <!--Reference the autogenerated SignalR hub script. -->
   <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' ></script>
    <!--Add script to update the page and send messages.--> 
         <script type ="text/javascript" >
             
            $(function () {
            // Declare a proxy to reference the hub. 
            var chat = $.connection.myHub;
            // Create a function that the hub can call to broadcast messages.
            chat.client.broadcastMessage = function (name, message) {
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
                    $('#discussion').append("SignalR Connected");
            });
        });
    </script>
     <style type="text/css">
        .container {
            background-color: #99CCFF;
            border: thick solid #808080;
            padding: 20px;
            margin: 20px;
        }
    </style>
    
   
</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
        <input type="text" id="message" />
        <input type="button" id="sendmessage" value="Send" />
        <input type="hidden" id="displayname" />
        <ul id="discussion">
        </ul>
          
    </div>
         <!--Reference the jQuery library. -->
         
   
    </form>
</body>
</html>
