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

namespace CresijApp.site.window.alert.data
{
    public partial class UploadFile : System.Web.UI.Page
    {

        readonly string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["SchoolConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void  btnUpload_Click()
        {
            try
            {
                if (IsPostBack && Upload.HasFile)
                {
                    if (Path.GetExtension(Upload.FileName).Equals(".xlsx"))
                    {
                        var excel = new ExcelPackage(Upload.FileContent);
                        var dt = excel.ToDataTable();
                        var table = "operationmgmt";
                        using (var conn = new MySqlConnection(constr))
                        {
                            var bulkCopy = new MySqlBulkLoader(conn)
                            {
                                TableName = table
                            };
                            conn.Open();
                            //var schema = conn.GetSchema("Columns", new[] { null, null, table, null });
                            //foreach (DataColumn sourceColumn in dt.Columns)
                            //{
                            //    foreach (DataRow row in schema.Rows)
                            //    {
                            //        if (string.Equals(sourceColumn.ColumnName, (string)row["COLUMN_NAME"], StringComparison.OrdinalIgnoreCase))
                            //        {
                            //            bulkCopy.ColumnMappings.Add(sourceColumn.ColumnName, (string)row["COLUMN_NAME"]);
                            //            break;
                            //        }
                            //    }
                            //}
                            bulkCopy.Load();
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }            
        }

        protected void BtnUpload_Click1(object sender, EventArgs e)
        {
            string filename="";
           
            try
            {
                if (IsPostBack && Upload.HasFile)
                {
                    if (Path.GetExtension(Upload.FileName).Equals(".txt") || Path.GetExtension(Upload.FileName).Equals(".csv"))
                    {
                        Upload.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + Upload.FileName);                       
                        filename = Server.MapPath("~/Uploads/") + Upload.FileName+"_"+ DateTime.Now.Minute+"_"+ DateTime.Now.Second;
                        
                        using (var conn = new MySqlConnection(constr))
                        {
                            // creating bulk loader instance
                            MySqlBulkLoader objbulk = new MySqlBulkLoader(conn);
                            objbulk.TableName = "operationmgmt";
                            objbulk.Timeout = 600; // set command timeout                           
                            objbulk.FieldTerminator = ",";
                            objbulk.LineTerminator = "\r\n";                                                      
                            objbulk.FileName = filename;
                            objbulk.NumberOfLinesToSkip = 3; // adjust this depending on CSV file headers
                            objbulk.Columns.Add("devicename");
                            objbulk.Columns.Add("assetno");
                            objbulk.Columns.Add("model");
                            objbulk.Columns.Add("specification");
                            objbulk.Columns.Add("devicetype");
                            objbulk.Columns.Add("price");
                            objbulk.Columns.Add("factory");
                            objbulk.Columns.Add("dateofmanufacture");
                            objbulk.Columns.Add("dateofpurchase");
                            objbulk.Columns.Add("dateofdelivery");
                            objbulk.Columns.Add("warrantytime");
                            objbulk.Columns.Add("locationType");
                            objbulk.Columns.Add("equipmentstatus");
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