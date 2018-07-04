<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteDocument.aspx.cs" Inherits="final.DeleteDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="divopt">
        <fieldset >
            <legend>Download Files</legend>
       
        <asp:GridView  Width="80%" GridLines="Horizontal" BorderStyle="None"
            CellPadding="20" CellSpacing="20" ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded" >
             <RowStyle Height="50" />
    <Columns>
        <asp:BoundField DataField="Text" HeaderText="File Name" ControlStyle-ForeColor="Black" />
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
            </fieldset>
    </div>
</asp:Content>
