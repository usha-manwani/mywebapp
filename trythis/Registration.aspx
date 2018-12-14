<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site2.Master" CodeBehind="Registration.aspx.cs" Inherits="trythis.Registration" %>
<%@Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
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

    <h2>Register</h2>
    <%--<p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>--%>

    <div class="form-horizontal" >
        <h4>Create a new account.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="User_Name" CssClass="col-md-2 control-label">User name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="User_Name" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="User_Name"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserID" CssClass="col-md-2 control-label">User ID</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserID" CssClass="form-control" ToolTip=" UpperCase, Lowercase and numbers are allowed" />
                 <cc1:FilteredTextBoxExtender runat="server" ID="filterId" FilterType="UppercaseLetters,LowercaseLetters,Numbers" TargetControlID="UserID" />
                           
                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserID"
                    CssClass="text-danger" ErrorMessage="The User ID field is required." />
            </div>
        </div>
        
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" ToolTip="Uppercase, Lowercase, Numbers and Symbols '@!_$#%' are allowed" />
                <cc1:FilteredTextBoxExtender runat="server" ID="filterPass" FilterType="UppercaseLetters,LowercaseLetters,Numbers, Custom" TargetControlID="Password" ValidChars="@!_%$#" />
                           
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PhoneNo" CssClass="col-md-2 control-label">Phone No.</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PhoneNo" placeHolder="+86-123-12345678" CssClass="form-control" ClientIDMode="Static"   />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNo"
                    CssClass="text-danger" ErrorMessage="The Phone Number is required." />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="PhoneNo" ValidationExpression = "\+(\(|)[\d]{2}(\)|)\-(\(|)[\d]{3}(\)|)\-(\(|)[\d]{8}(\)|)"
                    CssClass="text-danger" ErrorMessage="Please enter a valid Phone Number "></asp:RegularExpressionValidator>
                <br />
                
                <asp:LinkButton runat="server" ID="PhoneNoLink"  Enabled="true" OnClientClick="RequirePhone(); return false"  ClientIDMode="Static" CausesValidation="True" > Verify Phone Number</asp:LinkButton>
                    
                
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>