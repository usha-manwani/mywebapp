<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="authorize.aspx.cs" Inherits="WebCresij.authorize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
    <script src="Scripts/approve.js?v=2"></script>
    <div class="divopt">
        <h3><span><%=Resources.Resource.AuthorizeUser%></span></h3>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView ID="gv2" runat="server" BorderStyle="None" GridLines="Horizontal"
                    AutoGenerateColumns="false" Width="100%" EmptyDataText="<%$Resources:Resource, NoPending %>">
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
                                    OnClick="btnEdit_Click" CssClass="text123"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div id="idiot" class="modal" style="display: none; max-width: 500px; min-height: 800px; position: absolute;">

                    <div class="modal-content">
                        <p><span><%=Resources.Resource.Role%></span></p>
                        <span onclick="close3();"
                            class="w3-button w3-display-topright">&times;</span>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                            <asp:ListItem Text="<%$Resources:Resource, Admin %>" Value="1"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, LiveFeed %>" Value="2"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, manageDevice %>" Value="3"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, DocUploadDownload %>" Value="4"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, DocDelete %>" Value="5"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, EditUsers %>" Value="6"></asp:ListItem>
                        </asp:CheckBoxList>

                        <asp:Button ID="Button1" runat="server" Text="<%$Resources:Resource, Ok %>"
                            CssClass="btn" OnClick="Button2_Click" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:HiddenField ID="userIdhid" runat="server" Value="" />
    <script type="text/javascript">
//$(function () {
//    alert("javascript working");
//    $(document).on('click', '.text123', function () {
//        var closestTr = $(this).closest('tr');

//        alert(closestTr.cells[0].innerText);
//        var modal = document.getElementById("idiot");
//        modal.style.display = "block";
//        return false;
//    });

//        alert("javascript not working");

        //        });

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterSideBody" runat="server">
</asp:Content>
