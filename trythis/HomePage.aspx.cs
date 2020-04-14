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
                        int width = 0;
                        int height = 0;
                        string divp = "divPlugin";
                        string hid = "plugin";
                        int port = 80;
                        string func = "GetPlugin";
                        if (i == 0)
                        {
                            width = 490;
                            height = 300;
                            divp = "divPlugin";
                            hid = "plugin";
                            func = "GetPlugin";
                        }
                        else
                        {
                            width = 90;
                            height = 60;
                            divp = "divPlugin"+i;
                            hid = "plugin"+i;
                            func = "GetPlugin" + i;
                        }
                        //string videostream = "rtsp://" + dt.Rows[i]["user_ID"] + ":" + dt.Rows[i]["password"] + "@" + dt.Rows[i]["CameraIP"] + ":554/"
                        //   ;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "videostream" + i, func+"('"+ dt.Rows[i]["CameraIP"] 
                            +"','"+ dt.Rows[i]["user_ID"] +"','"+ dt.Rows[i]["password"] + "'," + port+","+width+","+height+",'"+ divp+"','"+hid+"');", true);
                    }
                }
            }
            catch
            {
                Response.Redirect("Logout.aspx");
            }
            
        }
        public void GetallCam()
        {
            OpenCam();
        }
    }
}