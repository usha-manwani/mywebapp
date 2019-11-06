<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPAge.aspx.cs" Inherits="WebCresij.TestPAge" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Chart.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/sensor.css" rel="stylesheet" />
    <link href="Content/fontawesome-all.min.css" rel="stylesheet" />
    <link href="Content/fontawesome.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/Treeview.js"></script>
    <script src="Scripts/sensor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid no-gutter">
            <div class="col-2 left no-gutter float-left">
                <div class="logo">
                    <img class="logo rounded-circle clearfix" src="images/logo.jpg" alt=""/></div>
                <h3 class="text-center clearfix">北京大学</h3>
                <p class="text-center font-weight-light" style="margin-bottom: 0;">BEIJING UNIVERSITY</p>
                <p class="text-center font-weight-light">智慧教室综合管理系统</p>
                <div class="component" id="menu-left">
                    
                    
                </div>
            </div>
            <div>
                <div style="-moz-box-shadow: inset 0 0 15px #000000; 
                            -webkit-box-shadow: inset 0 0 15px #000000;
                            box-shadow: inset 0 0 15px #000000;  overflow:hidden ;
                            display:inline-block" id="divplugin1">
                            <%--<iframe src="src/Chimera.htm" height="390" width="640" 
                                frameborder="0" wmode="opaque"></iframe>--%>
                            <object id="plugin_inst_1" type="application/x-chimera-plugin" 
                                height="360" width="640">
                                <param name="autoplay" value="true" />
                                <param name="src" id="src1" value="rtsp://admin:admin123@172.168.10.94:554/cam/realmonitor?channel=1&subtype=1" />
                                <param name="network-caching" value="300" />
                                <param name="allow-fullscreen" value="true" />
                                <param name="mute" value="true" />
                               <%-- <param name="audio" value="100" />--%>
                            </object>
                            <div style="display: none">
                                <textarea id="qml_edit" cols="80" rows="20">
                                    import QtQuick 2.1
                                    import QmlVlc 0.1

                                    Rectangle {
                                        color: bgcolor
                                        VlcVideoSurface {
                                            id: videoOutput;
                                            source: vlcPlayer;
                                            anchors.fill: parent;
                                        }
                                        MouseArea {
                                            anchors.fill: videoOutput;
                                            onClicked: vlcPlayer.toggleFullscreen();
                                        }
                                        Text {
                                            id: text;
                                            color: "white";
                                        }
                                        Component.onCompleted: {
                                            vlcPlayer.onMediaPlayerBuffering.connect( onBuffering )
                                        }
                                        function onBuffering( percents ) {
                                            if( percents < 100 )
                                            text.text = "Buffering: " + percents +"%";
                                            else
                                            text.text = "no signal";
                                        }
                                    }
                                </textarea>
                                <button onclick="plugin1().qml = getByID('qml_edit').value; 
                                    getByID('qml_error').innerHTML = plugin1().qmlError;">
                                    load qml</button>
                                <br />
                                <span id="qml_error" style="color: red;" />
                            </div>
                        </div>
            </div>
        </div>
    </form>
</body>
<script src="Scripts/umd/popper.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
</html>
