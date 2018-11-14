<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="trythis.home"  MasterPageFile="~/Site.Master" %>
<%--<%@ MasterType VirtualPath="~/Site.Master" %>--%>
<asp:Content ContentPlaceHolderID="HeadContent" ID="headarea" runat="server">   
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" ID="MainBody" runat="server">
    <div class="divopt">
    <asp:GridView ID="GridView1" runat="server" GridLines="Horizontal" AutoGenerateColumns="false" 
        CellPadding="40" CellSpacing="40"   ForeColor="Black" HeaderStyle-BackColor="#009688" 
        EmptyDataText = "No Cameras Registered" BorderStyle="None"   >
        <RowStyle Height="30"  />
        <Columns>
            <asp:BoundField DataField="CameraIP" HeaderText="Camera IP" HeaderStyle-HorizontalAlign="Left"  />
            <asp:BoundField DataField="Status" HeaderText="Status" HeaderStyle-HorizontalAlign="Left" />           
             <asp:TemplateField >
                            <ItemTemplate>
                                 <asp:linkButton ID="btnPing"  runat="server" Text="Check Status" OnClick="btnPing_Click" />
                            </ItemTemplate>
             </asp:TemplateField>
        </Columns>
    </asp:GridView>
 </div>
    
</asp:Content>
