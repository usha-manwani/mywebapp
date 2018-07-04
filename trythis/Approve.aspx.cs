using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace final
{
    public partial class Approve : System.Web.UI.Page
    {
        Userdetails ud = new Userdetails();
        string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GridView1.DataSource = ud.getUserDetailsPending();
                GridView1.DataBind();
                HideDeleteButton();
            }

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
             userid = GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            Permissions.Style.Add("display", "block");
 
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (userid != null)
            {
                string i = "";
                System.Collections.IList list = CheckBoxList1.Items;
                for (int i1 = 0; i1 < list.Count; i1++)
                {
                    ListItem item = (ListItem)list[i1];
                    if (item.Selected)
                    {
                        i = i + item.Value;
                    }
                }

                ud.SaveUser(userid, i);
            }
        }

        private void HideDeleteButton()
        {
            
                if (GridView1.Rows == null)
                {
                    Button deleteCommand = (Button)GridView1.Rows[0].FindControl("btnEdit");
                    deleteCommand.Visible = false;
                }
            
        }
    }
}