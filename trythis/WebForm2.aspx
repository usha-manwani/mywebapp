<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebCresij.WebForm2" %>
<%@ MasterType VirtualPath="~/Site.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .landing {
   
    position: fixed;
}
        .landing-wrapper {
    height: 800px;
    width:80%;
    display:inline-block;
    box-sizing:border-box;
    
}
        .canvas1{
            background:rgba(0,0,0, 1.0);
        }
       
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class=" divopt">
    <div class="row ">
        <div class="col">
            <canvas height="300" width="300" class="canvas1"  ></canvas>
        </div>
        <div class="col"><canvas height="300" width="300" class="canvas1"  ></canvas></div>
        <div class="col"><canvas height="300" width="300" class="canvas1"></canvas></div>
        <div class="col"><canvas height="300" width="300" class="canvas1"></canvas></div>
    </div>
    </div>
     <div style="position:relative;" id="gridDiv">
      
      <asp:GridView Width="550" GridLines="Horizontal" BorderStyle="None"  
            CellPadding="2" CellSpacing="2" ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText = "No Cameras Registered for the Selected Class" >
          <RowStyle Height="40" />
          <Columns> 
              <asp:BoundField HeaderText="Camera" DataField="CamName" />
              <asp:BoundField HeaderText="IP Address" DataField="CameraIP" />
              <asp:BoundField DataField="portNo" Visible="false" />
              <asp:BoundField DataField="CameraID" Visible="false" />
              <asp:BoundField DataField="password" Visible="false" />
              <asp:BoundField DataField="CameraProvider" Visible="false" />
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="loginipcam" Text="Play" runat="server" 
                          OnClientClick='<%#string.Format("return clickLogin(\"{0}\", \"{1}\", \"{2}\",\"{3}\", \"{4}\");", Eval("CameraIP"), Eval("portNo"), Eval("CameraID"), Eval("password"), Eval("CameraProvider")) %> '/>
                  </ItemTemplate>
              </asp:TemplateField>
          </Columns>
      </asp:GridView>
  </div>
    
    <asp:ScriptManagerProxy ID="scc" runat="server"></asp:ScriptManagerProxy>
  

 
    
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    
    

    <link href="Content/demo.css" rel="stylesheet" />


</asp:Content>
