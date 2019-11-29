<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="MobileLogin.aspx.cs" Inherits="WebCresij.Scan.MobileLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <style>
        @media screen and (max-width: 280px) and (max-height:450px)
        {
            .paddingtop{
                padding-top:20%;
                
            }
        }
        .paddingtop{
            padding: 10% 2% 2% 5%;
            max-width:500px;
            margin:0 auto;
        }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bck">
        
        <div>
            
           <asp:LinkButton runat="server" ID="gotoFault" Text="<%$Resources:Resource, AddNewFaultInfo %>"
                OnClick="gotoFault_Click" CausesValidation="false"></asp:LinkButton>
        </div>
    </div>
    <br />
    <div class="form-horizontal paddingtop">
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
            <div class="form-group row">
                <asp:Label runat="server" AssociatedControlID="UserName" ID="userLabel"
                    CssClass="col-md-2 " Text="<%$Resources:Resource, UserPhone %>"></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                    
                </div>
            </div>
            <div class="form-group row" >
                <asp:Label runat="server" AssociatedControlID="Password" ID="passLabel"
                    CssClass="col-md-2 control-label" Text="<%$Resources:Resource, Password %>"></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    
                </div>
            </div>
            <asp:Button Text="<%$Resources:Resource, Login %>" CssClass="btn btn-outline-dark" runat="server" ID="Login" OnClick="Login_Click" />
        </div>
         <p>
                  <asp:Label Text="<%$Resources:Resource, noAccount %>" runat="server" ID="registerLabel"></asp:Label>
       <asp:LinkButton runat="server" ID="linkregister" OnClick="linkregister_Click" Text="<%$Resources:Resource, RegisterLink %>"></asp:LinkButton>
            
               
                    </p>
    </div>
   
</asp:Content>
