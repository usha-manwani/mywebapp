<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Options.aspx.cs" Inherits="WebCresij.Options" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ID="Head" ContentPlaceHolderID="MasterHead" runat="server">

    <link href="Content/options.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="masterBody" runat="server">
    <asp:ScriptManagerProxy ID="sc1" runat="server"></asp:ScriptManagerProxy>
    <div>
        <asp:UpdatePanel runat="server" >
                <ContentTemplate>
        <div class="leftspace" oncontextmenu="return false;">
            
                    <cc1:TabContainer runat="server"  BorderStyle="None"  CssClass="fancy fancy-green">
                        <cc1:TabPanel ID="addpaneltab" runat="server" BorderStyle="None">
                            <HeaderTemplate>
                                <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;<span><%=Resources.Resource.Add%></span>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:LinkButton runat="server" Text="<%$Resources:Resource, AddInstitutes %>" ID="AddInstitutes" OnClientClick="displayPopup(); return false;" Font-Underline="True"
                                    Font-Bold="True" Font-Size="20px" ForeColor="#2f323a"></asp:LinkButton>
                                <asp:TreeView ID="TreeMenuView1" EnableClientScript="true" runat="server"
                                    OnSelectedNodeChanged="TreeMenuView1_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" ToolTip="Add new Details" PopulateNodesFromClient="true" ForeColor="#2F323A" ShowCheckBoxes="None">
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
                                    OnSelectedNodeChanged="TreeViewEdit_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" ForeColor="#2F323A">
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
        <div style="position: center;">
            
            <div id="id01" class="modal">
                <div class="modal-content">
                    <header class="row" style="position: center; ">
                        <span onclick="document.getElementById('id01').style.display='none'"
                            class="w3-button w3-display-topright">&times;</span>
                        <h2><span><%=Resources.Resource.AddInsgrade%></span></h2>
                    </header>
                    <div  >
                         <div class="form-group" style="width:30%;float:left">
            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="txtIns" CssClass="col-lg-3 control-label" Text="<%$Resources:Resource, InsName %>"></asp:Label>
                </div>
            <div style="width:40%; float:left">
                <asp:TextBox runat="server" ID="txtIns" CssClass="form-control" />
            </div>
                        </div>
        <div style="clear:both"></div>
        <div>
            <h4><span><%=Resources.Resource.AddNewgrade%></span></h4>
            <hr />
            <div id="TextBoxContainer1">
            </div>
            <asp:Button ID="btnaddgrade1" Text="<%$Resources:Resource, AddGrades %>" runat="server" OnClientClick="AddTextGrade1(); return false;" />
            <div class="row" style="width:50%; margin-top:50px; float:left;margin-right:30px;">
                <div class="col">
                    <asp:Button ID="saveg" Text="<%$Resources:Resource, Save %>" runat="server" OnClick="save_Click" />
                </div>
                <div class="col">
                    <asp:Button ID="Cancle" Text="<%$Resources:Resource, Cancel %>" runat="server"
                        OnClientClick="closeframe(); return false;" />
                </div>
            </div>
        </div>
                        <%--<iframe width="100%" height="500" id="Iframe1" src="~/addDetails.aspx" runat="server" frameborder="0"></iframe>--%>
                    
                    <div style="clear:both"></div>
                </div>
            </div>
            
            <div style="clear:both"></div>
            
            <div id="idGrade" class="modal ">
                <!-- Modal content -->
                
                <div class="modal-content">
                    <div class=" row " style="padding-right: 20px;">
                        <div class="panel-heading col ">
                            <h4><span><%=Resources.Resource.AddGrades%></span></h4>
                        </div>
                        <span onclick="xx();" style="cursor: pointer">&times;</span>
                    </div>
                    
                    <div>
                    <div class="row space">
                        <asp:TextBox ID="instext" runat="server" Visible="false"></asp:TextBox>
                                <div id="TextBoxContainer" class="form-horizontal">
                                    <div class="form-group">
                                        <asp:Label runat="server" Font-Bold="true" AssociatedControlID="Grade_Name"
                                            CssClass=" control-label" Text="<%$Resources:Resource, Grade %>"></asp:Label>
                                        <div>
                                            <asp:TextBox runat="server" ID="Grade_Name" CssClass="form-control" />
                                        </div>
                                    </div>
                                </div>
                        </div>
                        <div class="row" style="width:50%; margin-top:50px; float:left;margin-right:30px;">
                            <div class="col"><asp:Button ID="btnaddgrade" Text="<%$Resources:Resource, Add %>" runat="server" OnClientClick="AddTextGrade(); return false;" /></div>
                            <div class="col"><asp:Button ID="save" Text="<%$Resources:Resource, Save %>" runat="server" OnClientClick="hideGrade();" OnClick="btnGradesave_Click" /></div>
                        </div>
                    </div>
                   
                   </div>
                   
            </div>
            
            
            <div id="idClass" class="modal">
                <div class="modal-content">
                    <div class=" row " style="padding-right: 20px;">
                        <div class="panel-heading col ">
                            <h4><span><%=Resources.Resource.AddClass%></span></h4>
                        </div>
                        <span onclick="hideClass();" style="cursor: pointer">&times;</span>
                    </div>
                    <div class="row space">
                        
                                <asp:TextBox runat="server" ID="TextGrade" Visible="false" />
                                <div id="TextContainer" class="form-horizontal">
                                    <div class="form-group">
                                        <asp:Label runat="server" Text="<%$Resources:Resource, Class %>" AssociatedControlID="TextGrade"
                                            CssClass=" control-label" Font-Bold="True"></asp:Label>
                                        <div>
                                            <asp:TextBox runat="server" ID="Class_Name" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                        </div>
                        <div class="row" style="width:50%; margin-top:50px; float:left;margin-right:30px;">
                            <div class="col"><asp:Button ID="BtnClass" Text="<%$Resources:Resource, Add %>" runat="server" OnClientClick="AddTextClass(); return false;" /></div>
                            <div class="col"><asp:Button ID="BtnClassSave" Text="<%$Resources:Resource, Save %>" runat="server" OnClientClick="hideClass();" OnClick="BtnClassSave_Click" /></div>
                        </div>
                  </div>
            </div>

                    
            <div id="idCamera" class="modal">
                <div class="modal-content">
                    <div class=" row " style="padding-right: 20px; padding-top:50px">
                        <div class="panel-heading col ">
                            <h4><span><%=Resources.Resource.AddDeviceDetails%></span></h4>
                        </div>
                        <span onclick="hideCam();"
                            style="cursor: pointer">&times;</span>
                    </div>
                    <div class="row space" style="float:left">
                         <asp:TextBox Visible="false" runat="server" ID="tbSelectedClass"></asp:TextBox>
                                <div class="form-group">
                                    <asp:Label Text="<%$Resources:Resource, CCIPAddress %>" AssociatedControlID="ccSystem" runat="server" CssClass=" control-label" Font-Bold="True"></asp:Label>
                                    <asp:TextBox runat="server" CssClass="form-control" ID="ccSystem"></asp:TextBox>
                                </div>
                                <div id="camdiv">
                                </div>
                                <br />
                        </div>
                         <div class="row" style="width:50%; margin-top:50px; float:left;margin-right:30px;">
                            <div class="col">   <asp:Button ID="btncam" Text="<%$Resources:Resource, AddCam %>" runat="server" OnClientClick="AddTextCam(); return false;" />
                               </div>  
                             <div class="col">
                                   <asp:Button ID="BtnCamSave" Text="<%$Resources:Resource, Save %>" runat="server" OnClick="BtnCamSave_Click" />
                                 <div class="col">
                            </div>
                </div>
            </div>
                </div>
                </div>

              
            <script>


                function displayGrade() {
                    document.getElementById('idGrade').style.display = 'Flex';
                }
                function displayClass() {
                    document.getElementById('idClass').style.display = 'Flex';
                }
                function displayCam() {
                    document.getElementById('idCamera').style.display = 'Flex';
                }
                function displayPopup() {
                    document.getElementById('id01').style.display = 'Flex';
                }
                function xx() {
                    document.getElementById('idGrade').style.display = 'none';
                }
                function hideClass() {
                    document.getElementById('idClass').style.display = 'none';
                }
                function hideCam() {
                    document.getElementById('idCamera').style.display = 'none';
                }
                function duplicateIP() {
                    var message = ' <%=Resources.Resource.AlertErrorIP%>'
                    alert(message);
                }
                function CamIns() {
                    var message = ' <%=Resources.Resource.AlertDeviceSuccess%>'
                     alert(message);
                }
                function camError() {
                    var message = ' <%=Resources.Resource.AlertError%>'
                     alert(message);
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
                    return '<div class="form-group">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Grade %>" CssClass=" control-label" Font-Bold="True"/>' +
                        '<div ><input name = "DynamicTextBox" class="form-control" type="text" value = "' + value + '" /></div></div>'
                }

                function AddTextGrade() {
                    var div = document.createElement('DIV');
                    div.innerHTML = GetDynamicTextBox("");
                    document.getElementById("TextBoxContainer").appendChild(div);

                }

                function GetDynamicTextClass(value) {
                    return '<div class="form-group">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Class %>" CssClass=" control-label" Font-Bold="True"/>' +
                        '<input name = "DynamicTextClass" class="form-control" type="text" value = "' + value + '" /></div>' +
                        '<div class="form-group">'
                }

                function AddTextClass() {
                    var div = document.createElement('DIV');
                    div.innerHTML = GetDynamicTextClass("");
                    document.getElementById("TextContainer").appendChild(div);
                }
                function GetDynamicCamDetails(value) {
                    return '<p style="color: #C0C0C0"><span><%=Resources.Resource.AddCam%></span></p><section><div class="form-horizontal">'
            + '<table style="width:100%;"><tr><td style="text-align:center"> <div class = "form-group">' +
            '<asp:label runat="server" Text="<%$Resources:Resource, CamIP %>" CssClass=" control-label" Fond-Bold="True"/>' +
            '<div ><input name="IP" class="form-control" type="text" value="' + value + '"/></div></div></td>' +
            '<td style="text-align:center"><div class = "form-group">' +
            '<asp:label runat="server" Text="<%$Resources:Resource, PortNo %>" CssClass=" control-label" Fond-Bold="True"/>' +
            '<div ><input name="Port" class="form-control" type="text" value="' + value + '"' +
            '</div></div></td></tr>' +
            '<tr><td style="text-align:center"><div class = "form-group">' +
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
            </script>
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

                    <div class="row space">
                        
                                <div class="form-group">
                                    <asp:Label runat="server" Text="<%$Resources:Resource, CamIP %>" CssClass=" control-label" AssociatedControlID="camEditIP"></asp:Label>
                                    <div>
                                        <asp:TextBox runat="server" ID="camEditIP" CssClass="form-control" Enabled="false"></asp:TextBox>
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
                        <div class="row" style="width:50%; margin-top:50px; float:left;margin-right:30px;">
                             <div class="col">   <asp:Button ID="cancelCamEdit" Text="<%$Resources:Resource, Cancel %>" runat="server" OnClientClick="hideEdit(); return false;" />
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
                    <div class="row space" style="padding-left: 20px; padding-top: 40px;">
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
            

            <script>
                function Rename() {
                    document.getElementById('DivRename').style.display = 'Flex';
                }
                function EditCam() {
                    document.getElementById('edit').style.display = 'Flex';
                }
                function hideEdit() {
                    document.getElementById('edit').style.display = 'none';
                }
                function hideRename() {
                    document.getElementById('DivRename').style.display = 'none';
                }
                function DeviceNotEdit() {
                    var message = '<%=Resources.Resource.AlertEditIP%>'
                    alert(message);
                }
                function donothing() {
                    var message = '<%=Resources.Resource.AlertEditNot%>'
                    alert(message);
                }
            </script>

            <%--Edit all detals finished--%>

            <%--Delete Starts--%>
              
            <div id="del" class="modal">
                <div class="modal-content" style="width: 350px; min-height: 150px">
                    <div class=" row " style="padding-right: 20px;">
                       
                        <span onclick="hideDelConfirm();"
                            class="w3-button w3-display-topright">&times;</span>
                    </div>
                    <div class="row space">
                        <asp:TextBox runat="server" ID="delvalue" Visible="false"></asp:TextBox>
                        <p class="text-danger"><span><%=Resources.Resource.ConfirmDelete%></span></p>
                        </div>
                    <div class="row">
                        <div style="width:50%">
                        <asp:Button ID="btndel" runat="server" Text="<%$Resources:Resource, YesDelete %>" OnClick="Btndel_Click" />
                        </div>
                            <div style="width:50%">
                            <asp:Button ID="delcancel" runat="server" Text="<%$Resources:Resource, Cancel %>" OnClientClick="hideDelConfirm(); return false;" />
                    
                            </div></div>
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
                    <div class="row space">
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
        function ConfirmDel() {
            document.getElementById('del').style.display = 'Flex';
        }
        function hideDelConfirm() {
            document.getElementById('del').style.display = 'none';
        }
        function hideDelNot() {
            document.getElementById('delnot').style.display = 'none';
        }
        function nodelete() {
            var message = '<%=Resources.Resource.AlertDelete%>';
            alert(message);
        }
    </script>
      <script>
                    // Get the modal
                var c = document.getElementById('idClass');
                var modal = document.getElementById('id01');
                var m = document.getElementById('idGrade');
                var cam = document.getElementById('idCamera');
                var del = document.getElementById('del');
                var dn = document.getElementById('delnot');
          var ec = document.getElementById('edit');
          
          // When the user clicks anywhere outside of the modal, close it
          window.onclick = function (event) {
                    if (event.target == del) {
                        del.style.display = "none";
                    }

                    else if (event.target == cam) {
                        
                        cam.style.display = "none";
                       
                    }
                    else if (event.target == modal) {
                        modal.style.display = "none";
                    }
                    else if (event.target == m) {
                        m.style.display = "none";
                    }
                    else if (event.target == c) {
                        c.style.display = "none";
                    }
                    else if (event.target == dn) {
                        dn.style.display = "none";
                    }
                    else if (event.target == ec) {
                        ec.style.display = 'none';
                    }
                }
                function closeframe() {
                    document.getElementById('id01').style.display = "none";
                }
                </script>
    <%--Delete finished--%>
</asp:Content>
