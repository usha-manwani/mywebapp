<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebCresij.home" MasterPageFile="~/MastersChild.Master" %>

<asp:Content ContentPlaceHolderID="masterchildHead" ID="headarea" runat="server">

    <%--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/normalize.css@8.0.0/normalize.min.css">--%>
    <link href="Content/normalize.min.css" rel="stylesheet" />
    
    <%-- <link rel="stylesheet" href="assets/css/style.css">  --%>
    <link href="assets/css/charts.css" rel="stylesheet" />
    <link href="Content/Chart.min.css" rel="stylesheet" />
    <%--<link href="https://cdn.jsdelivr.net/npm/chartist@0.11.0/dist/chartist.min.css" rel="stylesheet">--%>
   <%-- <link href="https://cdn.jsdelivr.net/npm/jqvmap@1.5.1/dist/jqvmap.min.css" rel="stylesheet">--%>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.js"></script>--%>
    <script src="Scripts/Chart.min.js"></script>
    <style>
        canvas {
            max-width: 100%;
        }

        .card-body {
            /*float: left;
            padding: 1em;
            position: relative;
            width: 100%;*/
            font-size: small;
            color: white;
        }

        .divstyle {
            background-color: #191b28;
            color: white;
            -moz-box-shadow: inset 0 0 15px #000000;
            -webkit-box-shadow: inset 0 0 15px #000000;
            box-shadow: inset 0 0 15px #000000;
            border-width: 2px 10px 10px 2px;
        }

        .chartjs-tooltip {
            left: 0;
            top: 50px;
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
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="masterchildBody" ID="MainBody" runat="server">
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
    <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'></script>
    <script src="Scripts/StatusData.js?v=4"></script>

    <div class="row " id="ddl" style="background-color: #1e1e36; height: 100px">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="row" style="min-height: 100px; min-width:1000px;">
                    <div class="col-lg-6 col-sm-12 " style="margin-top:-15px">
                        <h5 ><span style="color: white; "><%=Resources.Resource.TempratureChartHead%></span> </h5>
                    </div>
                    <div class=" col-lg-2 col-md-4 col-sm-4 float-left">
                        <asp:DropDownList Width="150px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                            CssClass="btn btn-default border-light" ID="ddlInstitute"
                            data-toggle="dropdown" runat="server" ForeColor="White" BackColor="#1E1E36">
                            <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2 col-md-4 col-sm-4 float-none">
                        <asp:DropDownList Width="150px" ID="ddlGrade" AutoPostBack="true"
                            CssClass="btn btn-default border dropdown" data-toggle="dropdown"
                            OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server"
                            ForeColor="White" BackColor="#1E1E36">
                            <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-2 col-md-4 col-sm-4 float-right">
                        <asp:DropDownList ID="ddlClass" Width="150px" AutoPostBack="true"
                            runat="server" CssClass="btn btn-default border dropdown"
                            data-toggle="dropdown" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
                            ForeColor="White" BackColor="#1E1E36">
                            <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="lblip" runat="server" CssClass="displaynone"
                        Text='<%#Session["ipforgraph"]%>'></asp:Label>
                    <input id="ipgraph" type="hidden" value='<%=Session["ipforgraph"] %>' />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div class="row">
        <div class="animated fadeIn col-lg-12 col-md-12 col-sm-12">
            <!-- Widgets  -->
            <div class="row" style="height: 150px!important">
                <div class="col-sm-6  col-md-4 col-lg-2" title="Brightness">
                    <div class="card" style="background-color: #5821f0; height: 120px!important; border: 1px solid #8863f0">
                        <div class="card-body">
                            <div class="card-left  float-left">
                                <span><%=Resources.Resource.brightness%></span>
                                <br />
                                <span id="brightness" class="count float-left ">0</span>
                                <span>lx</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right">
                                <img src="Images/中控首页按钮/环境图标/背景图-（03_27.png" height="60" width="60" />
                                <%--<i class="wi wi-thermometer" style="font-size:1.5em; color:#967cc5"></i>--%>
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <!--/.col-->
                <div class="col-sm-6  col-md-4 col-lg-2" title="CO2">
                    <div class="card" style="background-color: #002ced; height: 120px!important; border: 1px solid #758bf0">
                        <div class="card-body">
                            <div class="card-left float-left">
                                <span>CO2</span>
                                <br />
                                <span id="humidvalue" class="count float-left">0</span>
                                <span>PPM</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right">
                                <img src="Images/中控首页按钮/环境图标/背景图-（03_19.png" height="60" width="80" />
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <!--/.col-->
                <div class="col-sm-6  col-md-4 col-lg-2" title="Formaldehyde">
                    <div class="card" style="background-color: #0072e7; height: 120px!important; border: 1px solid #98c3f0">
                        <div class="card-body">
                            <div class="card-left float-left">
                                <span><%=Resources.Resource.formaldehyde%></span>
                                <br />
                                <span id="FormalDehydevalue" class="count float-left">0</span>

                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right">
                                <img src="Images/中控首页按钮/环境图标/背景图-（03_29.png" height="70" width="70" />
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <!--/.col-->
                <div class="col-sm-6 col-md-4 col-lg-2" title="Voltage">
                    <div class="card" style="background-color: #00bee0; height: 120px!important; border: 1px solid #9adce7">
                        <div class="card-body">
                            <div class="card-left float-left">
                                <span><%=Resources.Resource.Voltage%></span>
                                <br />
                                <span id="voltage" class="count float-left">0</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right">

                                <img src="Images/中控首页按钮/环境图标/imgvoltage.png" height="60" width="60" />
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-md-4 col-lg-2" title="Electricity">
                    <div class="card" style="background-color: #01cc56; height: 120px!important; border: 1px solid #86e9af">
                        <div class="card-body">
                            <div class="card-left float-left">
                                <span><%=Resources.Resource.Electricity%></span>
                                <br />
                                <span id="Electricity" class="count float-left">0</span>
                            </div>
                            <!-- /.card-left -->
                            <div class="card-right float-right text-right">
                                <img src="Images/中控首页按钮/环境图标/imgelec.png" height="60" width="60" />
                            </div>
                            <!-- /.card-right -->
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear:both"></div>
            <div class="row" style="min-height:350px;margin-bottom:-40px">
                <div class="col-lg-5 col-md-10 col-sm-12">
                    <div class="card" style="background-color: #191b28">
                        
                        <div class="card-body divstyle" id="teamdiv">
                            <h4 class="mb-3" style="text-align:center;font-size:20px;font-weight:bold;margin-top:-5px"><span><%=Resources.Resource.Temperature%></span></h4>
                            <canvas id="team-chart" style="color: white"></canvas>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5 col-md-10 col-sm-12">
                    <div class="card" style="background-color: #191b28">
                        <div class="card-body divstyle" id="humdiv">
                            <h4 class="mb-3" style="text-align:center;font-size:20px;font-weight:bold;margin-top:-5px"><span><%=Resources.Resource.Humidity%></span> </h4>
                            <canvas id="lineChart"></canvas>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear:both"></div>

            <div class="row" style="min-height:250px; ">
                <div class="col-lg-10 col-md-12 col-sm-12" style="margin-bottom:-90px">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <div class="card" style="background-color: #191b28;">
                                
                                <div class="card-body divstyle"  id="systemDiv">
                                    
                                    <%--<h4 class="mb-3"> <span>System</span> </h4>
                                <canvas id="systemdonut"></canvas>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <div class="card" style="background-color: #191b28">
                                <div class="card-body divstyle" id="BarChart">
                                    <h4 class="mb-3" style="text-align:center;font-size:20px;font-weight:bold; margin-top:-5px"><span>使用时间</span> </h4>
                                    <canvas id="UsedBarChart"></canvas>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <div class="card" style="background-color: #191b28">
                                <div class="card-body divstyle" id="humdiv1">
                                    <h5 class="mb-3" style="text-align:center;font-size:20px;font-weight:bold; margin-top:-5px"><span><%=Resources.Resource.EnerygyNVoltage%></span> </h5>
                                    <div style="width: 50%; float: left; ">
                                        
                                        <canvas id="Speedometer" width="100%" height="88%"></canvas>
                                    </div>
                                    <div style="width: 50%; float: right" >
                                        <canvas id="Speedometer1" width="100%" height="88%"></canvas>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             <div style="clear:both"></div>
            <div class="row" style="min-height:250px">
                <div class="col-lg-10 col-md-12 col-sm-12">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <div class="card" style="background-color: #191b28">
                                <div class="card-body divstyle" id="carbonDiv">
                                    <h4 class="mb-3" style="text-align:center;font-size:20px;font-weight:bold; margin-top:-5px"><span>CO2 浓度</span> </h4>
                                    <canvas id="carbondonut"></canvas>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <div class="card" style="background-color: #191b28">
                                <div class="card-body divstyle" id="brightdiv">
                                    <h4 class="mb-3" style="text-align:center;font-size:20px;font-weight:bold; margin-top:-5px"><span><%=Resources.Resource.brightness%></span> </h4>
                                    <canvas id="brightdonut"></canvas>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-12" style="height:100%">
                            <div class="card" style="background-color: #191b28">
                                
                                <div class="card-body divstyle" id="metanaldiv" style="height:100%">
                                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row" style="height: 80px">
                <div class="col-lg-10 col-md-12 col-sm-12">
                    <div class="row" style="margin-left: -20px; margin-top: -70px; height: 70px!important;">
                        <div class="col-lg-2 col-md-3 col-sm-6">
                            <div >
                                <canvas id="c1" width="100%" height="100%"></canvas>
                                <div id="chartjs-tooltip" class="chartjs-tooltip">
                                    <div><span style="padding-left: 20px;">20</span><br />
                                        <span style="font-size: smaller; color: white">投影机</span> </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-lg-2 col-md-3 col-sm-6">
                            <div >
                                <canvas id="c2" width="100%" height="100%"></canvas>
                                <div id="chartjs-tooltip1" class="chartjs-tooltip">
                                    <div><span style="padding-left: 20px;">200</span><br />
                                        <span style="font-size: smaller; color: white">电脑</span></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-3 col-sm-6">
                            <div style="height: 70px!important;">
                                <canvas id="c3" width="100%" height="100%"></canvas>
                                <div id="chartjs-tooltip2" class="chartjs-tooltip">
                                    <div><span style="padding-left: 5px;">30</span><br />
                                        <span style="font-size: smaller; color: white">录播</span></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-3 col-sm-6">
                            <div >
                                <canvas id="c4" width="100%" height="100%"></canvas>
                                <div id="chartjs-tooltip5" class="chartjs-tooltip">
                                    <div><span style="padding-left: 0;">25</span><br />
                                        <span style="font-size: smaller; color: white">空调</span></div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-3 col-sm-6">
                            <div >
                                <canvas id="c5" width="100%" height="100%"></canvas>
                                <div id="chartjs-tooltip3" class="chartjs-tooltip">
                                    <div style="text-align:center;" >
                                        <span style="margin-top:50px;">68</span>
                                        <br />
                                        <span style="font-size: smaller; color: white">中控</span>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-3 col-sm-6">
                            <div >
                                <canvas id="c6" width="100%" height="100%"></canvas>
                                <div id="chartjs-tooltip4" class="chartjs-tooltip">
                                    <div>
                                        <span style="padding-left: 15px;">34</span>
                                        <br />
                                        <span style="font-size: smaller; color: white">屏幕</span>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Timer ID="Timer1" OnTick="Timer1_Tick" runat="server" Interval="25000" />
    <div style="display:none">
    <asp:UpdatePanel runat="server" >
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" />
        </Triggers>
        <ContentTemplate>
            <span id="machineStatus" runat="server"></span>
            <span id="work" runat="server"></span>
            <span id="machineStatus1" runat="server"></span>
            <span id ="work1" runat="server"></span>
            <span id="total" runat="server"></span>
        </ContentTemplate>
    </asp:UpdatePanel></div>
    
    <%--<script src="https://cdn.jsdelivr.net/npm/jquery-match-height@0.7.2/dist/jquery.matchHeight.min.js"></script>--%>    
    <!--  Chart js -->    
    <%--<script src="https://cdn.jsdelivr.net/npm/chart.js@2.7.3/dist/Chart.bundle.min.js"></script>--%>

    <script src="Scripts/jquery.matchHeight.js"></script>
    <script src="assets/js/main.js"></script>
    <script src="Scripts/Chart.bundle.min.js"></script>
    <script src="lib/gauge.js"></script>    
    <script src="ScriptsLInks/highcharts.js"></script>
    <script src="ScriptsLInks/highcharts-more.js"></script>
    <script src="ScriptsLInks/highcharts-3d.js"></script>
    
    <script>
       
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
      var cccc= Highcharts.chart('systemDiv', {
            chart: {
                backgroundColor: '#191b28',
                plotBackgroundColor: '#191b28',
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
                    fontWeight: 'bold'
                }
            },
            tooltip: {
                pointFormat: '<b>{point.percentage:.1f}%</b>'
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
                        style: { fontFamily: '\'Lato\', sans-serif', lineHeight: '18px', fontSize: '17px',fill:'#fff' }
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
                    ['故障', 10],
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


       var ccc= Highcharts.chart('metanaldiv', {
            chart: {
                backgroundColor: '#191b28',
                plotBackgroundColor: '#191b28',
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
                dispaly:false,
                style: {
                    
                    color: '#fff',
                    textTransform: 'uppercase',
                    fontSize: '16px',
                    fontWeight: 'bold'
                }
            },
            tooltip: {
                pointFormat: ' <b>{point.percentage:.1f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    colors: pieColors,
                    cursor: 'pointer',
                    depth: 20,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}',
                        style: { fontFamily: '\'Lato\', sans-serif', lineHeight: '18px', fontSize: '17px',fill:'#fff' }
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
  //      var configelec = Highcharts.chart('Speedometer', {
  //         chart: {
  //  type: 'gauge',
  //  //plotBackgroundColor: null,
  //             backgroundColor:'transparent',
  //  plotBackgroundImage: null,
  //  plotBorderWidth: 0,
  //  plotShadow: false,
    
  //},

  //title: {
  //  text: ''
  //},

  //      pane: {
  //  startAngle: -150,
  //  endAngle: 150,
  //  background: [{
     
  //    borderWidth: 0,
  //    outerRadius: '100%'
  //  }, {
      
  //    borderWidth: 0,
  //    outerRadius: '100%'
  //  }, {
  //    borderColor:'transparent',
  //    backgroundColor:'#223',
  //  }, {
      
  //    backgroundColor: '#eee',
  //    borderWidth: 0,
  //    outerRadius: '100%',
  //    innerRadius: '100%'
  //  }]
  //},

  //      // the value axis
  //      yAxis: {
  //  min: 0,
  //  max: 100,

  //  minorTickInterval: 'auto',
  //  minorTickWidth: 1,
  //  minorTickLength: 10,
  //  minorTickPosition: 'inside',
  //  minorTickColor: '#666',

  //  tickPixelInterval: 30,
  //  tickWidth: 2,
  //  tickPosition: 'inside',
  //  tickLength: 10,
  //  tickColor: '#666',
  //  labels: {
  //    step: 2,
  //    rotation: 'auto',
  //    color:'#fff'
  //  },
  //  title: {
  //    text: ''
  //  },
  //  plotBands: [{
  //    from: 0,
  //    to: 30,
  //    color: '#7f9' // green
  //  }, {
  //    from: 30,
  //    to: 70,
  //    color: '#03f' // blue
  //  }, {
  //    from: 70,
  //    to: 100,
  //    color: '#f78' // red
  //  }]
  //},

  //      series: [{
  //          name: 'Electricity',
  //          data: [80],
  //          tooltip: {
  //              valueSuffix: ' %'
  //          },
            
  //          }],
  //          credits:{
  //              enabled: false,
  //          }
  //  }, );
    </script>

</asp:Content>
