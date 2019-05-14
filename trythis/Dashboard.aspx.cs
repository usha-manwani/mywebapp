using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class Dashboard : System.Web.UI.Page
    {
        static DataTable dt = new DataTable();
        static SortDirection sortdirection = SortDirection.Ascending;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }
        protected void Gv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv1.PageIndex = e.NewPageIndex;
            BindData();
        }

        private void BindData()
        {
            dt = UserActivities.UserLogs.LogsRecord();
            gv1.DataSource = dt;
            gv1.DataBind();
            userNo.Text = UserActivities.UserLogs.CurrentUser().ToString();
            totalUser.Text = UserActivities.UserLogs.TotalUser().ToString();
        }
        protected void Gv1_Sorting(object sender, GridViewSortEventArgs e)
        {
            BindData();
            DataTable dtSortTable = dt;
            if (dtSortTable != null)
            {
                DataView sortedView = new DataView(dtSortTable);
                DataTable dt1 = new DataTable();
                {
                    string SortDir = string.Empty;
                    if (Dir == SortDirection.Ascending)
                    {
                        Dir = SortDirection.Descending;
                        SortDir = "Desc";
                        btnAsc.Text = "<i class=\"fa fa-sort-alpha-up\"></i>";
                    }
                    else
                    {
                        Dir = SortDirection.Ascending;
                        SortDir = "Asc";
                        btnAsc.Text = "<i class=\"fa fa-sort-alpha-down\"></i>";
                    }
                    if (e.SortExpression == "Time")
                    {

                        dt = UserActivities.UserLogs.LogsRecord();
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
        public SortDirection Dir
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
        protected void Ddlsort_SelectedIndexChanged(object sender, EventArgs e)
        {
            gv1.Sort(ddlsort.SelectedValue, SortDirection.Ascending);
        }
        protected void BtnAsc_Click(object sender, EventArgs e)
        {
            sortdirection = SortDirection.Ascending;
            gv1.Sort(ddlsort.SelectedValue, sortdirection);
        }
    }
}