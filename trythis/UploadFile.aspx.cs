using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data;

namespace WebCresij
{
    public partial class UploadFile : BasePage
    {
        UploadFiles up = new UploadFiles();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (HttpContext.Current.Session["UserId"] != null)
            {
                if (!IsPostBack)
                {                 
                        updateGrid();                    
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
        protected void updateGrid()
        {
            
            DataTable dt = up.GetFiles("Personal", HttpContext.Current.Session["UserId"].ToString());
            List<ListItem> files = new List<ListItem>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    files.Add(new ListItem(dr[0].ToString(), Server.MapPath("~/Uploads/") + dr[0]));
            //}
            GridView1.DataSource = dt;
            GridView1.DataBind();
            dt = up.GetFiles("Public", "");
            List<ListItem> filePrivate = new List<ListItem>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    filePrivate.Add(new ListItem(dr[0].ToString(), Server.MapPath("~/Uploads/") + dr[0]));
            //}
            GridView2.DataSource = dt;
            GridView2.DataBind();

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
                int count = 1;
                string fileName = fuSample.FileName;
                string fn = fileName;
                if (!string.IsNullOrEmpty(fn))
                {
                    if(Path.GetExtension(fileName) ==".zip" || Path.GetExtension(fileName) == ".rar")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "NoarchiveFile", "alert(You cannot upload archive files!!)", true);
                    }
                    else
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
                            string fname = "~/Uploads/" + fileName;
                            fuSample.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);

                            up.AddFileDetail(HttpContext.Current.Session["UserId"].ToString(),
                                fn, "Personal");
                            UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                            HttpContext.Current.Session["UserName"].ToString(), 5);
                            updateGrid();
                            // Response.Redirect(Request.Url.AbsoluteUri);
                        }
                        catch (HttpException)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(),
                                "alertMessage", "alert('Max File size allowed is 500')", true);
                        }
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
            string filePath = Server.MapPath("~/Uploads/")+(sender as LinkButton).CommandArgument;
            FileInfo fn = new FileInfo(filePath);
            int result;
            string name = fn.Name;
            try
            {
                File.Delete(filePath);
                result= up.DeleteFileInfo(HttpContext.Current.Session["UserId"].ToString(), name);
                if (result == 1)
                {
                    UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                                        HttpContext.Current.Session["UserName"].ToString(), 7);
                }
                else if(result==-1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alertdelete",
                        "alert('You cannot delete File uploaded by Other Users')", true);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            finally {
                updateGrid();
            }            
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
                string filePath = Server.MapPath("~/Uploads/") + e.CommandArgument.ToString();
                HttpContext.Current.Session["fileName"] = filePath;
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 6);
                Response.Redirect("Download.aspx");              
            }
            else if (e.CommandName == "details")
            {
                string filePath = Server.MapPath("~/Uploads/") + e.CommandArgument.ToString();
                Details(filePath);
            }
            else if (e.CommandName == "play")
            {
                string filePath = Server.MapPath("~/Uploads/") + e.CommandArgument.ToString();
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
            else if(e.CommandName=="Share")
            {
                string filePath = Server.MapPath("~/Uploads/") + e.CommandArgument.ToString();
                FileInfo fn = new FileInfo(filePath);
                string name = fn.Name;
                up.UpdateType(HttpContext.Current.Session["UserId"].ToString(), name);
                updateGrid();
            }
        }       

        protected void Videobtn_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Uploads/");
            gridview1div.Style.Add("display", "none");
            gridview2div.Style.Add("display", "none");
            VideoGrid.Visible = true;
            FillVideoGrid(path);
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
            
            FileInfo file =   new FileInfo(filePath);
            fileName.Text = file.Name;
            string type = file.Extension + " file";
            fileType.Text = type.Substring(1);
            fileCreation.Text = file.CreationTime.ToShortDateString();
            fileDateMod.Text = file.LastWriteTime.ToShortDateString();
            fileSize.Text = (Convert.ToInt64(file.Length / 1024)).ToString() + " KB";
        }

        protected void showAll_Click(object sender, EventArgs e)
        {
            gridview1div.Style.Add("display", "block");
            gridview2div.Style.Add("display", "block");
            VideoGrid.Visible = false;
            updateGrid();
        }

        protected void VideoGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                string filePath =  e.CommandArgument.ToString();
                HttpContext.Current.Session["fileName"] = filePath;
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 6);
                Response.Redirect("Download.aspx");
            }
            else if (e.CommandName == "details")
            {
                string filePath =  e.CommandArgument.ToString();
                Details(filePath);
            }
            else if (e.CommandName == "play")
            {
                string filePath =  e.CommandArgument.ToString();
                Details(filePath);
                string[] fileName = filePath.Split('\\');
                string ss = fileName[fileName.Length - 1];
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 8);
                //foreach(string s in fileName)
                //{
                //    ss = ss+ s + " ";
                //}
                ScriptManager.RegisterStartupScript(this, typeof(Page), "playvideo", "PlayVideo('" + ss + "');", true);
            }
        }

        protected void VideoGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            VideoGrid.PageIndex = e.NewPageIndex;
            FillVideoGrid(Server.MapPath("~/Uploads/"));
        }
        protected void FillVideoGrid(string path)
        {
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
            VideoGrid.DataSource = files;
            VideoGrid.DataBind();
        }
    }
}