   using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.IO;

using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace trythis
{
    public partial class Status : System.Web.UI.Page
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
           // DataTable dt1 = s.CC();
        
            if (!IsPostBack)
            {
               
                
            }
        

        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            DataTable ScoresTable = Application["ScoresTable"] as DataTable;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from dbo.[dataFrom control]", con))
                {

                    try
                    {
                        con.Open();
                        SqlDataAdapter ds = new SqlDataAdapter();
                        ds.Fill(ScoresTable);

                    }
                    catch(Exception ex)
                    {
                        string msg = ex.Message;
                    }
                }
            }
        }
        protected void Timer1_Tick()
        {
            DataTable dt1 = null;
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
      

    }
  

}