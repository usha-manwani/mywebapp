using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class ResetPassword : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnchangepass_Click(object sender, EventArgs e)
        {
            int r = 0;
            if (!string.IsNullOrEmpty(HttpContext.Current.Session["UserId"].ToString()))
            {
                string currentpass = oldpass.Value.Trim();
                string newpass = tbpassword.Text.Trim();
                string userid = HttpContext.Current.Session["UserId"].ToString();
                Userdetails userdetails = new Userdetails();                
                r= userdetails.ChangePass(userid, currentpass, newpass);
                if (r > 0)
                {
                    string message = "Password Changed Successfully!! Please Login Again using the new password!";
                    string url = "../Index.aspx";
                    string script = " alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; ";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RedirectToIndex", script, true);   
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "wrongpass", "Wrong Password, Please try again!", true);
            }
        }
    }
}