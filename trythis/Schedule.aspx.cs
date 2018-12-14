using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trythis
{
    public partial class Schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrd();
                string query = "select * from Institute_Details";
                DataTable dt = PopulateTree.ExecuteCommand(query);
                ddlInstitute.DataSource = dt;
                ddlInstitute.DataTextField = "InstituteName";
                ddlInstitute.DataValueField = "InstituteID";
                ddlInstitute.DataBind();
                ddlInstitute.Items.Insert(0, new ListItem("Select", "NA"));
            }

        }

        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGrade.Items.Clear();
            ddlClass.Items.Clear();
            ddlClass.Items.Insert(0, new ListItem("Select", "NA"));
            string insID = ddlInstitute.SelectedValue;
            string query = "select GradeID, GradeName from Grade_Details where InsID='"+insID+"'";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "GradeName";
            ddlGrade.DataValueField = "GradeID";
            ddlGrade.DataBind();
            ddlGrade.Items.Insert(0, new ListItem("Select", "NA"));
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
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            excelgrd.DataSource = dt;
            excelgrd.DataBind();
        }
        protected void addnewrow()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox tx1 = (TextBox)excelgrd.Rows[rowIndex].Cells[1].FindControl("txnm");
                        TextBox tx2 = (TextBox)excelgrd.Rows[rowIndex].Cells[2].FindControl("txdesc");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Slno"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Name"] = tx1.Text;
                        dtCurrentTable.Rows[i - 1]["Desc"] = tx2.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    excelgrd.DataSource = dtCurrentTable;
                    excelgrd.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox tx1 = (TextBox)excelgrd.Rows[rowIndex].Cells[1].FindControl("txnm");
                        TextBox tx2 = (TextBox)excelgrd.Rows[rowIndex].Cells[2].FindControl("txdesc");
                        tx1.Text = dt.Rows[i]["Name"].ToString();
                        tx2.Text = dt.Rows[i]["Desc"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
        protected void svbtn_Click(object sender, EventArgs e)
        {
            PopulateTree populateTree = new PopulateTree();
            foreach (GridViewRow r in excelgrd.Rows)
            {
                string des = (r.FindControl("txdesc") as TextBox).Text;
                string nm = (r.FindControl("txnm") as TextBox).Text;

                string query = "insert into Reader values('" + nm + "','" + des + "')";
                populateTree.insertANyData(query);
                (r.FindControl("txdesc") as TextBox).Text = "";
                (r.FindControl("txnm") as TextBox).Text= "";

            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            addnewrow();
        }
    }
}