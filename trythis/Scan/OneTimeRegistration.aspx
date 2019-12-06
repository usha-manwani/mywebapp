<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="OneTimeRegistration.aspx.cs" Inherits="WebCresij.Scan.OneTimeRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        input{
            max-width:200px;
        }
        @media screen and (max-width: 280px) and (max-height:450px)
        {
            .paddingtop{
                padding-top:20%;                
            }
        }
        .paddingtop{
            padding: 5% 2% 2% 5%;
            max-width:500px;
            margin:0 auto;           
        }
        .row{
            margin-right:0px!important;
        }
        #timetbstart {
            max-width:100%;
            text-align:left
        }
        #timetbstop{
            max-width:100%;
            text-align:right
        }
        .alignright{
            text-align:right;
        }
        .maxwidth{
            max-width:500px
        }     
        .errormessage{
            font-size:smaller;
            text-align:center;
            color:red;
        }
    </style>
    <link href="../Content/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Content/jquery-ui.theme.min.css" rel="stylesheet" />
    <script src="../assets/js/jquery-ui.min.js"></script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="form-horizontal paddingtop">
            <asp:LinkButton runat="server" ID="Login" Text="<%$resources:Resource, Login %>" OnClick="Login_Click"
                 CausesValidation="false"></asp:LinkButton>   
             <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red"
                    ControlToCompare="tbpasswordtemp" ControlToValidate="tbpasswordconfirm" 
                    ErrorMessage="<%$Resources:Resource,PasswordNotMatch %>"></asp:CompareValidator>
            <asp:RegularExpressionValidator ID="rev1" runat="server"    
                        ControlToValidate="tbpasswordtemp" ForeColor="Red"
                        ErrorMessage="<%$Resources:Resource, PasswordLength %>"
                        ValidationExpression="^[a-zA-Z0-9\s]{8,15}$" />            
            <div class="form-group row">
                <label class="col" for="classname"><%=Resources.Resource.IPAddress %></label>
                <asp:TextBox runat="server" Enabled="false" Text="" ID="iptb" CssClass="form-control col"></asp:TextBox>
            </div>
            <div class="form-group row">
                <label class="col" for="username"><%=Resources.Resource.User %></label>
                <input type="text" class=" form-control col" id="username" required 
                    maxlength="45" runat="server" value=""/>                   
            </div>
            <div class="form-group row">
                <label class="col" for="phone"><%=Resources.Resource.Phone %>
                    <span style="color:lightgrey; font-size:smaller">(1111111111)</span></label>
                <input type="tel" class=" form-control col" id="phone" required minlength="11" size="11"
                    maxlength="11" runat="server" value="" pattern="[0-9]{11}" list="defaultTels"/> 
                    <datalist id="defaultTels">
                        <option value="11111111111">
                        <option value="12222222222">
                        <option value="13245678912">
                        <option value="34444444444">
                    </datalist>
            </div>
            <div class="form-group row">
                <label class="col" for="tbusertempid"><%=Resources.Resource.UserID %></label>
                <input type="text" class=" form-control col" id="tbusertempid" maxlength="16" runat="server" value="" required/>                    
            </div>
            
            <div class="form-group row">
                <label class="col" for="tbpasswordtemp"><%=Resources.Resource.Password %></label>
                <input type="password" class=" form-control col" id="tbpasswordtemp" required
                    maxlength="15" runat="server" value="" onfocus="showtip(this);" onfocusout="hidetip()"/>                
            </div>
            <div class="row errormessage" style="display:none" id="passlength">
                <span class="col offset-5">
                    <%=Resources.Resource.PasswordLength %>
                </span></div>
            <div class="form-group row">
                <label class="col" for="tbpasswordconfirm"><%=Resources.Resource.ConfirmPassword %></label>
                <input type="password" class=" form-control col" id="tbpasswordconfirm" 
                    maxlength="15" runat="server" value="" required/>                
            </div>
           
            <div class="form-group row">
                <label class="col-6" for="datepicker"><%=Resources.Resource.StartTime %></label>                
                    <input type="text" id="datepicker" runat="server" class=" form-control col-6" required/>               
            </div>
            <div class="form-group row">
                <label class="col-6" for="timetbstarthour"><%=Resources.Resource.StartTime %></label>
                <input type="text" id="starttimepicker" runat="server" class=" timepicker form-control col-6" required/>
            </div>
            <div class="form-group row">
                <label class="col-6" for="timetbstophour"><%=Resources.Resource.StopTime %></label>
                <input type="text" id="stoptimepicker" runat="server" class=" timepicker form-control col-6" required/>
            </div>

            <div class="form-group row">
                <label class="col" for="description"><%=Resources.Resource.Descriptionbox %></label>
                <textarea id ="description" maxlength="100" class="form-control col" runat="server" required></textarea>          
            </div>
            <asp:Button runat="server" ID="Submit" CssClass="btn btn-outline-dark align-content-center" Text="<%$Resources:Resource , Submit %>" 
                 OnClick="Submit_Click"/>    
        </div>
    </div>
    <script src="../lib/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js"></script>
    <script src="../Scripts/OneTimeRegistration.js"></script>
    
</asp:Content>
