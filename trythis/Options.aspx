<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Options.aspx.cs" Inherits="trythis.Options" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<%@ MasterType VirtualPath="~/Site.master" %>
   <asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
       
 
      
      
       <link href="http://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" rel="Stylesheet"
        type="text/css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
      

       <style>
           /*.divopt{
               min-height:700px;
               width:auto;
               background-color: #2D2D2D;
               color: #FFFFFF;
               font-family: Arial, Helvetica, sans-serif;
               overflow:hidden;
               margin-left:10px;
               margin-top:20px;
               margin-bottom:20px;
                   
           }*/
          .leftspace{
              
              
              margin-right:20px;
              height:inherit;
              margin-bottom:20px;
              
          }
          .w3-modal{
              z-index:3;display:none;
              padding-top:100px;
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
    padding:0;
    outline:0;
    width:600px}


       </style>
       
       
       

   </asp:Content>
   
    <asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
        <asp:ScriptManagerProxy ID="sc1" runat="server"></asp:ScriptManagerProxy>
        
        <div style="opacity:0.8;" >
   <div Class="divopt" >
       <div class="leftspace">
       
       <cc1:TabContainer runat="server" BorderStyle="None">
           <cc1:TabPanel ID="addpaneltab" runat="server" HeaderText="Add" >
               <ContentTemplate>
                  
                   <asp:LinkButton runat="server" Text="Add Institutes" ID="AddInstitutes" OnClientClick="displayPopup(); return false;" Font-Underline="True" Font-Bold="True" Font-Size="20px"></asp:LinkButton>
                 
                      
                          <asp:treeView ID="TreeMenuView1"   EnableClientScript="true"  runat="server" OnSelectedNodeChanged="TreeMenuView1_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" ToolTip="Add new Details" PopulateNodesFromClient="true" >
                    
                         </asp:treeView>
 
                   
               </ContentTemplate>
           </cc1:TabPanel>
           <cc1:TabPanel runat="server" ID="editpaneltab" HeaderText="Edit">
               <ContentTemplate>
                   <asp:TextBox runat="server" Visible="false" ></asp:TextBox>
               <asp:treeView ID="TreeViewEdit" ToolTip="Edit Details" runat="server" OnSelectedNodeChanged="TreeViewEdit_SelectedNodeChanged"  NodeStyle-NodeSpacing="5px" CssClass="leftspace" >
                    
                </asp:treeView>
                   </ContentTemplate>
           </cc1:TabPanel>
           <cc1:TabPanel runat="server" ID="deletepaneltab" HeaderText="Delete">
               <ContentTemplate>
               <asp:treeView ID="TreeViewDelete" ToolTip="Delete Details" runat="server" OnSelectedNodeChanged="TreeViewDelete_SelectedNodeChanged" NodeStyle-NodeSpacing="5px" CssClass="leftspace" >
                    
                </asp:treeView>
                   </ContentTemplate> 
           </cc1:TabPanel>
       </cc1:TabContainer>
          </div>     
       </div>
       

 <%--Add all details--%>


      <div class="w3-container"  >
        
        <div id="id01" class="w3-modal">
            <div class="w3-modal-content w3-card-4" >
                <header class="w3-container w3-teal">
                    <span onclick="document.getElementById('id01').style.display='none'"
                          class="w3-button w3-display-topright">&times;</span>
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
        <div class="w3-container">
          <div id="idGrade" class="w3-modal" runat="server" >
            <div class="w3-modal-content w3-card-4" >
                <header class="w3-container w3-teal">
                    <span onclick="hideGrade();"
                          class="w3-button w3-display-topright">&times;</span>
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
        <asp:Button ID="btnaddgrade" Text="Add Grade" runat="server"  OnClientClick="AddTextGrade(); return false;" />
        <asp:Button ID="save" Text="Save" runat="server" OnClientClick="hideGrade();"    OnClick="btnGradesave_Click" />
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
                          class="w3-button w3-display-topright">&times;</span>
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
        <asp:Button ID="BtnClass" Text="Add Class" runat="server"  OnClientClick="AddTextClass(); return false;" />
        <asp:Button ID="BtnClassSave" Text="Save" runat="server" OnClientClick="hideClass();"    OnClick="BtnClassSave_Click"/>
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
                          class="w3-button w3-display-topright">&times;</span>
                    <h2>Add Camera Details</h2>
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
             <asp:Button ID="btncam" Text="Add Camera Details" runat="server"  OnClientClick="AddTextCam(); return false;" />            
        <asp:Button ID="BtnCamSave" Text="Save" runat="server"    OnClick="BtnCamSave_Click"/>
                           
                                
                        </ContentTemplate>

                    </asp:UpdatePanel>
                   
                 
               
            </div>
        </div>

        </div>
            </div>
        

         <script>
            function displayGrade()
        {
               document.getElementById('idGrade').style.display = 'block';
        }

 function displayPopup() {
               document.getElementById('id01').style.display = 'block';
            }
// Get the modal
var c = document.getElementById('<%=idClass.ClientID%>');
             var modal = document.getElementById('id01');
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
                          class="w3-button w3-display-topright">&times;</span>
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
             <asp:Button ID="cancelCamEdit" Text="Cancel" runat="server"  OnClientClick="hideEdit(); return false;" />            
        <asp:Button ID="saveCamEdit" Text="Save" runat="server" OnClientClick="hideEdit(); return false;"   OnClick="saveCamEdit_Click"/>
                           
                                
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
                          class="w3-button w3-display-topright">&times;</span>
                    <h3  >Edit Name</h3>
                </header>
                <div class="w3-container" style=" padding-left:40px;padding-top:40px;">
                <asp:Label runat="server" Text="New Name: " AssociatedControlID="tbRename"></asp:Label>
                <br />
                <asp:TextBox ID="tbRename" runat="server" CssClass="form-control"  ></asp:TextBox>
                <br />
                <asp:Button ID="saveRename" runat="server" Text="Save" OnClick="saveRename_Click" />
                <asp:Button ID="cancelRename" runat="server" Text="Cancel" OnClientClick="hideRename(); return false;" />
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
                          class="w3-button w3-display-topright">&times;</span>
                    <h3>Delete!!!</h3>
                </header>
                <div class="w3-container"  >
                  <asp:TextBox runat="server" ID="delvalue" Visible="false"></asp:TextBox>
                    
                      <p class="text-danger">Are you sure you want to delete this?</p>
                    <br />
               <asp:Button ID="btndel" runat="server" Text="Yes, Delete" OnClick="btndel_Click"  />
                    <asp:Button ID="delcancel" runat="server" Text="cancel" OnClientClick="hideDelConfirm(); return false;" />
                    </div>
                
               
            </div>
        </div>
     
</div>
        
           <div class="w3-container"  >
        
        <div id="delnot" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-4" style="width:250px" >
                <header class="w3-container w3-teal">
                    <span onclick="hideDelNot();"
                          class="w3-button w3-display-topright">&times;</span>
                    <h3>Delete!!</h3>
                </header>
                <div class="w3-container" >
                  
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
            
            function hideDelConfirm() {
                document.getElementById('<%=del.ClientID%>').style.display = 'none';
            }
            function hideDelNot() {
                document.getElementById('<%=delnot.ClientID%>').style.display = 'none';
            }
        </script>
        <%--Delete finished--%>

 </asp:Content>