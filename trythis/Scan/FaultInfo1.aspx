<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="FaultInfo1.aspx.cs" Inherits="WebCresij.Scan.FaultInfo1" %>
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
                Text="<%$Resources:Resource, Login %>" OnClick="logout_Click" CausesValidation="false"/>            
        </div>
    </div>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="forms">
                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="ddlPriority" ID="Label1"
                        CssClass="col-md-2 control-label" Text="<%$Resources:Resource, Priority %>"></asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="ddlPriority" 
                            CssClass="btn btn-default border-dark txtsize" 
                            ForeColor="#232140" BackColor="white">
                             <asp:ListItem Text="<%$Resources:Resource, Low %>" Value="Low"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, Medium %>" Value="Medium"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, High %>" Value="High"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="txtdistrict" ID="Label2"
                        CssClass="col-md-2 control-label" Text="<%$Resources:Resource, distname %>"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtdistrict" CssClass="form-control txtsize border-dark" />
                        <asp:RequiredFieldValidator runat="server" Text="*Required" CssClass="color"
                            ControlToValidate="txtdistrict"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="txtuser" ID="Label3"
                        CssClass="col-md-2 control-label" Text="<%$Resources:Resource, handledBy %>"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtuser" CssClass="form-control txtsize border-dark"/>
                        
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="txtphone" ID="Label4"
                        CssClass="col-md-2 control-label" Text="<%$Resources:Resource, PhoneNum %>"></asp:Label>
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
                        CssClass="col-md-2 control-label" Text="<%$Resources:Resource, Description %>"></asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="txtdesc" CssClass="form-control txtsize border-dark" />
                        <asp:RequiredFieldValidator runat="server" Text="*Required" CssClass="color"
                            ControlToValidate="txtdesc"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <asp:Label runat="server" AssociatedControlID="ddlStat" ID="Label6"
                        CssClass="col-md-2 control-label" Text="<%$Resources:Resource, FaultStatus %>"></asp:Label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="ddlStat"
                            CssClass="btn btn-default border-dark txtsize" 
                            ForeColor="#232140" BackColor="white">
                            <asp:ListItem Text="<%$Resources:Resource, Pending %>" Value="Pending"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, Resolved %>" Value="Resolved"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                </div>

                <div class="form-group row">
                    <div class="col" style="left: 10%">
                        <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-outline-dark"
                            Text="<%$Resources:Resource, Submit %>" OnClick="btnSubmit_Click" />
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
