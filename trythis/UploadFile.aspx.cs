using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace trythis
{
    public partial class UploadFile : System.Web.UI.Page
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
                string fileName = fuSample.FileName;
                
                try
                {
                    fuSample.PostedFile.SaveAs((Server.MapPath("~/Uploads/") + fileName));
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