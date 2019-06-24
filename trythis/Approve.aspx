<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="WebCresij.Approve" %>

<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ID="Head" ContentPlaceHolderID="masterHead" runat="server">
    <style>
        .leftspace {
            margin-left: 20px;
            width: inherit;
            margin-right: 20px;
            height: inherit;
            margin-bottom: 20px;
        }

        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="masterBody" runat="server">
    <script src="Scripts/approve.js?v=7"></script>
    <div class="divopt">
        <h3><span><%=Resources.Resource.AuthorizeUser%></span></h3>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="gv2" runat="server" AutoGenerateColumns="false" Width="100%">
                    <HeaderStyle BackColor="PaleTurquoise" Font-Bold="false" HorizontalAlign="Center" CssClass="table table-striped table-bordered table-hover" />
                    <RowStyle BackColor="LightCyan"
                        ForeColor="black"
                        Font-Italic="false" />
                    <AlternatingRowStyle BackColor="White"
                        ForeColor="black"
                        Font-Italic="false" />
                    <Columns>
                        <asp:BoundField DataField="User_ID" HeaderText="<%$Resources:Resource, UserID %>" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="User_Name" HeaderText="<%$Resources:Resource, User %>" HeaderStyle-HorizontalAlign="Left" />
                        <asp:TemplateField HeaderText="<%$Resources:Resource, Role %>">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="link1" Text="<%$Resources:Resource, Select %>"
                                    OnClick="btnEdit_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div id="Permissions" class=" displayplease" style="display: none">
                    <div class="modal-content" style="width: 400px">
                        <header>
                            <span onclick="del();"
                                class="w3-button w3-display-topright">&times;</span>
                            <h3><span><%=Resources.Resource.AuthUser%></span></h3>
                        </header>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div>
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                                        <asp:ListItem Text="<%$Resources:Resource, Admin %>" Value="1" ></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource, LiveFeed %>" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource, manageDevice %>" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource, DocUploadDownload %>" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource, DocDelete %>" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="<%$Resources:Resource, EditUsers %>" Value="6"></asp:ListItem> 
                                        
                                    </asp:CheckBoxList>
                                    <br />
                                    <asp:Button ID="Button2" runat="server" Text="<%$Resources:Resource, Save %>" OnClick="Button2_Click"
                                        BorderColor="Gray" CssClass="btn btn-default"/>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:HiddenField ID="userIdhid" runat="server" Value="" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Button runat="server" CssClass="linkCursor" Text="click me!" ID="btn1" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
