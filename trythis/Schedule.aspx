<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.master" EnableEventValidation="false"  
    AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="WebCresij.Schedule" %>

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
    <script src="assets/js/Schedule.js?v=3"></script>  
       <div>
           <div >
            <asp:UpdatePanel runat="server">
                 <Triggers>
                    <asp:PostBackTrigger ControlID="importExcel" /> 
                </Triggers>
                <ContentTemplate>                              
                   
                    <h4 style="margin-bottom:-10px;margin-top:-10px;color:white"><span><%=Resources.Resource.Schedule%></span></h4>
                  
                    <div class="row" style="margin-bottom:-20px" >
                        <div class="col-lg-7 col-md-12 col-sm-12">
                            <div class="row" style="margin-bottom:-15px;" >
                        <div class="col-lg-3 col-md-3 col-sm-12">
                            <span style="color:white"><%=Resources.Resource.CreateSchedule%></span>
                        </div>
                        <div class=" col-sm-12 col-md-3 col-lg-3">                 
                        <asp:DropDownList  AutoPostBack="true" Width="100px"
                            OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                            CssClass="btn btn-default border-light" ForeColor="White" BackColor="#1E1E36" 
                            ID="ddlInstitute" runat="server" >
                            
                        </asp:DropDownList>
                           </div>                           
                            <div class="col-sm-12 col-md-3 col-lg-3">
                        <asp:DropDownList  ID="ddlGrade" AutoPostBack="true" Width="100px"
                            CssClass="btn btn-default border-light" 
                            ForeColor="White" BackColor="#1E1E36"
                            OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" >
                            <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                        </asp:DropDownList>
                         </div>                             
                            <div class=" col-sm-12 col-md-3 col-lg-3">                    
                        <asp:DropDownList  ID="ddlClass" AutoPostBack="true" 
                            AppendDataBoundItems="true" runat="server"  Width="100px" 
                            CssClass="btn btn-default border-light" 
                            ForeColor="White" BackColor="#1E1E36" 
                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" >
                            <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                        </asp:DropDownList>                    
                         </div> 
                             </div>
                        </div>
                        <div class="col-lg-5 col-md-6 col-sm-12" >
                            <div class="row" style="margin-bottom:-20px">
                                <div class="col-lg-2 col-md-4 col-sm-4" >
                                    <div style="text-align:center;margin-top:-6%"><asp:CheckBox ID="chkTimer" runat="server" Text="<%$Resources:Resource, Timer %>"
                                         ForeColor="White"/></div>
                                </div>
                                <div class="col-lg-5 col-md-4 col-sm-4">
                                    <label for="txtmin" >
                                        <span style="color:white"><%=Resources.Resource.EarlyBoot%></span></label>
                                     <select name="EarlyBoot" id="EarlyBootMins" class="btn btn-default border-light"
                                                style="color:white; background-color:#1E1E36">
                                                <option value="01">1 </option>
                                                <option value="02">2 </option>
                                                <option value="03">3 </option>
                                                <option value="04">4 </option>
                                                <option value="05">5 </option>
                                                <option value="06">6 </option>
                                                <option value="07">7 </option>
                                                <option value="08">8 </option>
                                                <option value="09">9 </option>
                                                <option value="09">10</option>
                                      </select>
                                    <%--<asp:TextBox runat="server" ID="txtmin" 
                                        onchange="javascript:text_changed(this);"
                                        Height="25px" Width="60px"></asp:TextBox>--%>
                                    <label for="txtmin" >
                                        <span style="color:white"><%=Resources.Resource.Mins%></span>
                                    </label>                                        
                                </div>
                                <div class="col-lg-5 col-md-4 col-sm-4">
                                    <label for="txtmin" >
                                        <span style="color:white"><%=Resources.Resource.DelayBoot%></span></label>
                                    <select name="DelayBoot" id="DelayBootMins" class="btn btn-default border-light"
                                                style="color:white; background-color:#1E1E36">
                                                <option value="01">1 </option>
                                                <option value="02">2 </option>
                                                <option value="03">3 </option>
                                                <option value="04">4 </option>
                                                <option value="05">5 </option>
                                                <option value="06">6 </option>
                                                <option value="07">7 </option>
                                                <option value="08">8 </option>
                                                <option value="09">9 </option>
                                                <option value="09">10</option>
                                      </select>
                                    <%--<asp:TextBox runat="server" ID="txtdelay"
                                        onchange="javascript:text_changed(this);"
                                        Height="25px" Width="60px"></asp:TextBox>--%>
                                    <label for="txtmin" >
                                        <span style="color:white"><%=Resources.Resource.Mins%></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        </div>
                        <div class="row" style="margin-bottom:-20px">
                                <div style="display:none; color:white" id="uploadDiv">
                         <span><%=Resources.Resource.SelectFile%></span>&nbsp;<asp:FileUpload runat="server" ID="fuSample"  />
        <asp:Button ID="importExcel" runat="server" Text="<%$Resources:Resource, Upload %>"
            CssClass="btn btn-info" OnClick="importExcel_Click" /> 
                                    <p style="font-size:11px">please create excel with the same format and without leaving any empty cell in between</p></div>
                            </div>
                       
                </ContentTemplate>
          </asp:UpdatePanel>
           </div>
         <div class="row" style="margin-right:10px">
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
                    <HeaderStyle CssClass="hidden-phone" ForeColor="#7f919f"  Font-Size="Large"/>
        <RowStyle CssClass="rowstyle" BackColor="White" Font-Size="Large"/>
           
        <AlternatingRowStyle CssClass="rowstylealt" BackColor="WhiteSmoke" Font-Size="Large"/>
            <Columns>              
                <asp:TemplateField HeaderText="<%$Resources:Resource, Sno %>">
                    <ItemStyle Width="4%" />
                    <ItemTemplate>
                        <span> <%#Container.DataItemIndex + 1%></span>
                    </ItemTemplate>
                </asp:TemplateField>
              <%--  <asp:BoundField DataField="Slno" HeaderText="SL No" ItemStyle-Width="4%"  />--%>
                <asp:TemplateField HeaderText="<%$Resources:Resource, Time %>">
                    <ItemStyle Width="12%" Height="100%"/><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtTime" Text='<%#Eval("Time") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<%$Resources:Resource, Monday %>">
                    <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtMon" Text='<%#Eval("Monday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="<%$Resources:Resource, Tuesday %>">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtTue" Text='<%#Eval("Tuesday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="<%$Resources:Resource, Wednesday %>">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtWed" Text='<%#Eval("Wednesday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="<%$Resources:Resource, Thursday %>">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtThu" Text='<%#Eval("Thursday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="<%$Resources:Resource, Friday %>">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtFri" Text='<%#Eval("Friday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="<%$Resources:Resource, Saturday %>">
                      <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                    <ItemTemplate>
                        <asp:TextBox ID="txtSat" Text='<%#Eval("Saturday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
                     </asp:TemplateField>
                    <asp:TemplateField HeaderText="<%$Resources:Resource, Sunday %>">
                         <ItemStyle Width="12%" /><ControlStyle Width="100%" />
                        <ItemTemplate>
                        <asp:TextBox ID="txtSun" Text='<%#Eval("Sunday") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>                                       
                      <FooterStyle HorizontalAlign="Right" />
                      <FooterTemplate>                          
                       <asp:Button ID="ButtonAdd" CssClass="btn btn-info" runat="server" 
                           ClientIDMode="Static" Text="<%$Resources:Resource, NewRow %>" OnClick="svbtn_Click" />
                      </FooterTemplate>
              </asp:TemplateField>
            </Columns>
        </asp:GridView>
         <script runat="server">
                            public override void VerifyRenderingInServerForm(Control control)
                            {
                                /* Verifies that the control is rendered */
                            }
                       </script>
        <asp:Button ID="svbtn" runat="server" Text="<%$Resources:Resource, Save %>" OnClick="svbtn_Click" Visible="false" CssClass="btn btn-info"/>
        <asp:Button ID="export" runat="server" Text="<%$Resources:Resource, ExportToExcel %>" Visible="false" CssClass="btn btn-info"
             OnClick="export_Click"/>                           
            </div>
            
       </ContentTemplate>
              <Triggers>
                  <asp:PostBackTrigger ControlID="export" />
              </Triggers>
        </asp:UpdatePanel>
             </div>
           <div style="display:none">
               <asp:Literal runat="server" id="literal1"></asp:Literal>
               <asp:Literal runat="server" id="literal2"></asp:Literal>
               <asp:Literal runat="server" id="literal3"></asp:Literal>
               <asp:Literal runat="server" id="literal4"></asp:Literal>
               <asp:Literal runat="server" id="literal7"></asp:Literal>
               <asp:Literal runat="server" id="literal6"></asp:Literal>
               <asp:Literal runat="server" id="literal5"></asp:Literal>
           </div>
        </div>
    <script>
        
    </script>
    
</asp:Content>

