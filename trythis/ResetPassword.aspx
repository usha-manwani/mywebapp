<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="WebCresij.ResetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
    <style>
        .custombtn{  
            width: 80px;
            margin-right: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
    <div style="max-width:500px;">
            <div class=" row " style="padding-right: 20px; text-align:center">
                                <div class="panel-heading col ">
                                    <h4><span><%=Resources.Resource.ChangePassword %></span></h4>
                                </div>
                            </div>
                                <div class="form-horizontal">
                                    <div class="form-group row margintop">
                                        <label class="col"><%=Resources.Resource.CurrentPassword %></label>
                                        <input type="password" class="form-control col" runat="server" id="oldpass" required/>
                                    </div>
                                    <div class="form-group row margintop">
                                        <label class="col"><%=Resources.Resource.NewPassword %></label>
                                        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control col" ID="tbpassword"
                                             ToolTip ="Uppercase, Lowercase, Numbers and Symbols '@!_$#%' are allowed" required></asp:TextBox>                                        
                                    </div>
                                    <div class="form-group row margintop">
                                        <label class="col"><%=Resources.Resource.ConfirmPassword %></label>
                                        <asp:TextBox runat="server" TextMode="password" CssClass="form-control col"
                                           ID="confirmpassword" required></asp:TextBox>                                       
                                    </div>
                                    <asp:CompareValidator ID="CompareValidator2" ControlToCompare="oldpass"
                                         ControlToValidate="tbpassword" Operator="NotEqual"
                                        runat="server" ErrorMessage="Can not use same password as old one" Display="Dynamic"></asp:CompareValidator>
                                    <asp:CompareValidator ID="CompareValidator1" ControlToCompare="tbpassword"
                                         ControlToValidate="confirmpassword" Type="String"
                                        runat="server" ErrorMessage="<%$Resources:Resource,PasswordNotMatch %>" Display="Dynamic"></asp:CompareValidator>                                   
                                </div>
            <div class="row" style="text-align:center">
                <div class="col">
                    <asp:Button Text="<%$Resources:Resource,Ok %>" runat="server" ID="btnchangepass" OnClick="Btnchangepass_Click"
                    CssClass="btn btn-outline-light custombtn"/>
                    <%--<asp:Button Text="cancel" runat="server" ID="cancel"
                    CssClass="btn btn-outline-light custombtn" CausesValidation="false"/>--%>
                </div>
            </div>
        </div>
</asp:Content>
