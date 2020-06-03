<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controlsCam.aspx.cs" Inherits="WebCresij.controlsCam" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="lib/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/fontawesome/fontawesome.min.js"></script>
     <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>    
        <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' > </script>
    <script src="Scripts/remotekeys.js"></script>
    <title></title>
    <style>
    html {
        box-sizing: border-box;
    }
    @media  (max-width: 700px){
        div{
        width:100%;
        }
    }
    *, *::before, *::after {
        box-sizing: inherit;
    }
        .wrapper > div {
            border: black;
            border-radius: 1px;
            background-color: #1d2129;
            padding: 1em;
            border-radius:10px 10px;
            color: white;
            justify-content:center;
            -moz-box-shadow:    0px 0px 5px 5px #000;
            -webkit-box-shadow: 0px 0px 5px 5px #000;
            box-shadow:         0px 0px 5px 5px #000;
            border-width:0 20px 20px 0;
        }
        .wrapper {
            display: grid;
            display:  -ms-grid;
            -ms-grid-columns: repeat(1fr 20px)[14];
            width:70%;
            grid-template-columns: repeat(14, 1fr);
            grid-gap: 13px;
            grid-auto-rows: minmax(100px, auto);           
            background-color:#262d3c;
            -moz-box-shadow:    inset 0 0 10px #000000;
            -webkit-box-shadow: inset 0 0 10px #000000;
            box-shadow:         inset 0 0 10px #000000;
            padding: 1em 1em 1em 1em;
        }
        .one {
            grid-column: 1 /span 2;                                                                                 
            grid-row: 1/ span 6;
            -ms-grid-column:1 ;
            -ms-grid-column-span:2;
            -ms-grid-row: 1;
            -ms-grid-row-span:6;   
             border-width: 0 20px 20px 0;
        }
        .two { 
            grid-column: 3/ span 2 ;
            grid-row: 1/ span 4;
            -ms-grid-column:3 ;
            -ms-grid-row: 1;
            -ms-grid-column-span:2;
            -ms-grid-row-span:4;
             border-width: 0 20px 20px 0;
        }
        .three {
            grid-column: 5/ span 7;
            grid-row: 1/ span 4;
            -ms-grid-column: 5;
            -ms-grid-row: 1;
            -ms-grid-column-span:7;
            -ms-grid-row-span:4;
             border-width: 0 20px 20px 0;
        }
        .four {
            grid-column: 12 / span 3;
            grid-row: 1/ span 4;
            -ms-grid-column: 12 ;
            -ms-grid-row: 1;
            -ms-grid-column-span:3;
            -ms-grid-row-span:4;
             border-width: 0 20px 20px 0;
        }
        .five {
            grid-column: 3/ span 6;
            grid-row:5/ span 2;
            -ms-grid-column: 3;
            -ms-grid-row: 5;
            -ms-grid-column-span:6;
            -ms-grid-row-span:2;
             border-width: 0 20px 20px 0;
        }
        .six {
            grid-column: 9/ span 6;
            grid-row: 5/ span 2;
            -ms-grid-column: 9;
            -ms-grid-row: 5;
            -ms-grid-column-span:6;
            -ms-grid-row-span:2;
             border-width: 0 20px 20px 0;
        }
        .toggle{
            font-size:medium;
        }
        .divcontrols {
            width:100%;
            border: solid;   
            border-radius: 5px;
            border-color:white;
            padding:5px 2px 5px 2px;
        }        
        fieldset{
            border:1px solid white;
            cursor:pointer;
            padding:4px 5px 10px 5px;
        }
        [type=radio]{ 
            position: absolute;
            opacity: 0;
            width: 0;
            height: 0;
        }
/* IMAGE STYLES */

.imgclick{ 
    padding:2px;
    -moz-box-shadow:    0px 0px 3px 3px #7ce;
            -webkit-box-shadow: 0px 0px 3px 3px #7ce;
            box-shadow:         0px 0px 3px 3px #7ce;
            border-radius:100px;            
}
.imgclick:hover{
    -webkit-border-radius: 100px;
    -moz-border-radius: 100px;
    border-radius: 100px;
    -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
    -moz-box-shadow:    0px 0px 4px 4px rgba(119,204,238, 0.67);
    box-shadow:         0px 0px 4px 4px rgba(119,204,238, 0.67);
}
.imgclick:active{
    -webkit-border-radius: 100px;
    -moz-border-radius: 100px;
    border-radius: 100px;
   -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
    -moz-box-shadow:    0px 0px 4px 4px rgba(119,204,238, 0.67);
    box-shadow:         0px 0px 4px 4px rgba(119,204,238, 0.67);
    transform: translateY(1px);
}
[type=radio] + img {
  cursor: pointer;
}
/* CHECKED STYLES */
[type=radio]:checked + img {
  border: 2px solid lightgreen;
   border-radius: 100px;
}
.displaynone{
        display:none;
}
.displayblock{
   display:inline-block;
   cursor:pointer;
}
tr>td{
 padding-bottom:10px;   
}
h6{
    text-align:center
}
 </style>
</head>
<body>
    <form id="form1" runat="server"> 
        <div class="container-fluid" style="display:flex">
            <div class="wrapper" >
             <div class="one "><p>this is a test paragraph one</p></div>
             <div class="two "><p>this is a test paragraph two</p></div>
             <div class="three " style="-moz-box-shadow:inset 0 0 15px #000000;
                -webkit-box-shadow: inset 0 0 15px #000000;
                box-shadow:inset 0 0 15px #000000;" >
                 <p>this is a test paragraph three</p>
             </div>
             <div class="four" ><p>this is a test paragraph four</p></div>
             <div class="five "><p>this is a test paragraph five</p></div>
            <div class="six " id="accordion" >
               <fieldset >
                <legend align="center" style="width:auto">Remote Control</legend>
                <div class="row">
                    <div class="col-6"> 
                    <div id="myGroup" >
                    <div id="sysctrl" data-target="#system">
                        <h5><img src="Images/icons/pcwhite.png" height="25" width="25"/>&nbsp;System Control</h5>
                    </div>
                                  
                    <div id="projctrl" data-target="#Projector">
                        <h5><img src="Images/icons/project5.png" height="25" width="25" />&nbsp;Projector Controls</h5>
                    </div>
                   
                    <div id="lightctrl" data-target="#light">
                        <h5><img src="Images/icons/lightwhite.png" height="25" width="25"/>&nbsp;Light Control</h5>
                    </div>
                   
                    <div id="mediactrl" data-target="#media">
                        <h5><img src="Images/icons/deskwhite.png" height="25" width="25"/>&nbsp;Media Signal</h5>
                    </div>
                    
                     <div id="scrctrl" data-target="#ScreenCurtain">
                         <h5><img src="Images/icons/scwhite.png" height="25" width="25"/>&nbsp;Screen & curtain</h5>
                     </div>
                    
                     <div id="micCtrl" data-target="#Microphone">
                         <h5><img src="Images/icons/mic.png" height="25" width="25"/>&nbsp;Microphone Controls</h5>
                     </div>
                     
                     <div  id="volctrl" data-target="#volume">
                         <h5><img src="Images/icons/volsound.png" height="25" width="25"/>&nbsp;Volume Control</h5>
                     </div>
                     </div>
                    </div>
                    <div class="col-6">
                        <div id="media" class="displaynone">
                        <div class="divcontrols">
                            <h6>Media Signals</h6>
                        <table style="width:100%; height:auto">                 
                        <tr >
                            <td  style="text-align:center">
                            <label>
                            <input type="radio" value="1" name="test" id="desktop" data-target=".displaynone"/>
                            <img src="Images/icons/deskwhite.png" height="30" width="30" class="imgclick"/>
                            </label>
                            </td>
                            <td style="text-align:center">
                            <label>
                            <input type="radio" value="2" name="test" id="laptop" data-target=".displaynone"/>
                            <img src="Images/icons/lapwhite.png" height="30" width="30" class="imgclick"/>
                            </label>
                            </td>
                            <td style="text-align:center">
                            <label>
                            <input type="radio" value="3" name="test" id="platform" data-target=".displaynone" />
                            <img src="Images/icons/curtain1.png" height="30" width="30" class="imgclick"/>
                            </label></td>
                            <td style="text-align:center" >
                             <label>
                            <input type="radio" value="4" name="test" id="digitalEquipment" data-target=".displaynone"/>
                            <img src="Images/icons/scwhite.png" height="30" width="30" class="imgclick"/>
                            </label>
                            </td>
                            </tr>
                        <tr>
                        <td style="text-align:center" >
                            <label>
                            <input type="radio" value="5" name="test" id="dvd" data-target="#dvdsubmenu"/>
                            <img src="Images/icons/dvd1.png" height="30" width="30" class="imgclick" />
                            </label>
                        </td>
                        <td style="text-align:center">
                           <label>
                            <input type="radio" value="6" name="test" id="bluray" data-target="#bludvdsubmenu"/>
                            <img src="Images/icons/blu1.png" height="30" width="30" class="imgclick"/>
                            </label>
                       </td>
                        <td  style="text-align:center">
                            <label>
                            <input type="radio" value="7" name="test" id="tv" data-target="#tvsubmenu"/>
                            <img src="Images/icons/tvwhite.png" height="30" width="30" class="imgclick"/>
                            </label>
                        </td>
                        <td style="text-align:center">
                            <label>
                            <input type="radio" value="8" name="test" id="camera" data-target="#camerasubmenu"/>
                            <img src="Images/icons/camwhite.png" height="30" width="30" class="imgclick"/>
                            </label>    
                       </td>
                    </tr>
                    <tr>
                      <td style="text-align:center" >
                        <label>
                          <input type="radio" value="9" name="test" id="recorder"
                               data-target="#recordermenu" checked="checked"/>
                           <img src="Images/icons/vidwhite.png" height="30" width="30" class="imgclick"/>
                            </label>    
                        </td></tr>
                </table>
                        </div>
                       </div>
                        <div id="system" class="displaynone">
                        <div class="divcontrols"  >
                        <table style=" height:auto; width:100%" >
                            <tr style="font-size:small;text-align:center" > 
                                <td colspan="3" > System Power</td>
                                <td colspan="3" > Computer Power</td>
                            </tr>
                            <tr style="align-items:center; align-content:center;">
                                <td colspan="3" style="text-align:center">
                                    <span>
                                    <img src="Images/icons/switchwhite.png" id="systempower" 
                                    height="30" width="30" class="imgclick"/></span>
                                </td>
                                <td colspan="3" style="text-align:center">
                                    <span>
                                    <img src="Images/icons/pcwhite.png" id="pcpower" 
                                    height="30" width="30"  class="imgclick"/></span>
                                </td>                          
                            </tr>                               
                            <tr >
                                <td colspan="2" style="text-align:center">
                                    <span>
                                    <img src="Images/icons/unlockwhite.png"  id="syslock" 
                                    height="20" width="20" class="imgclick"/></span>                            
                                </td>                      
                                <td colspan="2" style="text-align:center;"  >
                                    <span>
                                    <img src="Images/icons/unlockwhite.png" id="podiumlock"
                                    height="20" width="20" class="imgclick"/></span>
                                </td>                       
                                <td colspan="2" style="text-align:center" >
                                    <span>
                                    <img src="Images/icons/unlockwhite.png"  id="classlock" 
                                    height="20" width="20" class="imgclick"/></span>
                                </td>
                            </tr>
                            <tr style="font-size:x-small" >
                                <td colspan="2" style="text-align:center">System lock</td>
                                <td colspan="2" style="text-align:center">Podium lock</td>
                                <td colspan="2" style="text-align:center">Class lock</td>
                            </tr>
                        </table> 
                    </div> 
                    </div> 
                        <div id="dvdsubmenu" class="displaynone" >
                            <div class="divcontrols">
                                <h6 style="color:white">DVD Controls</h6>
                        <table style="width:100%; height:100%">                 
                        <tr>
                        <td  style="text-align:center">
                            <img src="Images/icons/switchwhite.png"  id="dvdpoweron" 
                                height="30" width="30" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/icons/stopwhite.png" id="dvdstop"
                                height="30" width="30" class="imgclick"/>
                        </td>
                       <td  style="text-align:center">
                            <img src="Images/icons/playwhite.png"  id="playdvd"
                                height="30" width="30" class="imgclick"/>
                           </td>
                    </tr>
                    <tr>
                         
                        <td style="text-align:center">
                            <img src="Images/icons/pausewhite.png"  id="dvdpause"
                                height="30" width="30" class="imgclick" />
                        </td>
                       <td  style="text-align:center">
                            <img src="Images/icons/backwhite.png" id="dvdback" 
                                height="30" width="30" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/icons/forwardwhite.png" id="dvdforward" 
                                height="30" width="30" class="imgclick"/>
                        </td>
                        </tr>
                         <tr>
                        <td  style="text-align:center">
                            <img src="Images/icons/prewhite.png" id="dvdpre" 
                                height="30" width="30" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/icons/nextwhite.png" id="dvdnext"
                                height="30" width="30" class="imgclick"/>
                        </td>
                        <td style="text-align:center">
                            <img src="Images/icons/ejectwhite.png" id="dvdexit" 
                             height="30" width="30" class="imgclick" />
                       </td>
                    </tr>
                    
                        </table>
                            </div>
                        </div>
                        <div id="bludvdsubmenu" class="displaynone" >
                            <div class="divcontrols">
                                <h6 style="color:white">BluRay DVD Controls</h6>
                        <table style="width:100%; height:100%">                 
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/icons/switchwhite.png" id="bludvdpoweron"
                                height="30" width="30" class="imgclick" />
                           </td>
                        <td style="text-align:center">
                            <img src="Images/icons/stopwhite.png" id="bludvdstop" 
                                height="30" width="30" class="imgclick"/>
                        </td>
                        <td  style="text-align:center">
                            <img src="Images/icons/playwhite.png" id="bluplaydvd" 
                                height="30" width="30" class="imgclick"/>
                           </td>
                            </tr>
                    <tr>
                        <td style="text-align:center">
                            <img src="Images/icons/pausewhite.png" id="bludvdpause"
                                height="30" width="30" class="imgclick"/>
                        </td>
                        <td  style="text-align:center">
                            <img src="Images/icons/backwhite.png" id="bludvdback" 
                                height="30" width="30" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/icons/forwardwhite.png" id="bludvdforward"
                                height="30" width="30" class="imgclick"/>
                        </td>
                    </tr>
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/icons/prewhite.png" id="bludvdpre" 
                                height="30" width="30" class="imgclick"/>
                           </td>
                        <td style="text-align:center">
                            <img src="Images/icons/nextwhite.png" id="bludvdnext"
                                height="30" width="30" class="imgclick"/>
                        </td>
                        <td style="text-align:center">
                            <img src="Images/icons/ejectwhite.png" id="bludvdexit"
                                height="30" width="30" class="imgclick"/>
                        </td>
                    </tr>
                   </table>
                             </div>
                        </div>
                        <div id="camerasubmenu" class="displaynone">
                            <div class="divcontrols">
                                <h6 >Camera Controls</h6>
                                <table style="width:100%; height:100%">                 
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/icons/teachcamwhite.png" id="tcampoweroff"
                                            height="30" width="30" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/scam.png" id="scampoweroff"
                                            height="30" width="30" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/rotatewhite.png" height="30"
                                            width="30" id="rotate" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/wb.png" height="30" 
                                            width="30" id="wb" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/zoominwhite.png" height="30"
                                            width="30" id="plus" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/zoomoutwhite.png" height="30"
                                            width="30" id="minus" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/icons/savewhite.png" height="30"
                                            width="30" id="savecam" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/rolwhite.png" height="30"
                                            width="30" id="changecam" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/stop.png" height="30"
                                            width="30" id="stopcam" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/submenu/cam/novideo.png" height="30"
                                            width="30" id="novideo" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/nocamwhite.png" height="30"
                                            width="30" id="nocam" class="imgclick"/>
                                    </td>
                                </tr>
                              </table>
                            </div>
                        </div>
                        <div id="tvsubmenu" class="displaynone">
                            <div  class="divcontrols" >
                                <h6>TV Controls</h6>
                            <table style="width:100%; height:100%">                 
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/icons/tvbtnwhite.png" height="30" 
                                            width="30" id="tvoff" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/tvinwhite.png" height="30" 
                                            width="30" id="inputtv" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/icons/okwhite.png" height="30"
                                            width="30" id="oktv" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/menuwhite.png" height="30"
                                            width="30" id="optiontv" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/icons/tvpluswhite.png" height="30"
                                            width="30" id="plustv" class="imgclick"/>
                                    </td>
                                     <td class="text-center">
                                         <img src="Images/icons/tvminwhite.png" height="30"
                                             width="30" id="minustv" class="imgclick"/>
                                     </td>   
                                </tr>
                                <tr>
                                    <td class="text-center">
                                        <img src="Images/icons/exitwhite.png" height="30" 
                                            width="30" id="exittv" class="imgclick"/>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        </div>
                        <div id="recordermenu" class="displaynone">
                            <div  class="divcontrols" >
                                <h6>Recorder Controls</h6>
                                <table style="width:100%; height:100%">                 
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/icons/tvbtnwhite.png" height="30"
                                            width="30" id="recpoweron" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/submenu/recorder/poweroff.png" height="30"
                                            width="30" id="recpoweroff" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/icons/recplaywhite.png" height="30"
                                            width="30" id="recplay" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/recstopwhite.png" height="30"
                                            width="30" id="recstop" class="imgclick"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td  class="text-center">
                                        <img src="Images/icons/rolwhite.png" height="30"
                                            width="30" id="recchange" class="imgclick"/>
                                    </td>
                                    <td class="text-center">
                                        <img src="Images/icons/savewhite.png" height="30"
                                            width="30" id="recsave" class="imgclick"/>
                                    </td>
                                </tr>
                            </table>
                            </div>
                        </div>
                        <div id="volume" class="displaynone">
                         <div class="divcontrols">
                             <h6>Volume Controls</h6>
                      <table style="width:100%; height:auto;">               
                    <tr>
                        <td style="text-align:center" >
                            <span><img src="Images/icons/volpluswhite.png" id="volplus"
                                    height="30" width="30" class="imgclick"/></span>
                        </td>
                        <td style="text-align:center">
                            <span><img src="Images/icons/volminuswhite.png" id="volminus"
                                    height="30" width="30" class="imgclick"/></span>
                       </td>
                        <td style="text-align:center">
                            <span><img src="Images/icons/mutewhite.png" id="mute"
                                    height="30" width="30" class="imgclick"/></span>                        
                        </td>
                    </tr>
                    </table>
                    </div>
                         </div>
                        <div id="light" class="displaynone">
                    <div class="divcontrols" >
                        <h6>Light Control</h6>
                       <table style=" height:auto; width:100%">
                         <tr style="text-align:center">
                            <td >
                                <span>
                                <img src="Images/icons/lightwhite.png" id="light1"
                                    height="30" width="30" class="imgclick"/></span>
                            </td>
                             <td >
                                <span>
                                <img src="Images/icons/lightwhite.png" id="light2" 
                                    height="30" width="30" class="imgclick"/></span>
                             </td>
                             <td >
                                <span>
                                <img src="Images/icons/lightwhite.png" id="light3" 
                                    height="30" width="30" class="imgclick"/></span>
                            </td>
                        </tr >
                           <tr style="text-align:center;font-size:x-small">
                               <td>Light 1</td>
                               <td>Light 2</td>
                               <td>Light 3</td>
                           </tr>
                       </table>
                    </div>
                </div>
                        <div id="Projector" class="displaynone">
                     <div class="divcontrols" >
                         <h6>Projector Controls</h6>
                     <table style=" height:auto; width:100%">                  
                        <tr >
                        <td style="text-align:center">
                             <span>
                                <img src="Images/icons/project5.png" id="projectorOn" 
                                    height="30" width="30" class="imgclick"/></span>                
                        </td>
                            <td style="text-align:center">
                            <span>
                                <img src="Images/icons/project5.png" id="projectorOff" 
                                    height="30" width="30" class="imgclick"/></span>                            
                        </td>
                            <td style="text-align:center">
                            <span>
                                <img src="Images/icons/project5.png" id="projSleep"
                                    height="30" width="30" class="imgclick"/></span>
                            </td>
                        
                        </tr>
                         
                        <tr >
                        <td style="text-align:center">
                            <span>
                                <img src="Images/icons/hdmiwhite.png" id="hdmi" height="30" 
                                    width="30" class="imgclick"/></span>                            
                        </td>
                        <td style="text-align:center">
                            <span>
                                <img src="Images/icons/videowhite.png" id="projVideo"
                                    height="30" width="30" class="imgclick"/></span>
                           </td>
                            <td style="text-align:center">
                            <span>
                                <img src="Images/icons/vgawhite.png" id="vga" 
                                    height="30" width="30" class="imgclick"/></span>
                             </td>
                        </tr>
                        </table>
                     </div>
                </div>
                        <div id="ScreenCurtain" class="displaynone">
                        <div class="divcontrols" >
                            <h6>Screen & curtain Controls</h6>
                            <table style="width:100%; height:auto;">                
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
                                <img src="Images/icons/scupwhite.png" id="dsup" 
                                    height="30" width="30" class="imgclick"/></span>   
                    </td>
                    <td style="text-align:center">
                         <span>
                                <img src="Images/icons/curtainOpenWhite.png" id="dcopen"
                                    height="30" width="30" class="imgclick"/></span>
                         </td>
                </tr>
                <tr>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/icons/scstopwhite.PNG" 
                                    id="dsstop" height="30" width="30" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/icons/curtainStopwhite.PNG" 
                                    id="dcstop" height="30" width="30" class="imgclick"/></span>
                        </td>
                     </tr>
                <tr >
                    <td style="text-align:center">
                        <span>
                                <img src="Images/icons/scdownwhite.PNG" id="dsdown" 
                                    height="30" width="30" class="imgclick"/></span>
                       </td>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/icons/curtainCloseWhite.PNG" id="dcclose"
                                    height="30" width="30" class="imgclick"/></span>
                   </td>
                </tr>                
            </table>
                        </div>
                     </div>
                        <div id="Microphone" class="displaynone">
                          <div class="divcontrols">
                              <h6>Microphone Controls</h6>
                    <table style="width:100%; height:auto;">
                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="Label3" runat="server" Text="Wired Mic" Font-Size="x-Small"  ></asp:Label>
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="Label4" runat="server" Text="Wireless Mic" Font-Size="x-Small" ></asp:Label>
                    </td>
                  </tr>
                 <tr >
                    <td style="text-align:center" >
                        <span>
                                <img src="Images/icons/wmicpluswhite.png" id="wiredvolplus"
                                    height="30" width="30" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/icons/micpluswhite.png" id="wirelessvolplus"
                                    height="30" width="30" class="imgclick"/></span>
                       </td>
                </tr>
                 <tr>                  
                    <td style="text-align:center">
                        <span>
                                <img src="Images/icons/wmicminwhite.png" id="wiredvolminus"
                                    height="30" width="30" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/icons/micminuswhite.png" id="wirelessvolminus"
                                    height="30" width="30" class="imgclick"/></span>
                        </td>
                     </tr>
                       <tr >
                    <td style="text-align:center" class="auto-style1">
                        <span>
                                <img src="Images/icons/wmicmutewhite.png" id="wiredmute"
                                    height="30" width="30" class="imgclick"/></span>
                        </td>
                     <td style="text-align:center" class="auto-style1">
                         <span>
                                <img src="Images/icons/micmutewhite.png" id="wirelessmute"
                                    height="30" width="30" class="imgclick"/></span>
                       </td>
                </tr>                
            </table>
                    </div>
                     </div>
                    </div>
                </div>
               </fieldset>
            </div>
            </div>
        </div>        
    </form>
</body>    
</html>
