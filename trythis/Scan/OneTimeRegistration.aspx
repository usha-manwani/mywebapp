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
            padding: 10% 2% 2% 5%;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <div class="maxwidth">
        <div class="form-horizontal paddingtop">
            <div class="form-group row">
                <label class="col" for="classname"><%=Resources.Resource.ClassName %></label>
                <input type="text" class="form-control col" id="classname"/>
            </div>
            <div class="form-group row">
                <label class="col" for="classname"><%=Resources.Resource.IPAddress %></label>
                <asp:TextBox runat="server" Enabled="false" Text="" ID="iptb" CssClass="form-control col"></asp:TextBox>
            </div>
            <div class="form-group row">
                <label class="col-6" for="classname"><%=Resources.Resource.ClassName %></label>
                <input type="text" class="form-control col-3" id="timetbstart" />
                <input type="text" class="form-control col-3 alignright" id="timetbstop" />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
