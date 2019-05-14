<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="CustomError.aspx.cs" Inherits="WebCresij.Error.CustomError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <title></title>
    <style>
        .message{
            margin:auto;
            max-width:400px;
            min-height:200px;
            border:2px solid red;
            margin-top:100px;
            padding: 10px 10px 10px 10px;
            border-radius:5px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <div>
            <div class="row message" >
                <span>OOPS! The page you are trying to request is not found! Please login again to continue</span>
                <div style=" padding-left:40%">
                    <asp:Button runat="server" ID="btnLogin" CommandName="Login" OnClick="BtnLogin_Click" 
                                Text="<%$Resources:Resource, Login %>" 
                                Font-Size="Medium" BorderColor="white" ForeColor="White" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
</asp:Content>
