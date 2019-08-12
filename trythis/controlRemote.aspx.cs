using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class controlRemote : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               string Ip= Session["DeviceIP"].ToString();

                CentralControl ct = new CentralControl();
                DataTable dt = ct.Getlocation(Ip);
                if (dt.Rows.Count > 0)
                {
                    insName.Text = dt.Rows[0][0].ToString();
                    GradeName.Text = dt.Rows[0][1].ToString();
                    ClassName.Text = dt.Rows[0][2].ToString();
                }
            }
            
        }
    }
}