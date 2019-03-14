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
            HttpContext.Current.Session["UserName"] = null;
            HttpContext.Current.Session["role"] = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            Response.Redirect("Index.aspx");
        }
    }
}