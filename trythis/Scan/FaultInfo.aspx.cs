using System;
using System.Collections.Generic;
using System.Data;
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
                        GetLocation(ip);
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
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["MobileUserId"].ToString(),
                    HttpContext.Current.Session["MobileUserName"].ToString(), 17);
                string message = Resources.Resource.ResourceManager.GetString("SubmitSuccess");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Submit", "alert('" + message + "');", true);
            }
            txtdistrict.Text = "";
            txtuser.Text = "";
            txtdesc.Text = "";
            txtphone.Text = "";
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Scan/Logout.aspx?ip=" + ip);
        }

        protected void gotoControl_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Scan/QrControlPage.aspx?ip=" + ip, true);
        }

        protected void GetLocation(string ip)
        {
            DataTable dt = PopulateTree.GetlocationIP(ip);
            insName.Text = dt.Rows[0][2].ToString() + " >> ";
            GradeName.Text = dt.Rows[0][1].ToString() + " >> ";
            ClassName.Text = dt.Rows[0][0].ToString();
        }
    }
}