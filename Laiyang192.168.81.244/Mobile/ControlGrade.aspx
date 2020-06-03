<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Site1.MobileNested.master" AutoEventWireup="true" 
    CodeBehind="ControlGrade.aspx.cs" Inherits="WebCresij.Mobile.ControlGrade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childMasterhead" runat="server">
   <script src="../Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="childmastercontent" runat="server">
    <div  style="text-align:center">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

            
        <div class="row" style="text-align:center">
            <div class="col"><label><%=Resources.Resource.SelectInsGrade%></label></div>
            </div>
        <br />
        <div class="row"  style="text-align:center">
            <div class="col">
                <asp:DropDownList Width="100px" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                    CssClass="btn btn-default border-light" ID="ddlInstitute"
                    runat="server" ForeColor="White" BackColor="#1E1E36">
                    <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col">
                <asp:DropDownList Width="100px" ID="ddlGrade"
                    OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged"
                    CssClass="btn btn-default border-light"
                    AutoPostBack="true" runat="server" ForeColor="White" BackColor="#1E1E36">
                    <asp:ListItem Text="<%$Resources:Resource, Select %>"
                        Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    
    <br />
    <input type="hidden" value="" runat="server" id="ipadd" />
    <div class="row" style="text-align:center">
        
        <div class="col"> 
            <asp:Button runat="server" ID="Btnon" CssClass="btn btn-outline-light"
                Text="<%$Resources:Resource, SystemOn %>"/>
        </div>
        <div class="col"> 
            <asp:Button runat="server" ID="BtnOff" CssClass="btn btn-outline-light"
                Text="<%$Resources:Resource, SystemOff %>"/>
        </div>
    </div>
    <br />
    <div class="row"  style="text-align:center">
        <div class="col"> 
            <asp:Button runat="server" ID="BtnLock" CssClass="btn btn-outline-light"
                Text="<%$Resources:Resource, SystemLock %>" />
        </div>
        <div class="col"> 
            <asp:Button runat="server" ID="BtnUnlock" CssClass="btn btn-outline-light"
                Text="<%$Resources:Resource, SystemUnlock %>" />
        </div>        
    </div>
                </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    <script src="../Scripts/MobileControlGrade.js"></script>
</asp:Content>
