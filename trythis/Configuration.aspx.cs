using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class Configuration : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = HttpContext.Current.Session["UserId"].ToString();
            if (string.IsNullOrEmpty(userid))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                if (!IsPostBack)
                {               
                    UserActivities.UserLogs.Task1(userid,
                    HttpContext.Current.Session["UserName"].ToString(), 13);
                    string query = "select * from Institute_Details";
                    DataTable dt = PopulateTree.ExecuteCommand(query);
                    ddlInstitute.DataSource = dt;
                    ddlInstitute.DataTextField = "Ins_Name";
                    ddlInstitute.DataValueField = "Ins_ID";
                    ddlInstitute.DataBind();
                    string select = Resources.Resource.Select;
                    ddlInstitute.Items.Insert(0, new ListItem(select, "NA"));
                }                              
            }            
        }
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlClass.Items.Clear();
            ddlClass.DataSource = null;
            ddlClass.DataBind();
            ddlGrade.Items.Clear();            
            string insID = ddlInstitute.SelectedValue;
            string query = "select grade_ID, Grade_Name from Grade_Details where InsID " +
                " in (select id from Institute_details where ins_id='" + insID + "')";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "Grade_Name";
            ddlGrade.DataValueField = "Grade_ID";
            ddlGrade.DataBind();
            string select = Resources.Resource.Select;
            ddlGrade.Items.Insert(0, new ListItem(select, "NA"));           
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlClass.Items.Clear();
                ddlClass.DataSource = null;
                ddlClass.DataBind();
                string gradeID = ddlGrade.SelectedValue;
                string query = "select classname, ccip from cresijdatabase.centralcontrol cc join"+
                    " cresijdatabase.class_details cd on cc.location = cd.id  where cd.GradeID in "+"" +
                    "(select id from Grade_details where grade_id ='" + gradeID + "')";
                DataTable dt = PopulateTree.ExecuteCommand(query);
                ddlClass.DataSource = dt;
                ddlClass.DataTextField = "classname";
                ddlClass.DataValueField = "ccip";
                ddlClass.DataBind();
            }
            catch
            {

            }
        }
    }
}