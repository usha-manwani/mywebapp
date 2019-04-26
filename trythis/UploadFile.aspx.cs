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
                FillGrid();
            }
        }

        protected void FillGrid()
        {
            string path = Server.MapPath("~/Uploads/");
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] filesnames = di.GetFiles();
           // string[] filePaths = Directory.GetFiles(Server.MapPath("~/Uploads/"));
            Array.Sort(filesnames, (x, y) => StringComparer.OrdinalIgnoreCase.Compare(x.CreationTime, y.CreationTime));
            Array.Reverse(filesnames);
            List<ListItem> files = new List<ListItem>();
            foreach (FileInfo fi in filesnames)
            {
                files.Add(new ListItem(fi.Name,fi.FullName));
            }
            
            //foreach (string filePath in filePaths)
            //{
            //    files.Add(new ListItem(Path.GetFileName(filePath), filePath));
            //}
            GridView1.DataSource = files;
            GridView1.DataBind();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fuSample.PostedFile != null)
            {
                
                int count = 0;
                string fileName = fuSample.FileName;
                string fn = fileName;
                if (!string.IsNullOrEmpty(fn)) { 
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
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('No File Selected')", true);
                }
            }
        }

        

        protected void lnkdelete_Click(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            File.Delete(filePath);
            Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void lnkPlay_Click(object sender, EventArgs e)
        {

        }

        protected void lnkDetails_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        

        //protected void lnkDownload_Click(object sender, EventArgs e)
        //{
        //    string filePath = "";
        //    filePath = (sender as LinkButton).CommandArgument;
        //    Response.ContentType = ContentType;
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        //    Response.WriteFile(filePath);
        //    Response.End();
        //}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
               
                string filePath = e.CommandArgument.ToString();
                HttpContext.Current.Session["fileName"] = filePath;
                Response.Redirect("Download.aspx");
                //DownloadFile(e.CommandArgument.ToString());
                //Response.ContentType = ContentType;
                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                //Response.WriteFile(filePath);
                //Response.End();


            }
            else if (e.CommandName == "details")
            {
                string filePath = e.CommandArgument.ToString();
                
                FileInfo file = new FileInfo(filePath);
                fileName.Text = file.Name;
                string type = file.Extension +" file";
                fileType.Text = type.Substring(1);
                fileCreation.Text = file.CreationTime.ToShortDateString();
                
                fileDateMod.Text = file.LastWriteTime.ToShortDateString();
                fileSize.Text = (Convert.ToInt64(file.Length/1024)).ToString() +" KB";
            }
            
        }
    }
}