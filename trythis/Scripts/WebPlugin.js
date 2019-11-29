function checkIframeLoaded() {
    var iframe_content = $("#MainContent_masterchildBody_Iframe4").contents();

    if (iframe_content.length > 0) {
        clearInterval(checkIframeLoadedInterval);
        callCam();
    }
}


function GetPlugin(ip, user, pass, port, width, height, divid, hidden) {
    var ru;
    WebVideoCtrl.I_InitPlugin("100%", "100%", {
        bWndFull: true,
        iPackageType: 2,
        szColorProperty: " plugin-background: ffffff; sub-background: none; sub-border: none; sub-border-select: none ",
        cbInitPluginComplete: function () {
           ru=  WebVideoCtrl.I_InsertOBJECTPlugin(divid);
            //
            // check plugin to see whether it is the latest
            if (-1 == WebVideoCtrl.I_CheckPluginVersion()) {
                alert("Detect the latest version, please double click WebComponentsKit.exe to update!");
                return;
            }
        }
        
    });
    console.log(divid+"  "  +ru);
    camLogin(ip, user, pass, port, hidden)

}
var user = ''; var pass = ''; 
function camLogin(ip, user, pass, port) {
    var szIdentity;
    szIdentity = ip + "_" + port;
    var iret = WebVideoCtrl.I_Login(ip, 1, port, user, pass, {
        success: function (xmlDoc) {
            
            console.log(szIdentity);
            document.getElementById('hiddenplugin').value = ip;
            console.log(szIdentity + " login success！");
            ChangePlay(szIdentity);

        },
        error: function (status, xmlDoc) {
            console.log(szIdentity + " login failed！", status, xmlDoc);
        }
    });
    if (-1 == iret) {
        console.log(szIdentity + " login already !");
        ChangePlay(szIdentity);
    }
}
function StartPlay(szIdentity) {
    WebVideoCtrl.I_StartRealPlay(szIdentity,
        {
            iStreamType: 2,

            success: function () {
                szInfo = "start real play success！";
                console.log(szIdentity + " " + szInfo);
            },
            error: function (status, xmlDoc) {
                if (403 === status) {
                    szInfo = "Device do not support Websocket extracting the flow！";
                } else {
                    szInfo = "start real play failed！";
                }
                console.log(szIdentity + " " + szInfo);
            }
        }
    )
};

// Init plugin parameters and insert the plugin
console.log("initializn plugin");
$(function () {
    var iRet = WebVideoCtrl.I_CheckPluginInstall();    
    if (-1 == iRet) {
        alert(" please download and install the plugin WebComponentsKit.exe!");
        window.open("../HikVision/DownloadPlugin.aspx");
        return;
    }
    WebVideoCtrl.I_InitPlugin("100%", "100%", {
        bWndFull: true,
        iPackageType: 2,
        szColorProperty: " plugin-background: ffffff; sub-background: none; sub-border: none; sub-border-select: none ",
        cbInitPluginComplete: function () {
            ru = WebVideoCtrl.I_InsertOBJECTPlugin("divPlugin");
            //
            // check plugin to see whether it is the latest
            if (-1 == WebVideoCtrl.I_CheckPluginVersion()) {
                alert("Detect the latest version, please double click WebComponentsKit.exe to update!");
                return;
            }
        }

    });
});



document.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
};

//ajax call to get cam details
function callCam() {

    var aData;
    var val = document.getElementById("loccam").value;
    var jsonData = JSON.stringify({
        name: val
    });
    $.ajax({
        type: "POST",
        url: "Services/GetSideMenu.asmx/GetCamDetails",
        data: jsonData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess_,
        error: OnErrorCall_
    });
    function OnSuccess_(response) {
        console.log("web method for cam is working");
        aData = response.d;
        if (aData.length > 0) {
            console.log("method is called");
            for (i = 0; i < aData.length; i++) {
                var cam = aData[i];
               
                if (i == 0) {
                    camLogin(cam[0], cam[1], cam[2], 80);
                    user = cam[1];
                    pass = cam[2];
                }
                   
                else if (i == 1) {
                    window.frames['frameplugin1'].GetPlugin1(cam[0], cam[1], cam[2], 80);
                    //window.frames['frameplugin1'].camLogin1(cam[0], cam[1], cam[2], 80);
                    
                }
                else if (i == 2) {
                    window.frames['frameplugin2'].GetPlugin1(cam[0], cam[1], cam[2], 80);
                    //document.getElementById('#MainContent_masterchildBody_Iframe3').contentWindow.camLogin2(cam[0], cam[1], cam[2], 80, "");
                }
                else if (i == 3) {
                    window.frames['frameplugin3'].GetPlugin1(cam[0], cam[1], cam[2], 80);
                    //document.getElementById('#MainContent_masterchildBody_Iframe4').contentWindow.camLogin3(cam[0], cam[1], cam[2], 80, "");
                }
            }
        }
    }
    function OnErrorCall_(respo) {
        console.log(respo);
    }
};

var checkIframeLoadedInterval = setInterval(checkIframeLoaded, 1000);


function changeplaycam1() {
    var frame = $("#MainContent_masterchildBody_Iframe1").contents();
    if (frame.length > 0) {
        var ip = window.frames['frameplugin1'].getid();
        if (ip.length > 0) {
            var temp = document.getElementById('hiddenplugin').value;
            document.getElementById('hiddenplugin').value = ip;
            window.frames['frameplugin1'].setid(temp);
            camLogin(ip, user, pass, 80);            
            window.frames['frameplugin1'].camLogin1(temp, user, pass, 80);
            //window.frames['frameplugin1'].StartPlay1(temp+ "_" + 80);
        }
    }
}
function changeplaycam2() {
    var frame = $("#MainContent_masterchildBody_Iframe2").contents();
    if (frame.length > 0) {
        var ip = window.frames['frameplugin2'].getid();
        if (ip.length > 0) {
            var temp = document.getElementById('hiddenplugin').value;
            document.getElementById('hiddenplugin').value = ip;
            window.frames['frameplugin2'].setid(temp);
            camLogin(ip, user, pass, 80);
            window.frames['frameplugin2'].camLogin2(temp, user, pass, 80);
            //window.frames['frameplugin1'].StartPlay1(temp+ "_" + 80);
        }
    }
}
function changeplaycam3() {
    var frame = $("#MainContent_masterchildBody_Iframe3").contents();
    if (frame.length > 0) {
        var ip = window.frames['frameplugin3'].getid();
        if (ip.length > 0) {
            var temp = document.getElementById('hiddenplugin').value;
            document.getElementById('hiddenplugin').value = ip;
            window.frames['frameplugin3'].setid(temp);
            camLogin(ip, user, pass, 80);
            window.frames['frameplugin3'].camLogin3(temp, user, pass, 80);
            //window.frames['frameplugin1'].StartPlay1(temp+ "_" + 80);
        }
    }
}

function ChangePlay(szIdentity) {
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(0);
    if (oWndInfo != null) {// stop play first
        WebVideoCtrl.I_Stop({
            success: function () {
                StartPlay(szIdentity);
            }
        });
    } else {
        StartPlay(szIdentity);
    }
}

function clickOpenSound() {
    var imgmute = document.getElementById('muteimg');
    var src1 = $(imgmute).attr('src');
    
    var oWndInfo = WebVideoCtrl.I_GetWindowStatus(0);
    if (oWndInfo != null) {
        if (src1 == "Images/中控首页按钮/首页按钮-默认状态/总音量静音.png") {
            var iRet = WebVideoCtrl.I_OpenSound(0);
            $(imgmute).attr('src', "Images/中控首页按钮/首页按钮-默认状态/总音量.png");
        }
        else {
            var iRet = WebVideoCtrl.I_CloseSound(0);
            $(imgmute).attr('src', "Images/中控首页按钮/首页按钮-默认状态/总音量静音.png");
        }
        
    }
}



