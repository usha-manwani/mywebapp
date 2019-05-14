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
                if (!string.IsNullOrEmpty(fn))
                {
                    while (File.Exists(Server.MapPath("~/Uploads/" + fn)))
                    {
                        fn = Path.GetFileNameWithoutExtension(fileName);
                        fn = fn + "(" + count + ")";
                        string extension = Path.GetExtension(fileName);
                        fn = fn + extension;
                        count++;
                    }
                    fileName = fn;
                    try
                    {
                        fuSample.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                        UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 5);
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
            UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 7);
            Response.Redirect(Request.Url.AbsoluteUri);

        }

       

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            FillGrid();
        }        

       

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {              
                string filePath = e.CommandArgument.ToString();
                HttpContext.Current.Session["fileName"] = filePath;
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 6);
                Response.Redirect("Download.aspx");              
            }
            else if (e.CommandName == "details")
            {
                string filePath = e.CommandArgument.ToString();
                Details(filePath);
            }
            else if (e.CommandName == "play")
            {
                string filePath = e.CommandArgument.ToString();
                Details(filePath);
                string[] fileName = filePath.Split('\\');
                string ss = fileName[fileName.Length-1] ;
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 8);
                //foreach(string s in fileName)
                //{
                //    ss = ss+ s + " ";
                //}
                ScriptManager.RegisterStartupScript(this, typeof(Page), "playvideo", "PlayVideo('" + ss + "');", true);
            }            
        }       

        protected void Videobtn_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Uploads/");
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] filesnames = di.GetFiles();
            //string[] filePaths = Directory.GetFiles(Server.MapPath("~/Uploads/"));
            Array.Sort(filesnames, (x, y) => StringComparer.OrdinalIgnoreCase.Compare(x.CreationTime, y.CreationTime));
            Array.Reverse(filesnames);
            List<ListItem> files = new List<ListItem>();
            foreach (FileInfo fi in filesnames)
            {
                if (fi.Extension.ToLower() == ".avi" || fi.Extension.ToLower() == ".flv" || fi.Extension.ToLower() == ".asf"
                    || fi.Extension.ToLower() == ".qt" || fi.Extension.ToLower() == ".mov" ||
                    fi.Extension.ToLower() == ".mpg" || fi.Extension.ToLower() == ".mpeg" ||
                    fi.Extension.ToLower() == ".m4v" || fi.Extension.ToLower() == ".wmv" ||
                    fi.Extension.ToLower() == ".mp4" || fi.Extension.ToLower() == ".3gp"
                    || fi.Extension.ToLower() == ".webm" || fi.Extension.ToLower() == ".mts"
                     || fi.Extension.ToLower() == ".ogg")
                {
                    files.Add(new ListItem(fi.Name, fi.FullName));
                }

            }
            GridView1.DataSource = files;
            GridView1.DataBind();
        }

        protected void Btna_Click(object sender, EventArgs e)
        {

        }

        protected void Btni_Click(object sender, EventArgs e)
        {

        }

        protected void Btnp_Click(object sender, EventArgs e)
        {

        }
        protected void Details(string filePath)
        {
            
            FileInfo file = new FileInfo(filePath);
            fileName.Text = file.Name;
            string type = file.Extension + " file";
            fileType.Text = type.Substring(1);
            fileCreation.Text = file.CreationTime.ToShortDateString();
            fileDateMod.Text = file.LastWriteTime.ToShortDateString();
            fileSize.Text = (Convert.ToInt64(file.Length / 1024)).ToString() + " KB";
        }
    }
}