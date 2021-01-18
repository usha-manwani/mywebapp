using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace CresijApp.site.window.alert
{
    public partial class UploadFile : System.Web.UI.Page
    {
        readonly string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["SchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnUpload_Click1(object sender, EventArgs e)
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
                            var query = "load data infile '" + filename1 + "' ignore into table organisationdatabase.operationmgmt fields " +
                                "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`devicename`,`assetno`,`model`," +
                                "`specification`,`devicetype`,`price`,`factory`,`dateofmanufacture`,`dateofpurchase`,`dateofdelivery`," +
                                "`warrantytime`,`locationType`,`equipmentstatus`)";
                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            if (conn.State != ConnectionState.Open)
                                conn.Open();
                            cmd.CommandTimeout = 5000000;
                            numofrows = cmd.ExecuteNonQuery();
                            //// creating bulk loader instance
                            //MySqlBulkLoader objbulk = new MySqlBulkLoader(conn)
                            //{
                            //    TableName = "operationmgmt",
                            //    Timeout = 600, // set command timeout
                            //    FieldTerminator = ",",
                            //    LineTerminator = "\r\n",
                            //    FileName = filename,
                            //    //NumberOfLinesToSkip = 1 // adjust this depending on CSV file headers
                            //};
                            //objbulk.Columns.Add("devicename");
                            //objbulk.Columns.Add("assetno");
                            //objbulk.Columns.Add("model");
                            //objbulk.Columns.Add("specification");
                            //objbulk.Columns.Add("devicetype");
                            //objbulk.Columns.Add("price");
                            //objbulk.Columns.Add("factory");
                            //objbulk.Columns.Add("dateofmanufacture");
                            //objbulk.Columns.Add("dateofpurchase");
                            //objbulk.Columns.Add("dateofdelivery");
                            //objbulk.Columns.Add("warrantytime");
                            //objbulk.Columns.Add("locationType");
                            //objbulk.Columns.Add("equipmentstatus");
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

    public static class ExcelPackageExtensions
    {
        public static DataTable ToDataTable(this ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            DataTable table = new DataTable();
            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                table.Columns.Add(firstRowCell.Text);
            }
            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = table.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                table.Rows.Add(newRow);
            }
            return table;
        }
    }
}
