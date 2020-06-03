<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Maintainance.aspx.cs" Inherits="WebCresij.Maintainance" EnableEventValidation="false"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /* Fixed sidenav, full height */
        .sidenav1 {
            height: 100%;
            width: 240px;
            position: fixed;
            z-index: 1;
            top: 0;
            left: 0;
            background-color: #232140;
            overflow-x: hidden;
            padding-top: 80px;
        }

            /* Style the sidenav links and the dropdown button */
            .dropdown-btn, .sidenav1 span {
                padding: 6px 8px 6px 16px;
                text-decoration: none;
                font-size: 20px;
                color: #818181;
                display: block;
                border: none;
                background: none;
                width: 100%;
                text-align: left;
                cursor: pointer;
                outline: none;
            }

                /* On mouse-over */
                .sidenav1 span:hover, .dropdown-btn:hover {
                    color: #f1f1f1;
                }

        /* Main content */
        .main1 {
            margin-left: 250px; /* Same as the width of the sidenav */
            /*font-size: 20px;*/ /* Increased text to enable scrolling */
            padding: 0px;
            padding-top: 40px;
        }

        /* Add an active class to the active dropdown button */
        .active {
            background-color: #23233f;
            color: white;
        }

        /* Dropdown container (hidden by default). Optional: add a lighter background 
            color and some left padding to change the design of the dropdown content */
        .dropdown-container {
            display: none;
            background-color: #1e1e36;
            padding-left: 8px;
        }

        /*Optional: Style the caret down icon*/
        .fa-caret-down {
            float: right;
            margin-right: 10px;
        }

        /* Some media queries for responsiveness */
        @media screen and (max-height: 450px) {
            .sidenav1 {
                padding-top: 15px;
            }

                .sidenav1 span {
                    font-size: 18px;
                }
        }

        .modal {
            display: none; /* Hidden by default */
            position: fixed center; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 80px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow-y: no-display;
            /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.5); /* Black w/ opacity */
        }

        .modal-content {
            background-color: #1e1e36;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 500px;
            height: 400px;
        }

        .nodisplay {
            display: none
        }

        .tab {
            overflow: hidden;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
        }

            /* Style the buttons inside the tab */
            .tab button {
                background-color: inherit;
                float: left;
                border: none;
                outline: none;
                cursor: pointer;
                padding: 14px 16px;
                transition: 0.3s;
                font-size: 17px;
            }

                /* Change background color of buttons on hover */
                .tab button:hover {
                    background-color: #ddd;
                }

                /* Create an active/current tablink class */
                .tab button.active {
                    background-color: #ccc;
                }

        /* Style the tab content */
        .tabcontent {
            display: none;
            padding: 6px 12px;
        }

        .divstyle {
            background-color: #191b28;
            color: white;
            -moz-box-shadow: inset 0 0 15px #000000;
            -webkit-box-shadow: inset 0 0 15px #000000;
            box-shadow: inset 0 0 15px #000000;
            border-width: 2px 10px 10px 2px;
            margin-left: 15px;
            margin-right: 15px;
            min-width:500px;
        }

        .progressbar {
            background-color: white;
            border-radius: 2px; /* (height of inner div) / 2 + padding */
            padding: 0;
            margin-top: 6px;
            margin-bottom: 9px;
        }

            .progressbar > div {
                /* Adjust with JavaScript */
                max-height: 5px;
                height: 5px;
                border-radius: 2px;
                padding-bottom: 5px;
                padding-top:5px;
                
            }

        .pt-3-half {
            padding-top: 1.4rem;
        }
        .card{
            border-radius:20%!important;
            min-width:150px!important;
        }
        .borderRadius{
            border-radius:4px;
        }
        .textboxclass{
            min-width:420px;
            background-color:transparent;
            border-style:none;
            color:white;
        }
        .gridborder{
            border-style:none;
        }
        .TextBoxEditMode{
            border:1px solid white;
        }
        .hoverMode{

        }
        .hoverMode:hover{
            color:white;
        }
        .selected:visited{
            background-color:cadetblue
        }
        .buttonEffect {
            cursor: pointer;
            border-bottom: 1px solid #4ecdc4;
            color: white
        }

            .buttonEffect:focus {
                -webkit-box-shadow: 0px 0px 2px 2px rgba(119,204,238, 0.67);
                -moz-box-shadow: 0px 0px 2px 2px rgba(119,204,238, 0.67);
                box-shadow: 0px 0px 2px 2px rgba(119,204,238, 0.67);
                transform: translateY(1px);
                background-color:#4ecdc4;
            }

            .buttonEffect:hover {
                -webkit-border-radius: 5px;
                -moz-border-radius: 5px;
                border-radius: 5px;
                -webkit-box-shadow: 0px 0px 2px 2px rgba(119,204,238, 0.67);
                -moz-box-shadow: 0px 0px 2px 2px rgba(119,204,238, 0.67);
                box-shadow: 0px 0px 2px 2px rgba(119,204,238, 0.67);
                background-color:#4ecdc4;
            }
            .displayNone{
                display:none;
            }
            .gvfault{
                max-width:100%!important;
                min-width:1000px;
                padding-right:15px
            }
            .styling{
                height:60px!important;
                margin:-30px 10px -10px 0px;
                
            }
            .row{
                width:100%!important;
            }
    </style>
    <link href="assets/css/charts.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 20px">
        <div class="sidenav1" style="margin-top: 20px">
            <span><%=Resources.Resource.BuildingMgmt%></span>
            <span class="dropdown-btn "><%=Resources.Resource.InspectionLog%>
                <i class="fa fa-caret-down "></i>
            </span>
            <div class="dropdown-container">
                <span id="inspection"><%=Resources.Resource.InspectionLog%></span>
            </div>
            <span id="maintainanceMgmt" ><%=Resources.Resource.Maintainance%></span>
            <span class="dropdown-btn"><%=Resources.Resource.FaultMgmt%>
                <i class="fa fa-caret-down"></i>
            </span>
            <div class="dropdown-container">
                <span id="faultinfo" "><%=Resources.Resource.FaultInfo%></span>
                <span id=" Dispatch" "><%=Resources.Resource.DispatchMgmt%></span>
                <span id="statistics" ><%=Resources.Resource.Stat%></span>
            </div>
        </div>
        <div class="main1" id="faultinfos" style="display: none">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <asp:LinkButton runat="server" ID="AddNewFault" 
                           OnClick="AddNewFault_Click" class="btn btn-light">
                           <i class="fas fa-plus" aria-hidden="true"></i>&nbsp;
                           <span><%=Resources.Resource.Add%> </span>
                        </asp:LinkButton>
                        &nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="Lnkdeleteall" 
                           OnClick="DeleteAll" class="btn btn-light" CausesValidation="false">
                           <i class='fa fa-minus-circle' aria-hidden="true"></i>&nbsp;
                           <span><%=Resources.Resource.Delete%> </span>
                        </asp:LinkButton>
                        <%--<button class="btn btn-light"  runat="server"
                        id="btnDelete" onserverclick="DeleteAll">
                        <i class='fa fa-minus-circle' aria-hidden='true'></i>&nbsp;
                        <%=Resources.Resource.Delete%></button>--%>&nbsp;&nbsp;
                        <asp:LinkButton runat="server" ID="exportToExcel" 
                           OnClick="exportToExcel_Click" class="btn btn-light">
                           <i class="fa fa-file-export" aria-hidden="true"></i>&nbsp;
                           <span><%=Resources.Resource.export%> </span>
                        </asp:LinkButton>
                        <%-- <span  class="btn btn-light">
                        <i class="fa fa-file-export" aria-hidden="true">
                        </i>&nbsp;<%=Resources.Resource.export%></span>--%>&nbsp;&nbsp;
                        <%--<asp:LinkButton runat="server" CssClass="btn btn-light"
                            id="btnFaultUpdate" OnClick="btnFaultUpdate_Click">
                            <i class="fa fa-edit" aria-hidden="true"></i>&nbsp;
                            <span><%=Resources.Resource.update%></span>
                        </asp:LinkButton>--%>
                    
                        <span class="btn btn-light">
                        <i class="fa fa-cog" aria-hidden="true"></i>&nbsp;
                        <%=Resources.Resource.btnwork%></span>
                    </div>            
                    <div class="row">
                        <div class="col-xl-12 col-lg-12 col-sm-12 col-md-12">
                       
                        <asp:GridView runat="server" ID="gv1Fault" 
                            AutoGenerateColumns="false" PageSize="10" Width="95%"
                            AllowPaging="true" PagerStyle-ForeColor="White"
                            OnPageIndexChanging="Gv1Fault_PageIndexChanging"                             
                            CssClass="gvfault" ShowHeaderWhenEmpty="true" 
                            PagerStyle-BorderStyle="None" DataKeyNames="sno"
                            OnRowDataBound="Gv1Fault_RowDataBound"
                            BackColor="Transparent" 
                            OnRowCommand="gv1Fault_RowCommand"
                             OnRowEditing="gv1Fault_RowEditing"
                            OnRowCancelingEdit="gv1Fault_RowCancelingEdit"
                             OnRowUpdating="gv1Fault_RowUpdating">
                            <HeaderStyle CssClass="hidden-phone" ForeColor="white" 
                                Font-Size="Smaller" HorizontalAlign="Center" />
                            <RowStyle CssClass=" center" ForeColor="white"
                                Font-Size="Small" HorizontalAlign="Center" />
                            <AlternatingRowStyle CssClass=" center" ForeColor="white"
                                Font-Size="Small" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="<%$Resources:Resource, Select %>">
                                    <ItemStyle Width="3%" /><ControlStyle Width="100%" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="<%$Resources:Resource, Sno %>"
                                    Visible="false" DataField="sno"/>
                                <asp:TemplateField HeaderText="<%$Resources:Resource, DistrictName %>">
                                     <ItemStyle Width="6%" /><ControlStyle Width="100%" />
                                     <ItemTemplate> <%#Eval("distName")%></ItemTemplate>   
                                        <EditItemTemplate><%#Eval("distName")%>
                                        </EditItemTemplate>
                                     <FooterStyle Width="8%" />
                                        <FooterTemplate>
                                        <asp:TextBox ID="newdistName" runat="Server"/>                    
                                        </FooterTemplate>
                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:Resource, Building %>">
                                     <ItemStyle Width="6%" /><ControlStyle Width="100%" />
                                     <ItemTemplate> <%#Eval("GradeName")%></ItemTemplate>   
                                        <EditItemTemplate><%#Eval("GradeName")%></EditItemTemplate>                
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="<%$Resources:Resource, ClassName %>">
                                    <ItemStyle Width="6%" /><ControlStyle Width="100%" />
                                    <ItemTemplate> <%#Eval("ClassName")%></ItemTemplate>   
                                        <EditItemTemplate><%#Eval("ClassName")%>
                                        </EditItemTemplate>                
                                       
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Machine IP">
                                    <ItemStyle Width="10%" /><ControlStyle Width="100%" />
                                    <ItemTemplate> <%#Eval("IP")%></ItemTemplate>   
                                        <EditItemTemplate><%#Eval("IP")%>
                                       
                                        </EditItemTemplate>
                                    <FooterStyle Width="8%" />
                                    <FooterTemplate>
                                        <asp:TextBox ID="newIP" runat="server" 
                                            placeHolder="System IP Address"></asp:TextBox>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:Resource, FaultVia %>">
                                    
                                    <ItemStyle Width="6%" /><ControlStyle Width="100%" />
                                        <ItemTemplate> <%#Eval("faultknow")%></ItemTemplate>   
                                        <%--<EditItemTemplate><%#Eval("faultknow")%>
                                        
                                        </EditItemTemplate> 
                                    <FooterStyle Width="8%" />
                                        <FooterTemplate>
                                        <asp:TextBox ID="newfaultknow" runat="Server"/>                    
                                        </FooterTemplate>--%>
                                 </asp:TemplateField>                               
                                 <asp:TemplateField HeaderText="<%$Resources:Resource, PersonToHandle %>">
                                    <ItemStyle Width="6%" /><ControlStyle Width="100%" />
                                    <ItemTemplate> <%#Eval("memName")%></ItemTemplate>   
                                        <EditItemTemplate>
                                        <asp:TextBox id="txtmemName" runat="server"
                                            text='<%#Eval("memName")%>'/>
                                        </EditItemTemplate> 
                                    <FooterStyle Width="8%" />
                                        <FooterTemplate>
                                        <asp:TextBox ID="newmemName" runat="Server"/>                    
                                        </FooterTemplate>                                   
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:Resource, Phone %>">
                                    <ItemStyle Width="6%" /><ControlStyle Width="100%" />
                                    <ItemTemplate> <%#Eval("phone")%></ItemTemplate>   
                                        <EditItemTemplate>
                                        <asp:TextBox id="txtphone" runat="server"
                                            text='<%#Eval("phone")%>'/>
                                        </EditItemTemplate> 
                                    <FooterStyle Width="8%" />
                                        <FooterTemplate>
                                        <asp:TextBox ID="newphone" runat="Server"/>                    
                                        </FooterTemplate>                                    
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<%$Resources:Resource, Description %>">
                                    <ItemStyle Width="10%" /><ControlStyle Width="100%" />
                                    <ItemTemplate> <%#Eval("description")%></ItemTemplate>   
                                        <EditItemTemplate>
                                        <asp:TextBox id="txtdescription" runat="server"
                                            text='<%#Eval("description")%>'/>
                                        </EditItemTemplate> 
                                    <FooterStyle Width="8%" />
                                        <FooterTemplate>
                                        <asp:TextBox ID="newdescription" runat="Server"/>                    
                                        </FooterTemplate>                                    
                                </asp:TemplateField>
                               
                                <asp:BoundField HeaderText="<%$Resources:Resource, Time %>" 
                                    DataFormatString="{0:F}"
                                    DataField="time"  HtmlEncode="false" >
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Last Updated" 
                                    DataFormatString="{0:F}"
                                    DataField="LastUpdated"  HtmlEncode="false" >
                                    <ItemStyle Width="10%" />
                                </asp:BoundField>
                                  <asp:TemplateField HeaderText="<%$Resources:Resource, Priority %>">
                                    <ItemStyle Width="6%" /><ControlStyle Width="100%" />
                                    <ItemTemplate> <%#Eval("priority")%></ItemTemplate>   
                                        <EditItemTemplate>
                                            <asp:DropDownList runat="server" ID="ddlPriority"
                                                 CssClass="btn btn-default border-light" 
                                                ForeColor="White" BackColor="#1E1E36"
                                                selectedValue='<%#Eval("priority") %>'>
                                                <asp:ListItem Text="<%$Resources:Resource, Low %>" Value="Low"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Medium %>" Value="Medium"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, High %>" Value="High"></asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:TextBox ID="txtPriority" runat="server"
                                                Text='<%#Eval("priority")%>' />--%>
                                        </EditItemTemplate> 
                                    <FooterStyle Width="8%" />
                                        <FooterTemplate>
                                            <asp:DropDownList runat="server" ID="ddlnewPriority"
                                                  CssClass="btn btn-default border-light" 
                                                ForeColor="White" BackColor="#1E1E36">
                                                <asp:ListItem Text="<%$Resources:Resource, Low %>" Value="Low"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, Medium %>" Value="Medium"></asp:ListItem>
                            <asp:ListItem Text="<%$Resources:Resource, High %>" Value="High"></asp:ListItem>
                                            </asp:DropDownList>
                                        <%--<asp:TextBox ID="newpriority" runat="Server"/> --%>                   
                                        </FooterTemplate>
                                    
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="<%$Resources:Resource, FaultStatus %>">
                                    <ItemStyle Width="6%" /><ControlStyle Width="100%" />
                                    <ItemTemplate> <%#Eval("stat") %></ItemTemplate>   
                                        <EditItemTemplate>
                                            <asp:DropDownList runat="server" ID="ddlStat"  
                                                 CssClass="btn btn-default border-light"
                                                 selectedValue='<%#Eval("stat") %>'
                                                ForeColor="White" BackColor="#1E1E36">
                                                <asp:ListItem Text="<%$Resources:Resource, Pending %>" Value="Pending"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Resolved %>" Value="Resolved"></asp:ListItem>
                                            </asp:DropDownList>
                                       <%--     <asp:TextBox ID="txtstat" runat="server"
                                                Text='<%#Eval("stat") %>' />--%>
                                        </EditItemTemplate> 
                                    <FooterStyle Width="8%" />
                                        <FooterTemplate>
                                            <asp:DropDownList runat="server" ID="ddlnewStat"
                                                CssClass="btn btn-default border-light"
                                                ForeColor="White" BackColor="#1E1E36">
                                                <asp:ListItem Text="<%$Resources:Resource, Pending %>" Value="Pending"></asp:ListItem>
                                                <asp:ListItem Text="<%$Resources:Resource, Resolved %>" Value="Resolved"></asp:ListItem>
                                            </asp:DropDownList>
                                        <%--<asp:TextBox ID="newstat" runat="Server"/>      --%>              
                                        </FooterTemplate>                                    
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="<%$Resources:Resource, Options %>">
                                    <ItemStyle Width="7%"/>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkdelete" runat="server" ForeColor="Yellow"
                                            Font-Size="Large" OnClick="lnkdelete_Click" >
                                            <i class="far fa-trash-alt" aria-hidden="true"></i>
                                        </asp:LinkButton>&nbsp;&nbsp;
                                        
                                        <asp:LinkButton ID="LinkUpdateFault" runat="server" ForeColor="Yellow"
                                                 Font-Size="Large" CommandName="Edit">
                                            <i class="fa fa-edit" aria-hidden="true"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="btnupdate" runat="server" 
                                            CommandName="Update" Text="<%$Resources:Resource, update %>" />
                                        <asp:LinkButton ID="btncancel" runat="server" 
                                            CommandName="Cancel" Text="<%$Resources:Resource, Cancel %>"/>
                                    </EditItemTemplate>
                                    
                                    <FooterTemplate>
                                        <asp:LinkButton ID="lnkInsertFault" runat="server"
                                            Font-Size="12px" UseSubmitBehavior="False"
                                            ForeColor="Yellow" CommandName ="Insert" Text="<%$Resources:Resource, Save%>">
                                            <i class="fa fa-plus" aria-hidden="true"></i>
                                            
                                        </asp:LinkButton>
                                    </FooterTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                            
                        </asp:GridView>
                         </div>
                       <script runat="server">
                            public override void VerifyRenderingInServerForm(Control control)
                            {
                                /* Verifies that the control is rendered */
                            }
                       </script>
                    </div>
                    <div class="modal" id="editDetailtoAssign">
                        <div class="modal-content  positionCenter">
                            <header class="row" style="position: center;">
                                <span onclick="document.getElementById('editDetailtoAssign').style.display='none'"
                                    class="w3-button w3-display-topright">&times;</span>
                            </header>
                            <div class="form-group row">
                                <asp:Label runat="server" Text="User Name"
                                    AssociatedControlID="userNametoWork"
                                    CssClass="control-label col-4"> </asp:Label>
                                <asp:TextBox ID="userNametoWork" CssClass="form-control col-6"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group row">

                                <asp:Label runat="server" Text="Serial No."
                                    ID="snolabel" AssociatedControlID="snotxt"
                                    CssClass="control-label col-4"> </asp:Label>
                                <asp:TextBox ID="snotxt" CssClass="form-control col-6" 
                                    runat="server" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="form-group row">

                                <asp:Label runat="server" Text="Date" 
                                    AssociatedControlID="timetxt" CssClass="control-label col-4"> </asp:Label>
                                <asp:TextBox ID="timetxt" 
                                    CssClass="form-control col-6" Enabled="false" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group row">

                                <asp:Label runat="server" Text="Assign To" AssociatedControlID="assigntxt"
                                    CssClass="control-label col-4"> </asp:Label>
                                <asp:TextBox ID="assigntxt" CssClass="form-control col-6" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group row">
                                <asp:Button runat="server" ID="btneditok" CssClass="btn btn-light"
                                    Text="ok" Width="100px" OnClick="btneditok_Click" />
                                <button onclick="noModal();return false;" 
                                    style="width: 100px; margin-left: 20px" class="btn btn-light">Cancel</button>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div id="inspectionLogs" class="main1" style="display: none">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView runat="server" ID="gvinspect" AutoGenerateColumns="false"
                        PageSize="10" Width="95%" PagerStyle-ForeColor="White"
                        AllowPaging="true" OnPageIndexChanging="gvinspect_PageIndexChanging"                        
                        PagerStyle-BorderStyle="None" OnRowDataBound="gvinspect_RowDataBound"
                        DataKeyNames="sno" EmptyDataText="No Data to Display !!">
                        <HeaderStyle CssClass="hidden-phone" ForeColor="WhiteSmoke" 
                            Font-Size="Smaller" HorizontalAlign="Center" />
                        <RowStyle CssClass=" center" BackColor="White" 
                            Font-Size="Small" HorizontalAlign="Center" />
                        <AlternatingRowStyle CssClass=" center" 
                            BackColor="WhiteSmoke" Font-Size="Small" HorizontalAlign="Center" />
                        <Columns>

                            <asp:BoundField HeaderText="<%$Resources:Resource, Sno %>" DataField="sno" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, DistrictName %>"
                                DataField="distName" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, SchoolName %>" 
                                DataField="sName" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, BuildingName %>"
                                DataField="bName" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, ClassName %>"
                                DataField="className" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, PersonToHandle %>"
                                DataField="memName" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Projector %>"
                                DataField="projStat" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Screen %>" 
                                DataField="screenStat" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, CentralControl %>"
                                DataField="CCStat" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Computer %>" 
                                DataField="computer" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Speaker %>"
                                DataField="speaker" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Wirelessmic %>"
                                DataField="wireless" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Wiredmic %>"
                                DataField="wired" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, platform %>"
                                DataField="platform" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Phone %>"
                                DataField="phone" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Time %>"
                                DataFormatString="{0:F}"
                                DataField="time" HtmlEncode="false" />
                            <asp:BoundField HeaderText="<%$Resources:Resource, Description %>"
                                DataField="description" />
                            <asp:TemplateField HeaderText="<%$Resources:Resource, Options %>">
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdeleteInspect" runat="server" 
                                        CssClass="btn btn-info"
                                        Font-Size="12px" OnClick="lnkdeleteInspect_Click">
                                    <i class="fa fa-minus-circle" aria-hidden="true"></i>
                                        <%=Resources.Resource.Delete%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="Dispatchmgmt" class="main1" style="display: none">
        </div>
        <div id="stats" class="main1" style="display: none">
            <div>
                <h4><%=Resources.Resource.Stat%></h4>

                <div class="tab">
                    <button class="tablinks" onclick="openIssueStats(); return false">
                        <%=Resources.Resource.mgmttab1%></button>
                    <button class="tablinks" onclick="openParis(); return false">
                        <%=Resources.Resource.mgmttab2%></button>
                    <button class="tablinks" onclick="OpenTokyo(); return false">
                        <%=Resources.Resource.mgmttab3%></button>
                </div>
                <div>
                    <span style="font-size: 24px; color: white">
                        <i class="fa fa-chart-bar" aria-hidden="true"></i>&nbsp;
                    <%=Resources.Resource.issueStats%></span>
                </div>
                <div id="issueStats" class="tabcontent">
                    <div style="height: 400px; width: 400px; margin-left: 200px"
                        id="issueStats1"></div>
                    <div style="margin-left: -50px">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView runat="server" ID="gvChart" 
                                    AutoGenerateColumns="false" PageSize="10" Width="99%"
                                    AllowPaging="true" OnPageIndexChanging="gvChart_PageIndexChanging"
                                    PagerStyle-ForeColor="White"
                                    PagerStyle-BorderStyle="None">
                                    <HeaderStyle CssClass="hidden-phone" ForeColor="WhiteSmoke"
                                        Font-Size="Smaller" HorizontalAlign="Center" />
                                    <RowStyle CssClass=" center" BackColor="White" 
                                        Font-Size="Smaller" HorizontalAlign="Center" />
                                    <AlternatingRowStyle CssClass=" center" 
                                        BackColor="WhiteSmoke" Font-Size="Smaller" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField HeaderText="<%$Resources:Resource, DistrictName %>"
                                            DataField="distName" />
                                        <asp:BoundField HeaderText="<%$Resources:Resource, Resolved %>" 
                                            DataField="Resolved" />
                                        <asp:BoundField HeaderText="<%$Resources:Resource, Pending %>"
                                            DataField="Pending" />
                                    </Columns>

                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div id="Paris" class="tabcontent">
                    <h3>Building</h3>
                    <p>Paris is the capital of France.</p>
                </div>

                <div id="Tokyo" class="tabcontent">
                    <h3>Group</h3>
                    <p>Tokyo is the capital of Japan.</p>
                </div>
            </div>
        </div>
        <div id="mainStats" class="main1 " style="padding-right: 40px;">
            <div class="row">

                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="card" style="height: 180px;">
                        <div class="card-body" style="background-color: #df683a; color: white">
                            <div class=" float-left" style="width: 70%">
                                <h4><span><%=Resources.Resource.FaultyDevices%></span></h4>
                                <h4>
                                    <span id="FaultyDevices" class="count float-left ">0</span>
                                </h4>
                            </div>
                            <!-- /.card-left -->
                            <div class=" float-right text-right" style="width: 30%">
                                <i class="fa fa-tools" style="font-size: 2em; color: #8a3c1d"></i>
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>

                <div class=" col-lg-3 col-md-6 col-sm-6">
                    <div class="card" style="height: 180px;">
                        <div class="card-body" style="background-color: #dfc43a; color: white">
                            <div class=" float-left" style="width: 70%">
                                <h4><span><%=Resources.Resource.UnresolvedIssues%></span></h4>
                                <h4>
                                    <span id="UnresolvedIssues" class="count float-left ">0</span>
                                </h4>
                            </div>
                            <!-- /.card-left -->
                            <div class=" float-right text-right" style="width: 30%">
                                <i class="fa fa-cogs" style="font-size: 2em; color: #83752e"></i>
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="card" style="height: 180px;">
                        <div class="card-body" style="background-color: #2c95af; color: white">
                            <div class="float-left" style="width: 70%">
                                <h4><span><%=Resources.Resource.TotalResolved%></span></h4>
                                <h4>
                                    <span id="totalResolved" class="count float-left ">0</span>
                                </h4>
                            </div>
                            <!-- /.card-left -->
                            <div class=" float-right text-right" style="width: 30%">
                                <i class="fas fa-recycle" style="font-size: 2em; color: #1c5a69"></i>
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>

                <div class="col-lg-3 col-md-6 col-sm-6">
                    <div class="card" style="height: 180px;">
                        <div class="card-body" style="background-color: #3c7526; color: white">
                            <div class="float-left" style="width: 70%">
                                <h4><span><%=Resources.Resource.FixedToday%></span></h4>
                                <h4>
                                    <span id="fixedToday" class="count float-left ">0</span>
                                </h4>
                            </div>
                            <!-- /.card-left -->
                            <div class=" float-right text-right" style="width: 30%">
                                <i class="fa fa-cog" style="font-size: 2em; color: #1a410b"></i>
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
            <div class=" row divstyle" style="color: white">
                <div class="col-lg-12 col-sm-12 col-md-12" style="min-height: 300px;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                             <span><%=Resources.Resource.SelectInstitute%>  </span>
                            <asp:DropDownList Width="100px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                                CssClass="btn btn-default border-light" ID="ddlInstitute"
                                runat="server" ForeColor="White" BackColor="#191b28">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />
                    <h5 style="border-bottom: 1px solid #3b3f39; margin-top:-20px; text-align:center">
                        <%=Resources.Resource.unresolvedbyBuilding%></h5>                    
                    <div class="row" style="border-bottom: 1px solid #3b3f39; 
                    margin-bottom:-10px; margin-top:-20px; ">
                        <div class="col-lg-3 col-md-3 col-sm-3" style="float: left;
                             font-weight:600">
                            <span><%=Resources.Resource.BuildingName%></span>
                        </div>
                        <div class="col-lg-7 col-md-7 col-sm-6" style="float: left;
                            text-align:center; font-weight:600">
                            <%=Resources.Resource.Issue%>
                        </div>
                        
                        <div class="col-lg-2 col-md-2 col-sm-3" style="float: right;
                            text-align:center; font-weight:600">
                            <%=Resources.Resource.IssuesResolved%>
                        </div>
                    </div>
                    <div  id="progressdiv">
                  
                        </div>
                </div>                   
            </div>
            <div style="clear: both"></div>
            <div class="row divstyle" style="margin-top: 20px">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                   <div>
                       <h5><%=Resources.Resource.MyTasks%>
                           <asp:LinkButton runat="server" ID="AddNewTask" OnClick="AddNewTask_Click"
                                CssClass="table-add float-right mb-3 mr-2" ForeColor="#28a745">
                                <i class="fas fa-plus fa-2x" aria-hidden="true"></i></asp:LinkButton>
                       </h5>
                           </div>                                   
                            
                            <asp:GridView runat="server" ID="gvInputTask" AutoGenerateColumns="false"
                            Width="100%" ShowHeader="false" GridLines="Horizontal" 
                            BorderStyle="none" CellPadding="10" OnRowCommand="gvInputTask_RowCommand"
                            OnRowEditing="gvInputTask_RowEditing" OnRowUpdating="gvInputTask_RowUpdating"
                            OnRowDeleting="gvInputTask_RowDeleting" OnRowDataBound="gvInputTask_RowDataBound">
                                <RowStyle BackColor="#184197"/>
                                <AlternatingRowStyle BackColor="#263f75"/>                     
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="idOfTask" Visible="false"
                                                Text='<%#Eval("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField Visible="false" DataField="Id" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" Text='<%#Eval("Task") %>'
                                                ID="tasktext" Width="100%" CssClass="textboxclass"
                                                Enabled="false"></asp:TextBox>
                                            <i class="fa fa-clock" aria-hidden="true"
                                                style="background-color: transparent; color: yellow"></i>
                                            <asp:Label runat="server" Text='<%#Eval("TimeToReport") %>'
                                                ID="timelabel" BackColor="Yellow" CssClass="borderRadius"
                                                ForeColor="#263f75"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="delTaskRow" ForeColor="Yellow"
                                                CommandName="Delete" CommandArgument='<%#Eval("Id") %>'
                                                Text='<i class="far fa-trash-alt" aria-hidden="true"></i>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="EditTask" ForeColor="Yellow"
                                                CommandName="Edit" CommandArgument='<%#Eval("Id") %>'
                                                Text='<i class="far fa-edit" aria-hidden="true"></i>'>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server"
                                                ID="UpdateTaskRow" ForeColor="Yellow"
                                                CommandName="Update"
                                                CommandArgument='<%#Eval("Id") %>'
                                                Text='<%$Resources:Resource, Save %>' Font-Underline="true">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>                   
                </div>  
            </div>
        </div>
    </div>
    <script src="ScriptsLInks/highcharts.js"></script>
    <script src="ScriptsLInks/highcharts-more.js"></script>
    <script src="ScriptsLInks/highcharts-3d.js"></script>
    <script src="Scripts/MaintainanceScript.js"></script>
    <script>
        console.log("Window width " + $(window).width());
        console.log("Document width " + $(document).width());
       

    </script>
</asp:Content>
