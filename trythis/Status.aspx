<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="trythis.Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/MessagesToClient.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
     <div class="divopt">                     
         <br>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
           <div>
            <a id="refresh" href="#">Refresh</a>
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
            <asp:BoundField HeaderText="Status"  DataField ="Status" />
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
