<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Approve.aspx.cs" Inherits="final.Approve" %>
<%@ MasterType VirtualPath="~/Site.master" %>
 <asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
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
<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
        <div class="divopt">
            <asp:GridView ID="GridView1" runat="server"  Width="80%" GridLines="Horizontal" OnRowEditing="GridView1_RowEditing" EmptyDataText = "No Pending Requests"
                BorderStyle="None" AutoGenerateColumns="false" CellPadding="20" CellSpacing="20"   ForeColor="Black" HeaderStyle-BackColor="#009688">
                <RowStyle Height="50" />
                <Columns >
                    
                    <asp:BoundField DataField="User_ID" HeaderText="User ID" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="User_Name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left" />
                    
                   <%--  <asp:CommandField EditText="Add Permissions" ButtonType="Link" ShowEditButton="true" ControlStyle-ForeColor="#0066CC" />--%>
                     <asp:TemplateField >
                            <ItemTemplate>
                                 <asp:linkButton ID="btnEdit"  runat="server" Text="Give Permissions" CommandName="Edit" />
                            </ItemTemplate>
                     </asp:TemplateField>
 
                    
                </Columns>
            </asp:GridView>
            </div>
           

       <div class="w3-container"  >
        
        <div id="Permissions" class="w3-modal" runat="server">
            <div class="w3-modal-content w3-card-4" style="width:400px" >
                <header class="w3-container w3-teal">
                    <span onclick="del();"
                          class="w3-button w3-display-topright">&times;</span>
                    <h3>Authorize User..!</h3>
                </header>
                <div class="w3-container" >
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem Text="Administrator(Full Access)" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Live Feed " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Manage Camera Details" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Document Update" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Document Deletion" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Add and Delete Users" Value="6"></asp:ListItem>
                        <asp:ListItem Text="Authenticate Users" Value="7"></asp:ListItem>
                    </asp:CheckBoxList>

                     
                    <br />
               <asp:Button ID="Button2" runat="server" Text="Ok" OnClick="Button2_Click" OnClientClick="save(); return false;" />
                  
                        
               
                    </div>
                
                
            </div>
        </div>
     
</div>
    
    <script type="text/javascript">
      
        function save() {
            document.getElementById("<%=Permissions.ClientID%>").style.display = "none";
        }
    </script>
</asp:Content>
