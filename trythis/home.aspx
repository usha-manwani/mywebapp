<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebCresij.home" MasterPageFile="~/MastersChild.Master" %>

<asp:Content ContentPlaceHolderID="masterchildHead" ID="headarea" runat="server">
  
    <%--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/normalize.css@8.0.0/normalize.min.css">--%>
    <link href="Content/normalize.min.css" rel="stylesheet" />
    <%--<link href="css/customstyle-responsive.css" rel="stylesheet" />--%>
    <link href="assets/css/charts.css" rel="stylesheet" />
    <link href="Content/Chart.min.css" rel="stylesheet" />
    <%--<link href="https://cdn.jsdelivr.net/npm/chartist@0.11.0/dist/chartist.min.css" rel="stylesheet">--%>
    <%-- <link href="https://cdn.jsdelivr.net/npm/jqvmap@1.5.1/dist/jqvmap.min.css" rel="stylesheet">--%>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.js"></script>--%>
    <script src="Scripts/Chart.min.js"></script>
    <style>
        .modal {
            display: none; /* Hidden by default */
            position: fixed center; /* Stay in place */
            z-index: 1; /* Sit on top */
            margin:auto; /* Location of the box */
            /*left: 0;
            top: 0;*/
            width: 100%; /* Full width */
            /*height: 100%;*/ /* Full height */
            overflow-y: no-display;
            /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.5); /* Black w/ opacity */
            align-items:center;
            justify-content:center;
            /*text-align:center*/
        }

        .modal-content {
            /*display:table-cell;*/
            background-color: #191b28;
            margin: auto;
            position:center;
            border: 1px solid #888;
            width: 50%;
            min-width:300px;
            /*vertical-align:middle;
            position: relative;*/
             top: 35%;
            -webkit-transform: translateY(-50%);
            -ms-transform: translateY(-50%);
            transform: translateY(-50%);
           /*min-height: 90%;*/
        }

        .card-body {
            /*float: left;
            padding: 1em;
            position: relative;
            width: 100%;*/
            font-size: 7%;
            color: white;
        }

        .divstyle {
            background-color: #191b28;
            color: white;
            -moz-box-shadow: inset 0 0 15px #000000;
            -webkit-box-shadow: inset 0 0 15px #000000;
            box-shadow: inset 0 0 15px #000000;
            border-width: 2px 10px 10px 2px;
            min-width:300px;
        }

        .chartjs-tooltip {
            left: 0;
            top: 10px;
            font-family: Arial, sans-serif;
            font-style: normal;
            right: 0;
            display: flex;
            justify-content: center;
            position: absolute;
            z-index: 0;
            height: 100%;
            padding: 0;
            opacity: 1 !important;
            align-items: center;
            color: #c7b427;
            font-size: 12px !important;
        }
        .row{
            margin-bottom:-20px;           
        }
        .custommb{
            margin-top:-3px;
            margin-bottom:-5px;            
        }
        .customchartsize{
            max-width:200px!important;
            min-height:100px!important;
            text-align:center
        }
        
    </style>
    <script>
        var mySessionVariable;
        mySessionVariable = '<%= Session["ipforgraph"] %>';
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="masterchildBody" ID="MainBody" runat="server">

    <script src="Scripts/jquery-3.4.1.min.js"></script>   
    <script src="Scripts/jquery.signalR-2.4.1.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="Scripts/StatusData.js?v=9"></script>
   
    <div class="row" id="ddl" style="background-color: #1e1e36;
        min-height: 100px; min-width:80%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row" style="min-height: 100px;">
                    <div class="col-xl-3 col-lg-3 col-sm-12 col-md-3 mbcustom"
                        style="margin-top: -15px; min-width:100px">
                        <h5><span style="color: white;">
                            <%=Resources.Resource.TempratureChartHead%>
                            </span></h5>
                    </div>
                    <div class=" col-xl-2 col-lg-2 col-md-3 col-sm-12 float-left mbcustom" 
                        style="min-width:100px">
                        <asp:DropDownList Width="100px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                            CssClass="btn btn-default border-light" ID="ddlInstitute" 
                            runat="server" ForeColor="White" BackColor="#1E1E36">                            
                        </asp:DropDownList>
                    </div>
                    <div class="col-xl-2 col-lg-2 col-md-3 col-sm-12 float-none mbcustom"
                        style="min-width:100px">
                        <asp:DropDownList Width="100px" ID="ddlGrade" AutoPostBack="true"
                            CssClass="btn btn-default border dropdown"
                            OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged"
                            runat="server"
                            ForeColor="White" BackColor="#1E1E36">
                            <asp:ListItem Text="<%$Resources:Resource, Select %>"
                                Value="NA"></asp:ListItem>  
                        </asp:DropDownList>
                    </div>
                    <div class="col-xl-2 col-lg-2 col-md-3 col-sm-12 float-right mbcustom "
                        style="min-width:100px">
                        <asp:DropDownList ID="ddlClass" Width="100px" AutoPostBack="true"
                            runat="server" CssClass="btn btn-default border dropdown"
                             OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
                            ForeColor="White" BackColor="#1E1E36">
                            <asp:ListItem Text="<%$Resources:Resource, Select %>"
                                Value="NA"></asp:ListItem>  
                        </asp:DropDownList>
                    </div>
                    <div class="col-xl-2 col-lg-2 float-right" style="min-width:100px">
                        <asp:DropDownList Width="100px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlTime_SelectedIndexChanged"
                            CssClass="btn btn-default border-light" ID="ddlTime"
                            runat="server" ForeColor="White" BackColor="#1E1E36">
                            <asp:ListItem Text="<%$Resources:Resource, Select %>" 
                                Value="0"></asp:ListItem>                            
                            <asp:ListItem Text="Month" Value="month"></asp:ListItem>
                            <asp:ListItem Text="Week" Value="week" ></asp:ListItem>
                            <asp:ListItem Text="WeekDays" Value="days" ></asp:ListItem>
                            <asp:ListItem Text="Date" Value="date" ></asp:ListItem>
                        </asp:DropDownList>                       
                    </div>
                    <div class="col-xl-1 col-lg-1" style="float:right;">
                        <h3><asp:LinkButton runat="server" ID="liveLink" 
                            OnClick="LiveLink_Click" Text="Live">
                            </asp:LinkButton></h3>
                    </div>
                    <asp:Label ID="lbllive" runat="server" CssClass="displaynone"
                        ForeColor="Blue" Font-Underline="true" ></asp:Label>
                    <input id="ipgraph" type="hidden" value="" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
     <div style="clear: both"></div>           

            <div class="row">
                <div class="col-xl-10 col-lg-12 col-md-12 col-sm-12 mbcustom">
                    <div class="row" style="margin-left: -20px;">
                        <div class="col-lg-2 col-md-4 col-sm-6 col-xs-6">
                            <div>
                                <canvas id="c1" height="100%" style="width:100px!important;min-width:50px!important"></canvas>
                                <div id="chartjs-tooltip" class="chartjs-tooltip">
                                    <div class="centered">
                                        <span id ="span1">20</span><br />
                                        <span style="font-size:small; color: white">投影机</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-4 col-sm-6 col-xs-6">
                            <div>
                                <canvas id="c2" height="100%" style="width:100px!important;min-width:50px!important"></canvas>
                                <div id="chartjs-tooltip1" class="chartjs-tooltip">
                                    <div class="centered">
                                        <span id ="span2">200</span><br />
                                        <span style="font-size:small; color: white">电脑</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-4 col-sm-6 col-xs-6">
                            <div>
                                <canvas id="c3" height="100%" style="width:100px!important;min-width:50px!important"></canvas>
                                <div id="chartjs-tooltip2" class="chartjs-tooltip">
                                    <div class="centered">
                                        <span id ="span3">30</span><br />
                                        <span style="font-size:small; color: white">录播</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-4 col-sm-6 col-xs-6">
                            <div>
                                <canvas id="c4" height="100%" style="width:100px!important;min-width:50px!important"></canvas>
                                <div id="chartjs-tooltip5" class="chartjs-tooltip">
                                    <div class="centered">
                                        <span id ="span4">25</span><br />
                                        <span style="font-size:small; color: white">空调</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-4 col-sm-6 col-xs-6">
                            <div id="donutstatus">
                                <canvas id="c5" height="100%" style="width:100px!important; min-width:50px!important"></canvas>
                                <div id="chartjs-tooltip3" class="chartjs-tooltip">
                                    <div class="centered">
                                        <span id="systemspan">68</span>
                                        <br />
                                        <span style="font-size:small; color: white">中控</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-4 col-sm-6 col-xs-6">
                            <div >
                                <canvas id="c6" height="100%" style="width:100px!important;min-width:50px!important"></canvas>
                                <div id="chartjs-tooltip4" class="chartjs-tooltip">
                                    <div class="centered">
                                        <span id ="span6">34</span>
                                        <br />
                                        <span style="font-size:small; color: white">屏幕</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    <div style="clear: both"></div>  
    <div class="row">
        <div class="animated fadeIn col-lg-12 col-md-12 col-sm-12">
            <!-- Widgets-->
            <div class="row">
                <div class="col-sm-6 col-md-4 col-lg-2 col-xl-2 mbcustom" title="Brightness">
                    <div class="card" style="background-color: #5821f0; 
                        height: 120px!important; border: 1px solid #8863f0;
                        min-width:100px">
                        <div class="card-body">
                            <div class="card-left  float-left" style="width: 50%">
                                <span><%=Resources.Resource.brightness%></span>
                                <br />
                                <span id="brightness" style="font-size:small;
                                    font-size-adjust:0.60" 
                                    class="count float-left ">0</span>
                                <span>lx</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right" 
                                style="width: 40%">
                                <img src="Images/中控首页按钮/环境图标/背景图-（03_27.png" 
                                    width="70%" />
                                <%--<i class="wi wi-thermometer" style="font-size:1.5em; color:#967cc5"></i>--%>
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <!--/.col-->
                <div class="col-sm-6  col-md-4 col-lg-2 col-xl-2 mbcustom" title="CO2">
                    <div class="card" style="background-color: #002ced;
                        height: 120px!important; border: 1px solid #758bf0;
                        min-width:100px">
                        <div class="card-body">
                            <div class="card-left float-left" style="width: 50%">
                                <span>CO2</span>
                                <br />
                                <span id="co2value" style="font-size:small;
                                    font-size-adjust:0.60" class="count float-left">0</span>
                                <span>PPM</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right" style="width: 50%">
                                <img src="Images/中控首页按钮/环境图标/背景图-（03_19.png"
                                    width="70%" />
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <!--/.col-->
                <div class="col-sm-6  col-md-4 col-lg-2 col-xl-2 mbcustom" title="Formaldehyde">
                    <div class="card" style="background-color: #0072e7; 
                        height: 120px!important; border: 1px solid #98c3f0;
                        min-width:100px">
                        <div class="card-body">
                            <div class="card-left float-left" style="width: 50%">
                                <span><%=Resources.Resource.formaldehyde%></span>
                                <br />
                                <span id="FormalDehydevalue" class="count float-left">0</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right" style="width: 50%">
                                <img src="Images/中控首页按钮/环境图标/背景图-（03_29.png"
                                    width="70%" />
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <!--/.col-->
                <div class="col-sm-6 col-md-6 col-lg-2 col-xl-2 mbcustom" title="Voltage">
                    <div class="card" style="background-color: #00bee0; 
                        height: 120px!important; border: 1px solid #9adce7;
                        min-width:100px">
                        <div class="card-body">
                            <div class="card-left float-left" style="width: 50%">
                                <span><%=Resources.Resource.Voltage%></span>
                                <br />
                                <span id="voltage" class="count float-left">0</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right" style="width: 50%">
                                <img src="Images/中控首页按钮/环境图标/imgvoltage.png" height="60%"/>
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-6 col-lg-2 col-xl-2 mbcustom" title="Electricity">
                    <div class="card" style="background-color: #01cc56; 
                        height: 120px!important; border: 1px solid #86e9af; 
                        min-width:100px">
                        <div class="card-body">
                            <div class="card-left float-left" style="width: 50%">
                                <span><%=Resources.Resource.Electricity%></span>
                                <br />
                                <span id="Electricity" class="count float-left">0</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right" style="width: 50%">
                                <img src="Images/中控首页按钮/环境图标/imgelec.png" width="70%" />
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
            </div>
           
            <div style="clear: both"></div>

            <div class="row">
                <div class="col-xl-10 col-lg-12 col-md-12 col-sm-12 mbcustom fullWidth3">
                    <div class="row">
                        <div class="col-xl-4 col-lg-6 col-md-12 col-sm-12 fullWidth2">
                            <div class="card" style="background-color: #191b28; height: 250px">
                                 
                                <div class="card-body divstyle" id="systemDiv"
                                    align="center" style="margin-top:2px ">                                    
                                   
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-4 col-lg-6 col-md-12 col-sm-12 fullWidth2">
                            <div class="card" style="background-color: #191b28; height: 250px">
                                <div class="card-body divstyle" id="BarChart">
                                    <div style="max-height:200px" id="usedhourdiv">
                                    <h4 class="mb-3 custommb" style="text-align:center; 
                                        font-weight: bold;">
                                        <span>使用时间</span></h4>
                                    <canvas id="UsedBarChart" style="max-height: 150px">
                                    </canvas></div>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-4 col-lg-6 col-md-12 col-sm-12 fullWidth2">
                            <div class="card" style="background-color: #191b28; height: 250px">
                                <div class="card-body divstyle" id="humdiv1">
                                    <div>
                                        <h5 class="mb-3 custommb" style="text-align:center;
                                            font-weight: bold;">
                                            <%=Resources.Resource.EnerygyNVoltage%>
                                        </h5>
                                        <div style="width: 45%; float:left; height:80%">
                                            <canvas id="Speedometer"  
                                                width="80%" height="65%"></canvas>
                                        </div>
                                        
                                        <div style="width: 45%; float: left; height:80%">
                                            <canvas id="Speedometer1" 
                                                width="80%" height="65%"></canvas>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-4 col-lg-6 col-md-12 col-sm-12 fullWidth2">
                            <div class="card" style="background-color: #191b28; height: 250px">
                                <div class="card-body divstyle" id="carbonDiv">
                                    <div>
                                    <h4 class="mb-3 custommb" style="text-align: center;
                                        font-weight: bold;"><span>CO2 浓度</span> </h4>
                                    <canvas id="carbondonut" style="max-height:75%"></canvas>
                                        </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-4 col-lg-6 col-md-12 col-sm-12 fullWidth2">
                            <div class="card" style="background-color: #191b28; height: 250px">
                                <div class="card-body divstyle" id="brightdiv" 
                                    style="text-align:center">
                                    <div>
                                        <h4 class="mb-3 custommb" style="text-align: center; 
                                            font-weight: bold;"><span>
                                            <%=Resources.Resource.brightness%>
                                                </span></h4>
                                        <canvas id="brightdonut" 
                                            style="max-height:70%;
                                            max-width:100%"></canvas>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-4 col-lg-6 col-md-12 col-sm-12 fullWidth2">
                            <div class="card" style="background-color: #191b28; height: 250px">
                                <div class="card-body divstyle" id="metanaldiv" align="center" >
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>

            <div class="row" style="margin-bottom:-50px">
                <div class="col-xl-5 col-lg-12 col-md-12 col-sm-12  mbcustom fullWidth1">
                    <div class="card" style="background-color: #191b28;
                        height: 350px;min-width:380px">
                        <div class="card-body divstyle" >
                            <div style="height: 280px;" id="teamdiv">
                                <h4 class="mb-3 custommb" style="text-align: center;
                                    font-weight: bold;"><span>
                                    <%=Resources.Resource.Temperature%>
                                                        </span></h4>
                                <canvas id="team-chart"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-xl-5 col-lg-12 col-md-12 col-sm-12 mbcustom fullWidth1">
                    <div class="card" style="background-color: #191b28;
                        height: 350px; min-width:380px">
                        <div class="card-body divstyle" >
                            <div style="height: 270px" id="humdiv">
                                <h4 class="mb-3 custommb" style="text-align:center;
                                    font-weight: bold; "><span>
                                    <%=Resources.Resource.Humidity%>
                                                         </span> </h4>
                                <canvas id="lineChart" ></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both"></div>
        </div>
    </div>

    <%--<asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="25000" />
    <div style="display: none">
        <asp:UpdatePanel runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" />
            </Triggers>
            <ContentTemplate>
                <span id="machineStatus" runat="server"></span>
                <span id="work" runat="server"></span>
                <span id="machineStatus1" runat="server"></span>
                <span id="work1" runat="server"></span>
                <span id="total" runat="server"></span>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>--%>

    <div class="modal" id="TempModal">
        <div class="modal-content" >            
            <div style="display:table; text-align:center; color:white">
                <div>Temperature Current Value: 22</div>
                <div> Temperature Average value for the current week: 23</div>
                <div> Temperature Average value for the current month : 28</div>                
            </div>
            <div class="centered row" style="padding-right:20px;padding-left:10px; min-height:250px;"> 
                <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6" >
                    <canvas id="tempModalChartMonth" class="customchartsize" >
                </canvas></div>
                 <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6" >
                     <canvas id="tempModalChartDate" class="customchartsize">
                </canvas>
                 </div>
                 <div class="col-xl-4 col-lg-4 col-md-6 col-sm-6" >
                     <canvas id="tempModalChartLive" class="customchartsize">
                </canvas></div>
                <%--<span style="text-align:center">Temperature</span>--%>
           </div>
        </div>
    </div>
        
    <div class="modal" id="HumidModal">
        <div class="modal-content">
            <div>
                <div style="width:50%; float:left">
                    <div>Current Humidity Value: </div>
                     <div>Current PM10 Value: </div>
                     <div>Current PM2.5 Value:</div>
                </div>
                <div style="width:50%; float:right">
                     <div>Normal Humidity Value:</div>
                     <div>Normal PM10 Value: </div>
                     <div>Normal PM2.5 Value:</div>
                </div>
            </div>
            <div >
                <canvas id="HumidChartModal">
                </canvas>
            </div>
        </div>
    </div>
    
    <%--<script src="https://cdn.jsdelivr.net/npm/jquery-match-height@0.7.2/dist/jquery.matchHeight.min.js"></script>--%>
    <!--  Chart js -->
    <%--<script src="https://cdn.jsdelivr.net/npm/chart.js@2.7.3/dist/Chart.bundle.min.js"></script>--%>

    <script src="Scripts/jquery.matchHeight.js"></script>
    <script src="assets/js/main.js"></script>
    <script src="Scripts/Chart.bundle.min.js"></script>
    <script src="lib/gauge.js?v=1"></script>
    <script src="ScriptsLInks/highcharts.js"></script>
    <script src="ScriptsLInks/highcharts-more.js"></script>
    <script src="ScriptsLInks/highcharts-3d.js"></script>
    <script src="ScriptsLInks/modules/no-data-to-display.js"></script>
    <script>
        Highcharts.setOptions({ lang: { noData: "No Data to Display" } });
            var pieColors = (function () {
                var colors = [],
                    base = Highcharts.getOptions().colors[0],
                    i;

                for (i = 0; i < 10; i += 1) {
                    // Start out with a darkened base color (negative brighten), and end
                    // up with a much brighter color
                    colors.push(Highcharts.Color(base).brighten((i - 3) / 7).get());
                }
                return colors;
            }());
            var cccc = Highcharts.chart('systemDiv', {
                chart: {
                    backgroundColor: 'transparent',
                    plotBackgroundColor: 'transparent',
                    type: 'pie',
                    animation: {
                        enabled: false,
                    },

                    //options3d: {
                    //    enabled: true,
                    //    alpha: 45,
                    //    beta: 0
                    //}
                },

                title: {                    
                    text: '系统状态',
                    style: {
                        color: '#fff',
                        textTransform: 'uppercase',
                        fontSize: '16px',
                        fontFamily:"'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                        fontWeight: 'bold'
                    }
                },
                tooltip: {
                    pointFormat: '<b>{point.y}</b>'
                },
                plotOptions: {
                    pie: {

                        borderWidth: 0,
                        shadow: false,
                        center: ['50%', '50%'],
                        innerSize: 50,
                        allowPointSelect: true,
                        colors: pieColors,
                        cursor: 'pointer',
                        depth: 30,
                        dataLabels: {
                            enabled: true,
                            format: '{point.name}',
                            style: {
                                fontFamily: "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                                lineHeight: '18px', fontSize: '12px', color: '#fff',
                                stroke: 'none', fontWeight:'normal'
                            }
                        }
                    }
                },
                credits: {
                    enabled: false
                },
                series: [{

                    size: '100%',
                    innerSize: '75%',
                    slicedOffset: 20,

                    name: '系统状态',
                    data: [

                        {
                            name: '在线',
                            y: 90,
                            selected: true
                        },
                        ['离线', 15],
                    ],
                }, {
                    type: 'pie',
                    size: '50%',
                    innerSize: '30%',
                    slicedOffset: 10,
                    name: '系统状态',
                    data: [
                        ['待机', 10],
                        {
                            name: '使用中',
                            y: 50,
                            selected: true
                        },
                    ],
                }],
                scrollbar: {
                    // dont call setExtremes with each move of the scrollbar
                    liveRedraw: false
                }
            });

            var ccc = Highcharts.chart('metanaldiv', {
                chart: {
                    backgroundColor: 'transparent',
                    plotBackgroundColor: 'transparent',
                    type: 'pie',
                    animation: {
                        duration: 1000
                    },
                    options3d: {
                        enabled: true,
                        alpha: 45,
                        beta: 0
                    }
                },
                title: {
                    text: '甲醛',
                    dispaly: false,
                    style: {

                        color: '#fff',
                        textTransform: 'uppercase',
                        fontSize: '16px',
                        fontWeight: 'bold'
                    }
                },
                tooltip: {
                    pointFormat: ' <b>{point.percentage:.f}%</b>'
                },
                plotOptions: {
                    pie: {
                        size: '90%',
                        allowPointSelect: true,
                        colors: pieColors,
                        cursor: 'pointer',
                        depth: 30,
                        dataLabels: {
                            enabled: true,
                            format: '{point.name}',
                            style: { fontFamily: "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                                lineHeight: '18px', fontSize: '12px', color: '#fff',
                                stroke: 'none', fontWeight:'normal' }
                        }
                    }
                },
                credits: {
                    enabled: false
                },
                series: [{
                    type: 'pie',
                    name: '甲醛',
                    data: [
                        ['含量', 60.4],

                        {
                            name: '甲醛',
                            y: 39.6,
                            sliced: true,
                            selected: true
                        },

                    ]
                }],
                scrollbar: {
                    // dont call setExtremes with each move of the scrollbar
                    liveRedraw: false
                }
            });
  
    </script>

    <link href="css/style.css" rel="stylesheet">
    <link href="css/style-responsive.css" rel="stylesheet">
</asp:Content>
