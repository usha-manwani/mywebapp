 <%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="CardReader.aspx.cs" Inherits="trythis.CardReader" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
<link href="css/stepper.css" rel="stylesheet" />
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">    
    <link href="css/Card.css" rel="stylesheet" />
        <script src="Scripts/jquery.signalR-2.4.0.js"></script>
        <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
    
   <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="Scripts/CardReader.js"></script>
      <div>
           <div class="panel-heading col " >
                            <h4><p>Card Registration</p></h4> 
                        </div>
        <div class="stepper d-flex flex-column mt-5 ml-2">
    <div class="d-flex mb-1">
      <div class="d-flex flex-column pr-4 align-items-center">
        <div class="rounded-circle py-2 px-3 bg-primary text-white mb-1">1</div>
        <div class="line h-100" ></div>
      </div>
      <div>
        <h5 class="text-dark">Scan Card </h5>
        <p class="lead text-muted pb-3">Please Scan Card and Add User Details <h6>Once the card is scanned, a table to add the user data will appear. After adding all the details, click 'OK'.</h6>
        </p>
      </div>
    </div>
    <div class="d-flex mb-1">
      <div class="d-flex flex-column pr-4 align-items-center">
        <div class="rounded-circle py-2 px-3 bg-primary text-white mb-1">2</div>
        <div class="line h-100 "></div>
      </div>
      <div>
        <h5 class="text-dark">Provide Access to User</h5>
        <p class="lead text-muted pb-3">After completing step 1, you can give access to User to Register the card.
            <h6> You can select access level and options from the
                Select Access link in the table. Click on Register 
                once done with providing access to register the card</h6>
        </p>
      </div>
    </div>
             <div class="d-flex mb-1">
      <div class="d-flex flex-column pr-4 align-items-center">
        <div class="rounded-circle py-2 px-3 bg-primary text-white mb-1">3</div>
        <div class="line h-100 d-none"></div>
      </div>
      <div>
        <h5 class="text-dark">Check Card Status</h5>
        <p class="lead text-muted pb-3">Please check the current status of card(s) that you register. 
            <h6> You might want to check if the scanned card is registered to all locations or is in pending state.
                You can check and try to update it &nbsp;<a class=" linkstyle"
                    style=" color: blue; text-decoration: underline;" onclick="openGrid();">here</a> 
            </h6>
        </p>
      </div>
    </div>
  
  </div>

          <asp:Label ID="iptosend" runat="server" CssClass="displaynone" Text=""></asp:Label>
          <asp:Label ID="datatosend" runat="server" CssClass="displaynone" Text=""></asp:Label>
         <div id="myModal" class="modal" >
  <!-- Modal content -->
  <div class="modal-content">
    
        
      <div class=" row " style=" padding-right:20px; background-color:#4ECDC4 " >
          
                        <div class="panel-heading col " >
                            <h4><p>Card Registration</p></h4>
                            
                        </div> 
          <span class="close col" onclick="xx();" style="text-align:right">&times;</span>
                        </div>
      <div id="tablescan">
      <asp:UpdatePanel ID="up1" runat="server">
                 <ContentTemplate>
       <div class="table-responsive col-md-12">
           <input type="hidden" id="checkcard" value="" />
           <input type="hidden" value="0" id="hiddencount" />
      <table id="cardtable" style="font-size:Small;border-collapse:collapse; width:100%" cellspacing="0" rules="all" border="1" >
          <thead>
         <tr class="table table-striped table-bordered table-hover" align="center" style="background-color:PaleTurquoise;font-weight:normal;">
             <th scope="col">Serial Number</th>
              <th scope="col">Member ID</th>
             <th scope="col">Name of Person</th>
             <th scope="col"> Card ID</th>
             <th scope="col"> Comments</th>
             
         </tr>
        </thead>
         
      </table>
           </div>
                  
      <asp:Button CssClass="btn btn-round btn-navbar" runat="server" Width="100px" OnClick="Unnamed_Click" ID="btnSave1"  Text="OK" />
                     <button type="button" class="btn btn-round btn-navbar" onclick="xx();">Cancel</button>
                    <asp:Label runat="server" ID="info" Text="" ForeColor="red"></asp:Label>
                     </ContentTemplate>
                 </asp:UpdatePanel> 
          </div>
      
      <div class="row" id="griddiv" style="width:100%">
          
         <asp:UpdatePanel runat="server" >
          <ContentTemplate>
              
               <div class="panel-body row" style=" padding-right:20px;">
                   
                            <div class="table-responsive col-md-12">
              <asp:GridView ID="GridView1" Width="100%" runat="server" ShowHeaderWhenEmpty="true"  ViewStateMode="Enabled" 
                   RowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="White"                    
                  EmptyDataRowStyle-BackColor="Black"  AutoGenerateColumns="false" >
                  <HeaderStyle BackColor="PaleTurquoise" Font-Bold="false" HorizontalAlign="Center" CssClass="table table-striped table-bordered table-hover"  />
        <rowstyle backcolor="LightCyan"  
           forecolor="black"
           font-italic="false"    />

                <alternatingrowstyle backcolor="White"  
          forecolor="black"
          font-italic="false"   />
                  <Columns>
                     
                      <asp:BoundField HeaderText="Sno" DataField="sno" ><ItemStyle width="5%"/>
                          <ControlStyle Width="100%" /></asp:BoundField>
                      <asp:BoundField HeaderText="Member ID" DataField="memIDs" ><ItemStyle width="5%"/>
                          <ControlStyle Width="100%" /></asp:BoundField>
                    <asp:BoundField HeaderText="Name of Person" DataField="name" ><ItemStyle width="10%"/>
                          <ControlStyle Width="100%" /></asp:BoundField>
                     <asp:BoundField HeaderText="Card ID" DataField="cardIds" ><ItemStyle width="8%"/>
                          <ControlStyle Width="100%" /></asp:BoundField>
                    <asp:BoundField HeaderText="Comments" DataField="comments" ><ItemStyle width="15%"/>
                          <ControlStyle Width="100%" /></asp:BoundField>
                     <asp:BoundField HeaderText="state" DataField="states" ><ItemStyle width="7%"/>
                          <ControlStyle Width="100%" /></asp:BoundField>
                    
                       <asp:BoundField HeaderText="Access Permitted to" DataField="access" ><ItemStyle width="40%"/>
                          <ControlStyle Width="100%" /></asp:BoundField>
                      <asp:TemplateField HeaderText="Select Access">
                          <ItemStyle width="10%"/>
                          <ControlStyle Width="100%" />
                          <ItemTemplate>
                              <asp:LinkButton ID="selectAccessTree" runat="server" text="select" CssClass="linkcursor"
                                  OnClientClick="openTreeModal(); return false;" OnClick="openaccess_Click"></asp:LinkButton>
                           </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Edit" ShowHeader="false">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnedit" runat="server" CommandName="Edit" Text="Edit" ></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="btnupdate" runat="server" CommandName="Update" Text="Update" ></asp:LinkButton>
                        <asp:LinkButton ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                  </asp:TemplateField>
                  </Columns>                 
              </asp:GridView>
                            </div>
                   </div>
              <asp:Button CssClass="btn btn-round btn-navbar" runat="server" Width="100px" OnClick="btnSave_Click"  ID="btnSave" Text="register" />
              <asp:Button CssClass="btn btn-round btn-navbar" runat="server" Width="100px" OnClick="btnCancel_Click" Text="Cancel" ID="btnCancel" />
          <br /><br />
                
              </ContentTemplate>
      </asp:UpdatePanel>
        
          </div>
          
  </div>
             </div>
            
       <div class="modal sidebar-menu"  id="modalAccess" style="max-height:700px; display:none; overflow-y:auto">
                      
                                 <div class="modal-content" style="width:600px">
                                     <span class="close1" id="modalClose" style="text-align:right"><i class="fa fa-times" aria-hidden="true"></i></span>
                                     <h3> open</h3>
                                     <asp:UpdatePanel runat="server" ID="selectAccessPanel">
                                         <ContentTemplate>
                                     <asp:TreeView  ShowCheckBoxes="All" ID="TreeView1" NodeStyle-NodeSpacing="1" runat="server"></asp:TreeView>
                                   <%-- <button onclick="GetSelected()">select</button>--%>
                                 <asp:Button Text="Get Selected" runat="server" ID="btnToSelect"  OnClick="addAccess_Click"/>
                                             </ContentTemplate>
                                     </asp:UpdatePanel>
                                     
                                      <%--<input type="button" id=" btnselect" title="select" value="select" />--%>
                                <input id="hfSelected" type="hidden" runat="server" />
                                 </div>                           
                     </div>
             </div>
   
    <script>
        $(document).on("click", ".close1", function () {           
            var modal = document.getElementById('modalAccess');
            modal.style.display = "none"; 
            inputs = document.getElementsByTagName("input");
            for(i = 0 ; i<inputs.length; i++)
            {
                if(inputs[i].type=="checkbox")
                {
                inputs[i].checked = false;
                }
            }
        });
        $(document).on("click", ".linkcursor", function () {
            var modal = document.getElementById('modalAccess');
            modal.style.display = "block";            
        });
       
        window.onclick = function (event)
        {
            if (event.target == modal)
            {
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
