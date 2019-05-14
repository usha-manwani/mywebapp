﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class RemoveUsers : BasePage
    {
        Userdetails ud = new Userdetails();
        string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                s = HttpContext.Current.Session["UserId"].ToString();
            
            
                if (!IsPostBack)
                {
                    GridView1.DataSource = ud.getUserDetails(s);
                    GridView1.DataBind();
                // HideDeleteButton();
                }
            }
            catch
            {
                Response.Redirect("Error/CustomError.aspx");
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userid = GridView1.Rows[e.RowIndex].Cells[0].Text;
            try
            {
                ud.DeleteUser(userid);
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 4);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MyKey", "show(); return false;", true);
            }
            catch
            {
                
            }
            finally
            {
                GridView1.DataSource = ud.getUserDetails(s);
                GridView1.DataBind();
            }
            
           
        }
        private void HideDeleteButton()
        {

            if (GridView1.Rows == null)
            {
                Button deleteCommand = (Button)GridView1.Rows[0].FindControl("btnEdit");
                deleteCommand.Visible = false;
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string userid = GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            ud.DeleteUser(userid);
            
            GridView1.DataSource = ud.getUserDetails(s);
            GridView1.DataBind();
            
        }
    }
}