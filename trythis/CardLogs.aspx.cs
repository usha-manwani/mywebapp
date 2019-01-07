﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;




namespace WebCresij
{
    public partial class CardLogs : System.Web.UI.Page
    {
        static SortDirection sortdirection = SortDirection.Ascending;
        
        static DataTable dt ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }
        protected void PageSize_Changed(object sender, EventArgs e)
        {
            int pagesize = Convert.ToInt32(ddlPageSize.SelectedValue);
            gv1.PageSize = pagesize;
            gv1.DataSource = dt;
            gv1.DataBind();
            int _TotalRecs = dt.Rows.Count;
            int _CurrentRecStart = gv1.PageIndex * gv1.PageSize + 1;
            int _CurrentRecEnd = gv1.PageIndex * gv1.PageSize + gv1.Rows.Count;
            lblTitle.Text = string.Format("Displaying {0} to {1} of {2} records found", _CurrentRecStart, _CurrentRecEnd, _TotalRecs);
        }
        protected void bindData()
        {
            string query = "Select cc.Name as name, cc.MemberID as memberID, rd.data as cardID, " +
                "cd.ClassName as Location,  rd.date as Time from CardRegister cc " +
                "join ReaderData rd on rd.data = cc.CardID join CentralControl ccc on " +
                "rd.Reader = ccc.CCIP join Class_Details cd on ccc.location= cd.ClassID order by cc.Name asc ";
            dt = PopulateTree.ExecuteCommand(query);
            gv1.DataSource = dt;
            dt.TableName = "cardLogs";
            gv1.DataBind();
            int _TotalRecs = dt.Rows.Count;
            int _CurrentRecStart = gv1.PageIndex * gv1.PageSize + 1;
            int _CurrentRecEnd = gv1.PageIndex * gv1.PageSize + gv1.Rows.Count;

            lblTitle.Text = string.Format("Displaying {0} to {1} of {2} records found", _CurrentRecStart, _CurrentRecEnd, _TotalRecs);
        }

        protected void gv1_Sorting(object sender, GridViewSortEventArgs e)
        {
            bindData();
            DataTable dtSortTable = dt;
            if (dtSortTable != null)
            {
                DataView sortedView = new DataView(dtSortTable);
                DataTable dt1 = new DataTable();
                {
                    string SortDir = string.Empty;
                    if (dir == SortDirection.Ascending)
                    {
                        dir = SortDirection.Descending;
                        SortDir = "Desc";
                        btnAsc.Text = "<i class=\"fa fa-sort-alpha-up\"></i>";
                    }
                    else
                    {
                        dir = SortDirection.Ascending;
                        SortDir = "Asc";
                        btnAsc.Text = "<i class=\"fa fa-sort-alpha-down\"></i>";
                    }
                    if (e.SortExpression == "Time")
                    {
                        
                        string query = "Select cc.Name as name, cc.MemberID as memberID, rd.data as cardID, " +
                       "cd.ClassName as Location,  rd.date as Time from CardRegister cc " +
                       "join ReaderData rd on rd.data = cc.CardID join CentralControl ccc on " +
                       "rd.Reader = ccc.CCIP join Class_Details cd on ccc.location= cd.ClassID order by rd.date " + SortDir;
                        dt = PopulateTree.ExecuteCommand(query);
                        gv1.DataSource = dt;
                        gv1.DataBind();
                    }
                    else
                    {
                        sortedView.Sort = e.SortExpression + " " + SortDir;
                        dt = sortedView.ToTable();
                        gv1.DataSource = dt;
                        gv1.DataBind();
                    }

                }
            }
        }
        public SortDirection dir
        {
            get
            {
                if (ViewState["dirState"] == null)
                {
                    ViewState["dirState"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["dirState"];
            }
            set
            {
                ViewState["dirState"] = value;
            }
        }
        protected void ddlsort_SelectedIndexChanged(object sender, EventArgs e)
        {
            gv1.Sort(ddlsort.SelectedValue, SortDirection.Ascending);
        }
        protected void btnAsc_Click(object sender, EventArgs e)
        {
            sortdirection = SortDirection.Ascending;
            gv1.Sort(ddlsort.SelectedValue, sortdirection);
        }

        protected void gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv1.PageIndex = e.NewPageIndex;
            ViewState["pageindex"] = e.NewPageIndex;
            gv1.DataSource = dt;
            gv1.DataBind();
            int _TotalRecs = dt.Rows.Count;
            int _CurrentRecStart = gv1.PageIndex * gv1.PageSize + 1;
            int _CurrentRecEnd = gv1.PageIndex * gv1.PageSize + gv1.Rows.Count;

            lblTitle.Text = string.Format("Displaying {0} to {1} of {2} records found", _CurrentRecStart, _CurrentRecEnd, _TotalRecs);
        }
       
        protected void exportexcel_Click(object sender, EventArgs e)
        {
            gv1.AllowPaging = false;
            bindData();
            DataTable dt1 = gv1.DataSource as DataTable;
            
            dt1.Columns.Add("Date & Time");
            for (int k = 0; k < dt1.Rows.Count; k++)
            {
                dt1.Rows[k]["Date & Time"] = dt.Rows[k]["Time"].ToString();
            }
            dt1.Columns.Remove("Time");
            dt1.TableName = "CardLogs";
            
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
                    ws.Cells[rowstart, colstart].LoadFromDataTable(dt1, true);
                   
                    
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();
                    ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                       ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                       ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                       ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    string filename = "logs_" + DateTime.Now.ToString("MMddyyyy") + ".xlsx";
                    FileInfo excelFile = new FileInfo(Server.MapPath("~/Uploads/" + filename));
                    excel.SaveAs(excelFile);
                    Session["fileName"] = excelFile.FullName;
                    Response.Redirect("exportdata.aspx");             
                }           
        }       
    }
}