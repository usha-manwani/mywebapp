using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;

namespace CresijApp.site.window.alert
{
    public partial class UploadStudent : System.Web.UI.Page
    {
        readonly string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["SchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = "";
            try
            {
                if (IsPostBack && Upload.HasFile)
                {
                    if (Path.GetExtension(Upload.FileName).Equals(".txt") || Path.GetExtension(Upload.FileName).Equals(".csv"))
                    {
                        var fname = Upload.FileName + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                        Upload.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fname);
                        filename = Server.MapPath("~/Uploads/") + fname;

                        using (var conn = new MySqlConnection(constr))
                        {
                            // creating bulk loader instance
                            MySqlBulkLoader objbulk = new MySqlBulkLoader(conn)
                            {
                                TableName = "teacherdata",
                                Timeout = 600, // set command timeout
                                FieldTerminator = ",",
                                LineTerminator = "\r\n",
                                FileName = filename,
                                //NumberOfLinesToSkip = 1 // adjust this depending on CSV file headers
                            };
                            objbulk.Columns.Add("studentid");
                            objbulk.Columns.Add("studentName");
                            objbulk.Columns.Add("gender");
                            objbulk.Columns.Add("age");
                            objbulk.Columns.Add("deptcode");
                            objbulk.Columns.Add("phone");
                            objbulk.Columns.Add("idcard");
                            objbulk.Columns.Add("onecard");
                            objbulk.Load();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (!string.IsNullOrEmpty(filename))
                {
                    File.Delete(filename);
                }

            }
        }
    }
}