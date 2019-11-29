using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Mobile
{
    public partial class Home : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string s = HttpContext.Current.Session["UserName"].ToString();
                string roleids = HttpContext.Current.Session["role"].ToString();
                if (s != null)
                {
                    authuser.Visible = false;
                    int[] roleIds = roleids.ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToArray();
                    DisplayRole(roleIds);
                }
                else
                {

                    Response.Redirect("../Mobile/Login.aspx");
                }
            }
            catch
            {
                Response.Redirect("../Mobile/Login.aspx");
            }
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
        }

        private void DisplayRole(int[] roleIds)
        {
            for(int i = 0; i < roleIds.Length; i++)
            {
                if(roleIds[i]==1 || roleIds[i] == 6)
                {
                    authuser.Visible = true;
                }
            }
        }
    }
}