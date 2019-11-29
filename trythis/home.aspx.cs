using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
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
                string query = "select * from institute_details";
                DataTable dt = PopulateTree.ExecuteCommand(query);
                ddlInstitute.DataSource = dt;
                ddlInstitute.DataTextField = "Ins_Name";
                ddlInstitute.DataValueField = "Ins_ID";
                ddlInstitute.DataBind();
                string select = Resources.Resource.Select;
                int num = ddlInstitute.Items.Count;
                
                ddlInstitute.Items.Insert(num, new ListItem("All", "All"));
                //ddlTime.Enabled = false;
                HttpContext.Current.Session["ipforgraph"] = "";
                FillGradeDDL();
                //if (ddlClass.SelectedValue == "NA")
                //{
                //    ipgraph.Value = "NA";
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartclear1", "clearCharts();", true);
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey1", "CreateAllChart();", true);
                //}
            }
        }
        //private void bindgrd()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr = null;
        //    dt.Columns.Add(new DataColumn("Slno", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Name", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Desc", typeof(string)));
        //    dr = dt.NewRow();
        //    dr["Slno"] = 1;
        //    dr["Name"] = string.Empty;
        //    dr["Desc"] = string.Empty;
        //    dt.Rows.Add(dr);
        //    //Store the DataTable in ViewState
        //    ViewState["CurrentTable"] = dt;

        //}
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartclear2", "clearCharts();", true);
            ddlGrade.Items.Clear();
            ddlClass.Items.Clear();
            string select = Resources.Resource.Select;
            ddlClass.Items.Insert(0, new ListItem(select, "NA"));
            FillGradeDDL();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey1", "CreateAllChart('"+ddlInstitute.SelectedValue+"');", true);

            // string insID = ddlInstitute.SelectedValue;
            //if (insID == "All")
            //{
            //    ddlTime.Enabled = false;
            //}
            //else
            //{
            //    ddlTime.Enabled = true;
            //}

        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbllive.Text = "";
            ddlTime.SelectedItem.Selected = false;
            ddlTime.Items.FindByValue("0").Selected = true;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartclear3", "clearCharts();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey3",
                   "CreateAllChart('" + ddlGrade.SelectedValue+ "');", true);
            ddlClass.Items.Clear();
            // ddlClass.DataSource = null;
            //ddlClass.DataBind();
            FillClassDDL();
            

        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartclear4", "clearCharts();", true);
            string classID = ddlClass.SelectedValue;
            string ip = PopulateTree.getIP(classID);
            HttpContext.Current.Session["ipforgraph"] = ip;
            ipgraph.Value = ip;
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
            hubContext.Clients.All.SendControl(ip, "8B B9 00 03 04 01 08");
            lbllive.Text = "";           
            ddlTime.SelectedItem.Selected = false;
            ddlTime.Items.FindByValue("0").Selected = true;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey", "CreateChart();", true);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey4", "ddlIndexChange('" + classID + "');", true);
        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    CountMachines();
        //}

        protected void ddlTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbllive.Text = "";
            lbllive.ForeColor = System.Drawing.Color.Blue;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartclear5", "clearCharts();", true);
            if (ddlClass.SelectedValue != "NA")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey5", "ddltimeclass('" + ddlTime.SelectedValue + "','"+ ddlClass.SelectedValue + "');", true);
            }
            else if (ddlGrade.SelectedValue != "NA")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey6", "ddltimeclass('" + ddlTime.SelectedValue + "','" + ddlGrade.SelectedValue + "');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey7", "ddltimeclass('" + ddlTime.SelectedValue + "','" + ddlInstitute.SelectedValue + "');", true);
            }

        }

        protected void LiveLink_Click(object sender, EventArgs e)
        {
            lbllive.Text = "Live";
            lbllive.ForeColor = System.Drawing.Color.White;
            ddlTime.SelectedItem.Selected=false;            
            ddlTime.Items.FindByValue("0").Selected = true;            
        }      
        //public void CountMachines()
        //{
        //    DataTable dt = pt.GetStatus();
        //    machineStatus.InnerText = dt.Select("MachineStatus='Online'").Count().ToString();
        //    machineStatus1.InnerText = dt.Select("MachineStatus='Offline'").Count().ToString();
        //    work.InnerText = dt.Select("WorkStatus='OPEN'").Count().ToString();
        //    work1.InnerText = dt.Select("WorkStatus='CLOSED'").Count().ToString();
        //    dt = pt.totalMachines();
        //    total.InnerText = (Convert.ToInt32(dt.Rows[0][0]) - Convert.ToInt32(machineStatus.InnerText)).ToString();
        //    //ScriptManager.RegisterStartupScript(this, typeof(Page), "updatefunc", "func();", true);
            
        //}

        //protected void btngetData_Click(object sender, EventArgs e)
        //{
        //    CountMachines();
        //}

        protected void FillGradeDDL()
        {
            string insID = ddlInstitute.SelectedValue;
            string query = "select grade_ID, Grade_Name from Grade_Details where InsID " +
                " in (select id from Institute_details where ins_id='" + insID + "')";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "Grade_Name";
            ddlGrade.DataValueField = "Grade_ID";
            ddlGrade.DataBind();
            lbllive.Text = "";
            ddlTime.SelectedItem.Selected = false;
            ddlTime.Items.FindByValue("0").Selected = true;
            ddlGrade.Items.Insert(0, new ListItem("Select", "NA"));
            HttpContext.Current.Session["ipforgraph"] = "";
            //if (ddlClass.SelectedValue == "NA")
            //{
            //    ipgraph.Value = "NA";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page),
            //        "MyChartKey2", "CreateAllChart('" + insID + "');", true);
            //}
        }

        protected void FillClassDDL()
        {
            string gradeID = ddlGrade.SelectedValue;
            string query = "select ClassID, ClassName from Class_Details  " +
                " where GradeID in(select id from Grade_details where grade_id ='" + gradeID + "')";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            string select = Resources.Resource.Select;
            ddlClass.Items.Insert(0, new ListItem(select, "NA"));
            HttpContext.Current.Session["ipforgraph"] = "";
            //if (ddlClass.SelectedValue == "NA")
            //{
            //    ipgraph.Value = "NA";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "MyChartKey3",
            //        "CreateAllChart('" + gradeID + "');", true);
            //}
        }
    }
}