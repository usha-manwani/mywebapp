using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;

namespace WebCresij
{
    public partial class UploadFile : BasePage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Uploads/"));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                }
                GridView1.DataSource = files;
                GridView1.DataBind();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuSample.PostedFile != null)
            {
                
                int count = 0;
                string fileName = fuSample.FileName;
                string fn = fileName;
                while (File.Exists(Server.MapPath("~/Uploads/"+ fn)))
                {
                   fn= Path.GetFileNameWithoutExtension(fileName);
                    fn = fn + "("+count+")";
                    string extension = Path.GetExtension(fileName);
                    fn = fn + extension;
                    count++;
                }
                fileName = fn;
                try
                {
                    fuSample.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                    Response.Redirect(Request.Url.AbsoluteUri);
                    
                }
                catch (HttpException)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Max File size included is 1GB')", true);
                }
            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {            
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
            
        }
       
    }
}