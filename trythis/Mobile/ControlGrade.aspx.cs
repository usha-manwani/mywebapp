using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Mobile
{
    public partial class ControlGrade : BasePage
    {
        string listofIp = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select * from Institute_Details";
                DataTable dt = PopulateTree.ExecuteCommand(query);
                ddlInstitute.DataSource = dt;
                ddlInstitute.DataTextField = "Ins_Name";
                ddlInstitute.DataValueField = "ID";
                ddlInstitute.DataBind();
                string select = Resources.Resource.Select;
                ddlInstitute.Items.Insert(0, new ListItem(select, "NA"));
            }
            
        }
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ddlGrade.Items.Clear();
            string insID = ddlInstitute.SelectedValue;
            string query = "select ID, Grade_Name from Grade_Details where InsID = " + insID;
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "Grade_Name";
            ddlGrade.DataValueField = "ID";
            ddlGrade.DataBind();
            string select = Resources.Resource.Select;
            ddlGrade.Items.Insert(0, new ListItem(select, "0"));
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
                string gradeID = ddlGrade.SelectedValue;
                string query = "select CCIP from CentralControl where location in " +
                    "(select id from class_details where gradeid ="+gradeID+" ) ";
                DataTable dt = PopulateTree.ExecuteCommand(query);
                ipadd.Value = "";
                listofIp = "";
                foreach(DataRow dr in dt.Rows)
                {
                    listofIp = listofIp + "," + dr[0].ToString() ;
                    ipadd.Value = ipadd.Value + "," + dr[0].ToString();
                }
                
            }
            catch
            {

            }
        }

        protected void Btnon_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "SystemOn", "SystemOn('"+listofIp+"');", true);
        }

        protected void BtnOff_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "SystemOff", "SystemOff('" + listofIp + "');", true);
        }

        protected void BtnLock_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "SystemLock", "SystemLock('" + listofIp + "');", true);
        }

        protected void BtnUnlock_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "SystemUnlock", "SystemUnlock('" + listofIp + "');", true);
        }
    }
}