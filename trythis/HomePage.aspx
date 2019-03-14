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
        .imgsize{
            height:80px;
            width:80px
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
            width: 60%;
            border-width: 1px;
            border-top-color: #68afd0
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
            padding-top: 150px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow-y:no-display;
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
        }
        .blueDiv{
            height: 25%; 
            width: 90%; 
            border-bottom: 10px solid #1e1e36;
            background-color: #4182cf; 
            text-align:center;
            padding-top:10%;
            padding-left:5%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
   <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
        <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>    
        <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' > </script>
    <script src="Scripts/HomePageJS.js?version=3"></script>
    <div class="row" style="padding-left: 100px;max-width: 100%; min-width: 70%; ">       
            <div class="col-lg-8 col-md-8 col-sm-12">
                <div class="row shadowRow" style="max-height: 540px; max-width: 960px;">
                    <div class="col-lg-9 col-md-9 col-sm-12">
                        <div style="-moz-box-shadow: inset 0 0 15px #000000; -webkit-box-shadow: inset 0 0 15px #000000;
                            box-shadow: inset 0 0 15px #000000; border-width: 0 20px 20px 0; max-height: 650px;">
                          
                                <img src="Images/详细页图标/背景图-.jpg" height="100%" width="100%" />
                                                      
                    </div>
                        </div>
                    <div class="col-lg-3 col-md-3 col-sm-12 " style="color:white">
                        <div class="row blueDiv" >No Signal</div>
                        <div class="row blueDiv" >No Signal</div>
                        <div class="row blueDiv" >No Signal</div>
                        <div class="row blueDiv" >No Signal</div>
                    </div>
                    </div>
                <div class="row" style="margin-bottom: -100px; margin-left:-50px">
                    <div class="col-lg-4 col-md-4 col-sm-6">
                        
                        <div class="row">
                            <img src="Images/icons/images/背景图-（03_03.png" />
                            <div class="col-lg-4 col-md-1 col-sm-1"><span>
                                        <img src="Images/icons/images/背景图-（03_18.png" id="systempower"
                                             class="imgclick imgsize" /></span></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_20.png" id="pcpower"
                                             class="imgclick imgsize" /></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_22.png" id="lock"
                                            class="imgclick imgsize" /></div>
                        </div>
                       
                        <%--<table style="height: auto; width: 100%;">
                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_18.png" id="systempower"
                                             class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_20.png" id="pcpower"
                                             class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_22.png" id="lock"
                                            class="imgclick imgsize" /></span>
                                </td>
                            </tr>
                        </table>--%>
                        
                        <div class="row">
                            <img src="Images/icons/images/背景图-（03_40.png" />
                            <div class="col-lg-4 col-md-1 col-sm-1"><span>
                                        <img src="Images/icons/images/背景图-（03_53.png" id="Scup"
                                             class="imgclick imgsize" /></span></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_55.png" id="Scdown"
                                             class="imgclick imgsize" /></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_57.png" id="scStop"
                                             class="imgclick imgsize" /></div>
                        </div>
                        <%--<table style="height: auto; width: 100%;">
                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_53.png" id="Scup"
                                             class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_55.png" id="Scdown"
                                             class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_57.png" id="scStop"
                                             class="imgclick imgsize" /></span>
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-6">
                       
                        <div class="row">
                             <img src="Images/icons/images/背景图-（03_05.png" />
                            <div class="col-lg-4 col-md-1 col-sm-1"><span>
                                        <img src="Images/icons/images/背景图-（03_29.png" id="desktop1"
                                             class="imgclick imgsize" /></span></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"> <img src="Images/icons/images/背景图-（03_24.png" id="desktop2"
                                             class="imgclick imgsize" /></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_26.png" id="desktop3"
                                             class="imgclick imgsize" /></div>
                        </div>
                      <%--  <table style="height: auto; width: 100%;">
                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_29.png" id="desktop1"
                                             class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_24.png" id="desktop2"
                                             class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_26.png" id="desktop3"
                                             class="imgclick imgsize" /></span>
                                </td>
                            </tr>
                        </table>--%>
                       
                        <div class="row">
                             <img src="Images/icons/images/背景图-（03_42.png" />
                            <div class="col-lg-4 col-md-1 col-sm-1"><span>
                                        <img src="Images/icons/images/背景图-（03_47.png" id="CurtainOpen"
                                             class="imgclick imgsize" /></span></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_49.png" id="CurtainClose"
                                            class="imgclick imgsize" /></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_51.png" id="CurtainStop"
                                             class="imgclick imgsize" /></div>
                        </div>
                       <%-- <table style="height: auto; width: 100%;">
                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_47.png" id="Curtainopen"
                                             class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_49.png" id="CurtainClose"
                                            class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_51.png" id="CurtainStop"
                                             class="imgclick imgsize" /></span>
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-6">
                        
                        
                        <div class="row">
                            <img src="Images/icons/images/背景图-（03_07.png"  />
                            <div class="col-lg-4  col-md-1 col-sm-1"><span>
                                       <img src="Images/icons/images/背景图-（03_11.png" id="projgreen"
                                            class="imgclick imgsize" /></span></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_13.png" id="projred"
                                             class="imgclick  imgsize" /></div>
                            <div class="col-lg-4 col-md-1 col-sm-1"><img src="Images/icons/images/背景图-（03_15.png" id="projorange"
                                             class="imgclick  imgsize" /></div>
                        </div>
                       <%-- <table style="height: auto; width: 100%;">
                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_11.png" id="projgreen"
                                            class="imgclick imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_13.png" id="projred"
                                             class="imgclick  imgsize" /></span>
                                </td>
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/背景图-（03_15.png" id="projorange"
                                             class="imgclick  imgsize" /></span>
                                </td>
                            </tr>
                        </table>--%>
                        <div class="row">
                        <img src="Images/icons/images/背景图-（03_38.png"/>                        
                        <table style="height: auto; width: 100%;">
                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/主音量.png" height="30" width="40" />
                                        <img src="Images/icons/images/背景图-（03_60.png" id="volume"
                                            height="30" width="75%" class="imgclick" /></span>
                                </td>
                                <td rowspan=2 style="text-align: center">
                                    <span>
                                        <img src="Images/icons/icons/ddd.png" class="imgclick" onclick="DisplayModal(); return false;"/></span>
                                </td>
                            </tr>
                            <tr style="align-items: center; align-content: center;">
                                <td style="text-align: center">
                                    <span>
                                        <img src="Images/icons/images/话筒音量.png" height="40" width="40" />
                                        <img src="Images/icons/images/背景图-（03_60.png" id="mic"
                                            height="30" width="75%" class="imgclick" /></span>
                                </td>
                            </tr>
                        </table>
                            </div>
                        <input id="InputIP" type="hidden" value='<%= Session["DeviceIP"] %>' />
                    </div>
                </div>
                </div>
                
            
            <div class="col-lg-2 col-md-3 col-sm-12" style="max-height: 80%; ">
                <div class="row " style="border:1px solid white; margin-bottom:15px;">
                    <p style="color:white">
<script> document.write(new Date().toDateString()); </script>
</p><br/><p style="color:white">ClassName:  &nbsp;<script>document.write('<%= Session["LocToDisplay"] %>')</script></p><br />
                    <p style="color:white">Device IP: &nbsp;<script>document.write('<%= Session["DeviceIP"] %>')</script></p>
                     
                </div>
                <div class="row" style="border: 1px dashed #aeb2b7; min-height: 10%;">
                    <span style="text-align: center">
                        <img src="Images/icons/icons/背景图-（03_07.png" height="50" width="40" />
                    </span>
                </div>
                <div class="row" style="border: 1px dashed #aeb2b7;min-height: 10%;" >
                    <span style="text-align: center">
                        <img src="Images/icons/icons/背景图-（03_09.png" height="50" width="55" />
                    </span>
                </div>
                <div class="row" style="border: 1px dashed #aeb2b7;min-height: 10%;" >
                    <span style="text-align: center">
                        <img src="Images/icons/icons/背景图-（03_17.png" height="50" width="40"/>                        
                                               
                    </span>
                </div>
                <div class="row" style="border: 1px dashed #aeb2b7;min-height: 10%; ">
                    <span style="text-align: center">       
                        <img src="Images/icons/icons/背景图-（03_19.png" height="48" width="60"/>                 
                    </span>
                </div>
                <div class="row" style="border: 1px dashed #aeb2b7;min-height: 10%; ">
                      <span style="text-align: center">
                          <img src="Images/icons/icons/背景图-（03_27.png" height="50" width="50"/>
                     </span>
                </div>
                <div class="row" style="border: 1px dashed #aeb2b7;min-height: 10%; ">
                    <span style="text-align: center">
                        <img src="Images/icons/icons/背景图-（03_29.png" height="50" width="60"/>
                    </span>
                </div>
                <div class="row" style="border: 1px dashed #aeb2b7;min-height: 10%; ">
                    <span style="text-align: center">
                        <img src="Images/icons/icons/背景图-（03_37.png" height="50" width="50"/>                    
                    </span>
                </div>
                <div class="row" style="border: 1px dashed #aeb2b7; min-height: 10%;">
                    <span style="text-align: center">
                        <img src="Images/icons/icons/背景图-（03_39.png" height="50" width="70"/>
                    </span>
                </div>
            </div>
            <div class="col-lg-2 col-md-1"></div>
        </div>
            <div id="RemoteControl" class="modal">
                <div class="modal-content">
                    <header class="row" style="position: center; ">
                        <span onclick="document.getElementById('RemoteControl').style.display='none'"
                            class="w3-button w3-display-topright">&times;</span>                        
                    </header>
                    <div class="row">
                        <iframe  id="Iframe1" style="background-color:#1e1e36" src="~/controlRemote.aspx" height="500" width="100%" runat="server" frameborder="0"></iframe>
                    </div>
                </div>
            </div>
    
       <script>
            function DisplayModal() {
                
                document.getElementById("RemoteControl").style.display = "block";
            };
            window.onclick = function (event) {
            if (event.target == modal) {
                document.getElementById("RemoteControl").style.display = "none";
            }
            };
       </script>
</asp:Content>
