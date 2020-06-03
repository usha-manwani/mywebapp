﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="controlRemote.aspx.cs" Inherits="WebCresij.controlRemote" %>

<html>
<head>
    <title></title>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script>
    <script src="Scripts/RemoteModal.js?v=8"></script>
    <style>
        .scroll {
            overflow-y: auto;
        }

            .scroll::-webkit-scrollbar {
                width: 10px;
                background-color: #404040;
                visibility: hidden;
            }

                .scroll::-webkit-scrollbar:hover {
                    visibility: visible;
                }

            .scroll::-webkit-scrollbar-thumb {
                background: linear-gradient(left, #fff, #4ECDC4);
                max-height: 200px !important;
            }

                .scroll::-webkit-scrollbar-thumb:hover {
                    background: #4ECDC4;
                }

                .scroll::-webkit-scrollbar-thumb:active {
                    background: linear-gradient(left, #22ADD4, #4ECDC4);
                }

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
        /*.imgclick {
            
            width: 55%;
        }*/
        .imgsize {
            width: 50%;
            
        }

        .imgsize1 {
            width: 55%;
            
        }

        .imgsize2 {
            width: 60%;
        }

        .imgclick:hover {
            -webkit-border-radius: 5%;
            -moz-border-radius: 5%;
            border-radius: 5%;
            -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
        }

        .imgclick:active {
            -webkit-border-radius: 5%;
            -moz-border-radius: 5%;
            border-radius: 5%;
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
            height: 600px;
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
            height: 180px;
            width: 300px;
            min-width: 250px !important;
            max-width: 330px !important;
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

        .MediaSignalTable {
            border: 1px solid #4ecdc4;
            width: 220px !important;
        }       

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

            .buttonEffect:hover {
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

            .btnstyle:hover {
                -webkit-border-radius: 8px;
                -moz-border-radius: 8px;
                border-radius: 8px;
                -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
                box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            }
    </style>
</head>
<body style="overflow-x: hidden !important">

    <form runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div id="control">
            <div style="color: white; font-size: 1.5em">
                <asp:Label runat="server" ID="insName"></asp:Label>
                <span>>></span>
                <asp:Label runat="server" ID="GradeName"></asp:Label>
                <span>>></span>
                <asp:Label runat="server" ID="ClassName"></asp:Label>
                <hr />
            </div>
            <input id="sessionInputIP" type="hidden" value='<%= Session["DeviceIP"] %>' />
            <input id="sessionInput1" type="hidden" value='<%= Session["loc"] %>' />
            <input id="dev" type="hidden" value='<%=Session["devices"] %>' />
            <asp:TextBox Style="display: none" ID="ipAddressToSend" runat="server"></asp:TextBox>
            <div class="row">
                <div class="col-xl-7 col-lg-12 col-md-12 col-sm-12">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div id="system" class="divcontrols tablestyle">
                                <table style="height: 100%; width: 100%">
                                    <tr class="controlHeaderRow">
                                        <td colspan="6" style="text-align: center"><%=Resources.Resource.SystemControl%>
                                        </td>
                                    </tr>
                                    <tr style="align-items: center; align-content: center;">
                                        <td colspan="3" style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_212.png" id="systempower"
                                                    class="imgclick" style="width: 45%" /></span>
                                        </td>
                                        <td colspan="3" style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_212.png" id="pcpower"
                                                    class="imgclick" style="width: 45%" /></span></td>
                                    </tr>
                                    <tr style="align-items: center; align-content: center;">

                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                <img src="Images/中控首页按钮/on/lock1open.png" id="sysLock"
                                                    class="imgclick imgsize" /></span>
                                        </td>
                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                <img src="Images/中控首页按钮/on/lock2open.png" id="podiumLock"
                                                    class="imgclick imgsize" /></span>
                                        </td>
                                        <td colspan="2" style="text-align: center">
                                            <span>
                                                <img src="Images/中控首页按钮/on/lock3open.png" id="classLock"
                                                    class="imgclick imgsize" /></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div id="Projector" class="divcontrols tablestyle">
                                <table style="height: 100%; width: 100%">
                                    <tr class="controlHeaderRow">
                                        <td colspan="6" style="text-align: center"><%=Resources.Resource.ProjectorControl%>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_184.png" id="projectorOn"
                                                    class="imgclick imgsize" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_186.png" id="projectorOff"
                                                    class="imgclick imgsize" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_188.png" id="projSleep"
                                                    class="imgclick imgsize" /></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <a href="#" style="color: white;">
                                                <img src="Images/AllImages/images/图标_138.png" id="hdmi"
                                                    class="imgclick imgsize" /></a>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_164.png" id="projVideo"
                                                    class="imgclick imgsize" /></span>
                                        </td>
                                        <td style="text-align: center">
                                            <span>
                                                <img src="Images/AllImages/images/图标_190.png" id="vga"
                                                    class="imgclick imgsize" /></span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="divcontrols tablestyle ">
                                <table style="width: 100%; height: 100%;">
                                    <tr class="controlHeaderRow">
                                        <td colspan="6" style="text-align: center"><%=Resources.Resource.Light%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="width: 25%; height: 100%; border-right: 1px solid #4ecdc4; float: left">
                                                <table style="width: 100%; height: 100%; font-size: 12px; margin-top: -2px" id="myTable">

                                                    <tr class="buttonEffect">
                                                        <td id="light1"><%=Resources.Resource.Light%> 1
                                                        </td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light2"><%=Resources.Resource.Light%> 2
                                                        </td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light3"><%=Resources.Resource.Light%> 3</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light4"><%=Resources.Resource.Light%> 4 </td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light5"><%=Resources.Resource.Light%> 5</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light6"><%=Resources.Resource.Light%> 6</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="light7"><%=Resources.Resource.Light%> 7</td>
                                                    </tr>
                                                    <tr style="color: white; cursor: pointer">
                                                        <td id="light8"><%=Resources.Resource.Light%> 8 </td>
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
                                                                        id="lightyellow1" class="imgclick imgsize" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey1" class="imgclick imgsize" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons2" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow2" class="imgclick imgsize" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey2" class="imgclick imgsize" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons3" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow3" class="imgclick imgsize" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey3"
                                                                        class="imgclick imgsize" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons4" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow4" class="imgclick imgsize" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey4"
                                                                        class="imgclick imgsize" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons5" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow5"
                                                                        class="imgclick imgsize" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey5"
                                                                        class="imgclick imgsize" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons6" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow6"
                                                                        class="imgclick imgsize" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey6"
                                                                        class="imgclick imgsize" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons7" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow7"
                                                                        class="imgclick imgsize" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey7"
                                                                        class="imgclick imgsize" /></td>
                                                            </tr>

                                                        </table>
                                                    </div>

                                                    <div id="lightIcons8" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                                                                        id="lightyellow8"
                                                                        class="imgclick imgsize" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                                                                        id="lightgrey8"
                                                                        class="imgclick imgsize" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div style="height: 40%; margin-left: -20px; margin-top: -5px; background-color: #232140">
                                                    <fieldset style="border-top: 1px solid #4ecdc4">
                                                        <legend align="center" style="width: auto; color: white; font-size: 15px;"><%=Resources.Resource.Options%></legend>
                                                    </fieldset>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <table style="width: 100%">
                                                                <tr>
                                                                    <td style="text-align: center;">
                                                                        <button class="btnstyle" id="lighton">
                                                                            <%=Resources.Resource.On%></button>
                                                                    </td>
                                                                    <td style="text-align: center;">
                                                                        <button class="btnstyle" id="lightoff">
                                                                            <%=Resources.Resource.Off%></button>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>

                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="divcontrols tablestyle">
                                <table style="width: 100%; height: 100%;">
                                    <tr class="controlHeaderRow">
                                        <td colspan="6" style="text-align: center"><%=Resources.Resource.ScreenCurtain%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="width: 25%; height: 100%; border-right: 1px solid #4ecdc4; float: left">
                                                <table style="width: 100%; height: 100%; font-size: 12px; margin-top: -2px;"
                                                    id="curtainTable">
                                                    <tr class="buttonEffect">
                                                        <td id="screen1"><%=Resources.Resource.Screen%> 1</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="screen2"><%=Resources.Resource.Screen%> 2</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain1"><%=Resources.Resource.Curtain%> 1</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain2"><%=Resources.Resource.Curtain%> 2</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain3"><%=Resources.Resource.Curtain%> 3</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain4"><%=Resources.Resource.Curtain%> 4</td>
                                                    </tr>
                                                    <tr class="buttonEffect">
                                                        <td id="curtain5"><%=Resources.Resource.Curtain%> 5</td>
                                                    </tr>
                                                    <tr>
                                                        <td id="curtain6" style="color: white; cursor: pointer;"><%=Resources.Resource.Curtain%> 6</td>
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
                                                                        id="screenup1" class="imgclick imgsize2" />
                                                                </td>

                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png"
                                                                        id="screendown1" class="imgclick imgsize2" /></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png"
                                                                        id="screenstop1" class="imgclick imgsize2" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="screenIcons2" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_132.png"
                                                                        id="screenup2" class="imgclick imgsize2" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_134.png"
                                                                        id="screendown2" class="imgclick imgsize2" /></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_136.png"
                                                                        id="screenstop2" class="imgclick imgsize2" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons1" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen1" class="imgclick imgsize2" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose1" class="imgclick imgsize2" /></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop1" class="imgclick imgsize2" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons2" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen2" class="imgclick imgsize2" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose2" class="imgclick imgsize2" /></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop2" class="imgclick imgsize2" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons3" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen3" class="imgclick imgsize2" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose3" class="imgclick imgsize2" /></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop3" class="imgclick imgsize2" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons4" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen4" class="imgclick imgsize2" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose4" class="imgclick imgsize2" /></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop4" class="imgclick imgsize2" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons5" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen5" class="imgclick imgsize2" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose5" class="imgclick imgsize2" /></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop5" class="imgclick imgsize2" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div id="curtainIcons6" class="tab-pane active">
                                                        <table style="height: 100%; width: 100%">
                                                            <tr>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_106.png"
                                                                        id="curtainopen6" class="imgclick imgsize2" />
                                                                </td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_108.png"
                                                                        id="curtainclose6" class="imgclick imgsize2" /></td>
                                                                <td style="text-align: center">
                                                                    <img src="Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_110.png"
                                                                        id="curtainstop6" class="imgclick imgsize2" /></td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div style="height: 40%; background-color: #232140; margin-top: -5px;" id="curtainOptions">
                                                    <fieldset style="border-top: 1px solid #4ecdc4">
                                                        <legend align="center" style="width: auto; color: white; font-size: 15px;"><%=Resources.Resource.Options%></legend>
                                                    </fieldset>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                             <table style="width: 100%; height: 90%; margin-top: -15px;">
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="curtainbtnopen">
                                                                    <%=Resources.Resource.Open%></button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="curtainbtnclose">
                                                                    <%=Resources.Resource.Close%></button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="curtainbtnstop">
                                                                    <%=Resources.Resource.Stop%></button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                   
                                                </div>
                                                <div style="height: 40%; background-color: #232140; margin-top: -5px;" id="screenOptions">
                                                    <fieldset style="border-top: 1px solid #4ecdc4">
                                                        <legend align="center" style="width: auto; color: white; font-size: 15px;">Options</legend>
                                                    </fieldset>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                             <table style="width: 100%">
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="screenbtnup">
                                                                    <%=Resources.Resource.Up%></button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="screenbtndown">
                                                                    <%=Resources.Resource.Down%></button>
                                                            </td>
                                                            <td style="text-align: center;">
                                                                <button class="btnstyle" id="screenbtnstop">
                                                                    <%=Resources.Resource.Stop%></button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>                                                   
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-5 col-lg-8 col-md-12 col-sm-12">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div id="media" class="divcontrols MediaSignalTable">
                                <table style="height: 100%; width: 100%; max-height:350px;max-width:220px">
                                    <tr class="controlHeaderRow">
                                        <td colspan="2" style="text-align: center"><%=Resources.Resource.MediaSignal%></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="1" name="test" id="desktop"
                                                    data-target=".displaynone" />
                                                <img src="Images/AllImages/images/图标_158.png" class="imgclick imgsize">
                                            </label>
                                        </td>

                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="2" name="test" id="laptop"
                                                    data-target=".displaynone">
                                                <img src="Images/AllImages/images/图标_160.png" class="imgclick imgsize">
                                            </label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="3" name="test" id="platform"
                                                    data-target=".displaynone">
                                                <img src="Images/AllImages/images/图标_194.png" class="imgclick imgsize">
                                            </label>
                                        </td>

                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="4" name="test"
                                                    id="digitalEquipment" data-target=".displaynone">
                                                <img src="Images/AllImages/images/图标_194.png" class="imgclick imgsize">
                                            </label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="5" name="test" id="dvd"
                                                    data-target="#dvdcontrols">
                                                <img src="Images/AllImages/images/图标_246.png" class="imgclick imgsize">
                                            </label>
                                        </td>

                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="6" name="test" id="bluray"
                                                    data-target="#bluraydvd">
                                                <img src="Images/AllImages/images/图标_272.png" class="imgclick imgsize">
                                            </label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="7" name="test" id="tv"
                                                    data-target="#tvcontrols">
                                                <img src="Images/AllImages/images/图标_298.png" class="imgclick imgsize">
                                            </label>
                                        </td>

                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="8" name="test" id="camera"
                                                    data-target="#Camera">
                                                <img src="Images/AllImages/images/图标_220.png" class="imgclick imgsize">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <label>
                                                <input type="radio" value="9" name="test" id="recorder"
                                                    data-target="#recordercontrol">
                                                <img src="Images/AllImages/images/图标_324.png" class="imgclick imgsize">
                                            </label>
                                        </td>
                                        <td>no text</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div>
                                <div id="dvdcontrols" class="displaynone">
                                    <div id="dvdsubmenu" class="divcontrols  MediaSignalTable">
                                        <table style="width: 100%; height: 100%">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center"><%=Resources.Resource.dvdControls%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_19.png" id="dvdpoweron"
                                                        class="imgclick  imgsize" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_53.png" id="dvdstop"
                                                        class="imgclick  imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_87.png" id="playdvd"
                                                        class="imgclick imgsize" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_55.png" id="dvdpause"
                                                        class="imgclick  imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_121.png" id="dvdback"
                                                        class="imgclick imgsize" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_89.png" id="dvdforward"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_123.png" id="dvdpre"
                                                        class="imgclick imgsize" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_155.png" id="dvdnext"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_21.png" id="dvdexit"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="bluraydvd" class="displaynone">
                                    <div id="bludvdsubmenu" class="divcontrols MediaSignalTable">
                                        <table style="width: 100%; height: 100%">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center"><%=Resources.Resource.Bluraydvd%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_19.png" id="bludvdpoweron"
                                                        class="imgclick imgsize" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_53.png" id="bludvdstop"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_87.png" id="bluplaydvd"
                                                        class="imgclick imgsize" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_55.png" id="bludvdpause"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_121.png" id="bludvdback"
                                                        class="imgclick imgsize" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_89.png" id="bludvdforward"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_123.png" id="bludvdpre"
                                                        class="imgclick imgsize" />
                                                </td>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_155.png" id="bludvdnext"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <img src="Images/AllImages/子菜单/默认状态/DVD、蓝光控制/子菜单_21.png" id="bludvdexit"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="Camera" class="displaynone">
                                    <div id="camerasubmenu" class="divcontrols MediaSignalTable">
                                        <table style="width: 100%; height: 100%">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center"><%=Resources.Resource.Camera%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">

                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_27.png" id="tcampoweroff"
                                                        class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_29.png" id="scampoweroff"
                                                        class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_61.png"
                                                        id="rotate" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_63.png"
                                                        id="wb" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_95.png"
                                                        id="plus" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_97.png"
                                                        id="minus" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_129.png"
                                                        id="savecam" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_131.png"
                                                        id="changecam" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_163.png"
                                                        id="stopcam" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_165.png"
                                                        id="novideo" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/摄像机控制/子菜单_197.png"
                                                        id="nocam" class="imgclick imgsize" />
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="tvcontrols" class="displaynone">
                                    <div id="tvsubmenu" class="divcontrols MediaSignalTable">
                                        <table style="width: 100%; height: 80%">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center"><%=Resources.Resource.tvcontrol%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_23.png"
                                                        id="tvoff" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_25.png"
                                                        id="inputtv" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_57.png"
                                                        id="oktv" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_59.png"
                                                        id="optiontv" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_91.png"
                                                        id="plustv" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_93.png"
                                                        id="minustv" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/电视机控制/子菜单_125.png"
                                                        id="exittv" class="imgclick imgsize" />
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="recordercontrol" class="displaynone">
                                    <div id="recordermenu" class="divcontrols MediaSignalTable">
                                        <table style="width: 100%; height: 100%">
                                            <tr class="controlHeaderRow">
                                                <td colspan="2" style="text-align: center"><%=Resources.Resource.RecorderControls%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_31.png"
                                                        id="recpoweron" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_33.png"
                                                        id="recpoweroff" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_65.png"
                                                        id="recplay" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_67.png"
                                                        id="recstop" class="imgclick imgsize" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_99.png"
                                                        id="recchange" class="imgclick imgsize" />
                                                </td>
                                                <td class="text-center">
                                                    <img src="Images/AllImages/子菜单/默认状态/录播系统控制/子菜单_101.png"
                                                        id="recsave" class="imgclick imgsize" />
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
                <div class="col-xl-5 col-lg-8 col-md-8 col-sm-12">
                    <div style="height: 200px; border: 1px solid #4ecdc4;">
                        <table style="width: 100%; height: 100%;">
                            <tr class="controlHeaderRow">
                                <td colspan="6" style="text-align: center"><%=Resources.Resource.ACFreshAir%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="height: 100%">
                                        <div style="width: 20%; height: 100%; border-right: 1px solid #4ecdc4; float: left">
                                            <table style="width: 100%; height: 100%; font-size: 12px; margin-top: -2px;" id="actable">
                                                <tr class="buttonEffect">
                                                    <td id="ac1"><%=Resources.Resource.AC1%> 1</td>
                                                </tr>
                                                <tr class="buttonEffect">
                                                    <td id="ac2"><%=Resources.Resource.AC1%> 2</td>
                                                </tr>
                                                <tr class="buttonEffect">
                                                    <td id="ac3"><%=Resources.Resource.AC1%> 3</td>
                                                </tr>
                                                <tr class="buttonEffect">
                                                    <td id="ac4"><%=Resources.Resource.AC1%> 4</td>
                                                </tr>
                                                <tr class="buttonEffect">
                                                    <td id="air1"><%=Resources.Resource.AirSystem%> 1</td>
                                                </tr>
                                                <tr class="buttonEffect">
                                                    <td id="air2"><%=Resources.Resource.AirSystem%> 2</td>
                                                </tr>
                                                <tr class="buttonEffect">
                                                    <td id="air3"><%=Resources.Resource.AirSystem%> 3</td>
                                                </tr>
                                                <tr>
                                                    <td id="air4" style="color: white; cursor: pointer"><%=Resources.Resource.AirSystem%> 4</td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="width: 80%; height: 100%; float: right">

                                            <table id="ac1div" style="width: 100%; height: 100%">
                                                <tr>
                                                    <td align="center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick imgsize1" id="ac1on" />
                                                    </td>
                                                    <td align="center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick imgsize1" id="ac1off" />
                                                    </td>
                                                    <td align="center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick imgsize1" id="ac1cool" />
                                                    </td>
                                                    <td align="center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick imgsize1" id="ac1heat" />
                                                    </td>
                                                </tr>

                                                <tr style="padding-left: 20px">
                                                    <td align="center">
                                                        <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick imgsize1" id="ac1plus" />
                                                    </td>
                                                    <td align="center">
                                                        <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick imgsize1" id="ac1minus" />
                                                    </td>
                                                    <td align="center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick imgsize1" id="ac1fan" />
                                                    </td>
                                                    <td align="center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick imgsize1" id="ac1fanOn" />
                                                    </td>
                                                </tr>
                                            </table>


                                            <table style="width: 100%; height: 100%" id="ac2div">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick imgsize1" id="ac2on" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick imgsize1" id="ac2off" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick imgsize1" id="ac2cool" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick imgsize1" id="ac2heat" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick imgsize1" id="ac2plus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick imgsize1" id="ac2minus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick imgsize1" id="ac2fan" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick imgsize1" id="ac2fanOn" />
                                                    </td>
                                                </tr>
                                            </table>

                                            <table style="width: 100%; height: 100%" id="ac3div">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick imgsize1" id="ac3on" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick imgsize1" id="ac3off" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick imgsize1" id="ac3cool" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick imgsize1" id="ac3heat" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick imgsize1" id="ac3plus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick imgsize1" id="ac3minus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick imgsize1" id="ac3fan" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick imgsize1" id="ac3fanOn" />
                                                    </td>
                                                </tr>
                                            </table>

                                            <table style="width: 100%; height: 100%" id="ac4div">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick imgsize1" id="ac4on" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick imgsize1" id="ac4off" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick imgsize1" id="ac4cool" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick imgsize1" id="ac4heat" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick imgsize1" id="ac4plus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick imgsize1" id="ac4minus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick imgsize1" id="ac4fan" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick imgsize1" id="ac4fanOn" />
                                                    </td>
                                                </tr>
                                            </table>

                                            <table style="width: 100%; height: 100%" id="air1div">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick imgsize1" id="air1on" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick imgsize1" id="air1off" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick imgsize1" id="air1cool" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick imgsize1" id="air1heat" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick imgsize1" id="air1plus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick imgsize1" id="air1minus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick imgsize1" id="air1fan" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick imgsize1" id="air1fanOn" />
                                                    </td>
                                                </tr>
                                            </table>

                                            <table style="width: 100%; height: 100%" id="air2div">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick imgsize1" id="air2on" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick imgsize1" id="air2off" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick imgsize1" id="air2cool" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick imgsize1" id="air2heat" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick imgsize1" id="air2plus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick imgsize1" id="air2minus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick imgsize1" id="air2fan" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick imgsize1" id="air2fanOn" />
                                                    </td>
                                                </tr>
                                            </table>

                                            <table style="width: 100%; height: 100%" id="air3div">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick imgsize1" id="air3on" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick imgsize1" id="air3off" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick imgsize1" id="air3cool" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick imgsize1" id="air3heat" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick imgsize1" id="air3plus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick imgsize1" id="air3minus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick imgsize1" id="air3fan" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick imgsize1" id="air3fanOn" />
                                                    </td>
                                                </tr>
                                            </table>

                                            <table style="width: 100%; height: 100%" id="air4div">
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_07.png" class="imgclick imgsize1" id="air4on" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_09.png" class="imgclick imgsize1" id="air4off" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_22.png" class="imgclick imgsize1" id="air4cool" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_24.png" class="imgclick imgsize1" id="air4heat" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_17.png" class="imgclick imgsize1" id="air4plus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/images/空调_19.png" class="imgclick imgsize1" id="air4minus" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_32.png" class="imgclick imgsize1" id="air4fan" />
                                                    </td>
                                                    <td style="text-align: center">
                                                        <img src="Images/AllImages/空调/默认状态/空调_34.png" class="imgclick imgsize1" id="air4fanOn" />

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
                <div class="col-xl-3 col-lg-3 col-md-4 col-sm-5">
                    <div style="height: 200px; width: 100%; border: none">
                        <fieldset class="fieldSetControl" style="width: 100%; color: white;">
                            <legend align="center" style="width: auto; font-size: 16px;">
                                <span><%=Resources.Resource.Sound%></span></legend>
                        </fieldset>
                        <div id="Microphone" class="divcontrols">
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

            </div>
        </div>
    </form>
</body>
</html>
