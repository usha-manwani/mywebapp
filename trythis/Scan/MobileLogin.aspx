<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="MobileLogin.aspx.cs" Inherits="WebCresij.Scan.MobileLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <style>
        @media screen and (max-width: 280px) and (max-height:450px)
        {
            .paddingtop{
                padding-top:20%;
            }
        }
           
       
       
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="form-horizontal positionCenter paddingtop">
        <div>
            <h5>
                <asp:Label runat="server" Text="<%$Resources:Resource, loginAccount %>"
                    ID="heading1"></asp:Label>
            </h5>
            <hr style="background-color:white; height:1px;"/>
        </div>
        <div>
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            <div class="form-group row" style="max-width: 500px;">
                <asp:Label runat="server" AssociatedControlID="UserName" ID="userLabel"
                    CssClass="col-md-2 " Text="<%$Resources:Resource, UserPhone %>"></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                        CssClass="text-danger" ErrorMessage="The user name field is required." />
                </div>
            </div>
            <div class="form-group row" style="max-width: 500px;">
                <asp:Label runat="server" AssociatedControlID="Password" ID="passLabel"
                    CssClass="col-md-2 control-label" Text="<%$Resources:Resource, Password %>"></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                        CssClass="text-danger" ErrorMessage="The password field is required." />
                </div>
            </div>
            <asp:Button Text="Login" CssClass="btn btn-outline-dark" runat="server" ID="Login" OnClick="Login_Click" />
        </div>
    </div>
</asp:Content>
