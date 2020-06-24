<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadScheduleFile.aspx.cs" Inherits="CresijApp.site.window.UploadScheduleFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
               
            <asp:FileUpload runat="server" ID="Upload" />
            <asp:Button runat="server" ID="btnUpload" CausesValidation="false"
                OnClick="BtnUpload_Click1" CssClass="btns btns_auto" Text="upload"/>
                
            </div>
    </form>
</body>
</html>
