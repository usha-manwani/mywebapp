using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class Schedule : BasePage
    {
        static DataTable dtStatic = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrd();
                string query = "select * from Institute_Details";
                DataTable dt = PopulateTree.ExecuteCommand(query);
                ddlInstitute.DataSource = dt;
                ddlInstitute.DataTextField = "InstituteName";
                ddlInstitute.DataValueField = "InstituteID";
                ddlInstitute.DataBind();
                ddlInstitute.Items.Insert(0, new ListItem("Select Institute", "NA"));
                excelgrd.Enabled = false;
            }
        }
        protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGrade.Items.Clear();
            ddlClass.Items.Clear();
            ddlClass.Items.Insert(0, new ListItem("Select", "NA"));
            string insID = ddlInstitute.SelectedValue;
            string query = "select GradeID, GradeName from Grade_Details where InsID='" + insID + "'";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlGrade.DataSource = dt;
            ddlGrade.DataTextField = "GradeName";
            ddlGrade.DataValueField = "GradeID";
            ddlGrade.DataBind();
            ddlGrade.Items.Insert(0, new ListItem("Select Grade", "NA"));
            excelgrd.Enabled = false;
            svbtn.Visible = false;
        }
        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlClass.Items.Clear();
            ddlClass.DataSource = null;
            ddlClass.DataBind();
            string gradeID = ddlGrade.SelectedValue;
            string query = "select ClassID, ClassName from Class_Details  " +
                " where GradeID='" + gradeID + "'";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassID";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("Select Class", "NA"));
            excelgrd.Enabled = false;
            svbtn.Visible = false;
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            excelgrd.Enabled = true;
            svbtn.Visible = true;
            export.Visible = true;
            BindGriddata();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "import", "importFile();", true);
        }
        private void BindGriddata()
        {
            string ClassID = ddlClass.SelectedValue;
            string query = "SELECT [StartTime] as starttime, StopTime as stoptime,[Mon]" +
                " as Monday, [Tue] as Tuesday,[Wed] as Wednesday ,[Thu] as Thursday ," +
                "[Fri] as Friday ,[Sat] as Saturday,[Sun] as Sunday, timer FROM[CresijCam].[dbo].[Schedule] "
         + " where ClassID = '" + ClassID + "' order by StartTime asc";
            DataTable dt = PopulateTree.ExecuteCommand(query);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["timer"].ToString() == "true")
                {
                    chkTimer.Checked = true;
                }
                dt.Columns.Add("Time");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Time"] = dt.Rows[i]["starttime"] + "-" + dt.Rows[i]["stoptime"];
                }
                try
                {
                    excelgrd.DataSource = dt;
                    excelgrd.DataBind();
                    ViewState["CurrentTable"] = dt;
                }
                catch (Exception ex)
                {
                    Response.Redirect("Schedule.aspx");
                }
            }
            else
            {
                try
                {
                    bindgrd();
                }
                catch (Exception ex)
                {
                    Response.Redirect("Schedule.aspx");
                }
            }
        }
        private void bindgrd()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Slno", typeof(string)));
            dt.Columns.Add(new DataColumn("Time", typeof(string)));
            dt.Columns.Add(new DataColumn("Monday", typeof(string)));
            dt.Columns.Add(new DataColumn("Tuesday", typeof(string)));
            dt.Columns.Add(new DataColumn("Wednesday", typeof(string)));
            dt.Columns.Add(new DataColumn("Thursday", typeof(string)));
            dt.Columns.Add(new DataColumn("Friday", typeof(string)));
            dt.Columns.Add(new DataColumn("Saturday", typeof(string)));
            dt.Columns.Add(new DataColumn("Sunday", typeof(string)));

            dr = dt.NewRow();
            dr["Time"] = "07:00-07:55";
            dr["Monday"] = string.Empty;
            dr["Tuesday"] = string.Empty;
            dr["Wednesday"] = string.Empty;
            dr["Thursday"] = string.Empty;
            dr["Friday"] = string.Empty;
            dr["Saturday"] = string.Empty;
            dr["Sunday"] = string.Empty;
            dt.Rows.Add(dr);

            DataRow dr1 = dt.NewRow();
            dr1["Time"] = "08:00-08:55";
            dr1["Monday"] = string.Empty;
            dr1["Tuesday"] = string.Empty;
            dr1["Wednesday"] = string.Empty;
            dr1["Thursday"] = string.Empty;
            dr1["Friday"] = string.Empty;
            dr1["Saturday"] = string.Empty;
            dr1["Sunday"] = string.Empty;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["Time"] = "09:00-09:55";
            dr2["Monday"] = string.Empty;
            dr2["Tuesday"] = string.Empty;
            dr2["Wednesday"] = string.Empty;
            dr2["Thursday"] = string.Empty;
            dr2["Friday"] = string.Empty;
            dr2["Saturday"] = string.Empty;
            dr2["Sunday"] = string.Empty;
            dt.Rows.Add(dr2);

            DataRow dr3 = dt.NewRow();
            dr3["Time"] = "10:00-10:55";
            dr3["Monday"] = string.Empty;
            dr3["Tuesday"] = string.Empty;
            dr3["Wednesday"] = string.Empty;
            dr3["Thursday"] = string.Empty;
            dr3["Friday"] = string.Empty;
            dr3["Saturday"] = string.Empty;
            dr3["Sunday"] = string.Empty;
            dt.Rows.Add(dr3);

            DataRow dr4 = dt.NewRow();
            dr4["Time"] = "11:00-11:55";
            dr4["Monday"] = string.Empty;
            dr4["Tuesday"] = string.Empty;
            dr4["Wednesday"] = string.Empty;
            dr4["Thursday"] = string.Empty;
            dr4["Friday"] = string.Empty;
            dr4["Saturday"] = string.Empty;
            dr4["Sunday"] = string.Empty;
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["Time"] = "12:00-12:55";
            dr5["Monday"] = string.Empty;
            dr5["Tuesday"] = string.Empty;
            dr5["Wednesday"] = string.Empty;
            dr5["Thursday"] = string.Empty;
            dr5["Friday"] = string.Empty;
            dr5["Saturday"] = string.Empty;
            dr5["Sunday"] = string.Empty;
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["Time"] = "13:00-13:55";
            dr6["Monday"] = string.Empty;
            dr6["Tuesday"] = string.Empty;
            dr6["Wednesday"] = string.Empty;
            dr6["Thursday"] = string.Empty;
            dr6["Friday"] = string.Empty;
            dr6["Saturday"] = string.Empty;
            dr6["Sunday"] = string.Empty;
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["Time"] = "14:00-14:55";
            dr7["Monday"] = string.Empty;
            dr7["Tuesday"] = string.Empty;
            dr7["Wednesday"] = string.Empty;
            dr7["Thursday"] = string.Empty;
            dr7["Friday"] = string.Empty;
            dr7["Saturday"] = string.Empty;
            dr7["Sunday"] = string.Empty;
            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["Time"] = "15:00-15:55";
            dr8["Monday"] = string.Empty;
            dr8["Tuesday"] = string.Empty;
            dr8["Wednesday"] = string.Empty;
            dr8["Thursday"] = string.Empty;
            dr8["Friday"] = string.Empty;
            dr8["Saturday"] = string.Empty;
            dr8["Sunday"] = string.Empty;
            dt.Rows.Add(dr8);
            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            excelgrd.DataSource = dt;
            excelgrd.DataBind();
        }
        protected void addnewrow()
        {
            //int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                try
                {
                    // SetPreviousData();
                    DataTable dt = (DataTable)excelgrd.DataSource;
                    drCurrentRow = dt.NewRow();
                    drCurrentRow["Time"] = "00:00-00:00";
                    dt.Rows.Add(drCurrentRow);
                    excelgrd.DataSource = dt;
                    excelgrd.DataBind();
                    dtCurrentTable = dt;
                    ViewState["CurrentTable"] = dtCurrentTable;
                }
                catch (Exception ex)
                {
                    BindGriddata();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "time1", "timevalue();", true);
                }
            }
            else
            {
                BindGriddata();
            }
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            DataRow drCurrentRow = null;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox txtTime = (TextBox)excelgrd.Rows[rowIndex].Cells[1].FindControl("txtTime");
                        TextBox txtMon = (TextBox)excelgrd.Rows[rowIndex].Cells[2].FindControl("txtMon");
                        TextBox txtTue = (TextBox)excelgrd.Rows[rowIndex].Cells[3].FindControl("txtTue");
                        TextBox txtWed = (TextBox)excelgrd.Rows[rowIndex].Cells[4].FindControl("txtWed");
                        TextBox txtThu = (TextBox)excelgrd.Rows[rowIndex].Cells[5].FindControl("txtThu");
                        TextBox txtFri = (TextBox)excelgrd.Rows[rowIndex].Cells[6].FindControl("txtFri");
                        TextBox txtSat = (TextBox)excelgrd.Rows[rowIndex].Cells[7].FindControl("txtSat");
                        TextBox txtSun = (TextBox)excelgrd.Rows[rowIndex].Cells[8].FindControl("txtSun");
                        txtTime.Text = dt.Rows[i]["Time"].ToString();
                        txtMon.Text = dt.Rows[i]["Monday"].ToString();
                        txtTue.Text = dt.Rows[i]["Tuesday"].ToString();
                        txtWed.Text = dt.Rows[i]["Wednesday"].ToString();
                        txtThu.Text = dt.Rows[i]["Thursday"].ToString();
                        txtFri.Text = dt.Rows[i]["Friday"].ToString();
                        txtSat.Text = dt.Rows[i]["saturday"].ToString();
                        txtSun.Text = dt.Rows[i]["Sunday"].ToString();
                        rowIndex++;
                    }
                    drCurrentRow = dt.NewRow();
                    drCurrentRow["Time"] = "00:00-00:00";
                    dt.Rows.Add(drCurrentRow);
                    excelgrd.DataSource = dt;
                    excelgrd.DataBind();
                    ViewState["CurrentTable"] = dt;
                }
            }
            else
            {
                BindGriddata();
            }
        }
        protected void svbtn_Click(object sender, EventArgs e)
        {
            string ClassID = ddlClass.SelectedValue;
            Button btn = (Button)sender;
            if (!string.IsNullOrEmpty(ClassID))
            {
                string ip = PopulateTree.getIP(ClassID);
                PopulateTree populateTree = new PopulateTree();
                populateTree.DelOldSchedule(ClassID);
                try
                {
                    string timer = "";
                    if (chkTimer.Checked == true)
                        timer = "true";
                    else
                        timer = "false";
                    foreach (GridViewRow r in excelgrd.Rows)
                    {
                        string time = (r.FindControl("txtTime") as TextBox).Text;
                        int h1 = Convert.ToInt32(time.Substring(0, 2));
                        int m1 = Convert.ToInt32(time.Substring(3, 2));
                        int h2 = Convert.ToInt32(time.Substring(6, 2));
                        int m2 = Convert.ToInt32(time.Substring(9, 2));
                        if (h1 > h2 || h1 > 23 || h2 > 23 || m1 > 59 || m2 > 59)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "time2", "timeset();", true);
                            continue;
                        }
                        if (btn.Text == "Save" && h1 == h2 && m1 == m2)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "time3", "timesetSame();", true);
                            continue;
                        }
                        string mon = (r.FindControl("txtMon") as TextBox).Text;
                        string tue = (r.FindControl("txtTue") as TextBox).Text;
                        string wed = (r.FindControl("txtWed") as TextBox).Text;
                        string thu = (r.FindControl("txtThu") as TextBox).Text;
                        string fri = (r.FindControl("txtFri") as TextBox).Text;
                        string sat = (r.FindControl("txtSat") as TextBox).Text;
                        string sun = (r.FindControl("txtSun") as TextBox).Text;
                        string starttime = time.Substring(0, 5);
                        string stoptime = time.Substring(6, 5);
                        if (string.IsNullOrEmpty(mon) && string.IsNullOrWhiteSpace(mon))
                        {
                            mon = "";
                        }
                        if (string.IsNullOrEmpty(tue) && string.IsNullOrWhiteSpace(tue))
                        {
                            tue = "";
                        }
                        if (string.IsNullOrEmpty(wed) && string.IsNullOrWhiteSpace(wed))
                        {
                            wed = "";
                        }
                        if (string.IsNullOrEmpty(thu) && string.IsNullOrWhiteSpace(thu))
                        {
                            thu = "";
                        }
                        if (string.IsNullOrEmpty(fri) && string.IsNullOrWhiteSpace(fri))
                        {
                            fri = "";
                        }
                        if (string.IsNullOrEmpty(sat) && string.IsNullOrWhiteSpace(sat))
                        {
                            sat = "";
                        }
                        if (string.IsNullOrEmpty(sun) && string.IsNullOrWhiteSpace(sun))
                        {
                            sun = "";
                        }
                        int success = populateTree.setSchedule(ip, ClassID, starttime, stoptime, timer, mon, tue, wed, thu, fri, sat, sun);
                        if (success >= 0 && btn.Text == "Save")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "AlertSuccess();", true);
                        }
                        else if (success < 0 && btn.Text == "Save")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Fail", "AlertFail();", true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "time", "timewrong();", true);
                }
                finally
                {
                    BindGriddata();
                }
            }
            if (btn.Text != "Save")
            {
                addnewrow();
            }
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            addnewrow();
        }
        protected void export_Click(object sender, EventArgs e)
        {
            excelgrd.AllowPaging = false;
            BindGriddata();
            DataTable dt1 = excelgrd.DataSource as DataTable;
            dt1.TableName = "Schedule";
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Worksheet1");
                int rowstart = 2;
                int colstart = 2;
                int rowend = rowstart;
                int colend = colstart + dt1.Columns.Count;
                ws.Cells[rowstart, colstart, rowend, colend].Merge = true;
                ws.Cells[rowstart, colstart, rowend, colend].Value = dt1.TableName;
                ws.Cells[rowstart, colstart, rowend, colend].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                ws.Cells[rowstart, colstart, rowend, colend].Style.Font.Bold = true;
                ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[rowstart, colstart, rowend, colend].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                rowstart += 2;
                rowend = rowstart + dt1.Rows.Count;
                ws.Cells[rowstart, colstart].LoadFromDataTable(dt1, false);
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                string filename = "Schedule_" + DateTime.Now.ToString("MMddyyyy") + ".xlsx";
                FileInfo excelFile = new FileInfo(Server.MapPath("~/Uploads/" + filename));
                excel.SaveAs(excelFile);
                Session["fileName"] = excelFile.FullName;
                Response.Redirect("exportdata.aspx");
            }
        }
        protected void importExcel_Click(object sender, EventArgs e)
        {
            string fileName = "";
            try
            {
                int count = 0;
                fileName = fuSample.FileName;
                string fn = fileName;
                while (File.Exists(Server.MapPath("~/Uploads/" + fn)))
                {
                    fn = Path.GetFileNameWithoutExtension(fileName);
                    fn = fn + "(" + count + ")";
                    string extension = Path.GetExtension(fileName);
                    fn = fn + extension;
                    count++;
                }
                fileName = fn;
                fuSample.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
                DataTable dt = GetDataTableFromExcel(Server.MapPath("~/Uploads/") + fileName, true);
                excelgrd.DataSource = dt;
                excelgrd.DataBind();
                if (excelgrd.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "importempty", "importEmptyFile();", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "fileformat", "fileFormat();", true);
                BindGriddata();
            }
            finally
            {
                export.Visible = true;
                if (!string.IsNullOrEmpty(fileName))
                    File.Delete(Server.MapPath("~/Uploads/") + fileName);
            }
        }
        public static DataTable GetDataTableFromExcel(string path, bool hasHeader = true)
        {
            using (var pck = new ExcelPackage())
            {
                using (var stream = File.OpenRead(path))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;


                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }


                return tbl;
            }
        }
    }
}