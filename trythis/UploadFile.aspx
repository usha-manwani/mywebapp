<%@ Page Title="" Language="C#" MasterPageFile="~/MastersChild.Master" AutoEventWireup="true" 
    CodeBehind="UploadFile.aspx.cs" Inherits="WebCresij.UploadFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="masterchildHead" runat="server">
    <style>
        .divstyle {
            background-color: #191b28;
            color: white;
            -moz-box-shadow: inset 0 0 5px #000000;
            -webkit-box-shadow: inset 0 0 5px #000000;
            box-shadow: inset 0 0 5px #000000;
            border-width: 2px 10px 10px 2px;
        }
        .btn-custom {
            color: #2c95af;
            border: 1px solid #2c95af;
            width: 80px;
            margin-right: 20px
        }
            .btn-custom:hover {
                color: #98def0;
                border: 1px solid #98def0;
            }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="masterchildBody" runat="server">
    <asp:ScriptManagerProxy runat="server"></asp:ScriptManagerProxy>
    <div class="row" style="margin-top:-2rem">
        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-xl-5 col-lg-7 col-md-12 col-sm-12">
                            <div class="divstyle" id="playArea" style="float: left; 
                                height: 350px; min-width: 100%">
                                <div style="width: 100%; height: 100%" id="displayFiles"></div>
                            </div>
                        </div>
                        <div class="col-xl-4 col-lg-5 col-md-12 col-sm-12">
                            <div style="background-color: #263f75; float: left; 
                                height: 350px; color: #c7b427">
                                <div style="float: left; width: 100%">
                                    <%=Resources.Resource.filen%>:
                            <asp:Label runat="server" ID="fileName" Text=""></asp:Label>
                                </div>
                                <div style="float: left; width: 100%">
                                    <%=Resources.Resource.FileType%>:
                            <asp:Label runat="server" ID="fileType" Text=""></asp:Label>
                                </div>
                                <div style="float: left; width: 100%">
                                    <%=Resources.Resource.FileSize%>:
                            <asp:Label runat="server" ID="fileSize" Text=""></asp:Label>
                                </div>
                                <%--<div style="float:left;width:100%">Creation date: 
                                    <asp:Label runat="server" ID="fileDate" Text="">
                                    </asp:Label></div>--%>
                                <div style="float: left; width: 100%">
                                    <%=Resources.Resource.FileDate%>:
                            <asp:Label runat="server" ID="fileCreation" Text=""></asp:Label>
                                </div>
                                <div style="float: left; width: 100%">
                                    <%=Resources.Resource.Filemod%>:
                            <asp:Label runat="server" ID="fileDateMod" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-xl-12 col-lg-12 col-md-12 col-sm-12">
                            <asp:Button runat="server" CssClass="btn btn-custom" ID="btnv"
                                OnClick="Videobtn_Click" Text="<%$Resources:Resource, Video %>"/>
                            <asp:Button runat="server" CssClass="btn btn-custom" ID="btnp"
                                OnClick="Btnp_Click" Text="PPT"/>
                            <asp:Button runat="server" CssClass="btn btn-custom" ID="btna"
                                OnClick="Btna_Click" Text="<%$Resources:Resource, audio %>"/>
                            <asp:Button runat="server" CssClass="btn btn-custom" ID="btni"
                                OnClick="Btni_Click" Text="<%$Resources:Resource, image %>"/>
                            <asp:Button runat="server" CssClass="btn btn-custom" ID="showAll"
                                OnClick="showAll_Click" Text="All Files"/>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            
            <div class="row" style="padding-top: 10px;">
                <div class="col-xl-10 col-lg-12 col-md-12 col-sm-12">
                    <fieldset>
                        <legend><span><%=Resources.Resource.UploadFiles%>
                            <span style="font-size: small" class="control-label">
                                <%=Resources.Resource.MaxFileSize%></span>
                        </span></legend>
                        <div class="form-group">
                            <div style="border: thin">
                                <asp:FileUpload runat="server" ID="fuSample" />
                                <asp:Button runat="server" ID="btnUpload" CausesValidation="false" 
                                   Text="<%$Resources:Resource, Upload %>"
                                  OnClick="btnUpload_Click" CssClass="btn btn-info" />
                            </div>
                            <asp:Label runat="server" ID="lblMessage" Text=""></asp:Label>
                        </div>
                    </fieldset>
                    <div style="margin-top: -50px">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                 <asp:GridView Width="80%" GridLines="Horizontal" BorderStyle="None"
                                    CellPadding="5" ID="VideoGrid" runat="server" AutoGenerateColumns="false"
                                    EmptyDataText="<%$Resources:Resource, NoFileUpload %>" 
                                    OnRowCommand="VideoGrid_RowCommand" Visible="false"
                                    AllowPaging="true" OnPageIndexChanging="VideoGrid_PageIndexChanging" 
                                    PageSize="10" ShowHeader="false">

                                    <HeaderStyle BorderColor="Transparent" />
                                    <Columns>
                                        <asp:BoundField DataField="Text" />
                                        <%--<asp:BoundField DataField="UserName" HeaderText="Uploaded By" />--%>
                                         
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkdelete" runat="server" 
                                                    Text="<%$Resources:Resource, Delete %>"
                                                    CommandArgument='<%# Eval("Value") %>' 
                                                    OnClick="lnkdelete_Click" ForeColor="DeepSkyBlue">

                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" 
                                                    Text="<%$Resources:Resource, Download %>" 
                                                    CommandName="download"
                                                    CommandArgument='<%# Eval("Value") %>' 
                                                    runat="server" ForeColor="DeepSkyBlue">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPlay" runat="server" 
                                                    Text="<%$Resources:Resource, play %>" CommandName="play"
                                                    CommandArgument='<%# Eval("Value") %>' 
                                                    ForeColor="DeepSkyBlue"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDetails" 
                                                    Text="<%$Resources:Resource, details %>" 
                                                    runat="server" CommandName="details"
                                                    CommandArgument='<%# Eval("Value") %>' 
                                                    ForeColor="DeepSkyBlue"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel runat="server" ID="panel1">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView1" />
                            </Triggers>
                            <ContentTemplate>
                                <div runat="server" id="gridview1div">
                                <span style="font-size:1.5rem; font-weight:bold">Personal Files</span>
                                <asp:GridView Width="80%" GridLines="Horizontal" BorderStyle="None"
                                    CellPadding="5" ID="GridView1" runat="server" AutoGenerateColumns="false"
                                    EmptyDataText="<%$Resources:Resource, NoFileUpload %>" 
                                    OnRowCommand="GridView1_RowCommand"
                                    AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" 
                                    PageSize="10" DataKeyNames="docinfo" ShowHeader="false">

                                    <HeaderStyle BorderColor="Transparent" />
                                    <Columns>
                                        <asp:BoundField DataField="Docinfo" />
                                        <%--<asp:BoundField DataField="UserName" HeaderText="Uploaded By" />--%>
                                         <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkshare" 
                                                    Text="Share" 
                                                    runat="server" CommandName="Share"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    ForeColor="DeepSkyBlue"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkdelete" runat="server" 
                                                    Text="<%$Resources:Resource, Delete %>"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    OnClick="lnkdelete_Click" ForeColor="DeepSkyBlue">

                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" 
                                                    Text="<%$Resources:Resource, Download %>" 
                                                    CommandName="download"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    runat="server" ForeColor="DeepSkyBlue">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPlay" runat="server" 
                                                    Text="<%$Resources:Resource, play %>" CommandName="play"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    ForeColor="DeepSkyBlue"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDetails" 
                                                    Text="<%$Resources:Resource, details %>" 
                                                    runat="server" CommandName="details"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    ForeColor="DeepSkyBlue"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                             </ContentTemplate>
                        </asp:UpdatePanel>

                         <asp:UpdatePanel runat="server" ID="panel2">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="GridView2" />
                            </Triggers>
                            <ContentTemplate>
                                <div runat="server" id="gridview2div">
                                <span style="font-size:1.5rem; font-weight:bold">Public Files</span>
                                <asp:GridView Width="80%" GridLines="Horizontal" BorderStyle="None"
                                    CellPadding="5" ID="GridView2" runat="server" AutoGenerateColumns="false"
                                    EmptyDataText="<%$Resources:Resource, NoFileUpload %>" 
                                    OnRowCommand="GridView1_RowCommand"  ShowHeader="false"
                                    AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" 
                                    PageSize="10" DataKeyNames="docinfo">

                                    <HeaderStyle BorderColor="Transparent" />
                                    <Columns>
                                        <asp:BoundField DataField="docinfo" />
                                        <asp:BoundField DataField="UserName" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkdelete" runat="server" 
                                                    Text="<%$Resources:Resource, Delete %>"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    OnClick="lnkdelete_Click" ForeColor="DeepSkyBlue">

                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" 
                                                    Text="<%$Resources:Resource, Download %>" 
                                                    CommandName="download"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    runat="server" ForeColor="DeepSkyBlue">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkPlay" runat="server" 
                                                    Text="<%$Resources:Resource, play %>" CommandName="play"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    ForeColor="DeepSkyBlue"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDetails" 
                                                    Text="<%$Resources:Resource, details %>" 
                                                    runat="server" CommandName="details"
                                                    CommandArgument='<%# Eval("docinfo") %>' 
                                                    ForeColor="DeepSkyBlue"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
                   
        </div>
    </div>
    <script>
        function PlayVideo(url) {
            //var ss = url.split(" ");
            //for (i = 0; i < ss.length;i++){
            //    console.log(ss[i]);
            //};


            var source = "Uploads\\" + url;
            // console.log("source of video file "+ source);
            //var fileURL = URL.createObjectURL(source);
            //console.log(fileURL);
            var div = document.getElementById("displayFiles");
            var x = document.createElement("VIDEO");
            div.appendChild(x);

            if (x.canPlayType("video/mp4")) {
                x.setAttribute("src", source);
            } else {
                x.setAttribute("src", source);
            }

            x.setAttribute("width", "100%");
            x.setAttribute("height", "100%");
            x.setAttribute("controls", "controls");

            x.play();
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
