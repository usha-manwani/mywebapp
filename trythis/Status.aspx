﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.Master" AutoEventWireup="true" CodeBehind="Status.aspx.cs" Inherits="WebCresij.Status" %>

<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ID="Head" ContentPlaceHolderID="masterchildHead" runat="server">
    <%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">--%>

    <style type="text/css">
        .imgclick {
            height: 40px;
            width: 40px;
        }

            .imgclick:active {
                height: 42px;
                width: 42px;
            }

            .imgclick:hover {
                -webkit-border-radius: 10px;
                -moz-border-radius: 10px;
                border-radius: 10px;
                -webkit-box-shadow: 0px 0px 30px 0px rgba(0, 0, 245, 0.67);
                -moz-box-shadow: 0px 0px 30px 0px rgba(0, 0, 245, 0.67);
                box-shadow: 0px 0px 30px 0px rgba(0, 0, 245, 0.67);
            }
    </style>
    <%--</asp:Content>--%>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="masterchildBody" runat="server">
    <%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">--%>
    <!--Reference the SignalR library. -->
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
    <!--Reference the autogenerated SignalR hub script. -->
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="Scripts/MessagesToClient.js?v=4" type="text/javascript"></script>
    <div class="row" style="padding-right: 20px; margin-top: 8px;">
        <br>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%;">
                    <tr class="site-footer" style="height: 50px;">
                        <td style="text-align: left; background-color: #4ecdc4;">&nbsp;<span><%=Resources.Resource.Status%></span>:</td>
                        <td style="display: flex; justify-content: flex-end;">
                            <span style="float: right; color: white;">
                                <%--<i class="fa fa-refresh fa-spin fa-3x fa-fw" id="refresh"></i>--%>
                                <img src="Images/refresh.png" id="refresh" class="imgclick" />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <br />
                            <label for="ddlins">&nbsp;<span><%=Resources.Resource.SelectInstitute%></span>&nbsp;</label>
                            <asp:DropDownList ID="ddlins" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlins_SelectedIndexChanged" data-toggle="dropdown"
                                CssClass="btn btn-default border dropdown" BackColor="WhiteSmoke">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="GridView1" runat="server" Font-Size="Small" ViewStateMode="Enabled"
                                EmptyDataRowStyle-BackColor="Black"
                                ShowHeaderWhenEmpty="true" RowStyle-HorizontalAlign="Center"
                                EmptyDataRowStyle-ForeColor="White" AutoGenerateColumns="false">
                                <HeaderStyle Font-Bold="True" HorizontalAlign="Center" CssClass="table table-striped table-bordered table-hover" />
                                <RowStyle BackColor="WhiteSmoke" ForeColor="black" Height="50" />
                                <AlternatingRowStyle BackColor="White" ForeColor="black" Height="50" />
                                <Columns>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, ClassName %>" DataField="loc">
                                        <ItemStyle Width="6%" />
                                        <ControlStyle Width="6%"></ControlStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, IPAddress %>" DataField="CCIP">
                                        <ItemStyle Width="6%" />
                                        <ControlStyle Width="6%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, Status %>" DataField="Status">
                                        <ItemStyle Width="6%" />
                                        <ControlStyle Width="6%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, WorkStatus %>" DataField="PowerStatus">
                                        <ItemStyle Width="6%" />
                                        <ControlStyle Width="6%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, TimerService %>" DataField="TimerService">
                                        <ItemStyle Width="4%" />
                                        <ControlStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, PCPower %>" DataField="ComputerPower">
                                        <ItemStyle Width="4%" />
                                        <ControlStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, ProjectorPower %>" DataField="ProjectorPower">
                                        <ItemStyle Width="6%" />
                                        <ControlStyle Width="6%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, ProjectorHours %>" DataField="ProjectorUsedHour">
                                        <ItemStyle Width="6%" />
                                        <ControlStyle Width="6%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, CurtainStatus %>" DataField="CurtainStatus">
                                        <ItemStyle Width="6%" />
                                        <ControlStyle Width="6%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, SCStatus %>" DataField="ScreenStatus">
                                        <ItemStyle Width="6%" />
                                        <ControlStyle Width="6%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, Light%>" DataField="light">
                                        <ItemStyle Width="4%" />
                                        <ControlStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, MediaSignal %>" DataField="MediaSignal">
                                        <ItemStyle Width="10%" />
                                        <ControlStyle Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, SystemLock %>" DataField="LockStatus">
                                        <ItemStyle Width="5%" />
                                        <ControlStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, PodiumLock %>" DataField="podiumLock">
                                        <ItemStyle Width="5%" />
                                        <ControlStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, ClassLock %>" DataField="ClassLocked">
                                        <ItemStyle Width="5%" />
                                        <ControlStyle Width="5%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, Temperature %>" DataField="Temperature">
                                        <ItemStyle Width="4%" />
                                        <ControlStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, Humidity %>" DataField="Humidity">
                                        <ItemStyle Width="4%" />
                                        <ControlStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PM2.5(µg/m3)" DataField="PM25">
                                        <ItemStyle Width="4%" />
                                        <ControlStyle Width="4%" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="PM10(µg/m3)" DataField="PM10">
                                        <ItemStyle Width="4%" />
                                        <ControlStyle Width="4%" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
<%--</asp:Content>--%>


<%--  <div class=" row site-footer" style=" padding-right:20px; " >
                        <div class="panel-heading col-md-8" >
                             Status:
                        </div>
                        <div class="col-md-4" style="display:flex; justify-content:flex-end; ">
                            <%--<input type="image" src="Images/refresh.png"  id=" refresh" height="40" width="40" />
                            
                         <a id="refresh" href="#" style="float:right; color:white;">
                             <image src="Images/refresh.png" height="40" width="40" alt="Refresh"></image>
                         </a>
                   </div>
                        </div>--%>

<%--  <div class=" row" style=" padding-right:20px;">
                       <div class="col-12">    
                <asp:GridView ID="GridView1" runat="server" Font-Size="Small" ViewStateMode="Enabled" EmptyDataRowStyle-BackColor="Black"
                     ShowHeaderWhenEmpty="true" RowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="White" AutoGenerateColumns="false">
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
                            </div>--%>
                        
       
