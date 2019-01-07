<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="WebCresij.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
    <style type="text/css">
        .headerstyle{
            -webkit-box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
-moz-box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
color:white;
        }
        .rowstyle{
            -webkit-box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
-moz-box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
color:white;
background-color:#e7a61a;
        }
         .rowstylealt{
            -webkit-box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
-moz-box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
box-shadow: inset 0px -6px 96px -14px rgba(0,0,0,0.75);
color:white;
background-color:white;
        }
        
          .rowstyle:hover, .rowstylealt:hover,.selected{
              color:white;
              background-color:darkcyan
          }
        

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
    
    <script src="assets/js/Schedule.js"></script>
   
       <div >
           <div class="row">
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
               
                <div class="thead-dark" ><h3>Schedule</h3>
                    <table>
                        <tr>

                       <td class="col-md-4 col-sm-12 col-lg-4">
                    <div  >
                        <asp:DropDownList max-width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                            CssClass="btn btn-default dropdown "  ID="ddlInstitute" data-toggle="dropdown"  runat="server" >
                            <asp:ListItem Text="Select Institute" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                           </td>
                            <td><span><i class="fa fa-angle-double-right"></i></span></td> 
                            <td class="col-md-4 col-sm-12 col-lg-4">
                    <div >
                        <asp:DropDownList max-width="200px" ID="ddlGrade" AutoPostBack="true"
                            CssClass="btn btn-default dropdown" data-toggle="dropdown" 
                            OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" >
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                         </td>
                            <td><span><i class="fa fa-angle-double-right"></i></span></td>  
                            <td class="col-md-4 col-sm-12 col-lg-4">
                    <div >
                        <asp:DropDownList  ID="ddlClass" max-width="200px"  AutoPostBack="true"
                            AppendDataBoundItems="true" runat="server" CssClass="btn btn-default  dropdown" 
                            data-toggle="dropdown" 
                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" >
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                         </td>   

                        </tr>
                        <tr>
                            <td colspan="3">
                             <span style="font-size:small">   
               <i class="fa fa-info-circle"></i>&nbsp;&nbsp;<span style="color:red">Please select above options to create the Schedule</span></span> 

           
                            </td>
                        </tr>
                    </table>
                </div>
                  
                
             </div>
    </ContentTemplate>
          </asp:UpdatePanel>
           </div>
         
          <asp:UpdatePanel runat="server">
              <ContentTemplate>
     <div style=" margin-top:-50px;">
          
               
                    
                 <asp:GridView ID="excelgrd" runat="server" Font-Size="Small" ViewStateMode="Enabled"
                     EmptyDataRowStyle-BackColor="Black" ShowFooter="true" 
                     ShowHeaderWhenEmpty="true" RowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="White" AutoGenerateColumns="false">
                    <HeaderStyle CssClass="headerstyle" />
        <rowstyle CssClass="rowstyle"  />

        <alternatingrowstyle CssClass="rowstylealt" />
            <Columns>
              
                <asp:TemplateField HeaderText="SNo">
                    <ItemStyle Width="4%" />
                    <ItemTemplate>
                        <span> <%#Container.DataItemIndex + 1%></span>
                    </ItemTemplate>
                </asp:TemplateField>

              <%--  <asp:BoundField DataField="Slno" HeaderText="SL No" ItemStyle-Width="4%"  />--%>
                <asp:TemplateField HeaderText="Time">
                    <ItemStyle Width="12%" Height="100%"/><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtTime" Text='<%#Eval("Time") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Monday">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtMon" Text='<%#Eval("Monday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="Tuesday">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtTue" Text='<%#Eval("Tuesday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="Wednesday">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtWed" Text='<%#Eval("Wednesday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="Thursday">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtThu" Text='<%#Eval("Thursday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="Friday">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtFri" Text='<%#Eval("Friday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="Saturday">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtSat" Text='<%#Eval("Saturday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sunday">
                         <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                        <ItemTemplate>
                        <asp:TextBox ID="txtSun" Text='<%#Eval("Sunday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>                                       
                      <FooterStyle HorizontalAlign="Right" />
                      <FooterTemplate>                          
                       <asp:Button ID="ButtonAdd" CssClass="btn btn-info" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" />
                      </FooterTemplate>
              </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="svbtn" runat="server" Text="Save" OnClick="svbtn_Click" Visible="false" />
                                                  
            </div>
            
       </ContentTemplate>
        </asp:UpdatePanel>
        </div>
    
</asp:Content>

