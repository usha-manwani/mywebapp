using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Status : System.Web.UI.Page
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        private void loadGrid()
        {
            CentralControl cc = new CentralControl();
            DataSet ds = cc.ControlDetails();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}