<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadClass.aspx.cs" Inherits="CresijApp.site.window.alert.UploadClass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h4>To download the template for the file 
                <a href="DownloadClassCSVTemplate.aspx">click here</a>

            </h4>
        <div>
            <asp:FileUpload runat="server" ID="Upload" />
            <asp:Button runat="server" ID="btnUpload" CausesValidation="false"
                OnClick="btnUpload_Click" CssClass="btns btns_auto" Text="upload" />
        </div>
    </form>
</body>
</html>
