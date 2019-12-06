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
                    GetFaultCount();
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
                    int total= Userdetails.totalPendingUser();
                    string num = total.ToString();
                    if(total> 9)
                    {
                        num = "9+";
                    }
                    if (num.Contains("0") && num.Length == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "nousercount", "RemoveBadge();", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "usercount", "updateBadge('"+num+"');", true);
                }
            }
        }

        private void GetFaultCount()
        {
            int total= MaintainanceData.GetFaultCount();
            string num = total.ToString();
            if (total > 9)
            {
                num = "9+";
            }
            if (num.Contains("0") && num.Length == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "nofaultcount", "RemoveFaultBadge();", true);
            }
            else
                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "faultcount", "updateFaultBadge('" + num + "')", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "faultcount", "updateFaultBadge('" + num + "');", true);
        }
    }
}