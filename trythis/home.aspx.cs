using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.AspNet.SignalR;

namespace WebCresij
{
    public partial class home : BasePage
    {
        PopulateTree pt = new PopulateTree();
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
                string select = Resources.Resource.Select;
                ddlInstitute.Items.Insert(0, new ListItem(select, "NA"));
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
            string select = Resources.Resource.Select;
            ddlClass.Items.Insert(0, new ListItem(select, "NA"));
            string insID = ddlInstitute.SelectedValue;
            string query = "select GradeID, GradeName from Grade_Details where InsID='" + insID + "'";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "GradeName";
            ddlGrade.DataValueField = "GradeID";
            ddlGrade.DataBind();
            
            ddlGrade.Items.Insert(0, new ListItem(select, "NA"));
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
            string select = Resources.Resource.Select;
            ddlClass.Items.Insert(0, new ListItem(select, "NA"));
            HttpContext.Current.Session["ipforgraph"] = "";
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classID = ddlClass.SelectedValue;
            string ip = PopulateTree.getIP(classID);
            HttpContext.Current.Session["ipforgraph"] = ip;
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
            hubContext.Clients.All.SendControl(ip, "8B B9 00 03 04 01 08");

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DataTable dt = pt.GetStatus();
            machineStatus.InnerText = dt.Select("MachineStatus='Online'").Count().ToString();
            machineStatus1.InnerText = dt.Select("MachineStatus='Offline'").Count().ToString();
            work.InnerText = dt.Select("WorkStatus='OPEN'").Count().ToString();
            work1.InnerText = dt.Select("WorkStatus='CLOSED'").Count().ToString();
            total.InnerText = dt.Rows.Count.ToString();
        }
    }
}