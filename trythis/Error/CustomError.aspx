<%@ Page Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="CustomError.aspx.cs" Inherits="WebCresij.Error.CustomError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <title></title>
    <style>
        .message{
           position: absolute;
            top: 50%;
            left: 50%;
            -ms-transform: translateX(-50%) translateY(-50%);
            -webkit-transform: translate(-50%,-50%);
            transform: translate(-50%,-50%);
          
          color:red;
            
            /*border:2px solid red;*/
          
        }
        
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <div class="message">
            <div class="row">
                <span>OOPS! The page you are trying to request is not found! Please login again to continue</span>
           &nbsp; &nbsp; &nbsp;
                    <asp:LinkButton runat="server" CommandName="Login"
                        OnClick="BtnLogin_Click" 
                                Text="<%$Resources:Resource, Login %>" 
                                Font-Size="Medium" BorderColor="white" ForeColor="White" Font-Underline="true"></asp:LinkButton>
                </div>
            </div>
        
</asp:Content>
