<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPAge.aspx.cs" Inherits="WebCresij.TestPAge1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Chart.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/sensor.css" rel="stylesheet" />
    <link href="Content/fontawesome-all.min.css" rel="stylesheet" />
    <link href="Content/fontawesome.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/Treeview.js"></script>
    <script src="Scripts/sensor.js"></script>
    <link href="HikVision/demo.css" rel="stylesheet" />
    
</head>
    
<body>
    <form id="form1" runat="server">
        <%--<div class="container-fluid no-gutter">
            <div class="col-2 left no-gutter float-left">
                <div class="logo">
                    <img class="logo rounded-circle clearfix" src="images/logo.jpg" alt=""/></div>
                <h3 class="text-center clearfix">北京大学</h3>
                <p class="text-center font-weight-light" style="margin-bottom: 0;">BEIJING UNIVERSITY</p>
                <p class="text-center font-weight-light">智慧教室综合管理系统</p>
                <div class="component" id="menu-left"></div>
                
            </div>           
           
        </div>--%>
    <div style =" margin-left:300px!important">
                   <div class="left">
    <div id="divPlugin" class="plugin"></div>
    <fieldset class="login">
        <legend>Login</legend>
        <table cellpadding="0" cellspacing="3" border="0">
            <tr>
                <td class="tt">IP address</td>
                <td><input id="loginip" type="text" class="txt" value="172.168.10.96" /></td>
                <td class="tt">Port</td>
                <td><input id="port" type="text" class="txt" value="80" /></td>
            </tr>
            <tr>
                <td class="tt">User name</td>
                <td><input id="username" type="text" class="txt" value="admin" /></td>
                <td class="tt">Password</td>
                <td><input id="password" type="password" class="txt" value="admin123" /></td>
            </tr>
            <tr>
                <td class="tt">Device port</td>
                <td colspan="2"><input id="deviceport" type="text" class="txt" />（optional）</td>
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
                <td class="tt">RTSP port</td>
                <td colspan="3"><input id="rtspport" type="text" class="txt" />（optional）</td>
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
                    <select id="ip" class="sel" onchange="getChannelInfo();getDevicePort();"></select>
                </td>
                <td class="tt">Channel list</td>
                <td>
                    <select id="channels" class="sel"></select>
                </td>
                <td>
                    <input type="button" class="btn" value="Start preview" onclick="clickStartRealPlay();" />
                </td>
            </tr>
        </table>
    </fieldset>
  
</div>
<%--<div class="left">
    <fieldset class="preview">
        <legend>Browse</legend>
        <table cellpadding="0" cellspacing="3" border="0">
            <tr>
                <td class="tt">Stream type</td>
                <td>
                    <select id="streamtype" class="sel">
                        <option value="1">Main stream</option>
                        <option value="2">Sub stream</option>
                        <option value="3">Third stream</option>
                        <option value="4">Transcode stream</option>
                    </select>
                </td>
                <td>
                    <input type="button" class="btn" value="Start preview" onclick="clickStartRealPlay();" />
                    <input type="button" class="btn" value="Stop preview" onclick="clickStopRealPlay();" />
                </td>
            </tr>
            
        </table>
    </fieldset>

</div>--%>
<div class="left">
    <fieldset class="operate">
        <legend>Operation information</legend>
        <div id="opinfo" class="opinfo"></div>
    </fieldset>
    
</div>
                </div>
         
    </form>
</body>
<script src="Scripts/umd/popper.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="HikVision/codebase/webVideoCtrl.js"></script>

<script src="HikVision/Hikvision.js"></script>
    <script>

    </script>    
</html>

    