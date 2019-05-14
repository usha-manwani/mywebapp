<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Maintainance.aspx.cs" Inherits="WebCresij.Maintainance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        /* Fixed sidenav, full height */
        .sidenav1 {
            height: 100%;
            width: 200px;
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
            margin-left: 200px; /* Same as the width of the sidenav */
            font-size: 20px; /* Increased text to enable scrolling */
            padding: 0px;
            padding-top: 40px;
        }

        /* Add an active class to the active dropdown button */
        .active {
            background-color: #23233f;
            color: white;
        }

        /* Dropdown container (hidden by default). Optional: add a lighter background color and some left padding to change the design of the dropdown content */
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
            margin-right:15px
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
                padding-bottom: 5px
        }

        .pt-3-half {
            padding-top: 1.4rem;
        }
       
    </style>
    <link href="assets/css/charts.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:20px">
    <div class="sidenav1" style="margin-top:20px">
        <span><%=Resources.Resource.BuildingMgmt%></span>
        <span class="dropdown-btn"><%=Resources.Resource.InspectionLog%> 
    <i class="fa fa-caret-down"></i>
        </span>
        <div class="dropdown-container">
            <span id="inspection"><%=Resources.Resource.InspectionLog%></span>
        </div>
        <span id="maintainanceMgmt"><%=Resources.Resource.Maintainance%></span>
        <span class="dropdown-btn"><%=Resources.Resource.FaultMgmt%> 
    <i class="fa fa-caret-down"></i>
        </span>
        <div class="dropdown-container">
            <span id="faultinfo"><%=Resources.Resource.FaultInfo%></span>
            <span id=" Dispatch"><%=Resources.Resource.DispatchMgmt%></span>
            <span id="statistics"><%=Resources.Resource.Stat%></span>
        </div>
    </div>

    <div class="main1" id="faultinfos" style="display: none">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row">
                    <span style="font-size: 12px;" class="btn btn-light"><i class="fa fa-plus-square" aria-hidden="true"></i>&nbsp;<%=Resources.Resource.Add%></span>&nbsp;&nbsp;
                    
                    <button class="btn btn-light" style="font-size: 12px" runat="server" id="btnDelete" onserverclick="DeleteAll">
                        <i class='fa fa-minus-circle' aria-hidden='true'></i>&nbsp;<%=Resources.Resource.Delete%></button>&nbsp;&nbsp;
                    <span style="font-size: 12px;" class="btn btn-light"><i class="fa fa-edit" aria-hidden="true"></i>&nbsp;<%=Resources.Resource.Edit%></span>&nbsp;&nbsp;
                    <span style="font-size: 12px;" class="btn btn-light"><i class="fa fa-file-export" aria-hidden="true"></i>&nbsp;<%=Resources.Resource.export%></span>&nbsp;&nbsp;
                    <span style="font-size: 12px;" class="btn btn-light"><i class="fa fa-edit" aria-hidden="true"></i>&nbsp;<%=Resources.Resource.update%></span>&nbsp;&nbsp;
                    <span style="font-size: 12px;" class="btn btn-light"><i class="fa fa-cog" aria-hidden="true"></i>&nbsp;<%=Resources.Resource.btnwork%></span>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-sm-12 col-md-12">
                </div>
                <asp:GridView runat="server" ID="gv1" AutoGenerateColumns="false" PageSize="10" Width="95%"
                    AllowPaging="true" OnPageIndexChanging="Gv1_PageIndexChanging" PagerStyle-ForeColor="White"
                    PagerStyle-BorderStyle="None" OnRowDataBound="gv1_RowDataBound"
                    DataKeyNames="sno">
                    <HeaderStyle CssClass="hidden-phone" ForeColor="WhiteSmoke" Font-Size="Smaller" HorizontalAlign="Center" />
                    <RowStyle CssClass=" center" BackColor="White" Font-Size="Small" HorizontalAlign="Center" />
                    <AlternatingRowStyle CssClass=" center" BackColor="WhiteSmoke" Font-Size="Small" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="<%$Resources:Resource, Select %>">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="<%$Resources:Resource, Sno %>" DataField="sno" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, FaultVia %>" DataField="faultknow" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Priority %>" DataField="priority" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Building %>" DataField="bName" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, DistrictName %>" DataField="distName" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, ClassName %>" DataField="className" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, PersonToHandle %>" DataField="memName" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Phone %>" DataField="phone" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Description %>" DataField="description" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Time %>" DataFormatString="{0:F}"
                            DataField="time" HtmlEncode="false" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, FaultStatus %>" DataField="stat" />
                        <asp:TemplateField HeaderText="<%$Resources:Resource, Options %>">
                            <ItemStyle />
                            <ItemTemplate>
                              <div>  <asp:LinkButton ID="lnkdelete" runat="server" CssClass="btn btn-info"
                                    Font-Size="12px" OnClick="lnkdelete_Click">
                                    <i class="fa fa-minus-circle" aria-hidden="true"></i><%=Resources.Resource.Delete%>
                                </asp:LinkButton>
                                  <asp:LinkButton ID="lnkedit" runat="server" CssClass="btn btn-info"
                                    Font-Size="12px" OnClick="lnkedit_Click">
                                    <i class="fa fa-edit" aria-hidden="true"></i><%=Resources.Resource.Edit%>
                                </asp:LinkButton></div>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
                <div class="modal" id="editDetailtoAssign">
                    <div class="modal-content">
                        <header class="row" style="position: center;">
                            <span onclick="document.getElementById('editDetailtoAssign').style.display='none'"
                                class="w3-button w3-display-topright">&times;</span>
                        </header>
                        <div class="form-group row">
                            <asp:Label runat="server" Text="User Name" AssociatedControlID="userNametoWork"
                                CssClass="control-label col-4"> </asp:Label>
                            <asp:TextBox ID="userNametoWork" CssClass="form-control col-6" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group row">

                            <asp:Label runat="server" Text="Serial No." ID="snolabel" AssociatedControlID="snotxt"
                                CssClass="control-label col-4"> </asp:Label>
                            <asp:TextBox ID="snotxt" CssClass="form-control col-6" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                        <div class="form-group row">

                            <asp:Label runat="server" Text="Date" AssociatedControlID="timetxt" CssClass="control-label col-4"> </asp:Label>
                            <asp:TextBox ID="timetxt" CssClass="form-control col-6" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group row">

                            <asp:Label runat="server" Text="Assign To" AssociatedControlID="assigntxt" CssClass="control-label col-4"> </asp:Label>
                            <asp:TextBox ID="assigntxt" CssClass="form-control col-6" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group row">
                            <asp:Button runat="server" ID="btneditok" CssClass="btn btn-light" Text="ok" Width="100px" OnClick="btneditok_Click" />
                            <button onclick="noModal();return false;" style="width: 100px; margin-left: 20px" class="btn btn-light">Cancel</button>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <div id="inspectionLogs" class="main1" style="display: none">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:GridView runat="server" ID="gvinspect" AutoGenerateColumns="false" PageSize="10" Width="95%"
                    AllowPaging="true" OnPageIndexChanging="gvinspect_PageIndexChanging" PagerStyle-ForeColor="White"
                    PagerStyle-BorderStyle="None" OnRowDataBound="gvinspect_RowDataBound"
                    DataKeyNames="sno">
                    <HeaderStyle CssClass="hidden-phone" ForeColor="WhiteSmoke" Font-Size="Smaller" HorizontalAlign="Center" />
                    <RowStyle CssClass=" center" BackColor="White" Font-Size="Small" HorizontalAlign="Center" />
                    <AlternatingRowStyle CssClass=" center" BackColor="WhiteSmoke" Font-Size="Small" HorizontalAlign="Center" />
                    <Columns>

                        <asp:BoundField HeaderText="<%$Resources:Resource, Sno %>" DataField="sno" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, DistrictName %>" DataField="distName" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, SchoolName %>" DataField="sName" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, BuildingName %>" DataField="bName" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, ClassName %>" DataField="className" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, PersonToHandle %>" DataField="memName" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Projector %>" DataField="projStat" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Screen %>" DataField="screenStat" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, CentralControl %>" DataField="CCStat" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Computer %>" DataField="computer" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Speaker %>" DataField="speaker" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Wirelessmic %>" DataField="wireless" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Wiredmic %>" DataField="wired" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, platform %>" DataField="platform" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Phone %>" DataField="phone" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Time %>" DataFormatString="{0:F}"
                            DataField="time" HtmlEncode="false" />
                        <asp:BoundField HeaderText="<%$Resources:Resource, Description %>" DataField="description" />
                        <asp:TemplateField HeaderText="<%$Resources:Resource, Options %>">
                            <ItemStyle />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkdeleteInspect" runat="server" CssClass="btn btn-info"
                                    Font-Size="12px" OnClick="lnkdeleteInspect_Click">
                                    <i class="fa fa-minus-circle" aria-hidden="true"></i><%=Resources.Resource.Delete%>
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
                <button class="tablinks" onclick="openIssueStats(); return false"><%=Resources.Resource.mgmttab1%></button>
                <button class="tablinks" onclick="openParis(); return false"><%=Resources.Resource.mgmttab2%></button>
                <button class="tablinks" onclick="OpenTokyo(); return false"><%=Resources.Resource.mgmttab3%></button>
            </div>
            <div >
                <span style="font-size: 24px; color: white"><i class="fa fa-chart-bar" aria-hidden="true"></i>&nbsp;
                    <%=Resources.Resource.issueStats%></span>
            </div>
            <div  id="issueStats" class="tabcontent">
                <div style="height: 400px; width: 400px; margin-left:200px" id="issueStats1"></div>
                <div style="margin-left: -50px">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView runat="server" ID="gvChart" AutoGenerateColumns="false" PageSize="10" Width="99%"
                                AllowPaging="true" OnPageIndexChanging="gvChart_PageIndexChanging" PagerStyle-ForeColor="White"
                                PagerStyle-BorderStyle="None">
                                <HeaderStyle CssClass="hidden-phone" ForeColor="WhiteSmoke" Font-Size="Smaller" HorizontalAlign="Center" />
                                <RowStyle CssClass=" center" BackColor="White" Font-Size="Smaller" HorizontalAlign="Center" />
                                <AlternatingRowStyle CssClass=" center" BackColor="WhiteSmoke" Font-Size="Smaller" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField HeaderText="<%$Resources:Resource, DistrictName %>" DataField="distName" />
                                    <asp:BoundField HeaderText="<%$Resources:Resource, Resolved %>" DataField="Resolved" />
                                    <asp:BoundField HeaderText="<%$Resources:Resource, Pending %>" DataField="Pending" />
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
                            <h4 >
                                <span id="FaultyDevices" class="count float-left ">21</span>
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
                            <h4 >
                                <span id="UnresolvedIssues" class="count float-left ">32</span>
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
                            <h4 >
                                <span id="totalResolved" class="count float-left ">87</span>
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
                            <h4 >
                                <span id="tempvalue" class="count float-left ">12</span>
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
        <div class=" row divstyle" style=" color: white">
            <div class="col-lg-12 col-sm-12 col-md-12" style="min-height: 300px;">
            <h5 style="border-bottom: 1px solid #3b3f39"><%=Resources.Resource.unresolvedbyBuilding%></h5>
            <div class="row" style="border-bottom: 1px solid #3b3f39; margin-bottom:-20px">
                <div class="col-lg-3 col-md-3 col-sm-3" style="  float: left;" ><span><%=Resources.Resource.BuildingName%></span></div>
                <div class="col-lg-7 col-md-7 col-sm-6" style=" float: left;"><%=Resources.Resource.Issue%></div>
                <div class="col-lg-2 col-md-2 col-sm-3" style=" float: left;"><%=Resources.Resource.IssuesResolved%></div>
            </div>
                <div class="row" style="border-bottom: 1px solid #3b3f39; margin-bottom:-20px">
            <div style="width: 100%; height:50px">
                <div style="width: 30%; float: left; ">1. 教三

                </div>
                <div style="width: 60%; height: 100%; float: left;">
                    <div class="progressbar">
                        <div style="background-color: #482d72; width: 40%;">
                        </div>
                    </div>
                </div>
                <div style="width: 10%; float: left;">
                    <span style="background-color: #dfc43a; border-radius: 6px; padding: 1px 8px 1px 8px">43</span>
                </div>
            </div>
                    </div>
                 <div class="row" style="border-bottom: 1px solid #3b3f39; margin-bottom:-20px">
            <div style="width: 100%;height:50px">
                <div style="width: 30%; float: left; ">2. 教一

                </div>
                <div style="width: 60%; float: left; ">
                    <div class="progressbar">
                        <div style="background-color: #214286; width: 60%;">
                        </div>
                    </div>
                </div>
                <div style="width: 10%; float: left; ">
                    <span style="background-color: #df683a; border-radius: 6px; padding: 1px 8px 1px 8px">70</span>
                </div>
            </div>
                     </div>
                <div class="row" style="border-bottom: 1px solid #3b3f39; margin-bottom:-20px">
            <div style="width: 100%;height:50px">
                <div style="width: 30%; float: left">3. 教四

                </div>
                <div style="width: 60%; float: left;">
                    <div class="progressbar">
                        <div style="background-color: #2c95af; width: 50%;">
                        </div>
                    </div>
                </div>
                <div style="width: 10%; float: left;">
                    <span style="background-color: #2c95af; border-radius: 6px; padding: 1px 8px 1px 8px">65</span>
                </div>
            </div>
                    </div>
                <div class="row" style=" margin-bottom:-20px">
            <div style="width: 100%;height:50px">
                <div style="width: 30%; float: left;">4. 教六 

                </div>
                <div style="width: 60%; float: left;">
                    <div class="progressbar">
                        <div style="background-color: #3c7526; width: 20%;">
                        </div>
                    </div>
                </div>
                <div style="width: 10%; float: left;">
                    <span style="background-color: #3c7526; border-radius: 6px; padding: 1px 8px 1px 8px">15</span>
                </div>
            </div>
                    </div>
                </div>
        </div>
        <div style=" clear: both"></div>
        <div class="row divstyle" style="margin-top: 20px">
            <div class="col-lg-12 col-sm-12 col-md-12" style="min-height: 300px;">
            <h5><%=Resources.Resource.MyTasks%></h5>
            <!-- Editable table -->
            
                <div class="card-body">
                    <div id="table" class="table-editable">
                        <span class="table-add float-right mb-3 mr-2"><a href="#!" class="text-success"><i class="fas fa-plus fa-2x"
                            aria-hidden="true"></i></a></span>
                        <table class="table table-responsive-md table-striped text-left" style="color: white; font-size: 16px;">

                            <tr class="hide" style="background-color: #184197">
                                <td class="pt-3-half" contenteditable="true">五山校区的实验楼101室有故障上报，请尽快审核和派工
                                    &nbsp;&nbsp;
              <span style="background-color: yellow; color: #263f75; border-radius: 6px; padding: 1px 8px 1px 8px">
                  <i class="fa fa-clock" aria-hidden="true"></i>2分钟前</span></td>
                                <td>
                                    <span class="table-remove" style="color: yellow"><i class="far fa-trash-alt" aria-hidden="true"></i></span>
                                </td>
                            </tr>
                            <!-- This is our clonable table line -->
                            <tr class="hide" style="background-color: #263f75">
                                <td class="pt-3-half" contenteditable="true">五山校区的实验楼103室有故障上报，请尽快审核和派工&nbsp;&nbsp;
              <span style="background-color: yellow; color: #263f75; border-radius: 6px; padding: 1px 8px 1px 8px">
                  <i class="fa fa-clock" aria-hidden="true"></i>1分钟前</span></td>
                                <td>
                                    <span class="table-remove" style="color: yellow"><i class="far fa-trash-alt" aria-hidden="true"></i></span>
                                </td>
                            </tr>
                            <!-- This is our clonable table line -->
                            <tr class="hide" style="background-color: #184197">
                                <td class="pt-3-half" contenteditable="true">五山校区的实验楼202室有故障上报，请尽快审核和派工&nbsp;&nbsp;
              <span style="background-color: yellow; color: #263f75; border-radius: 6px; padding: 1px 8px 1px 8px">
                  <i class="fa fa-clock" aria-hidden="true"></i>2分钟前</span></td>
                                <td>
                                    <span class="table-remove" style="color: yellow"><i class="far fa-trash-alt" aria-hidden="true"></i></span>
                                </td>
                            </tr>
                            <!-- This is our clonable table line -->
                            <tr class="hide" style="background-color: #263f75">
                                <td class="pt-3-half" contenteditable="true">五山校区的实验楼105室有故障上报，请尽快审核和派工&nbsp;&nbsp;
              <span style="background-color: yellow; color: #263f75; border-radius: 6px; padding: 1px 8px 1px 8px">
                  <i class="fa fa-clock" aria-hidden="true"></i>2分钟前</span>
                                </td>
                                <td>
                                    <span class="table-remove" style="color: yellow"><i class="far fa-trash-alt" aria-hidden="true"></i></span>
                                </td>
                            </tr>

                            <!-- This is our clonable table line -->
                            <tr class="hide" style="background-color: #184197">
                                <td class="pt-3-half" contenteditable="true">五山校区的实验楼201室有故障上报，请尽快审核和派工&nbsp;&nbsp;
              <span style="background-color: yellow; color: #263f75; border-radius: 6px; padding: 1px 8px 1px 8px">
                  <i class="fa fa-clock" aria-hidden="true"></i>1分钟前</span></td>
                                <td>
                                    <span class="table-remove" style="color: yellow"><i class="far fa-trash-alt" aria-hidden="true"></i></span>
                                </td>
                            </tr>
                            <!-- This is our clonable table line -->
                            <tr class="hide" style="background-color: #263f75">
                                <td class="pt-3-half" contenteditable="true">五山校区的实验楼303室有故障上报，请尽快审核和派工&nbsp;&nbsp;
              <span style="background-color: yellow; color: #263f75; border-radius: 6px; padding: 1px 8px 1px 8px">
                  <i class="fa fa-clock" aria-hidden="true"></i>1分钟前</span>
                                </td>
                                <td>
                                    <span class="table-remove" style="color: yellow"><i class="far fa-trash-alt" aria-hidden="true"></i></span>
                                </td>
                            </tr>

                        </table>

                    </div>
                </div>
            
                </div>
            <!-- Editable table -->
        </div>
    </div>
    </div>

    
    
    <script src="ScriptsLInks/highcharts.js"></script>
    <script src="ScriptsLInks/highcharts-more.js"></script>
    <script src="ScriptsLInks/highcharts-3d.js"></script>
    <script>
        var dropdown = document.getElementsByClassName("dropdown-btn");
        var i;

        for (i = 0; i < dropdown.length; i++) {
            dropdown[i].addEventListener("click", function () {
                this.classList.toggle("active");
                var dropdownContent = this.nextElementSibling;
                if (dropdownContent.style.display === "block") {
                    dropdownContent.style.display = "none";
                } else {
                    dropdownContent.style.display = "block";
                }
            });
        }
        $(document).on("click", "#inspection", function () {

            displayNone();
            document.getElementById("inspectionLogs").style.display = "block";
        });

        $(document).on("click", "#maintainanceMgmt", function () {
            displayNone();
            document.getElementById("mainStats").style.display = "block";
        });

        $(document).on("click", "#faultinfo", function () {
            displayNone();
            document.getElementById("faultinfos").style.display = "block";
        });

        $(document).on("click", "#statistics", function () {
            displayNone();
            document.getElementById("stats").style.display = "block";
            openIssueStats();
        })
        function displayNone() {
            document.getElementById("inspectionLogs").style.display = "none";
            document.getElementById("faultinfos").style.display = "none";
            document.getElementById("stats").style.display = "none";
            document.getElementById("mainStats").style.display = "none";
        }

        function displayModalnow() {
            document.getElementById("editDetailtoAssign").style.display = "block";
            return false;
        }

        function noModal() {
            document.getElementById("editDetailtoAssign").style.display = "none";
        }

        var pieColors = (function () {
            var colors = [],
                base = Highcharts.getOptions().colors[0],
                i;

            for (i = 0; i < 10; i += 1) {
                // Start out with a darkened base color (negative brighten), and end
                // up with a much brighter color
                colors.push(Highcharts.Color(base).brighten((i - 3) / 7).get());
            }
            return colors;
        }());
        var ccc = Highcharts.chart('issueStats1', {
            chart: {
                backgroundColor: 'transparent',
                plotBackgroundColor: 'transparent',
                type: 'pie',
                animation: {
                    duration: 1000
                },
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: '',
                style: {
                    color: '#E0E0E3',
                    textTransform: 'uppercase',
                    fontSize: '16px',
                    fontWeight: 'bold'
                }
            },
            tooltip: {
                pointFormat: ' <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    colors: pieColors,
                    innerSize: 70,
                    cursor: 'pointer',
                    depth: 30,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}'
                    }
                }
            },
            credits: {
                enabled: false
            },
            series: [{
                type: 'pie',
                name: 'Issues Status',
                data: [
                    ['已处理', 60.4],

                    {
                        name: '未处理',
                        y: 39.6,
                        sliced: true,
                        selected: true
                    },

                ]
            }],
            scrollbar: {
                // dont call setExtremes with each move of the scrollbar
                liveRedraw: false
            }
        });

        function func() {
            console.log("function worked");
            ccc.series[0].setData([[Math.random()], [Math.random()]]);
        };
        setInterval(func, 10 * 1000);

        function openIssueStats() {

            document.getElementById("issueStats").style.display = "block";
            document.getElementById("Tokyo").style.display = "none";
            document.getElementById("Paris").style.display = "none";
            return false;
        };
        function openParis() {
            openIssueStats();
            return false;
        }
        function OpenTokyo() {
             openIssueStats();
            return false;
        }

    </script>
    <script>
        console.log("Window width " +$(window).width());
        console.log("Document width " + $(document).width());
        var $TABLE = $('#table');
        var $BTN = $('#export-btn');
        var $EXPORT = $('#export');

        $('.table-add').click(function () {
            var $clone = $TABLE.find('tr.hide:first').clone(true).removeClass(' table-line');
            $TABLE.find('table').append($clone);
        });

        $('.table-remove').click(function () {
            $(this).parents('tr').detach();
        });



        // A few jQuery helpers for exporting only
        jQuery.fn.pop = [].pop;
        jQuery.fn.shift = [].shift;

        $BTN.click(function () {
            var $rows = $TABLE.find('tr:not(:hidden)');
            var headers = [];
            var data = [];



            // Turn all existing rows into a loopable array
            $rows.each(function () {
                var $td = $(this).find('td');
                var h = {};

                // Use the headers from earlier to name our hash keys
                headers.forEach(function (header, i) {
                    h[header] = $td.eq(i).text();
                });

                data.push(h);
            });

            // Output the result
            $EXPORT.text(JSON.stringify(data));
        });

    </script>
</asp:Content>
