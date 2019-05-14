using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class Logout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserId"] != null)
            {
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 2);
                UserActivities.UserLogs.LoggedOutUser(HttpContext.Current.Session["UserId"].ToString());
            }
            
            HttpContext.Current.Session["UserName"] = null;
            HttpContext.Current.Session["role"] = null;
            HttpContext.Current.Session["UserId"] = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}