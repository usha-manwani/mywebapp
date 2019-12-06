<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Site1.MobileNested.master" AutoEventWireup="true" CodeBehind="FaultInfo.aspx.cs" Inherits="WebCresij.Mobile.FaultInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childMasterhead" runat="server">
    <style>
        .padding-top{
            padding-top:5%;
            max-width:600px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="childmastercontent" runat="server">
    <div class="row padding-top">

        <div class="col-12">
            <h4 style="text-align:center"><%=Resources.Resource.FaultInfo %></h4>
            <asp:GridView runat="server" ID="gv1Fault"
                AutoGenerateColumns="false" PageSize="10" Width="95%"
                AllowPaging="true" PagerStyle-ForeColor="White"
                OnPageIndexChanging="Gv1Fault_PageIndexChanging"
                CssClass="gvfault" ShowHeaderWhenEmpty="false" EmptyDataText="No Data to Display!!"
                PagerStyle-BorderStyle="None" DataKeyNames="sno"                
                BackColor="Transparent">
                <HeaderStyle CssClass="hidden-phone" ForeColor="white"
                    Font-Size="Smaller" HorizontalAlign="Center" />
                <RowStyle CssClass=" center" ForeColor="white"
                    Font-Size="Small" HorizontalAlign="Center" />
                <AlternatingRowStyle CssClass=" center" ForeColor="white"
                    Font-Size="Small" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, Select %>">
                        <ItemStyle Width="3%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="<%$Resources:Resource, Sno %>"
                        Visible="false" DataField="sno" />
                    <asp:TemplateField HeaderText="<%$Resources:Resource, DistrictName %>">
                        <ItemStyle Width="6%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("distName")%></ItemTemplate>
                        

                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, Building %>">
                        <ItemStyle Width="6%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("GradeName")%></ItemTemplate>
                        
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="<%$Resources:Resource, ClassName %>">
                        <ItemStyle Width="6%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("ClassName")%></ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, IPAddress %>">
                        <ItemStyle Width="10%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("IP")%></ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, FaultVia %>">

                        <ItemStyle Width="6%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("faultknow")%></ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, PersonToHandle %>">
                        <ItemStyle Width="6%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("memName")%></ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, Phone %>">
                        <ItemStyle Width="6%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("phone")%></ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, Description %>">
                        <ItemStyle Width="10%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("description")%></ItemTemplate>
                        
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="<%$Resources:Resource, Time %>"
                        DataFormatString="{0:F}"
                        DataField="time" HtmlEncode="false">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Last Updated" Visible="false"
                        DataFormatString="{0:F}"
                        DataField="LastUpdated" HtmlEncode="false">
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, Priority %>">
                        <ItemStyle Width="6%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate><%#Eval("priority")%></ItemTemplate>
                        
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, FaultStatus %>">
                        <ItemStyle Width="6%" />
                        <ControlStyle Width="100%" />
                        <ItemTemplate> <%#Eval("stat") %></ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </div>
</asp:Content>
