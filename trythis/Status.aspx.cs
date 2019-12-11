using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.AspNet.SignalR;

namespace WebCresij
{
    public partial class Status : BasePage
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {                  
            if (!IsPostBack)
            {
              
                if(HttpContext.Current.Session["UserId"] != null)
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
                    FillGradeDDL();
                   // GetMachineCount();
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }
                
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg2", "triggerclick();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "showcount", "updateCount();", true);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
           // GetMachineCount();
        }

        private void loadGrid( string insID)
        {
            CentralControl cc = new CentralControl();
            DataSet ds = cc.ControlDetails( insID);
            DataTable dt = ds.Tables[0];
            
            try
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg1", "triggerclick();", true);
                
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
            ddlGrade.Items.Clear();
            
            FillGradeDDL();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            if (ddlGrade.SelectedIndex>0)
            {
                LoadGridwithGrade(ddlGrade.SelectedValue);
            }
            else
            loadGrid(ddlins.SelectedValue);
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGrade.SelectedIndex == 0)
            {
                loadGrid(ddlins.SelectedValue);
            }
            else
            {
                CentralControl cc = new CentralControl();
                DataTable dt = cc.GetStatusOnGrade(Convert.ToInt32(ddlGrade.SelectedValue));
                try
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "triggerclick", "triggerclick();", true);
                }
                catch (Exception ex)
                {

                }
            }   
        }

        protected void FillGradeDDL()
        {
            string insID = ddlins.SelectedValue;
            string query = "select ID, Grade_Name from Grade_Details where InsID = '" + insID + "'";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "Grade_Name";
            ddlGrade.DataValueField = "ID";
            ddlGrade.DataBind();
            string select = Resources.Resource.Select;
            ddlGrade.Items.Insert(0, new ListItem(select, "NA"));
        }
        protected void LoadGridwithGrade(string g)
        {
            CentralControl cc = new CentralControl();
            DataTable dt = cc.GetStatusOnGrade(Convert.ToInt32(g));
            try
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "triggerclick1", "triggerclick();", true);
            }
            catch (Exception ex)
            {

            }
        }

        
    }
}