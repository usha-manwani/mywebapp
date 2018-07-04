<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="final._Default" %>
<asp:Content ID="Headcontent" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="Scripts/demo.js"></script>
    <link href="Content/demo.css" rel="stylesheet" />
    <script src="Scripts/WebVideoCtrl.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="camAdd" runat="server">
        <ContentTemplate>
    <div class="row">
    <div class="col-sm-6">
    <fieldset class="login">
		<legend>Login</legend>
		<table cellpadding="0" cellspacing="3" border="0">
			<tr>
				<td class="tt">IP address</td>
				<td><input id="loginip" type="text" class="txt" value="172.9.4.222" /></td>
				<td class="tt">Port</td>
				<td><input id="port" type="text" class="txt" value="80" /></td>
			</tr>
			<tr>
				<td class="tt">User name</td>
				<td><input id="username" type="text" class="txt" value="admin" /></td>
				<td class="tt">Password</td>
				<td><input id="password" type="password" class="txt" value="12345" /></td>
			</tr>
			<tr>
				<td class="tt">Device port</td>
				<td colspan="2"><input id="deviceport" type="text" class="txt" value="8000" />（optional）</td>
				<td>
					Split screen&nbsp;
					<select class="sel2" onchange="changeWndNum(this.value);">
						<option value="1">1x1</option>
						<option value="2" selected>2x2</option>
						<option value="3">3x3</option>
						<option value="4">4x4</option>
					</select>
				</td>
			</tr>
			<tr>
				<td colspan="4">
					<input type="button" class="btn" value="Login" onclick="clickLogin();" />
					<input type="button" class="btn" value="Logout" onclick="clickLogout();" />
					<input type="button" class="btn2" value="Get basic info" onclick="clickGetDeviceInfo();" />
				</td>
			</tr>
			<tr>
				<td class="tt">Logined devices</td>
				<td>
					<select id="ip" class="sel" onchange="getChannelInfo();"></select>
				</td>
				<td class="tt">Channel list</td>
				<td>
					<select id="channels" class="sel"></select>
				</td>
			</tr>
		</table>
	</fieldset>
        </div>
        </div>
    <div class="row">
    <div class="col-sm-6">
        <fieldset class="preview" style="position:relative">
        <legend>Browse</legend>
        <table cellpadding="0" cellspacing="3" border="0">
            <tr>
                <td class="tt">Stream type</td>
                <td>
                    <select id="streamtype" class="sel">
                        <option value="1">Main stream</option>
                        <option value="2">Sub stream</option>
                    </select>
                </td>
                <td>
                    <input type="button" class="btn" value="Start preview" onclick="clickStartRealPlay();" />
                    <input type="button" class="btn" value="Stop preview" onclick="clickStopRealPlay();" />
                </td>
            </tr>
            </table>
    </fieldset>
        </div>
        </div>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
