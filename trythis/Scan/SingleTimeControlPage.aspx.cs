using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Scan
{
    public partial class SingleTimeControlPage : BasePage
    {
        string ip;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ip = Request.QueryString["ip"];
                iptocam.Value = Request.QueryString["ip"];
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("../Scan/Logout.aspx?ip=" + ip);
        }
    }
}