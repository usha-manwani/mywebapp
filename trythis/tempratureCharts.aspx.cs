using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.AspNet.SignalR;

namespace WebCresij
{
    public partial class tempratureCharts : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select * from Institute_Details";
                DataTable dt = PopulateTree.ExecuteCommand(query);
                ddlInstitute.DataSource = dt;
                ddlInstitute.DataTextField = "InstituteName";
                ddlInstitute.DataValueField = "InstituteID";
                ddlInstitute.DataBind();
                ddlInstitute.Items.Insert(0, new ListItem("Select", "NA"));
                HttpContext.Current.Session["ipforgraph"] = "";
            }
        }
        private void bindgrd()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Slno", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Desc", typeof(string)));
            dr = dt.NewRow();
            dr["Slno"] = 1;
            dr["Name"] = string.Empty;
            dr["Desc"] = string.Empty;
            dt.Rows.Add(dr);
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
           
        }
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGrade.Items.Clear();
            ddlClass.Items.Clear();
            ddlClass.Items.Insert(0, new ListItem("Select", "NA"));
            string insID = ddlInstitute.SelectedValue;
            string query = "select GradeID, GradeName from Grade_Details where InsID='" + insID + "'";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "GradeName";
            ddlGrade.DataValueField = "GradeID";
            ddlGrade.DataBind();
            ddlGrade.Items.Insert(0, new ListItem("Select", "NA"));
            HttpContext.Current.Session["ipforgraph"] = "";
        }
       
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlClass.Items.Clear();
            ddlClass.DataSource = null;
            ddlClass.DataBind();
            string gradeID = ddlGrade.SelectedValue;
            string query = "select ClassID, ClassName from Class_Details where GradeID='" + gradeID + "'";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("Select", "NA"));
            HttpContext.Current.Session["ipforgraph"] = "";
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classID = ddlClass.SelectedValue;           
            string ip= PopulateTree.getIP(classID);
            HttpContext.Current.Session["ipforgraph"] = ip;
            IHubContext  hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
            hubContext.Clients.All.SendControl(ip, "8B B9 00 03 04 01 08");

        }
    }
}