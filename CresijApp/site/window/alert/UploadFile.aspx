<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="CresijApp.site.window.alert.UploadFile" %>

<!DOCTYPE html>


<html>
    <body>
        <form runat="server">
            <h4>To download the template for the file 
                <a href="DownloadCSVTempelate.aspx">click here</a>

            </h4>
            <div>
               
            <asp:FileUpload runat="server" ID="Upload" />
            <asp:Button runat="server" ID="btnUpload" CausesValidation="false"
                OnClick="BtnUpload_Click1" CssClass="btns btns_auto" Text="upload"/>
                
            </div>

        </form>
    </body>
</html>
