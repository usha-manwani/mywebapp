<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="WebCresij.AddUser" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 <asp:Content ID="Head" ContentPlaceHolderID="masterHead" runat="server">
        <style>       
          .leftspace{
              margin-left:20px;
              width:inherit;
              margin-right:20px;
              height:inherit;
              margin-bottom:20px;
          }
          .w3-modal{
              z-index:3;display:none;
              padding-top:100px;
              position:fixed;
              left:0;top:0;
              width:100%;
              height:100%;
              overflow:auto;
              background-color:rgb(0,0,0);
              background-color:rgba(0,0,0,0.4)}
          .w3-modal-content{
              margin:auto;background-color:#fff;
              position:relative;
              padding:0;
              outline:0;
              width:600px;
          }
          
        </style>
    <link href="http://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
     <script>
        function RequirePhone()
        {
            var x = document.getElementById('PhoneNo').value;            
            if(x=="")
            {
                alert("Please enter a phone No ");
                return false;
            }            
        }        
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="masterBody" runat="server">
    <div class="form-horizontal">
        <h4><span><%=Resources.Resource.AddNewUser1%></span></h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group row rowMargin">
            <asp:Label runat="server" AssociatedControlID="User_Name"
                CssClass="col-lg-2 control-label">
                <span><%=Resources.Resource.User%></span>
            </asp:Label>
            <asp:TextBox runat="server" ID="User_Name" CssClass="form-control col-lg-3" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="User_Name"
                CssClass="text-danger" ErrorMessage="The user name field is required." />
        </div>
        <div class="form-group row rowMargin">
            <asp:Label runat="server" AssociatedControlID="UserID"
                CssClass="col-lg-2 control-label"> <span><%=Resources.Resource.UserID%></span></asp:Label>
            <asp:TextBox runat="server" ID="UserID" CssClass="form-control col-lg-3"
                ToolTip=" UpperCase, Lowercase and numbers are allowed" />
            <cc1:FilteredTextBoxExtender runat="server" ID="filterId"
                FilterType="UppercaseLetters,LowercaseLetters,Numbers" TargetControlID="UserID" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserID"
                CssClass="text-danger" ErrorMessage="The User ID field is required." />
        </div>
        <div class="form-group row rowMargin">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-lg-2 control-label">
                 <span><%=Resources.Resource.Password%></span></asp:Label>
            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control col-lg-3"
                ToolTip="Uppercase, Lowercase, Numbers and Symbols '@!_$#%' are allowed" />
            <cc1:FilteredTextBoxExtender runat="server" ID="filterPass"
                FilterType="UppercaseLetters,LowercaseLetters,Numbers, Custom"
                TargetControlID="Password" ValidChars="@!_%$#" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                CssClass="text-danger" ErrorMessage="The password field is required." />
        </div>
        <div class="form-group row rowMargin">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword"
                CssClass="col-lg-2 control-label">
                 <span><%=Resources.Resource.ConfirmPassword%></span></asp:Label>
            <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" 
                CssClass="form-control col-lg-3" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                CssClass="text-danger" Display="Dynamic" 
                ErrorMessage="The confirm password field is required." />
            <asp:CompareValidator runat="server" ControlToCompare="Password" 
                ControlToValidate="ConfirmPassword" CssClass="text-danger" Display="Dynamic"
                ErrorMessage="The password and confirmation password do not match."/>
        </div>
        <div class="form-group row rowMargin">
            <asp:Label runat="server" AssociatedControlID="CheckBoxList1"
                CssClass="col-lg-2 control-label">
                <span><%=Resources.Resource.Role%></span>
            </asp:Label>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="col-lg-5">
                <asp:ListItem Text="<%$Resources:Resource, Admin %>" Value="1"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Resource, LiveFeed %>" Value="2"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Resource, manageDevice %>" Value="3"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Resource, DocUploadDownload %>" Value="4"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Resource, DocDelete %>" Value="5"></asp:ListItem>
                <asp:ListItem Text="<%$Resources:Resource, EditUsers %>" Value="6"></asp:ListItem>
            </asp:CheckBoxList>
        </div>
        <div class="form-group row rowMargin">
            <asp:Label runat="server" AssociatedControlID="PhoneNo"
                CssClass="col-lg-2 control-label"> 
                <span><%=Resources.Resource.Phone%></span></asp:Label>

            <asp:TextBox runat="server" ID="PhoneNo" placeHolder="+86-123-12345678"
                CssClass="form-control col-lg-3" ClientIDMode="Static" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNo"
                CssClass="text-danger" ErrorMessage="The Phone Number is required." />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="PhoneNo"
                ValidationExpression="\+(\(|)[\d]{2}(\)|)\-(\(|)[\d]{3}(\)|)\-(\(|)[\d]{8}(\)|)"
                CssClass="text-danger" ErrorMessage="Please enter a valid Phone Number ">
            </asp:RegularExpressionValidator>


        </div>

        <asp:LinkButton runat="server" ID="PhoneNoLink" Enabled="true"
            OnClientClick="RequirePhone(); return false" ClientIDMode="Static"
            CausesValidation="True" ForeColor="#336699">
                   <span><%=Resources.Resource.PhoneVerify%></span></asp:LinkButton>
        <div class="form-group">
            <div class=" col-lg-offset-1 col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click"
                    Text="<%$Resources:Resource, Register %>" CssClass="btn btn-outline-light" />
            </div>
        </div>
    </div>
</asp:Content>
