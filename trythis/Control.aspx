<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="trythis.Control" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .RoundButton{            
-moz-border-radius: 10px;
-webkit-border-radius: 10px;
border-radius: 10px; 
        }      
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divopt">
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" ></asp:ScriptManagerProxy>
        <asp:UpdatePanel runat="server" ID="updateControl" UpdateMode="Conditional">
            <ContentTemplate>
        <div >
        <table>
        <tr>
        <td>
        <div class="col-md-3 col" style="width:300px">
            <asp:Panel ID="Panel1" runat="server"  Height="250" Width="290" BackColor="White" BorderColor="#008888" BorderStyle="Solid">
         
                <table style=" height:120px; width:280px">
                    <tr >
                        <td colspan="2" style="font-size:medium; font-weight:bold; color:darkcyan;  text-align:center">System Control</td>
                    </tr>
                    <tr>
                        <td style="font-size:small"> System Power</td>
                        <td style="font-size:small"> Computer Power</td>
                    </tr>
                    <tr style="align-items:center; align-content:center">
                        <td style="align-items:center; align-content:center">
                            <asp:ImageButton  ID="poweronOff" runat="server" Height="70" Width="70" ImageUrl="~/Images/powerOff.png" OnClick="ImageButton16_Click" ToolTip="Power On" onmouseover=""   /></td>
                        <td style="align-items:center; align-content:center">
                            <asp:ImageButton ID="pcpoweronoff" runat="server"  Height="70" Width="70" ImageUrl="~/Images/powerOff.png" ToolTip="Power On" OnClick="ImageButton16_Click"/></td>                    
                    </tr>
                </table>
                <table style=" height:100px; width:280px">                
                    <tr>
                        <td>
                            <asp:ImageButton ID="syslock" runat="server" ImageUrl="~/Images/unlock.png" Height="40" Width="40" /></td>
                        <td>
                            <asp:ImageButton ID="podiumlock" runat="server" ImageUrl="~/Images/unlock.png" Height="40" Width="40"  /></td>
                        <td>
                            <asp:ImageButton ID="classlock" runat="server" ImageUrl="~/Images/unlock.png" Height="40" Width="40"  /></td>
                    </tr>
                    <tr>
                        <td style="font-size:small">system lock</td>
                        <td style="font-size:small">podium lock</td>
                        <td style="font-size:small">class lock</td>
                    </tr>
                </table>            
            </asp:Panel>
        </div>
        </td>
        <td>
        <div class="col-md-3 col" style=" width:300px">
            <asp:Panel ID="Panel2" runat="server" Height="250" Width="290" BackColor="White" BorderColor="#008888" BorderStyle="Solid">

                <table style=" height:220px; width:260px">
                    <tr >
                        <td colspan="2" style="font-size:medium; font-weight:bold; color:darkcyan; text-align:center">Program Control</td>
                    </tr>
                    <tr style="width:220px">
                        <td style="float:left">
                            <asp:Button ID="pcPowerOn" CssClass="RoundButton" runat="server" Text="PowerOn" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White" />
                        </td>
                        <td style="float:right; ">
                            <asp:Button ID="pcHDMI" CssClass="RoundButton" runat="server" Text="HDMI" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White" />
                        </td>
                    </tr>
                    <tr style="width:220px">
                        <td style="float:left">
                            <asp:Button ID="pcPowerOff" CssClass="RoundButton" runat="server" Text="PowerOff" Font-Size="Small"  Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                        </td>
                        <td style="float:right">
                            <asp:Button ID="pcVideo" CssClass="RoundButton" runat="server" Text="Video" Font-Size="Small"  Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                        </td>
                    </tr>
                    <tr style="width:220px">
                        <td style="float:left">
                            <asp:Button ID="pcSleep" CssClass="RoundButton" runat="server" Text="Sleep" Font-Size="Small"  Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                        </td>
                        <td style="float:right">
                            <asp:Button ID="pcVGA" CssClass="RoundButton" runat="server" Text="VGA"  Font-Size="Small" Height="35" Width="80"  BackColor="#666666" ForeColor="White"/>
                        </td>
                    </tr>                
                </table>
            </asp:Panel>
        </div>
        </td>
        <td>
        <div class="col-md-3 col" style=" width:200px">
            <asp:Panel ID="Panel3" runat="server" Height="250" Width="150" BackColor="White" BorderColor="#008888" BorderStyle="Solid">
                <table style="width:140px; height:220px;">
                    <tr >
                        <td colspan="2" style="font-size:medium; font-weight:bold; color:darkcyan; text-align:center">Light Control</td>
                    </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="light1" runat="server" CssClass="RoundButton" Text="Light 1" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="light2" runat="server" CssClass="RoundButton" Text="Light 2" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="light3" runat="server" CssClass="RoundButton" Text="Light 3" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        </td>            
        <td rowspan="2">
        <div  style=" width:200px"> 
            <asp:Panel ID="Panel9" runat="server" Height="530" Width="150" BackColor="White" BorderColor="#008888" BorderStyle="Solid">
                <table style="width:140px; height:500px;">
                    <tr >
                        <td colspan="2" style="font-size:medium; font-weight:bold; color:darkcyan; text-align:center">Media Control</td>
                    </tr>
                    <tr  style="width:130px;">
                        <td  >
                            <asp:Button ID="desktop" runat="server" CssClass="RoundButton" Text="Desktop PC" Font-Size="Small" Height="35" Width="100" BackColor="#666666" ForeColor="White" OnClick="Button19_Click"/>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="laptop" runat="server" CssClass="RoundButton" Text="Laptop" Font-Size="Small" Height="35" Width="100" BackColor="#666666" ForeColor="White" OnClick="Button20_Click"/>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="digitalScreen" runat="server" CssClass="RoundButton" Text="Digital Screen" Font-Size="Small" Height="35" Width="100" BackColor="#666666" ForeColor="White" OnClick="Button21_Click"/>

                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td  >
                            <asp:Button ID="digitalCurtain" runat="server" CssClass="RoundButton" Text=" Digital Curtain" Font-Size="Small" Height="35" Width="100" BackColor="#666666" ForeColor="White" OnClick="Button22_Click"/>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="dvd" runat="server" CssClass="RoundButton" Text="DVD" Font-Size="Small" Height="35" Width="100" BackColor="#666666" ForeColor="White" OnClick="Button23_Click"/>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="bluray" runat="server" CssClass="RoundButton" Text="Blu-Ray DVD" Font-Size="Small" Height="35" Width="100" BackColor="#666666" ForeColor="White" OnClick="Button24_Click"/>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td  >
                            <asp:Button ID="tvset" runat="server" CssClass="RoundButton" Text="TV Set" Font-Size="Small" Height="35" Width="100" BackColor="#666666" ForeColor="White" OnClick="Button25_Click"/>
                        </td>
                    </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="vcr" runat="server" CssClass="RoundButton" Text="VCR" Font-Size="Small" Height="35" Width="100" BackColor="#666666" ForeColor="White" OnClick="Button26_Click"/></td>
                        </tr>
                    <tr  style="width:130px;">
                        <td>
                            <asp:Button ID="recorder" runat="server" CssClass="RoundButton" Text="Recorder" Font-Size="Small" Height="35px" Width="100px" BackColor="#666666" ForeColor="White" OnClick="Button27_Click"/></td>
                    </tr>
                </table>

            </asp:Panel>
        </div>
        </td>       
        </tr>
        <tr>
        <td>
        <div class="col-md-3 col" style="width:300px">
        <asp:Panel ID="Panel4" runat="server" Height="250" Width="290" BackColor="White" BorderColor="#008888" BorderStyle="Solid">
             <table style="width:260px; height:220px;">
                 <tr >
                    <td colspan="2" style="font-size:medium; font-weight:bold; color:darkcyan; text-align:center">Screen & Curtain Control</td>
                </tr>
                 <tr  style="width:220px;">
                    <td  style="float:left; font-size:small;">
                        Digital Screen                        
                    </td>
                    <td style="float:right; font-size:small;">
                       Digital Curtain
                    </td>
                </tr>
                <tr  style="width:220px;">
                    <td  style="float:left">
                        <asp:ImageButton ID="dsUp" CssClass="RoundButton" runat="server"  ImageUrl="~/Images/up.PNG" Height="40" Width="80" />
                        
                    </td>
                    <td style="float:right">
                        <asp:ImageButton ID="dcOpen" CssClass="RoundButton" runat="server"  ImageUrl="~/Images/oepn.PNG" Height="40" Width="80" />
                    </td>
                </tr>
                 <tr style="width:220px;">
                    <td  style="float:left">
                        <asp:ImageButton ID="dsStop" CssClass="RoundButton" runat="server"  ImageUrl="~/Images/stop.PNG" Height="40" Width="80" />
                    </td>
                    <td style="float:right">
                       <asp:ImageButton ID="dcStop" CssClass="RoundButton" runat="server"  ImageUrl="~/Images/stop.PNG" Height="40" Width="80"/>
                    </td>
                     </tr>
                      <tr style="width:220px;">
                    <td style="float:left">
                       <asp:ImageButton ID="dsDown" CssClass="RoundButton" runat="server"  ImageUrl="~/Images/down.PNG" Height="40" Width="80"/>
                    </td>
                    <td  style="float:right">
                        <asp:ImageButton ID="dcClose" CssClass="RoundButton" runat="server"  ImageUrl="~/Images/close.PNG" Height="40" Width="80" />
                    </td>
                </tr>                
            </table>
        </asp:Panel>
    </div>
        </td>
        <td>
    <div class="col-md-3 col" style=" width:300px">
        <asp:Panel ID="Panel5" runat="server" Height="250" Width="290" BackColor="White" BorderColor="#008888" BorderStyle="Solid">
             <table style="width:260px; height:220px;">
                 <tr >
                    <td colspan="2" style="font-size:medium; font-weight:bold; color:darkcyan; text-align:center">Microphone Control</td>
                </tr>
                <tr style="width:220px;" >
                    <td style="float:left">
                        <asp:Label ID="Label1" runat="server" Text="Wired Mic" Font-Size="Small"  ></asp:Label>
                    </td>
                    <td style="float:right">
                        <asp:Label ID="Label2" runat="server" Text="Wireless Mic" Font-Size="Small" ></asp:Label>
                    </td>
                    </tr>
                 <tr style="width:220px;">
                    <td style="float:left" >
                        <asp:Button ID="micWiredAdd" CssClass="RoundButton" runat="server" Text="add volume" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                   </td>
                    <td style="float:right">
                        <asp:Button ID="micAdd" CssClass="RoundButton" runat="server" Text="add volume" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                    </td>
                </tr>
                 <tr style="width:220px;">
                     
                    <td  style="float:left">
                        <asp:Button ID="micWiredSub" CssClass="RoundButton" runat="server" Text="sub volume" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                     </td>
                    <td style="float:right">
                        <asp:Button ID="micSub" CssClass="RoundButton" runat="server" Text="sub volume" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                    </td>
                     </tr>
                       <tr style="width:220px;">
                    <td style="float:left">
                        <asp:Button ID="micWiredMute" CssClass="RoundButton" runat="server" Text="mute" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                    </td>
                     <td  style="float:right">
                        <asp:Button ID="micMute" CssClass="RoundButton" runat="server" Text="mute" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                    </td>
                </tr>
                
            </table>
        </asp:Panel>
    </div>
        </td>
        <td>
    <div class="col-md-3 col" style=" width:200px">
        <asp:Panel ID="Panel6" runat="server" Height="250" Width="150" BackColor="White" BorderColor="#008888" BorderStyle="Solid">
         <table style="width:140px; height:220px;">
                <tr >
                    <td colspan="2" style="font-size:medium; font-weight:bold; color:darkcyan; text-align:center">Volume Control</td>
                </tr>
                <tr  style="width:130px;">
                    <td  >
                        <asp:Button ID="volumeAdd" runat="server" CssClass="RoundButton" Text="+ Volume" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/>
                    </td>
                    </tr>
                 <tr  style="width:130px;">
                    <td>
                        <asp:Button ID="volumeSub" runat="server" CssClass="RoundButton" Text="- Volume" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/></td>
                     </tr>
                 <tr  style="width:130px;">
                    <td>
                        <asp:Button ID="volumeMute" runat="server" CssClass="RoundButton" Text="mute" Font-Size="Small" Height="35" Width="80" BackColor="#666666" ForeColor="White"/></td>
                </tr>
            </table>

        </asp:Panel>
    </div>
        </td>
           </tr>

    </table>
            </div>
        <div  style="display:inline-block; float:left">
    
        <asp:Panel ID="Panel8" runat="server" Height="300" Width="250" BackColor="White" BorderColor="#008888" BorderStyle="Solid" >
            
             <table style="width:245px; height:256px;" >
                 
                <tr>
                    <td >
                        <asp:ImageButton ID="dvdpower" runat="server"  ImageUrl="~/Images/button_power.png" Height="40" Width="70" />
                        
                    </td>
                    <td >
                        <asp:ImageButton ID="dvdopen" runat="server"  ImageUrl="~/Images/button_open.png" Height="40" Width="70" />
                    </td>
                </tr>
                 <tr>
                    <td >
                        <asp:ImageButton ID="dvdstop" runat="server"  ImageUrl="~/Images/button_stop.png" Height="40" Width="70" />
                    </td>
                    <td >
                       <asp:ImageButton ID="dvdplay" runat="server"  ImageUrl="~/Images/button_play.png" Height="40" Width="70"/>
                    </td>
                     </tr>
                      <tr>
                    <td >
                       <asp:ImageButton ID="dvdprevious" runat="server"  ImageUrl="~/Images/button_previous.png" Height="40" Width="70"/>
                    </td>
                    <td  >
                        <asp:ImageButton ID="dvdnext" runat="server"  ImageUrl="~/Images/button_next.png" Height="40" Width="70" />
                    </td>
                </tr>
                 <tr>
                    <td >
                       <asp:ImageButton ID="dvdpause" runat="server"  ImageUrl="~/Images/button_pause.png" Height="40" Width="70"/>
                    </td>
                    <td  >
                        <asp:ImageButton ID="dvdforward" runat="server"  ImageUrl="~/Images/button_forward (1).png" Height="40" Width="70" />
                    </td>
                </tr>
                 <tr>
                    <td >
                       <asp:ImageButton ID="dvdrewind" runat="server"  ImageUrl="~/Images/button_rewind.png" Height="40" Width="70"/>
                    </td>
                    
                </tr>
                
            </table>

        </asp:Panel>
    </div>
            
     </ContentTemplate>
           
        </asp:UpdatePanel>
        
    </div>
    
    

</asp:Content>

