<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveUsers.aspx.cs" Inherits="WebCresij.RemoveUsers" MasterPageFile="~/Master.Master" %>
<%@ MasterType VirtualPath="~/Master.master" %>
 <asp:Content ID="Head" ContentPlaceHolderID="masterHead" runat="server">
     <style>
      
          .leftspace{
              margin-left:20px;
              width:inherit;
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
     <link href="http://code.jquery.com/ui/1.11.1/themes/smoothness/jquery-ui.css" rel="Stylesheet"
        type="text/css" />
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.4/jquery-ui.js"></script>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="masterBody" runat="server">
        <div class="divopt">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server"  Width="80%" GridLines="Horizontal" OnRowDeleting="GridView1_RowDeleting" 
                BorderStyle="None" AutoGenerateColumns="false" CellPadding="20" CellSpacing="20"  EmptyDataText = "No Registered Users">
                <RowStyle />
                <HeaderStyle ForeColor="white" />
                <Columns >
                    
                    <asp:BoundField DataField="User_Id" HeaderText="<%$Resources:Resource, userID %>" 
                        HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="User_Name" HeaderText="<%$Resources:Resource, Name %>" 
                        HeaderStyle-HorizontalAlign="Left" />
                   
                     <asp:TemplateField HeaderText="Option">
                         
                            <ItemTemplate>
                               
                                 <asp:linkButton ID="btnEdit"  runat="server"  Text="<%$Resources:Resource, Delete %>"
                                     CommandName="Delete"  CssClass="asplink" />
                            </ItemTemplate>
                     </asp:TemplateField>
                </Columns>
            </asp:GridView>
                     </ContentTemplate>
            </asp:UpdatePanel>
            </div>
             <div class="w3-container"  >
        
        <div id="deleteuser" class="modal" >
            <div class="modal-content w3-card-4" style="width:200px" >
                <header class="container ">
                    <span onclick="del();"
                          class="w3-button w3-display-topright">&times;</span>
                    <h3><span><%=Resources.Resource.Delete1%></span></h3>
                </header>
                <div class="w3-container" >
                      <p class="text-danger"><span><%=Resources.Resource.DeleteSuccess%></span></p>
                    <br />
               <asp:Button ID="Button1" runat="server" Text="<%$Resources:Resource, Ok %>"  OnClientClick="del(); return false;" />            
                    </div>
            </div>
        </div>     
</div>
    
    <script type="text/javascript">
        function del() {
            document.getElementById("deleteuser").style.display = "none";
        }
        function show() {
            document.getElementById("deleteuser".style.display = "block");
        }
    </script>
</asp:Content>
