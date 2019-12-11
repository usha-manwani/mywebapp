<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Mobile.Master" AutoEventWireup="true" 
    CodeBehind="Login.aspx.cs" Inherits="WebCresij.Mobile.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
         
     <div class="form-horizontal paddingtop" >
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
                    
                </div>
            </div>
            <div class="form-group row" style="max-width: 500px;">
                <asp:Label runat="server" AssociatedControlID="Password" ID="passLabel"
                    CssClass="col-md-2 control-label" Text="<%$Resources:Resource, Password %>"></asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                    
                </div>
            </div>
            <p style="text-align:center"><asp:Button Text="<%$Resources:Resource, Login %>" CssClass="btn btn-outline-light" runat="server" ID="Loginbtn" OnClick="Login_Click" /></p>
            
        </div>
         <br />
         <p>
                  <asp:Label Text="<%$Resources:Resource, noAccount %>" runat="server" ID="registerLabel"></asp:Label>
             <a href="Registration.aspx"><%=Resources.Resource.RegisterLink %></a> 
               
                    </p>
         
    </div>
         
         
</asp:Content>
