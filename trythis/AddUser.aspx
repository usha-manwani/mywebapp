<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="trythis.AddUser" %>
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
    width:600px}

    </style>
     <link href="http://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" rel="Stylesheet"
        type="text/css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
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
   
       <div class="form-horizontal divopt" >
        <h4>Add a new User..!</h4>
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
        <div class="form-group ">
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
            <asp:Label runat="server" AssociatedControlID="CheckBoxList1" CssClass="col-md-2 control-label" Text="Role"></asp:Label>
            <div class="col-md-10">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem Text="Administrator(Full Access)" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Live Feed " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Manage Devices Details(Add,Edit,Delete)" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Document upload & Download" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Document Deletion" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Add, Authenticate and Delete Users" Value="6"></asp:ListItem>                       
                    </asp:CheckBoxList>
                </div>
            </div>
           <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="PhoneNo" CssClass="col-md-2 control-label" Text="Phone"></asp:Label>
               <div class="col-md-10">
                <asp:TextBox runat="server" ID="PhoneNo" placeHolder="+86-123-12345678" CssClass="form-control" ClientIDMode="Static"   />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNo"
                    CssClass="text-danger" ErrorMessage="The Phone Number is required." />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="PhoneNo" ValidationExpression = "\+(\(|)[\d]{2}(\)|)\-(\(|)[\d]{3}(\)|)\-(\(|)[\d]{8}(\)|)"
                    CssClass="text-danger" ErrorMessage="Please enter a valid Phone Number "></asp:RegularExpressionValidator>
                <br />
                
                <asp:LinkButton runat="server" ID="PhoneNoLink"  Enabled="true" OnClientClick="RequirePhone(); return false"  ClientIDMode="Static" CausesValidation="True"  ForeColor="#336699" CssClass="asplink"> Verify Phone Number</asp:LinkButton>
                 </div>   
                
            </div>
        
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Add" CssClass="btn btn-default" />
            </div>
        </div>
   </div>
</asp:Content>
