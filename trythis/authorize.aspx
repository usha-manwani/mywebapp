<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="authorize.aspx.cs" Inherits="WebCresij.authorize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
    <script src="Scripts/approve.js?v=2"></script>
      <div class="divopt">
            <h3>Authorize user by Selecting Roles</h3>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gv2" runat="server" BorderStyle="None" GridLines="Horizontal" 
                        AutoGenerateColumns="false" Width="100%" EmptyDataText = "No Pending Requests">
                        <HeaderStyle BackColor="PaleTurquoise" Font-Bold="false" HorizontalAlign="Center" CssClass="table table-striped table-bordered table-hover"  />
        <rowstyle backcolor="LightCyan"  
           forecolor="black"
           font-italic="false" />

                <alternatingrowstyle backcolor="White"  
          forecolor="black"
          font-italic="false"   />
                         <Columns >                    
                    <asp:BoundField DataField="User_ID" HeaderText="User ID" HeaderStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="User_Name" HeaderText="Name" HeaderStyle-HorizontalAlign="Left" /> 
                             <asp:TemplateField HeaderText="Role">
                                 <ItemTemplate>
                                     <asp:LinkButton runat="server" ID="link1" Text="select"
                                          OnClick="btnEdit_Click"  CssClass="text123" ></asp:LinkButton>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             </Columns>
                    </asp:GridView>
                    <div id="idiot" class="modal" style="display:none; max-width:500px;min-height:800px;position:absolute; ">
                        
                         <div class="modal-content" >
                             <p>you idiot</p>
                             <span  onclick="close3();"
                           class="w3-button w3-display-topright">&times;</span>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        <asp:ListItem Text="Administrator(Full Access)" Value="1" ></asp:ListItem>
                        <asp:ListItem Text="Live Feed " Value="2"></asp:ListItem>
                        <asp:ListItem Text="Manage Devices Details(Add,Edit,Delete)" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Document upload and Download" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Document Deletion" Value="5"></asp:ListItem>
                        <asp:ListItem Text="Add, Authenticate and Delete Users" Value="6"></asp:ListItem>                       
                    </asp:CheckBoxList>
                   
               <asp:Button ID="Button1" runat="server" Text="Ok" CssClass="btn" OnClick="Button2_Click" 
                   />             
                    </div>
                    </div>
                   </ContentTemplate>
            </asp:UpdatePanel>
          </div>
    <asp:HiddenField ID="userIdhid" runat="server" value=""/>
    <script type="text/javascript">
//$(function () {
//    alert("javascript working");
//    $(document).on('click', '.text123', function () {
//        var closestTr = $(this).closest('tr');

//        alert(closestTr.cells[0].innerText);
//        var modal = document.getElementById("idiot");
//        modal.style.display = "block";
//        return false;
//    });
    
//        alert("javascript not working");

        //        });
        
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterSideBody" runat="server">
</asp:Content>
