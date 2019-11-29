using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = HttpContext.Current.Session["fileName"].ToString();
            if (!string.IsNullOrEmpty(filePath))
            {
                if (File.Exists(filePath))
                {
                    Response.ContentType = ContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.WriteFile(filePath);
                    Response.Flush();
                }
                else
                {
                    try
                    {
                        FileInfo fn = new FileInfo(filePath);
                        int result;
                        string name = fn.Name;
                        UploadFiles up = new UploadFiles();
                        File.Delete(filePath);
                        result = up.DeleteFileInfo(HttpContext.Current.Session["UserId"].ToString(), name);

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertdelete",
                            "alert('File with this name doesnt exists anymore')", true);
                        
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertdelete",
                            "alert('Some error occured. Please try again !!')", true);
                    }
                    
                }
                HttpContext.Current.Session["fileName"] = "";
                Response.Redirect("UploadFile.aspx");
            }
        }
    }
}