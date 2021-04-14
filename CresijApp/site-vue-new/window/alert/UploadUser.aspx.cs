using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CresijApp.site.window.alert
{
    public partial class UploadUser : System.Web.UI.Page
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
                            var query = "load data infile '" + filename1 + "' ignore into table userdetails fields " +
                                "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`loginID`,`UserName`,`PersonType`," +
                                "`Deptcode`,`PersonnelStatus`,`Notes`,`Password`,`phone`,`validtill`,`expiretime`)";
                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            if (conn.State != ConnectionState.Open)
                                conn.Open();
                            cmd.CommandTimeout = 5000000;
                            numofrows = cmd.ExecuteNonQuery();
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