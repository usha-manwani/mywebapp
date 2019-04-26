﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="controlRemote.aspx.cs" Inherits="WebCresij.controlRemote" %>

<html>
<head>
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script>
    <script src="Scripts/RemoteModal.js?v=5"></script>
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
        .imgclick {
            height: 65px;
            width: 65px;
        }

            .imgclick:hover {
                -webkit-border-radius: 10px;
                -moz-border-radius: 10px;
                border-radius: 10px;
                -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            }

            .imgclick:active {
                -webkit-border-radius: 10px;
                -moz-border-radius: 10px;
                border-radius: 10px;
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
            border-radius: 10px;
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
            border-top-color: #4ecdc4;
        }

        .shadowRow {
            -moz-box-shadow: 0 0 10px #000000;
            -webkit-box-shadow: 0 0 10px #000000;
            box-shadow: 0 0 10px #000000;
        }

        #control {
            background-color: #1e1e36;
            height: 500px;
            padding-bottom: 50px;
            padding-left: 50px;
        }

        .displaynone {
            display: none;
        }

        .displayblock {
            display: inline-block;
            cursor: pointer;
        }

        body {
            background-color: #1e1e36;
        }

        input[type=range] {
            -webkit-appearance: none;
            background-color: #1e1e36;
            width: 180px;
        }

            input[type=range]::-webkit-slider-runnable-track {
                /*width:100%;*/
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

        .tableStyle {
            border: 1px solid #4ecdc4;
            height: 200px;
            width: 330px;
        }

        .controlHeaderRow {
            font-size: 16px;
            color: white;
            align-items: center;
            align-content: center;
            border-bottom: 1px solid #4ecdc4;
            height: 24px;
            background-color: #1e1e36;
            margin-left: -50px;
        }
        
        /*.tab {
            float: left;
            border: 1px solid #4ecdc4;
            width: 30%;
            height: 200px;
        }

            
            .tab button {
                display: block;
                background-color: inherit;
                color: white;
                padding: 22px 16px;
                width: 100%;
                border: none;
                outline: none;
                text-align: left;
                cursor: pointer;
                transition: 0.3s;
                font-size: 17px;
            }

                
                .tab button:hover {
                    background-color: #ddd;
                }

                
                .tab button.active {
                    background-color: #ccc;
                }

       
        .tabcontent {
            float: left;
            padding: 0px 12px;
            border: 1px solid #ccc;
            width: 70%;
            border-left: none;
            height: 200px;
            color: white;
        }*/

        .buttonEffect {
            cursor: pointer;
            border-bottom: 1px solid #4ecdc4;
            color: white
        }

            .buttonEffect:active {
                -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                transform: translateY(1px);
            }
        .buttonEffect:hover{
            -webkit-border-radius: 5px;
                -moz-border-radius: 5px;
                border-radius: 5px;
                -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
        }

        .rowTrans {
            background-color: transparent;
        }

        .rowRed {
            background-color: red;
        }

        .btnstyle {
            border: 1px solid white;
            background-color: #23233f;
            width: 60px;
            border-radius: 8px;
            color: whitesmoke
        }
        .btnstyle:hover{
             -webkit-border-radius: 8px;
                -moz-border-radius: 8px;
                border-radius: 8px;
                -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
        }
    </style>
</head>
<body style="overflow: hidden !important">
    <form runat="server">

        <div id="control">
            <input id="sessionInputIP" type="hidden" value='<%= Session["DeviceIP"] %>' />
            <input id="sessionInput1" type="hidden" value='<%= Session["loc"] %>' />
            <input id="dev" type="hidden" value='<%=Session["devices"] %>' />
            <asp:TextBox Style="display: none" ID="ipAddressToSend" runat="server"></asp:TextBox>
            <div class="row">
                <div class="col-lg-7">
                    <div class="row">
                        <div class="col-lg-6">
                            <div id="system" class="divcontrols tablestyle">
                                <table style="height: 100%; width: 100%">
                                    <tr class="controlHeaderRow">
                                        <td colspan="6" style="text-align: center">System Control
                                        </td>
                                    </tr>
                                    <tr style="align-items: center; align-content: center;">
                                        <td colspan="3" style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_212.png" id="systempower"
                                                    class="imgclick" /></span>
                                        </td>
                                        <td colspan="3" style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_212.png" id="pcpower"
                                                    class="imgclick" /></span></td>

                                    </tr>
                                    <tr style="align-items: center; align-content: center;">

                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                
                                                <img src="Images/AllImages/images/SystemLock.png" id="sysLock"
                                                    class="imgclick" /></span>
                                        </td>
                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_236.png" id="classLock"
                                                    class="imgclick" /></span>
                                        </td>
                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_262.png" id="podiumLock"
                                                    class="imgclick" /></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div id="Projector" class="divcontrols tablestyle">
                                <table style="height: 100%; width: 100%">
                                    <tr class="controlHeaderRow">
                                        <td colspan="6" style="text-align: center">Projector Control
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_184.png" id="projectorOn"
                                                    class="imgclick" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_186.png" id="projectorOff"
                                                    class="imgclick" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_188.png" id="projSleep"
                                                    class="imgclick" /></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <a href="#" style="color: white;">
                                                <img src="Images/AllImages/images/图标_138.png" id="hdmi"
                                                    class="imgclick" /></a>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_164.png" id="projVideo"
                                                    class="imgclick" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_190.png" id="vga"
                                                    class="imgclick" /></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="divcontrols tablestyle ">
                                <table style="width: 100%; height: 100%;">
                                    <tr class="controlHeaderRow">
                                        <td colspan="6" style="text-align: center">Light Control
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="width: 25%; height: 100%; border-right: 1px solid #4ecdc4; float: left">
                                                <table style="width: 100%; height: 100%; font-size:14px;margin-top:-2px" id="myTable">

                                                    <tr class="buttonEffect">
                                                        <td id="light1">Light 1
                                                        </td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light2">Light 2
                                                        </td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light3">Light 3</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light4">Light 4 </td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light5">Light 5</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light6">Light 6</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light7">Light 7</td>
                                                    </tr>
                                                    <tr style="color: white; cursor: pointer">
                                                        <td id="light8">Light 8 </td>
                                                    </tr>
                                                </table>
                                            </div>

                                            <div class="tab-content" style="width: 75%; height: 100%; float: right; padding-left: 20px; padding-top: 10px;">
                                                <div style="height: 60%">
                                                    <div id="lightIcons1" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow1" class="imgclick" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey1" class="imgclick" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons2" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow2" class="imgclick" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey2" class="imgclick" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons3" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow3" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey3"
                                                                         class="imgclick" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons4" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow4" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey4"
                                                                        class="imgclick"/></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons5" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow5"
                                                                         class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey5"
                                                                        class="imgclick"/></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons6" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow6"
                                                                        class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey6"
                                                                        class="imgclick"/></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons7" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow7"
                                                                         class="imgclick" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey7"
                                                                         class="imgclick" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons8" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow8"
                                                                         class="imgclick" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey8"
                                                                         class="imgclick" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div style="height: 40%; margin-left: -20px; margin-top:-5px; background-color: #232140">
                                                    <fieldset style="border-top: 1px solid #4ecdc4">
                                                        <legend align="center" style="width: auto; color: white; font-size: 15px;">Options</legend>
                                                    </fieldset>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="lighton">
                                                                    On</button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="lightoff">
                                                                    Off</button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </div>
                        <div class="col-lg-6">
                            <div class="divcontrols tablestyle">
                                <table style="width: 100%; height: 100%;">
                                    <tr class="controlHeaderRow">
                                        <td colspan="6" style="text-align: center">Screen & Curtains Control
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="width: 25%; height: 100%; border-right: 1px solid #4ecdc4; float: left">
                                                <table style="width: 100%; height: 100%; font-size:14px;
                                                    margin-top:-2px;" id="curtainTable">                                             
                                                    <tr class="buttonEffect">
                                                        <td id="screen1">Screen 1</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="screen2">Screen 2</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain1">Curtain 1</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain2">Curtain 2</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain3">Curtain 3</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain4">Curtain 4</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain5">Curtain 5</td>
                                                    </tr>
                                                    <tr>
                                                        <td id="curtain6" style="color: white; cursor: pointer;">Curtain 6</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div class="tab-content" style="width: 75%; height: 100%; float: right; padding-top: 10px;">
                                                <div style="height: 60%">
                                                    <div id="screenIcons1" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png"
                                                                        id="screenup1" class="imgclick"/>
                                                                </td>
                                                                
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png"
                                                                        id="screendown1" class="imgclick"/></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png"
                                                                        id="screenstop1" class="imgclick"/></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="screenIcons2" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png"
                                                                        id="screenup2" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png"
                                                                        id="screendown2" class="imgclick"/></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png"
                                                                        id="screenstop2" class="imgclick"/></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons1" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen1" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose1" class="imgclick"/></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop1" class="imgclick"/></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons2" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen2" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose2" class="imgclick"/></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop2" class="imgclick"/></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons3" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen3" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose3" class="imgclick"/></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop3" class="imgclick"/></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons4" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen4" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose4" class="imgclick"/></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop4" class="imgclick"/></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons5" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen5" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose5" class="imgclick"/></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop5" class="imgclick"/></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons6" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen6" class="imgclick"/>
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose6" class="imgclick"/></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop6" class="imgclick"/></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div style="height: 40%; background-color: #232140; margin-top:-5px;" id="curtainOptions">
                                                    <fieldset style="border-top: 1px solid #4ecdc4">
                                                        <legend align="center" style="width: auto; color: white; font-size: 15px;">Options</legend>
                                                    </fieldset>

                                                    <table style="width: 100%;height:90%;margin-top:-15px;">
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="curtainbtnopen">
                                                                    Open</button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="curtainbtnclose">
                                                                    Close</button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="curtainbtnstop">
                                                                    Stop</button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <div style="height: 40%; background-color: #232140; margin-top:-5px;" id="screenOptions">
                                                    <fieldset style="border-top: 1px solid #4ecdc4">
                                                        <legend align="center" style="width: auto; color: white; font-size: 15px;">Options</legend>
                                                    </fieldset>
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="screenbtnup">
                                                                    Up</button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="screenbtndown">
                                                                    Down</button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="screenbtnstop">
                                                                    Stop</button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5">
                    <div class="row">
                        <div class="col-lg-6">
                            <div id="media" class="divcontrols" style="border: 1px solid #4ecdc4; width: 200px; height: 450px;">
                                <table style="height: 100%; width: 100%;">
                                    <tr class="controlHeaderRow">
                                        <td colspan="2" style="text-align: center">Media Signals
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="1" name="test" id="desktop"
                                                    data-target=".displaynone" />
                                                <img src="Images/AllImages/images/图标_158.png" class="imgclick">
                                            </label>
                                        </td>
                                        
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="2" name="test" id="laptop"
                                                    data-target=".displaynone">
                                                <img src="Images/AllImages/images/图标_160.png" class="imgclick">
                                            </label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="3" name="test" id="platform"
                                                    data-target=".displaynone">
                                                <img src="Images/AllImages/images/图标_194.png" class="imgclick">
                                            </label>
                                        </td>

                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="4" name="test"
                                                    id="digitalEquipment" data-target=".displaynone">
                                                <img src="Images/AllImages/images/图标_194.png" class="imgclick">
                                            </label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="5" name="test" id="dvd"
                                                    data-target="#dvdcontrols">
                                                <img src="Images/AllImages/images/图标_246.png" class="imgclick">
                                            </label>
                                        </td>

                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="6" name="test" id="bluray"
                                                    data-target="#bluraydvd">
                                                <img src="Images/AllImages/images/图标_272.png" class="imgclick">
                                            </label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="7" name="test" id="tv"
                                                    data-target="#tvcontrols">
                                                <img src="Images/AllImages/images/图标_298.png" class="imgclick">
                                            </label>
                                        </td>

                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="8" name="test" id="camera"
                                                    data-target="#Camera">
                                                <img src="Images/AllImages/images/图标_220.png" class="imgclick">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="9" name="test" id="recorder"
                                                    data-target="#recordercontrol">
                                                <img src="Images/AllImages/images/图标_324.png" class="imgclick">
                                            </label>
                                        </td>
                                        <td>no text</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div style="width: 200px;">
                                <div id="dvdcontrols" class="displaynone">
                                    <div id="dvdsubmenu" class="divcontrols" style="border: 1px solid #4ecdc4; width: 100%;">
                                        <table style="width: 100%; height: 100%">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center">DVD Controls
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_19.png" id="dvdpoweron"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_53.png" id="dvdstop"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_87.png" id="playdvd"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_55.png" id="dvdpause"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_121.png" id="dvdback"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_89.png" id="dvdforward"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_123.png" id="dvdpre"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_155.png" id="dvdnext"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_21.png" id="dvdexit"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="bluraydvd" class="displaynone">
                                    <div id="bludvdsubmenu" class="divcontrols" style="border: 1px solid #4ecdc4; width: 100%;">
                                        <table style="width: 100%; height: 100%">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center">Blu-ray DVD Controls
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_19.png" id="bludvdpoweron"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_53.png" id="bludvdstop"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_87.png" id="bluplaydvd"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_55.png" id="bludvdpause"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_121.png" id="bludvdback"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_89.png" id="bludvdforward"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_123.png" id="bludvdpre"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_155.png" id="bludvdnext"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_21.png" id="bludvdexit"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="Camera" class="displaynone">
                                    <div id="camerasubmenu" class="divcontrols" style="border: 1px solid #4ecdc4; width: 200px;">
                                        <table style="width: 100%; height: 100%">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center">Camera Controls
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">

                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_27.png" id="tcampoweroff"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_29.png" id="scampoweroff"
                                                        height="40" width="40" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_61.png" height="40"
                                                        width="40" id="rotate" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_63.png" height="40"
                                                        width="40" id="wb" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_95.png" height="40"
                                                        width="40" id="plus" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_97.png" height="40"
                                                        width="40" id="minus" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_129.png" height="40"
                                                        width="40" id="savecam" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_131.png" height="40"
                                                        width="40" id="changecam" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_163.png" height="40"
                                                        width="40" id="stopcam" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_165.png" height="40"
                                                        width="40" id="novideo" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_197.png" height="40"
                                                        width="40" id="nocam" class="imgclick" />
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="tvcontrols" class="displaynone">
                                    <div id="tvsubmenu" class="divcontrols" style="border: 1px solid #4ecdc4; width: 200px;">
                                        <table style="width: 100%; height: 400px">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center">TV Controls
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_23.png" height="40"
                                                        width="40" id="tvoff" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_25.png" height="40"
                                                        width="40" id="inputtv" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_57.png" height="40"
                                                        width="40" id="oktv" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_59.png" height="40"
                                                        width="40" id="optiontv" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_91.png" height="40"
                                                        width="40" id="plustv" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_93.png" height="40"
                                                        width="40" id="minustv" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_125.png" height="40"
                                                        width="40" id="exittv" class="imgclick" />
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="recordercontrol" class="displaynone">
                                    <div id="recordermenu" class="divcontrols" style="border: 1px solid #4ecdc4; width: 200px;">
                                        <table style="width: 100%; height: 300px">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center">Recorder Controls
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_31.png" height="40"
                                                        width="40" id="recpoweron" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_33.png" height="40"
                                                        width="40" id="recpoweroff" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_65.png" height="40"
                                                        width="40" id="recplay" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_67.png" height="40"
                                                        width="40" id="recstop" class="imgclick" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_99.png" height="40"
                                                        width="40" id="recchange" class="imgclick" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_101.png" height="40"
                                                        width="40" id="recsave" class="imgclick" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-5">
                    <div style="height: 200px; width: 100%; border: 1px solid #4ecdc4;">
                        <table style="width: 100%; height: 100%;">
                            <tr class="controlHeaderRow">
                                <td colspan="6" style="text-align: center">AC & Fresh Air System Control
                                </td>
                            </tr>
                            <tr>
                                <td>
 <div class="divcontrols ">
                            <div style="width: 20%; height: 100%; border-right: 1px solid #4ecdc4; float: left">
                                <table style="width: 100%; height: 100%; font-size:14px;margin-top:-2px;" id="actable">
                                    <tr class="buttonEffect">
                                        <td id="ac1">AC 1</td>
                                    </tr>
                                    <tr class="buttonEffect">
                                        <td id="ac2">AC 2</td>
                                    </tr>
                                    <tr class="buttonEffect">
                                        <td id="ac3">AC 3</td>
                                    </tr>
                                    <tr class="buttonEffect">
                                        <td id="ac4">AC 4</td>
                                    </tr>
                                    <tr class="buttonEffect">
                                        <td id="air1">AirSystem 1</td>
                                    </tr>
                                    <tr class="buttonEffect">
                                        <td id="air2">AirSystem 2</td>
                                    </tr>
                                    <tr class="buttonEffect">
                                        <td id="air3">AirSystem 3</td>
                                    </tr>
                                    <tr>
                                        <td id="air4" style="color: white; cursor: pointer">AirSystem 4</td>
                                    </tr>
                                </table>
                            </div>
                            <div style="width: 80%">
                                <div style="width: 100%" id="ac1div">
                                    <div class="row" style="padding-bottom: 15px; padding-top: 10px; padding-left: 20px;">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick" id="ac1on" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick" id="ac1off" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick" id="ac1cool" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick" id="ac1heat" />
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left: 20px">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick" id="ac1plus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick" id="ac1minus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick" id="ac1fan" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick" id="ac1fanOn" />
                                        </div>
                                    </div>
                                </div>

                                <div style="width: 100%" id="ac2div">
                                    <div class="row" style="padding-bottom: 15px; padding-top: 10px; padding-left: 20px;">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick" id="ac2on" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick" id="ac2off" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick" id="ac2cool" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick" id="ac2heat" />
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left: 20px">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick" id="ac2plus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick" id="ac2minus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick" id="ac2fan" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick" id="ac2fanOn" />
                                        </div>
                                    </div>
                                </div>

                                <div style="width: 100%" id="ac3div">
                                    <div class="row" style="padding-bottom: 15px; padding-top: 10px; padding-left: 20px;">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick" id="ac3on" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick" id="ac3off" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick" id="ac3cool" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick" id="ac3heat" />
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left: 20px">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick" id="ac3plus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick" id="ac3minus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick" id="ac3fan" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick" id="ac3fanOn" />
                                        </div>
                                    </div>
                                </div>

                                <div style="width: 100%" id="ac4div">
                                    <div class="row" style="padding-bottom: 15px; padding-top: 10px; padding-left: 20px;">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick" id="ac4on" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick" id="ac4off" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick" id="ac4cool" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick" id="ac4heat" />
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left: 20px">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick" id="ac4plus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick" id="ac4minus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick" id="ac4fan" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick" id="ac4fanOn" />
                                        </div>
                                    </div>
                                </div>

                                <div style="width: 100%" id="air1div">
                                    <div class="row" style="padding-bottom: 15px; padding-top: 10px; padding-left: 20px;">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick" id="air1on" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick" id="air1off" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick" id="air1cool" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick" id="air1heat" />
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left: 20px">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick" id="air1plus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick" id="air1minus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick" id="air1fan" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick" id="air1fanOn" />
                                        </div>
                                    </div>
                                </div>

                                <div style="width: 100%" id="air2div">
                                    <div class="row" style="padding-bottom: 15px; padding-top: 10px; padding-left: 20px;">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick" id="air2on" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick" id="air2off" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick" id="air2cool" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick" id="air2heat" />
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left: 20px">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick" id="air2plus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick" id="air2minus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick" id="air2fan" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick" id="air2fanOn" />
                                        </div>
                                    </div>
                                </div>

                                <div style="width: 100%" id="air3div">
                                    <div class="row" style="padding-bottom: 15px; padding-top: 10px; padding-left: 20px;">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick" id="air3on" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick" id="air3off" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick" id="air3cool" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick" id="air3heat" />
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left: 20px">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick" id="air3plus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick" id="air3minus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick" id="air3fan" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick" id="air3fanOn" />
                                        </div>
                                    </div>
                                </div>

                                <div style="width: 100%" id="air4div">
                                    <div class="row" style="padding-bottom: 15px; padding-top: 10px; padding-left: 20px;">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick" id="air4on" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick" id="air4off" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick" id="air4cool" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick" id="air4heat" />
                                        </div>
                                    </div>
                                    <div class="row" style="padding-left: 20px">
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick" id="air4plus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick" id="air4minus" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick" id="air4fan" />
                                        </div>
                                        <div class="col-lg-3">
                                            <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick" id="air4fanOn" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                                </td>
                            </tr>
                        </table>
                       
                    </div>
                </div>
                <div class="col-lg-4">
                    <div style="height: 200px; width: 300px; border: none">
                        <fieldset class="fieldSetControl" style="width: 100%; color: white;">
                            <legend align="center" style="width: auto; font-size: 16px;">
                                <span>Sound Control</span></legend>
                        </fieldset>
                        <div id="Microphone" class="divcontrols" >
                            <table>
                                <tr>
                                    <td style="text-align: center; width: 45px;">
                                        <img src="Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png"
                                            id="volicons" height="40" width="40" />
                                    </td>
                                    <td>
                                        <input id="vol" type="range" min="0" step="1" max="99"
                                            oninput="RemoteVol(this.value)" onchange="RemoteVol(this.value)" />
                                        <span style="color: white; font-size: 16px;" id="volValue">50</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; width: 45px;">
                                        <img src="Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png" id="wirelessicons"
                                            height="40" width="40" />
                                    </td>
                                    <td>
                                        <input id="wirelessvol" type="range" min="0" step="1" max="99"
                                            oninput="WirelessRemoteMic(this.value)" onchange="WirelessRemoteMic(this.value)" />
                                        <span style="color: white; font-size: 16px;" id="wirelessValue">50</span></td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; width: 45px;" class="auto-style1">
                                        <img src="Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png"
                                            id="wiredicons" height="40" width="40" />
                                    </td>
                                    <td>
                                        <input id="wiredvol" type="range" min="0" step="1" max="99"
                                            oninput="WiredRemoteMic(this.value)" onchange="WiredRemoteMic(this.value)" />
                                        <span style="color: white; font-size: 16px;" id="wiredValue">50</span></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3"></div>
            </div>
        </div>
    </form>
</body>
</html>
