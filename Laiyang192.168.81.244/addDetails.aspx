<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="addDetails.aspx.cs" Inherits="WebCresij.addDetails" %>

<html>
<head>
    <title></title>
    <script src="Scripts/jquery-3.4.1.min.js"></script>
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
            <asp:Button ID="btnaddgrade1" Text="<%$Resources:Resource, AddGrades %>" runat="server" OnClientClick="AddTextGrade(); return false;" />
            <div class="row" style="width:50%; margin-top:50px; float:right;margin-right:30px;">
                <div class="col">
                    <asp:Button ID="saveg" Text="<%$Resources:Resource, Save %>" runat="server" OnClick="save_Click" />
                </div>
                <div class="col">
                    <asp:Button ID="Cancle" Text="<%$Resources:Resource, Cancel %>" runat="server"
                        OnClientClick="closeframe(); return false;" />
                </div>
            </div>
        </div>
            
        
        <script type="text/javascript">
            function GetDynamicTextBoxIns(value) {
                return '<div class="form-group">' + '<asp:Label runat="server" Text="<%$Resources:Resource, Grade %>" CssClass="col-sm-2 control-label" Font-Bold="True"/>' +
                    '<div class="col-sm-10"><input name = "DynamicTextBox" class="form-control" type="text" value = "' + value + '" /></div></div>'
            }

            function AddTextGrade() {
                var div = document.createElement('DIV');
                div.innerHTML = GetDynamicTextBoxIns("");
                document.getElementById("TextBoxContainer1").appendChild(div);
            }

           
            function closeframe() {

                parent.document.getElementById("id01").style.display = "none";
                
                parent.window.location.reload();
            }
        </script>
    </form>
</body>
</html>
