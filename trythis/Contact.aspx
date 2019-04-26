<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebCresij.Contact" %>

<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ID="Head" ContentPlaceHolderID="masterHead" runat="server">
    <style type="text/css">
        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }
        .modal-content {
            background-color: #fefefe;
            margin: auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Main" ContentPlaceHolderID="masterBody" runat="server">
    <div class="row " id="d1" runat="server" style="width: 100%">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <table class="row">
                    <tr>
                        <td>
                            <div class="col">
                                <div class="form-group " style="padding-top: 1em;">
                                    <asp:Label Text="Name:" runat="server" AssociatedControlID="name"></asp:Label>
                                    <input type="text" runat="server" name="sname" class="form-control" placeholder="Your Name *" id="name"
                                        required data-validation-required-message="Please enter your name." style="width: 250px;">
                                    <p class="help-block text-danger"></p>
                                </div>
                                <br />
                                <div class="form-group">
                                    <asp:Label Text="Email:" runat="server" AssociatedControlID="email"></asp:Label>
                                    <input type="text" runat="server" name="email" class="form-control"
                                        placeholder="abc@xyz.com" id="email" required
                                        data-validation-required-message="Please enter your email address" style="width: 250px;" />
                                    <%--<asp:TextBox ID="txtemail" runat="server" TextMode="Email" placeHolder="Your Email*" 
                                   CssClass="form-control"></asp:TextBox>--%>
                                    <p class="help-block text-danger"></p>
                                </div>
                                <div class="form-group">
                                    <asp:Label runat="server" AssociatedControlID="txtPhone" Text="Phone"></asp:Label>
                                    <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"
                                        placeHolder="+86-123-12345678" CssClass="form-control" Width="250px"></asp:TextBox>
                                    <p class="help-block text-danger"></p>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhone"
                                        CssClass="text-danger" ErrorMessage=" Phone Number is required." />
                                    <asp:RegularExpressionValidator runat="server" ControlToValidate="TxtPhone"
                                        ValidationExpression="\+(\(|)[\d]{2}(\)|)\-(\(|)[\d]{3}(\)|)\-(\(|)[\d]{8}(\)|)"
                                        CssClass="text-danger" ErrorMessage="Please enter a valid Phone Number "></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </td>
                        <td>
                            <div class="col" style="width: 250px;">
                                <div class="form-group" style="padding-top: 2em;">
                                    <asp:Label runat="server" Text="Issue" AssociatedControlID="issueList"></asp:Label>
                                    <asp:DropDownList runat="server" ID="issueList"
                                        onChange="javascript:selectedval();"
                                        CssClass=" border dropdown form-control btn-light" Width="250px">
                                        <asp:ListItem Text="Camera Offline" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Unable to manage Camera Details" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Unable to manage User Details" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Upload & Download Documents" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <div id="IssueSubject" style="border: none; display: none">
                                    <div class="form-group">
                                        <asp:Label Text="Issue Related to" runat="server" AssociatedControlID="otherissue"></asp:Label>
                                        <asp:TextBox ID="otherissue" runat="server" placeHolder="Brief Discription of issue"
                                            CssClass="form-control" Width="250px"></asp:TextBox>
                                    </div>
                                </div>
                                <br />
                                <div class="form-group">
                                    <asp:Label Text="Message" runat="server" AssociatedControlID="issuemessage"></asp:Label>
                                    <textarea class="form-control" name="smessage" style="min-height: 150px; min-width: 250px"
                                        runat="server" placeholder="Your Message *" id="issuemessage"
                                        required data-validation-required-message="Please enter a message."></textarea>
                                    <p class="help-block text-danger"></p>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="row">
                    <div class="clearfix"></div>
                </div>
                <div class="row">
                    <div class="col-lg-12 text-center">
                        <asp:Button runat="server" Text="Send" ID="sendEmail" CssClass="btn btn-xl btn-info"
                            OnClick="sendEmail_Click"></asp:Button>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
  
    <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="txtemail"
   CssClass="text-danger" ErrorMessage="Email address is required." /> --%>
    <script type="text/javascript">
        
        function showMail() {
            alert("Email Sent successfully.. Our Executive will contact you back Soon.");
        }
        function selectedval() {
            var rr = document.getElementById('<%=issueList.ClientID%>');
            var x = $(rr).val();
            if (x == '0') {
                document.getElementById("IssueSubject").style.display = "block";
            }
        }
    </script>
</asp:Content>
