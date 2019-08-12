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
                    string query = "select * from Institute_Details";
                    DataTable dt = PopulateTree.ExecuteCommand(query);
                    ddlins.DataSource = dt;
                    ddlins.DataTextField = "InstituteName";
                    ddlins.DataValueField = "InstituteID";
                    ddlins.DataBind();
                    string select = Resources.Resource.Select;
                    //ddlins.Items.Insert(0, new ListItem(select, "NA"));
                    loadGrid(dt.Rows[0]["InstituteID"].ToString());
                }
                else
                {
                    Response.Redirect("Logout.aspx");
                }                
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alertmsg2", "triggerclick();", true);
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
            loadGrid(ddlins.SelectedValue);
            
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loadGrid(ddlins.SelectedValue);
        }


        //protected void Timer1_Tick()
        //{
        //    DataTable ScoresTable = Application["ScoreTable"] as DataTable;
        //    if(ScoresTable == null){
        //        Hubsfile.UpdateDevice up = new Hubsfile.UpdateDevice();
        //        ScoresTable = up.update();
        //    }
        //    rptData.DataSource = ScoresTable;
        //    rptData.DataBind();
        //    //DataTable dt1 = null;
        //    //GridView1.DataSource = dt1;
        //    //GridView1.DataBind();
        //}

        //public DataTable updateData(DataTable dt)
        //{
        //    DataTable dt1 = new DataTable();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        DataRow row = dt1.NewRow();
        //        row[0] = dr[0];
        //        if (Convert.ToInt32( dr[20]) != -1)
        //        { 

        //            if (Convert.ToByte( dr[6])== Convert.ToByte(0xc4))
        //            {
        //                row[3] = "Online";
        //            }
        //        if (Convert.ToByte( dr[8] )== Convert.ToByte(0x00))
        //        {
        //            row[4] = "Closed";
        //        }
        //        else
        //            row[4] = "Open";

        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[6] = "OFF";
        //        }
        //        else
        //            row[6] = "ON";

        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[15] = "Locked";
        //        }
        //        else
        //            row[15] = "Opened";


        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[14] = "Locked";
        //        }
        //        else
        //            row[14] = "Opened";


        //        switch (Convert.ToInt32(dr[6]))
        //        {
        //            case 1:
        //               row[12] = "Desktop PC";
        //                break;
        //            case 2:
        //                row[12] = "Laptop";
        //                break;
        //            case 3:
        //                row[12] = "Digital Booth";
        //                break;
        //            case 4:
        //                row[12] = "Digital Equipment";
        //                break;
        //            case 5:
        //                row[12] = "DVD";
        //                break;
        //            case 6:
        //                row[12] = "Blu-Ray DVD";
        //                break;
        //            case 7:
        //                row[12] = "TV set";
        //                break;
        //            case 8:
        //                row[12] = "VCR";
        //                break;
        //            case 9:
        //                row[12] = "Recording System";
        //                break;
        //            default:
        //                row[12] = "No system Detected";
        //                break;
        //        }

        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[13] = "Locked";
        //        }
        //        else
        //            row[13] = "Open";

        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[7] = "Closed";
        //        }
        //        else
        //            row[7] = "Open";

        //        switch (Convert.ToInt32(dr[6]))
        //        {
        //            case 1:
        //                row[10] = "Open";
        //                break;
        //            case 2:
        //                row[10] = "Down";
        //                break;
        //            case 0:
        //                row[10] = "Stop";
        //                break;
        //        }
        //        switch (Convert.ToInt32(dr[6]))
        //        {
        //            case 1:
        //                row[9] = "Open";
        //                break;
        //            case 2:
        //                row[9] = "Down";
        //                break;
        //            case 0:
        //                row[9] = "Stop";
        //                break;
        //        }
        //        if (Convert.ToByte(dr[6]) == Convert.ToByte(0x00))
        //        {
        //            row[11] = "OFF";
        //        }
        //        else
        //            row[11] = "On";

        //    }


        //            else
        //            {

        //            if (Convert.ToByte(dr[6]) == Convert.ToByte(0xc9))
        //            {
        //                row[3] = "Offline";
        //            }
        //        }
        //    }





        //    return dt;

        //}
    }
  

}