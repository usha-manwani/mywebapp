﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class Configuration : System.Web.UI.Page
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
            }
        }
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlClass.Items.Clear();
            ddlClass.DataSource = null;
            ddlClass.DataBind();
            ddlGrade.Items.Clear();            
            string insID = ddlInstitute.SelectedValue;
            string query = "select GradeID, GradeName from Grade_Details where InsID='" + insID + "'";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "GradeName";
            ddlGrade.DataValueField = "GradeID";
            ddlGrade.DataBind();
            ddlGrade.Items.Insert(0, new ListItem("Select", "NA"));           
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            }
            catch
            {

            }
        }
    }
}