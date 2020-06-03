<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebCresij.Scan.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .para{
            color:red;
            text-align:center;
            width:60%;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div  class="positionCenter para">
        <p>
            No valid Ip Address!! Please scan code to login.
        </p>
    </div>
    
</asp:Content>
