﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="trythis.UploadFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divopt" style="padding-top:2em;">
        
        
        <fieldset >
            <legend>Upload Files</legend>
        <div  class="form-group">
            <p style="font-size:x-small" class="control-label">Max File Size allowed to upload is 1GB</p>
        <asp:FileUpload runat="server" ID="fuSample" BorderColor="Black"  ForeColor="Black"  />
            <br />
        <asp:Button  runat="server" ID="btnUpload" Text="Upload" 
                onclick="btnUpload_Click" CssClass="btn btn-default" />
                <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
        </div>
            </fieldset>
            <br />
        <br />
        <br />
        <br />
    <div>
        <fieldset >
            <legend>Download Files</legend>
       
        <asp:GridView  Width="80%" GridLines="Horizontal" BorderStyle="None"
            CellPadding="20" CellSpacing="20" ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded" >
             <RowStyle Height="50" />
    <Columns>
        <asp:BoundField DataField="Text" HeaderText="Files" HeaderStyle-Font-Size="X-Large" ControlStyle-ForeColor="Black" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
</asp:GridView>
            </fieldset>
    </div>
    </div>
</asp:Content>
