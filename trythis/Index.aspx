<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebCresij.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="position:center; " >
     <h2 ><asp:Label runat="server" ID="loginHead" Text="<%$Resources:Resource, Login %>"></asp:Label></h2>    
    <div class="row">
        <div class="col-12">
            <section id="loginForm"  >
                <div class="form-horizontal" >
                    <h4 ><asp:Label runat="server" Text="<%$Resources:Resource, loginAccount %>" ID="heading1" ></asp:Label>
                        </h4>
                    <hr />
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                        </asp:PlaceHolder>
                    
                    <div class=" row"  >
                        <asp:Label runat="server" AssociatedControlID="UserName" ID="userLabel"
                            CssClass="col-md-2 " Text="<%$Resources:Resource, UserPhone %>" ></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control"  />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>                    
                    <div class="form-group row">
                        <asp:Label runat="server" AssociatedControlID="Password" ID="passLabel"
                            CssClass="col-md-2 control-label" Text="<%$Resources:Resource, Password %>" ></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password"  CssClass="form-control" />                           
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" 
                                CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" ID="rememberLabel" Text="<%$Resources:Resource, Remember %>"
                                    AssociatedControlID="RememberMe"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="btnLogin" CommandName="Login" OnClick="LogIn"
                                Text="<%$Resources:Resource, Login %>" 
                                Font-Size="Medium" BorderColor="Gray" ForeColor="White" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" 
                        ViewStateMode="Disabled"  Text="<%$Resources:Resource, RegisterLink %>" 
                        NavigateUrl="~/Registration.aspx"></asp:HyperLink>
                  <asp:Label Text="<%$Resources:Resource, noAccount %>" runat="server" ID="registerLabel"></asp:Label>
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
