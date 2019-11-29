<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Options.aspx.cs" Inherits="WebCresij.Options" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ID="Head" ContentPlaceHolderID="MasterHead" runat="server">
    <link href="ajaxfiles/Background.css" rel="stylesheet" />
    <link href="ajaxfiles/Tabs.css" rel="stylesheet" />
    <link href="Content/options.css?v=1" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="masterBody" runat="server">
    <script src="ajaxfiles/Localization.Resources.debug.js"></script>
    <script src="ajaxfiles/Common.debug.js"></script>
    <script src="ajaxfiles/ComponentSet.debug.js"></script>
    <script src="ajaxfiles/BaseScripts.debug.js"></script>
    <script src="ajaxfiles/Tabs.debug.js"></script>
    <script src="ajaxfiles/DynamicPopulate.debug.js"></script>
    <script src ="Scripts/Options.js?version=2"></script>
    <asp:ScriptManagerProxy ID="sc1" runat="server"></asp:ScriptManagerProxy>
    <div>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="leftspace" oncontextmenu="return false;">
                    <cc1:TabContainer runat="server" BorderStyle="None" CssClass="fancy fancy-green">
                        <cc1:TabPanel ID="addpaneltab" runat="server" BorderStyle="None">
                            <HeaderTemplate>
                                <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;<span><%=Resources.Resource.Add%></span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:LinkButton runat="server" Text="<%$Resources:Resource, AddEditNoDevice %>" ID="AddEditlink" 
                                    OnClientClick="displaydevicesPopup();return false;" Font-Underline="True"
                                    Font-Bold="True" Font-Size="20px" ForeColor="#2f323a"></asp:LinkButton><br />
                                <%--<asp:LinkButton runat="server" Text="Add University" ID="AddUniv" 
                                    OnClientClick="displayUnivPopup();return false;" Font-Underline="True"
                                    Font-Bold="True" Font-Size="20px" ForeColor="#2f323a"></asp:LinkButton><br />--%>
                                <asp:LinkButton runat="server" Text="<%$Resources:Resource, AddInstitutes %>" 
                                    ID="AddInstitutes" OnClientClick="displayPopup(); return false;" Font-Underline="True"
                                    Font-Bold="True" Font-Size="20px" ForeColor="#2f323a"></asp:LinkButton>
                                <asp:TreeView ID="TreeMenuView1" EnableClientScript="true" runat="server"
                                    OnSelectedNodeChanged="TreeMenuView1_SelectedNodeChanged" 
                                    NodeStyle-NodeSpacing="5px" CssClass="leftspace" 
                                    ToolTip="Add new Details" PopulateNodesFromClient="true" 
                                    ForeColor="#2F323A" ShowCheckBoxes="None">
                                </asp:TreeView>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" ID="editpaneltab" BorderStyle="None">
                            <HeaderTemplate>
                                <i class="fas fa-edit" aria-hidden="true"></i>&nbsp;<span><%=Resources.Resource.Edit%></span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:TextBox runat="server" Visible="false"></asp:TextBox>
                                <asp:TreeView ID="TreeViewEdit" ToolTip="Edit Details" runat="server"
                                    OnSelectedNodeChanged="TreeViewEdit_SelectedNodeChanged" 
                                    NodeStyle-NodeSpacing="5px" CssClass="leftspace" ForeColor="#2F323A"
                                    >
                                </asp:TreeView>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" ID="deletepaneltab" BorderStyle="None">
                            <HeaderTemplate>
                                <i class="fa fa-minus-circle" aria-hidden="true"></i>&nbsp;<span><%=Resources.Resource.Delete%></span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:TreeView ID="TreeViewDelete" ToolTip="Delete Details" runat="server"
                                    OnSelectedNodeChanged="TreeViewDelete_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" ForeColor="#2F323A">
                                </asp:TreeView>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>
                </div>
                <%--Add all details--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div style="position: center;">
                     <div id="idAddUniv" class="modal scroll">
                        <!-- Modal content -->
                        <div class="modal-content">
                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col ">
                                    <h4><span>UniversityName</span></h4>
                                </div>
                                <span onclick="hideUnivDiv();" style="cursor: pointer">&times;</span>
                            </div>
                            <div>
                                <div class="row ">
                                    <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
                                    <div class="form-horizontal">
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="tbuniv_Name"
                                                CssClass="col-md-5 labelpadding" Text="University Name"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="tbuniv_Name" CssClass="form-control " />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="width: 50%; float: left; margin-right: 30px;">                                    
                                    <div class="col">
                                        <asp:Button ID="Button3" Text="<%$Resources:Resource, Save %>" runat="server" OnClientClick="hideGrade();" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id ="addeditdevices" class ="modal scroll">
                        <div class="modal-content">
                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col">
                                    <h4><span><%=Resources.Resource.AddEditNoDevice%></span></h4>
                                </div>
                                <span onclick="hidedevicesDiv();" style="cursor: pointer">&times;</span>
                            </div>
                            <div>
                                <div class="row ">
                                   
                                    <div class="form-horizontal">
                                        <div class="form-group row margintop">
                                             <asp:Label runat="server" Font-Bold="true" AssociatedControlID="ddlInstitute"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, SelectInstitute %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:DropDownList Width="100px" AutoPostBack="false"                            
                                            CssClass="btn btn-default border-dark" ID="ddlInstitute" 
                                            runat="server" ForeColor="#1E1E36" onChange="GetMachineCounts(this);return false;">                            
                                        </asp:DropDownList>
                                            </div>
                                            
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="projtb"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, NoOfProjector %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="projtb" CssClass="form-control" Text="0"/>
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="pctb"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, NoOfPC %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="pctb" CssClass="form-control" Text="0"/>
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="recordtb"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, NoOfRecorder %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="recordtb" CssClass="form-control" Text="0" />
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="actb"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, NoOfAC %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="actb" CssClass="form-control" Text="0"/>
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="screentb"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, NoofBooth %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="screentb" CssClass="form-control" Text="0"/>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="width: 50%; float: left; margin-right: 30px;">                                    
                                        <asp:Button ID="Button2" Text="<%$Resources:Resource, Save %>" runat="server"
                                            OnClientClick="saveandhideDevices();" /></div>                                
                            </div>
                        </div>
                    </div>
                    <div id="id01" class="modal scroll">
                        <div class="modal-content">

                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col ">
                                    <h4><span><%=Resources.Resource.AddInsgrade%></span></h4>
                                </div>
                                <span onclick="xx1();" style="cursor: pointer; float: right">&times;</span>

                            </div>

                            <div class="form-group">
                                <div  style="width: 30%; float: left">
                                    <asp:Label runat="server" Font-Bold="true" AssociatedControlID="txtIns" CssClass="col-lg-3 control-label" Text="<%$Resources:Resource, InsName %>"></asp:Label>
                                </div>
                                <div style="width: 40%; float: left">
                                    <asp:TextBox runat="server" ID="txtIns" CssClass="form-control" />
                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <div>
                                <h4><span><%=Resources.Resource.AddNewgrade%></span></h4>
                                <hr />
                                <div id="TextBoxContainer1">
                                </div>

                                <div class="row" style="width: 50%; margin-top: 50px; float: left; margin-right: 30px;">
                                    <div class="col">
                                        <asp:Button ID="btnaddgrade1" Text="<%$Resources:Resource, AddGrades %>"
                                            runat="server" OnClientClick="AddTextGrade1(); return false;" />
                                    </div>

                                    <div class="col">
                                        <asp:Button ID="saveg" Text="<%$Resources:Resource, Save %>" runat="server" OnClick="save_Click" />
                                    </div>
                                    <div class="col">
                                        <asp:Button ID="Cancle" Text="<%$Resources:Resource, Cancel %>" runat="server"
                                            OnClientClick="closeframe(); return false;" />
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>

                    <div id="idGrade" class="modal scroll">
                        <!-- Modal content -->
                        <div class="modal-content">
                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col ">
                                    <h4><span><%=Resources.Resource.AddGrades%></span></h4>
                                </div>
                                <span onclick="xx();" style="cursor: pointer">&times;</span>
                            </div>
                            <div>
                                <div class="row ">
                                    <asp:TextBox ID="instext" runat="server" Visible="false"></asp:TextBox>
                                    <div id="TextBoxContainer" class="form-horizontal"  style="width: 90%">
                                        <div class="form-group row margintop">
                                            
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="Grade_Name"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, Grade %>"></asp:Label>                                
                                            <div class="col-md-7" >
                                                <asp:TextBox runat="server" ID="Grade_Name" CssClass="form-control " />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="width: 50%; float: left; margin-right: 30px;">
                                    <div class="col">
                                        <asp:Button ID="btnaddgrade" Text="<%$Resources:Resource, Add %>" runat="server" 
                                            OnClientClick="AddTextGrade(); return false;" /></div>
                                    <div class="col">
                                        <asp:Button ID="save" Text="<%$Resources:Resource, Save %>" runat="server" OnClientClick="hideGrade();"
                                            OnClick="btnGradesave_Click" /></div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="idClass" class="modal scroll">
                        <div class="modal-content">
                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col ">
                                    <h4><span><%=Resources.Resource.AddClass%></span></h4>
                                </div>
                                <span onclick="hideClass();" style="cursor: pointer">&times;</span>
                            </div>
                            <div class="row ">
                                <asp:TextBox runat="server" ID="TextGrade" Visible="false" />
                                <div id="TextContainer" class="form-horizontal" style="width: 90%">
                                    <div class="form-group row margintop">
                                        <asp:Label runat="server" Text="<%$Resources:Resource, Class %>"
                                            AssociatedControlID="TextGrade"
                                            CssClass="col-md-5 col-lg-5 control-label labelpadding" Font-Bold="True"></asp:Label>
                                        <div class="col-md-7 ">
                                            <asp:TextBox runat="server" ID="Class_Name" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class=" form-group row  margintop">
                                        <asp:Label runat="server"
                                            Text="<%$Resources:Resource, CCIPAddress %>"
                                            AssociatedControlID="tbip"
                                            CssClass="col-md-5 col-lg-5 control-label labelpadding" Font-Bold="True"></asp:Label>

                                        <div class="col-md-7 col-lg-7">
                                            <asp:TextBox runat="server" ID="tbip" CssClass="form-control"></asp:TextBox>
                                        </div>

                                    </div>

                                </div>
                            </div>
                            <div class="row margintop" style="width: 50%; float: left; margin-right: 30px;">
                                <div class="col">
                                    <asp:Button ID="BtnClass" Text="<%$Resources:Resource, Add %>" runat="server" OnClientClick="AddTextClass(); return false;" /></div>
                                <div class="col">
                                    <asp:Button ID="BtnClassSave" Text="<%$Resources:Resource, Save %>" runat="server" OnClientClick="hideClass();" OnClick="BtnClassSave_Click" /></div>
                            </div>
                        </div>
                    </div>
                    <div id="idCamera" class="modal scroll">
                        <div class="modal-content">
                            <div class=" row " style="padding-right: 20px; padding-top: 50px">
                                <div class="panel-heading col ">
                                    <h4><span><%=Resources.Resource.AddDeviceDetails%></span></h4>
                                </div>
                                <span onclick="hideCam();"
                                    style="cursor: pointer">&times;</span>
                            </div>
                            <div class="row" style="float: left; ">
                                <asp:TextBox Visible="false" runat="server" ID="tbSelectedClass"></asp:TextBox>
                                <div class="form-group row margintop" style="width:90%">
                                    <asp:Label Text="<%$Resources:Resource, CCIPAddress %>" AssociatedControlID="ccSystem" runat="server" CssClass="col-md-5 control-label" Font-Bold="True"></asp:Label>
                                    <div class="col-md-7">
                                        <asp:TextBox runat="server" CssClass="form-control" ID="ccSystem"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="camdiv" class="row margintop">
                                </div>
                            </div>
                            <div class="row" style="width: 50%; float: left; margin-right: 30px;">
                                <div class="col">
                                    <asp:Button ID="btncam" Text="<%$Resources:Resource, AddCam %>" runat="server" OnClientClick="AddTextCam(); return false;" />
                                </div>
                                <div class="col">
                                    <asp:Button ID="BtnCamSave" Text="<%$Resources:Resource, Save %>" runat="server" OnClick="BtnCamSave_Click" />
                                    <div class="col">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                 
                    <%--add all details finished--%>
                    <%--Edit all details--%>

                    <div id="edit" class="modal">
                        <div class="modal-content">
                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col ">

                                    <h3><span><%=Resources.Resource.EditCamDetails%></span></h3>
                                </div>
                                <span onclick="hideEdit();"
                                    class="w3-button w3-display-topright">&times;</span>
                            </div>

                            <div class="row">
                                <asp:Label Visible="false" runat="server" ID="hiddencamName"></asp:Label>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="<%$Resources:Resource, CamIP %>" CssClass=" control-label" AssociatedControlID="camEditIP"></asp:Label>
                                    <div>
                                        <asp:TextBox runat="server" ID="camEditIP" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="<%$Resources:Resource, PortNo %>" CssClass=" control-label" AssociatedControlID="portEdit"></asp:Label>
                                    <div>
                                        <asp:TextBox runat="server" ID="portEdit" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="ID" CssClass="control-label" AssociatedControlID="idEditcam"></asp:Label>
                                    <div class="">
                                        <asp:TextBox runat="server" ID="idEditcam" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" Text="<%$Resources:Resource, Password %>" CssClass=" control-label" AssociatedControlID="passEditcam"></asp:Label>
                                    <div>
                                        <asp:TextBox runat="server" ID="passEditcam" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                            </div>
                            <div class="row" style="width: 50%; margin-top: 50px; float: left; margin-right: 30px;">
                                <div class="col">
                                    <asp:Button ID="cancelCamEdit" Text="<%$Resources:Resource, Cancel %>" runat="server" OnClientClick="hideEdit(); return false;" />
                                </div>
                                <div class="col">
                                    <asp:Button ID="saveCamEdit" Text="<%$Resources:Resource, Save %>" runat="server" OnClick="saveCamEdit_Click" />
                                </div>
                            </div>
                        </div>
                    </div>


                    <div id="DivRename" class="modal">
                        <asp:TextBox runat="server" ID="txtRename" Visible="false"></asp:TextBox>
                        <div class="modal-content" style="width: 500px; height: 400px; text-align: center;">
                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col ">
                                    <h4><span><%=Resources.Resource.EditName%></span></h4>
                                </div>
                                <span onclick="hideRename();"
                                    class="w3-button w3-display-topright">&times;</span>
                            </div>
                            <div class="row " style="padding-left: 20px; padding-top: 40px;">
                                <asp:Label runat="server" Text="<%$Resources:Resource, NewName %>" AssociatedControlID="tbRename"></asp:Label>
                                &nbsp;
                   
                <asp:TextBox ID="tbRename" runat="server" CssClass="form-control"></asp:TextBox>
                                <br />
                            </div>
                            <div class="row">
                                <div class="col">
                                    <asp:Button ID="saveRename" runat="server" Text="<%$Resources:Resource, Save %>" OnClick="saveRename_Click" />
                                </div>
                                <div class="col">
                                    <asp:Button ID="cancelRename" runat="server" Text="<%$Resources:Resource, Cancel %>"
                                        OnClientClick="hideRename(); return false;" />
                                </div>
                            </div>
                        </div>

                    </div>

                     <div id ="edithours" class ="modal scroll">
                        <div class="modal-content">
                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col">
                                    <h4><span><%= Resources.Resource.ChangeUsesTime%></span></h4>
                                </div>
                                <span onclick="hidehourDiv();" style="cursor: pointer">&times;</span>
                            </div>
                            <div>
                                <p id="workingHourslocation" runat="server"><span>
                                    <asp:Label runat="server" ID="hourins" Text=""></asp:Label> &nbsp;>>
                                    <asp:Label runat="server" ID="hourgrade" Text=""></asp:Label>&nbsp;>>
                                    <asp:Label runat="server" ID="hourclass" Text=""></asp:Label>
                                                             </span></p>
                                <div class="row ">
                                   <input type="hidden" id="hiddenworkip" value="" />
                                    <div class="form-horizontal">
                                       
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="projhour"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, Projector %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="projhour" CssClass="form-control" Text="0"/>&nbsp;<%=Resources.Resource.Hours %>
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="pchour"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, Computer %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="pchour" CssClass="form-control" Text="0"/>&nbsp;<%=Resources.Resource.Hours %>
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="recordhour"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, Recorder %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="recordhour" CssClass="form-control" Text="0" />&nbsp;<%=Resources.Resource.Hours %>
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="achour"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, AC %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="achour" CssClass="form-control" Text="0"/>&nbsp;<%=Resources.Resource.Hours %>
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="syshour"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, CentralControl %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="syshour" CssClass="form-control" Text="0"/>&nbsp;<%=Resources.Resource.Hours %>
                                            </div>
                                        </div>
                                        <div class="form-group row margintop">
                                            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="screenhour"
                                                CssClass="col-md-5 labelpadding" Text="<%$Resources:Resource, Screen %>"></asp:Label>
                                            <div class="col-md-7">
                                                <asp:TextBox runat="server" ID="screenhour" CssClass="form-control" Text="0"/>&nbsp;<%=Resources.Resource.Hours %>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="width: 50%; float: left; margin-right: 30px;">                                    
                                        <asp:Button ID="Button4" Text="<%$Resources:Resource, Save %>" runat="server"
                                            OnClientClick="saveandhideworkinghour();" /></div>                                
                            </div>
                        </div>
                    </div>
                  

                    <%--Edit all detals finished--%>

                    <%--Delete Starts--%>

                    <div id="del" class="modal">
                        <div class="modal-content" style="width: 350px; min-height: 150px">
                            <div class=" row " style="padding-right: 20px;">

                                <span onclick="hideDelConfirm();"
                                    class="w3-button w3-display-topright">&times;</span>
                            </div>
                            <div class="row ">
                                <asp:TextBox runat="server" ID="delvalue" Visible="false"></asp:TextBox>
                                <p class="text-danger"><span><%=Resources.Resource.ConfirmDelete%></span></p>
                            </div>
                            <div class="row">
                                <div style="width: 50%">
                                    <asp:Button ID="btndel" runat="server" Text="<%$Resources:Resource, YesDelete %>" OnClick="Btndel_Click" />
                                </div>
                                <div style="width: 50%">
                                    <asp:Button ID="delcancel" runat="server" Text="<%$Resources:Resource, Cancel %>" OnClientClick="hideDelConfirm(); return false;" />

                                </div>
                            </div>
                        </div>
                    </div>


                    <div id="delnot" class="modal">
                        <div class="modal-content" style="width: 250px">
                            <div class=" row " style="padding-right: 20px;">
                                <div class="panel-heading col ">
                                    <h4>Delete!!</h4>
                                </div>
                                <span onclick="hideDelNot();"
                                    class="w3-button w3-display-topright">&times;</span>
                            </div>
                            <div class="row ">
                                <asp:TextBox runat="server" ID="TextBox1" Visible="false"></asp:TextBox>

                                <p class="text-danger">You are not allowed to delete this. Please delete sub categories first!!</p>
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="Ok, got it!" OnClientClick="hideDelNot(); return false;" />

                            </div>
                        </div>
                    </div>


                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
  <script>
function GetDynamicCamDetails(value) {
    return '<span style="color: #C0C0C0"><%=Resources.Resource.AddCam%></span><section><div class="form-horizontal">'
        + '<table style="width:100%;"><tr class="margintop"><td style="text-align:center"> <div class = "form-group">' +
        '<asp:label runat="server" Text="<%$Resources:Resource, CamIP %>" CssClass=" control-label" Fond-Bold="True"/>' +
        '<div ><input name="IP" class="form-control" type="text" value="' + value + '"/></div></div></td>' +
        '<td style="text-align:center"><div class = "form-group">' +
        '<asp:label runat="server" Text="<%$Resources:Resource, PortNo %>" CssClass=" control-label" Fond-Bold="True"/>' +
        '<div ><input name="Port" class="form-control" type="text" value="' + value + '"' +
        '</div></div></td></tr>' +
        '<tr class="margintop"><td style="text-align:center"><div class = "form-group">' +
        '<asp:label runat="server" Text="<%$Resources:Resource, UserID %>" CssClass=" control-label" Fond-Bold="True"/>' +
        '<div ><input name="User" class="form-control" type="text" value="' + value + '"/></div></div></td>' +
        '<td style="text-align:center"><div class = "form-group">' +
        '<asp:label runat="server" Text="<%$Resources:Resource, Password %>" CssClass=" control-label" Fond-Bold="True"/>' +
        '<div ><input name="Pass" class="form-control" type="text" value="'
        + value + '"/></div></div></td></tr></table></div><section>'
}
function AddTextCam() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicCamDetails("");
    document.getElementById("camdiv").appendChild(div);

      }
      //Get Modal for Ins Grade


function GetDynamicTextBoxIns(value) {
    return '<div class="form-group">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Grade %>" CssClass="col-sm-2 control-label" Font-Bold="True"/>' +
        '<div class="col-sm-10"><input name = "DynamicTextBox" class="form-control" type="text" value = "' + value + '" /></div></div>'
}

function AddTextGrade1() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextBoxIns("");
    document.getElementById("TextBoxContainer1").appendChild(div);
}

// Get the modal
function GetDynamicTextBox(value) {
    return '<div class="form-group row  margintop">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Grade %>" CssClass="col-md-5 control-label labelpadding" Font-Bold="True"/>' +
        '<div class="col-md-7"><input name = "DynamicTextBox" class="form-control" type="text" value = "' + value + '" /></div></div>'
}

function AddTextGrade() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextBox("");
    document.getElementById("TextBoxContainer").appendChild(div);

}

function GetDynamicTextClass(value) {
    return '<div class="form-group row  margintop">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Class %>" CssClass="col-md-5 control-label labelpadding" Font-Bold="True"/>' +
        '<div class="col-md-7"><input name = "DynamicTextClass" class="form-control" type="text" value = "' + value + '" /></div></div>' +
        '<div class="form-group row  margintop">' + '<asp:Label runat="server" Text="<%$Resources:Resource, CCIPAddress %>" CssClass="col-md-5 control-label labelpadding" Font-Bold="True"/>' +
        '<div class="col-md-7"><input name = "DynamicIP" class="form-control" type="text" value = "' + value + '" /></div></div>';
}

function AddTextClass() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextClass("");
    document.getElementById("TextContainer").appendChild(div);
}
  </script>
    <%--Delete finished--%>
</asp:Content>
