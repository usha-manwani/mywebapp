<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="WebCresij.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
    <link href="assets/css/weather-icons-wind.min.css" rel="stylesheet" />
    <link href="assets/css/weather-icons.min.css" rel="stylesheet" />
    <style>
        /*.imgclick {
            padding: 2px;
            -moz-box-shadow: 0px 0px 3px 3px #7ce;
            -webkit-box-shadow: 0px 0px 3px 3px #7ce;
            box-shadow: 0px 0px 3px 3px #7ce;
            border-radius: 15px;
        }*/
        .imgsize {
            height: 60px;
            width: 60px;
        }

        .imgclick:hover {
            -webkit-border-radius: 15px;
            -moz-border-radius: 15px;
            border-radius: 15px;
            -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
        }

        .imgclick:active {
            -webkit-border-radius: 15px;
            -moz-border-radius: 15px;
            border-radius: 15px;
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
            border-radius: 15px;
        }

        [type=radio] {
            position: absolute;
            opacity: 0;
            width: 0;
            height: 0;
        }

        .fieldSetControl {
            border-top: solid;
            width: 100%;
            border-width: 1px;
            border-top-color: #4ecdc4;
            margin-left: 5px;
            color: white;
        }

        .shadowRow {
            -moz-box-shadow: 0 0 10px #000000;
            -webkit-box-shadow: 0 0 10px #000000;
            box-shadow: 0 0 10px #000000;
        }

        .modal {
            display: none; /* Hidden by default */
            position: fixed center; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 80px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow-y: no-display;
            /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.5); /* Black w/ opacity */
        }

        .modal-content {
            background-color: #1e1e36;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 70%;
            height: 90%;
        }

        .blueDiv {
            height: 25%;
            width: 90%;
            border-bottom: 10px solid #1e1e36;
            background-color: #4182cf;
            text-align: center;
            padding-top: 10%;
            padding-left: 5%;
        }

        body {
            overflow: hidden 
        }

        input[type=range] {
            -webkit-appearance: none;
            background-color: #1e1e36;
            width: 70%;
        }

            input[type=range]::-webkit-slider-runnable-track {
                width: 100%;
                height: 15px;
                border-radius: 10px;
                background: #1E1E36;
                border: 5px solid #545ca6;
            }

            input[type=range]::-webkit-slider-thumb {
                -webkit-appearance: none;
                border: none;
                height: 24px;
                width: 24px;
                border-radius: 50%;
                background: #545ca6;
                margin-top: -8px;
                border: 2px solid black;
            }

            input[type=range]:focus {
                outline: none;
            }

                input[type=range]:focus::-webkit-slider-runnable-track {
                    background: #1E1E36;
                }

            input[type=range]::-moz-range-track {
                width: 100%;
                height: 6px;
                border-radius: 10px;
                background: #1E1E36;
                border: 5px solid #545ca6;
            }

            input[type=range]::-moz-range-thumb {
                -webkit-appearance: none;
                border: none;
                height: 24px;
                width: 24px;
                border-radius: 50%;
                background: #545ca6;
                margin-top: -8px;
                border: 2px solid black;
            }

        input[type="range"]::-moz-range-progress {
            background-color: #82cfd0;
        }
        /*hide the outline behind the border*/
        input[type=range]:-moz-focusring {
            outline: 1px solid #545ca6;
            outline-offset: -1px;
        }

        input[type=range]::-ms-track {
            width: 100%;
            height: 15px;
            /*remove bg colour from the track, we'll use ms-fill-lower and ms-fill-upper instead */
            background: transparent;
            /*leave room for the larger thumb to overflow with a transparent border */
            border-color: transparent;
            border-width: 1px 0;
            /*remove default tick marks*/
            color: transparent;
        }

        input[type=range]::-ms-fill-lower {
            background: #545ca6;
            border-radius: 10px;
        }

        input[type=range]::-ms-fill-upper {
            background: #545ca6;
            border-radius: 10px;
        }

        input[type=range]::-ms-thumb {
            border: none;
            height: 16px;
            width: 16px;
            border-radius: 50%;
            background: #545ca6;
        }

        input[type=range]:focus::-ms-fill-lower {
            background: #545ca6;
        }

        input[type=range]:focus::-ms-fill-upper {
            background: #545ca6;
        }

        #interface {
            position: absolute;
            top: 268px;
            left: 190px;
            width: 220px;
            height: 50px;
            background: rgba(255, 255, 255, 0.75);
            border-radius: 5px;
        }

        ul.dropdown-menu li {
            xdisplay: inline;
            float:left;
            cwidth: 100%;
            xheight: 40px;
            padding: 0px;
            margin-bottom:-5px
        }

        ul.dropdown-menu {
            margin-top:-30px!important;
            width: 600px;
        }

        #doc{
            width:700px
        }        
        #dev{
            width:650px
        }        
        #queryMenu{
            width:250px
        }
        #allmenu{            
            width:600px
        }

        #muteimg:active{
            box-shadow: 0 2px #666;
            transform: translateY(1px);
        }
        #muteimg:hover{
            cursor:pointer;
        }
        .oncolor{
            -webkit-border-radius: 15px;
            -moz-border-radius: 15px;
            border-radius: 15px;
            -webkit-box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
            -moz-box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
            box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
        }
        @media only screen and (max-height: 600px), screen and (max-width: 1000px){
            body{
                overflow:scroll;
            }
        }
        
    </style>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script>
    <script src="Scripts/HomePageJS.js?v=11"></script>

    <div class="row" style="padding-left: 100px; max-width: 100%; min-width: 70%;">
        <div class="col-lg-8 col-md-8 col-sm-12">
            <div class="row">                
                <div class="row shadowRow" style="width: 100%; height: 460px">
                    <div class="col-lg-9 col-md-9 col-sm-12" >
                        <div style="-moz-box-shadow: inset 0 0 15px #000000; -webkit-box-shadow: inset 0 0 15px #000000;
                            box-shadow: inset 0 0 15px #000000; width:660px; height:380px; overflow:hidden ; " >
                            <%--<iframe src="src/Chimera.htm" height="390" width="640" frameborder="0" wmode="opaque"></iframe>--%>
                            <object id="plugin_inst_1" type="application/x-chimera-plugin" width="640" height="360" >
                                <param name="autoplay" value="true" />
                                <param name="src" id="src1" value="rtsp://admin:admin123@192.168.1.94:554/" />
                                <param name="network-caching" value="300" />
                                <param name="allow-fullscreen" value="true" />
                                
                               <%-- <param name="audio" value="100" />--%>
                            </object>
                           
                           
                           <div style="display:none">
    <textarea id="qml_edit" cols="80" rows="20">
import QtQuick 2.1
import QmlVlc 0.1

Rectangle {
    color: bgcolor
    VlcVideoSurface {
        id: videoOutput;
        source: vlcPlayer;
        anchors.fill: parent;
    }
    MouseArea {
        anchors.fill: videoOutput;
        onClicked: vlcPlayer.toggleFullscreen();                
    }
    Text {
        id: text;
        color: "white";
    }
    Component.onCompleted: {
        vlcPlayer.onMediaPlayerBuffering.connect( onBuffering )
    }
    function onBuffering( percents ) {
        if( percents < 100 )
            text.text = "Buffering: " + percents +"%";
        else
            text.text = "no signal";
    }
}
</textarea>
    <button onclick="plugin1().qml = getByID('qml_edit').value; getByID('qml_error').innerHTML = plugin1().qmlError;">load qml</button> <br />
    <span id="qml_error" style="color: red;" />
</div>
                        </div>
                        
                        <span class="btn btn-outline-light font-weight-bolder" onclick="goToFull();" style="margin-top:5px" >[&nbsp;&nbsp;]</span>
                            &nbsp;&nbsp;
                            <span class="btn  font-weight-bolder" id="imgspan" onclick="muteVideo();" style="margin-top:5px">
                                <img id="muteimg" src="Images/中控首页按钮/首页按钮-默认状态/总音量.png" height="40" width="40" />
                                </span>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-12 " style="color: white; ">
                        <div class="row" >
                            <object id="plugin_inst_2"
                                type="application/x-chimera-plugin" height="80" width="160" >
                                <param name="autoplay" value="true" />
                                <param name="mrl" id="src2" value="rtsp://admin:admin123@192.168.1.94:554/cam/realmonitor?channel=1&subtype=1" />
                                <param name="network-caching" value="300" />
                                <param name="mute" value="true" />
                            </object>
                        </div>
                        <div class="row " >
                            <object id="plugin_inst_3"
                                type="application/x-chimera-plugin" height="80" width="160" >
                                <param name="autoplay" value="true" />
                                <param name="mrl" id="src3" value="rtsp://admin:admin123@192.168.1.91:554/cam/realmonitor?channel=1&subtype=1" />
                                <param name="network-caching" value="300" />
                                <param name="mute" value="true" />
                            </object>
                        </div>
                        <div class="row" >
                            <object id="plugin_inst_4"
                                type="application/x-chimera-plugin" height="80" width="160" >
                                <param name="autoplay" value="true" />
                                <param name="mrl" id="src4" value="rtsp://admin:admin123@192.168.1.94:554/cam/realmonitor?channel=1&subtype=1" />
                                <param name="network-caching" value="300" />
                                <param name="mute" value="true" />
                            </object>
                        </div>
                        <div class="row" >
                            <object id="plugin_inst_5"
                                type="application/x-chimera-plugin" height="80" width="160" >
                                <param name="autoplay" value="true" />
                                <param name="mrl" id="src5" value="rtsp://admin:admin123@192.168.1.91:554/cam/realmonitor?channel=1&subtype=1" />
                                <param name="network-caching" value="300" />
                                <param name="mute" value="true" />
                            </object>
                        </div>
                    </div>
                </div>
                  
            </div>
            <div class="row" style="margin-bottom: -150px; margin-left: -50px">
                <div class="col-lg-3 col-md-4 col-sm-6">
                    <fieldset class="fieldSetControl">
                        <legend align="center" style="width: auto; font-size: 16px;">&nbsp;系统&nbsp;</legend>
                    </fieldset>
                    <div class="row">
                        
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <span>
                                <img src="Images/greyed/sysgrey.png" id="syspower"
                                    class="imgclick imgsize" /></span>
                        </div>
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/pcgrey.png" id="ppower"
                                class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-4 col-md-1 col-sm-1">

                            <img src="Images/greyed/lock1.png" id="lock"
                                class="imgclick imgsize" />
                        </div>
                        
                    </div>
                    <fieldset class="fieldSetControl">
                        <legend align="center" style="width: auto; font-size: 16px;">&nbsp;屏幕&nbsp;</legend>
                    </fieldset>
                    <div class="row">
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/scup.png" id="Scup"
                                class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/scdown.png" id="Scdown"
                                class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/scstop.png" id="scStop"
                                class="imgclick imgsize" />
                        </div>
                    </div>

                </div>
                
                <div class="col-lg-3 col-md-4 col-sm-6">
                    <fieldset class="fieldSetControl">
                        <legend align="center" style="width: auto; font-size: 16px;">&nbsp;信号切换&nbsp;</legend>
                    </fieldset>
                    <div class="row">
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/desktop.png"
                                id="desktop1"
                                class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/laptop.png" id="laptop1"
                                class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            
                            <img src="Images/greyed/more.png" id="Moremedia"
                                class="imgclick imgsize" />
                        </div>
                    </div>
                   
                    <fieldset class="fieldSetControl">
                        <legend align="center" style="width: auto; font-size: 16px;">&nbsp;窗帘&nbsp;</legend>
                    </fieldset>
                    <div class="row">
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/copengrey.png" id="CurtainOpen"
                                class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/cclosegrey.png" id="CurtainClose"
                                class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-4 col-md-1 col-sm-1">
                            <img src="Images/greyed/cstopgrey.png" id="CurtainStop"
                                class="imgclick imgsize" />
                        </div>
                    </div>

                </div>

                <div class="col-lg-3 col-md-4 col-sm-6">
                    <fieldset class="fieldSetControl">
                        <legend align="center" style="width: auto; font-size: 16px;">&nbsp;投影机&nbsp;</legend>
                    </fieldset>
                    <div class="row" style="text-align: center">
                        <div class="col-lg-6  col-md-1 col-sm-1">
                            <img src="Images/greyed/proj1.png" id="projgreen"
                                class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-6 col-md-1 col-sm-1">
                            <img src="Images/greyed/proj2.png" id="projred"
                                class="imgclick  imgsize" />
                        </div>
                    </div>
                    <fieldset class="fieldSetControl" >
                        <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.Light%>&nbsp;</legend>
                    </fieldset>
                    <div class="row" style="text-align: center">
                        <div class="col-lg-6  col-md-1 col-sm-1">
                            <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                id="lighton" class="imgclick imgsize" />
                        </div>
                        <div class="col-lg-6 col-md-1 col-sm-1">
                            <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                id="lightoff" class="imgclick imgsize" />
                        </div>

                    </div>
                        
                    <input id="InputIP" type="hidden" value='<%= Session["DeviceIP"] %>' />
                </div>
                <div class="col-lg-3">
                    <fieldset class="fieldSetControl"  id="volfieldset">
                        <legend align="center" style="width: auto; font-size: 16px;">&nbsp;音量&nbsp;</legend>
                    
                    <div class="row">
                        <table style="height: auto; width: 100%;">
                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center; background-color: #1e1e36; width: 5%">
                                    <span>
                                        <img src="Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png" id="volsymbol" height="30" />
                                    </span>
                                </td>
                                <td>
                                    <input id="vol-control" type="range" min="0" step="1" max="99"
                                        oninput="SetVolume(this.value)" onchange="SetVolume(this.value)" />
                                    &nbsp;<span id="volchange" style="color: white; font-size: 16px; width: 10%">50</span></td>

                            </tr>

                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center; width: 5%">
                                    <span>
                                        <img src="Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png" id="micIcon" height="40" />
                                    </span>

                                </td>
                                <td>
                                    <input id="mic-control" type="range" min="0" step="1" max="99"
                                        oninput="MicControl(this.value)" onchange="MicControl(this.value)" />
                                    <span id="micchange" style="color: white; font-size: 16px; width: 10%;">50</span></td>
                            </tr>
                        </table>
                    </div>
                       </fieldset> 
                    <div class="row" style="text-align: center">
                        <div class="col-lg-12" style="text-align: center;">
                            <span>
                                <img src="Images/中控首页按钮/全部菜单.png" class="imgclick" id="yellowbuttons"
                                    onclick="DisplayModal(); return false;" height="50" width="50" />
                            </span>
                        </div>

                    </div>
                        
                </div>
            </div>
        </div>

        <div class="col-lg-2 col-md-3 col-sm-12" style="max-height: 90%;">
            <div class="row " style="border: 1px solid white; margin-bottom: 10px; font-size: 14px;">
                <p style="color: white">
                    <script> document.write(new Date().toDateString()); </script>
                    <br />
                    <%=Resources.Resource.ClassName%>:  &nbsp;<script>document.write('<%= Session["LocToDisplay"] %>')</script>
                    <br />
                    <%=Resources.Resource.IPAddress%>: &nbsp;<script>document.write('<%= Session["DeviceIP"] %>')</script>&nbsp;<br />
                    <%=Resources.Resource.Status%>: &nbsp;<span id="devicestatus" style="font-weight: bold">Offline</span>
                </p>
            </div>
            <div class="row" style="border: 1px dashed #aeb2b7; ">
                <span style="text-align: left; width:110px">
                    <img src="Images/中控首页按钮/环境图标/背景图-（03_07.png" height="40" width="40" />
                </span>
                <span style="font-size:18px; color:#ffaa4d;padding-top:10px;" id="tempvalue">21°C</span>
            </div>
            <div class="row" style="border: 1px dashed #aeb2b7; ">
                <span style="text-align: left; width:110px">
                    <img src="Images/中控首页按钮/环境图标/背景图-（03_09.png" height="40" width="55" />
                </span>
                <span style="font-size:18px; color:#ffaa4d;padding-top:10px;" id="humidvalue">45%</span>
            </div>
            <div class="row" style="border: 1px dashed #aeb2b7; ">
                <span style="text-align: left; width:110px">
                    <img src="Images/中控首页按钮/环境图标/背景图-（03_17.png" height="40" width="40" />
                </span>
                <span style="font-size:18px; color:#ffaa4d;padding-top:10px;" id="pmvalue">12µg/m3</span>
            </div>
            <div class="row" style="border: 1px dashed #aeb2b7; ">
                <span style="text-align: left; width:110px">
                    <img src="Images/中控首页按钮/环境图标/背景图-（03_19.png" height="40" width="60" />
                </span>
                <span style="font-size:18px; color:#ffaa4d;padding-top:10px;" id="co2">350ppm</span>
            </div>
            <div class="row" style="border: 1px dashed #aeb2b7; ">
                <span style="text-align: left; width:110px">
                    <img src="Images/中控首页按钮/环境图标/背景图-（03_27.png" height="40" width="50" />
                </span>
                <span style="font-size:18px; color:#ffaa4d;padding-top:10px;" id="intensityvalue">1500nits</span>
            </div>
            <div class="row" style="border: 1px dashed #aeb2b7; ">
                <span style="text-align: left; width:110px">
                    <img src="Images/中控首页按钮/环境图标/背景图-（03_29.png" height="40" width="60" />
                </span>
                <span style="font-size:18px; color:#ffaa4d;padding-top:10px;" id="methanalvalue">8.1mg/m3</span>
            </div>
            <div class="row" style="border: 1px dashed #aeb2b7; ">
                <span style="text-align: left; width:110px">
                    <img src="Images/中控首页按钮/环境图标/背景图-（03_37.png" height="40" width="50" />
                </span>
                <span style="font-size:18px; color:#ffaa4d;padding-top:10px;" id="voltvalue">220V</span>
            </div>
            <div class="row" style="border: 1px dashed #aeb2b7; ">
                <div style="width:40%;float:left;text-align: left; margin:auto;">
                    <img src="Images/中控首页按钮/环境图标/背景图-（03_39.png" height="50" width="70" />
                </div>
                <div style="width:60%">
                    <div style="border-bottom: 1px solid #aeb2b7;width:100%;margin-top:-20px">
                        <span style="font-size:18px; color:#ffaa4d;padding-top:10px;" >
                            1:&nbsp;&nbsp;<span id="I1">0.06KW</span></span>
                    </div>
                    <div style="border-bottom: 1px solid #aeb2b7;width:100%">
                    <span style="font-size:18px;color:#ffaa4d">2:&nbsp;&nbsp;
                    <span id="I2">0.07KW</span></span></div>
                <div style="border-bottom: 1px solid #aeb2b7;width:100%">
                    <span style="font-size:18px;color:#ffaa4d">3:&nbsp;&nbsp;
                    <span id="I3">0.08KW</span></span>
                </div>
                <div style="width:100%; margin-bottom:-20px">
                    <span style="font-size:18px;color:#ffaa4d">4:&nbsp;&nbsp;
                    <span id="I4">0.05KW</span></span>
                </div>
                </div>
               
            </div>
        </div>
        <div class="col-lg-2 col-md-1"></div>
    </div>
    <div id="RemoteControl" class="modal">
        <div class="modal-content">
            <header class="row" style="position: center;">
                <span onclick="document.getElementById('RemoteControl').style.display='none'"
                    class="w3-button w3-display-topright">&times;</span>
            </header>
            <div class="row">
                <iframe id="Iframe1" style="background-color: #1e1e36" src="~/controlRemote.aspx" height="700" width="100%" runat="server" frameborder="0"></iframe>
            </div>
        </div>
    </div>

    <script>
        var modal = document.getElementById("RemoteControl");
        function DisplayModal() {
            if (document.getElementById("devicestatus").innerHTML == "Offline") {
                $("#yellowbuttons").removeClass("imgclick");
            }
            else {
                $("#yellowbuttons").removeClass("imgclick");
                modal.style.display = "block";
            }
        };
        document.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        };
        
        window.onload = onLoad;
        function addEvent(obj, name, func) {
            if (obj.attachEvent) {
                obj.attachEvent("on" + name, func);
            } else {
                obj.addEventListener(name, func, false);
            }
            console.log(name);
        }
        function onLoad(){
            addEvent(document.getElementById('plugin_inst_1'), 'MediaPlayerPaused', onPause1);
            addEvent(document.getElementById('plugin_inst_2'), 'MediaPlayerPaused', onPause2);
            addEvent(document.getElementById('plugin_inst_3'), 'MediaPlayerPaused', onPause3);
            addEvent(document.getElementById('plugin_inst_4'), 'MediaPlayerPaused', onPause4);
            addEvent(document.getElementById('plugin_inst_5'), 'MediaPlayerPaused', onPause5);
            console.log("function attacked");
        }
        function onPause1() {
            console.log("paused");
            var player1 = document.getElementById('plugin_inst_1');
            var video = document.getElementById('src1').value;
            player1.play(video);
            console.log("player1" + video);
        }
        function onPause2() {
            console.log("paused");
            var player1 = document.getElementById('plugin_inst_1');
            var player2 = document.getElementById('plugin_inst_2');
            var video2 = document.getElementById('src2').value;
            var video1 = document.getElementById('src1').value;
            var sub = video1 + video2.substring(39);
            player2.play(video2);
            player1.play(video2.substring(0, video2.length-35));
            document.getElementById('src1').value = video2.substring(0, 39);
            console.log("player2 " + sub);
            console.log("player1" + video2.substring(0, 39));
        }
        function onPause3() {
            console.log("paused");
            var player1 = document.getElementById('plugin_inst_1');
            var player2 = document.getElementById('plugin_inst_3');
            var video2 = document.getElementById('src3').value;
           var video1 = document.getElementById('src1').value;
            var sub = video1+video2.substring(39);
            player2.play(video2);
            player1.play(video2.substring(0, video2.length-35)); 
            document.getElementById('src1').value = video2.substring(0, 39);
            console.log("player2 " + sub);
            console.log("player1" + video2.substring(0, 39));
        }
        function onPause4() {
            console.log("paused");
            var player1 = document.getElementById('plugin_inst_1');
            var player2 = document.getElementById('plugin_inst_4');
            var video2 = document.getElementById('src4').value;
            var video1 = document.getElementById('src1').value;
            var sub = video1+video2.substring(39);
            player2.play(video2);
            player1.play(video2.substring(0, video2.length-35));
            document.getElementById('src1').value = video2.substring(0, 39);
            console.log("player2 " + sub);
            console.log("player1" + video2.substring(0, 39));
        }
        function onPause5() {
            console.log("paused");
            var player1 = document.getElementById('plugin_inst_1');
            var player2 = document.getElementById('plugin_inst_5');
            var video2 = document.getElementById('src5').value;
            player2.play(video2);
            player1.play(video2.substring(0, video2.length-35)); 
            document.getElementById('src1').value = video2.substring(0, 39);
            console.log("player1" + video2.substring(0, video2.length-35));
        }

        function muteVideo() {           
            document.getElementById('plugin_inst_1').toggleMute();            
            var imgmute = document.getElementById('muteimg');
            var src1 = $(imgmute).attr('src');
            if (src1 == "Images/中控首页按钮/首页按钮-默认状态/总音量静音.png") {
                $(imgmute).attr('src', "Images/中控首页按钮/首页按钮-默认状态/总音量.png");                
            }
            else {
                $(imgmute).attr('src', "Images/中控首页按钮/首页按钮-默认状态/总音量静音.png");                
            }                            
        }
        
        function goToFull() {
            var src = document.getElementById('src1').value;
            sessionStorage.setItem('videosrc', src);
            var win = window.open("src/chimera.htm", "_blank");
            win.focus();
            //window.location = "src/chimera.htm" ;
        }
    </script>
  
</asp:Content>
