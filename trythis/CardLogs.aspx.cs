using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trythis
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
                        gv1.DataSource = sortedView;
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
    }
}