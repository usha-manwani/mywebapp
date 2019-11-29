using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Scan
{
    public partial class QrControlPage : BasePage
    {
        string ip ;
        string username = "";
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

                        if (!string.IsNullOrEmpty(ip))
                        {
                            iptoControl.Value = ip;
                            username = Request.QueryString["username"];
                        }
                        else
                        {
                            HttpContext.Current.Session["MobileUserId"] = "";
                            Response.Redirect("../Scan/MobileLogin.aspx?ip=");
                        }
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

        protected void logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["MobileUserId"] = "";
            Response.Redirect("../Scan/MobileLogin.aspx?ip=" + ip);
        }

        protected void gotoFault_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Scan/FaultInfo.aspx?ip=" + ip, true);
        }
    }
}