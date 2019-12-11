using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Mobile
{
    public partial class Status : BasePage
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                                    HttpContext.Current.Session["UserName"].ToString(), 12);
                    string query = "select ins_name, id from Institute_Details";
                    DataTable dt = PopulateTree.ExecuteCommand(query);
                    ddlins.DataSource = dt;
                    ddlins.DataTextField = "ins_name";
                    ddlins.DataValueField = "id";
                    ddlins.DataBind();
                    string select = Resources.Resource.Select;
                    //ddlins.Items.Insert(0, new ListItem(select, "NA"));
                    loadGrid(dt.Rows[0]["id"].ToString());
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg2", "triggerclick();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "showcount", "updateCount();", true);
        }

        private void loadGrid(string insID)
        {
            CentralControl cc = new CentralControl();
            DataSet ds = cc.ControlDetails(insID);
            DataTable dt = ds.Tables[0];

            try
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg1", "triggerclick();", true);
                //hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    string ip = row.Cells[1].Text;
                //    string data = "8B B9 00 03 05 01 09";
                //    hubContext.Clients.All.SendControl(ip, data);
                //}
            }
            catch
            {

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //   DataTable ScoresTable = Application["ScoreTable"] as DataTable;          
        }

        protected void ddlins_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            loadGrid(ddlins.SelectedValue);

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loadGrid(ddlins.SelectedValue);
        }
    }
}