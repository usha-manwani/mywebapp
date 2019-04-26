using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class Maintainance : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }                
        }

        protected void FillData()
        {
            DataTable dt = new DataTable();
            dt = PopulateTree.ExecuteCommand("Select * from FaultInfo order by sno");
            gv1.DataSource = dt;
            gv1.DataBind();
            FillChartGrid();
            FillInspectGrid();
        }

        protected void Gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv1.PageIndex = e.NewPageIndex;
            FillData();
        }

        public void DeleteAll(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in gv1.Rows)
            {
                if ((gr.FindControl("chkSelect") as CheckBox).Checked)
                {
                    int sno = Convert.ToInt32(gr.Cells[1].Text);
                    PopulateTree.AnyTask("Delete from FaultInfo where sno = " + sno);
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
            int sno = Convert.ToInt32(gv1.DataKeys[gvrow.RowIndex].Value.ToString());
            PopulateTree.AnyTask("Delete from FaultInfo where sno = " + sno);
            FillData();
        }

        protected void gv1_RowDataBound(object sender, GridViewRowEventArgs e)
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
            int sno = Convert.ToInt32(gv1.DataKeys[gvrow.RowIndex].Value.ToString());
            string time = gv1.Rows[gvrow.RowIndex].Cells[10].Text.ToString();
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
            string query = "SELECT COUNT(CASE Stat WHEN 'Resolved' THEN 1 END) AS Resolved, COUNT(CASE " +
                 "Stat WHEN 'Pending' THEN 1 END) AS Pending," + " distName FROM FaultInfo group by distName";
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
            dt=PopulateTree.ExecuteCommand("select * from InspectionLogs order by sno");
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
            PopulateTree.AnyTask("Delete from InspectionLogs where sno = " + sno);
            FillInspectGrid();
        }
    }
}