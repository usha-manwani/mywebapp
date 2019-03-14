<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebCresij.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CheckBoxList runat="server" ID="chk1">
                <asp:ListItem Text="one" Value="1"></asp:ListItem>
                <asp:ListItem Text="two" Value="2"></asp:ListItem>
                <asp:ListItem Text="three" Value="3"></asp:ListItem>
                <asp:ListItem Text="four" Value="4"></asp:ListItem>
                <asp:ListItem Text="five" Value="5"></asp:ListItem>
            </asp:CheckBoxList>
            
            <asp:Button runat="server" ID="btn" Text="submit" OnClick="btn_Click"/>
        </div>
    </form>
</body>
</html>
