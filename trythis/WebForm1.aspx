<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="final.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <meta charset="UTF-8"/>
		<meta http-equiv="X-UA-Compatible" content="IE=6;IE=7; IE=8; IE=EmulateIE7" />

    </head>
    <body>
        <form runat="server">
       <div id="login_install_dialog"  style="display:none;height:20px; width:400px;padding-top:30px; margin:auto;">
		<div style="clear: both;zoom:1; border: 2px solid #373737;background: #D5D5D5;">
		 <a id="login_btn_install" href="/webplugin.exe" target="_download" onclick = "instal()"style ="background: rgb(255,0,0);">Instal</a>
		 <a id="login_btn_cancel" href="javascript:;">Cancle</a>
		</div>
        </div>
            <div id="f_ocx" style="top:60px; left:0; width: 500px; height: 500px;"></div>
		<div >

			<%--<button id="Login"  href="javascript:;" OnClick = "LoginDevice()" style = "display:none;">Login</button>
            <button id="Play" href="javascript:;"Onclick = "RealPlay()" style = "display:none;">RealPlay</button>--%>
            <%-- <asp:Button runat="server" ID="btnlogin" OnClientClick="LoginDevice();return false;" Text="loginbtn"/>
            <asp:Button runat="server" ID="btnrealplay" OnClientClick="RealPlay();return false;" Text="playbtn" />--%>
			
			<button id="Ptzctrl" href="javascript:;"Onclick = "ControlPtz()" style = "display:none;">云台</button>
			<button id="Stop" href="javascript:;"Onclick = "StopPlay()" style = "display:none;">Stop</button>	
			<button id="FullScreen" href="javascript:;"Onclick = "FullScreen()" style = "display:none;">FullScreen</button>		
			<button id="LocalPlay" href="javascript:;"Onclick = "LocalPlay()" style = "display:none;">LocalPlay</button>			
			<button id="Logout" href="javascript:;"Onclick = "LogoutDevice()" style = "display:none;">Logout</button>	
		</div>  
		
		<div >
			<button id="idQuery" href="javascript:;"Onclick = "QueryRecord()" style = "display:none;">QueryRecord</button>
			<button id="PlayBack" href="javascript:;"Onclick = "PlayBack()" style = "display:none;">Playback</button>
			<button id="download" href="javascript:;"Onclick = "Download()" style = "display:none;">Download</button>
			<button id="PlayRec" href="javascript:;"Onclick = "PlayRec()" style = "display:none;">PlayRec</button>
			<button id="PauseRec" href="javascript:;"Onclick = "PauseRec()" style = "display:none;">PauseRec</button>
			<button id="FastPlay" href="javascript:;"Onclick = "FastPlay()" style = "display:none;">FastPlay</button>
			<button id="SlowPlay" href="javascript:;"Onclick = "SlowPlay()" style = "display:none;">SlowPlay</button>	
		</div >  
		<div id="ShowPlayTime" style = "display:none;">
			<label >now time</label><input type="text" id="playtime">
		</div>
		<div id="DwonLoadPos" style = "display:none;">
			<label >pos</label><input type="text" style="width:900px" id="downPos">
		</div>
		<div style="display:none;" id="RecInfo">
			<div id="RecInfoList" style = "overflow:auto;width:600px;height:200px;">
			</div>
        </div>
	</form>

       
<script type="text/javascript">
var agent = navigator.userAgent.toLowerCase();
var g_ocx;
var PLUGINS_CLASSID = '7F9063B6-E081-49DB-9FEC-D72422F2727F';
var VERSION_GUI = 'version=3,1,0,4'; //注意：本地GUI上版本信息显示需要的字符串，修改版本的时候这个字符串也要修改
var Sys = {};
var isMac = navigator.userAgent.toLowerCase().indexOf("mac") != -1;
var ua = navigator.userAgent.toLowerCase();
        var s;
        (s = ua.match(/(msie\s|trident.*rv:)([\d.]+)/)) ? Sys.ie = s[2] :
        (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
        (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
        (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
        (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;
 var PLUGINS_NAME = 'WebActiveEXE.Plugin.1';
var hasPlugin = checkPlugins();

var g_PlayTime;
var g_curSpeed = 4;//默认的正常速度
var htmlStChn1 = '';
    var wndno=0;
/**
 * 检测浏览器是否存在视频插件
 * @return {Boolean}
 */
function checkPlugins(){
    var result;
    if (Sys.ie) {
        try { 
            result = new ActiveXObject(PLUGINS_NAME);
            delete result;
        } catch (e) {
            return false;
        }
        return true;
    } else {
        navigator.plugins.refresh(false);
        result = navigator.mimeTypes["application/media-plugin-version-3.1.0.2"];
        return !!(result && result.enabledPlugin);
    }
}

function hideInstallDialog()
{
	document.getElementById('login_install_dialog').style.display = 'none';
	if(document.getElementById('username') && !g_isRemoteLogin)
	{
		if(document.getElementById('username').value != '')
		{
			document.getElementById('password').focus();
		}
		else
		{
			document.getElementById('username').focus();
		}
	}
}
function showInstallDialog()
{
	document.getElementById('login_install_dialog').style.display = '';
}
function instal(){
	hideInstallDialog();
	setTimeout('loadPlugins()',1000);
}
var mainOcxHtml = '';
if (Sys.ie)
{		
	mainOcxHtml = '<object id="ocx" width="100%" height="100%" classid="CLSID:{'+PLUGINS_CLASSID+'}"codebase="/webrec.cab"></object>';
}
else
{
	mainOcxHtml = '<object id="ocx" width="100%" height="100%" type="application/media-plugin-version-3.1.0.2" VideoWindTextColor="9c9c9c" VideoWindBarColor="414141"></object>';
}

var handlerOcxEvents = {
	fireOcxEvent: function(jsonStr) {
		document.getElementById('downPos').value = jsonStr;
	}
}

function loadPlugins()
{
	if(checkPlugins())
	{	
		hasPlugin = true;
		setTimeout('loadPageOcx()',2000);
	}
	else
	{
		setTimeout('loadPlugins()',1000);
	}	
}

if (!hasPlugin ) 
{
	showInstallDialog();				
}
else
{
	hideInstallDialog();
	loadPageOcx();
}	

function loadPageOcx (){
		document.getElementById('f_ocx').innerHTML = mainOcxHtml;
	//document.getElementById('Login').style.display = '';
		initPageOcx();	

}

function initPageOcx() {
	g_ocx = document.getElementById('ocx');
	//g_ocx.AddEventListener('SetNetPlayRecordStatus', ShowRecInfo);
	g_ocx.AddEventListener('SetNetPlayFileInfo', ShowRecInfo);
	g_ocx.AddEventListener('NetPlayTimeInform', ShowPlayTime);
	g_ocx.AddEventListener('TransEvent', handlerOcxEvents.fireOcxEvent);
}
	
    function RealPlay() {
      
        g_ocx.SetModuleMode(1); //监视模式
        g_ocx.ConnectRealVideoEx(0, 1, wndno);
    if (wndno != 3) {
        wndno = wndno + 1;
    }
    else if (wndno == 3) {
        wndno = 0;
        }
     
}

function ControlPtz(){
	g_ocx.ControlPtzEx(0, 1, 1, 8, 1, 0);
}

    function LoginDevice(ip, id, pass) {
        g_ocx.LogoutDevice();
        var camip = ip, camid = id, password = pass;


    var bRet = g_ocx.LoginDeviceEx(camip, 37777, camid, password, 1);
        if (bRet == 0) {
            
		//document.getElementById('LocalPlay').style.display = '';
		//document.getElementById('Stop').style.display = '';
		//document.getElementById('FullScreen').style.display = '';	
		//document.getElementById('Logout').style.display = '';	
		//document.getElementById('idQuery').style.display = '';			
		//document.getElementById('Ptzctrl').style.display = '';	
  //      document.getElementById('Play').style.display = '';	
        RealPlay();
    }
   
}

function LogoutDevice(){
	g_ocx.LogoutDevice();
	document.getElementById('Login').style.display = '';
	document.getElementById('PlayBack').style.display = 'none';
	document.getElementById('LocalPlay').style.display = 'none';
	document.getElementById('Stop').style.display = 'none';
	document.getElementById('FullScreen').style.display = 'none';
	document.getElementById('Play').style.display = 'none';
	document.getElementById('Logout').style.display = 'none';
	document.getElementById('PlayRec').style.display = 'none';
	document.getElementById('PauseRec').style.display = 'none';
	document.getElementById('FastPlay').style.display = 'none';
	document.getElementById('SlowPlay').style.display = 'none';
	document.getElementById('ShowPlayTime').style.display = 'none';
	document.getElementById('DwonLoadPos').style.display = 'none';
	document.getElementById('RecInfo').style.display = 'none';
}

function LocalPlay()
{
	g_ocx.QuickOperation(0);
}

function StopPlay()
{
	g_ocx.DisConnectRealVideo(0);
}

function FullScreen(){
	g_ocx.OnFullScreenClk(); 
}

function QueryRecord(){
	g_ocx.SetModuleMode(4);	//回放模式	
	g_ocx.SetWinBindedChannel(1, 0, 63,64);
	g_ocx.SwitchMonth(2014,11,17);
	g_ocx.SwitchDay(2014,11,17);
	htmlStChn1 = '';
}

function PlayBack(){
	//ocx.SetSearchBeginTime('2014-10-13 00:00:00',true);
	g_ocx.PlayBackByTime(0, '01:00:00');
}

function FastPlay(){
	if(g_curSpeed >= 8){//达到最大速度以后再快放就回到正常速度,客户可以按照自己的意愿来处理此时是否灰显快放按钮
		g_curSpeed = 4;
	}
	else{
		g_curSpeed++;
	}
	ocx.SpeedPlayBack(g_curSpeed);
}

function SlowPlay(){
	if(g_curSpeed <= 0){//达到最小速度以后再慢放就回到正常速度,客户可以按照自己的意愿来处理此时是否灰显快放按钮
		g_curSpeed = 4;
	}
	else{
		g_curSpeed--;
	}
	ocx.SpeedPlayBack(g_curSpeed);
}

function Download(){
	g_ocx.DownloadRecordByTime(0, '2014-11-04 01:05:00','2014-11-04 01:18:00', 'C:\\RecordDownload', 'dav');
}

function PlayRec()
{
	g_ocx.PlayBack();
}

function PauseRec()
{
	g_ocx.PausePlayBack();
}

function ShowPlayTime(time)
{
	//时间的格式00020018|  |是通道分隔符
	g_PlayTime = time;
	document.getElementById('playtime').value = g_PlayTime;
}

function ShowRecInfo(nCh, strRecodInfo)
{
	document.getElementById('PlayBack').style.display = '';
	document.getElementById('PlayRec').style.display = '';
	document.getElementById('PauseRec').style.display = '';
	document.getElementById('FastPlay').style.display = '';
	document.getElementById('SlowPlay').style.display = '';	
	document.getElementById('download').style.display = '';
	document.getElementById('RecInfo').style.display = '';
	document.getElementById('ShowPlayTime').style.display = '';
	document.getElementById('DwonLoadPos').style.display = '';
	g_PlayTime = "";
	var readtime = strRecodInfo.split(':');
	var num = readtime.length;
	for(var i=0; i<num ; i++){
		if(readtime[i]=='')
			continue;
		htmlStChn1 += '<li><a id="StChn'+(i)+'">' +'channel: '+nCh+' info: '+ readtime[i]+'</a></li>';
	}
	document.getElementById('RecInfoList').innerHTML = htmlStChn1;
}		
</script>
</body></html>