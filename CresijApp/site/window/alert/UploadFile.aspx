<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="CresijApp.site.window.alert.data.UploadFile" %>

<html>
    <body>
        <form runat="server">
            <div>
                <%--<input type="file" runat="server" id="fileUpload"/>
                    <input type="button" id="uploadbtn"
                         value="Upload" runat="server" onclick="btnUpload_Click();" />--%>
            <asp:FileUpload runat="server" ID="Upload" />
            <asp:Button runat="server" ID="btnUpload" CausesValidation="false"
                OnClick="BtnUpload_Click1" CssClass="btns btns_auto" Text="upload"/>
                
            </div>

        </form>
    </body>
</html>
            