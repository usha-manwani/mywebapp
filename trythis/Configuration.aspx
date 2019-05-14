<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="WebCresij.Configuration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
    <link href="css/Configcss.css" rel="stylesheet" />
    <link href="ajaxfiles/Background.css" rel="stylesheet" />
    <link href="ajaxfiles/Tabs.css" rel="stylesheet" />
   <style>
      
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
    <script src="ajaxfiles/Localization.Resources.debug.js"></script>
    <script src="ajaxfiles/Common.debug.js"></script>
    <script src="ajaxfiles/ComponentSet.debug.js"></script>
    <script src="ajaxfiles/BaseScripts.debug.js"></script>
    <script src="ajaxfiles/Tabs.debug.js"></script>    
    <script src="ajaxfiles/DynamicPopulate.debug.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script>
    <script src="Scripts/Config.js"></script>
    <div>
        <div style="background-color: #4ecdc4; margin-left:-25px; margin-top:-30px">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-lg-3 col-sm-12 col-md-12 ">
                            <span><%=Resources.Resource.SelectInsGrade%></span> - &nbsp;
                        </div>
                        <div class=" col-lg-2 col-sm-6 col-md-6 float-left">
                            <asp:DropDownList Width="100px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                                CssClass="btn btn-default border dropdown" ID="ddlInstitute"
                                data-toggle="dropdown" runat="server">
                                <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        &nbsp;&nbsp;  &nbsp;&nbsp; &nbsp;
         <div class="col-lg-2 col-sm-6 col-md-6 float-none">
             <asp:DropDownList Width="100px" ID="ddlGrade"
                 OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged"
                 CssClass="btn btn-default border dropdown" data-toggle="dropdown"
                 AutoPostBack="true" runat="server">
                 <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
             </asp:DropDownList>
         </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row" >
            <div class="col-xl-10 col-lg-12 col-md-12 col-sm-12">
            <cc1:TabContainer ID="tb1" runat="server" CssClass="fancy fancy-green">
                <cc1:TabPanel runat="server">
                    <HeaderTemplate>
                        <img src="Images/icons/deskblack.png" height="15" width="15" />&nbsp;
                    <span><%=Resources.Resource.SystemSetup%></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <fieldset class="group" style="width: 80%;font-size:small">
                            <legend align="center" style="width: auto"><span><%=Resources.Resource.ConfigSettings%></span></legend>
                            <div class="row">
                                <div class="col-lg-6 col-sm-12 col-md-12" style="font-size: small">
                                    <ul class="checkbox">
                                        <li>
                                            <input type="checkbox" id="cb1" name="sys" value="pepperoni" />
                                            <label for="cb1"><span><%=Resources.Resource.ProjAutoBoot%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb2" name="sys" value="sausage" />
                                            <label for="cb2"><span><%=Resources.Resource.ProjAutoShut%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb3" name="sys" value="mushrooms" />
                                            <label for="cb3"><span><%=Resources.Resource.ScDownProj%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb4" name="sys" value="onions" />
                                            <label for="cb4"><span><%=Resources.Resource.CompAutoBoot%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb5" name="sys" value="gpeppers" />
                                            <label for="cb5"><span><%=Resources.Resource.CompAutoShut%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb6" name="sys" value="xcheese" />
                                            <label for="cb6>"><span><%=Resources.Resource.ProjAutoSwitch%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb7" name="sys" value="pepperoni" />
                                            <label for="cb7"><span><%=Resources.Resource.ScreenDownWithProj%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb8" name="sys" value="sausage" />
                                            <label for="cb8"><span><%=Resources.Resource.ScreenUPWithProj%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb9" name="sys" value="mushrooms" />
                                            <label for="cb9"><span><%=Resources.Resource.VolumeOn%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb10" name="sys" value="onions" />
                                            <label for="cb10"><span><%=Resources.Resource.TurnOnBuzzer%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb11" name="sys" value="gpeppers" />
                                            <label for="cb11"><span><%=Resources.Resource.IOShutDown%></span></label></li>
                                        <li>
                                            <label for="delayminutes"><span><%=Resources.Resource.projectorDelayShut%></span></label>
                                            <select name="delayminutes" id="delaymin" class="btn btn-default dropdown"
                                                style="border: 1px solid chocolate;">
                                                <option value="01">1 <span><%=Resources.Resource.Mins%></span></option>
                                                <option value="02">2 <span><%=Resources.Resource.Mins%></span></option>
                                                <option value="03">3 <span><%=Resources.Resource.Mins%></span></option>
                                                <option value="04">4 <span><%=Resources.Resource.Mins%></span></option>
                                                <option value="05">5 <span><%=Resources.Resource.Mins%></span></option>
                                                <option value="06">6 <span><%=Resources.Resource.Mins%></span></option>
                                                <option value="07">7 <span><%=Resources.Resource.Mins%></span></option>
                                                <option value="08">8 <span><%=Resources.Resource.Mins%></span></option>
                                                <option value="09">9 <span><%=Resources.Resource.Mins%></span></option>
                                            </select>
                                        </li>
                                    </ul>
                                </div>
                                <div class="col-lg-6 col-sm-12 col-md-12" style="font-size: small">
                                    <ul class="checkbox">
                                        <li>
                                            <input type="checkbox" id="cb12" name="sys" value="pepperoni" />
                                            <label for="cb12"><span><%=Resources.Resource.Proj232%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb13" name="sys" value="sausage" />
                                            <label for="cb13"><span><%=Resources.Resource.ProjInfraRed%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb14" name="sys" value="gpeppers" />
                                            <label for="cb14"><span><%=Resources.Resource.IOBoot%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb15" name="sys" value="onions" />
                                            <label for="cb15"><span><%=Resources.Resource.SwipeOpen%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb16" name="sys" value="peppers" />
                                            <label for="cb16"><span><%=Resources.Resource.SwipeClose%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb17" name="sys" value="xcheese" />
                                            <label for="cb17"><span><%=Resources.Resource.FingerPrintOpen%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb18" name="sys" value="xcheese" />
                                            <label for="cb18"><span><%=Resources.Resource.FingerPrintClose%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb19" name="sys" value="xcheese" />
                                            <label for="cb19"><span><%=Resources.Resource.CompLinkageOff%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb20" name="sys" value="xcheese" />
                                            <label for="cb20"><span><%=Resources.Resource.HDMIAudioSep%></span></label></li>
                                        <li>
                                            <input type="checkbox" id="cb21" name="sys" value="xcheese" />
                                            <label for="cb21"><span><%=Resources.Resource.SystemAlarm%></span></label></li>
                                        <li>
                                            <label for="delaySeconds"><span><%=Resources.Resource.ProjectorDelayBoot%></span></label>
                                            <select id="delaysec" name="delaySeconds" class="btn btn-default dropdown" 
                                                style="border: 1px solid chocolate;">
                                                <option value="01">1 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="02">2 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="03">3 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="04">4 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="05">5 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="06">6 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="07">7 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="08">8 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="09">9 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="10">10 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="11">11 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="12">12 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="13">13 <span><%=Resources.Resource.Seconds%></span></option>
                                                <option value="14">14 <span><%=Resources.Resource.Seconds%></span>s</option>
                                            </select>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="row" style="padding-right: 10px;">
                                <div class="col-xl-6 col-lg-12 col-sm-12 col-md-12">
                                    <fieldset class="group" style="box-shadow: 0 0 10px #999; ">
                                        <legend style="width: auto" align="center"><span><%=Resources.Resource.Alarm%></span></legend>
                                        <div class="row" >
                                            <div class="col-lg-6 col-md-6 col-sm-6" style="font-size: small">
                                                <ul class="checkbox">
                                                    <li>
                                                        <input type="checkbox" id="cb22" name="sys" value="pepperoni" />
                                                        <label for="cb22">IO1</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb23" name="sys" value="sausage" />
                                                        <label for="cb23">IO2</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb24" name="sys" value="mushrooms" />
                                                        <label for="cb24">IO3</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb25" name="sys" value="onions" />
                                                        <label for="cb25">IO4</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb26" name="sys" value="gpeppers" />
                                                        <label for="cb26">IO5</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb27" name="sys" value="xcheese" />
                                                        <label for="cb27">IO6</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb28" name="sys" value="xcheese" />
                                                        <label for="cb28">IO7</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb29" name="sys" value="xcheese" />
                                                        <label for="cb29">IO8</label></li>
                                                </ul>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6" style="font-size: x-small">
                                                <ul class="checkbox">
                                                    <li>
                                                        <input type="checkbox" id="cb30" name="sys" value="pepperoni" />
                                                        <label for="cb30">IO9</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb31" name="sys" value="sausage" />
                                                        <label for="cb31">IO10</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb32" name="sys" value="mushrooms" />
                                                        <label for="cb32">IO11</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb33" name="sys" value="onions" />
                                                        <label for="cb33">IO12</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb34" name="sys" value="gpeppers" />
                                                        <label for="cb34">IO13</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb35" name="sys" value="xcheese" />
                                                        <label for="cb35">IO14</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb36" name="sys" value="xcheese" />
                                                        <label for="cb36">IO15</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb37" name="sys" value="xcheese" />
                                                        <label for="cb37">IO16</label></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                                <div class="col-xl-6 col-lg-12 col-sm-12 col-md-12">
                                    <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                        <legend style="width: auto" align="center"><span><%=Resources.Resource.IO%></span></legend>
                                        <div class="row">
                                            <div class="col-lg-6 col-md-6 col-sm-6" style="font-size: x-small;">
                                                <ul class="checkbox">
                                                    <li>
                                                        <input type="checkbox" id="cb38" name="sys" value="pepperoni" />
                                                        <label for="cb38">IO1</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb39" name="sys" value="sausage" />
                                                        <label for="cb39">IO2</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb40" name="sys" value="mushrooms" />
                                                        <label for="cb40">IO3</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb41" name="sys" value="onions" />
                                                        <label for="cb41">IO4</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb42" name="sys" value="gpeppers" />
                                                        <label for="cb42">IO5</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb43" name="sys" value="xcheese" />
                                                        <label for="cb43">IO6</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb44" name="sys" value="xcheese" />
                                                        <label for="cb44">IO7</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb45" name="sys" value="xcheese" />
                                                        <label for="cb45">IO8</label></li>
                                                </ul>
                                            </div>
                                            <div class="col-lg-6 col-md-6 col-sm-6" style="font-size: x-small">
                                                <ul class="checkbox">
                                                    <li>
                                                        <input type="checkbox" id="cb46" name="sys" value="pepperoni" />
                                                        <label for="cb46">IO9</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb47" name="sys" value="sausage" />
                                                        <label for="cb47">IO10</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb48" name="sys" value="mushrooms" />
                                                        <label for="cb48">IO11</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb49" name="sys" value="onions" />
                                                        <label for="cb49">IO12</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb50" name="sys" value="gpeppers" />
                                                        <label for="cb50">IO13</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb51" name="sys" value="xcheese" />
                                                        <label for="cb51">IO14</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb52" name="sys" value="xcheese" />
                                                        <label for="cb52">IO15</label></li>
                                                    <li>
                                                        <input type="checkbox" id="cb53" name="sys" value="xcheese" />
                                                        <label for="cb53">IO16</label></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col" style="text-align: center">
                                    <button class="btn-info customButton" id="readConfig"
                                        value="Read Configuration"  ><span><%=Resources.Resource.ReadConfig%></span></button>
                                </div>
                                <div class="col" style="text-align: center">
                                    <button class="btn-info customButton" id="writeConfig"
                                        value="Write Configuration" ><span><%=Resources.Resource.WriteConfig%></span></button>
                                </div>
                            </div>
                        </fieldset>

                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel runat="server">
                    <HeaderTemplate>
                        <img src="Images/icons/project4.png" height="15px" width="15px" />&nbsp;
                    <span><%=Resources.Resource.Projector%></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="row" style="margin-right: 5px;">
                            <div class="col-lg-6 " >
                                <div class="row" style="padding-bottom:30px">
                                    <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                        <legend align="center" style="width: auto"><span><%=Resources.Resource.Options%></span></legend>
                                        <div style="min-width: 300px;"></div>
                                    </fieldset>
                                </div>
                                <div class="row" style="padding-bottom:30px">
                                    <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                        <legend align="center" style="width: auto"><span><%=Resources.Resource.Data%></span></legend>
                                        <div style="min-width: 300px;"></div>
                                    </fieldset>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend align="center" style="width: auto"><span><%=Resources.Resource.SettingsMenu%></span></legend>
                                    <div style="margin-left: 5px; margin-right: 5px; font-size: small">
                                        <label for="baud"><span><%=Resources.Resource.BaudRate%></span></label>&nbsp;
                                    <select id="baud" class="btn dropdown btn-group" 
                                        style="border: 1px solid chocolate; font-size: small">
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
                                    <label for="parity"><span><%=Resources.Resource.Parity%></span></label>&nbsp;
                                    <select id="parity" class="btn dropdown btn-group" 
                                        style="border: 1px solid chocolate; font-size: small; margin-right: 5px;">
                                        <option value="-1"><span><%=Resources.Resource.none%></span></option>
                                        <option value="1"><span><%=Resources.Resource.Odd%></span></option>
                                        <option value="0"><span><%=Resources.Resource.Even%></span></option>
                                    </select>&nbsp;&nbsp;
                                    </div>
                                    <div>
                                        <asp:Label runat="server" Text="<%$Resources:Resource, HexCode %>"></asp:Label>
                                    </div>

                                    <div class="row" style="margin-left: 5px; margin-right: 5px; font-size: small">
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <label for="tb1"><span><%=Resources.Resource.ProjOn%></span></label>&nbsp;
                                        </div>
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-left: 5px; margin-right: 5px; font-size: small">
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <label for="tb2"><span><%=Resources.Resource.ProjOff%></span></label>&nbsp;
                                        </div>
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-left: 5px; margin-right: 5px; font-size: small">
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <label for="tb3"><span><%=Resources.Resource.Video%></span></label>&nbsp;
                                        </div>
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-left: 5px; margin-right: 5px; font-size: small">
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <label for="tb4">VGA</label>&nbsp;
                                        </div>
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-left: 5px; margin-right: 5px; font-size: small">
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <label for="tb5">HDMI</label>&nbsp;
                                        </div>
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                    <div class="row" style="margin-left: 5px; margin-right: 5px; font-size: small">
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <label for="tb6"><span><%=Resources.Resource.Sleep%></span></label>&nbsp;
                                        </div>
                                        <div class="col" style="margin-left: 5px; margin-right: 15px; font-size: small">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>

                                    <div class="row" style="text-align: center;padding-bottom:30px">
                                        <div class="col">
                                            <button id="projok" class="btn btn-group border-dark" value="Cancel" >
                                                <span><%=Resources.Resource.Ok%></span></button>
                                        </div>
                                        <div class="col">
                                            <button id="projsave" class="btn btn-group border-dark" value="Cancel" >
                                                <span><%=Resources.Resource.Save%></span>
                                            </button>
                                        </div>
                                        <div class="col">
                                            <button id="projcancle" class="btn btn-group border-dark" value="Cancel" >
                                                <span><%=Resources.Resource.Cancel%></span>
                                            </button>
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
                    <span><%=Resources.Resource.Power%></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="row" style="margin-right: 5px;">
                            <div class="col-lg-6">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend align="center" style="width: auto" runat="server"><span><%=Resources.Resource.Light%></span>1</legend>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6" style="font-size: small">
                                            <ul class="checkbox">
                                                <li>
                                                    <input type="checkbox" id="bc1" name="light1" value="pepperoni" />
                                                    <label for="bc1"><span><%=Resources.Resource.Light%></span> 1 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc2" name="light1" value="pepperoni" />
                                                    <label for="bc2"><span><%=Resources.Resource.Light%></span> 2 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc3" name="light1" value="pepperoni" />
                                                    <label for="bc3"><span><%=Resources.Resource.Light%></span> 3 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc4" name="light1" value="pepperoni" />
                                                    <label for="bc4"><span><%=Resources.Resource.Light%></span> 4 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc5" name="light1" value="pepperoni" />
                                                    <label for="bc5"><span><%=Resources.Resource.Light%></span> 5 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc6" name="light1" value="pepperoni" />
                                                    <label for="bc6"><span><%=Resources.Resource.Light%></span> 6<span><%=Resources.Resource.AutoOn%></span></label></li>
                                            </ul>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6" style="font-size: small">
                                            <ul class="checkbox">
                                                <li>
                                                    <input type="checkbox" id="bc7" name="light1" value="pepperoni" />
                                                    <label for="bc7"><span><%=Resources.Resource.Light%></span> 1 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc8" name="light1" value="pepperoni" />
                                                    <label for="bc8"><span><%=Resources.Resource.Light%></span> 2 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc9" name="light1" value="pepperoni" />
                                                    <label for="bc9"><span><%=Resources.Resource.Light%></span> 3 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc10" name="light1" value="pepperoni" />
                                                    <label for="bc10"><span><%=Resources.Resource.Light%></span> 4 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc11" name="light1" value="pepperoni" />
                                                    <label for="bc11"><span><%=Resources.Resource.Light%></span> 5 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc12" name="light1" value="pepperoni" />
                                                    <label for="bc12"><span><%=Resources.Resource.Light%></span> 6 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                            </ul>
                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                            <div class="col-lg-6">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend align="center" style="width: auto"><span><%=Resources.Resource.Light%></span> 2</legend>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sm-6" style="font-size: small">
                                            <ul class="checkbox">
                                                <li>
                                                    <input type="checkbox" id="bc13" name="light2" value="pepperoni" />
                                                    <label for="bc13"><%=Resources.Resource.Light%></span> 7 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc14" name="light2" value="pepperoni" />
                                                    <label for="bc14"><%=Resources.Resource.Light%></span> 8 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc15" name="light2" value="pepperoni" />
                                                    <label for="bc15"><%=Resources.Resource.Light%></span> 9 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc16" name="light2" value="pepperoni" />
                                                    <label for="bc16"><%=Resources.Resource.Light%></span> 10 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc17" name="light2" value="pepperoni" />
                                                    <label for="bc17"><%=Resources.Resource.Light%></span> 11 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc18" name="light2" value="pepperoni" />
                                                    <label for="bc18"><%=Resources.Resource.Light%></span> 12 <span><%=Resources.Resource.AutoOn%></span></label></li>
                                            </ul>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sm-6" style="font-size: small">
                                            <ul class="checkbox">
                                                <li>
                                                    <input type="checkbox" id="bc19" name="light2" value="pepperoni" />
                                                    <label for="bc19"><%=Resources.Resource.Light%></span> 7 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc20" name="light2" value="pepperoni" />
                                                    <label for="bc20"><%=Resources.Resource.Light%></span> 8 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc21" name="light2" value="pepperoni" />
                                                    <label for="bc21"><%=Resources.Resource.Light%></span> 9 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc22" name="light2" value="pepperoni" />
                                                    <label for="bc22"><%=Resources.Resource.Light%></span> 10 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc23" name="light2" value="pepperoni" />
                                                    <label for="bc23"><%=Resources.Resource.Light%></span> 11 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                                <li>
                                                    <input type="checkbox" id="bc24" name="light2" value="pepperoni" />
                                                    <label for="bc24"><%=Resources.Resource.Light%></span> 12 <span><%=Resources.Resource.AutoOff%></span></label></li>
                                            </ul>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row" style="margin-right: 5px;">
                            <div class="col-lg-3 col-md-6 col-sm-12" style="font-size: small">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend style="width: auto" align="center"><span><%=Resources.Resource.Curtain%></span> 1</legend>
                                    <ul class="checkbox">
                                        <li>
                                            <input type="checkbox" id="w1" name="w1" value="pepperoni" />
                                            <label for="w1"><%=Resources.Resource.Curtain%> 1 <%=Resources.Resource.AutoOn%></label></li>
                                        <li>
                                            <input type="checkbox" id="w11" name="w1" value="pepperoni" />
                                            <label for="w11"><%=Resources.Resource.Curtain%> 1 <%=Resources.Resource.AutoOff%></label></li>
                                    </ul>
                                </fieldset>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-12" style="font-size: small">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend style="width: auto" align="center"><%=Resources.Resource.Curtain%> 2</legend>
                                    <ul class="checkbox">
                                        <li>
                                            <input type="checkbox" id="w2" name="w2" value="pepperoni" />
                                            <label for="w2"><%=Resources.Resource.Curtain%> 2 <%=Resources.Resource.AutoOn%></label></li>
                                        <li>
                                            <input type="checkbox" id="w22" name="w2" value="pepperoni" />
                                            <label for="w22"><%=Resources.Resource.Curtain%> 2 <%=Resources.Resource.AutoOff%></label></li>
                                    </ul>
                                </fieldset>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-12" style="font-size: small">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend style="width: auto" align="center"><%=Resources.Resource.Curtain%> 3</legend>
                                    <ul class="checkbox">
                                        <li>
                                            <input type="checkbox" id="w3" name="w3" value="pepperoni" />
                                            <label for="w3"><%=Resources.Resource.Curtain%> 3 <%=Resources.Resource.AutoOn%></label></li>
                                        <li>
                                            <input type="checkbox" id="w33" name="w33" value="pepperoni" />
                                            <label for="w33"><%=Resources.Resource.Curtain%> 3 <%=Resources.Resource.AutoOff%></label></li>
                                    </ul>
                                </fieldset>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-12" style="font-size: small">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend style="width: auto" align="center"><%=Resources.Resource.Curtain%> 4</legend>
                                    <ul class="checkbox">
                                        <li>
                                            <input type="checkbox" id="w4" name="w4" value="pepperoni" />
                                            <label for="w4"><%=Resources.Resource.Curtain%> 4 <%=Resources.Resource.AutoOn%></label></li>
                                        <li>
                                            <input type="checkbox" id="w44" name="w4" value="pepperoni" />
                                            <label for="w44"><%=Resources.Resource.Curtain%> 4 <%=Resources.Resource.AutoOff%></label></li>
                                    </ul>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row" style="margin-right: 5px;">
                            <div class=" col-lg-6">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend style="width: auto" align="center"><%=Resources.Resource.FreshAirSystem%></legend>
                                    <ul class="checkbox" >
                                        <li style="display: inline-block">
                                            <input type="checkbox" id="air1" name="air1" value="" />
                                            <label for="air1"><%=Resources.Resource.AutoOn%></label>
                                        </li>
                                        &nbsp;&nbsp;&nbsp;<li style="display: inline-block">
                                            <input type="checkbox" id="air11" name="air1" value="" />
                                            <label for="air11"><%=Resources.Resource.AutoOff%></label>
                                        </li>
                                    </ul>
                                </fieldset>
                            </div>
                            <div class=" col-lg-6">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999;">
                                    <legend style="width: auto" align="center"><%=Resources.Resource.AC%></legend>
                                    <ul class="checkbox" >
                                        <li style="display: inline-block">
                                            <input type="checkbox" id="air2" name="air2" value="" />
                                            <label for="air2"><%=Resources.Resource.AutoOn%></label>
                                        </li>
                                        &nbsp;&nbsp;&nbsp;<li style="display: inline-block">
                                            <input type="checkbox" id="air22" name="air2" value="" />
                                            <label for="air22"><%=Resources.Resource.AutoOff%></label>
                                        </li>
                                    </ul>
                                </fieldset>
                            </div>
                        </div>
                        <div class="row" style="width: 80%">
                            <div class="col" style="text-align: center">
                                <button class="btn btn-default  customButton border-dark" id="powerok" value="Save" >
                                    <span><%=Resources.Resource.Save%></span>
                                </button>
                            </div>
                            <div class="col" style="text-align: center">
                                <button class="btn btn-default customButton border-dark" id="powercancel" value="Cancel" >
                                    <span><%=Resources.Resource.Cancel%></span>
                                </button>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel runat="server">
                    <HeaderTemplate>
                        <img src="Images/icons/vidblack.png" height="15px" width="15px" />&nbsp;
                    <span><%=Resources.Resource.Recording%></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="row" style="width: 80%;padding-bottom:30px">
                            <fieldset class="group" style="width: 100%; box-shadow: 0 0 10px #999; margin-left: 5px;">
                                <legend align="center" style="width: auto"><span><%=Resources.Resource.BaudParity%></span></legend>
                                <div class="row" style="margin-left: 5px; margin-right: 5px; font-size: small;padding-bottom:30px">
                                    <div class="col">
                                        <label for="baud1" ><span><%=Resources.Resource.BaudRate%></span> &nbsp;</label>
                                        <select id="baud1" class="btn dropdown btn-group" 
                                            style="border: 1px solid chocolate; font-size: small;width:80px!important">
                                            
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
                                        <label for="parity1" ><span><%=Resources.Resource.Parity%></span> &nbsp;</label>
                                        <select id="parity1" class="btn dropdown btn-group"
                                            style="border: 1px solid chocolate; font-size: small">
                                            <option value="-1"><span><%=Resources.Resource.none%></span></option>
                                            <option value="1"><span><%=Resources.Resource.Odd%></span></option>
                                            <option value="0"><span><%=Resources.Resource.Even%></span></option>
                                        </select>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row" style="width: 80%;">
                            <div class="col">
                                <fieldset class="group" style="box-shadow: 0 0 10px #999; width: 100%;">
                                    <legend align="center" style="width: auto"><span><%=Resources.Resource.GroupCode%></span></legend>
                                    <label for="sys1" style="margin-left: 10px;"><span><%=Resources.Resource.SystemHexOn%></span></label>
                                    <input type="text" style="margin-left: 10px;" id="sys1" class="form-control" />
                                    <label for="sys2" style="margin-left: 10px; 
                                        margin-top: 10px"><span><%=Resources.Resource.SystemHexOff%></span></label>
                                    <input type="text" style="margin-left: 10px;" id="sys2" class="form-control" />
                                    <label for="sys3" style="margin-left: 10px; margin-top: 10px">
                                        <span><%=Resources.Resource.RecordingOn%></span></label>
                                    <input type="text" style="margin-left: 10px;" id="sys3" class="form-control" />
                                    <label for="sys4" style="margin-left: 10px; margin-top: 10px">
                                        <span><%=Resources.Resource.RecordingOff%></span></label>
                                    <input type="text" style="margin-left: 10px;" id="sys4" class="form-control" />
                                    <label for="sys5" style="margin-left: 10px; margin-top: 10px">
                                        <span><%=Resources.Resource.Recall%></span></label>
                                    <input type="text" style="margin-left: 10px;" id="sys5" class="form-control" />
                                    <label for="sys6" style="margin-left: 10px; margin-top: 10px">
                                        <span><%=Resources.Resource.SaveHex%></span></label>
                                    <input type="text" style="margin-left: 10px; margin-bottom: 20px;" id="sys6" class="form-control" />
                                </fieldset>
                            </div>
                        </div>
                        <div class="row" style="text-align: center; width: 80%">
                            <div class="col">
                                <button class="btn btn-group border-dark" id="recok" value="Ok" >
                                    <span><%=Resources.Resource.Ok%></span>
                                </button>
                            </div>
                            <div class="col">
                                <button class="btn btn-group border-dark" id="recsave" value="Save" >
                                    <span><%=Resources.Resource.Save%></span>
                                </button>
                            </div>
                            <div class="col">
                                <button class="btn btn-group border-dark" id="reccancel" value="Cancel" >
                                    <span><%=Resources.Resource.Cancel%></span>
                                </button>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel runat="server">
                    <HeaderTemplate>
                        <img src="Images/icons/camblack.png" height="15px" width="15px" />&nbsp;
                    <span><%=Resources.Resource.Camera%></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-lg-3 col-md-6 col-sm-6" style="font-size: small">
                                <input type="radio" style="display: inline-block" name="cam" id="radio1" value="" />
                                <label for="radio1"><span><%=Resources.Resource.TeacherCam%></span></label>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-6" style="font-size: small">
                                <input type="radio" id="radio2" style="display: inline-block" name="cam" value="" />
                                <label for="radio2"><span><%=Resources.Resource.StudentCam%></span></label>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-6" style="font-size: small">
                                <input type="radio" style="display: inline-block" id="radio3" name="cam" value="" />
                                <label for="radio3">Third Camera</label>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-6" style="font-size: small">
                                <input type="radio" id="radio4" style="display: inline-block" name="cam" value="" />
                                <label for="radio3">Fourth Camera</label>
                            </div>
                        </div>
                        <div class="row" style="margin-left: 5px; margin-bottom:30px">
                            <fieldset class="group" style="box-shadow: 0 0 10px #999; width: 80%">
                                <legend align="center" style="width: auto"><span><%=Resources.Resource.BaudParity%></span></legend>
                                <div class="row" style="margin-left: 5px; margin-right: 5px; padding-bottom:30px">
                                    <div class="col-lg-6 col-md-6 col-sm-12">
                                        <label for="baud2" >
                                            <span><%=Resources.Resource.BaudRate%></span> &nbsp;</label>
                                        <select id="baud2" class="btn dropdown btn-group" 
                                            style="border: 1px solid chocolate; font-size: small">
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
                                        <label for="parity2" >
                                            <span><%=Resources.Resource.Parity%></span> &nbsp;</label>
                                        <select id="parity2" class="btn dropdown btn-group" 
                                            style="border: 1px solid chocolate; font-size: small">
                                            <option value="-1"><span><%=Resources.Resource.none%></span></option>
                                            <option value="1"><span><%=Resources.Resource.Odd%></span></option>
                                            <option value="0"><span><%=Resources.Resource.Even%></span></option>
                                        </select>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row" style="margin-left: 5px;margin-bottom:5px">
                            <fieldset class="group" style="box-shadow: 0 0 10px #999; width: 80%;">
                                <legend align="center" style="width: auto"><span><%=Resources.Resource.GroupCode%></span></legend>
                                <div class="row" style="margin-right: 5px;">
                                    <div class="col-lg-6 col-md-6 col-sm-12" style="font-size: small;">
                                        <label for="cam11" style="margin-left: 10px;">
                                            <span><%=Resources.Resource.ZoomIn%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam11" class="form-control" />
                                        <label for="cam12" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.ZoomOut%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam12" class="form-control" />
                                        <label for="cam13" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.AutoWhiteBalance%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam13" class="form-control" />
                                        <label for="cam14" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.AutoRecord%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam14" class="form-control" />
                                        <label for="cam15" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.Recall%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam15" class="form-control" />
                                        <label for="cam16" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.SaveHex%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam16" class="form-control" />
                                        <label for="cam17" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.SystemHexOff%></span></label>
                                        <input type="text" style="margin-left: 10px; margin-bottom: 20px;" 
                                            id="cam17" class="form-control" />
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12" style="font-size: small;">
                                        <label for="cam18" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.Up%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam18" class="form-control" />
                                        <label for="cam19" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.Down%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam19" class="form-control" />
                                        <label for="cam20" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.Left%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam20" class="form-control" />
                                        <label for="cam21" style="margin-left: 10px; margin-top: 10px">
                                           <span><%=Resources.Resource.Right%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam21" class="form-control" />
                                        <label for="cam22" style="margin-left: 10px; margin-top: 10px">
                                            <span><%=Resources.Resource.OkHex%></span></label>
                                        <input type="text" style="margin-left: 10px;" id="cam22" class="form-control" />
                                        <label for="cam23" style="margin-left: 10px; margin-top: 10px">
                                           <span><%=Resources.Resource.SystemHexOn%></span></label>
                                        <input type="text" style="margin-left: 10px; margin-bottom: 20px;" 
                                            id="cam23" class="form-control" />
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                        <div class="row" style="text-align: center; width: 80%; margin-left: 5px;">
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <button class="btn btn-group  border-dark" id="camok" value="Ok">
                                    <span><%=Resources.Resource.Ok%></span>
                                </button>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <button class="btn btn-group border-dark" id="camsave" value="Save">
                                    <span><%=Resources.Resource.Save%></span>
                                </button>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4">
                                <button class="btn btn-group border-dark" id="camcancel" value="Cancel">
                                    <span><%=Resources.Resource.Cancel%></span>
                                </button>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
             </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="masterSideBody" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row " id="classchk" style="background-color: #4ecdc4; margin-left: -30px; margin-top:-20px;">
                <span><%=Resources.Resource.SelectClassConfig%></span> - &nbsp;
                <asp:CheckBoxList runat="server" ID="ddlClass"></asp:CheckBoxList>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
