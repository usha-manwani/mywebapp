using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class home : BasePage
    {
        CameraOnline stat = new CameraOnline();
        
        //static string script = "";
        //static Int32 i = 0;
        //string scriptKey = "loginthis";
        //static SqlConnection con;
        static DataTable dt = new DataTable();
        //protected static String classId="Class4" ;
        
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = stat.Camcheck();
                GridView1.DataBind();
            }
           
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
           
        }
      
       
        protected void btnPing_Click(object sender, EventArgs e)
        { 
             GridView1.DataSource = stat.Camcheck() ;
            GridView1.DataBind();
            GridView1.GridLines = GridLines.None;
            GridView1.BorderStyle = BorderStyle.None;

        }
    }
}