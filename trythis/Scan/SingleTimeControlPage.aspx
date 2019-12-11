<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" 
    CodeBehind="SingleTimeControlPage.aspx.cs" Inherits="WebCresij.Scan.SingleTimeControlPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        @media screen and (max-width: 280px) and (max-height:450px)
        {
            .paddingtop{
                padding-top:20%;
            }
            label{
                color:white;
            }
        }
        .paddingtop{
            padding: 10% 0 2% 2%;
            max-width:500px;
            margin:0 auto;
        }
        .imgsize {
            /*width: 80%;*/
            max-width: 80%;
            width: 50px;
            min-width: 25px;
        }

        .imgsize1 {
            max-width: 100%;
            min-width: 25px;
        }

        .imgclick:active {
            -webkit-border-radius: 30%;
            -moz-border-radius: 30%;
            border-radius: 30%;
            -webkit-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            -moz-box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            box-shadow: 0px 0px 4px 4px rgba(119,204,238, 0.67);
            transform: translateY(1px);
        }

        .oncolor {
            -webkit-border-radius: 30%;
            -moz-border-radius: 30%;
            border-radius: 30%;
            -webkit-box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
            -moz-box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
            box-shadow: 0px 0px 6px 6px rgba(132,220,142, 0.67);
        }

        .noborder {
            border: none !important;
            /* max-width:500px;*/
        }

        .paddingright {
            padding-right: 10%;
        }

        .imgback {
            background-color: none;
        }

        .color {
            color: greenyellow;
        }

        .coloroff {
            color: lightslategrey;
        }

        .bck {
            width: 100% !important;
        }

        .fieldSetControl {
            border: solid;
            width: 100%;
            border-width: 1px;
            border-color: #4ecdc4;
            margin-left: 5px;
            color: #4ecdc4;
            padding-bottom: 2px;
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
            /*remove bg colour from the track, we'll use ms-fill-lower 
                and ms-fill-upper instead */
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

        [class^="col-"], [class*=" col-"] {
            text-align: center;
        }
        .positionCenter {
            /*padding: 15px;*/
            position: absolute;
            top: 50%;
            left: 50%;
            -ms-transform: translateX(-50%) translateY(-50%);
            -webkit-transform: translate(-50%,-50%);
            transform: translate(-50%,-50%);
        } 
        body{
            background-color:#1e1e36!important;
            color: #232140!important;
            padding-top:5%;
            padding-left:5%;
            padding-bottom:5%
        }
        .container{
            padding-left:0px !important
        }
    </style>
    <script src="../Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row marginTop" style="max-width: 450px; text-align: center">
        <asp:HiddenField ID="iptocam" Value="" runat="server" />
        
        <div style="padding-left: 5%; color: goldenrod; text-align: left">
            <p><asp:LinkButton runat="server" ID="logout" Text="<%$Resources:Resource , SignOut %>" OnClick="logout_Click"></asp:LinkButton>
        </p>
        
            <p><span><%=Resources.Resource.IPAddress %>&nbsp;:
                <label id="ipadd"></label>
            </span></p>
            <p>
                <span><%=Resources.Resource.Status%>&nbsp;:
                <label id="devicestatus"><%=Resources.Resource.Off %></label></span>
            </p>
        </div>
        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.SystemControl%>&nbsp;</legend>

            <div class="row marginBottom ">

                <div class="col-4">
                    <span>
                        <img src="../Images/greyed/sysgrey.png" id="syspower"
                            class="imgclick imgsize" /></span>
                </div>
                <div class="col-4">
                    <img src="../Images/greyed/pcgrey.png" id="ppower"
                        class="imgclick imgsize" />
                </div>
                <div class="col-4">

                    <img src="../Images/greyed/lock1.png" id="lock"
                        class="imgclick imgsize" />
                </div>

            </div>
        </fieldset>

        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.Screen%>&nbsp;</legend>
            <div class="row  marginTop">
                <div class="col-4">
                    <img src="../Images/greyed/scup.png" id="Scup"
                        class="imgclick imgsize" />
                </div>
                <div class="col-4">
                    <img src="../Images/greyed/scdown.png" id="Scdown"
                        class="imgclick imgsize" />
                </div>
                <div class="col-4">
                    <img src="../Images/greyed/scstop.png" id="scStop"
                        class="imgclick imgsize" />
                </div>
            </div>
        </fieldset>

        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.MediaSignal%>&nbsp;</legend>
            <div class="row marginBottom">
                <div class="col-4">
                    <img src="../Images/greyed/desktop.png"
                        id="desktop1"
                        class="imgclick imgsize" />
                </div>
                <div class="col-4">
                    <img src="../Images/greyed/laptop.png" id="laptop1"
                        class="imgclick imgsize" />
                </div>
                <div class="col-4">

                    <img src="../Images/AllImages/images/图标_194.png" id="Moremedia"
                        class="imgclick imgsize" />
                </div>
            </div>
        </fieldset>

        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.Curtain%>&nbsp;</legend>
            <div class="row  marginTop">
                <div class="col-4">
                    <img src="../Images/greyed/copengrey.png" id="CurtainOpen"
                        class="imgclick imgsize" />
                </div>
                <div class="col-4">
                    <img src="../Images/greyed/cclosegrey.png" id="CurtainClose"
                        class="imgclick imgsize" />
                </div>
                <div class="col-4">
                    <img src="../Images/greyed/cstopgrey.png" id="CurtainStop"
                        class="imgclick imgsize" />
                </div>
            </div>
        </fieldset>

        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.ProjectorControl%>&nbsp;</legend>
            <div class="row marginBottom" style="text-align: center">
                <div class="col-6">
                    <img src="../Images/greyed/proj1.png" id="projgreen"
                        class="imgclick imgsize" />
                </div>
                <div class="col-6">
                    <img src="../Images/greyed/proj2.png" id="projred"
                        class="imgclick  imgsize" />
                </div>
            </div>
        </fieldset>

        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.Light%>&nbsp;</legend>
            <div class="row marginTop" style="text-align: center">
                <div class="col-6">
                    <img src="../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_112.png"
                        id="lighton" class="imgclick imgsize" />
                </div>
                <div class="col-6 ">
                    <img src="../Images/AllImages/全部按钮/控制全页面-默认状态/控制页面_168.png"
                        id="lightoff" class="imgclick imgsize" />
                </div>
            </div>
        </fieldset>

        <input id="InputIP" type="hidden" runat="server" />
        <input id="deviceStatusHidden" type="hidden" value='Offline' />
        <input id="loccam" type="hidden" runat="server"  />


        <fieldset class="fieldSetControl" id="volfieldset">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;音量&nbsp;</legend>
            <div class="row marginBottom">
                <table style="height: auto; width: 100%;">
                    <tr style="align-items: center; width: 100%">
                        <td style="text-align: center; width: 30%">
                            <span style="font-size: x-small"><%=Resources.Resource.Vol %>
                                <img src="../Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png"
                                    id="volsymbol" height="20" />
                            </span>
                        </td>
                        <td style="text-align: center; width: 70%">
                            <input id="vol-control" type="range" min="0" step="1" max="99"
                                onchange="SetVolume(this.value)"
                                style="min-width: 100px; max-width: 90%" />
                            &nbsp;<span id="volchange" style="color: white; font-size: 16px; width: 10%">50</span></td>

                    </tr>

                    <tr style="align-items: center; width: 100%">
                        <td style="text-align: center; width: 30%">
                            <span style="font-size: x-small"><%=Resources.Resource.WiredVol %>
                                <img src="../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png"
                                    id="wiredmicIcon" height="20" />
                            </span>

                        </td>
                        <td style="text-align: center; width: 70%">
                            <input id="wiredmic-control" type="range" min="0"
                                step="1" max="99"
                                onchange="WiredMicControl(this.value)"
                                style="min-width: 100px; max-width: 90%" />
                            <span id="wiredmicchange" style="color: white; font-size: 16px; width: 10%;">50</span></td>
                    </tr>
                    <tr style="align-items: center; width: 100%">
                        <td style="text-align: center; width: 30%">
                            <span style="font-size: x-small"><%=Resources.Resource.WirelessVol %>
                                <img src="../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png"
                                    id="micIcon" height="20" />
                            </span>
                        </td>
                        <td style="text-align: center; width: 70%">
                            <input id="mic-control" type="range" min="0"
                                step="1" max="99"
                                onchange="MicControl(this.value)"
                                style="min-width: 100px; max-width: 90%" />
                            <span id="micchange" style="color: white; font-size: 16px; width: 10%;">50</span></td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
    <script src="../Scripts/SingleTimeControl.js"></script>
</asp:Content>
