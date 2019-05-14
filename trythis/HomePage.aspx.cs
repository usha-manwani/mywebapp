using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class HomePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            OpenCam();            
        }

        private void OpenCam()
        {
            try
            {
                string classId = HttpContext.Current.Session["LocForCam"].ToString();
                DataTable dt = new DataTable();
                CentralControl cc = new CentralControl();
                dt = cc.CamDetails(classId);
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 14);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string videostream = "rtsp://" + dt.Rows[i]["ID"] + ":" + dt.Rows[i]["password"] + "@" + dt.Rows[i]["CameraIP"] + ":554/";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "videostream" + i, "Cam" + (i + 1) + "('" + videostream + "');", true);
                    }
                }
            }
            catch 
            {
                Response.Redirect("Logout.aspx");
            }
            
        }
    }
}