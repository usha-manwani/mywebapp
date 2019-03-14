<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="WebCresij.UploadFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="masterBody" runat="server">
    <div class="divopt" style="padding-top:2em;">
        
        
        <fieldset  >
            <legend> <span><%=Resources.Resource.UploadFiles%></span></legend>
        <div  class="form-group">
            <div style="border:thin">
            <p style="font-size:small" class="control-label"> <span><%=Resources.Resource.MaxFileSize%></span></p>
        <asp:FileUpload runat="server" ID="fuSample"   />
            </div>
        <asp:Button  runat="server" ID="btnUpload" Text="<%$Resources:Resource, Upload %>" 
                onclick="btnUpload_Click" CssClass="btn btn-info" />
                <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
        </div>
            </fieldset>
            <br />
        <br />
        <br />
        <br />
    <div>
        <fieldset >
            <legend><span><%=Resources.Resource.DownloadFiles%></span></legend>
       
        <asp:GridView  Width="80%" GridLines="Horizontal" BorderStyle="None"
            CellPadding="20" CellSpacing="20" ID="GridView1" runat="server" AutoGenerateColumns="false" EmptyDataText = "<%$Resources:Resource, NoFileUpload %>" >
             <RowStyle Height="50" />
    <Columns>
        <asp:BoundField DataField="Text" HeaderText="<%$Resources:Resource, Files %>" HeaderStyle-Font-Size="X-Large"  />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" Text = "<%$Resources:Resource, Download %>" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile" CssClass="asplink"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>
</asp:GridView>
            </fieldset>
    </div>
    </div>
</asp:Content>
