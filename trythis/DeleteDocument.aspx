<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DeleteDocument.aspx.cs" Inherits="WebCresij.DeleteDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
     <div class="divopt">
        <fieldset >
            <legend>Download Files</legend>
       
        <asp:GridView  Width="80%" GridLines="Horizontal" BorderStyle="None"
            CellPadding="20" CellSpacing="20" ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded" >
             <RowStyle Height="50" />
    <Columns>
        <asp:BoundField DataField="Text" HeaderText="File Name" ControlStyle-ForeColor="white" />
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile"  CssClass="asplink" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
            </fieldset>
    </div>
</asp:Content>
