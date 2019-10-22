<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.Master" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="WebCresij.Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
<style type="text/css">
.imgclick:active{
   box-shadow: 0 5px #666;
   transform: translateY(4px);
}
.imgclick:hover{
    -webkit-border-radius: 10px;
    -moz-border-radius: 10px;
    border-radius: 10px;
    -webkit-box-shadow: 0px 0px 30px 0px rgba(0, 0, 245, 0.67);
    -moz-box-shadow:    0px 0px 30px 0px rgba(0, 0, 245, 0.67);
    box-shadow:         0px 0px 30px 0px rgba(0, 0, 245, 0.67);
}
[type=radio] { 
  position: absolute;
  opacity: 0;
  width: 0;
  height: 0;
}
/* IMAGE STYLES */
[type=radio] + img {
  cursor: pointer;
}
/* CHECKED STYLES */
[type=radio]:checked + img {
  outline: 2px solid #f00;
}
.modal 
{
    display: none;  /*Hidden by default*/ 
    position: fixed;  /*Stay in place*/ 
    z-index: 1;  /*Sit on top*/ 
    padding-top: 150px;  /*Location of the box*/ 
    left: 0;
    top: 0;
    width: 100%;  /*Full width*/ 
    height: 100%;  /*Full height*/ 
    overflow: auto;  /*Enable scroll if needed*/ 
    background-color: rgb(0,0,0);  /*Fallback color*/ 
    background-color: rgba(0,0,0,0.4);  /*Black w/ opacity*/ 
}
.modal-content {
    background-color:aliceblue;
    margin: auto;
    padding: 20px;
    border: 1px solid #888;
    width: 60%;
} 
.pp{
    background-color: #565656;
    color: transparent;
    text-shadow: 0px 2px 3px rgba(255,255,255,0.3);
    -webkit-background-clip: text;
    -moz-background-clip: text;
    background-clip: text;
}
.displaynone{
        display:none;
}
.displayblock{
   display:inline-block;
   cursor:pointer;
}
.table1234 {
    float:left;
    border-radius: 10px;
    max-width: 250px;
    min-width:240px;
    min-height: 280px;
    max-height:300px;
    background-color:#23233f;
}
.fixwidth{
    width:80%;
    text-align:center;
}
.chk{
    width:20%;
    float:left;
    text-align:center;
}
</style>
    <link href="Content/ControlStyle.css?v=1" rel="stylesheet" />
    <link href="css/toggleswitch.css" rel="stylesheet" />
    <link href="http://www.cssscript.com/wp-includes/css/sticky.css" rel="stylesheet" type="text/css">
    <!--Reference the SignalR library. -->  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
    <script src="Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="Scripts/ControlKeys.js?v=19"></script>
    <h4 style="color:white;margin-top:-1rem">
        <asp:Label runat="server" ID="insName"></asp:Label>
        <asp:Label runat="server" ID="GradeName"></asp:Label>
    </h4>
        <hr style="background-color:black"/>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row" style="margin-bottom:-1.5rem; margin-top:-1rem">
        <span class="col-lg-3 col-md-6 col-sm-9" style="font-size:1rem; color:white">
            Select classes to on/off the Multiple devices</span>
                <div class="col-lg-1 col-md-1 col-sm-3">
        <button class="btn btn-outline-light " value="ON/OFF" id="btnOn"> On</button></div>
                <div class="col-lg-1 col-md-1 col-sm-3">
        <button class="btn btn-outline-light " value="ON/OFF" id="btnOff"> Off</button></div>
                <div class="col-lg-3"></div>
                <div class="col-lg-1 col-md-1 col-sm-3" style="float:right">
        <button class=" btn btn-link" value="ON/OFF" id="SelectAll"> Select All</button></div>
                <div class="col-lg-2 col-md-1 col-sm-3" style="float:right">
        <button class=" btn btn-link" value="ON/OFF" id="UnselectAll"> Unselect All</button></div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="container-fluid">
        <div class="row clearfix" id="smallcontrol" style="width: 90%; min-width: 800px; max-width: 100%">
            <input type="hidden" name="ipForRemote" value="<%= Session["MyVariable"]%>"/>
        </div>
    </div>
    <input id="sessionInput" type="hidden" value='<%= Session["DeviceIP"] %>'/>
    <input id="sessionInput1" type="hidden" value='<%= Session["loc"] %>'/>
    <input id="dev1" type="hidden" value='<%= Session["devices"] %>'/>
    <input id="InputIP" type="hidden" value='<%= Session["DeviceIP"] %>'/>
    <asp:TextBox Style="display:none" ID="ipAddressToSend" runat="server"></asp:TextBox>
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
    <%--  <div id="control" class="modal">
    <div class=" modal-content" style="font-family: 'Ruda', sans-serif" >        
        <div style="width:100%; color:#3c763d; border:solid;border-color:#3c763d; background-color:#dff0d8; 
             border-radius:5px" class="row " onmouseover="this.style.background='white';"
             onmouseout="this.style.background='#dff0d8';">
        <header>
            <p style="text-align:center">Remote Control For 
                <asp:Label runat="server" Font-Bold="true" Font-Italic="true" ID="deviceips" Text=""></asp:Label></p>
            </header>
        <div style="text-align:right">
             <i class="fa fa-times-circle" aria-hidden="true" onclick="closexx();"
                 style="text-align:right;cursor:pointer"></i>
         </div>
        </div>        
        
        <table  class="container " >
            <tr>
                <td>   
                <div  style="height:250px;width:250px;  border:none">    
             <header style=" background-color:#2680a7;color:black; text-align:center;border:solid;
                border-color:#428bca " >System Control&nbsp; 
                 <span data-toggle="collapse" data-target="#system" style="color:white" 
                     class="fa fa-angle-down trying" aria-expanded="true" aria-controls="system" ></span>
             </header>          
           <div id="system" class="divcontrols"  >
                <table style=" height:180px; width:220px;border-color:#333333" >
                    <tr > 
                        <td colspan="3" style="font-size:small; text-align:center"> System Power</td>
                        <td colspan="3" style="font-size:small; text-align:center"> Computer Power</td>
                    </tr>
                    <tr style="align-items:center; align-content:center;">
                        <td colspan="3" style="text-align:center">
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_210.png" id="systempower" 
                                    height="60" width="60" class="imgclick"/></span>
                             </td>
                        <td colspan="3" style="text-align:center">
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_212.png" id="pcpower" 
                                    height="60" width="60" class="imgclick"/></span>                          
                    </tr>                               
                    <tr >
                        <td colspan="2" style="text-align:center">
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_216.png"  id="syslock" 
                                    height="40" width="40" class="imgclick"/></span>                            
                           </td>                      
                        <td colspan="2" style="text-align:center"  >
                           
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_238.png" id="podiumlock"
                                    height="40" width="40" class="imgclick"/></span>
                            </td>                       
                        <td colspan="2" style="text-align:center" >
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_264.png"  id="classlock" 
                                    height="40" width="40" class="imgclick"/></span>
                             </td>
                    </tr>                  
                </table> 
               </div>          
                </div>
                </td>
                <td>
                <div style="height:250px;width:250px;  border:none">            
                    <header style=" background-color:#dff0d8;color:black; text-align:center ;
                        border:solid; border-color:#dff0d8">Projector Control&nbsp;
                        <span data-toggle="collapse" data-target="#Projector" style="color:#3c763d" 
                            class="fa fa-angle-down trying" ></span>
                    </header>
                    <div id="Projector" class="divcontrols" style=" border-color:#3c763d">
                     <table style=" height:180px; width:230px">                  
                    <tr style="width:220px">
                        <td style="text-align:center">
                            
                             <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_184.png" id="projectorOn" 
                                    height="40" width="40" class="imgclick"/></span>                
                        </td>
                        <td style="text-align:center">
                            <a  href="#" style=" color:white;">
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_138.png" id="hdmi" height="40" 
                                    width="40" class="imgclick"/></a>                            
                        </td>
                    </tr>
                    <tr style="width:220px">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_186.png" id="projectorOff" 
                                    height="40" width="40" class="imgclick"/></span>                            
                        </td>
                        <td style="text-align:center">
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_164.png" id="projVideo"
                                    height="40" width="40" class="imgclick"/></span>
                           </td>
                    </tr>
                    <tr style="width:220px">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_188.png" id="projSleep"
                                    height="40" width="40" class="imgclick"/></span>
                            </td>
                        <td style="text-align:center">
                            <span>
                                <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_190.png" id="vga" 
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                    </tr>                
                </table>
             </div>
             </div>
                </td>
                <td>
                <div style="height:250px;width:180px;  border:none">             
             <header style=" background-color:#d9edf7;color:black; text-align:center;
                        border:solid; border-color:#d9edf7 ">Light Control&nbsp;
                 <span class="fa fa-angle-down trying" data-toggle="collapse"
                     data-target="#light" style="color:#31708f;">
                     </span></header>                       
                    <div id="light" class="divcontrols" style=" border-color: #31708f;">
                             <table style="width:160px; height:180px;">
                 
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/light1off.png" id="light1"
                                    height="40" width="40" class="imgclick"/></span>
                             </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/light2off.png" id="light2" 
                                    height="40" width="40" class="imgclick"/></span>
                             </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/light3.png" id="light3" 
                                    height="40" width="40" class="imgclick"/></span>
                            </td>
                    </tr>
                </table>
                    </div>
             </div>
                </td>
                <td rowspan="2">
                <div  style=" width:180px; height:500px "> 
            <header style=" background-color:#fcf8e3;color:black; text-align:center;
                    border:solid; border-color:#fcf8e3 ">Media Signal&nbsp;
                <span data-toggle="collapse" data-target="#media" style="color:#916d3b" 
                    class="fa fa-angle-down trying" ></span>
            </header>
            <div id="media" class="divcontrols" style=" border-color:#916d3b">
                <table style="width:160px; color:#202838">                 
                    <tr  style="width:130px;">
                        <td  style="text-align:center">
                            <label>
                            <input type="radio" value="1" name="test" id="desktop" data-target=".displaynone" checked/>
                           <img src="Images/offimages/desktop.png" height="40" width="40" class="imgclick">
                            </label>
                            </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" value="2" name="test" id="laptop" data-target=".displaynone" checked>
                           <img src="Images/offimages/laptop.png" height="40" width="40" class="imgclick">
                            </label>
                            </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" value="3" name="test" id="platform" data-target=".displaynone" checked>
                            <img src="Images/offimages/screen.png" height="40" width="40" class="imgclick">
                            </label>
                           </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center" >
                             <label>
                            <input type="radio" value="4" name="test" id="digitalEquipment" data-target=".displaynone" checked>
                            <img src="Images/offimages/screen.png" height="40" width="40" class="imgclick">
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center" >
                            <label>
                            <input type="radio" value="5" name="test" id="dvd" data-target="#dvdcontrols" checked>
                            <img src="Images/offimages/dvd.png" height="40" width="40" class="imgclick" >
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                           <label>
                            <input type="radio" value="6" name="test" id="bluray" data-target="#bluraydvd" checked>
                            <img src="Images/offimages/bluraydvd.png" height="40" width="40" class="imgclick">
                            </label>
                       </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td  style="text-align:center">
                            <label>
                            <input type="radio" value="7" name="test" id="tv" data-target="#tvcontrols" checked>
                            <img src="Images/offimages/tv.png" height="40" width="40" class="imgclick">
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" value="8" name="test" id="camera" data-target="#Camera" checked>
                            <img src="Images/offimages/camera.png" height="40" width="40" class="imgclick">
                            </label>    
                       </td>
                            </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center" >
                            <label>
                            <input type="radio" value="9" name="test" id="recorder" data-target="#recordercontrol" checked>
                            <img src="Images/offimages/recorder.png" height="40" width="40" class="imgclick">
                            </label>    
                        </td></tr>
                </table>
                </div>
                     </div>
                    </td>
                <td  rowspan="2">                   
                <div  style=" width:200px; height:500px "> 
                    <div id="dvdcontrols" class="displaynone">
                    <header style=" background-color:#428bca;color:black; text-align:center;
                    border:solid; border-color:#428bca ">DVD Controls&nbsp;
                    <span data-toggle="collapse" data-target="#dvdsubmenu" style="color:white" 
                    class="fa fa-angle-down trying" ></span>
                    </header>
                         <div id="dvdsubmenu" class="divcontrols" style=" border-color:#428bca">
                <table style="width:180px; height:400px">                 
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/poweroff.png" id="dvdpoweron" 
                                height="40" width="40" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/stop.png" id="dvdstop"
                                height="40" width="40" class="imgclick"/>
                        </td>
                    </tr>
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/play.png" id="playdvd"
                                height="40" width="40" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/pause.png" id="dvdpause"
                                height="40" width="40" class="imgclick" />
                        </td>
                            </tr>
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/backward.png" id="dvdback" 
                                height="40" width="40" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/forward.png" id="dvdforward" 
                                height="40" width="40" class="imgclick"/>
                        </td>
                            </tr>
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/pre.png" id="dvdpre" 
                                height="40" width="40" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/next.png" id="dvdnext"
                                height="40" width="40" class="imgclick"/>
                        </td>
                    </tr>
                    <tr>                       
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/exit.png" id="dvdexit" 
                                height="40" width="40" class="imgclick" />
                        </td>
                  </tr>
                </table>
            </div>
                    </div>
                    <div id="bluraydvd" class="displaynone">
                        <header style=" background-color:#428bca;color:black; text-align:center;
                        border:solid; border-color:#428bca "> Blu-ray DVD Controls&nbsp;
                        <span data-toggle="collapse" data-target="#bludvdsubmenu" style="color:white" 
                        class="fa fa-angle-down trying" ></span>
                        </header>
                    <div id="bludvdsubmenu" class="divcontrols" style=" border-color:#428bca">
                <table style="width:180px; height:400px">                 
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/poweroff.png" id="bludvdpoweron"
                                height="40" width="40" class="imgclick" />
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/stop.png" id="bludvdstop" 
                                height="40" width="40" class="imgclick"/>
                        </td>
                            </tr>
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/play.png" id="bluplaydvd" 
                                height="40" width="40" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/pause.png" id="bludvdpause"
                                height="40" width="40" class="imgclick"/>
                        </td>
                            </tr>
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/backward.png" id="bludvdback" 
                                height="40" width="40" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/forward.png" id="bludvdforward"
                                height="40" width="40" class="imgclick"/>
                        </td>
                            </tr>
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/pre.png" id="bludvdpre" 
                                height="40" width="40" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/next.png" id="bludvdnext"
                                height="40" width="40" class="imgclick"/>
                        </td>
                    </tr>
                    <tr>                       
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/exit.png" id="bludvdexit"
                                height="40" width="40" class="imgclick"/>
                        </td>
                            </tr>
                </table>
                </div>
                    </div>
                    <div id="Camera" class="displaynone">
                        <header style=" background-color:#428bca;color:black; text-align:center;
                        border:solid; border-color:#428bca "> Camera Sub-Menu&nbsp;
                        <span data-toggle="collapse" data-target="#camerasubmenu" style="color:white" 
                        class="fa fa-angle-down trying" ></span></header>
                        <div id="camerasubmenu" class="divcontrols">
                            <table style="width:180px; height:400px">                 
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/submenu/cam/tcam.png" id="tcampoweroff"
                                            height="40" width="40" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/scam.png" id="scampoweroff"
                                            height="40" width="40" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/rotate.png" height="40"
                                            width="40" id="rotate" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/wb.png" height="40" 
                                            width="40" id="wb" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/plus.png" height="40"
                                            width="40" id="plus" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/minus.png" height="40"
                                            width="40" id="minus" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/save.png" height="40"
                                            width="40" id="savecam" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/change.png" height="40"
                                            width="40" id="changecam" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/stop.png" height="40"
                                            width="40" id="stopcam" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/novideo.png" height="40"
                                            width="40" id="novideo" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/nocam.png" height="40"
                                            width="40" id="nocam" class="imgclick"/>
                                    </td>
                                    <td></td>
                                </tr>
                          </table>
                        </div>
                    </div>
                    <div id="tvcontrols" class="displaynone">
                        <header style=" background-color:#428bca;color:black; text-align:center;
                        border:solid; border-color:#428bca "> TV Controls&nbsp;
                        <span data-toggle="collapse" data-target="#tvsubmenu" style="color:white" 
                        class="fa fa-angle-down trying" ></span></header>
                        <div id="tvsubmenu" class="divcontrols" >
                            <table style="width:180px; height:250px">                 
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/submenu/tv/off.png" height="40" 
                                            width="40" id="tvoff" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/tv/input.png" height="40" 
                                            width="40" id="inputtv" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/tv/ok.png" height="40"
                                            width="40" id="oktv" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/tv/option.png" height="40"
                                            width="40" id="optiontv" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/tv/plus.png" height="40"
                                            width="40" id="plustv" class="imgclick"/>
                                    </td>
                                     <td class="text-center">
                                         <img src="Images/submenu/tv/minus.png" height="40"
                                             width="40" id="minustv" class="imgclick"/>
                                     </td>   
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/tv/exit.png" height="40" 
                                            width="40" id="exittv" class="imgclick"/>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="recordercontrol" class="displaynone">
                         <header style=" background-color:#428bca;color:black; text-align:center;
                        border:solid; border-color:#428bca "> Recorder Control&nbsp;
                        <span data-toggle="collapse" data-target="#recordermenu" style="color:white" 
                        class="fa fa-angle-down trying" ></span></header>
                         <div id="recordermenu" class="divcontrols" >
                            <table style="width:180px; height:250px">                 
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/submenu/recorder/poweron.png" height="40"
                                            width="40" id="recpoweron" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/recorder/poweroff.png" height="40"
                                            width="40" id="recpoweroff" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/submenu/recorder/play.png" height="40"
                                            width="40" id="recplay" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/recorder/stop.png" height="40"
                                            width="40" id="recstop" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/submenu/recorder/change.png" height="40"
                                            width="40" id="recchange" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/recorder/save.png" height="40"
                                            width="40" id="recsave" class="imgclick"/>
                                    </td>
                                </tr>
                            </table>
                        </div>
                     </div>   
                </div>
                </td>
            </tr>
            <tr>
                <td>
                <div style="height:250px;width:250px; border:none">             
                <header style=" background-color:#dff0d8;color:black; text-align:center;
                        border:solid; border-color:#dff0d8 ">Screen & curtain&nbsp;
                    <span data-toggle="collapse" data-target="#ScreenCurtain" 
                        style="color:#3c763d"class="fa fa-angle-down trying" ></span>
                </header>
                <div id="ScreenCurtain" class="divcontrols" style=" border-color:#3c763d">
                <table style="width:220px; height:180px;">                
                <tr>
                    <td  style=" font-size:small; text-align:center">
                        Digital Screen                        
                    </td>
                    <td style=" font-size:small; text-align:center">
                       Digital Curtain
                    </td>
                </tr>
                <tr>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/offimages/up.PNG" id="dsup" 
                                    height="40" width="40" class="imgclick"/></span>   
                    </td>
                    <td style="text-align:center">
                         <span>
                                <img src="Images/offimages/open.PNG" id="dcopen"
                                    height="40" width="40" class="imgclick"/></span>
                         </td>
                </tr>
                <tr>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/offimages/stopscreen.PNG" 
                                    id="dsstop" height="40" width="40" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/stopcurtain.PNG" 
                                    id="dcstop" height="40" width="40" class="imgclick"/></span>
                        </td>
                     </tr>
                <tr >
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/screendown.PNG" id="dsdown" 
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/offimages/curtainclose.PNG" id="dcclose"
                                    height="40" width="40" class="imgclick"/></span>
                   </td>
                </tr>                
            </table>
                </div>
                    </div>
                </td>
                <td>
                <div style="height:250px;width:250px;  border:none">            
                <header style=" background-color:#d9edf7;color:black; text-align:center;
                    border:solid; border-color:#d9edf7 ">Microphone Control&nbsp;
                    <span class="fa fa-angle-down trying" data-toggle="collapse" 
                        data-target="#Microphone" style="color:#31708f;"></span>
                </header>                    
                <div id="Microphone" class="divcontrols" style=" border-color: #31708f;">
                    <table style="width:250px; height:180px;">
                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="Label3" runat="server" Text="Wired Mic" Font-Size="Small"  ></asp:Label>
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="Label4" runat="server" Text="Wireless Mic" Font-Size="Small" ></asp:Label>
                    </td>
                    </tr>
                 <tr >
                    <td style="text-align:center" >
                        <span>
                                <img src="Images/offimages/wiredvolplus.PNG" id="wiredvolplus"
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/wirelessvolplus.PNG" id="wirelessvolplus"
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                </tr>
                 <tr>                  
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/wiredvolminus.PNG" id="wiredvolminus"
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/wirelessvolminus.PNG" id="wirelessvolminus"
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                     </tr>
                       <tr >
                    <td style="text-align:center" class="auto-style1">
                        <span>
                                <img src="Images/offimages/wiredmute.PNG" id="wiredmute"
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                     <td style="text-align:center" class="auto-style1">
                         <span>
                                <img src="Images/offimages/wirelessmute.PNG" id="wirelessmute"
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                </tr>                
            </table>
                    </div>
                    </div>
                </td>
                <td>
                <div  style="height:250px ;width:180px; border:none ">             
                <header style=" background-color:#fcf8e3;color:black ; border:solid;
                        border-color:#fcf8e3; text-align:center "> Volume&nbsp;
                     <span data-toggle="collapse" data-target="#volume" style="color:#916d3b" 
                         class="fa fa-angle-down trying" ></span>
                </header>
                <div id="volume" class="divcontrols" style=" border-color:#916d3b">
                     <table style="width:160px; height:180px;">               
                <tr>
                    <td style="text-align:center" >
                        <span>
                                <img src="Images/offimages/volplus.PNG" id="volplus"
                                    height="40" width="40" class="imgclick"/></span>
                          </td>
                    </tr>
                 <tr>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/volminus.PNG" id="volminus"
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                         </tr>
                 <tr>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/mute.PNG" id="mute"
                                    height="40" width="40" class="imgclick"/></span>                        
                        </td>
                </tr>
            </table>
                    </div>                 
                    </div>
                </td>
            </tr>
        </table>           
    </div>
     </div>       --%>
    <%--<div id="control" class="modal">
        <div class="modal-content">
            <header class="row" style="position: center;">
                <span onclick="closexx();"
                    class="w3-button w3-display-topright">&times;</span>
            </header>
            
            <div class="row">
                <iframe id="Iframe1" style="background-color: #1e1e36" src="~/controlRemote.aspx" height="700" width="100%" runat="server" frameborder="0"></iframe>
            </div>
        </div>
    </div>--%>
</asp:Content>