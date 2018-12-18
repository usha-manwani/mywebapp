<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="tempratureCharts.aspx.cs" Inherits="trythis.tempratureCharts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
        <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>    
        <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' > </script>

    <div>
        <div>
                <asp:DropDownList Width="150px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                        CssClass="btn btn-default dropdown "  ID="ddlInstitute" 
                        data-toggle="dropdown"  runat="server" >
                        <asp:ListItem Text="select" Value=""></asp:ListItem>
                        </asp:DropDownList>
  
            </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterSideBody" runat="server">
</asp:Content>
