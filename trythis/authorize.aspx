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
                    AutoGenerateColumns="false" Width="100%" CellPadding="20" CellSpacing="20" 
                    EmptyDataText="<%$Resources:Resource, NoPending %>">
                    <HeaderStyle BackColor="white" Font-Bold="false" HorizontalAlign="Center" 
                        CssClass="table table-striped table-bordered table-hover" ForeColor="#1e1e36"/>
                    <RowStyle ForeColor="white" HorizontalAlign="Center"/>                    
                    <Columns>
                        <asp:BoundField DataField="userid" HeaderText="<%$Resources:Resource, UserID %>" HeaderStyle-HorizontalAlign="Left" />
                        <asp:BoundField DataField="username" HeaderText="<%$Resources:Resource, User %>" HeaderStyle-HorizontalAlign="Left" />
                        <asp:TemplateField HeaderText="<%$Resources:Resource, Role %>">
                            <ItemTemplate>
                                <asp:LinkButton ForeColor="DeepSkyBlue" runat="server" ID="link1" Text="<%$Resources:Resource, Select %>"
                                    OnClick="btnEdit_Click" CssClass="text123"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div id="roleModal" class="modal" style="display: none; max-width: 500px; min-height: 800px; position: absolute;">
                    <div class="modal-content">
                        <p><span><%=Resources.Resource.Role%></span><span onclick="close3();"
                            style="cursor: pointer;float:right;font-size:24px;color:red">&times;</span></p>                        
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                            <asp:ListItem Text="<%$Resources:Resource, Admin %>" Value="1"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, LiveFeed %>" Value="2"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, manageDevice %>" Value="3"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, DocUploadDownload %>" Value="4"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, Maintainance %>" Value="5"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, EditUsers %>" Value="6"></asp:ListItem>                            
                        </asp:CheckBoxList>
                        <asp:Button ID="Button1" runat="server" Text="<%$Resources:Resource, Ok %>"
                            CssClass="btn" OnClick="Button2_Click" />
                    </div>
                </div>
                <div>
                    <br />
                    <h5><%=Resources.Resource.SingleRequestToApprove%></h5>
                <hr />
                <asp:GridView runat="server" ID="TempUserGrid" BorderStyle="None" GridLines="Horizontal"
                    AutoGenerateColumns="false" Width="100%" CellPadding="20" CellSpacing="20" 
                    EmptyDataText="<%$Resources:Resource, NoPending %>">
                     <HeaderStyle BackColor="white" Font-Bold="false" HorizontalAlign="Center" 
                        CssClass="table table-striped table-bordered table-hover" ForeColor="#1e1e36"/>
                    <RowStyle ForeColor="white" HorizontalAlign="Center"/>
                    <Columns>
                         <asp:BoundField HeaderText="<%$Resources:Resource, UserID %>" DataField="userid" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, User %>" DataField="UserName" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Phone %>" DataField="phone" />
                        <asp:BoundField HeaderText ="<%$Resources:Resource, Date %>" DataField="date" DataFormatString="{0:yyyy-MM-dd}"/>
                        <asp:BoundField HeaderText="<%$Resources:Resource, StartTime %>" DataField="starttime" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, StopTime %>" DataField="stoptime" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Descriptionbox %>" DataField="description" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Status %>" DataField="Status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="userapprove" Text="<%$Resources:Resource, Approve %>"
                                    OnClick="userapprove_Click" CssClass="btn btn-outline-light"></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="UserReject" Text="<%$Resources:Resource, Reject %>"
                                    OnClick="UserReject_Click" CssClass="btn btn-outline-light"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
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
