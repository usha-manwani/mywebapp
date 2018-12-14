<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="WebApplication1.Settings" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modal1 {
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
        .modal1-content {
    background-color: #fefefe;
    margin: auto;
    padding: 20px;
    border: 1px solid #888;
    width: 80%;
}

/* The Close Button */
.close {
    color: #aaaaaa;
    float: right;
    font-size: 28px;
    font-weight: bold;
}

    .close:hover,
    .close:focus {
        color: #000;
        text-decoration: none;
        cursor: pointer;
    }

     .w3-modal{
              z-index:3;display:none;
              padding-top:100px;
              padding-left:30px;
              position:fixed;
              left:0;top:0;
              width:100%;
              height:100%;
              overflow:auto;
              background-color:rgb(0,0,0);
              background-color:rgba(0,0,0,0.4)}
.w3-modal-content{
    margin:auto;background-color:#fff;
    position:relative;  
    padding:10px 10px 10px 40px;
    outline:0;
    width:600px}

.form-control {
	width: 60%
}
.form-horizontal.style-form .form-group {
	border-bottom: 1px solid #eff2f7;
	padding-bottom: 15px;
	margin-bottom: 15px;
    padding-left:30px;
}

.round-form {
	border-radius: 500px;
	-webkit-border-radius: 500px;
}

@media (min-width: 768px) {
		.form-horizontal .control-label {
		text-align: left;
	}
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="row">
          <div class="col-lg-9 ">
            <!--CUSTOM CHART START -->
            <div class="border-head">
              <h3>Devices and Locations</h3>
            </div>
        <asp:ScriptManagerProxy ID="sc1" runat="server"></asp:ScriptManagerProxy>
        
       <%-- <div style="opacity:0.8;" >
   <div Class="divopt" >
    
       <div class="leftspace">--%>
       
       <cc1:TabContainer runat="server" BorderStyle="None" BackColor="#444C57">
           <cc1:TabPanel ID="addpaneltab" BackColor="#444C57" runat="server" HeaderText="Add" BorderStyle="None">
               <ContentTemplate>                  
                   <asp:LinkButton runat="server" Text="Add Institutes" ID="AddInstitutes" OnClientClick="displayPopup(); return false;" Font-Underline="True" Font-Bold="True" Font-Size="20px"></asp:LinkButton>                                       
                          <asp:treeView ID="TreeMenuView1"   EnableClientScript="true"  runat="server" OnSelectedNodeChanged="TreeMenuView1_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" ToolTip="Add new Details" PopulateNodesFromClient="true" ForeColor="White">                    
                         </asp:treeView>                   
               </ContentTemplate>
           </cc1:TabPanel>
           <cc1:TabPanel BackColor="#444C57" runat="server" ID="editpaneltab" HeaderText="Edit" BorderStyle="None">
               <ContentTemplate>
                   <asp:TextBox runat="server" Visible="false" ></asp:TextBox>
               <asp:treeView ID="TreeViewEdit" ToolTip="Edit Details" runat="server" OnSelectedNodeChanged="TreeViewEdit_SelectedNodeChanged"  NodeStyle-NodeSpacing="5px" CssClass="leftspace" ForeColor="White">
                    
                </asp:treeView>
                   </ContentTemplate>
           </cc1:TabPanel>
           <cc1:TabPanel BackColor="#444C57" runat="server" ID="deletepaneltab" BorderStyle="None" HeaderText="Delete">
               <ContentTemplate>
               <asp:treeView ID="TreeViewDelete" ToolTip="Delete Details" runat="server" OnSelectedNodeChanged="TreeViewDelete_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" ForeColor="White">
                    
                </asp:treeView>
                   </ContentTemplate> 
           </cc1:TabPanel>
       </cc1:TabContainer>

          </div> 

          <div class="col-lg-3 ds">
              </div>
         <div>
         <button id="myBtn" >Open Modal</button>
         <div id="myModal" class="modal1">

  <!-- Modal content -->
  <div class="modal1-content">
    <span class="close">&times;</span>
    <p>Some text in the Modal..</p>
  </div>

</div>
             </div>
       </div>
       

 <%--Add all details--%>


      <div class="w3-container"  >
        
        <div id="id01" class="w3-modal">
            <div class="w3-modal-content w3-card-4" >
                <header class="w3-container ">
                    <span onclick="document.getElementById('id01').style.display='none'" class="pull-right">
                          &times;</span>
                    <h2>Add Institutes And Grades</h2>
                </header>
                <div class="w3-container" >
                  
                    
                        <iframe width="500" height="600"  id="Iframe1" src="~/addDetails.aspx" runat="server" frameBorder="0"></iframe>
               
                    </div>
                
                <footer class="w3-container w3-teal">
                   
                </footer>
            </div>
        </div>
     
</div>
    <div id ="noMoreAdd" class="w3-modal" runat="server">
        <div class="w3-modal-content">
            <span onclick="hideGrade();" class="pull-right">
                         &times;</span>
            <p>Please click on class names to update Camera or Control Device Details</p>
            <input class="btn btn-default" type="button" onclick="hideNoMoreAdd" id="stop" />
        </div>
    </div>
   <%-- <script>
        $(document).On("click", "stop", function () {
            var di = document.getElementById("#noMoreAdd");
            di.style.display = none;
        });
    </script>--%>
        <div class="w3-container">
          <div id="idGrade" class="w3-modal" runat="server" >
            <div class="w3-modal-content w3-card-4" >
                <header class="w3-container w3-teal">
                    <span onclick="hideGrade();" class="pull-right">
                         &times;</span>
                    <h2>Add Grades</h2>
                </header>
                <div class="w3-container" >
                  
        <asp:UpdatePanel runat="server" ID="updateGrade">
            <ContentTemplate>
                <asp:TextBox ID="instext" runat="server" Visible="false"></asp:TextBox>
                <div id="TextBoxContainer" class="form-horizontal">       
        <h4>Add New Grades</h4>
        <hr />       
        <div class="form-group">
            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="Grade_Name" CssClass=" control-label" Text="Grade"></asp:Label>
            <div >
                <asp:TextBox runat="server" ID="Grade_Name" CssClass="form-control"  />
            </div>
        </div>
                       
        </div>
        <asp:Button ID="btnaddgrade" CssClass="btn btn-default" Text="Add Grade" runat="server"  OnClientClick="AddTextGrade(); return false;" />
        <asp:Button ID="save" Text="Save" runat="server" OnClientClick="hideGrade();" CssClass="btn btn-default"   OnClick="btnGradesave_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
                    </div>
                
                <footer class="w3-container w3-teal">
                   
                </footer>
            </div>
        </div>
            </div>


        <div class="w3-container">
          <div id="idClass" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-4" >
                <header class="w3-container w3-teal">
                    <span onclick="hideClass();"
                         class="pull-right" >&times;</span>
                    <h2>Add Class</h2>
                </header>
                <div class="w3-container" >
                  
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                
                <div id="TextContainer" class="form-horizontal">
       
        <h4>Add New Class</h4>
        <hr />
        
        <div class="form-group">
            <asp:Label runat="server" Text="Selected Grade " AssociatedControlID="TextGrade" CssClass=" control-label" Font-Bold="True"></asp:Label>
            <div>
                <asp:TextBox runat="server" ID="TextGrade" CssClass="form-control" Enabled="false"  />
            </div>
        </div>
            
            
        </div>
        <asp:Button CssClass="btn btn-default" ID="BtnClass" Text="Add Class" runat="server"  OnClientClick="AddTextClass(); return false;" />
        <asp:Button ID="BtnClassSave" Text="Save" runat="server" OnClientClick="hideClass();"  CssClass="btn btn-default"  OnClick="BtnClassSave_Click"/>
            </ContentTemplate>
        </asp:UpdatePanel>
                    </div>
                
                <footer class="w3-container w3-teal " >
                   
                </footer>
            </div>
        </div>
            </div>
        <div class="w3-container">
            
        <div id="idCamera" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-4"  >
                <header class="w3-container w3-teal">
                    <span onclick="hideCam();"
                          class="pull-right">&times;</span>
                    <h2>Add Control Device and Camera Details</h2>
                </header>
                <div class="w3-container" >
                  
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
             <asp:Button ID="btncam" Text="Add Camera Details" CssClass="btn btn-default" runat="server"  OnClientClick="AddTextCam(); return false;" />            
        <asp:Button ID="BtnCamSave" Text="Save" runat="server" CssClass="btn btn-default"   OnClick="BtnCamSave_Click"/>
                           
                                
                        </ContentTemplate>

                    </asp:UpdatePanel>
                   
                 
               
            </div>
        </div>

        </div>
            </div>
        

         <script>
           var modal = document.getElementById('myModal');

// Get the button that opens the modal
var btn = document.getElementById("myBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal 
btn.onclick = function() {
    modal.style.display = "block";
    return false;
}

// When the user clicks on <span> (x), close the modal
span.onclick = function() {
    modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
            function displayGrade()
        {
               document.getElementById('idGrade').style.display = 'block';
        }

 function displayPopup() {
               document.getElementById('id01').style.display = 'block';
            }
// Get the modal
var c = document.getElementById('<%=idClass.ClientID%>');
             var insmodal = document.getElementById('id01');
             var m = document.getElementById('<%=idGrade.ClientID%>');
             var cam = document.getElementById('<%=idCamera.ClientID%>');
             var del = document.getElementById('<%=del.ClientID%>');
             var dn = document.getElementById('<%=delnot.ClientID%>');
             var ec = document.getElementById('<%=edit.ClientID%>');
// When the user clicks anywhere outside of the modal, close it
           
         
          
     
             window.onclick = function (event) {

                 if (event.target == del) {
                     del.style.display = "none";
                 }

                 else if (event.target == cam) {
                     cam.style.display = "none";
                 }
                 else if (event.target == modal) {
                     insmodal.style.display = "none";
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
            '<div class="form-group">' +
            '<asp:Label Text="Central Control System IP Address" AssociatedControlID="ccSystem" runat="server" CssClass=" control-label" Font-Bold="True"></asp:Label>' +
                     '<input name="ccSystem"  class="form-control" type="text" value = "' + value + '" /></div>'
                                   
               }

             function AddTextClass() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextClass("");
    document.getElementById("TextContainer").appendChild(div);
    
             }

             function GetDynamicCamDetails(value) {
                 return '<p style="color: #C0C0C0">Add Camera Details</p><section> <div class="form-horizontal"><div class = "form-group">' + '<asp:label runat="server" Text="Camera IP" CssClass=" control-label" Fond-Bold="True"/>' +
                     '<div ><input name="IP" class="form-control" type="text" value="' + value + '"/></div></div>' +
                 '<div class = "form-group">' + '<asp:label runat="server" Text="Port No" CssClass=" control-label" Fond-Bold="True"/>' +
                     '<div ><input name="Port" class="form-control" type="text" value="' + value + '"/></div></div>' +
                 '<div class = "form-group">' + '<asp:label runat="server" Text="UserID" CssClass=" control-label" Fond-Bold="True"/>' +
                     '<div ><input name="User" class="form-control" type="text" value="' + value + '"/></div></div>' +
                 '<div class = "form-group">' + '<asp:label runat="server" Text="Password" CssClass=" control-label" Fond-Bold="True"/>' +
                     '<div ><input name="Pass" class="form-control" type="text" value="' + value + '"/></div></div></div><section>'
             }

             function AddTextCam() {
                 var div = document.createElement('DIV');
                 div.innerHTML = GetDynamicCamDetails("");
                 document.getElementById("camdiv").appendChild(div);
             }
     
        function hideGrade() {
           document.getElementById('<%=idGrade.ClientID%>').style.display = 'none';
            
             }
             function hideClass() {
           document.getElementById('<%=idClass.ClientID%>').style.display = 'none';
            
             }
             function hideCam() {
           document.getElementById('<%=idCamera.ClientID%>').style.display = 'none';
            
             }
        
</script>


  <%--add all details finished--%>


  <%--Edit all details--%>


         <div class="w3-container"  >
        
        <div id="edit" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-4" >
                <header class="w3-container w3-teal">
                    <span onclick="hideEdit();"
                          class="pull-right">&times;</span>
                    <h3>Edit Camera Details!!</h3>
                </header>
                <div class="w3-container" >
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
             <asp:Button ID="cancelCamEdit" CssClass="btn btn-default" Text="Cancel" runat="server"  OnClientClick="hideEdit(); return false;" />            
        <asp:Button ID="saveCamEdit" Text="Save" runat="server" OnClientClick="hideEdit(); return false;" CssClass="btn btn-default"  OnClick="saveCamEdit_Click"/>
                           
                                
                        </ContentTemplate>

                    </asp:UpdatePanel>
                </div>
                
            </div>
        </div>
     
</div>

         <div class="w3-container"  >
        
        <div id="DivRename" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-4" style="width:500px; height:250px;  text-align:center; " >
                <header class="w3-container w3-teal">
                    <span onclick="hideRename();"
                          class="pull-right">&times;</span>
                    <h3 >Edit Name</h3>
                </header>
                <div class="w3-container" style=" padding-left:40px;padding-top:40px;">
                <asp:Label runat="server" Text="New Name: " AssociatedControlID="tbRename"></asp:Label>
                <br />
                <asp:TextBox ID="tbRename" runat="server" CssClass="form-control"  ></asp:TextBox>
                <br />
                <asp:Button ID="saveRename" runat="server" CssClass="btn btn-default" Text="Save" OnClick="saveRename_Click" />
                <asp:Button ID="cancelRename" runat="server" Text="Cancel" CssClass="btn btn-default" OnClientClick="hideRename(); return false;" />
                    </div>
                </div>
            </div>
             </div>

        <script>
            function hideEdit() {
                document.getElementById('<%=edit.ClientID%>').style.display = 'none';
            }
            function hideRename() {
                document.getElementById('<%=DivRename.ClientID %>').style.display = 'none';
            }

        </script>

 <%--Edit all detals finished--%>

        <%--Delete Starts--%>
       

         <div class="w3-container"  >
        
        <div id="del" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-4" style="width:250px; min-height:150px" >
                <header class="w3-container w3-teal">
                   <span onclick="hideDelConfirm();"
                          class="pull-right">&times;</span>
                    <h3>Delete!!!</h3>
                </header>
                <div class="w3-container"  >
                  <asp:TextBox runat="server" ID="delvalue" Visible="false"></asp:TextBox>
                    
                      <p class="text-danger">Are you sure you want to delete this?</p>
                    <br />
               <asp:Button ID="btndel" runat="server" CssClass="btn btn-default" Text="Yes, Delete" OnClick="btndel_Click"  />
                    <asp:Button ID="delcancel"  CssClass="btn btn-default" runat="server" Text="cancel" OnClientClick="hideDelConfirm(); return false;" />
                    </div>
                
               
            </div>
        </div>
     
</div>
        
           <div class="w3-container"  >
        
        <div id="delnot" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-4" style="width:250px" >
                <header class="w3-container w3-teal">
                    <span onclick="hideDelNot();"
                          class="pull-right">&times;</span>
                    <h3>Delete!!</h3>
                </header>
                <div class="w3-container" >
                  
                    <asp:TextBox runat="server" ID="TextBox1" Visible="false"></asp:TextBox>
                    
                      <p class="text-danger">You are not allowed to delete this. Please delete sub categories first!!</p>
                    <br />
               <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Ok, got it!"  OnClientClick="hideDelNot(); return false;" />
                  
                        
               
                    </div>
                
                
            </div>
        </div>
     
</div>   
            
        
        <script>
            
            function hideDelConfirm() {
                document.getElementById('<%=del.ClientID%>').style.display = 'none';
            }
            function hideDelNot() {
                document.getElementById('<%=delnot.ClientID%>').style.display = 'none';
            }
        </script>
        <%--Delete finished--%>

</asp:Content>
