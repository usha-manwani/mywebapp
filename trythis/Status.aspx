<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="trythis.Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.6.4.js" />
            <asp:ScriptReference Path="~/Scripts/jquery.signalR-2.3.0.js" />
           
          
            </Scripts>
        </asp:ScriptManagerProxy>
      <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
   <script type="text/javascript">
        var scoresHub;

        $(document).ready();
      
        $(function () {            
            // Declare a proxy to reference the hub.
            var scoresHub = $.connection.MyHub;
            debugger;
            // Create a function that the hub can call to broadcast messages.
            scoresHub.client.recieveNotification = function (dt) {
                // Add the message to the page.                
                $('id*=mytable').DataTable();
            };
            // Start the connection.
            $.connection.hub.start().done(function () {
                scoresHub.server.updateData();
            }).fail(function (e) {
                alert(e); 
            });
            $.connection.hub.start();            
        });
   

            var hub = $.connection.MyHub;
       hub.client.addGame = function (game) {
           $tablebody.empty();
           $("#<%= rptData.ClientID%>").DataTable();
            };
            $.connection.hub.start();
            

       </script>

 
    <div class="divopt">
        
           <asp:Repeater ID="rptData" runat="server">
                    <HeaderTemplate>
                        <table border="1" id ="myTable">
                            <thead>
                                <tr>
                                    <th>Location</th>
                                    <th>IP Address</th>
                                    <th>Status</th>
                                    <th>Work Status</th>
                                    <th>Timer Service</th>
                                    <th>PC Power Satus</th>
                                    <th>Projector Power Status</th>
                                    <th>Projector Used Hours</th>
                                    <th>Curtain Status</th>
                                    <th>digital Screen Status</th>
                                    <th>Light</th>
                                    <th>Media Signal</th>
                                    <th>System lock Status</th>
                                    <th>Podium Lock Status</th>
                                    <th>Class Lock Status</th>
                                    <th>temperature</th>
                                    <th>Humidity</th>
                                    <th>PM2.5(µg/m3)</th>
                                    <th>PM10(µg/m3)</th>
                                </tr>
                            </thead>
                            <tbody id ="tablebody">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr >
                            <td><%# Eval("location") %></td>
                            <td><%# Eval("CCIP") %></td>
                            <td><%# Eval("Status") %></td>
                            <td><%# Eval("PowerStatus") %></td>
                            <td><%# Eval("TimerService") %></td>
                            <td><%# Eval("ComputerPower") %></td>
                            <td><%# Eval("ProjectorPower") %></td>
                            <td><%# Eval("ProjectorUsedHour") %></td>
                            <td><%# Eval("CurtainStatus") %></td>
                            <td><%# Eval("ScreenStatus") %></td>
                            <td><%# Eval("light") %></td>
                            <td><%# Eval("MediaSignal") %></td>
                            <td><%# Eval("LockStatus") %></td>
                            <td><%# Eval("podiumLock") %></td>
                            <td><%# Eval("ClassLocked") %></td>
                            <td><%# Eval("Temperature") %></td>
                            <td><%# Eval("Humidity") %></td>
                            <td><%# Eval("PM25") %></td>
                            <td><%# Eval("PM10") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate></tbody></table></FooterTemplate>
                </asp:Repeater>
     
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
           <div>
             <%--<asp:LinkButton runat="server" ID="refresh" Text="Refresh" OnClick="LinkButton1_Click"></asp:LinkButton>--%>
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
