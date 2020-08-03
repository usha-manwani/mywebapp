<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadUser.aspx.cs" Inherits="CresijApp.site.window.alert.UploadUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <h4>To download the template for the file
            <asp:HyperLink runat="server" NavigateUrl="~/site/window/alert/DownloadUserDataTemplate.aspx" Text="click here!"></asp:HyperLink>
        </h4>
        <div>
            <asp:FileUpload runat="server" ID="Upload" />
            <asp:Button runat="server" ID="btnUpload" CausesValidation="false"
                OnClick="btnUpload_Click" CssClass="btns btns_auto" Text="upload" />
        </div>
        <div class="btns btns_auto">
    <!--<a class="bg_green alert_jmodal" j-page-href="window/alert/state_fail.html" j-page-box="#jcontent"><i class="fa fa-check"></i> 确定导入数据</a>-->
    <a class="bg_red close_jmodal"><i class="fa fa-close"></i> 取消</a>
    </div>
    </form>
</body>
</html>
<script src="../../js/sensor.js"></script>

