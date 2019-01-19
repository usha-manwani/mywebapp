<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="WebCresij.Configuration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server"> 
    <link href="css/Configcss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
        <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>    
        <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' > </script>
    <script src="Scripts/Config.js"></script>
<div>          
    <div style="background-color: #bff5e9; top:50px;">
         <asp:UpdatePanel runat="server">
            <ContentTemplate>
     <div class="row" >
         <div class="col-lg-3 col-sm-12 col-md-12 ">
             Select Institute and Grade - &nbsp;
         </div>
         <div class=" col-lg-2 col-sm-6 col-md-6 float-left">
             <asp:DropDownList Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
              CssClass="btn btn-default dropdown "  ID="ddlInstitute" data-toggle="dropdown"  runat="server" >
              <asp:ListItem Text="select" Value=""></asp:ListItem></asp:DropDownList>
         </div>
         &nbsp;&nbsp;  &nbsp;&nbsp; &nbsp;
         <div class="col-lg-2 col-sm-6 col-md-6 float-none">
              <asp:DropDownList Width="150px" ID="ddlGrade" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged"
              CssClass="btn btn-default dropdown" data-toggle="dropdown" AutoPostBack="true" runat="server" >
              <asp:ListItem Text="select" Value=""></asp:ListItem></asp:DropDownList>                        
         </div>
         </div>         
         </ContentTemplate>
    </asp:UpdatePanel>
     </div>
    <div>        
         <cc1:TabContainer ID="tb1" runat="server" CssClass="fancy fancy-green" >
            <cc1:TabPanel runat="server" >
                <HeaderTemplate>
                    <img src="Images/icons/deskblack.png" height="15px" width="15px" />&nbsp;
                    System Setup</HeaderTemplate>
                <ContentTemplate>                   
                  <fieldset class="group" style=" width:80%"> 
                    <legend align="center" style="width:auto">Configuration Settings</legend> 
                     <div class="row" >
                        <div class="col-lg-6 col-sm-12 col-md-12" style="font-size:small">                      
                          <ul class="checkbox"> 
                            <li><input type="checkbox" id="cb1" name="sys" value="pepperoni" />
                                <label for="cb1">Projector On</label></li> 
                            <li><input type="checkbox" id="cb2" name="sys" value="sausage" />
                                <label for="cb2">Projector Off</label></li> 
                            <li><input type="checkbox" id="cb3" name="sys" value="mushrooms" />
                                <label for="cb3">Projector Shutdown</label></li> 
                            <li><input type="checkbox" id="cb4" name="sys" value="onions" />
                                <label for="cb4">Computer Auto Boot</label></li> 
                            <li><input type="checkbox" id="cb5" name="sys" value="gpeppers" />
                                <label for="cb5">Computer Shutdown</label></li> 
                            <li><input type="checkbox" id="cb6" name="sys" value="xcheese" />
                                <label for="cb6>">Projector Auto Switch</label></li>
                              <li><input type="checkbox" id="cb7" name="sys" value="pepperoni" />
                                <label for="cb7">Projector linked curtain open</label></li> 
                            <li><input type="checkbox" id="cb8" name="sys" value="sausage" />
                                <label for="cb8">Curtain linkage Projection</label></li> 
                            <li><input type="checkbox" id="cb9" name="sys" value="mushrooms" />
                                <label for="cb9">Volume On</label></li> 
                            <li><input type="checkbox" id="cb10" name="sys" value="onions" />
                                <label for="cb10">Buzz On</label></li> 
                            <li><input type="checkbox" id="cb11" name="sys" value="gpeppers" />
                                <label for="cb11">IO Detection and Shutdown</label></li>
                              <li>
                                  <label for="delayminutes">Projector Machine Delay</label>
                                 <select name="delayminutes" class="btn btn-default dropdown" style="border:1px solid chocolate;">
                                     <option value="1">1 minute</option>
                                     <option value="2">2 minutes</option>
                                     <option value="3">3 minutes</option>
                                     <option value="4">4 minutes</option>
                                     <option value="5">5 minutes</option>
                                     <option value="6">6 minutes</option>
                                     <option value="7">7 minutes</option>
                                     <option value="8">8 minutes</option>
                                     <option value="9">9 minutes</option>
                                 </select>
                              </li>
                             </ul> 
                        </div>
                        <div class="col-lg-6 col-sm-12 col-md-12" style="font-size:small">                      
                          <ul class="checkbox"> 
                            <li><input type="checkbox" id="cb12" name="sys" value="pepperoni" />
                                <label for="cb12">Computer On</label></li> 
                            <li><input type="checkbox" id="cb13" name="sys" value="sausage" />
                                <label for="cb13">Computer Off</label></li> 
                            <li><input type="checkbox" id="cb14" name="sys" value="mushrooms" />
                                <label for="cb14">Projector Infrared</label></li> 
                            <li><input type="checkbox" id="cb15" name="sys" value="onions" />
                                <label for="cb15">Swipe Open</label></li> 
                            <li><input type="checkbox" id="cb16" name="sys" value="peppers" />
                                <label for="cb16">Swipe Off</label></li> 
                            <li><input type="checkbox" id="cb17" name="sys" value="xcheese" />
                                <label for="cb17">Fingerprint Open</label></li> 
                              <li><input type="checkbox" id="cb18" name="sys" value="xcheese" />
                                <label for="cb18">Fingerprint Off</label></li> 
                              <li><input type="checkbox" id="cb19" name="sys" value="xcheese" />
                                <label for="cb19">Computer linkage System Shutdown</label></li>
                              <li><input type="checkbox" id="cb20" name="sys" value="xcheese" />
                                <label for="cb20">HDMI audio separation</label></li>
                              <li><input type="checkbox" id="cb21" name="sys" value="xcheese" />
                                <label for="cb21">System Alarm</label></li>
                               <li>
                                 <label for="delaySeconds">Projector Boot Delay</label>
                                 <select name="delaySeconds" class="btn btn-default dropdown" style="border:1px solid chocolate;">
                                     <option value="1">1 seconds</option>
                                     <option value="2">2 seconds</option>
                                     <option value="3">3 seconds</option>
                                     <option value="4">4 seconds</option>
                                     <option value="5">5 seconds</option>
                                     <option value="6">6 seconds</option>
                                     <option value="7">7 seconds</option>
                                     <option value="8">8 seconds</option>
                                     <option value="9">9 seconds</option>
                                     <option value="10">10 seconds</option>
                                     <option value="11">11 seconds</option>
                                     <option value="12">12 seconds</option>
                                     <option value="13">13 seconds</option>
                                     <option value="14">14 seconds</option>
                                 </select> 
                               </li>
                          </ul> 
                        </div>
                      </div>
                     <div class="row" style="padding-right:10px;">
                          <div class="col-lg-6 col-sm-12 col-md-12" >
                              <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                  <legend style="width:auto" align="center">Alarm</legend>
                              <div class="row">
                              <div class="col-lg-6 col-md-6 col-sm-6" style="font-size:x-small">
                                   <ul class="checkbox"> 
                            <li><input type="checkbox" id="cb22" name="sys" value="pepperoni" />
                                <label for="cb22">IO1</label></li> 
                            <li><input type="checkbox" id="cb23" name="sys" value="sausage" />
                                <label for="cb23">IO2</label></li> 
                            <li><input type="checkbox" id="cb24" name="sys" value="mushrooms" />
                                <label for="cb24">IO3</label></li> 
                            <li><input type="checkbox" id="cb25" name="sys" value="onions" />
                                <label for="cb25">IO4</label></li> 
                            <li><input type="checkbox" id="cb26" name="sys" value="gpeppers" />
                                <label for="cb26">IO5</label></li> 
                            <li><input type="checkbox" id="cb27" name="sys" value="xcheese" />
                                <label for="cb27">IO6</label></li> 
                              <li><input type="checkbox" id="cb28" name="sys" value="xcheese" />
                                <label for="cb28">IO7</label></li> 
                              <li><input type="checkbox" id="cb29" name="sys" value="xcheese" />
                                <label for="cb29">IO8</label></li>
                                      
                          </ul>
                              </div>
                              <div class="col-lg-6 col-md-6 col-sm-6" style="font-size:x-small">
                                   <ul class="checkbox"> 
                            <li><input type="checkbox" id="cb30" name="sys" value="pepperoni" />
                                <label for="cb30">IO9</label></li> 
                            <li><input type="checkbox" id="cb31" name="sys" value="sausage" />
                                <label for="cb31">IO10</label></li> 
                            <li><input type="checkbox" id="cb32" name="sys" value="mushrooms" />
                                <label for="cb32">IO11</label></li> 
                            <li><input type="checkbox" id="cb33" name="sys" value="onions" />
                                <label for="cb33">IO12</label></li> 
                            <li><input type="checkbox" id="cb34" name="sys" value="gpeppers" />
                                <label for="cb34">IO13</label></li> 
                            <li><input type="checkbox" id="cb35" name="sys" value="xcheese" />
                                <label for="cb35">IO14</label></li> 
                              <li><input type="checkbox" id="cb36" name="sys" value="xcheese" />
                                <label for="cb36">IO15</label></li> 
                              <li><input type="checkbox" id="cb37" name="sys" value="xcheese" />
                                <label for="cb37">IO16</label></li>
                          </ul>
                              </div>
                              </div>
                              </fieldset>
                          </div>
                          <div class="col-lg-6 col-sm-12 col-md-12" >
                              <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                  <legend style="width:auto" align="center">Input/Output</legend> 
                              <div class="row">
                              <div class="col-lg-6 col-md-6 col-sm-6" style="font-size:x-small;">
                                   <ul class="checkbox"> 
                            <li><input type="checkbox" id="cb38" name="sys" value="pepperoni" />
                                <label for="cb38">IO1</label></li> 
                            <li><input type="checkbox" id="cb39" name="sys" value="sausage" />
                                <label for="cb39">IO2</label></li> 
                            <li><input type="checkbox" id="cb40" name="sys" value="mushrooms" />
                                <label for="cb40">IO3</label></li> 
                            <li><input type="checkbox" id="cb41" name="sys" value="onions" />
                                <label for="cb41">IO4</label></li> 
                            <li><input type="checkbox" id="cb42" name="sys" value="gpeppers" />
                                <label for="cb42">IO5</label></li> 
                            <li><input type="checkbox" id="cb43" name="sys" value="xcheese" />
                                <label for="cb43">IO6</label></li> 
                              <li><input type="checkbox" id="cb44" name="sys" value="xcheese" />
                                <label for="cb44">IO7</label></li> 
                              <li><input type="checkbox" id="cb45" name="sys" value="xcheese" />
                                <label for="cb45">IO8</label></li>
                          </ul>
                              </div>
                              <div class="col-lg-6 col-md-6 col-sm-6" style="font-size:x-small">
                                   <ul class="checkbox"> 
                            <li><input type="checkbox" id="cb46" name="sys" value="pepperoni" />
                                <label for="cb46">IO9</label></li> 
                            <li><input type="checkbox" id="cb47" name="sys" value="sausage" />
                                <label for="cb47">IO10</label></li> 
                            <li><input type="checkbox" id="cb48" name="sys" value="mushrooms" />
                                <label for="cb48">IO11</label></li> 
                            <li><input type="checkbox" id="cb49" name="sys" value="onions" />
                                <label for="cb49">IO12</label></li> 
                            <li><input type="checkbox" id="cb50" name="sys" value="gpeppers" />
                                <label for="cb50">IO13</label></li> 
                            <li><input type="checkbox" id="cb51" name="sys" value="xcheese" />
                                <label for="cb51">IO14</label></li> 
                              <li><input type="checkbox" id="cb52" name="sys" value="xcheese" />
                                <label for="cb52">IO15</label></li> 
                              <li><input type="checkbox" id="cb53" name="sys" value="xcheese" />
                                <label for="cb53">IO16</label></li>
                          </ul>
                              </div>
                              </div>
                                  </fieldset>                              
                          </div>
                      </div>
                     <div class="row" >
                     <div class="col" style="text-align:center">
                        <input type="button" class="btn-info customButton"  value="Read Configurations" />
                     </div>
                     <div class="col" style="text-align:center">
                        <input type="button" class="btn-info customButton" id="btnsetup" value="Write Configurations" />
                     </div>
                     </div>
                  </fieldset>                    
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server" >
                <HeaderTemplate>
                    <img src="Images/icons/project4.png" height="15px" width="15px" />&nbsp;
                    Projector</HeaderTemplate>
                <ContentTemplate>
                    <div class="row" style="margin-right:5px;">
                        <div class="col-lg-6">
                            <div class="row">
                                <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                <legend align="center" style="width:auto">first</legend>
                                <div style="min-width:300px;"></div>
                            </fieldset>
                                </div>
                            <div class="row">
                            <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                <legend align="center" style="width:auto">first</legend>
                                <div style="min-width:300px;" ></div>
                            </fieldset>
                            </div>
                         </div>    
                        <div class="col-lg-6">
                            <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                <legend align="center" style="width:auto">first</legend> 
                                <div style="margin-left:5px; margin-right:5px;font-size:small">
                                    <label for="baud" >BaudRate</label>&nbsp;
                                    <select id="baud" class="btn dropdown btn-group" style="border:1px solid chocolate;font-size:small">
                                        <option value="1">1200</option>
                                        <option value="2">2400</option>
                                        <option value="3">4800</option>
                                        <option value="4">9600</option>
                                        <option value="5">19200</option>
                                        <option value="6">38400</option>
                                        <option value="7">57600</option>
                                        <option value="8">76800</option>
                                        <option value="9">115200</option>
                                    </select>&nbsp;&nbsp;
                                    <label for="parity" >Parity</label>&nbsp;
                                    <select id="parity" class="btn dropdown btn-group" style="border:1px solid chocolate;font-size:small;margin-right:5px;">
                                        <option value="-1">none</option>
                                        <option value="1">Odd</option>
                                        <option value="0">Even</option>
                                    </select>&nbsp;&nbsp;
                                    </div>
                                <div class="row" style="margin-left:5px; margin-right:5px;font-size:small">
                                <label for="tb1">tb1</label>&nbsp;
                                <input type="text" class="form-control" /></div>
                                 <div class="row" style="margin-left:5px; margin-right:5px;font-size:small">
                                <label for="tb2">tb2</label>&nbsp;
                                <input type="text" class="form-control" /></div>
                                 <div class="row" style="margin-left:5px; margin-right:5px;font-size:small">
                                <label for="tb3">tb3</label>&nbsp;
                                <input type="text" class="form-control" /></div>
                                 <div class="row" style="margin-left:5px; margin-right:5px;font-size:small">
                                <label for="tb4">tb4</label>&nbsp;
                                <input type="text" class="form-control" /></div>
                                 <div class="row" style="margin-left:5px; margin-right:5px;font-size:small">
                                <label for="tb5">tb5</label>&nbsp;
                                <input type="text" class="form-control" /></div>
                                <div class="row" style="margin-left:5px; margin-right:5px;font-size:small">
                                <label for="tb6">tb6</label>&nbsp;
                                <input type="text" class="form-control" /></div>
                                <div class="row" style=" text-align:center">
                                    <div class="col">
                                        <input type="button" class="btn btn-group" value="ok"/>
                                    </div>
                                    <div class="col">
                                        <input type="button" class="btn btn-group" value="save" />
                                    </div>
                                    <div class="col">
                                        <input type="button" class="btn btn-group" value="Cancel" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server">
                <HeaderTemplate>
                    <img src="Images/icons/lightblack.png" height="15px" width="15px" />&nbsp;
                    Power</HeaderTemplate>
                <ContentTemplate>
                    <div class="row" style="margin-right:5px;">
                        <div class="col-lg-6">                            
                            <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                <legend align="center" style="width:auto" runat="server">Light 1</legend>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6" style="font-size:small">
                                        <ul class="checkbox">
                                             <li><input type="checkbox" id="bc1" name="light1" value="pepperoni" />
                                                <label for="bc1">Light 1 On</label></li>
                                            <li><input type="checkbox" id="bc2" name="light1" value="pepperoni" />
                                                <label for="bc2">Light 2 On</label></li>
                                            <li><input type="checkbox" id="bc3" name="light1" value="pepperoni" />
                                                <label for="bc3">Light 3 On</label></li>
                                            <li><input type="checkbox" id="bc4" name="light1" value="pepperoni" />
                                                <label for="bc4">Light 4 On</label></li>
                                            <li><input type="checkbox" id="bc5" name="light1" value="pepperoni" />
                                                <label for="bc5">Light 5 On</label></li>
                                            <li><input type="checkbox" id="bc6" name="light1" value="pepperoni" />
                                                <label for="bc6">Light 6 On</label></li>
                                        </ul>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6" style="font-size:small" >
                                        <ul class="checkbox">
                                             <li><input type="checkbox" id="bc7" name="light1" value="pepperoni" />
                                                <label for="bc7">Light 1 Off</label></li>
                                            <li><input type="checkbox" id="bc8" name="light1" value="pepperoni" />
                                                <label for="bc8">Light 2 Off</label></li>
                                            <li><input type="checkbox" id="bc9" name="light1" value="pepperoni" />
                                                <label for="bc9">Light 3 Off</label></li>
                                            <li><input type="checkbox" id="bc10" name="light1" value="pepperoni" />
                                                <label for="bc10">Light 4 Off</label></li>
                                            <li><input type="checkbox" id="bc11" name="light1" value="pepperoni" />
                                                <label for="bc11">Light 5 Off</label></li>
                                            <li><input type="checkbox" id="bc12" name="light1" value="pepperoni" />
                                                <label for="bc12">Light 6 Off</label></li>
                                        </ul>
                                    </div>
                                </div>
                                
                            </fieldset>
                         </div>
                        <div class="col-lg-6">
                            <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                <legend align="center" style="width:auto" >Light 2</legend>
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6" style="font-size:small">
                                        <ul class="checkbox">
                                             <li><input type="checkbox" id="bc13" name="light2" value="pepperoni" />
                                                <label for="bc13">Light 7 On</label></li>
                                            <li><input type="checkbox" id="bc14" name="light2" value="pepperoni" />
                                                <label for="bc14">Light 8 On</label></li>
                                            <li><input type="checkbox" id="bc15" name="light2" value="pepperoni" />
                                                <label for="bc15">Light 9 On</label></li>
                                            <li><input type="checkbox" id="bc16" name="light2" value="pepperoni" />
                                                <label for="bc16">Light 10 On</label></li>
                                            <li><input type="checkbox" id="bc17" name="light2" value="pepperoni" />
                                                <label for="bc17">Light 11 On</label></li>
                                            <li><input type="checkbox" id="bc18" name="light2" value="pepperoni" />
                                                <label for="bc18">Light 12 On</label></li>
                                        </ul>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6" style="font-size:small" >
                                        <ul class="checkbox">
                                             <li><input type="checkbox" id="bc19" name="light2" value="pepperoni" />
                                                <label for="bc19">Light 7 Off</label></li>
                                            <li><input type="checkbox" id="bc20" name="light2" value="pepperoni" />
                                                <label for="bc20">Light 8 Off</label></li>
                                            <li><input type="checkbox" id="bc21" name="light2" value="pepperoni" />
                                                <label for="bc21">Light 9 Off</label></li>
                                            <li><input type="checkbox" id="bc22" name="light2" value="pepperoni" />
                                                <label for="bc22">Light 10 Off</label></li>
                                            <li><input type="checkbox" id="bc23" name="light2" value="pepperoni" />
                                                <label for="bc23">Light 11 Off</label></li>
                                            <li><input type="checkbox" id="bc24" name="light2" value="pepperoni" />
                                                <label for="bc24">Light 12 Off</label></li>
                                        </ul>
                                    </div>
                                </div>
                             </fieldset>
                        </div>
                    </div>
                    <div class="row" style="margin-right:5px;">
                        <div class="col-lg-3 col-md-6 col-sm-12" style="font-size:small">
                                    <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                        <legend style="width:auto" align="center">Curtain 1</legend>
                                        <ul class="checkbox">
                                            <li><input type="checkbox" id="w1" name="w1" value="pepperoni" />
                                                <label for="w1">Curtain 1 Open</label></li>
                                            <li><input type="checkbox" id="w11" name="w1" value="pepperoni" />
                                                <label for="w11">Curtain 1 Shutdown</label></li>
                                        </ul>
                                    </fieldset>
                                </div>
                        <div class="col-lg-3 col-md-6 col-sm-12" style="font-size:small">
                                    <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                        <legend style="width:auto" align="center">Curtain 2</legend>
                                        <ul class="checkbox">
                                            <li><input type="checkbox" id="w2" name="w2" value="pepperoni" />
                                                <label for="w2">Curtain 2 Open</label></li>
                                            <li><input type="checkbox" id="w22" name="w2" value="pepperoni" />
                                                <label for="w22">Curtain 2 Shutdown</label></li>
                                        </ul>
                                    </fieldset>
                                </div>
                        <div class="col-lg-3 col-md-6 col-sm-12" style="font-size:small">
                                    <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                        <legend style="width:auto" align="center">Curtain 3</legend>
                                        <ul class="checkbox">
                                            <li><input type="checkbox" id="w3" name="w3" value="pepperoni" />
                                                <label for="w3">Curtain 3 Open</label></li>
                                            <li><input type="checkbox" id="w33" name="w33" value="pepperoni" />
                                                <label for="w33">Curtain 3 Shutdown</label></li>
                                        </ul>
                                    </fieldset>
                                </div>
                        <div class="col-lg-3 col-md-6 col-sm-12" style="font-size:small">
                                    <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                        <legend style="width:auto" align="center">Curtain 4</legend>
                                        <ul class="checkbox">
                                            <li><input type="checkbox" id="w4" name="w4" value="pepperoni" />
                                                <label for="w4">Curtain 4 Open</label></li>
                                            <li><input type="checkbox" id="w44" name="w4" value="pepperoni" />
                                                <label for="w44">Curtain 4 Shutdown</label></li>
                                        </ul>
                                    </fieldset>
                                </div>
                     </div>
                    <div class="row" style="margin-right:5px;">
                        <div class=" col-lg-6">
                            <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                <legend style="width:auto" align="center">Fresh Air System</legend>
                                <ul class="checkbox" style="font-size:small" >
                                    <li style="display:inline-block"><input type="checkbox" id="air1" name="air1" value="" />
                                       <label for="air1">Auto On</label>
                                    </li>
                                    &nbsp;&nbsp;&nbsp;<li style="display:inline-block"><input type="checkbox" id="air11" name="air1" value="" />
                                        <label for="air11">Auto Off</label>
                                    </li>
                                </ul>
                            </fieldset> 
                        </div>
                        <div class=" col-lg-6">
                            <fieldset class="group" style=" box-shadow: 0 0 10px #999;">
                                <legend style="width:auto" align="center">Air Control System</legend>
                                <ul class="checkbox" style="font-size:small">
                                    <li style="display:inline-block"><input type="checkbox" id="air2" name="air2" value="" />
                                        <label for="air2">Auto On</label>
                                    </li>
                                    &nbsp;&nbsp;&nbsp;<li style="display:inline-block"><input type="checkbox" id="air22" name="air2" value="" />
                                        <label for="air22">Auto Off</label>
                                    </li>
                                </ul>
                            </fieldset>
                        </div>
                    </div>
                    <div class="row" style="width:80%" >
                      <div class="col" style="text-align:center">
                    <input type="button" class="btn-info customButton"  value="Read Configurations" />
                    </div>
                    <div class="col" style="text-align:center">
                    <input type="button" class="btn-info customButton"  value="Write Configurations" />
                     </div>
                          </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server">
                <HeaderTemplate>
                    <img src="Images/icons/vidblack.png" height="15px" width="15px" />&nbsp;
                    Recording</HeaderTemplate>
                <ContentTemplate>
                    <div class="row" style="width:80%">
                        <fieldset class="group" style=" width:100%; box-shadow: 0 0 10px #999; margin-left:5px;">
                            <legend align="center" style="width:auto">Baudrate and Parity</legend>
                            <div class="row" style="margin-left:5px; margin-right:5px;font-size:small">
                                <div class="col">
                            <label for="baud1" style="font-size:small">Baudrate &nbsp;</label>
                            <select id="baud1" class="btn dropdown btn-group" style="border:1px solid chocolate;font-size:small">
                                <option value="1">1200</option>
                                <option value="2">2400</option>
                                <option value="3">4800</option>
                                <option value="4">9600</option>
                                <option value="5">19200</option>
                                <option value="6">38400</option>
                                <option value="7">57600</option>
                                <option value="8">76800</option>
                                <option value="9">115200</option>
                            </select>
                                </div>
                                <div class="col">
                            <label for="parity1" style="font-size:small">Parity &nbsp;</label>
                            <select id="parity1" class="btn dropdown btn-group" style="border:1px solid chocolate;font-size:small">
                                <option value="-1">none</option>
                                <option value="1">Odd</option>
                                <option value="0">Even</option>
                            </select>
                               </div>
                            </div>
                            </fieldset>
                    </div>
                            <div class="row" style=" width:80%; ">
                                <div class="col">
                                <fieldset class="group" style=" box-shadow: 0 0 10px #999; width:100%;font-size:small">
                                    <legend align="center" style="width:auto">Group Code</legend>
                                    <label for="sys1" style="margin-left:10px;">Turn On System(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="sys1" class="form-control" />
                                    <label for="sys2" style="margin-left:10px; margin-top:10px">Turn Off System(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="sys2" class="form-control" />
                                    <label for="sys3" style="margin-left:10px; margin-top:10px">Turn On Recording(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="sys3" class="form-control" />
                                    <label for="sys4" style="margin-left:10px; margin-top:10px">Stop Recording(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="sys4" class="form-control" />
                                    <label for="sys5" style="margin-left:10px; margin-top:10px">Transfer(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="sys5" class="form-control" />
                                    <label for="sys6" style="margin-left:10px; margin-top:10px">Save(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px; Margin-bottom:20px;" id="sys6" class="form-control" />
                                </fieldset>
                                    </div>
                            </div>
                    <div class="row" style=" text-align:center;width:80%">
                                    <div class="col">
                                        <input type="button" class="btn btn-group" value="ok"/>
                                    </div>
                                    <div class="col">
                                        <input type="button" class="btn btn-group" value="save" />
                                    </div>
                                    <div class="col">
                                        <input type="button" class="btn btn-group" value="Cancel" />
                                    </div>
                                </div>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel runat="server">
                <HeaderTemplate>
                    <img src="Images/icons/camblack.png" height="15px" width="15px" />&nbsp;
                    Camera</HeaderTemplate>
                <ContentTemplate>
                    <div class="row" >
                        <div class="col" style="font-size:small">
                        <input type="radio" style="display:inline-block" name="cam" id="radio1" value=""/>
                        <label for="radio1">Teacher Camera</label>
                        </div>
                        <div class="col" style="font-size:small">
                        <input type="radio" id="radio2" style="display:inline-block" name="cam" value=""/>
                        <label for="radio2">Student Camera</label>
                        </div>        
                        <div class="col" style="font-size:small">
                        <input type="radio" style="display:inline-block" id="radio3" name="cam" value=""/>
                        <label for="radio3">Third Camera</label>
                         </div>           
                        <div class="col" style="font-size:small">
                        <input type="radio" id="radio4" style="display:inline-block" name="cam" value=""/>
                        <label for="radio3">Fourth Camera</label>
                        </div>
                    </div>
                    <div class="row" style="margin-left:5px;">
                        <fieldset class="group" style=" box-shadow: 0 0 10px #999; width:80%">
                            <legend align="center" style="width:auto">Baudrate and Parity</legend>
                            <div class="row" style="margin-left:5px; margin-right:5px;font-size:small">
                                <div class="col-lg-6 col-md-6 col-sm-12">
                            <label for="baud2" style="font-size:small">Baudrate &nbsp;</label>
                            <select id="baud2" class="btn dropdown btn-group" style="border:1px solid chocolate;font-size:small">
                                <option value="1">1200</option>
                                <option value="2">2400</option>
                                <option value="3">4800</option>
                                <option value="4">9600</option>
                                <option value="5">19200</option>
                                <option value="6">38400</option>
                                <option value="7">57600</option>
                                <option value="8">76800</option>
                                <option value="9">115200</option>
                            </select>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-12">
                            <label for="parity3" style="font-size:small">Parity &nbsp;</label>
                            <select id="parity3" class="btn dropdown btn-group" style="border:1px solid chocolate;font-size:small">
                                <option value="-1">none</option>
                                <option value="1">Odd</option>
                                <option value="0">Even</option>
                            </select>
                               </div>
                            </div>
                            </fieldset>
                    </div>
                    <div class="row" style="margin-left:5px;">
                         <fieldset class="group" style=" box-shadow: 0 0 10px #999; width:80%;">
                            <legend align="center" style="width:auto">Group Code</legend>
                    <div class="row" style="  margin-right:5px;">
                         <div class="col-lg-6 col-md-6 col-sm-12" style="font-size:small;">
                               
                                    <label for="cam11" style="margin-left:10px;">Zoom In(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam11" class="form-control" />
                                    <label for="cam12" style="margin-left:10px; margin-top:10px">Zoom Out(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam12" class="form-control" />
                                    <label for="cam13" style="margin-left:10px; margin-top:10px">Automatic white balance(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam13" class="form-control" />
                                    <label for="cam14" style="margin-left:10px; margin-top:10px">Automatic Recording(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam14" class="form-control" />
                                    <label for="cam15" style="margin-left:10px; margin-top:10px">Transfer(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam15" class="form-control" />
                                    <label for="cam16" style="margin-left:10px; margin-top:10px">Save(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px; " id="cam16" class="form-control" />
                                    <label for="cam17" style="margin-left:10px; margin-top:10px">Turn Off System(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;Margin-bottom:20px;" id="cam17" class="form-control" />
                                    </div>
                                <div class="col-lg-6 col-md-6 col-sm-12" style="font-size:small;">
                                    <label for="cam18" style="margin-left:10px; margin-top:10px">On(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam18" class="form-control" />
                                    <label for="cam19" style="margin-left:10px; margin-top:10px">Down(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam19" class="form-control" />
                                    <label for="cam20" style="margin-left:10px; margin-top:10px">left(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam20" class="form-control" />
                                    <label for="cam21" style="margin-left:10px; margin-top:10px">Right(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam21" class="form-control" />
                                    <label for="cam22" style="margin-left:10px; margin-top:10px">Ok(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px;" id="cam22" class="form-control" />
                                    <label for="cam23" style="margin-left:10px; margin-top:10px">Turn On System(Hexadecimal code)</label>
                                    <input type="text" style="margin-left:10px; Margin-bottom:20px;" id="cam23" class="form-control" />
                                 </div>
                            </div>
                             </fieldset>
                        </div>
                    <div class="row" style="text-align:center;width:80%;margin-left:5px;">
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <input type="button" class="btn btn-group" value="ok"/>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <input type="button" class="btn btn-group" value="save" />
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-12">
                                        <input type="button" class="btn btn-group" value="Cancel" />
                                    </div>
                                </div>
                 </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>           
    </div>               
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterSideBody" runat="server">
    <asp:UpdatePanel runat="server">
       <ContentTemplate>   
            <div class="row " style="background-color: #bff5e9; margin-left:-25px;">
                Select Class for Configuration Settings - &nbsp;
                <asp:CheckBoxList runat="server" ID="ddlClass" ></asp:CheckBoxList>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
