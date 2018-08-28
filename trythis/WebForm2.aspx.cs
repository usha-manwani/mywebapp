using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Pipes;


namespace trythis
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void Master_Selected(object sender, EventArgs e)
        {
            string c = SiteMaster.c;
            string constr = SiteMaster.constr;
            if (c != "")
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from fn_cam(@cid)", con))
                    {
                        cmd.Parameters.AddWithValue("@cid", c);
                        try
                        {
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            con.Open();
                            da.Fill(dt);
                            
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
          


        }

     

        protected void Page_PreInit(object sender, EventArgs e)
        {
            
            // TODO: Put event wiring logic here
            Master.selected += new EventHandler(Master_Selected);
        }
    }
}