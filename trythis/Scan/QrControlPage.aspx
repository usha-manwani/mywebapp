<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Mobile.Master"
    AutoEventWireup="true" CodeBehind="QrControlPage.aspx.cs" Inherits="WebCresij.Scan.QrControlPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .imgsize {
            /*width: 80%;*/
            max-width: 80%;
            width:50px;
            min-width: 25px;
        }
        .imgsize1{
            max-width:100%;
            min-width:25px;
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
    </style>
    <script src="../Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="../Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100% !important">
    <div class="bck row">            
        <asp:LinkButton runat="server" CssClass="col-6" Text="<%$Resources:Resource, SignOut %>"
             OnClick="logout_Click" style="text-align:left" ID="logout"></asp:LinkButton>
            <asp:LinkButton runat="server" ID="gotoFault" Text="<%$Resources:Resource, AddNewFaultInfo %>"
                OnClick="gotoFault_Click" CssClass="col-6" style="text-align:right"></asp:LinkButton>            
        
    </div>
    
    <div class="clearfix"></div>
    <div class=" positionCenter noborder">
        <asp:HiddenField runat="server" ID="iptoControl" />
        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.SystemControl%>&nbsp;</legend>
            <div class="row">
                <div class="col" style="text-align: center">
                    <%--<i class="fas fa-power-off imgclick imgback" style="font-size:4rem"
                 id="syspower"></i>--%>
                    <img src="../Images/greyed/sysgrey.png" id="syspower"
                        class="imgclick imgsize" />
                </div>

                
            </div>
        </fieldset>

        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.MediaSignal%>&nbsp;</legend>
            <div class="row" >
                <div class="col-4" style="text-align: center">
                    <img src="../Images/greyed/desktop.png" id="desktop"
                        class="imgclick imgsize1" />
                </div>
                <div class="col-4" style="text-align: center">
                    <img src="../Images/greyed/laptop.png" id="laptop"
                        class="imgclick imgsize1" />
                </div>
                <div class="col-4" style="text-align: center">
                    <img src="../Images/AllImages/images/图标_194.png" id="Moremedia"
                        class="imgclick imgsize1" />
                </div>
            </div>
        </fieldset>
        <fieldset class="fieldSetControl">
            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;<%=Resources.Resource.ProjectorAndPC%>&nbsp;</legend>
            <div class="row" >
            <div class="col-4">
                <img src="../Images/greyed/proj1.png" id="projgreen"
                    class="imgclick imgsize1" />
            </div>
            <div class="col-4">
                <img src="../Images/greyed/proj2.png" id="projred"
                    class="imgclick imgsize1" />
            </div>
            <div class="col-4">
                            <img src="../Images/greyed/pcgrey.png" id="ppower"
                                class="imgclick imgsize1"/>
            </div>
                </div>
        </fieldset>

        <fieldset class="fieldSetControl" id="volfieldset" style="background-color: #1e1e36;align-content:center">
                            <legend align="center" style="width: auto; font-size: 16px;">&nbsp;音量&nbsp;</legend>
                      
                        <table style="height: auto;width:100%;max-width:500px; margin:0 auto">
                            <tr style="align-items: center; width:100%">
                                <td style="text-align: center;  width: 30%">
                                    <span style="font-size:x-small"><%=Resources.Resource.Vol %>
                                        <img src="../Images/AllImages/全部按钮/控制全页面-默认状态/总音量.png"
                                            id="volsymbol" height="20" />
                                    </span>
                                </td>
                                <td style="text-align: center;  width: 70%">
                                    <input id="vol-control" type="range" min="0" step="1" max="99"
                                        onchange="SetVolume(this.value)"
                                        style="min-width: 100px; max-width:90%" />
                                    &nbsp;<span id="volchange" style="color: white; font-size: 16px; width: 10%">50</span></td>

                            </tr>
                            <tr style="align-items: center; width:100%">
                                <td style="text-align: center; width: 30%">
                                    <span style="font-size:x-small"><%=Resources.Resource.WiredVol %>
                                        <img src="../Images/AllImages/全部按钮/控制全页面-默认状态/有线麦音量.png"
                                            id="wiredmicIcon" height="20" />
                                    </span>
                                  
                                </td>
                                <td style="text-align: center;  width: 70%">
                                    <input id="wiredmic-control" type="range" min="0"
                                        step="1" max="99"
                                        onchange="WiredMicControl(this.value)"
                                        style="min-width: 100px; max-width:90%" />
                                    <span id="wiredmicchange" style="color: white; font-size: 16px; width: 10%;">50</span></td>
                            </tr>
                            <tr style="align-items: center; width:100%">
                                <td style="text-align: center; width: 30%">
                                    <span style="font-size:x-small"><%=Resources.Resource.WirelessVol %>
                                        <img src="../Images/AllImages/全部按钮/控制全页面-默认状态/无线麦音量.png"
                                            id="micIcon" height="20" />
                                    </span>
                                </td>
                                <td style="text-align: center;  width: 70%">
                                    <input id="mic-control" type="range" min="0"
                                        step="1" max="99"
                                        onchange="MicControl(this.value)"
                                        style="min-width: 100px; max-width:90%" />
                                    <span id="micchange" style="color: white; font-size: 16px; width: 10%;">50</span></td>
                            </tr>                            
                        </table>
                        
            </fieldset>

    </div>
    <div class="clearfix"></div>
        </div>
    <script src="QrControl.js?version=6"></script>
        
</asp:Content>
