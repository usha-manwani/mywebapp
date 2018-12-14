﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="CresijWeb.Status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script src="Scripts/jquery.signalR-2.4.0.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
     <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' ></script> 
    
    <script src="SignalRHub/testScript.js"></script>
    <div class="row">
          <div class="col-lg-9 main-chart">
            <!--CUSTOM CHART START -->
            <div class="border-head">
              <h3>Status</h3>
            </div>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>
                           
                    <div class=" row" style=" padding-right:20px">
                        <div class="panel-heading col-md-8" style="color:white">
                             Status:
                        </div>
                        <div class="col-md-4" style="display:flex; justify-content:flex-end">
                            <%--<input type="image" src="Images/refresh.png"  id=" refresh" height="40" width="40" />--%>
                            
                         <a id="refresh" href="#" style="float:right; color:white">
                             <image src="Images/refresh.png" height="40" width="40" alt="Refresh"></image>
                         </a>
                   </div>
                        </div>
                   
                    <div class="panel-body row" style=" padding-right:20px">
                            <div class="table-responsive col-md-12">
                <asp:GridView ID="GridView1" runat="server" Font-Size="Small" ViewStateMode="Enabled" EmptyDataRowStyle-BackColor="Black"
                    EmptyDataText="NO Device" RowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="White" AutoGenerateColumns="false">
                    <HeaderStyle BackColor="PaleTurquoise" Font-Bold="false" HorizontalAlign="Center" CssClass="table table-striped table-bordered table-hover" />
        <rowstyle backcolor="LightCyan"  
           forecolor="black"
           font-italic="false" Height="50"  />

        <alternatingrowstyle backcolor="White"  
          forecolor="black"
          font-italic="false" />
        <Columns >           
            <asp:BoundField HeaderText="ClassName" DataField="location" ><ItemStyle Width="6%" /><ControlStyle Width="6%"></ControlStyle></asp:BoundField>
            <asp:BoundField HeaderText="IP Address" DataField="CCIP"><ItemStyle Width="6%" /><ControlStyle Width="6%"/></asp:BoundField>
            <asp:BoundField HeaderText="Status"  DataField ="Status" ><ItemStyle Width="6%" /><ControlStyle Width="6%"/></asp:BoundField>
            <asp:BoundField HeaderText="Work Status" DataField="PowerStatus" ><ItemStyle Width="6%" /><ControlStyle Width="6%"/></asp:BoundField>
            <asp:BoundField HeaderText="Timer Service" DataField="TimerService"><ItemStyle Width="4%" /><ControlStyle Width="4%"/></asp:BoundField>
            <asp:BoundField HeaderText ="PC Power Satus" DataField="ComputerPower"><ItemStyle Width="4%" /><ControlStyle Width="4%"/></asp:BoundField>
            <asp:BoundField HeaderText="Projector Power Status" DataField="ProjectorPower"><ItemStyle Width="6%" /><ControlStyle Width="6%"/></asp:BoundField>
            <asp:BoundField HeaderText="Projector Used Hours" DataField="ProjectorUsedHour"><ItemStyle Width="6%" /><ControlStyle Width="6%"/></asp:BoundField>
            <asp:BoundField HeaderText="Curtain Status" DataField="CurtainStatus"><ItemStyle Width="6%" /><ControlStyle Width="6%"/></asp:BoundField>
            <asp:BoundField HeaderText="digital Screen Status" DataField="ScreenStatus"><ItemStyle Width="6%" /><ControlStyle Width="6%"/></asp:BoundField>
            <asp:BoundField HeaderText="Light" DataField="light"><ItemStyle Width="4%" /><ControlStyle Width="4%"/></asp:BoundField>
            <asp:BoundField HeaderText="Media Signal" DataField="MediaSignal"><ItemStyle Width="7%" /><ControlStyle Width="7%"/></asp:BoundField>
            <asp:BoundField HeaderText="System lock Status" DataField="LockStatus"><ItemStyle Width="5%" /><ControlStyle Width="5%"/></asp:BoundField>
            <asp:BoundField HeaderText="Podium Lock Status" DataField="podiumLock"><ItemStyle Width="5%" /><ControlStyle Width="5%"/></asp:BoundField>
            <asp:BoundField HeaderText="Class Lock Status" DataField="ClassLocked"><ItemStyle Width="5%" /><ControlStyle Width="5%"/></asp:BoundField>
            <asp:BoundField HeaderText="temperature" DataField="Temperature"><ItemStyle Width="5%" /><ControlStyle Width="5%"/></asp:BoundField>
            <asp:BoundField HeaderText="Humidity" DataField="Humidity"><ItemStyle Width="5%" /><ControlStyle Width="5%"/></asp:BoundField>
            <asp:BoundField HeaderText="PM2.5(µg/m3)" DataField="PM25"><ItemStyle Width="5%" /><ControlStyle Width="5%"/></asp:BoundField>
            <asp:BoundField HeaderText="PM10(µg/m3)" DataField="PM10"><ItemStyle Width="5%" /><ControlStyle Width="5%"/></asp:BoundField>                
        </Columns>
    </asp:GridView>    
                                </div>
                            </div>
                        
       </ContentTemplate>                    
    </asp:UpdatePanel>     
        <input type="text" id="message" />
        <input type="button" id="sendmessage" value="Send" />
        <input type="hidden" id="displayname" />
        <ul id="discussion">
        </ul>
        </div>
        </div>
</asp:Content>
