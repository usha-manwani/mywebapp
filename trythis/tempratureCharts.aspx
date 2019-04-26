<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.master" AutoEventWireup="true" CodeBehind="tempratureCharts.aspx.cs" Inherits="WebCresij.tempratureCharts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
    <%--<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/normalize.css@8.0.0/normalize.min.css">--%>
    <link href="Content/normalize.min.css" rel="stylesheet" />
   <%-- <link rel="stylesheet" href="assets/css/style.css">  --%> 
    <link href="assets/css/charts.css" rel="stylesheet" />
    <link href="Content/Chart.min.css" rel="stylesheet" />
    <%--<link href="https://cdn.jsdelivr.net/npm/chartist@0.11.0/dist/chartist.min.css" rel="stylesheet">--%>
    <%--<link href="https://cdn.jsdelivr.net/npm/jqvmap@1.5.1/dist/jqvmap.min.css" rel="stylesheet">--%>
    <link href="assets/css/weather-icons-wind.min.css" rel="stylesheet" />
    <link href="assets/css/weather-icons.min.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
    
    <script src="Scripts/jquery.signalR-2.4.0.js"></script>
        <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>    
        <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' > </script>
        <div  id="ddl" style="background-color: #1e1e36;height:150px;" >        
      <asp:UpdatePanel runat="server">
                         <ContentTemplate>                            
                 <div class="row" style="min-height:100px; width:70%" >
                    <div class="col-lg-4 col-sm-12 ">
                        <h6 ><span style="color:white"><%=Resources.Resource.TempratureChartHead%></span> </h6>
                    </div>
                     <div class=" col-lg-2 col-sm-6 float-left" >
                        <asp:DropDownList Width="150px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlInstitute_SelectedIndexChanged"
                        CssClass="btn btn-default border dropdown"  ID="ddlInstitute" 
                        data-toggle="dropdown"  runat="server" ForeColor="White" BackColor="#1E1E36">
                         <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                        </asp:DropDownList></div>
                    <div class="col-lg-2 col-sm-6 float-left" >
                        <asp:DropDownList Width="150px" ID="ddlGrade" AutoPostBack="true"
                            CssClass="btn btn-default border dropdown" data-toggle="dropdown"  
                            OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" runat="server" ForeColor="White" BackColor="#1E1E36">
                            <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                        </asp:DropDownList>                        
                    </div>
                    <div class="col-lg-2 col-sm-6 float-left">
                        <asp:DropDownList  ID="ddlClass" Width="150px" AutoPostBack="true" 
                              runat="server" CssClass="btn btn-default border dropdown" 
                            data-toggle="dropdown" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" ForeColor="White" BackColor="#1E1E36">
                            <asp:ListItem Text="<%$Resources:Resource, Select %>" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>                    
                        <asp:Label ID="lblip" runat="server" CssClass="displaynone" Text='<%#Session["ipforgraph"]%>' ></asp:Label> 
                     <input id="ipgraph" type="hidden" value='<%=Session["ipforgraph"] %>'/>
                </div>
                             </ContentTemplate>
                     </asp:UpdatePanel>
        </div>
        <div style="display:block">  
         <!-- Content -->    
        <div class="container-fluid " id="tempdata" >            
            <div class="animated fadeIn">
                  <!-- Widgets  -->
                <div class="row" >
                 <div class="col-sm-6  col-md-6 col-lg-3" title="Temperature" >
                        <div class="card bg-flat-color-1" style="background-color:#cab9e9">
                            <div class="card-body">
                                <div class="card-left pt-1 float-left">
                                   <h3> <span><%=Resources.Resource.Temperature%></span></h3>
                                    <h3 class="mb-0 ">                                        
                                        <span id="tempvalue" class="count float-left ">0</span>
                                        <span >°C</span>
                                    </h3>                                    
                                </div><!-- /.card-left -->
                                <div class="card-right float-right text-right">
                                    <i class="wi wi-thermometer" style="font-size:2.5em; color:#967cc5"></i>
                                </div><!-- /.card-right -->
                            </div>
                        </div>
                    </div>
                    <!--/.col-->
                    <div class="col-sm-6  col-md-6 col-lg-3" title="Humidity" >
                        <div class="card  bg-flat-color-6" style="background-color:#99e9d7">
                            <div class="card-body">
                                <div class="card-left pt-1 float-left" >
                                    <h3><span><%=Resources.Resource.Humidity%></span></h3>
                                    <h3 class="mb-0 fw-r">                                        
                                        <span id="humidvalue" class="count float-left">0</span>
                                        <span>%</span>
                                    </h3>                                    
                                </div><!-- /.card-left -->
                                <div class="card-right float-right text-right">
                                    <i class="wi wi-humidity" style="font-size:2.5em; color:#53af9a"></i>
                                </div><!-- /.card-right -->
                            </div>
                        </div>
                    </div>
                    <!--/.col-->
                    <div class="col-sm-6  col-md-6 col-lg-3" title="PM2.5(µg/m3)" >
                        <div class="card  bg-flat-color-3" style="background-color:#f1c9c8">
                            <div class="card-body">
                                <div class="card-left pt-1 float-left">
                                    <h3> PM2.5(µg/m3)</h3>
                                    <h3 class="mb-0 ">                                       
                                        <span id="hum25value" class="count float-left">0</span>                                        
                                    </h3>                                  
                                </div><!-- /.card-left -->
                                <div class="card-right float-right text-right">
                                    <i class="wi wi-humidity" style="font-size:2.5em; color:#ca7f7d"></i>
                                </div><!-- /.card-right -->
                            </div>
                        </div>
                    </div>
                    <!--/.col-->
                    <div class="col-sm-6 col-md-6 col-lg-3" title="PM10(µg/m3)" >
                        <div class="card  bg-flat-color-2" style="background-color:#c2e9c4">
                            <div class="card-body">
                                <div class="card-left pt-1 float-left">
                                    <h3>PM10(µg/m3)</h3>
                                    <h3 class="mb-0 ">                                        
                                        <span id="hum10value" class="count float-left">0</span>
                                    </h3>                                    
                                </div><!-- /.card-left -->
                                <div class="card-right float-right text-right">
                                    <i class="wi wi-humidity" style="font-size:2.5em; color:#61bd66"></i>
                                </div><!-- /.card-right -->
                            </div>
                        </div>
                    </div>
             </div>                
                <div class="clearfix"></div>
                <!-- /Widgets -->
                <div class="row "  >
                    <div class="col-lg-6 col-md-12  col-sm-12" >
                        <div class="card">
                            <div class="card-body" id="teamdiv" style="background-color:white">
                                <h4 class="mb-3"> <span><%=Resources.Resource.Temperature%></span></h4>
                                <canvas id="team-chart"></canvas>
                            </div>
                        </div>
                        <br /><br /><br /><br /><br /><br/><br />
                    </div><!-- /# column --> 
                 <div class="col-lg-6 col-md-12  col-sm-12">
                <div class="card">
                            <div class="card-body" id="humdiv" style="background-color:white">
                                <h4 class="mb-3"> <span><%=Resources.Resource.Humidity%></span> </h4>
                                <canvas id="lineChart"></canvas>
                            </div>
                        </div>
                      <br /><br /><br /><br /><br />
                     </div>   
                <div class="col-lg-6 col-md-12  col-sm-12" style="display:none">
                        <div class="card">
                            <div class="card-body" id="humdiv1">
                                <h4 class="mb-3">Yearly Sales </h4>
                                <canvas id="sales-chart" ></canvas>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    </div>              
                <br />                
                <div class="row">
                    <div class="col-lg-6 col-md-12  col-sm-12" >
                        <div class="card">
                            <div class="card-body"  style="background-color:white">
                                <h4 class="mb-3"> <span><%=Resources.Resource.Electricity%></span></h4>
                                 <canvas id="myChart"  height="100"></canvas>
                            </div>
                        </div>
                         <br /><br /><br /><br /><br />
                    </div>
                    
                    <div class="col-lg-6 col-md-12  col-sm-12" >
                        <div class="card">
                            <div class="card-body"  style="background-color:white">
                                <h4 class="mb-3"> <span><%=Resources.Resource.Voltage%></span></h4>
                                 <canvas id="myChart1"  height="100"></canvas>
                            </div>
                        </div>
                         <br /><br /><br /><br /><br />                    
                    </div>
                </div>                              
                <div class="row">
                    <div class="col-lg-6 col-md-12  col-sm-12" >
                        <div class="card">
                            <div class="card-body"  style="background-color:white">
                                <h4 class="mb-3"> <span><%=Resources.Resource.ProjectorUses%></span></h4>
                                 <canvas id="myChart2"  height="100"></canvas>
                            </div>
                        </div>
                         <br /><br /><br /><br /><br />
                    </div>
                    
                    <div class="col-lg-6 col-md-12  col-sm-12" >
                        <div class="card">
                            <div class="card-body"  style="background-color:white">
                                <h4 class="mb-3"> <span><%=Resources.Resource.PCUses%></span></h4>
                                 <canvas id="myChart3"  height="100"></canvas>
                            </div>
                        </div>
                         <br /><br /><br /> <br /><br />                   
                    </div>
                </div>              
                <div class="row">
                    <div class="col-lg-6 col-md-12  col-sm-12" >
                        <div class="card">
                            <div class="card-body"  style="background-color:white">
                                <h4 class="mb-3"> <span><%=Resources.Resource.CO2%></span></h4>
                                 <canvas id="myChart4"  height="100"></canvas>
                            </div>
                        </div>
                         <br /><br /> <br /><br /><br />
                    </div>
                    
                    <div class="col-lg-6 col-md-12  col-sm-12" >
                        <div class="card">
                            <div class="card-body"  style="background-color:white">
                                <h4 class="mb-3"> <span><%=Resources.Resource.Methanal%></span> </h4>
                                 <canvas id="myChart5"  height="100"></canvas>
                            </div>
                        </div>
                       <br /><br /><br />
                    </div>
                </div>
            </div><!-- .animated -->
       </div>
        <!-- /.content -->
     </div>
    
    <script src="Scripts/jquery.matchHeight.js"></script>
    <script src="assets/js/main.js"></script>
    <!--  Chart js -->
    <script src="Scripts/Chart.bundle.min.js"></script>   
    <script src="assets/js/init/chartjs-init.js?v=1"></script>
    <script src="assets/js/widgets.js"></script>
</asp:Content>

