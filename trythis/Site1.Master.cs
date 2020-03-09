﻿using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebCresij
{
    public partial class Site1 : MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name) != null)
                {
                    ddlLanguages.Items.FindByValue(CultureInfo.CurrentCulture.Name).Selected = true;
                }
            }
            try
            {
                string s = HttpContext.Current.Session["UserName"].ToString();
                string roleids = HttpContext.Current.Session["role"].ToString();
                if (s != null)
                {
                    username.Text = "  " + s + "!!";
                    int[] roleIds = roleids.ToCharArray().Select(x => (int)char.GetNumericValue(x)).ToArray();
                    displayRole(roleIds, roleids);
                }
                else
                {                   
                    Response.Redirect("~/Index.aspx");
                }
            }
            catch
            {
                Response.Redirect("~/Index.aspx");
            }
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");           
        }
        
        private void displayRole(int[] roleIds, string roleids)
        {
            ICcard.Visible = false;
            navbarDropdown4.Visible = true;
            navbarDropdown2.Visible = false;
            status.Visible = true;
            logouts.Visible = true;
            uploadDoc.Visible = false;
            downloadDoc.Visible = false;
            delDoc.Visible = false;
            maintainanceLink.Visible = false;
            addUser.Visible = false;
            removeUser.Visible = false;
            approveUser.Visible = false;
            navbarDropdown1.Visible = false;
            navbarDropdown.Visible = false;
            dashboard.Visible = false;
            for (int i = 0; i < roleIds.Length; i++)
            {
                if (roleIds[i] == 1)
                {
                    navbarDropdown.Visible = true;                    
                    navbarDropdown1.Visible = true;
                    navbarDropdown2.Visible = true;
                    uploadDoc.Visible = true;
                    downloadDoc.Visible = true;
                    delDoc.Visible = true;
                    addUser.Visible = true;
                    removeUser.Visible = true;
                    approveUser.Visible = true;
                    dashboard.Visible = true;
                    ICcard.Visible = true;
                    maintainanceLink.Visible = true;
                    break;
                }
                else
                {
                    if (roleIds[i] == 2){}
                    else if (roleIds[i] == 3)
                    {
                        navbarDropdown2.Visible = true;
                    }
                    else if (roleIds[i] == 4 )
                    {
                        navbarDropdown1.Visible = true;
                        uploadDoc.Visible = true;
                        downloadDoc.Visible = true;
                        delDoc.Visible = true;
                    }
                    else if (roleIds[i] == 5)
                    {
                        navbarDropdown1.Visible = true;
                        maintainanceLink.Visible = true;
                    }
                    else if (roleIds[i] == 6)
                    {
                        navbarDropdown.Visible = true;
                    }                    
                }               
            }                       
        }      
    }
}