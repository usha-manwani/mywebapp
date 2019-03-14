using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace WebCresij
{
    public partial class Contact : BasePage
    {
        protected string Values;
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void sendEmail_Click(object sender, EventArgs e)
        {           
            string  m = issueList.SelectedItem.ToString();            
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.To.Add(new MailAddress("uphulwani1@gmail.com"));  // replace with receiver's email id  
                    message.From = new MailAddress(email.Value);  // replace with sender's email id 
                    message.Body = issuemessage.Value;
                    message.Subject = m;
                    SmtpClient client = new SmtpClient();
                    client.Host = "localhost";
                    client.Send(message);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "successmail", "showMail();", true);
                    //emailsent.Style.Add("display", "block");
                }
                issuemessage.Value = "";
                txtPhone.Text = "";
                email.Value = "";
                name.Value = "";              
            }
            catch (Exception)
            {
              
            }
        }
    }
}