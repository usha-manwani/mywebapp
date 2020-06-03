<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="WebCresij.FAQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
   <style>
    .flex {
        display: flex;
        background: pink;
        width:400px;
        overflow: auto;
        align-items:center;    
    }

.item {
  min-width: 100px;
  height: 100px;
  background: black;
  margin: 8px;  
}
       </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterchildBody" runat="server">
   <div class="flex" style="padding-right:20px">
  <div class="item"></div>
  <div class="item"></div>
  <div class="item"></div>
  <div class="item"></div>
  <div class="item" ></div>
</div>
</asp:Content>
