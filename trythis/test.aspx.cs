using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trythis
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            for(int i=0; i < chk1.Items.Count; i++)
            {
                if (chk1.Items[i].Selected == true)
                {
                    items.Add(chk1.Items[i].Text); 
                }
            }
        }
    }
}