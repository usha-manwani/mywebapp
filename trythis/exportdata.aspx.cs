using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebCresij
{
    public partial class exportdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = HttpContext.Current.Session["fileName"].ToString();
            if (!string.IsNullOrEmpty(filePath))
            {
                Response.ContentType = ContentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.Flush();
                HttpContext.Current.Session["fileName"] = "";
                File.Delete(filePath);                
            }            
        }
    }
}