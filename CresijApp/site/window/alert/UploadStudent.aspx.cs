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
            int numofrows = 0;
            try
            {
                if (IsPostBack && Upload.HasFile)
                {
                    if (Path.GetExtension(Upload.FileName).Equals(".txt") || Path.GetExtension(Upload.FileName).Equals(".csv"))
                    {
                        var fname = Path.GetFileNameWithoutExtension(Upload.FileName) + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                        Upload.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fname + Path.GetExtension(Upload.FileName));
                        filename = Server.MapPath("~/Uploads/") + fname + Path.GetExtension(Upload.FileName);

                        using (var conn = new MySqlConnection(constr))
                        {
                            string filename1 = filename.Replace("\\", "/");
                            var query = "load data infile '" + filename1 + "' ignore into table organisationdatabase.studentdata fields " +
                                "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES";
                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            if (conn.State != System.Data.ConnectionState.Open)
                                conn.Open();
                            cmd.CommandTimeout = 5000000;
                            numofrows = cmd.ExecuteNonQuery();
                            // creating bulk loader instance
                            //MySqlBulkLoader objbulk = new MySqlBulkLoader(conn)
                            //{
                            //    TableName = "teacherdata",
                            //    Timeout = 600, // set command timeout
                            //    FieldTerminator = ",",
                            //    LineTerminator = "\r\n",
                            //    FileName = filename,
                            //    //NumberOfLinesToSkip = 1 // adjust this depending on CSV file headers
                            //};
                            //objbulk.Columns.Add("studentid");
                            //objbulk.Columns.Add("studentName");
                            //objbulk.Columns.Add("gender");
                            //objbulk.Columns.Add("age");
                            //objbulk.Columns.Add("deptcode");
                            //objbulk.Columns.Add("phone");
                            //objbulk.Columns.Add("idcard");
                            //objbulk.Columns.Add("onecard");
                            //objbulk.Load();
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