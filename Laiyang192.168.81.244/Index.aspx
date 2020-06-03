<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebCresij.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
         @media screen and (max-width: 280px) and (max-height:450px)
        {
            .paddingtop{
                padding-top:20%;
            }
            label{
                color:white;
            }
        }
        .paddingtop{
            padding: 10% 0 2% 2%;
            max-width:500px;
            margin:0 auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <div class="form-horizontal paddingtop" >
     <h2 style="text-align:center"><asp:Label runat="server" ID="loginHead" 
         Text="<%$Resources:Resource, Login %>"></asp:Label></h2>    
    <div class="row" >
        <div class="col-12">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4 style="text-align:center">
                        <asp:Label runat="server" Text="<%$Resources:Resource, loginAccount %>" ID="heading1" ></asp:Label>
                    </h4>
                    <hr style="background-color:white; height:1.5px;"/>
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText"/>
                        </p>
                    </asp:PlaceHolder>
                    <div class="row" >
                        <asp:Label runat="server" AssociatedControlID="UserName" ID="userLabel"
                            CssClass="col-md-5 " Text="<%$Resources:Resource, UserPhone %>" ></asp:Label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="Password" ID="passLabel"
                            CssClass="col-md-5 control-label" Text="<%$Resources:Resource, Password %>" ></asp:Label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password"  CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" 
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class=" col-md-12">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" ID="rememberLabel" Text="<%$Resources:Resource, Remember %>"
                                    AssociatedControlID="RememberMe"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12" style="text-align:center">
                            <asp:Button runat="server" ID="btnLogin" CommandName="Login" OnClick="LogIn"
                                Text="<%$Resources:Resource, Login%>"
                                CssClass="btn btn-outline-light" />
                        </div>
                    </div>
                </div>
                <p>
                  <asp:Label Text="<%$Resources:Resource, noAccount %>" runat="server" ID="registerLabel"></asp:Label>
               <asp:HyperLink runat="server" ID="RegisterHyperLink"  ForeColor="DeepSkyBlue"
                        ViewStateMode="Disabled"  Text="<%$Resources:Resource, RegisterLink %>"
                        NavigateUrl="~/Registration.aspx"></asp:HyperLink>
                    </p>
            </section>
        </div>
        <%--<div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>--%>
        
    </div>
        
        </div>  
    
    
</asp:Content>
