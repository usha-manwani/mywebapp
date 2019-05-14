using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.UserControl
{
    public partial class ResourcesControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LiteralControl jsResource = new LiteralControl();
            jsResource.Text = "<script type=\"text/javascript\">";

            jsResource.Text += "var Resources = {";

            jsResource.Text += "AlertTime: '" + Resources.Resource.AlertTime + "',";
            jsResource.Text += "AlertTime2: '" + Resources.Resource.AlertTime2 + "',";
            jsResource.Text += "AlertTime3: '" + Resources.Resource.AlertTime3 + "',";
            jsResource.Text += "AlertTime4: '" + Resources.Resource.AlertTime4 + "',";
            jsResource.Text += "AlertTime5: '" + Resources.Resource.AlertTime5 + "',";
            jsResource.Text += "AlertTime6: '" + Resources.Resource.AlertTime6 + "',";
            jsResource.Text += "};";

            jsResource.Text += "</script>";
            Page.Header.Controls.Add(jsResource);
        }
    }
}