    <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="final.Contact" %>
<%@ MasterType VirtualPath="~/Site.master" %>    
<asp:Content ID="Head" ContentPlaceHolderID="HeadContent" runat="server">
    </asp:Content>
 <asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row " id="d1" runat="server" > 
            <div class="col-lg-12"> 
                
                    <div class="row"> 
                        <div class="col-md-6"> 
                            <div class="form-group" style="padding-top:2em;"> 
                                <asp:Label Text="Name:" runat="server" AssociatedControlID="name"></asp:Label>
                                 <input type="text" runat="server" name="sname" class="form-control" placeholder="Your Name *" id="name" required data-validation-required-message="Please enter your name."> 
                                <p class="help-block text-danger"></p> 
                            </div> 
                            <br />
                            <div class="form-group">
                                <asp:Label Text="Email:" runat="server" AssociatedControlID="txtemail"></asp:Label>
                               <asp:TextBox ID="txtemail" runat="server" TextMode="Email" placeHolder="Your Email*" CssClass="form-control"></asp:TextBox>
                                                 <asp:RequiredFieldValidator runat="server" ControlToValidate="txtemail"
                                                 CssClass="text-danger" ErrorMessage="Email address is required." /> 
                                <p class="help-block text-danger"></p> 
                            </div> 
                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="txtPhone" Text="Phone"></asp:Label>
                                <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone" placeHolder="+86-123-12345678" CssClass="form-control"></asp:TextBox>
                               
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhone"
                    CssClass="text-danger" ErrorMessage="The Phone Number is required." />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="TxtPhone" ValidationExpression = "\+(\(|)[\d]{2}(\)|)\-(\(|)[\d]{3}(\)|)\-(\(|)[\d]{8}(\)|)"
                    CssClass="text-danger" ErrorMessage="Please enter a valid Phone Number "></asp:RegularExpressionValidator>
                                <p class="help-block text-danger"></p> 
                            </div>
                            
                        </div> 
                        <div class="col-md-6"> 
                            <div class="form-group" style="padding-top:2em;">
                                <asp:Label runat="server" Text="Issue" AssociatedControlID="issueList"></asp:Label>
                                <asp:DropDownList runat="server" ID="issueList" OnSelectedIndexChanged="issueList_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                                    <asp:ListItem Text="Camera Offline" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Unable to manage Camera Details" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Unable to manage User Details" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Upload & Download Documents" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Others" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                </div>
                            <br/>
                                <div id="IssueSubject" style="border:none; color:black;" runat="server">
                                    <%--<div class="form-control">
                                    <asp:Label Text="Issue Related to" runat="server" AssociatedControlID="otherissue"></asp:Label>
                                    <asp:TextBox ID="otherissue" runat="server" placeHolder="Brief Discription of issue" CssClass="form-control"></asp:TextBox>
                                </div>--%></div>
                            <br/>
                            <div class="form-group" > 
                                <asp:Label Text="Message" runat="server" AssociatedControlID="issuemessage"></asp:Label>
                                <textarea class="form-control" name="smessage" style="min-height:150px" runat="server" placeholder="Your Message *" id="issuemessage" required data-validation-required-message="Please enter a message."></textarea> 
                                <p class="help-block text-danger"></p> 
                            </div> 
                        </div> 
                        <div class="clearfix"></div> 
                        <div class="col-lg-12 text-center"> 
                            <div id="success"></div> 
                            
                            <asp:Button runat="server" Text="Send"  ID="sendEmail" CssClass="btn btn-xl" onclick="sendEmail_Click"></asp:Button> 
                             
                        </div> 
                    </div> 
               
            </div> 
        </div> 
      <div class="w3-container"  >
        
        <div id="emailsent" class="w3-modal" runat="server" style="align-items:center">
            <div class="w3-modal-content w3-card-4" style="width:300px" >
                <header class="w3-container w3-teal">
                    <span onclick="hideDelNot();"
                          class="w3-button w3-display-topright">&times;</span>
                    <h3>Successful!!</h3>
                </header>
                <div class="w3-container" >
                  
                    <asp:TextBox runat="server" ID="TextBox1" Visible="false"></asp:TextBox>
                    
                      <p >Email Sent successfully.. Our Executive will contact you back Soon.</p>
                    <br />
               <asp:Button ID="Button1" runat="server" Text="Ok, got it!"  OnClientClick="hideSent(); return false;" />
                  
                        
               
                    </div>
                
                
            </div>
        </div>
     
</div>   
     <script type="text/javascript">
         function hideSent() {
             document.getElementById('<%=emailsent.ClientID%>').style.display = "none";
         }
     </script>
         </asp:Content>
