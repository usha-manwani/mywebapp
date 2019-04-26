<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="WebCresij.UploadFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
    <style>
        .divstyle {
            background-color: #191b28;
            color: white;
            -moz-box-shadow: inset 0 0 5px #000000;
            -webkit-box-shadow: inset 0 0 5px #000000;
            box-shadow: inset 0 0 5px #000000;
            border-width: 2px 10px 10px 2px;
            margin-left: 15px
        }
        .btn-custom{
            color:#2c95af;
            border:1px solid #2c95af;
            width:80px;
            margin-right:20px
        }
        .btn-custom:hover{
            color:#98def0;
            border:1px solid #98def0;
        }
        
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="masterchildBody" runat="server">
    <asp:ScriptManagerProxy runat="server" ></asp:ScriptManagerProxy>
    <div style="padding-top:40px">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                 <div style="min-height:450px;width:90%; margin-bottom:40px;color:#ffaa4d">
            <div class="divstyle" id="playArea" style="width:60%;float:left;min-height:450px;">
                <canvas height="100%" width="100%" runat="server" id="displayFiles"></canvas>
            </div>
            <div style="background-color:#263f75;margin-left:40px;width:30%;float:left;min-height:450px">
                
                <div style="float:left;width:100%"><%=Resources.Resource.filen%>: <asp:Label runat="server" ID="fileName" Text=""></asp:Label></div>
                <div style="float:left;width:100%"><%=Resources.Resource.FileType%>: <asp:Label runat="server" ID="fileType" Text=""></asp:Label></div>
                <div style="float:left;width:100%"><%=Resources.Resource.FileSize%>: <asp:Label  runat="server" ID="fileSize" Text=""></asp:Label></div>
                <%--<div style="float:left;width:100%">Creation date: <asp:Label runat="server" ID="fileDate" Text=""></asp:Label></div>--%>
                <div style="float:left;width:100%"><%=Resources.Resource.FileDate%>: <asp:Label  runat="server" ID="fileCreation" Text=""></asp:Label></div>
                <div style="float:left;width:100%"><%=Resources.Resource.Filemod%>: <asp:Label  runat="server" ID="fileDateMod" Text=""></asp:Label></div>
                
            </div>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
       
        <div>
            <h5 style="border-bottom:1px solid white">Files</h5>
            <div>
                <span class="btn btn-custom" id="videobtn"> <%=Resources.Resource.Video%></span>
                <span class="btn btn-custom" id="pptbtn"> PPT</span>
                <span class="btn btn-custom" id="audiobtn"> <%=Resources.Resource.audio%></span>
                <span class="btn btn-custom" id="imagebtn"> <%=Resources.Resource.image%></span>

            </div>
        </div>
    </div>
    <div class="divopt" style="padding-top:10px;">
         <fieldset  >
            <legend> <span><%=Resources.Resource.UploadFiles%>
                <span style="font-size:small" class="control-label"> <%=Resources.Resource.MaxFileSize%></span>
                     </span></legend>
        <div  class="form-group">
            <div style="border:thin">
            
        <asp:FileUpload runat="server" ID="fuSample"/>
                <asp:Button  runat="server" ID="btnUpload" Text="<%$Resources:Resource, Upload %>" 
                onclick="btnUpload_Click" CssClass="btn btn-info" />
            </div>
        
                <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
        </div>
            </fieldset>
          
    <div style="margin-top:-70px">
        <asp:UpdatePanel runat="server" >
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1" />
            </Triggers>
            <ContentTemplate>    
        <asp:GridView  Width="80%" GridLines="Horizontal" BorderStyle="None"
            CellPadding="5"  ID="GridView1" runat="server" AutoGenerateColumns="false"
            EmptyDataText = "<%$Resources:Resource, NoFileUpload %>" OnRowCommand="GridView1_RowCommand"
            AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10">
             
            <HeaderStyle BorderColor="Transparent"/>
    <Columns>
        <asp:BoundField DataField="Text" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkdelete" runat="server" Text="<%$Resources:Resource, Delete %>"  
                    CommandArgument = '<%# Eval("Value") %>' OnClick="lnkdelete_Click"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                
                        <asp:LinkButton ID="lnkDownload" Text = "<%$Resources:Resource, Download %>" CommandName="download"  
                    CommandArgument = '<%# Eval("Value") %>' runat="server"  ></asp:LinkButton>
                   
                
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkPlay" runat="server" Text="<%$Resources:Resource, play %>"  
                    CommandArgument='<%# Eval("Value") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDetails" Text="<%$Resources:Resource, details %>" runat="server" CommandName="details"
                    CommandArgument='<%# Eval("Value") %>' ></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
        
    </Columns>
</asp:GridView>
                
                </ContentTemplate>
            
        </asp:UpdatePanel>
      </div>
    </div>

    <script>
        function PlayVideo() {

        }
        function PlayAudio() {

        }
        function OpenImage() {

        }
        $(document).on("click", "#videobtn", function () { });
        $(document).on("click", "#audiobtn", function () { });
        $(document).on("click", "#pptbtn", function () { });
        $(document).on("click", "#imagebtn", function () { });
    </script>
</asp:Content>
