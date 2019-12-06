using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Scan
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ip;
            ip = Request.QueryString["ip"];
            if (HttpContext.Current.Session["UserId"] != null)
            {
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["MobileUserId"].ToString(),
                HttpContext.Current.Session["MobileUserName"].ToString(), 2);
                UserActivities.UserLogs.LoggedOutUser(HttpContext.Current.Session["MobileUserId"].ToString());
            }
            HttpContext.Current.Session["MobileUserName"] = null;
            HttpContext.Current.Session["role"] = null;
            HttpContext.Current.Session["MobileUserId"] = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            Response.Redirect("../Scan/MobileLogin.aspx?ip=" + ip, true);
        }
    }
}