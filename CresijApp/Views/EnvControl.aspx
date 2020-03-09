<%@ Page Title="" Language="C#" MasterPageFile="~/Views/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EnvControl.aspx.cs" Inherits="CresijApp.Views.EnvControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .pluginstyle{
            -moz-box-shadow: inset 0 0 10px #808080;
            -webkit-box-shadow: inset 0 0 10px #808080;
            box-shadow: inset 0 0 10px #808080;
            overflow: hidden; 
            height:330px!important;
            min-height:330px;
            width:80%!important;
            display:inline-block;
            text-align:left
        }
        .smallplugin{
            min-width: 144px; 
            max-height: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="siteContainer" runat="server">
    <script src="../HikVision/codebase/webVideoCtrl.js"></script>
    <div class="col-12 float-left">
      <h3 class="h3tt float-left"><i class="fa fa-desktop"></i> Class 01</h3>
      <div class="float-right mt-4">
        <label for="">
          <a href="Control.aspx" class="btn btn-secondary btn-sm float-right"><i class="fa fa-desktop"></i> 辅教设备</a>
        </label>
        <label for="">
          <a href="#" class="btn btn-primary btn-sm float-right active"><i class="fa fa-leaf"></i> 环境设备</a>
        </label>
        <label for="">
          <a href="#" class="btn btn-secondary btn-sm float-right"><i class="fa fa-camera"></i> 录课设备</a>
        </label>
      </div>
      <div class="stat-card col-12 float-left">
        <div class="col-7 no-gutter float-left" style="padding: 15px 0;">
          <div class="box-video"> 
              <div id="divPlugin" class="plugin pluginstyle">
               </div>
              <input type="hidden" id="hiddenplugin" value="" /> </div>
          <div class="col-12 controler no-gutter clearfix" style="padding-bottom: 0;">
           
              <label>
                <input value="teacher" name="listen" type="radio" checked>
                <i>教师音频</i><span class="fa fa-volume-up"></span></label>
              <label>
                <input value="room" name="listen" type="radio" >
                <i>课室音频</i><span class="fa fa-volume-up"></span></label>
              <label>
                <input value="call" name="listen" type="radio">
                <i>呼叫</i><span class="fa fa-phone"></span></label>            
          </div>
        </div>
        <div class="col-2 float-left" style="padding-right: 0;">
          <p class="sbox-video smallplugin"><iframe id="Iframe2" style=" height: 120px"
                                    src="~/HikVision/Plugin1.html" name="frameplugin1"
                                    width="100%" runat="server" frameborder="0"></iframe></p>
          <p class="sbox-video smallplugin"><iframe id="Iframe3" style=" height: 120px"
                                    src="~/HikVision/Plugin2.html" name="frameplugin2"
                                    width="100%" runat="server" frameborder="0"></iframe></p>
          <p class="sbox-video smallplugin"><iframe id="Iframe4" style=" height: 120px"
                                    src="~/HikVision/Plugin3.html" name="frameplugin3"
                                    width="100%" runat="server" frameborder="0"></iframe></p>
        </div>
        <div class="right-card card col-3 float-right no-gutter" style="margin-right: -15px;">
          <div class="card-header small">
            <p><i class="fa fa-angle-double-right"></i> Fri Sep-27-2019</p>
            <p><i class="fa fa-angle-double-right"></i> 班级名称：Class 01</p>
            <p><i class="fa fa-angle-double-right"></i> IP地址：192.168.1.101</p>
            <p><i class="fa fa-angle-double-right"></i> 在线状态：Offline</p>
          </div>
          <div class="card-body">
            <table class="w-100 small">
              <tbody>
                <tr>
                  <th class="w-25"><i class="fa fa-angle-right"></i> 温度</th>
                  <td>22℃</td>
                </tr>
                <tr>
                  <th class="w-25"><i class="fa fa-angle-right"></i> 湿度</th>
                  <td>16%rh</td>
                </tr>
                <tr>
                  <th class="w-25"><i class="fa fa-angle-right"></i> PM2.5</th>
                  <td>22.58μg/m³ <i class="fa fa-exclamation-circle red"></i></td>
                </tr>
                <tr>
                  <th class="w-25"><i class="fa fa-angle-right"></i> CO2</th>
                  <td>22.58ppm</td>
                </tr>
                <tr>
                  <th class="w-25"><i class="fa fa-angle-right"></i> 亮度</th>
                  <td>22.58lx <i class="fa fa-exclamation-circle yellow"></i></td>
                </tr>
                <tr>
                  <th class="w-25"><i class="fa fa-angle-right"></i> 甲醛</th>
                  <td>22.58μg/m³</td>
                </tr>
                <tr>
                  <th class="w-25"><i class="fa fa-angle-right"></i> 电压</th>
                  <td>220V</td>
                </tr>
                <tr>
                  <th class="w-25"><i class="fa fa-angle-right"></i> 能耗</th>
                  <td>122.58kW/h</td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
    <div class="w-100 clearfix float-left" style="height: 30px;"></div>
    <div id="envcontrol" style="display:none">

    
    <div class="col-4 float-left">
      <div class="stat-card no-gutter ">
        <div class="col-4 float-left text-center header" style="background: #fafafa; height: 120px;"> <i class="fa fa-lightbulb-o" aria-hidden="true"></i>
          <h5>灯光</h5>
        </div>
        <div class="col-8 float-left small controler2 pt-4">
          <div class="controler-item float-left"><i class="fa fa-lightbulb-o"></i> 讲台灯光
            <label class="rounded-pill ml-3" for="">
              <input type="checkbox" id="light1">
            </label>
          </div>
          <div class="w-100 clearfix"></div>
          <div class="controler-item float-left pr-4"><i class="fa fa-lightbulb-o"></i> 课室灯光
            <label class="rounded-pill ml-3" for="">
              <input type="checkbox"  id="light2">
            </label>
          </div>
        </div>
      </div>
    </div>
    <div class="col-4 float-left">
      <div class="stat-card no-gutter ">
        <div class="col-4 float-left text-center header" style="background: #fafafa; height: 120px;"> <i class="fa fa-columns" aria-hidden="true"></i>
          <h5>窗帘</h5>
        </div>
        <div class="col-8 float-left small controler3 pt-4">
          <table class="table-ctrl">
            <tr>
              <th><i class="fa fa-columns"></i></th>
              <td>讲台窗帘</td>
              <td class="btns"><input type="radio" name="env" class="radio s-left ml-0" value="open">
                <input type="radio" name="env" class="radio s-pause ml-0" value="stop">
                <input type="radio" name="env" class="radio s-right ml-0" value="close"></td>
            </tr>
            <tr>
              <th><i class="fa fa-columns"></i></th>
              <td>讲台窗帘</td>
              <td class="btns"><input type="radio" name="env2" class="radio s-left ml-0" value="open">
                <input type="radio" name="env2" class="radio s-pause ml-0" value="stop">
                <input type="radio" name="env2" class="radio s-right ml-0" value="close"></td>
            </tr>
          </table>
        </div>
      </div>
    </div>
    <div class="col-4 float-left">
      <div class="stat-card no-gutter ">
        <div class="col-4 float-left text-center header" style="background: #fafafa; height: 120px;"> <i class="fa fa-snowflake-o" aria-hidden="true"></i>
          <h5>空调</h5>
        </div>
        <div class="col-8 float-left small controler2" style="padding-top: 20px;">
          <div class="controler-item float-left pr-4" style="padding-right:;">空调1
            <label class="rounded-pill ml-3" for="">
              <input type="checkbox" id="ac1">
            </label>
          </div>
          <div class="controler-item float-left">空调2
            <label class="rounded-pill ml-3" for="">
              <input type="checkbox" id="ac2">
            </label>
          </div>
          <div class="w-100 clearfix"></div>
          <div class="controler-item float-left pr-4">空调3
            <label class="rounded-pill ml-3" for="">
              <input type="checkbox" id="ac3">
            </label>
          </div>
          <div class="controler-item float-left">空调4
            <label class="rounded-pill ml-3" for="">
              <input type="checkbox" id="ac4">
            </label>
          </div>
        </div>
      </div>
    </div>
    <div class="w-100 clearfix float-left" style="height: 30px;"></div>
        </div>
    <script src="../Scripts/WebPlugin.js"></script>

     <script src="../Scripts/jquery.signalR-2.4.1.min.js"></script>
    <script src='<%: ResolveClientUrl("~/signalr/hubs") %>'> </script> 
    <script src="../Scripts/EnvControl.js"></script>
</asp:Content>
