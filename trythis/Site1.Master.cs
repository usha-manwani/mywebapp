using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace trythis
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddListView();
        }

        protected void AddListView()
        {
            String connString = null;
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                con.Close();

            }
            catch
            {

            }
            
        }
    }
}