using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.HikVision
{
    public partial class DownloadPlugin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/HikVision/WebComponentsKit.exe");
            Uri uri = new Uri(filePath);

            if (!string.IsNullOrEmpty(filePath))
            {

                Response.ContentType = "application/zip";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                Response.WriteFile(filePath);
                Response.Flush();
                //using (WebClient wc = new WebClient())
                //    {
                //        wc.DownloadFile(uri, @"webdevelopmentkit.zip");
                //    }

            }

        }
        public async void Index(string downloadURL)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(downloadURL))
                {
                    //using (var stream = await response.Content.ReadAsStreamAsync())
                    //{
                    //    using (Stream zip = FileManager.OpenWrite(ZIP_PATH))
                    //    {

                    //        stream.CopyTo(zip);
                    //    }
                    //}
                }
            }
        }
    }    
}