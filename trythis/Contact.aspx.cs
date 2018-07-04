using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace final
{
    public partial class Contact : Page
    {
        protected string Values;
        protected void Page_Load(object sender, EventArgs e)
        {
            emailsent.Style.Add("display", "none");
        }

        protected void sendEmail_Click(object sender, EventArgs e)
        {
            
              string  m = issueList.SelectedItem.ToString();
            

            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.To.Add(new MailAddress("uphulwani1@gmail.com"));  // replace with receiver's email id  
                    message.From = new MailAddress(txtemail.Text);  // replace with sender's email id 
                    message.Body = issuemessage.Value;

                    message.Subject = m;
                    SmtpClient client = new SmtpClient();
                    client.Host = "localhost";
                    client.Send(message);
                    emailsent.Style.Add("display", "block");
                }
                issuemessage.Value = "";
                txtPhone.Text = "";
                txtemail.Text = "";
                name.Value = "";

            }
            catch (Exception)

            {

            }

        }

        protected void issueList_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if(issueList.SelectedItem.ToString()=="Others")
            {
                IssueSubject.Attributes.Add("class", "form-control");
                Label otherlbl = new Label();
                otherlbl.Text = "Issue related to:";
                
                IssueSubject.Controls.Add(otherlbl);
                TextBox otherissuetxt = new TextBox();
               
                otherissuetxt.CssClass = "form-control";
                otherissuetxt.Text = "Write issue subject here";
                
                IssueSubject.Controls.Add(otherissuetxt);
               // otherlbl.AssociatedControlID = otherissuetxt.ClientID;
            }

        }
    }
}