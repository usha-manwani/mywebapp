<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="addDetails.aspx.cs" Inherits="WebCresij.addDetails" %>

<html>
<head>
    <title></title>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        input, select, textarea {
            max-width: 280px;
        }
    </style>
</head>
<body>
    <form runat="server">
       
        <div class="form-group">
            <asp:Label runat="server" Font-Bold="true" AssociatedControlID="txtIns" CssClass="col-lg-3 control-label" Text="<%$Resources:Resource, InsName %>"></asp:Label>

            <div class="col-lg-9">
                <asp:TextBox runat="server" ID="txtIns" CssClass="form-control" />
            </div>
        </div>
        <div>
            <h4><span><%=Resources.Resource.AddNewgrade%></span></h4>
            <hr />
            <div id="TextBoxContainer">
            </div>
            <asp:Button ID="btnaddgrade" Text="<%$Resources:Resource, AddGrades %>" runat="server" OnClientClick="AddTextGrade(); return false;" />
            <div class="row" style="width:50%; margin-top:50px; float:right;margin-right:30px;">
                <div class="col">
                    <asp:Button ID="save" Text="<%$Resources:Resource, Save %>" runat="server" OnClick="save_Click" />
                </div>
                <div class="col">
                    <asp:Button ID="Cancle" Text="<%$Resources:Resource, Cancel %>" runat="server"
                        OnClientClick="closeframe(); return false;" />
                </div>
            </div>
        </div>
            </div>
        <div class="w3-container">
            <div id="AddIns" class="modal" style="position: center" runat="server">
                <div class="modal-content w3-card-4" style="width: 250px; min-height: 150px">
                    <header class="w3-container w3-teal">
                        <span onclick="hideDelConfirm();"
                            class="w3-button w3-display-topright">&times;</span>
                        <h3><span><%=Resources.Resource.Success%></span>!</h3>
                    </header>
                    <div class="w3-container">
                        <asp:TextBox runat="server" ID="delvalue" Visible="false"></asp:TextBox>
                        <p class="text-danger"><span><%=Resources.Resource.AddInsSuccess%></span></p>
                        <br />
                        <asp:Button ID="delcancel" runat="server" Text="<%$Resources:Resource, Ok %>" OnClientClick="hideAddConfirm(); return false;" />
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function GetDynamicTextBox(value) {
                return '<div class="form-group">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Grade %>" CssClass="col-sm-2 control-label" Font-Bold="True"/>' +
                    '<div class="col-sm-10"><input name = "DynamicTextBox" class="form-control" type="text" value = "' + value + '" /></div></div>'
            }

            function AddTextGrade() {
                var div = document.createElement('DIV');
                div.innerHTML = GetDynamicTextBox("");
                document.getElementById("TextBoxContainer").appendChild(div);
            }

            function hideAddConfirm() {
                document.getElementById('<%=AddIns.ClientID%>').style.display = "none";
                closeframe();
            }
            function closeframe() {

                parent.document.getElementById("id01").style.display = "none";
                document.getElementById('<%=AddIns.ClientID%>').style.display = "none";
                parent.window.location.reload();
            }
        </script>
    </form>
</body>
</html>
