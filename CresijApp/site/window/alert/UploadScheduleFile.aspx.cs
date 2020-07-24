using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CresijApp.site.window
{
    public partial class UploadScheduleFile : System.Web.UI.Page
    {
        readonly string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["SchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnUpload_Click1(object sender, EventArgs e)
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
                                TableName = "scheduleoriginal",
                                Timeout = 600, // set command timeout
                                FieldTerminator = ",",
                                LineTerminator = "\r\n",
                                FileName = filename,
                              //  NumberOfLinesToSkip = 3 // adjust this depending on CSV file headers
                            };
                            objbulk.Columns.Add("year");
                            objbulk.Columns.Add("sem");
                            objbulk.Columns.Add("teacherid");
                            objbulk.Columns.Add("teachername");
                            objbulk.Columns.Add("courseid");                            
                            objbulk.Columns.Add("classname");
                            objbulk.Columns.Add("coursename");
                            objbulk.Columns.Add("weekstart");
                            objbulk.Columns.Add("weekend");
                            objbulk.Columns.Add("dayno");
                            objbulk.Columns.Add("section");                            
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