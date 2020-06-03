<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.Master" AutoEventWireup="true" 
    CodeBehind="Control.aspx.cs" Inherits="WebCresij.Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
<style type="text/css">
.imgclick:active{
   box-shadow: 0 5px #666;
   transform: translateY(4px);
}
.imgclick:hover{
    -webkit-border-radius: 10px;
    -moz-border-radius: 10px;
    border-radius: 10px;
    -webkit-box-shadow: 0px 0px 30px 0px rgba(0, 0, 245, 0.67);
    -moz-box-shadow: 0px 0px 30px 0px rgba(0, 0, 245, 0.67);
    box-shadow: 0px 0px 30px 0px rgba(0, 0, 245, 0.67);
}
[type=radio] { 
  position: absolute;
  opacity: 0;
  width: 0;
  height: 0;
}
/* IMAGE STYLES */
[type=radio] + img {
  cursor: pointer;
}
/* CHECKED STYLES */
[type=radio]:checked + img {
  outline: 2px solid #f00;
}
.modal 
{
    display: none;  /*Hidden by default*/ 
    position: fixed;  /*Stay in place*/ 
    z-index: 1;  /*Sit on top*/ 
    padding-top: 150px;  /*Location of the box*/ 
    left: 0;
    top: 0;
    width: 100%;  /*Full width*/ 
    height: 100%;  /*Full height*/ 
    overflow: auto;  /*Enable scroll if needed*/ 
    background-color: rgb(0,0,0);  /*Fallback color*/ 
    background-color: rgba(0,0,0,0.4);  /*Black w/ opacity*/ 
}
.modal-content {
    background-color:aliceblue;
    margin: auto;
    padding: 20px;
    border: 1px solid #888;
    width: 60%;
} 
.pp{
    background-color: #565656;
    color: transparent;
    text-shadow: 0px 2px 3px rgba(255,255,255,0.3);
    -webkit-background-clip: text;
    -moz-background-clip: text;
    background-clip: text;
}
.displaynone{
        display:none;
}
.displayblock{
   display:inline-block;
   cursor:pointer;
}
.table1234 {
    float:left;
    border-radius: 10px;   
    max-width: 250px;
    min-width:200px;
    min-height: 280px;
    max-height:300px;
    background-color:#23233f;
}
.fixwidth{
    width:100%;
    text-align:center;
}
.chk{
    width:20%;
    float:left;
    text-align:center;
}
</style>
    <link href="Content/ControlStyle.css?v=1" rel="stylesheet" />
    <link href="css/toggleswitch.css" rel="stylesheet" />
    <link href="http://www.cssscript.com/wp-includes/css/sticky.css" 
        rel="stylesheet" type="text/css">
    <!--Reference the SignalR library. -->  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
    <script src="Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="Scripts/ControlKeys.js?v=26"></script>
    <h4 style="color:white;margin-top:-1rem">
        <asp:Label runat="server" ID="insName"></asp:Label>
        <asp:Label runat="server" ID="GradeName"></asp:Label>
    </h4>
        <hr style="background-color:black"/>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row" style="margin-bottom:-1.5rem; margin-top:-1rem; text-align:center">
        <span class="col-xl-2 col-lg-3 col-md-6 col-sm-10" style="font-size:1rem; color:white">
            <%=Resources.Resource.ClassToOnOff %></span>
                <div class="col-xl-2 col-lg-2 col-md-3 col-sm-5">
        <button class="btn btn-outline-light " value="ON" id="btnOn"> 
            <%=Resources.Resource.SystemOn %></button></div>
                <div class="col-xl-2 col-lg-2 col-md-3 col-sm-5">
        <button class="btn btn-outline-light " value="OFF" id="btnOff"> 
            <%=Resources.Resource.SystemOff %></button></div>
                <div class="col-xl-2 col-lg-2 col-md-3 col-sm-5" >
        <button class="btn btn-outline-light " value="lock" id="btnlock"> 
            <%=Resources.Resource.SystemLock %></button></div>
                <div class="col-xl-2 col-lg-2 col-md-3 col-sm-5">
        <button class="btn btn-outline-light " value="unlock" id="btnunlock"> 
            <%=Resources.Resource.SystemUnlock%></button></div>                
                <div class="col-xl-1 col-lg-2 col-md-3 col-sm-5" style="float:right">
        <button class=" btn btn-link" value="select" id="SelectAll">
            <%=Resources.Resource.SelectAll %></button></div>
                <div class="col-xl-1 col-lg-2 col-md-3 col-sm-5" style="float:right">
        <button class=" btn btn-link" value="unselect" id="UnselectAll">
            <%=Resources.Resource.UnselectAll %></button></div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="container-fluid">
        <div class="row clearfix" id="smallcontrol"
            style="width: 90%; min-width: 800px; max-width: 100%">
            <input type="hidden" name="ipForRemote" value="<%= Session["MyVariable"]%>"/>
        </div>
    </div>
    <input id="sessionInput" type="hidden" value='<%= Session["DeviceIP"] %>'/>
    <input id="sessionInput1" type="hidden" value='<%= Session["loc"] %>'/>
    <input id="dev1" type="hidden" value='<%= Session["devices"] %>'/>
    <input id="InputIP" type="hidden" value='<%= Session["DeviceIP"] %>'/>
    <asp:TextBox Style="display:none" ID="ipAddressToSend" runat="server"></asp:TextBox>
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
</asp:Content>