<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" 
    AutoEventWireup="true" CodeBehind="QrControlPage.aspx.cs" Inherits="WebCresij.Scan.QrControlPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style>        
        .imgsize {
            /*width: 80%;*/
            max-width:60px;
            min-width:25px;
            
        }
       
        .imgclick:active {
            -webkit-border-radius: 30%;
            -moz-border-radius: 30%;
            border-radius: 30%;
            -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            transform: translateY(1px);
        }
        .oncolor{
            -webkit-border-radius: 30%;
            -moz-border-radius: 30%;
            border-radius: 30%;
            -webkit-box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
            -moz-box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
            box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
        }
        
        .noborder{
            border:none!important;
        }
        .paddingright{
            padding-right:10%;
        }
        .imgback{
            background-color:none;
        }
        .color{
            color:greenyellow;
        }
        .coloroff{
            color:lightslategrey;
        }
        .bck{
            width:100%!important;
        }
    </style>
    <script src="../Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="bck">
         
            <div >
                <asp:Button runat="server" ID="logout" CssClass="btn btn-link paddingright" 
                Text="Logout" OnClick="logout_Click"/>
            </div>
        <div >
        <asp:LinkButton runat="server" ID="gotoFault" Text="Add New FaultInfo"
             OnClick="gotoFault_Click"></asp:LinkButton>
            </div>
    
         </div>
    <div class="clearfix"></div>
    <div class=" positionCenter noborder">
            <asp:HiddenField runat="server" ID="iptoControl" />
         <div class="row">
             <div class="col-6" style="text-align:center">
             <%--<i class="fas fa-power-off imgclick imgback" style="font-size:4rem"
                 id="syspower"></i>--%>
                <img src="../Images/greyed/sysgrey.png" id="syspower"
                    class="imgclick imgsize"/>
            </div>
            
        <div class="col-6" style="text-align:center">
           <%-- <i class="fas fa-power-off imgclick imgback"
                id="syspoweroff" style="color:red;font-size:4rem"></i>--%>
                <img src="../Images/greyed/sysgrey.png" id="syspoweroff"
                    class="imgclick imgsize"/>
            </div>
         </div>
            
       
        </div>
    <div class="clearfix"></div>
    <script type="text/javascript" >
        var ip = document.getElementById("MainContent_iptoControl").value;
        
        (function () {
            var chat = $.connection.myHub;
            chat.client.broadcastMessage = function (name, message) {                
                ip = document.getElementById("MainContent_iptoControl").value;
                if (name == ip) {
                    
                    var arraydata = message.split(",");
                    if (arraydata[3] == 'CLOSED' || arraydata[2] == 'SystemSwitchOff' || arraydata[2] == 'SystemOff') {
                        var img = document.getElementById("syspower");
                        img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $(img).removeClass('oncolor');
                    }
                    else if (arraydata[3] == 'OPEN' || arraydata[2] == 'SystemSwitchOn' || arraydata[2] == 'SystemON') {
                        var img = document.getElementById("syspower");
                       img.src = "Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png";
                        $(img).addClass('oncolor');
                        
                    }
                    else if (arraydata[2] == 'Offline' || arraydata[1] == 'Unsuccessful') {
                        var img = document.getElementById("syspower");
                        img.src = "Images/greyed/sysgrey.png";
                        $(img).removeClass('oncolor');
                    }
                }
            };
            $.connection.hub.start({ waitForPageLoad: false }).done(function () {   
                
                if (ip != "") {
                    chat.server.sendControlKeys(ip, "8B B9 00 03 05 01 09");
                }
                $(document).on("click", "#syspower", function () {
                    chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 18 22");
                });
                $(document).on("click", "#syspoweroff", function () {
                    chat.server.sendControlKeys(ip, "8B B9 00 04 02 04 18 22");
                });
            });
        })(jQuery);
        
    </script>
</asp:Content>
