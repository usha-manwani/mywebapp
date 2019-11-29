using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;

namespace WebCresij
{
    public partial class Maintainance : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(exportToExcel);
                string query = "select * from Institute_Details";
                DataTable dt = PopulateTree.ExecuteCommand(query);
                ddlInstitute.DataSource = dt;
                ddlInstitute.DataTextField = "Ins_Name";
                ddlInstitute.DataValueField = "Ins_ID";
                ddlInstitute.DataBind();
               // GradeDetails();
                TaskDetails();
                FillData();
            }
        }

        private void TaskDetails()
        {
            string query = "select Id, Task, TimeToReport from Fault_Task";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            gvInputTask.DataSource = dt;
            gvInputTask.DataBind();
            ViewState["TaskCurrentTable"] = dt;
        }

        protected void GradeDetails()
        {
            string insID = ddlInstitute.SelectedValue;
            ScriptManager.RegisterStartupScript(this, typeof(Page),
                "listGrades", "GetAllIssues('" + insID + "');", true);
        }

        protected void FillData()
        {
            string query = "SELECT sno, IP, fault_knowledge as faultknow, cd.ClassName , priority, " +
                " Grade_Name as GradeName, distName as distName, " 
                +"member_Name as memName , phone, description, time, LastUpdated, status as stat "+
                "FROM Fault_Info f   join Class_Details cd on cd.id = f.classID "+
                "join Grade_Details gd on gd.ID = cd.gradeId order by sno";
            DataTable dt = new DataTable();
            //string query = "SELECT [sno],IP,faultknow,cd.ClassName ,[priority],[GradeName],[distName], " +
            //    "[memName] ,[phone],[description],[time],LastUpdated,[stat] " +
            //    "FROM[dbo].[FaultInfo] f join Grade_Details gd on gd.GradeID = f.gradeId " +
            //    "join Class_Details cd on cd.ClassID = f.classID order by sno";
            dt = PopulateTree.ExecuteCommand(query);
            if (dt.Rows.Count == 0)
            {
                EmptyFaultGrid();
            }
            else
            {
                gv1Fault.DataSource = dt;
                gv1Fault.DataBind();
            }
            ViewState["FaultCurrentTable"] = dt;
            FillChartGrid();
            FillInspectGrid();
        }

        protected void AddNewFault_Click(object sender, EventArgs e)
        {
            gv1Fault.ShowFooter = true;
            FillData();            
        }

        protected void Gv1Fault_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv1Fault.PageIndex = e.NewPageIndex;
            FillData();
        }

        public void DeleteAll(object sender, EventArgs e)
        {
            DataTable dt = ViewState["FaultCurrentTable"] as DataTable;
            for(int i=0; i< gv1Fault.Rows.Count; i++)
            {
                GridViewRow gr = gv1Fault.Rows[i];
                if ((gr.FindControl("chkSelect") as CheckBox).Checked)
                {
                    int sno = Convert.ToInt32(dt.Rows[i][0].ToString());
                    PopulateTree.AnyTask("Delete from Fault_Info where sno = " + sno);
                }
            }                        
            FillData();
        }

        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting sno of particular row
            int sno = Convert.ToInt32(gv1Fault.DataKeys[gvrow.RowIndex].Value.ToString());
            PopulateTree.AnyTask("Delete from Fault_Info where sno = " + sno);
            FillData();
        }

        protected void Gv1Fault_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //getting sno from particular row
                string sno = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "sno"));
                LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("lnkdelete");
                LinkButton lnkbtnresult1 = (LinkButton)e.Row.FindControl("lnkedit");
            }
        }

        protected void lnkedit_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting sno of particular row
            int sno = Convert.ToInt32(gv1Fault.DataKeys[gvrow.RowIndex].Value.ToString());
            string time = gv1Fault.Rows[gvrow.RowIndex].Cells[11].Text.ToString();
            timetxt.Text = time;
            snotxt.Text = sno.ToString();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "EditModalOpen", "displayModalnow();", true);
            //PopulateTree.AnyTask("Update FaultInfo set sno='18' where sno= " + sno);
            //FillData();
        }

        protected void btneditok_Click(object sender, EventArgs e)
        {
            int sno = Convert.ToInt32(snotxt.Text);
            PopulateTree.AnyTask("Update FaultInfo set memName='" + assigntxt.Text + "' where sno= " + sno);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "EditModalClose", "noModal();", true);
            FillData();
        }

        protected void FillChartGrid()
        {
            DataTable dt = new DataTable();
            string query = "SELECT COUNT(CASE Status WHEN 'Resolved' THEN 1 END) AS Resolved, COUNT(CASE "+ 
                 "Status WHEN 'Pending' THEN 1 END) AS Pending, distName "+
                 "FROM cresijdatabase.Fault_Info group by distName";
            dt = PopulateTree.ExecuteCommand(query);
            gvChart.DataSource = dt;
            gvChart.DataBind();
        }

        protected void gvinspect_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvinspect.PageIndex = e.NewPageIndex;
            //FillInspectGrid();
        }

        protected void gvinspect_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //getting sno from particular row
                string sno = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "sno"));
                LinkButton lnkbtnresult = (LinkButton)e.Row.FindControl("lnkdeleteInspect");
            }
        }

        protected void gvChart_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvChart.PageIndex = e.NewPageIndex;
            FillChartGrid();
        }

        protected void FillInspectGrid()
        {
            DataTable dt = new DataTable();
            dt = PopulateTree.ExecuteCommand("select * from Inspection_Logs order by sno");
            gvinspect.DataSource = dt;
            gvinspect.DataBind();
        }

        protected void lnkdeleteInspect_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting sno of particular row
            int sno = Convert.ToInt32(gvinspect.DataKeys[gvrow.RowIndex].Value.ToString());
            PopulateTree.AnyTask("Delete from Inspection_Logs where sno = " + sno);
            FillInspectGrid();
        }

        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            GradeDetails();
        }

        protected void gvInputTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                int n = Convert.ToInt32(e.CommandArgument);
                string query = "Delete from Fault_Task where Id=" + n;
                DeletefromFaultTask(query);
            }
            if (e.CommandName.Equals("Update"))
            {
                int n = Convert.ToInt32(e.CommandArgument);
            }
        }

        protected void gvInputTask_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int index = e.NewEditIndex;
            TextBox tt = (TextBox)gvInputTask.Rows[index].FindControl("tasktext");
            tt.Enabled = true;
            tt.CssClass = "TextBoxEditMode";
        }

        protected void gvInputTask_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string sendername = ((TextBox)gvInputTask.Rows[e.RowIndex].FindControl("tasktext")).Text;
            int id = Convert.ToInt32(((Label)gvInputTask.Rows[e.RowIndex].FindControl("idOfTask")).Text);
            string query = "Update Fault_Task set Task ='" + sendername + "' where Id=" + id;
            PopulateTree.AnyTask(query);
            TaskDetails();
        }

        protected void gvInputTask_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void DeletefromFaultTask(string query)
        {
            PopulateTree.AnyTask(query);
            TaskDetails();
        }

        protected void gvInputTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //getting sno from particular row
                string sno = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Id"));
                TextBox tb = e.Row.FindControl("tasktext") as TextBox;
            }
        }

        protected void AddNewTask_Click(object sender, EventArgs e)
        {
            // bindgrd();
            if (ViewState["TaskCurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["TaskCurrentTable"];
                DataRow drCurrentRow = null;
                try
                {
                    // SetPreviousData();
                    DataTable dt = dtCurrentTable;
                    drCurrentRow = dt.NewRow();
                    drCurrentRow["TimeToReport"] = DateTime.Now;
                    drCurrentRow["Task"] = "Enter the task here";
                    string query = "Insert into Fault_Task (task, timetoreport) values('" + drCurrentRow["Task"] +
                         "', now())";
                    PopulateTree.AnyTask(query);
                    dt.Rows.Add(drCurrentRow);
                    //gvInputTask.DataSource = dt;
                    //gvInputTask.DataBind();
                    //dtCurrentTable = dt;
                    //ViewState["TaskCurrentTable"] = dtCurrentTable;
                    TaskDetails();
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    TaskDetails();
                }
            }
            else
            {
                TaskDetails();
            }

        }

        protected void gv1Fault_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                // TextBox faultknow = gv1Fault.FooterRow.FindControl("newfaultknow") as TextBox;
                string faultvia = "Manual";
                DropDownList prio = gv1Fault.FooterRow.FindControl("ddlnewPriority") as DropDownList;               
                TextBox distName = gv1Fault.FooterRow.FindControl("newdistName") as TextBox;
                TextBox memName = gv1Fault.FooterRow.FindControl("newmemName") as TextBox;
                TextBox phone = gv1Fault.FooterRow.FindControl("newphone") as TextBox;
                TextBox description = gv1Fault.FooterRow.FindControl("newdescription") as TextBox;
                DropDownList ddlstats = gv1Fault.FooterRow.FindControl("ddlnewStat") as DropDownList;
                TextBox ip = gv1Fault.FooterRow.FindControl("newIP") as TextBox;
                string prioritytext = prio.SelectedValue;
                string selectedstat = ddlstats.SelectedValue;
                MaintainanceData maintainanceData = new MaintainanceData();

                if (!(string.IsNullOrEmpty(ip.Text)  ||
                     string.IsNullOrEmpty(distName.Text) ||
                    string.IsNullOrEmpty(memName.Text) || string.IsNullOrEmpty(description.Text)
                     || string.IsNullOrEmpty(phone.Text) ))
                {
                    int result = maintainanceData.InsertFaultInfo(ip.Text, faultvia,
                    prioritytext, distName.Text
                    , memName.Text, description.Text, phone.Text, selectedstat);
                }
                gv1Fault.ShowFooter = false;
                FillData();
                GradeDetails();
            }
        }

        protected void EmptyFaultGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sno", typeof(int));
            dt.Columns.Add("IP", typeof(string));
            dt.Columns.Add("faultknow", typeof(string));
            dt.Columns.Add("priority", typeof(string));
            dt.Columns.Add("GradeName", typeof(string));
            dt.Columns.Add("distName", typeof(string));
            dt.Columns.Add("ClassName", typeof(string));
            dt.Columns.Add("memName", typeof(string));
            dt.Columns.Add("phone", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("time", typeof(string));
            dt.Columns.Add("LastUpdated", typeof(string));
            dt.Columns.Add("stat", typeof(string));
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            gv1Fault.DataSource = dt;
            gv1Fault.DataBind();
            gv1Fault.Rows[0].Visible = false;
        }

        protected void btnFaultUpdate_Click(object sender, EventArgs e)
        {
            LinkButton lnkbtn = sender as LinkButton;
            //getting particular row linkbutton
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            //getting sno of particular row
            int sno = Convert.ToInt32(gv1Fault.DataKeys[gvrow.RowIndex].Value.ToString());
            FillData();
        }

        protected void gv1Fault_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv1Fault.EditIndex = e.NewEditIndex;
            FillData();
        }

        protected void gv1Fault_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv1Fault.EditIndex = -1;
            FillData();
        }

        protected void gv1Fault_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string ID = gv1Fault.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = gv1Fault.Rows[e.RowIndex];
            DropDownList ddlprio =(DropDownList) row.FindControl("ddlPriority");
            //TextBox priority = (TextBox)row.FindControl("txtPriority");
            TextBox memName = (TextBox)row.FindControl("txtmemName");
            TextBox phone = (TextBox)row.FindControl("txtphone");
            TextBox desc = (TextBox)row.FindControl("txtdescription");
            //TextBox stat = (TextBox)row.FindControl("txtstat");
            DropDownList ddlstats = (DropDownList)row.FindControl("ddlStat");
            string query = "Update Fault_Info set priority ='" + ddlprio.SelectedValue + "', member_Name='" + memName.Text + "',phone='" +
                phone.Text + "', description ='" + desc.Text + "', status='" + ddlstats.SelectedValue + 
                "', LastUpdated=Now() where sno = " + Convert.ToInt32(ID);
            PopulateTree.AnyTask(query);
            gv1Fault.EditIndex = -1;
            FillData();
        }

        protected void exportToExcel_Click(object sender, EventArgs e)
        {
            gv1Fault.AllowPaging = false;
            DataTable dt1 = (DataTable)ViewState["FaultCurrentTable"];
            dt1.Columns.RemoveAt(0);
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt1);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=FaultInfo.xlsx");
                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
    }
}