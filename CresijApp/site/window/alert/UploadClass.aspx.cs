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
                                TableName = "classdetail",
                                Timeout = 600, // set command timeout
                                FieldTerminator = ",",
                                LineTerminator = "\r\n",
                                FileName = filename,
                               // NumberOfLinesToSkip = 3 // adjust this depending on CSV file headers
                            };
                            objbulk.Columns.Add("ClassName");
                            objbulk.Columns.Add("teachingbuilding");
                            objbulk.Columns.Add("floor");
                            objbulk.Columns.Add("seats");
                            objbulk.Columns.Add("camipS");
                            objbulk.Columns.Add("camipT");
                            objbulk.Columns.Add("coursename");
                            objbulk.Columns.Add("camSmac");
                            objbulk.Columns.Add("camTmac");
                            objbulk.Columns.Add("camport");
                            objbulk.Columns.Add("camuserid");
                            objbulk.Columns.Add("campass");
                            objbulk.Columns.Add("ccequipIP");
                            objbulk.Columns.Add("ccmac");
                            objbulk.Columns.Add("desktopip");
                            objbulk.Columns.Add("deskmac");
                            objbulk.Columns.Add("recordingEquip");
                            objbulk.Columns.Add("recordermac");
                            objbulk.Columns.Add("callhelpip");
                            objbulk.Columns.Add("callhelpmac");
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