<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Options.aspx.cs" Inherits="WebCresij.Options" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<%@ MasterType VirtualPath="~/Master.master" %>
   <asp:Content ID="Head" ContentPlaceHolderID="MasterHead" runat="server">
       
 
        <link href="Content/bootstrap.css" rel="stylesheet" />
       <link href="Content/font-awesome.css" rel="stylesheet" />
      
       <link href="Content/options.css" rel="stylesheet" />
       <script src="Scripts/bootstrap.js"></script>
        
       <link href="http://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" rel="Stylesheet"
        type="text/css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>

   </asp:Content>
   
    <asp:Content ID="Main" ContentPlaceHolderID="masterBody" runat="server">
        <asp:ScriptManagerProxy ID="sc1" runat="server"></asp:ScriptManagerProxy>
        
        <div style="opacity:0.8;" >   
    
       <div class="leftspace" oncontextmenu="return false;" >
       <asp:UpdatePanel runat="server">
           <ContentTemplate>        
       <cc1:TabContainer runat="server" BorderStyle="None" CssClass="TabHeaderCSS" >
           <cc1:TabPanel ID="addpaneltab"  runat="server"   BorderStyle="None" >
                <HeaderTemplate >
           <i class="fa fa-plus" aria-hidden="true"></i>&nbsp;Add
       </HeaderTemplate>
               <ContentTemplate>                  
                   <asp:LinkButton runat="server" Text="Add Institutes" ID="AddInstitutes" OnClientClick="displayPopup(); return false;" Font-Underline="True" 
                       Font-Bold="True" Font-Size="20px" ForeColor="#2f323a"></asp:LinkButton>                                       
                          <asp:treeView ID="TreeMenuView1"   EnableClientScript="true"  runat="server" 
                              OnSelectedNodeChanged="TreeMenuView1_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" ToolTip="Add new Details" PopulateNodesFromClient="true" ForeColor="#2F323A" ShowCheckBoxes="None">                    
                         </asp:treeView>                   
               </ContentTemplate>
           </cc1:TabPanel>
           <cc1:TabPanel  runat="server" ID="editpaneltab"  BorderStyle="None" >
               <HeaderTemplate>
           <i class="fas fa-edit" aria-hidden="true"></i>&nbsp;Edit
       </HeaderTemplate>
               <ContentTemplate>
                   <asp:TextBox runat="server" Visible="false" ></asp:TextBox>
               <asp:treeView ID="TreeViewEdit" ToolTip="Edit Details" runat="server"  
                   OnSelectedNodeChanged="TreeViewEdit_SelectedNodeChanged"  NodeStyle-NodeSpacing="5px" CssClass="leftspace" ForeColor="#2F323A">
                    
                </asp:treeView>
                   </ContentTemplate>
           </cc1:TabPanel>
           <cc1:TabPanel runat="server" ID="deletepaneltab" BorderStyle="None" >
               <HeaderTemplate>
           <i class="fa fa-minus-circle" aria-hidden="true"></i>&nbsp;Delete
       </HeaderTemplate>
               <ContentTemplate>
               <asp:treeView ID="TreeViewDelete" ToolTip="Delete Details" runat="server" 
                   OnSelectedNodeChanged="TreeViewDelete_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" ForeColor="#2F323A">
                    
                </asp:treeView>
                   </ContentTemplate> 
           </cc1:TabPanel>
       </cc1:TabContainer>
               </ContentTemplate>
       </asp:UpdatePanel>
          </div>     
      
       

 <%--Add all details--%>

           <div style="position:center; margin-top:400px"> 
                 <div id="id01" class="modal">
            <div class="modal-content" >
                <header class="row" >
                    <span onclick="document.getElementById('id01').style.display='none'"
                           class="w3-button w3-display-topright">&times;</span>
                    <h2>Add Institutes And Grades</h2>
                </header>
                <div class="row" >  
                    <iframe width="100%" height="500"  id="Iframe1" src="~/addDetails.aspx" runat="server" frameBorder="0"></iframe>               
                </div>
            </div>
        </div>
                <div id="idGrade" class="modal" >
  <!-- Modal content -->
  <div class="modal-content">
      <div class=" row " style=" padding-right:20px; " >          
                        <div class="panel-heading col " >
                            <h4>Add Grades</h4>                            
                        </div> 
          <span class="close col" onclick="xx();" style="text-align:right">&times;</span>
                        </div>
      <div class="row space">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                      <asp:TextBox ID="instext" runat="server" Visible="false"></asp:TextBox>
                <div id="TextBoxContainer" class="form-horizontal">           
        <div class="form-group">
            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="Grade_Name" CssClass=" control-label" Text="Grade"></asp:Label>
            <div >
                <asp:TextBox runat="server" ID="Grade_Name" CssClass="form-control"  />
            </div>
        </div>
                       
        </div>
        <asp:Button ID="btnaddgrade" Text="Add Grade" runat="server"  OnClientClick="AddTextGrade(); return false;" />
        <asp:Button ID="save" Text="Save" runat="server" OnClientClick="hideGrade();"  OnClick="btnGradesave_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
          
      </div>
      </div>
                    </div>
      

          <div id="idClass" class="modal" >
            <div class="modal-content" >
                <div class=" row " style=" padding-right:20px; " >          
                        <div class="panel-heading col " >
                    <h4>Add Class</h4>
                            </div>
                    <span class="close col" onclick="hideClass();" style="text-align:right">&times;</span>
                </div>
                <div class="row space" >                  
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <asp:TextBox runat="server" ID="TextGrade" Visible="false"  />
                <div id="TextContainer" class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" Text="Class" AssociatedControlID="TextGrade" CssClass=" control-label" Font-Bold="True"></asp:Label>
            <div>
                <asp:TextBox runat="server" ID="Class_Name" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
          
        </div>
        <asp:Button ID="BtnClass" Text="Add Class" runat="server"  OnClientClick="AddTextClass(); return false;" />
        <asp:Button ID="BtnClassSave" Text="Save" runat="server" OnClientClick="hideClass();" OnClick="BtnClassSave_Click"/>
            </ContentTemplate>
        </asp:UpdatePanel>
                    </div>
            </div>
        </div>
                   
        <div id="idCamera" class="modal" >
            <div class="modal-content"  >
                <div class=" row " style=" padding-right:20px; " >          
                        <div class="panel-heading col " >
                             <h4>Add Device Details</h4></div>
                    <span onclick="hideCam();"
                          class="w3-button w3-display-topright">&times;</span>
                   
                </div>
                <div class="row space" >
                  
        <asp:UpdatePanel runat="server" ID="AddCam">
                        <ContentTemplate>                            
                               <hr />
                            <asp:TextBox Visible="false" runat="server" ID="tbSelectedClass"></asp:TextBox>
                               <div class="form-group">
                            <asp:Label Text="Central Control System IP Address" AssociatedControlID="ccSystem" runat="server" CssClass=" control-label" Font-Bold="True"></asp:Label>
                            <asp:TextBox runat="server" CssClass="form-control" id="ccSystem"></asp:TextBox>
                                   </div>
                            <div id="camdiv">
                                </div>                          
                            <br />
             <asp:Button ID="btncam" Text="Add Camera Details" runat="server"  OnClientClick="AddTextCam(); return false;" />            
        <asp:Button ID="BtnCamSave" Text="Save" runat="server" OnClick="BtnCamSave_Click"/>                                                          
                        </ContentTemplate>
                    </asp:UpdatePanel>             
            </div>
        </div>
        </div> 
    <script>
        function displayGrade()
        {
            document.getElementById('idGrade').style.display = 'block';
        }
        function displayClass() {
            document.getElementById('idClass').style.display = 'block';
        }
        function displayCam() {
            document.getElementById('idCamera').style.display = 'block';
        }
    function displayPopup() {
        document.getElementById('id01').style.display = 'block';
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
            alert("Can not have same IP address in this institute!!\n Please enter different one!!")
        }   
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
       
// Get the modal
    function GetDynamicTextBox(value){
        return '<div class="form-group">' + '<asp:Label runat="server" Text="Grade" CssClass=" control-label" Font-Bold="True"/>' +
           '<div ><input name = "DynamicTextBox" class="form-control" type="text" value = "' + value + '" /></div></div>'
    }
             
    function AddTextGrade() {
        var div = document.createElement('DIV');
        div.innerHTML = GetDynamicTextBox("");
        document.getElementById("TextBoxContainer").appendChild(div);
    
    }

    function GetDynamicTextClass(value){
        return '<div class="form-group">' + '<asp:Label runat="server" Text="Class" CssClass=" control-label" Font-Bold="True"/>' +
            '<input name = "DynamicTextClass" class="form-control" type="text" value = "' + value + '" /></div>' +
            '<div class="form-group">' 
    }

    function AddTextClass() {
        var div = document.createElement('DIV');
        div.innerHTML = GetDynamicTextClass("");
        document.getElementById("TextContainer").appendChild(div);
    }

    function GetDynamicCamDetails(value) {
        return '<p style="color: #C0C0C0">Add Camera Details</p><section><div class="form-horizontal"><table style="width:100%;"><tr><td style="text-align:center"> <div class = "form-group">' + '<asp:label runat="server" Text="Camera IP" CssClass=" control-label" Fond-Bold="True"/>' +
                     '<div ><input name="IP" class="form-control" type="text" value="' + value + '"/></div></div></td>' +
                 '<td style="text-align:center"><div class = "form-group">' + '<asp:label runat="server" Text="Port No" CssClass=" control-label" Fond-Bold="True"/>' +
                     '<div ><input name="Port" class="form-control" type="text" value="' + value + '"/></div></div></td></tr>' +
                 '<tr><td style="text-align:center"><div class = "form-group">' + '<asp:label runat="server" Text="UserID" CssClass=" control-label" Fond-Bold="True"/>' +
                     '<div ><input name="User" class="form-control" type="text" value="' + value + '"/></div></div></td>' +
                 '<td style="text-align:center"><div class = "form-group">' + '<asp:label runat="server" Text="Password" CssClass=" control-label" Fond-Bold="True"/>' +
                     '<div ><input name="Pass" class="form-control" type="text" value="' + value + '"/></div></div></td></tr></table></div><section>'
    }
    function AddTextCam() {
        var div = document.createElement('DIV');
        div.innerHTML = GetDynamicCamDetails("");
        document.getElementById("camdiv").appendChild(div);
    }
     
    
</script>


  <%--add all details finished--%>


  <%--Edit all details--%>
        <div id="edit" class="modal" >
            <div class="modal-content" >
                <div class=" row " style=" padding-right:20px; " >          
                        <div class="panel-heading col " >
                    
                    <h3>Edit Camera Details!!</h3>
                            </div>
                            <span onclick="hideEdit();"
                          class="w3-button w3-display-topright">&times;</span>
                </div>
                <div class="row space" >
               <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                        <ContentTemplate>
                            
                          <div class="form-group">
                              <asp:Label runat="server" Text="Camera IP" CssClass=" control-label" AssociatedControlID="camEditIP"></asp:Label>
                              <div >
                              <asp:TextBox runat="server" ID="camEditIP" CssClass="form-control" Enabled="false"></asp:TextBox></div>
                          </div>
                            <div class="form-group">
                              <asp:Label runat="server" Text="Port No" CssClass=" control-label" AssociatedControlID="portEdit"></asp:Label>
                              <div>
                              <asp:TextBox runat="server" ID="portEdit" CssClass="form-control"></asp:TextBox></div>
                          </div>
                            <div class="form-group">
                              <asp:Label runat="server" Text="ID" CssClass="control-label" AssociatedControlID="idEditcam"></asp:Label>
                              <div class="">
                              <asp:TextBox runat="server" ID="idEditcam" CssClass="form-control"></asp:TextBox></div>
                          </div>
                            <div class="form-group">
                              <asp:Label runat="server" Text="Password" CssClass=" control-label" AssociatedControlID="passEditcam"></asp:Label>
                              <div >
                              <asp:TextBox runat="server" ID="passEditcam" CssClass="form-control"></asp:TextBox></div>
                          </div>
                          
                            <br />
             <asp:Button ID="cancelCamEdit" Text="Cancel" runat="server"  OnClientClick="hideEdit(); return false;" />            
        <asp:Button ID="saveCamEdit" Text="Save" runat="server"    OnClick="saveCamEdit_Click"/>
                           
                                
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>
                
            </div>
        </div>
               
                  
        <asp:HiddenField id="renameText" runat="server" />
        <div id="DivRename" class="modal">
            <div class="modal-content" style="width:500px; height:250px;  text-align:center; " >
                 <div class=" row " style=" padding-right:20px; " >          
                        <div class="panel-heading col " >
                            <h4 >Edit Name</h4></div>
                    <span onclick="hideRename();"
                          class="w3-button w3-display-topright">&times;</span>                    
                </div>
                <div class="row space" style=" padding-left:40px;padding-top:40px;">
                <asp:Label runat="server" Text="New Name: " AssociatedControlID="tbRename"></asp:Label>
                <br />
                <asp:TextBox ID="tbRename" runat="server" CssClass="form-control"  ></asp:TextBox>
                <br />
                <asp:Button ID="saveRename" runat="server" Text="Save" OnClick="saveRename_Click" />
                <asp:Button ID="cancelRename" runat="server" Text="Cancel" OnClientClick="hideRename(); return false;" />
                    </div>
                </div>
            </div>

        <script>
            function Rename() {
                document.getElementById('DivRename').style.display = 'block';
            }
            function EditCam() {
                document.getElementById('edit').style.display = 'block';
            }
            function hideEdit() {
                document.getElementById('edit').style.display = 'none';
            }
            function hideRename() {
                document.getElementById('DivRename').style.display = 'none';
            }
            function DeviceNotEdit() {
                alert('Device Ip Can not be edited!! Please add a new device\n and delete the current device to make the changes');
            }
            function donothing() {
                alert('You cannot edit this!! Please expand more to edit devices!!');
            }
        </script>

 <%--Edit all detals finished--%>

        <%--Delete Starts--%>    
        
        <div id="del" class="modal" >
            <div class="modal-content" style="width:250px; min-height:150px" >
               <div class=" row " style=" padding-right:20px; " >          
                        <div class="panel-heading col " >
                            <h4>Delete!!!</h4>
                            </div>
                   <span onclick="hideDelConfirm();"
                          class="w3-button w3-display-topright">&times;</span>                    
                </div>
                <div class="row space"  >
                  <asp:TextBox runat="server" ID="delvalue" Visible="false"></asp:TextBox>
                    
                      <p class="text-danger">Are you sure you want to delete this?</p>
                    <br />
               <asp:Button ID="btndel" runat="server" Text="Yes, Delete" OnClick="btndel_Click"  />
                    <asp:Button ID="delcancel" runat="server" Text="cancel" OnClientClick="hideDelConfirm(); return false;" />
                    </div>
        </div>
            </div>
        <div id="delnot" class="modal" >
            <div class="modal-content" style="width:250px" >
               <div class=" row " style=" padding-right:20px; " >          
                        <div class="panel-heading col " >
                            <h4>Delete!!</h4></div>
                    <span onclick="hideDelNot();"
                          class="w3-button w3-display-topright">&times;</span>
                    
                </div>
                <div class="row space" >
                  
                    <asp:TextBox runat="server" ID="TextBox1" Visible="false"></asp:TextBox>
                    
                      <p class="text-danger">You are not allowed to delete this. Please delete sub categories first!!</p>
                    <br />
               <asp:Button ID="Button1" runat="server" Text="Ok, got it!"  OnClientClick="hideDelNot(); return false;" />
               
                    </div>
                
                
            </div>
        </div>
     
</div>   
     
        </div>
             
        <script>
            function ConfirmDel() {
                document.getElementById('del').style.display = 'block';
            }
            function hideDelConfirm() {
                document.getElementById('del').style.display = 'none';
            }
            function hideDelNot() {
                document.getElementById('delnot').style.display = 'none';
            }
            function nodelete() {
                alert('This cannot be deleted!! Please expand more to delete devices!!')
            }
        </script>
        <%--Delete finished--%>

 </asp:Content>