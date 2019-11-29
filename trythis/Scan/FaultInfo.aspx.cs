using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Scan
{
    public partial class FaultInfo : BasePage
    {
        static string ip;
        protected void Page_Load(object sender, EventArgs e)
        {
            ip = Request.QueryString["ip"];
            if (string.IsNullOrEmpty(ip))
            {
                string url = "../Scan/Error.aspx";
                Response.Redirect(url, true);
            }
            else
            {
                try
                {

                    string userid = HttpContext.Current.Session["MobileUserId"].ToString();
                    if (userid != null)
                    {

                    }
                    else
                    {
                        HttpContext.Current.Session["MobileUserId"] = "";
                        Response.Redirect("../Scan/MobileLogin.aspx?ip=" + ip);
                    }
                }
                catch
                {
                    HttpContext.Current.Session["MobileUserId"] = "";
                    Response.Redirect("../Scan/MobileLogin.aspx?ip=" + ip);
                }
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string via = "Scan Code";
            string priority = ddlPriority.SelectedValue;
            string district = txtdistrict.Text;
            string user = txtuser.Text;
            string desc = txtdesc.Text;
            string phone = txtphone.Text;
            string stat = ddlStat.SelectedValue;
            if (!string.IsNullOrEmpty(ip))
            {
                MaintainanceData md = new MaintainanceData();
                md.InsertFaultInfo(ip,via,priority,district,user,desc,phone, stat);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Submit", "alert('Submitted Successfully');", true);
            }
            txtdistrict.Text = "";
            txtuser.Text = "";
            txtdesc.Text = "";
            txtphone.Text = "";
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["MobileUserId"] = "";
            Response.Redirect("../Scan/MobileLogin.aspx?ip=" + ip);
        }

        protected void gotoControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Scan/QrControlPage.aspx?ip=" + ip, true);
        }
    }
}