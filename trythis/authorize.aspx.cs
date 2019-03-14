using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebCresij
{
    public partial class authorize : BasePage
    {
        Userdetails ud = new Userdetails();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                
                gv2.DataSource = ud.getUserDetailsPending();
                gv2.DataBind();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var user = Session["usertoapprove"].ToString();
                if (!string.IsNullOrEmpty(user))
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
                    if(!string.IsNullOrEmpty(i))
                    ud.SaveUser(user, i);
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "MyKey2", "norole();", true);
                    }
                }
            }
            catch 
            {

            }
            finally
            {
                gv2.DataSource = ud.getUserDetailsPending();
                gv2.DataBind();
                Session["usertoapprove"] = "";
            }
            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            //Get the row that contains this button
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            //Get rowindex
            int rowindex = gvr.RowIndex;
            Session["usertoapprove"] = gv2.Rows[rowindex].Cells[0].Text;
           // userIdhid.Value = gv2.Rows[rowindex].Cells[0].Text;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyKey", "displayoption()", true);
        }
    }
}