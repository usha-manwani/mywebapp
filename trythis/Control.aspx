<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="trythis.Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
    <style type="text/css">

        .imgclick:active{
            box-shadow: 0 5px #666;
            transform: translateY(4px);
        }
        .imgclick:hover{
            -webkit-border-radius: 10px;
    -moz-border-radius: 10px;
    border-radius: 10px;
 -webkit-box-shadow: 0px 0px 30px 0px rgba(0, 0, 245, 0.67);
-moz-box-shadow:    0px 0px 30px 0px rgba(0, 0, 245, 0.67);
box-shadow:         0px 0px 30px 0px rgba(0, 0, 245, 0.67);
        }
       [type=radio] { 
  position: absolute;
  opacity: 0;
  width: 0;
  height: 0;
}

/* IMAGE STYLES */
[type=radio] + img {
  cursor: pointer;
}

/* CHECKED STYLES */
[type=radio]:checked + img {
  outline: 2px solid #f00;
}
 .modal {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 150px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
}
        .modal-content {
    background-color:aliceblue;
    margin: auto;
    padding: 20px;
    border: 1px solid #888;
    width: 80%;
}
pp{
  background-color: #565656;
  color: transparent;
  text-shadow: 0px 2px 3px rgba(255,255,255,0.3);
  -webkit-background-clip: text;
     -moz-background-clip: text;
          background-clip: text;
}
    </style>                                                                                
    <link href="Content/ControlStyle.css" rel="stylesheet" />   
    <link href="css/toggleswitch.css" rel="stylesheet" />
    <link href="http://www.cssscript.com/wp-includes/css/sticky.css" rel="stylesheet" type="text/css">
    <!--Reference the SignalR library. -->  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">    
        <script src="Scripts/jquery.signalR-2.4.0.js"></script>
        <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>    
        <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' > </script>
        <script src="Scripts/ControlKeys.js"></script>
    <div class="container-fluid">
    <div class="row clearfix" id="smallcontrol" >
        <input type="hidden" name="ipForRemote" value="" />
        <%--   <div class="col-md-3">   
            <table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;">
            <tr id="first" style=" text-align:center">
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name aur bada h</h3>
                    </td>
                <td>
                    <div class="switch">

  <input type="checkbox" name="toggle" />

  <label for="toggle"><i></i></label>

  <span></span>

</div>

                </td>
            </tr>
            <tr style="  height:50px; border:solid; border-color:white; border-width:1px">
                <td colspan="2" ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td title="proj" colspan="2" style="color:greenyellow" ><i style="font-size:24px; color:white" class="fa" >&#xf0a0;</i></td>
                <td colspan="2" ><i class="fa fa-hdd" style="color:pink"></i></td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td colspan="2" ><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td colspan="2" ><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td colspan="2" ><i class="fa fa-desktop fa-2x  " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>--%>
        
        <%-- <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">

                      <span class="checking"></span>  
  
   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
         <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">
 
                      <span class="checking"></span>  

   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
         <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">
  
                      <span class="checking"></span>  

   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
         <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">
 
                      <span class="checking"></span>  
 
   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
         <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">
  
                      <span class="checking"></span>  
 
   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
         <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">
  
                      <span class="checking"></span>  
 
   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
         <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">
 
                      <span class="checking"></span>  
  
   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
         <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">
  
                      <span class="checking"></span>  
  
   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
         <div class="col-md-3"><table class="1234" style=" border-radius:10px; width:250px; height:200px;background: #202838;" >
            <tr style=" text-align:center" >
                <td colspan="3" style="text-align:center">                    
                    <h3 style="color:white">Class Name 2</h3>
                    <div class="switch">
  
                      <span class="checking"></span>  
  
   </div>
                </td>
            </tr>
            <tr style=" height:50px; height:50px; border:solid; border-color:white; border-width:1px">
                <td ><img class="fa-2x " src="Images/proj.png" style="color:white" /></td>
                <td><i class="fi-projection-screen " style="color:#283446">dfd</i></td>
                <td>p</td>
            </tr>
            <tr style="height:50px;  text-align:center;border:solid; border-color:white; border-width:1px">
                <td><i class="fa fa-volume-off fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-lock fa-2x " aria-hidden="true" style="color:white"></i></td>
                <td><i class="fa fa-desktop fa-2x " aria-hidden="true" style="color:white"></i></td>
            </tr>
        </table></div>
           --%>
    </div>
        </div>
  
    <div id="control" class="modal">
    <div class=" modal-content" style="font-family: 'Ruda', sans-serif" >
         <div style="width:100%; color:#3c763d; border:solid;border-color:#3c763d; background-color:#dff0d8; 
             border-radius:5px" class="row changecolor" onmouseover="this.style.background='white';"
             onmouseout="this.style.background='#dff0d8';">
        <header>
            <p style="text-align:left">Remote Control For 
                <asp:Label runat="server" Font-Bold="true" Font-Italic="true" ID="deviceips" Text=""></asp:Label>
            </p><span class="close " onclick="closexx();" style="align-content:flex-end">&times;</span>
        </header>
    </div>
        <input id="sessionInput" type="hidden" value='<%= Session["DeviceIP"] %>' />
        <input id="sessionInput1" type="hidden" value='<%= Session["loc"] %>' />
        <input id="dev" type="hidden" value='<%=Session["devices"] %>' />
        <asp:TextBox style="display:none" ID="ipAddressToSend" runat="server"></asp:TextBox>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" ></asp:ScriptManagerProxy>
        <table >
            <tr>
                <td>   
                <div  style="height:300px;width:290px;  border:none">
             
             <header style=" background-color:#428bca;color:black; text-align:center;border:solid; border-color:#428bca ">System Control&nbsp;
                 <span data-toggle="collapse" data-target="#system" style="color:white" class="fa fa-angle-double-down trying" ></span>
             </header>
          
           <div id="system" class="divcontrols"  >
                <table style=" height:220px; width:250px;border-color:#428bca" >
                    <tr > 
                        <td colspan="3" style="font-size:small; text-align:center"> System Power</td>
                        <td colspan="3" style="font-size:small; text-align:center"> Computer Power</td>
                    </tr>
                    <tr style="align-items:center; align-content:center;">
                        <td colspan="3" style="text-align:center">
                            <span>
                                <img src="Images/powerOff.png" id="systempower" height="70" width="70" class="imgclick"/></span>
                             </td>
                        <td colspan="3" style="text-align:center">
                            <span>
                                <img src="Images/powerOff.png" id="pcpower" height="70" width="70" class="imgclick"/></span>                          
                    </tr>                               
                    <tr >
                        <td colspan="2" style="text-align:center">
                            <span>
                                <img src="Images/unlock.png" id="syslock" height="30" width="30" class="imgclick"/></span>                            
                           </td>
                        <td colspan="2" style="text-align:center"  >
                            <span>
                                <img src="Images/unlock.png" id="podiumlock" height="30" width="30" class="imgclick"/></span>
                            </td>
                        <td colspan="2" style="text-align:center" >
                            <span>
                                <img src="Images/unlock.png" id="classlock" height="30" width="30" class="imgclick"/></span>
                             </td>
                    </tr>
                    <tr >
                        <td colspan="2" style="font-size:small; text-align:center">system lock</td>
                        <td colspan="2" style="font-size:small; text-align:center" >podium lock</td>
                        <td colspan="2" style="font-size:small; text-align:center">class lock</td>
                    </tr>
                </table> 
               </div>          
                </div>
                </td>
                <td>
                <div style="height:300px;width:290px;  border:none">
             
             <header style=" background-color:#dff0d8;color:black; text-align:center ;border:solid; border-color:#dff0d8">Projector Control&nbsp;
                  <span data-toggle="collapse" data-target="#Projector" style="color:#3c763d"class="fa fa-angle-double-down trying" ></span>
             </header>
             <div id="Projector" class="divcontrols" style=" border-color:#3c763d">
                     <table style=" height:220px; width:270px">
                  
                    <tr style="width:220px">
                        <td style="text-align:center">
                             <span>
                                <img src="Images/power.png" id="projectorOn" height="30" width="30" class="imgclick"/></span>                
                        </td>
                        <td style="text-align:center">
                            <a  href="#" style=" color:white;">
                                <img src="Images/HDMI.png" id="hdmi" height="30" width="30" class="imgclick"/></a>
                            
                        </td>
                    </tr>
                    <tr style="width:220px">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/power.png" id="projectorOff" height="30" width="30" class="imgclick"/></span>                            
                        </td>
                        <td style="text-align:center">
                            <span>
                                <img src="Images/video.png" id="projVideo" height="30" width="30" class="imgclick"/></span>
                           </td>
                    </tr>
                    <tr style="width:220px">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/stop.png" id="projSleep" height="30" width="30" class="imgclick"/></span>
                            </td>
                        <td style="text-align:center">
                            <span>
                                <img src="Images/VGA.png" id="vga" height="30" width="30" class="imgclick"/></span>
                             </td>
                    </tr>                
                </table>
             </div>
             </div>
                </td>
                <td>
                <div style="height:300px;width:180px;  border:none">
             
             <header style=" background-color:#d9edf7;color:black; text-align:center;border:solid; border-color:#d9edf7 ">Light Control&nbsp;
                 <span class="fa fa-angle-double-down trying" data-toggle="collapse" data-target="#light" style="color:#31708f;">
                     </span></header>
             
           
                    <div id="light" class="divcontrols" style=" border-color: #31708f;">
                             <table style="width:160px; height:220px;">
                 
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/light.png" id="light1" height="30" width="30" class="imgclick"/></span>
                             </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/light.png" id="light2" height="30" width="30" class="imgclick"/></span>
                             </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/light.png" id="light3" height="30" width="30" class="imgclick"/></span>
                            </td>
                    </tr>
                </table>
                    </div>
             </div>
                </td>
                <td rowspan="2">
                <div  style=" width:200px; height:590px"> 
            <header style=" background-color:#fcf8e3;color:black; text-align:center;border:solid; border-color:#fcf8e3 ">Media Signal&nbsp;
                <span data-toggle="collapse" data-target="#media" style="color:#916d3b"class="fa fa-angle-double-down trying" ></span>
            </header>
            <div id="media" class="divcontrols" style=" border-color:#916d3b">
                <table style="width:130px;height:540px">
                  
                    <tr  style="width:130px;">
                        <td  style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="desktop" checked>
                            <img src="Images/Desktop.png" height="30" width="30" class="imgclick">
                            </label>
                            <%--<input type="image" src="Images/Desktop.png" class="imgclick" height="30" width="30" id="desktop"/>--%></td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="laptop" checked>
                            <img src="Images/laptop.png" height="30" width="30" class="imgclick">
                            </label>
                            <%--<input type="image" src="Images/laptop.png" class="imgclick" height="30" width="30" id="laptop"/>--%></td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="platform" checked>
                            <img src="Images/platform.png" height="30" width="30" class="imgclick">
                            </label>
                            <%--<input type="image" src="Images/platform.png" class="imgclick" height="30" width="30" id="platform"/>--%></td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center" >
                            <%--<input type="image" src="Images/platform.png" class="imgclick" height="30" width="30" id="digitalEquipment"/>--%> 
                             <label>
                            <input type="radio" name="test" id="digitalEquipment" checked>
                            <img src="Images/platform.png" height="30" width="30" class="imgclick">
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <%--<input type="image" src="Images/DVD.png" class="imgclick" height="30" width="30" id="dvd"/>--%> 
                            <label>
                            <input type="radio" name="test" id="dvd" checked>
                            <img src="Images/DVD.png" height="30" width="30" class="imgclick">
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <%--<input type="image" src="Images/Blu-Ray.png" class="imgclick" height="30" width="30" id="bluray"/>--%>
                            <label>
                            <input type="radio" name="test" id="bluray" checked>
                            <img src="Images/Blu-Ray.png" height="30" width="30" class="imgclick">
                            </label>
                       </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td  style="text-align:center">
                           <%--<input type="image" src="Images/TV.png" class="imgclick" height="30" width="30" id="tv"/>--%>
                            <label>
                            <input type="radio" name="test" id="tv" checked>
                            <img src="Images/TV.png" height="30" width="30" class="imgclick">
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <%--<input type="image" src="Images/Camera.png" class="imgclick" height="30" width="30" id="camera"/>--%>
                        <label>
                            <input type="radio" name="test" id="camera" checked>
                            <img src="Images/Camera.png" height="30" width="30" class="imgclick">
                            </label>    
                       </td>
                            </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center" >
                            <%--<input type="image" src="Images/video.png" class="imgclick" height="30" width="30" id="Recorder"/>--%>
                        <label>
                            <input type="radio" name="test" id="recorder" checked>
                            <img src="Images/video.png" height="30" width="30" class="imgclick">
                            </label>    
                        </td></tr>
                </table>
                </div>
                     </div>
                    </td>
            </tr>
            <tr>
                <td>
                <div style="height:290px;width:290px; border:none">
             
                <header style=" background-color:#dff0d8;color:black; text-align:center;border:solid; border-color:#dff0d8 ">Screen & curtain&nbsp;
                    <span data-toggle="collapse" data-target="#ScreenCurtain" style="color:#3c763d"class="fa fa-angle-double-down trying" ></span>
                </header>
                <div id="ScreenCurtain" class="divcontrols" style=" border-color:#3c763d">
                <table style="width:270px; height:220px;">
                
                 <tr  >
                    <td  style=" font-size:small; text-align:center">
                        Digital Screen                        
                    </td>
                    <td style=" font-size:small; text-align:center">
                       Digital Curtain
                    </td>
                </tr>
                <tr  >
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/up.PNG" id="dsup" height="30" width="30" class="imgclick"/></span>   
                    </td>
                    <td style="text-align:center">
                         <span>
                                <img src="Images/open.PNG" id="dcopen" height="30" width="30" class="imgclick"/></span>
                         </td>
                </tr>
                 <tr>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/stop.PNG" id="dsstop" height="30" width="30" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/stop.PNG" id="dcstop" height="30" width="30" class="imgclick"/></span>
                        </td>
                     </tr>
                      <tr >
                    <td style="text-align:center">
                        <span>
                                <img src="Images/down.PNG" id="dsdown" height="30" width="30" class="imgclick"/></span>
                       </td>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/close.PNG" id="dcclose" height="30" width="30" class="imgclick"/></span>
                       </td>
                </tr>                
            </table>
                </div>
                    </div>
                </td>

                <td>
                <div style="height:290px;width:290px;  border:none">
             
                <header style=" background-color:#d9edf7;color:black; text-align:center;border:solid; border-color:#d9edf7 ">Microphone Control&nbsp;
                    <span class="fa fa-angle-double-down trying" data-toggle="collapse" data-target="#Microphone" style="color:#31708f;"></span>
                </header>
                    
                <div id="Microphone" class="divcontrols" style=" border-color: #31708f;">
                    <table style="width:270px; height:220px;">
                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="Label3" runat="server" Text="Wired Mic" Font-Size="Small"  ></asp:Label>
                    </td>
                    <td style="text-align:center">
                        <asp:Label ID="Label4" runat="server" Text="Wireless Mic" Font-Size="Small" ></asp:Label>
                    </td>
                    </tr>
                 <tr >
                    <td style="text-align:center" >
                        <span>
                                <img src="Images/volplus.PNG" id="wiredvolplus" height="30" width="30" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/volplus.PNG" id="wirelessvolplus" height="30" width="30" class="imgclick"/></span>
                       </td>
                </tr>
                 <tr >
                     
                    <td style="text-align:center">
                        <span>
                                <img src="Images/volminus.PNG" id="wiredvolminus" height="50" width="50" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/volminus.PNG" id="wirelessvolminus" height="50" width="50" class="imgclick"/></span>
                        </td>
                     </tr>
                       <tr >
                    <td style="text-align:center" class="auto-style1">
                        <span>
                                <img src="Images/mute.PNG" id="wiredmute" height="50" width="50" class="imgclick"/></span>
                        </td>
                     <td style="text-align:center" class="auto-style1">
                         <span>
                                <img src="Images/mute.PNG" id="wirelessmute" height="50" width="50" class="imgclick"/></span>
                       </td>
                </tr>
                
            </table>
                    </div>
                    </div>
                </td>

                <td>
                <div  style="height:290px ;width:180px; border:none ">
             
                <header style=" background-color:#fcf8e3;color:black ; border:solid; border-color:#fcf8e3; text-align:center "> Volume&nbsp;
                     <span data-toggle="collapse" data-target="#volume" style="color:#916d3b"class="fa fa-angle-double-down trying" ></span>
                </header>
                <div id="volume" class="divcontrols" style=" border-color:#916d3b">
                     <table style="width:160px; height:220px;">
               
                <tr  >
                    <td style="text-align:center" >
                        <span>
                                <img src="Images/volplus.PNG" id="volplus" height="50" width="50" class="imgclick"/></span>
                          </td>
                    </tr>
                 <tr  >
                    <td style="text-align:center">
                        <span>
                                <img src="Images/volminus.PNG" id="volminus" height="50" width="50" class="imgclick"/></span>
                       </td>
                         </tr>
                 <tr >
                    <td style="text-align:center">
                        <span>
                                <img src="Images/mute.PNG" id="mute" height="50" width="50" class="imgclick"/></span>
                        
                        </td>
                </tr>
            </table>
                    </div>
                 
                    </div>
                </td>
            </tr>
        </table>
      
    </div>
     </div>
    <script type="text/javascript">
       
        window.onclick = function (event) {
            if (event.target == modal) {
                document.getElementById("control").style.display = "none";
            }
        }
        
    </script>
    
</asp:Content>

