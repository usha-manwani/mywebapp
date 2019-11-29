<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Site1.MobileNested.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebCresij.Mobile.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childMasterhead" runat="server">
    <style>
        .paddingtop{
                padding-top:15%;
                margin:0 auto;
            }
        .borders{
            border-bottom:1px solid white;
            
        }
        .notopborder{
            border:1px solid white;
            border-top:none;
           
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="childmastercontent" runat="server">
    <div class="paddingtop">
    <div class="row">
        <div class="col-6" style="border:1px solid white;text-align:center">
            <table style="width:100%;height:80px;">
                <tr>
                    <td><a href="Status.aspx"><i class="fa fa-th fa-2x" style="color:cornflowerblue"></i><br />
            <span class="menutext"  style="color:white!important">&nbsp;<%=Resources.Resource.Status%></span></a></td>
                    
                </tr>
            </table>
            </div>
        <div class="col-6"  style="border:1px solid white;text-align:center">
            <table  style="width:100%;height:80px;">
                <tr>
                    <td><a href="FaultInfo.aspx"><i class="fa fa-cog fa-2x" style="color:mediumpurple"></i><br />
            <span class="menutext" style="color:white!important">&nbsp;<%=Resources.Resource.FaultInfo%></span></a></td>
                    
                </tr>
            </table>
            
            </div>
   
        <div class="col-6 notopborder"  style=" text-align:center">
            
            <table  style="width:100%;height:80px;">
                <tr>
                    <td><a href="Control.aspx"><i class="fa fa-calculator fa-2x" style="color:yellowgreen"></i><br />
            <span class="menutext" style="color:white!important">&nbsp;<%=Resources.Resource.GoToControl%></span></a></td>
                    
                </tr>
            </table></div>
        <div class="col-6 notopborder" id="authuser" runat="server"  style="text-align:center">
            <table style="width:100%;height:80px;" >
                <tr>
                    <td><a href="AuthenticateUser.aspx"><i class="fas fa-user-check fa-2x" style="color:skyblue"></i><br />
                <span class="menutext" style="color:white!important">&nbsp;<%=Resources.Resource.AuthenticateUsers%></span></a></td>
                    
                </tr>
            </table>
        </div>
    
            <div class="col-6 notopborder"  style="text-align:center">
             <table  style="width:100%;height:80px;">
                <tr>
                    <td><a href="Logout.aspx"><i class="fas fa-sign-out-alt fa-2x" style="color:palegreen"></i><br />
            <span class="menutext" style="color:white!important">&nbsp;<%=Resources.Resource.SignOut%></span></a></td>
                    
                </tr>
            </table></div>
        
        </div>
        </div>
    <br />
</asp:Content>
