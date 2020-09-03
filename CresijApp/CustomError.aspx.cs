using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CresijApp.site
{
    public partial class CustomError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies["AuthToken"].Value = null;
            HttpContext.Current.Response.Redirect("site/login.html");
        }
    }
}