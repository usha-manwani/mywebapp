﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.master" AutoEventWireup="true" CodeBehind="CardLogs.aspx.cs" Inherits="WebCresij.CardLogs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
    <link href="css/logs.css" rel="stylesheet" />
    <link href="lib/advanced-datatable/css/demo_page.css" rel="stylesheet" />
  <link href="lib/advanced-datatable/css/demo_table.css" rel="stylesheet" />
  <link rel="stylesheet" href="lib/advanced-datatable/css/DT_bootstrap.css" />
  <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.31.1/js/jquery.tablesorter.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.31.1/js/jquery.tablesorter.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
    
     <script src="Scripts/jquery.signalR-2.4.0.js"></script>
        <script src="Scripts/jquery.signalR-2.4.0.min.js"></script>
  
    <!--Reference the autogenerated SignalR hub script. -->
   <script src='<%: ResolveClientUrl("~/signalr/hubs") %>' ></script> 
    <script src="Scripts/cardlogs.js?v=2"></script>
    <div class="content-panel">
    <asp:UpdatePanel runat="server" ID="up1" >
        <ContentTemplate>          
            <asp:Label ID="label1" runat="server"></asp:Label>
                <div class="row">
                    <h3><p>Logs for Cards Scanned!!</p></h3>
                </div>
                <div class="row mb" >
       <div class="col">
           <asp:DropDownList ID="ddlsort" runat="server" AutoPostBack="true" 
               CssClass="btn btn-default border dropdown" OnSelectedIndexChanged="ddlsort_SelectedIndexChanged">
               <asp:ListItem Value="Name" Text="Name"></asp:ListItem>
               <asp:ListItem Value="Time" Text="Time"></asp:ListItem>
               <asp:ListItem Value="Location" Text="Location"></asp:ListItem>
               <asp:ListItem Value="memberID" Text="MemberID"></asp:ListItem>
           </asp:DropDownList>
           <asp:LinkButton runat="server" ID="btnAsc" CssClass="icons1" OnClick="btnAsc_Click" 
               Text='<i class="fa fa-sort-alpha-down"></i>'></asp:LinkButton>
       </div>
        <div class="col">
            <asp:DropDownList ID="ddlPageSize" runat="server" 
                AutoPostBack="true" CssClass="btn btn-default border dropdown" 
                OnSelectedIndexChanged="PageSize_Changed">
    <asp:ListItem Text="10" Value="10" />
    <asp:ListItem Text="25" Value="25" />
    <asp:ListItem Text="50" Value="50" />
</asp:DropDownList> Records Per Page!!
        </div>       
    </div>
            <div class="row mb">
                <asp:Label runat="server" ID="lblTitle"></asp:Label>
            </div>
    <div class=" row mb">        
        <div class=" col-8">
            <div class="adv-table">
            <asp:GridView runat="server" cellpadding="0" cellspacing="0" ID="gv1"
                border="0" class="display table table-bordered" AutoGenerateColumns="false"
                  AllowPaging="true" AllowSorting="true" OnSorting="gv1_Sorting"
                 PageSize="10" PagerSettings-Mode="Numeric" OnPageIndexChanging="gv1_PageIndexChanging">
                <HeaderStyle CssClass="hidden-phone" />
                <RowStyle CssClass="gradeX center" />
                <AlternatingRowStyle CssClass="gradeC center" />              
            <Columns>
                <asp:BoundField HeaderText="MemeberID" DataField="memberID" />
                <asp:BoundField HeaderText="Name" DataField="name" />
                <asp:BoundField HeaderText="CardID" DataField="cardID" />
                <asp:BoundField HeaderText="Time" DataFormatString="{0:F}" DataField="Time" HtmlEncode="false" />  
                <asp:BoundField HeaderText="Location" DataField="Location" />
            </Columns>
    </asp:GridView>
            
                </div>
        </div>
    </div>      
            <div class="row mb">
                <asp:Button CssClass="btn btn-info" Text="Export to Excel" runat="server" ID="exportexcel" OnClick="exportexcel_Click"/>
            </div>
            </ContentTemplate>
           
    </asp:UpdatePanel>
    </div>
      <script type="text/javascript"  src="lib/advanced-datatable/js/jquery.js"></script>   
  <script type="text/javascript"  src="lib/advanced-datatable/js/jquery.dataTables.js"></script>
  <script type="text/javascript" src="lib/advanced-datatable/js/DT_bootstrap.js"></script>
</asp:Content>
