<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Mobile.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebCresij.Mobile.Registration" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media screen and (max-width: 280px) and (max-height:450px)
        {
            .paddingtop{
                padding-top:30%;
            }
            label{
                color:white;
            }
        }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="form-horizontal paddingtop" style="margin:0 auto; max-width:500px" >
         <a href="Login.aspx"><%=Resources.Resource.Login %></a>
         <h2 style="text-align:center"><span><%=Resources.Resource.Register%></span></h2>
        <h4 style="text-align:center"><span><%=Resources.Resource.NewAccount%></span></h4>
        <hr style="background-color:white; height:1.5px;"/>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="User_Name" CssClass="col-md-5 control-label">
                <span><%=Resources.Resource.User%></span>
            </asp:Label>
            <div class="col-md-7">
                <asp:TextBox runat="server" ID="User_Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="User_Name"
                    CssClass="text-danger" ErrorMessage="<%$Resources:Resource,InsertName%>" />
            </div>
        </div>
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="UserID"
               CssClass="col-md-5 control-label">
                <span><%=Resources.Resource.UserID%></span>
            </asp:Label>
            <div class="col-md-7">
                <asp:TextBox runat="server" ID="UserID" CssClass="form-control" ToolTip=" UpperCase, Lowercase and numbers are allowed" />
                 <cc1:FilteredTextBoxExtender runat="server" ID="filterId" FilterType="UppercaseLetters,LowercaseLetters,Numbers" TargetControlID="UserID" />
                           
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserID"
                    CssClass="text-danger" ErrorMessage="<%$Resources:Resource,InsertID %>" />
            </div>
        </div>        
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-5 control-label">
                <span><%=Resources.Resource.Password%></span>
            </asp:Label>
            <div class="col-md-7">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" ToolTip="Uppercase, Lowercase, Numbers and Symbols '@!_$#%' are allowed" />
                <cc1:FilteredTextBoxExtender runat="server" ID="filterPass" 
                    FilterType="UppercaseLetters,LowercaseLetters,Numbers, Custom" 
                    TargetControlID="Password" ValidChars="@!_%$#" />                           
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="<%$Resources:Resource,InsertPassword %>" />
            </div>
        </div>
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-5 control-label">
                <span><%=Resources.Resource.ConfirmPassword%></span>
            </asp:Label>
            <div class="col-md-7">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="<%$Resources:Resource,InsertConfirmPassword %>" />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="<%$Resources:Resource,PasswordNotMatch %>" />
            </div>
        </div>
        
        <div class="form-group row">
            <asp:Label runat="server" AssociatedControlID="PhoneNo" CssClass="col-md-5 control-label">
               <span><%=Resources.Resource.Phone%></span>
            </asp:Label>
            <div class="col-md-7">
                <asp:TextBox runat="server" ID="PhoneNo" placeHolder="12312345678" CssClass="form-control" ClientIDMode="Static"   />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNo"
                    CssClass="text-danger" ErrorMessage="<%$Resources:Resource,InsertPhone%>" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="PhoneNo" ValidationExpression = "[\d]{11}"
                    CssClass="text-danger" ErrorMessage="Please enter a valid Phone Number "></asp:RegularExpressionValidator>
                <br />                
                <asp:LinkButton runat="server" ID="PhoneNoLink"  Enabled="true" 
                    OnClientClick="RequirePhone(); return false"  ClientIDMode="Static"
                    CausesValidation="True" ForeColor="DeepSkyBlue"  > 
                    <span ><%=Resources.Resource.PhoneVerify%></span></asp:LinkButton>                                    
            </div>
        </div>
        <div class="form-group row">
            <div class="col-md-12" style="text-align:center">
                <asp:Button runat="server" OnClick="CreateUser_Click" 
                    Text="<%$Resources:Resource, Register %>" CssClass="btn btn-outline-light"/>
            </div>
        </div>
            
    </div>
        
</asp:Content>
