using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Scan
{
    public partial class OneTimeRegistration : BasePage
    {
        static string ip = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ip = Request.QueryString["ip"];
                iptb.Text = ip;
                tbusertempid.Value = "";
                tbpasswordtemp.Value = "";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string n = username.Value.Trim();
            string u = tbusertempid.Value.Trim();
            string p = tbpasswordtemp.Value.Trim();
            string d = datepicker.Value;

            string start = starttimepicker.Value;
            
            string stop = stoptimepicker.Value;

            string state = "Pending";
            string ph = phone.Value;
            string desc = description.InnerText;
            string[] data = new string[] {n, u, p, ip, d, start, stop, state, ph, desc };
            Userdetails ud = new Userdetails();
            int result = ud.RegisterTempUser(data);
            if(result == -1)
            {
                string message = Resources.Resource.ResourceManager.GetString("UseridExists");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Duplicate", "alert('"+message+"')", true);
            }
            else if(result == 1)
            {
                string message = Resources.Resource.ResourceManager.GetString("WaitingforAdmin");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "SuccessRegistration('"+ip+"','"+message+"')", true);
                
            }
            else
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError1");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Failure", "alert('"+message+"')", true);
            }            
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Scan/MobileLogin.aspx?ip=" + ip, true);
        }
    }
}