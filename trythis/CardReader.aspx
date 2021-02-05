<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="CardReader.aspx.cs" Inherits="WebCresij.CardReader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
    <link href="css/stepper.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
    <link href="css/Card.css" rel="stylesheet" />
    <script src="Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>

    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="Scripts/CardReader.js?v=4"></script>
    <div style="color:whitesmoke">
        <div class="panel-heading col ">
            <h4 style="color:whitesmoke">
                <p><span ><%=Resources.Resource.CardRegistration%></span></p>
            </h4>
        </div>
        <div class="stepper d-flex flex-column mt-5 ml-2">
            <div class="d-flex mb-1">
                <div class="d-flex flex-column pr-4 align-items-center">
                    <div class="rounded-circle py-2 px-3 bg-primary text-white mb-1">1</div>
                    <div class="line h-100"></div>
                </div>
                <div>
                    <h5 class="text-light"><span><%=Resources.Resource.ScanCard%></span></h5>
                    <p class="lead text-muted pb-3">
                        <span><%=Resources.Resource.ScanCardPara1%></span>
                        <h6 class="text-light"><span><%=Resources.Resource.ScanCardPara2%></span></h6>
                    </p>
                </div>
            </div>
            <div class="d-flex mb-1">
                <div class="d-flex flex-column pr-4 align-items-center">
                    <div class="rounded-circle py-2 px-3 bg-primary text-white mb-1">2</div>
                    <div class="line h-100 "></div>
                </div>
                <div>
                    <h5 class="text-light"><span><%=Resources.Resource.ScanCardPara3%></span></h5>
                    <p class="lead text-muted pb-3">
                        <span><%=Resources.Resource.ScanCardPara4%></span>
                        <h6><span><%=Resources.Resource.ScanCardPara5%></span></h6>
                    </p>
                </div>
            </div>
            <div class="d-flex mb-1">
                <div class="d-flex flex-column pr-4 align-items-center">
                    <div class="rounded-circle py-2 px-3 bg-primary text-white mb-1">3</div>
                    <div class="line h-100 d-none"></div>
                </div>
                <div>
                    <h5 class="text-light"><span><%=Resources.Resource.ScanCardPara6%></span></h5>
                    <p class="lead text-muted pb-3">
                        <span><%=Resources.Resource.ScanCardPara7%></span>
                        <h6><span><%=Resources.Resource.ScanCardPara8%></span> &nbsp;<a class=" linkstyle"
                            style="color: white; text-decoration: underline;" href="editDelCard.aspx">
                            <span><%=Resources.Resource.Here%></span></a>
                        </h6>
                    </p>
                </div>
            </div>
        </div>
        <asp:Label ID="iptosend" runat="server" CssClass="displaynone" Text=""></asp:Label>
        <asp:Label ID="datatosend" runat="server" CssClass="displaynone" Text=""></asp:Label>
        <div id="myModal" class="modal">
            <!-- Modal content -->
            <div class="modal-content" style="width:70%">
                <div class=" row " style="padding-right: 20px; background-color: #4ECDC4">
                    <div class="panel-heading col ">
                        <h4>
                            <p><span><%=Resources.Resource.CardRegistration%></span></p>
                        </h4>
                    </div>
                    <span class="close col" onclick="xx();" style="text-align: right">&times;</span>
                </div>
                <div id="tablescan">
                    <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>
                            <div class="table-responsive col-md-12">
                                <input type="hidden" id="checkcard" value="" />
                                <input type="hidden" id="snoinsert" value="" />
                                <input type="hidden" value="0" id="hiddencount" />
                                <table id="cardtable" style="font-size: Small; border-collapse: collapse;
                                        width: 100%" cellspacing="0" rules="all" border="1">
                                    <thead>
                                        <tr class="table table-striped table-bordered table-hover" align="center"
                                            style="background-color: PaleTurquoise; font-weight: normal;">
                                            <th scope="col"><span><%=Resources.Resource.Sno%></span></th>
                                            <th scope="col"><span><%=Resources.Resource.MemberID%></span></th>
                                            <th scope="col"><span><%=Resources.Resource.PersonName%></span></th>
                                            <th scope="col"><span><%=Resources.Resource.CardID%></span></th>
                                            <th scope="col"><span><%=Resources.Resource.Comments%></span></th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                            <asp:Button CssClass="btn btn-round btn-navbar" runat="server" Width="100px" OnClick="Unnamed_Click"
                                ID="btnSave1" Text="<%$Resources:Resource, Ok %>" />
                            <button type="button" class="btn btn-round btn-navbar" onclick="xx();">
                                <span><%=Resources.Resource.Cancel%></span></button>
                            <asp:Label runat="server" ID="info" Text="" ForeColor="red"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="row" id="griddiv" style="width: 100%">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="panel-body row" style="padding-right: 20px;">
                                <div class="table-responsive col-md-12">
                                    <asp:GridView ID="GridView1" Width="100%" runat="server" ShowHeaderWhenEmpty="true"
                                        ViewStateMode="Enabled" RowStyle-HorizontalAlign="Center" 
                                        EmptyDataRowStyle-ForeColor="White"
                                        EmptyDataRowStyle-BackColor="Black" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="PaleTurquoise" Font-Bold="false" HorizontalAlign="Center"
                                            CssClass="table table-striped table-bordered table-hover" />
                                        <RowStyle BackColor="LightCyan"
                                            ForeColor="black"
                                            Font-Italic="false" />
                                        <AlternatingRowStyle BackColor="White"
                                            ForeColor="black"
                                            Font-Italic="false" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Sno" DataField="sno">
                                                <ItemStyle Width="5%" />
                                                <ControlStyle Width="100%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="<%$Resources:Resource, MemberID %>" DataField="memIDs">
                                                <ItemStyle Width="5%" />
                                                <ControlStyle Width="100%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="<%$Resources:Resource, PersonName %>" DataField="name">
                                                <ItemStyle Width="10%" />
                                                <ControlStyle Width="100%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="<%$Resources:Resource, CardID %>" DataField="cardIds">
                                                <ItemStyle Width="8%" />
                                                <ControlStyle Width="100%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="<%$Resources:Resource, Comments %>" DataField="comments">
                                                <ItemStyle Width="15%" />
                                                <ControlStyle Width="100%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="<%$Resources:Resource, Status %>" DataField="states">
                                                <ItemStyle Width="7%" />
                                                <ControlStyle Width="100%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="<%$Resources:Resource, AccessPermitted %>" DataField="access">
                                                <ItemStyle Width="40%" />
                                                <ControlStyle Width="100%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="<%$Resources:Resource, SelectAccess %>">
                                                <ItemStyle Width="10%" />
                                                <ControlStyle Width="100%" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="selectAccessTree" runat="server"
                                                        Text="<%$Resources:Resource, Select %>" CssClass="linkcursor"
                                                        OnClientClick="openTreeModal(); return false;" OnClick="openaccess_Click">
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <asp:Button CssClass="btn btn-round btn-navbar" runat="server" Width="100px" OnClick="btnSave_Click"
                                ID="btnSave" Text="<%$Resources:Resource, Register %>" />
                            <asp:Button CssClass="btn btn-round btn-navbar" runat="server" Width="100px"
                                OnClick="btnCancel_Click" Text="<%$Resources:Resource, Cancel %>" ID="btnCancel" />
                            <br />
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="modal sidebar-menu" id="modalAccess" style="max-height: 700px; display: none; overflow-y: auto">
            <div class="modal-content" style="width: 600px">
                <span class="close1" id="modalClose" style="text-align: right">
                    <i class="fa fa-times" aria-hidden="true"></i></span>
                <h3><span><%=Resources.Resource.Select%></span></h3>
                <asp:UpdatePanel runat="server" ID="selectAccessPanel">
                    <ContentTemplate>
                        <asp:TreeView ShowCheckBoxes="All" ID="TreeView1" NodeStyle-NodeSpacing="1"
                            runat="server">
                        </asp:TreeView>
                        <%-- <button onclick="GetSelected()">select</button>--%>
                        <asp:Button Text="<%$Resources:Resource, getSelected %>" runat="server"
                            ID="btnToSelect" OnClick="addAccess_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <input id="hfSelected" type="hidden" runat="server" />
            </div>
        </div>
    </div>
    <script>
        $(document).on("click", ".close1", function () {
            var modal = document.getElementById('modalAccess');
            modal.style.display = "none";
            inputs = document.getElementsByTagName("input");
            for (i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    inputs[i].checked = false;
                }
            }
        });
        $(document).on("click", ".linkcursor", function () {
            var modal = document.getElementById('modalAccess');
            modal.style.display = "block";
        });

        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
        function isNameKey(evt) {
            var x = (evt.which) ? evt.which : event.keyCode;
            var c = String.fromCharCode(x);
            if (/^[A-Za-z ._-]+$/.test(c)) {
                return true;
            }
            else {
                alert("A name can contain letters, dot, hyphen and underscore only");
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterSideBody" runat="server">
</asp:Content>
