<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="trythis.Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/jquery.signalR-2.3.0.js"></script>
    
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script>
        var scoresHub;

        $(document).ready(DocReady);

        // ---- Doc Ready -------------------------------------------

        function DocReady()
        {
            $("#ButtonPostScore").click(PostScoreToServer);     // hook up button click

            // use a global variable to reference the hub. 
            scoresHub = $.connection.scoresHub;

            // supply the hub with a client function it can call
            scoresHub.client.SendMessageToClient = HandleMessageFromServer;

            $.connection.hub.start();   // start the local hub
        }

        // ---- Post Score to Server ------------------------------------

        function PostScoreToServer(Player, Hole, Score)
        {
            var Player = $("#DDLPlayer").val();
            var Hole = $("#DDLHole").val();
            var Score = $("#DDLScore").val();

            scoresHub.server.postScoreToServer(Player, Hole, Score);
        }

        // ---- Handle Message From Server -------------------------------

        function HandleMessageFromServer(Player, Hole, Score)
        {
            // get the correct table row
            var tableRow = $("#GridViewScores td").filter(function ()
            {
                return $(this).text() == Player;
            }).closest("tr");

            // update the hole with the score
            tableRow.find('td:eq(' + Hole + ')').html(Score);
        }

    </script>
    <div class="divopt">
        
     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
           <div>
             <asp:LinkButton runat="server" ID="refresh" Text="Refresh" OnClick="LinkButton1_Click"></asp:LinkButton>
        </div>
        
        
           
    <asp:GridView ID="GridView1" runat="server" Visible="true" Font-Size="Small" ViewStateMode="Enabled" EmptyDataRowStyle-BackColor="Black"
        EmptyDataText="--" RowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="White" AutoGenerateColumns="false">
        <HeaderStyle BackColor="PaleTurquoise" Font-Bold="false" HorizontalAlign="Center" />
        <rowstyle backcolor="LightCyan"  
           forecolor="black"
           font-italic="false" Height="50" />

        <alternatingrowstyle backcolor="White"  
          forecolor="black"
          font-italic="false" />
        <Columns>
           
            <asp:BoundField HeaderText="ClassName" DataField="location" />
            <asp:BoundField HeaderText="IP Address" DataField="CCIP" />
            <asp:BoundField HeaderText="Status"  DataField ="Status"  />
            <asp:BoundField HeaderText="Work Status" DataField="PowerStatus" />
            <asp:BoundField HeaderText="Timer Service" DataField="TimerService" />
            <asp:BoundField HeaderText ="PC Power Satus" DataField="ComputerPower" />
            <asp:BoundField HeaderText="Projector Power Status" DataField="ProjectorPower" />
            <asp:BoundField HeaderText="Projector Used Hours" DataField="ProjectorUsedHour" />
            <asp:BoundField HeaderText="Curtain Status" DataField="CurtainStatus" />
            <asp:BoundField HeaderText="digital Screen Status" DataField="ScreenStatus" />
            <asp:BoundField HeaderText="Light" DataField="light" />
            <asp:BoundField HeaderText="Media Signal" DataField="MediaSignal" />
            <asp:BoundField HeaderText="System lock Status" DataField="LockStatus" />
            <asp:BoundField HeaderText="Podium Lock Status" DataField="podiumLock" />
            <asp:BoundField HeaderText="Class Lock Status" DataField="ClassLocked" />
            <asp:BoundField HeaderText="temperature" DataField="Temperature" />
            <asp:BoundField HeaderText="Humidity" DataField="Humidity" />
            <asp:BoundField HeaderText="PM2.5(µg/m3)" DataField="PM25" />
            <asp:BoundField HeaderText="PM10(µg/m3)" DataField="PM10" />
                
        </Columns>
    </asp:GridView>
        
       </ContentTemplate>
          
            
    </asp:UpdatePanel>
       
         </div>
</asp:Content>
