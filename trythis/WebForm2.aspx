﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="WebForm2.aspx.cs" Inherits="WebCresij.WebForm2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Ajax Tab Container</title>
<style type="text/css">
.fancy-green .ajax__tab_header
{
	background: url("../Images/green_bg_Tab.gif") repeat-x;
	cursor:pointer;
}
.fancy-green .ajax__tab_hover .ajax__tab_outer, .fancy-green .ajax__tab_active .ajax__tab_outer
{
	background: url("../Images/green_left_tab.gif") no-repeat left top;
}
.fancy-green .ajax__tab_hover .ajax__tab_inner, .fancy-green .ajax__tab_active .ajax__tab_inner
{
	background: url("../Images/green_right_Tab.gif") no-repeat right top;
}
.fancy .ajax__tab_header
{
	font-size: 13px;
	font-weight: bold;
	color: #000;
	font-family: sans-serif;
}
.fancy .ajax__tab_active .ajax__tab_outer, .fancy .ajax__tab_header .ajax__tab_outer, .fancy .ajax__tab_hover .ajax__tab_outer
{
	height: 46px;
}
.fancy .ajax__tab_active .ajax__tab_inner, .fancy .ajax__tab_header .ajax__tab_inner, .fancy .ajax__tab_hover .ajax__tab_inner
{
	height: 46px;
	margin-left: 16px; /* offset the width of the left image */
}
.fancy .ajax__tab_active .ajax__tab_tab, .fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_header .ajax__tab_tab
{
	margin: 16px 16px 0px 0px;
}
.fancy .ajax__tab_hover .ajax__tab_tab, .fancy .ajax__tab_active .ajax__tab_tab
{
	color:cadetblue;
}
.fancy .ajax__tab_body
{
	font-family: Arial;
	font-size: 10pt;
	border-top: 0;
	border:1px solid #999999;
	padding: 8px;
	background-color: #ffffff;
}

</style>
</head>
<body>
<form id="form1" runat="server">
<asp:ScriptManager runat="server"></asp:ScriptManager>
<div style=" width:40%">
<ajax:TabContainer ID="TabContainer1" runat="server" CssClass="fancy fancy-green">
<ajax:TabPanel ID="tbpnluser" runat="server" >
<HeaderTemplate>
New User
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="UserReg" runat="server">
<table align="center">
<tr>
<td></td>
<td align="right" >
</td>
<td align="center">
<b>Registration Form</b>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
UserName:
</td>
<td>
<asp:TextBox ID="txtuser" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Password:
</td>
<td>
<asp:TextBox ID="txtpwd" runat="server" TextMode="Password"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
FirstName:
</td>
<td>
<asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
LastName:
</td>
<td>
<asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Email:
</td>
<td>
<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Phone No:
</td>
<td>
<asp:TextBox ID="txtphone" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Location:
</td>
<td align="left">
<asp:TextBox ID="txtlocation" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td></td>
<td></td>
<td align="left" ><asp:Button ID="btnsubmit" runat="server" Text="Save"/>
<input type="reset" value="Reset" />
</td>
</tr>
</table>
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>
<ajax:TabPanel ID="tbpnlusrdetails" runat="server" >
<HeaderTemplate>
User Details
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="Panel1" runat="server">
<table align="center">
<tr>
<td align="right" colspan="2" >
</td>
<td>
<b>User Details</b>
</td>
</tr>
<tr>

<td align="right" colspan="2">
UserName:
</td>
<td>
<b>Suresh Dasari</b>
</td>
</tr>
<tr>
<td align="right" colspan="2">
FirstName:
</td>
<td>
<b>Suresh</b>
</td>
</tr>
<tr>
<td align="right" colspan="2">
LastName:
</td>
<td>
<b>Dasari</b>
</td>
</tr>
<tr>
<td align="right" colspan="2">
Email:
</td>
<td>
<b>sureshbabudasari@gmail.com</b>
</td>
</tr>
<tr>
<td align="right" colspan="2" >
Phone No:
</td>
<td>
<b>1234567890</b>
</td>
</tr>
<tr>
<td align="right" colspan="2" >
Location:
</td>
<td align="left">
<b>Hyderabad</b>
</td>
</tr>
</table>
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>
<ajax:TabPanel ID="tbpnljobdetails" runat="server" >
<HeaderTemplate>
Job Details
</HeaderTemplate>
<ContentTemplate>
<asp:Panel ID="Panel2" runat="server">
<table align="center">
<tr>
<td></td>
<td align="right" >
</td>
<td>
<b>Job Details</b>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Job Type:
</td>
<td>
<b>Software</b>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Industry:
</td>
<td>
<b>IT</b>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Designation:
</td>
<td>
<b>Software Engineer</b>
</td>
</tr>
<tr>
<td></td>
<td align="right">
Company:
</td>
<td>
<b>aspdotnet-suresh</b>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Phone No:
</td>
<td>
<b>1234567890</b>
</td>
</tr>
<tr>
<td></td>
<td align="right" >
Location:
</td>
<td align="left">
<b>Hyderabad</b>
</td>
</tr>
</table>
</asp:Panel>
</ContentTemplate>
</ajax:TabPanel>
</ajax:TabContainer>
</div>
</form>
</body>
</html>
