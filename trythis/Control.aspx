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
 .modal 
 {
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
    width: 50%;
        }
    .pp{
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
        <input type="hidden" name="ipForRemote" value="<%= Session["MyVariable"]%>" />
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
             border-radius:5px" class="row " onmouseover="this.style.background='white';"
             onmouseout="this.style.background='#dff0d8';">
        <header>
            <p style="text-align:center">Remote Control For 
                <asp:Label runat="server" Font-Bold="true" Font-Italic="true" ID="deviceips" Text=""></asp:Label></p>
            </header>
       <div style="text-align:right">
             <i class="fa fa-times-circle" aria-hidden="true" onclick="closexx();"
                 style="text-align:right;cursor:pointer"></i>
         </div>
      </div>        
        <input id="sessionInput" type="hidden" value='<%= Session["DeviceIP"] %>' />
        <input id="sessionInput1" type="hidden" value='<%= Session["loc"] %>' />
        <input id="dev" type="hidden" value='<%=Session["devices"] %>' />
        <asp:TextBox style="display:none" ID="ipAddressToSend" runat="server"></asp:TextBox>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" ></asp:ScriptManagerProxy>
        <table  class="container " >
            <tr>
                <td>   
                <div  style="height:250px;width:250px;  border:none">    
             <header style=" background-color:#2680a7;color:black; text-align:center;border:solid;
                border-color:#428bca ">System Control&nbsp;
                 <span data-toggle="collapse" data-target="#system" style="color:white" 
                     class="fa fa-angle-down trying" ></span>
             </header>          
           <div id="system" class="divcontrols"  >
                <table style=" height:180px; width:220px;border-color:#333333" >
                    <tr > 
                        <td colspan="3" style="font-size:small; text-align:center"> System Power</td>
                        <td colspan="3" style="font-size:small; text-align:center"> Computer Power</td>
                    </tr>
                    <tr style="align-items:center; align-content:center;">
                        <td colspan="3" style="text-align:center">
                            <span>
                                <img src="Images/offimages/sysof.png" id="systempower" 
                                    height="60" width="60" class="imgclick"/></span>
                             </td>
                        <td colspan="3" style="text-align:center">
                            <span>
                                <img src="Images/offimages/pcof.png" id="pcpower" 
                                    height="60" width="60" class="imgclick"/></span>                          
                    </tr>                               
                    <tr >
                        <td colspan="2" style="text-align:center">
                            <span>
                                <img src="Images/offimages/sysunlock.png"  id="syslock" 
                                    height="40" width="40" class="imgclick"/></span>                            
                           </td>                      
                        <td colspan="2" style="text-align:center"  >
                            <span>
                                <img src="Images/offimages/podiumunlock.png" id="podiumlock"
                                    height="40" width="40" class="imgclick"/></span>
                            </td>                       
                        <td colspan="2" style="text-align:center" >
                            <span>
                                <img src="Images/offimages/classunlock.png"  id="classlock" 
                                    height="40" width="40" class="imgclick"/></span>
                             </td>
                    </tr>
                   <%-- <tr >
                        <td colspan="2" style="font-size:small; text-align:center">system lock</td>
                        <td colspan="2" style="font-size:small; text-align:center" >podium lock</td>
                        <td colspan="2" style="font-size:small; text-align:center">class lock</td>
                    </tr>--%>
                </table> 
               </div>          
                </div>
                </td>
                <td>
                <div style="height:250px;width:250px;  border:none">            
             <header style=" background-color:#dff0d8;color:black; text-align:center ;border:solid; border-color:#dff0d8">Projector Control&nbsp;
                  <span data-toggle="collapse" data-target="#Projector" style="color:#3c763d"class="fa fa-angle-down trying" ></span>
             </header>
             <div id="Projector" class="divcontrols" style=" border-color:#3c763d">
                     <table style=" height:180px; width:230px">                  
                    <tr style="width:220px">
                        <td style="text-align:center">
                             <span>
                                <img src="Images/offimages/proj1.png" id="projectorOn" 
                                    height="40" width="40" class="imgclick"/></span>                
                        </td>
                        <td style="text-align:center">
                            <a  href="#" style=" color:white;">
                                <img src="Images/offimages/hdmi.png" id="hdmi" height="40" 
                                    width="40" class="imgclick"/></a>                            
                        </td>
                    </tr>
                    <tr style="width:220px">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/proj2.png" id="projectorOff" 
                                    height="40" width="40" class="imgclick"/></span>                            
                        </td>
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/videooff.png" id="projVideo"
                                    height="40" width="40" class="imgclick"/></span>
                           </td>
                    </tr>
                    <tr style="width:220px">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/proj3.png" id="projSleep"
                                    height="40" width="40" class="imgclick"/></span>
                            </td>
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/vga.png" id="vga" 
                                    height="40" width="40" class="imgclick"/></span>
                             </td>
                    </tr>                
                </table>
             </div>
             </div>
                </td>
                <td>
                <div style="height:250px;width:180px;  border:none">             
             <header style=" background-color:#d9edf7;color:black; text-align:center;
                        border:solid; border-color:#d9edf7 ">Light Control&nbsp;
                 <span class="fa fa-angle-down trying" data-toggle="collapse"
                     data-target="#light" style="color:#31708f;">
                     </span></header>                       
                    <div id="light" class="divcontrols" style=" border-color: #31708f;">
                             <table style="width:160px; height:180px;">
                 
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/light1off.png" id="light1"
                                    height="40" width="40" class="imgclick"/></span>
                             </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/light2off.png" id="light2" 
                                    height="40" width="40" class="imgclick"/></span>
                             </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <span>
                                <img src="Images/offimages/light3.png" id="light3" 
                                    height="40" width="40" class="imgclick"/></span>
                            </td>
                    </tr>
                </table>
                    </div>
             </div>
                </td>
                <td rowspan="2">
                <div  style=" width:180px; height:500px "> 
            <header style=" background-color:#fcf8e3;color:black; text-align:center;
                    border:solid; border-color:#fcf8e3 ">Media Signal&nbsp;
                <span data-toggle="collapse" data-target="#media" style="color:#916d3b" 
                    class="fa fa-angle-down trying" ></span>
            </header>
            <div id="media" class="divcontrols" style=" border-color:#916d3b">
                <table style="width:160px;">                 
                    <tr  style="width:130px;">
                        <td  style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="desktop" checked>
                            <img src="Images/offimages/desktop.png" height="40" width="40" class="imgclick">
                            </label>
                            </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="laptop" checked>
                            <img src="Images/offimages/laptop.png" height="40" width="40" class="imgclick">
                            </label>
                            </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="platform" checked>
                            <img src="Images/platform.png" height="40" width="40" class="imgclick">
                            </label>
                           </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center" >
                             <label>
                            <input type="radio" name="test" id="digitalEquipment" checked>
                            <img src="Images/platform.png" height="40" width="40" class="imgclick">
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="dvd" checked>
                            <img src="Images/offimages/dvd.png" height="40" width="40" class="imgclick">
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                           <label>
                            <input type="radio" name="test" id="bluray" checked>
                            <img src="Images/offimages/bluraydvd.png" height="40" width="40" class="imgclick">
                            </label>
                       </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td  style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="tv" checked>
                            <img src="Images/offimages/tv.png" height="40" width="40" class="imgclick">
                            </label>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center">
                            <label>
                            <input type="radio" name="test" id="camera" checked>
                            <img src="Images/offimages/camera.png" height="40" width="40" class="imgclick">
                            </label>    
                       </td>
                            </tr>
                    <tr  style="width:130px;">
                        <td style="text-align:center" >
                            <label>
                            <input type="radio" name="test" id="recorder" checked>
                            <img src="Images/offimages/video.png" height="40" width="40" class="imgclick">
                            </label>    
                        </td></tr>
                </table>
                </div>
                     </div>
                    </td>
                <td  rowspan="2">                   
                <div  style=" width:200px; height:500px "> 
            <header style=" background-color:#428bca;color:black; text-align:center;
                    border:solid; border-color:#428bca ">DVD Controls&nbsp;
                <span data-toggle="collapse" data-target="#dvdsubmenu" style="color:white" 
                    class="fa fa-angle-down trying" ></span>
            </header>
            <div id="dvdsubmenu" class="divcontrols" style=" border-color:#428bca">
                <table style="width:180px; height:400px">                 
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/poweroff.png" id="dvdpoweron" height="40" width="40" />
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/stop.png" id="dvdstop" height="40" width="40" />
                        </td>
                            </tr>
                   <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/play.png" id="playdvd" height="40" width="40" />
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/pause.png" id="dvdpause" height="40" width="40" />
                        </td>
                            </tr>
                   <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/backward.png" id="dvdback" height="40" width="40" />
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/forward.png" id="dvdforward" height="40" width="40" />
                        </td>
                            </tr>
                    <tr>
                        <td  style="text-align:center">
                            <img src="Images/submenu/dvd/pre.png" id="dvdpre" height="40" width="40" />
                           </td>
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/next.png" id="dvdnext" height="40" width="40" />
                        </td>
                  <tr>                       
                        <td style="text-align:center">
                            <img src="Images/submenu/dvd/exit.png" id="dvdexit" height="40" width="40" />
                        </td>
                            </tr>
                   
                </table>
                </div>
                     </div>                   
                </td>
            </tr>
            <tr>
                <td>
                <div style="height:250px;width:250px; border:none">
             
                <header style=" background-color:#dff0d8;color:black; text-align:center;
                        border:solid; border-color:#dff0d8 ">Screen & curtain&nbsp;
                    <span data-toggle="collapse" data-target="#ScreenCurtain" 
                        style="color:#3c763d"class="fa fa-angle-down trying" ></span>
                </header>
                <div id="ScreenCurtain" class="divcontrols" style=" border-color:#3c763d">
                <table style="width:220px; height:180px;">
                
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
                                <img src="Images/offimages/up.PNG" id="dsup" 
                                    height="40" width="40" class="imgclick"/></span>   
                    </td>
                    <td style="text-align:center">
                         <span>
                                <img src="Images/offimages/open.PNG" id="dcopen"
                                    height="40" width="40" class="imgclick"/></span>
                         </td>
                </tr>
                 <tr>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/offimages/stopscreen.PNG" 
                                    id="dsstop" height="40" width="40" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/stopcurtain.PNG" 
                                    id="dcstop" height="40" width="40" class="imgclick"/></span>
                        </td>
                     </tr>
                      <tr >
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/screendown.PNG" id="dsdown" 
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                    <td  style="text-align:center">
                        <span>
                                <img src="Images/offimages/curtainclose.PNG" id="dcclose"
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                </tr>                
            </table>
                </div>
                    </div>
                </td>
                <td>
                <div style="height:250px;width:250px;  border:none">            
                <header style=" background-color:#d9edf7;color:black; text-align:center;
                    border:solid; border-color:#d9edf7 ">Microphone Control&nbsp;
                    <span class="fa fa-angle-down trying" data-toggle="collapse" 
                        data-target="#Microphone" style="color:#31708f;"></span>
                </header>
                    
                <div id="Microphone" class="divcontrols" style=" border-color: #31708f;">
                    <table style="width:250px; height:180px;">
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
                                <img src="Images/offimages/wiredvolplus.PNG" id="wiredvolplus"
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/wirelessvolplus.PNG" id="wirelessvolplus"
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                </tr>
                 <tr>                  
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/wiredvolminus.PNG" id="wiredvolminus"
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/wirelessvolminus.PNG" id="wirelessvolminus"
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                     </tr>
                       <tr >
                    <td style="text-align:center" class="auto-style1">
                        <span>
                                <img src="Images/offimages/wiredmute.PNG" id="wiredmute"
                                    height="40" width="40" class="imgclick"/></span>
                        </td>
                     <td style="text-align:center" class="auto-style1">
                         <span>
                                <img src="Images/offimages/wirelessmute.PNG" id="wirelessmute"
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                </tr>                
            </table>
                    </div>
                    </div>
                </td>
                <td>
                <div  style="height:250px ;width:180px; border:none ">             
                <header style=" background-color:#fcf8e3;color:black ; border:solid;
                        border-color:#fcf8e3; text-align:center "> Volume&nbsp;
                     <span data-toggle="collapse" data-target="#volume" style="color:#916d3b" 
                         class="fa fa-angle-down trying" ></span>
                </header>
                <div id="volume" class="divcontrols" style=" border-color:#916d3b">
                     <table style="width:160px; height:180px;">
               
                <tr>
                    <td style="text-align:center" >
                        <span>
                                <img src="Images/offimages/volplus.PNG" id="volplus"
                                    height="40" width="40" class="imgclick"/></span>
                          </td>
                    </tr>
                 <tr>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/volminus.PNG" id="volminus"
                                    height="40" width="40" class="imgclick"/></span>
                       </td>
                         </tr>
                 <tr>
                    <td style="text-align:center">
                        <span>
                                <img src="Images/offimages/mute.PNG" id="mute"
                                    height="40" width="40" class="imgclick"/></span>                        
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

