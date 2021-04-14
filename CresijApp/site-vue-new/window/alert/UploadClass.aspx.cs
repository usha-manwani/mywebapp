using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
namespace CresijApp.site.window.alert
{
    public partial class UploadClass : Page
    {
        readonly string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["SchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = ""; int numofrows = 0;
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
                            var query = "load data infile '" + filename1 + "' ignore into table classdetails fields " +
                                "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`ClassName`,`teachingbuilding`," +
                                "`floor`,`seats`,`camipS`,`camipT`,`camSmac`,`camTmac`,`camport`,`camuserid`,`campass`," +
                                "`ccequipIP`,`ccmac`,`desktopip`,`deskmac`,`recordingEquip`,`recordermac`,`callhelpip`,`callhelpmac`)";
                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            if (conn.State != ConnectionState.Open)
                                conn.Open();
                            cmd.CommandTimeout = 5000000;
                            numofrows = cmd.ExecuteNonQuery();
                            //// creating bulk loader instance
                            //MySqlBulkLoader objbulk = new MySqlBulkLoader(conn)
                            //{
                            //    TableName = "classdetail",
                            //    Timeout = 600, // set command timeout
                            //    FieldTerminator = ",",
                            //    LineTerminator = "\r\n",
                            //    FileName = filename,
                            //   // NumberOfLinesToSkip = 3 // adjust this depending on CSV file headers
                            //};
                            //objbulk.Columns.Add("ClassName");
                            //objbulk.Columns.Add("teachingbuilding");
                            //objbulk.Columns.Add("floor");
                            //objbulk.Columns.Add("seats");
                            //objbulk.Columns.Add("camipS");
                            //objbulk.Columns.Add("camipT");
                            //objbulk.Columns.Add("coursename");
                            //objbulk.Columns.Add("camSmac");
                            //objbulk.Columns.Add("camTmac");
                            //objbulk.Columns.Add("camport");
                            //objbulk.Columns.Add("camuserid");
                            //objbulk.Columns.Add("campass");
                            //objbulk.Columns.Add("ccequipIP");
                            //objbulk.Columns.Add("ccmac");
                            //objbulk.Columns.Add("desktopip");
                            //objbulk.Columns.Add("deskmac");
                            //objbulk.Columns.Add("recordingEquip");
                            //objbulk.Columns.Add("recordermac");
                            //objbulk.Columns.Add("callhelpip");
                            //objbulk.Columns.Add("callhelpmac");
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