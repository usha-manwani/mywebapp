using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Error
{
    public partial class CustomError : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["UserName"] = null;
            HttpContext.Current.Session["role"] = null;
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Index.aspx");
        }
    }
}