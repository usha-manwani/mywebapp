<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="WebCresij.Schedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
    <style type="text/css">
        .headerstyle{
            -webkit-box-shadow: inset 0px -6px 76px -14px rgba(0,0,0,0.75);
-moz-box-shadow: inset 0px -6px 86px -14px rgba(0,0,0,0.75);
box-shadow: inset 0px -6px 86px -14px rgba(0,0,0,0.75);
color:white;
        }
        .rowstyle{
            -webkit-box-shadow: inset 0px -6px 76px -14px rgba(0,0,0,0.75);
-moz-box-shadow: inset 0px -6px 76px -14px rgba(0,0,0,0.75);
box-shadow: inset 0px -6px 76px -14px rgba(0,0,0,0.75);
color:white;
background-color:#e7a61a;
        }
         .rowstylealt{
            -webkit-box-shadow: inset 0px -6px 76px -14px rgba(0,0,0,0.75);
-moz-box-shadow: inset 0px -6px 76px -14px rgba(0,0,0,0.75);
box-shadow: inset 0px -6px 76px -14px rgba(0,0,0,0.75);
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
    <script src="assets/js/Schedule.js?v=2"></script>
   
       <div style="background:#fff;">
           <div style="background-color: #7fe0c8; top:100px;">
            <asp:UpdatePanel runat="server">
                 <Triggers>
                    <asp:PostBackTrigger ControlID="importExcel" /> 
                </Triggers>
                <ContentTemplate>                              
                    <div class="row">
                    <h3>Schedule</h3>
                  </div>
                    <div class="row" >
                        <div class="col-lg-7 col-md-12 col-sm-12">
                            <div class="row">
                        <div class="col-lg-3 col-sm-12">
                            <h5>Select options to create Schedule</h5>
                        </div>
                        <div class=" col-sm-12 col-lg-3">                 
                        <asp:DropDownList  AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                            CssClass="btn btn-default dropdown " Width="180px"  ID="ddlInstitute" data-toggle="dropdown"  runat="server" >
                            <asp:ListItem Text="Select Institute" Value=""></asp:ListItem>
                        </asp:DropDownList>
                           </div>                           
                            <div class="col-sm-12 col-lg-3">
                    
                        <asp:DropDownList  ID="ddlGrade" AutoPostBack="true" Width="150px"
                            CssClass="btn btn-default dropdown" data-toggle="dropdown" 
                            OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" >
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                         </div>                             
                            <div class=" col-sm-12 col-lg-3">                    
                        <asp:DropDownList  ID="ddlClass" AutoPostBack="true" Width="150px"
                            AppendDataBoundItems="true" runat="server" CssClass="btn btn-default  dropdown" 
                            data-toggle="dropdown" 
                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" >
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    
                         </div> 
                             </div>
                        </div>
                        <div class="col-lg-5 col-md-6 col-sm-12" >
                            <div class="row" >
                                <div class="col" style="font-size:16px">
                                    <asp:CheckBox ID="chkTimer" runat="server" Text="Timer"/>
                                </div>
                                <div class="col">
                                    <label for="txtmin" style="font-size:16px">Early boot</label>
                                    <asp:TextBox runat="server" ID="txtmin" 
                                        onchange="javascript:text_changed(this);"
                                        Height="25px" Width="60px"></asp:TextBox>
                                    <label for="txtmin" style="font-size:11px">mins</label>                                        
                                </div>
                                <div class="col">
                                    <label for="txtmin" style="font-size:16px">Delay boot</label>
                                    <asp:TextBox runat="server" ID="txtdelay"
                                        onchange="javascript:text_changed(this);"
                                        Height="25px" Width="60px"></asp:TextBox>
                                    <label for="txtmin" style="font-size:11px">mins</label>
                                </div>
                            </div>
                        </div>
                        </div>
                  
                           <%-- <div class="row" >
                             <span style="font-size:small">   
               <i class="fa fa-info-circle"></i>&nbsp;&nbsp;<span style="color:red">Please select above options to create the Schedule</span></span> 

           
                            </div>--%>

                       
                            <div class="row">
                                <div style="display:none;" id="uploadDiv">
                         Select a File&nbsp;<asp:FileUpload runat="server" ID="fuSample"  />
        <asp:Button ID="importExcel" runat="server" Text="Upload" CssClass="btn btn-group-toggle" OnClick="importExcel_Click" /> 
                                    </div>
                            </div>
                       
                </ContentTemplate>
          </asp:UpdatePanel>
           </div>
         <div class="row">
          <asp:UpdatePanel runat="server">
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="excelgrd" />
              </Triggers>
              <ContentTemplate>
     <div style=" margin-top:-20px;">
       <asp:GridView ID="excelgrd" runat="server" Font-Size="Small" ViewStateMode="Enabled"
           EmptyDataRowStyle-BackColor="Black" ShowFooter="true" Width="100%"
           ShowHeaderWhenEmpty="true" RowStyle-HorizontalAlign="Center"
           EmptyDataRowStyle-ForeColor="White" AutoGenerateColumns="false">
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
                       <asp:Button ID="ButtonAdd" CssClass="btn btn-info" runat="server" 
                           ClientIDMode="Static" Text="Add New Row" OnClick="svbtn_Click" />
                      </FooterTemplate>
              </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="svbtn" runat="server" Text="Save" OnClick="svbtn_Click" Visible="false" CssClass="btn btn-info"/>
        <asp:Button ID="export" runat="server" Text="Export Schedule to Excel" Visible="false" CssClass="btn btn-info"
             OnClick="export_Click"/>                           
            </div>
            
       </ContentTemplate>
        </asp:UpdatePanel>
             </div>
        </div>
    
</asp:Content>

