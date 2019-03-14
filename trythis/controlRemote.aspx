<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="controlRemote.aspx.cs" Inherits="WebCresij.controlRemote" %>

<html>
<head>
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
        <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>    
        <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' > </script>
     <script src="Scripts/RemoteModal.js"></script>
    <style>
        input, select, textarea {
            max-width: 280px;
        }
     
        /*.imgclick {
            padding: 2px;
            -moz-box-shadow: 0px 0px 3px 3px #7ce;
            -webkit-box-shadow: 0px 0px 3px 3px #7ce;
            box-shadow: 0px 0px 3px 3px #7ce;
            border-radius: 15px;
        }*/

        .imgclick:hover {
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
        }

        .imgclick:active {
            -webkit-border-radius: 5px;
            -moz-border-radius: 5px;
            border-radius: 5px;
            -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            transform: translateY(1px);
        }

        [type=radio] + img {
            cursor: pointer;
        }
        /* CHECKED STYLES */
        [type=radio]:checked + img {
            border: 2px solid lightgreen;
            border-radius: 5px;
        }

        [type=radio] {
            position: absolute;
            opacity: 0;
            width: 0;
            height: 0;
        }

        .fieldSetControl {
            border-top: solid;
            width: 60%;
            border-width: 1px;
            border-top-color: #68afd0;
            
        }

        .shadowRow {
            -moz-box-shadow: 0 0 10px #000000;
            -webkit-box-shadow: 0 0 10px #000000;
            box-shadow: 0 0 10px #000000;
        }
        #control
        {
            background-color:#1e1e36; 
            height:500px;
            padding-bottom:50px;            
        }
        .displaynone{
        display:none;
}
.displayblock{
   display:inline-block;
   cursor:pointer;
   
}
    </style>
</head>
<body style=" overflow-y:hidden">
    <form runat="server">        
    <div id="control" >  
        
            <input id="sessionInputIP" type="hidden" value='<%= Session["DeviceIP"] %>' />
            <input id="sessionInput1" type="hidden" value='<%= Session["loc"] %>' />
            <input id="dev" type="hidden" value='<%=Session["devices"] %>' />
            <asp:TextBox Style="display: none" ID="ipAddressToSend" runat="server"></asp:TextBox>            
            <table class="container " >
                <tr>
                    <td style="text-align:center">
                        <div style="height: 250px; width: 250px; border: none">
                            <fieldset class="fieldSetControl" style="width: 80%;color:white;">
                                <legend align="center" style="width: auto;font-size:16px;"><span>System Control</span></legend>
                            </fieldset>
                            <div id="system" class="divcontrols">
                                <table style="height: 180px; width: 220px; border-color: #333333">
                                   
                                    <tr style="align-items: center; align-content: center;">
                                        <td colspan="3" style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_212.png" id="systempower"
                                                    height="60" width="60" class="imgclick" /></span>
                                        </td>
                                        <td colspan="3" style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_212.png" id="pcpower"
                                                    height="60" width="60" class="imgclick" /></span></td>

                                    </tr>
                                    <tr>
                                        
                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_214.png" id="sysLock"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_236.png" id="classlock"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_262.png" id="podiumLock"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>                                
                        </div>
                    </td>
                    <td style="text-align:center">
                        <div style="height: 250px; width: 250px; border: none">
                            <fieldset class="fieldSetControl" style="width: 80%;color:white;">
                                <legend align="center" style="width: auto;font-size:16px;color:white;">
                                    <span>Projector Control</span></legend></fieldset>
                            <div id="Projector" class="divcontrols" style="border-color: #3c763d">
                                <table style="height: 180px; width: 230px">
                                    <tr style="width: 220px">
                                        <td style="text-align: center">
                                            <span>
                                                 <img src="Images/详细页图标/images/图标_184.png" id="projectorOn"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>                                                
                                                <img src="Images/详细页图标/images/图标_186.png" id="projectorOff"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>                                                
                                                <img src="Images/详细页图标/images/图标_188.png"  id="projSleep"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                    </tr>
                                    <tr style="width: 220px">
                                        <td style="text-align: center">
                                            <a href="#" style="color: white;">
                                                <img src="Images/详细页图标/images/图标_138.png" id="hdmi" height="50"
                                                    width="50" class="imgclick" /></a>
                                        </td>
                                        <td style="text-align: center">
                                            <span>                                               
                                                <img src="Images/详细页图标/images/图标_164.png" id="projVideo"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                         <td style="text-align: center">
                                            <span>                                                
                                                <img src="Images/详细页图标/images/图标_190.png" id="vga"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div style="height: 250px; width: 130px; border: none">
                            <fieldset class="fieldSetControl" style="width: 80%;color:white;">
                                <legend align="center" style="width: auto;font-size:16px;">
                                    <span>Light Control</span></legend></fieldset>
                            <div id="light" class="divcontrols" style="border-color: #31708f;">
                                <table style="width: 140px; height: 180px;">

                                    <tr style="width: 100px;">
                                        <td style="text-align: center">
                                            <span>
                                                
                                                <img src="Images/详细页图标/images/图标_112.png" id="light1"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_112.png" id="light2"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_112.png" id="light3"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                    </tr>
                                    </table>
                            </div>
                        </div>
                    </td>
                    <td rowspan="2">
                        <div style="width: 200px; height: 500px">
                           <fieldset class="fieldSetControl" style="width: 80%;color:white;">
                                <legend align="center" style="width: auto;font-size:16px;">
                                    <span>Media Signal</span></legend></fieldset>
                            <div id="media" class="divcontrols" style="border-color: #916d3b">
                                <table style="width: 160px; height:400px; color: #202838">
                                    <tr style="width: 180px;">
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="1" name="test" id="desktop" 
                                                    data-target=".displaynone" checked />
                                                <img src="Images/详细页图标/images/图标_158.png" height="50" width="50" class="imgclick">
                                            </label></td>
                                    
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="2" name="test" id="laptop"
                                                    data-target=".displaynone" checked>
                                                <img src="Images/详细页图标/images/图标_160.png" height="50" width="50" class="imgclick">
                                            </label></td>
                                    </tr>
                                   
                                    <tr style="width: 180px;">
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="3" name="test" id="platform" 
                                                    data-target=".displaynone" checked>
                                                <img src="Images/详细页图标/images/图标_194.png" height="50" width="50" class="imgclick">
                                            </label></td>
                                        
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="4" name="test" 
                                                    id="digitalEquipment" data-target=".displaynone" checked>
                                                <img src="Images/详细页图标/images/图标_194.png" height="50" 
                                                    width="50" class="imgclick">
                                            </label>
                                        </td>
                                    </tr>
                                    
                                    <tr style="width: 180px;">
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="5" name="test" id="dvd" 
                                                    data-target="#dvdcontrols" checked>
                                                <img src="Images/详细页图标/images/图标_246.png" height="50" width="50" class="imgclick">
                                            </label>
                                        </td>
                                        
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="6" name="test" id="bluray" 
                                                    data-target="#bluraydvd" checked>
                                                <img src="Images/详细页图标/images/图标_272.png" height="50" 
                                                    width="50" class="imgclick">
                                            </label>
                                        </td>
                                    </tr>
                                    
                                    <tr style="width: 180px;">
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="7" name="test" id="tv" 
                                                    data-target="#tvcontrols" >
                                                <img src="Images/详细页图标/images/图标_298.png" height="50" width="50" class="imgclick">
                                            </label>
                                        </td>
                                        
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="8" name="test" id="camera" 
                                                    data-target="#Camera" >
                                                <img src="Images/详细页图标/images/图标_220.png" height="50" 
                                                    width="50" class="imgclick">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr style="width: 180px;">
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="9" name="test" id="recorder" 
                                                    data-target="#recordercontrol" checked>
                                                <img src="Images/详细页图标/images/图标_324.png" height="50" 
                                                    width="50" class="imgclick">
                                            </label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td rowspan="2">
                        <div style="width: 200px; height: 500px">
                            <div id="dvdcontrols" class="displaynone">
                                <header style="background-color: #428bca; color: black; text-align: center;
                                    border: solid; border-color: #428bca">
                                    DVD Controls&nbsp;
                                    <span data-toggle="collapse" data-target="#dvdsubmenu" style="color: white"
                                        class="fa fa-angle-down trying"></span>
                                </header>
                                <div id="dvdsubmenu" class="divcontrols" style="border-color: #428bca">
                                    <table style="width: 180px; height: 400px">
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/poweroff.png" id="dvdpoweron"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/stop.png" id="dvdstop"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/play.png" id="playdvd"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/pause.png" id="dvdpause"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/backward.png" id="dvdback"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/forward.png" id="dvdforward"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/pre.png" id="dvdpre"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/next.png" id="dvdnext"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/exit.png" id="dvdexit"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="bluraydvd" class="displaynone">
                                <header style="background-color: #428bca; color: black; text-align: center; 
                                    border: solid; border-color: #428bca">
                                    Blu-ray DVD Controls&nbsp;
                                    <span data-toggle="collapse" data-target="#bludvdsubmenu" style="color: white"
                                        class="fa fa-angle-down trying"></span>
                                </header>
                                <div id="bludvdsubmenu" class="divcontrols" style="border-color: #428bca">
                                    <table style="width: 180px; height: 400px">
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/poweroff.png" id="bludvdpoweron"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/stop.png" id="bludvdstop"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/play.png" id="bluplaydvd"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/pause.png" id="bludvdpause"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/backward.png" id="bludvdback"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/forward.png" id="bludvdforward"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/pre.png" id="bludvdpre"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/next.png" id="bludvdnext"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <img src="Images/submenu/dvd/exit.png" id="bludvdexit"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="Camera" class="displaynone">
                                <header style="background-color: #428bca; color: black; text-align: center; 
                                    border: solid; border-color: #428bca">
                                    Camera Sub-Menu&nbsp;
                                    <span data-toggle="collapse" data-target="#camerasubmenu" style="color: white"
                                        class="fa fa-angle-down trying"></span>
                                </header>
                                <div id="camerasubmenu" class="divcontrols">
                                    <table style="width: 180px; height: 400px">
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/tcam.png" id="tcampoweroff"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/scam.png" id="scampoweroff"
                                                    height="40" width="40" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/rotate.png" height="40"
                                                    width="40" id="rotate" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/wb.png" height="40"
                                                    width="40" id="wb" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/plus.png" height="40"
                                                    width="40" id="plus" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/minus.png" height="40"
                                                    width="40" id="minus" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/save.png" height="40"
                                                    width="40" id="savecam" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/change.png" height="40"
                                                    width="40" id="changecam" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/stop.png" height="40"
                                                    width="40" id="stopcam" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/novideo.png" height="40"
                                                    width="40" id="novideo" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/cam/nocam.png" height="40"
                                                    width="40" id="nocam" class="imgclick" />
                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="tvcontrols" class="displaynone">
                                <header style="background-color: #428bca; color: black; text-align: center;
                                    border: solid; border-color: #428bca">
                                    TV Controls&nbsp;
                                    <span data-toggle="collapse" data-target="#tvsubmenu" style="color: white"
                                        class="fa fa-angle-down trying"></span>
                                </header>
                                <div id="tvsubmenu" class="divcontrols">
                                    <table style="width: 180px; height: 250px">
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/tv/off.png" height="40"
                                                    width="40" id="tvoff" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/tv/input.png" height="40"
                                                    width="40" id="inputtv" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/tv/ok.png" height="40"
                                                    width="40" id="oktv" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/tv/option.png" height="40"
                                                    width="40" id="optiontv" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/tv/plus.png" height="40"
                                                    width="40" id="plustv" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/tv/minus.png" height="40"
                                                    width="40" id="minustv" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/tv/exit.png" height="40"
                                                    width="40" id="exittv" class="imgclick" />
                                            </td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div id="recordercontrol" class="displaynone">
                                <header style="background-color: #428bca; color: black; text-align: center; 
                                    border: solid; border-color: #428bca">
                                    Recorder Control&nbsp;
                                    <span data-toggle="collapse" data-target="#recordermenu" style="color: white"
                                        class="fa fa-angle-down trying"></span>
                                </header>
                                <div id="recordermenu" class="divcontrols">
                                    <table style="width: 180px; height: 250px">
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/recorder/poweron.png" height="40"
                                                    width="40" id="recpoweron" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/recorder/poweroff.png" height="40"
                                                    width="40" id="recpoweroff" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/recorder/play.png" height="40"
                                                    width="40" id="recplay" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/recorder/stop.png" height="40"
                                                    width="40" id="recstop" class="imgclick" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-center">
                                                <img src="Images/submenu/recorder/change.png" height="40"
                                                    width="40" id="recchange" class="imgclick" />
                                            </td>
                                            <td class="text-center">
                                                <img src="Images/submenu/recorder/save.png" height="40"
                                                    width="40" id="recsave" class="imgclick" />
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
                        <div style="height: 250px; width: 250px; border: none">
                            <fieldset class="fieldSetControl" style="width:80%;color:white;">
                                <legend align="center" style="width:auto;font-size:16px;">
                                    <span>Screen & Curtain</span></legend></fieldset>
                            <div id="ScreenCurtain" class="divcontrols" style="border-color:#3c763d">
                                <table style="width:220px; height:180px;">                                   
                                    <tr>
                                        <td style="text-align:center">
                                            <span>
                                                
                                                <img src="Images/详细页图标/images/图标_132.png" id="dsup"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_134.png" id="dsdown"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                         <td style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_136.png"
                                                    id="dsstop" height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                       <td style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_106.png" id="dcopen"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_108.png" id="dcclose"
                                                    height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/images/图标_110.png"
                                                    id="dcstop" height="50" width="50" class="imgclick" /></span>
                                        </td>
                                        
                                    </tr>
                                   
                                </table>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div style="height: 250px; width: 250px; border: none">
                           <fieldset class="fieldSetControl" style="width: 80%;color:white;">
                                <legend align="center" style="width: auto;font-size:16px;">
                                    <span>Sound Control</span></legend></fieldset>
                            <div id="Microphone" class="divcontrols" style="border-color: #31708f;">
                                <table style="width: 250px; height: 180px;">                                   
                                    <tr>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/详细页图标/全部按钮/控制全页面-默认状态/总音量.png"
                                                    height="40" width="40"/>                                                
                                                <img src="Images/icons/images/背景图-（03_63.png" id="vol"
                                                    height="40" width="80%" class="imgclick" /></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <span>
                                                
                                               <img src="Images/icons/images/话筒音量.png" 
                                                   height="40" width="40"/>
                                                <img src="Images/icons/images/背景图-（03_63.png" id="wiredlessvol"
                                                    height="40" width="80%" class="imgclick" /></span>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td style="text-align: center" class="auto-style1">
                                            <span>
                                                <img src="Images/详细页图标/全部按钮/控制全页面-默认状态/有线麦音量.png" 
                                                    height="40" width="40"/>
                                                <img src="Images/icons/images/背景图-（03_63.png" id="wiredvol"
                                                    height="40" width="80%" class="imgclick" /></span>
                                        </td>                                        
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                  
                </tr>
            </table>        
    </div>
        </form>
        </body>
    <script type="text/javascript">       
        window.onclick = function (event) {
            if (event.target == modal) {
                document.getElementById("control").style.display = "none";
            }
        }
    </script>

</html>
