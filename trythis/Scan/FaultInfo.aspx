<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="FaultInfo.aspx.cs" Inherits="WebCresij.Scan.FaultInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .forms{
            min-width:250px;
            min-height:300px;
            width:60%;
            top:20%;
            left:20%;  
            position:absolute;
            
        }
        .txtsize{
            max-width:200px;
            Width:200px;
        }
        .color{
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <asp:Button runat="server" ID="logout" CssClass="btn btn-link"
                Text="Logout" OnClick="logout_Click" CausesValidation="false"/>
        </div>
        <div>
            <asp:Button runat="server" CssClass="btn btn-link" Text="Go To Control"
                 OnClick="gotoControl_Click" CausesValidation="false"/>
            
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="forms">


                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="ddlPriority" ID="Label1"
                        CssClass="col-md-2 control-label" Text="Priority"></asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="ddlPriority" 
                            CssClass="btn btn-default border-dark txtsize" 
                            ForeColor="#232140" BackColor="white">
                            <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                            <asp:ListItem Text="Medium" Value="Medium"></asp:ListItem>
                            <asp:ListItem Text="High" Value="High"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="txtdistrict" ID="Label2"
                        CssClass="col-md-2 control-label" Text="District Name"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtdistrict" CssClass="form-control txtsize border-dark" />
                        <asp:RequiredFieldValidator runat="server" Text="*Required" CssClass="color"
                            ControlToValidate="txtdistrict"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="txtuser" ID="Label3"
                        CssClass="col-md-2 control-label" Text="Handled by"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtuser" CssClass="form-control txtsize border-dark"/>
                        <asp:RequiredFieldValidator runat="server" Text="*Required" CssClass="color"
                            ControlToValidate="txtuser"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="txtphone" ID="Label4"
                        CssClass="col-md-2 control-label" Text="Phone No."></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtphone" CssClass="form-control txtsize border-dark" 
                             PlaceHolder ="12345678901"/>
                        <asp:RequiredFieldValidator runat="server" Text="*Required" CssClass="color"
                            ControlToValidate="txtphone"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationExpression="^(\d){11}$"
                             runat="server" Text="Enter valid Phone Number" ControlToValidate="txtphone">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="txtdesc" ID="Label5"
                        CssClass="col-md-2 control-label" Text="Description"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtdesc" CssClass="form-control txtsize border-dark" />
                        <asp:RequiredFieldValidator runat="server" Text="*Required" CssClass="color"
                            ControlToValidate="txtdesc"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="ddlStat" ID="Label6"
                        CssClass="col-md-2 control-label" Text="Fault Status"></asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="ddlStat"
                            CssClass="btn btn-default border-dark txtsize" 
                            ForeColor="#232140" BackColor="white">
                            <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                            <asp:ListItem Text="Resolved" Value="Resolved"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                </div>

                <div class="form-group row">
                    <div class="col" style="left: 10%">
                        <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-outline-dark"
                            Text="Submit" OnClick="btnSubmit_Click" />
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
  
</asp:Content>
