using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    public partial class editDelCard : BasePage
    {
        static List<KeyValuePair<string, string>> idsloc = new List<KeyValuePair<string, string>>();        
        IHubContext hubContext;
        string nodesval = "";
        DataSet ds = new DataSet();
        static int selectindex = 0;
        static DataTable dtSearch = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
                PopulateTree populateTree = new PopulateTree();
                populateTree.fill(TreeView1);
            }
        }

        private void bindData()
        {
            string query = "select * from Card_register";
            ds = PopulateTree.GetDataSet(query);
            dtSearch = ds.Tables[0];
            gvCard.DataSource = ds;
            gvCard.DataBind();
        }

        protected void gvCard_Sorting(object sender, GridViewSortEventArgs e)
        {
            bindData();
            DataTable dt = new DataTable();

            dt = ds.Tables[0];
            {
                string SortDir = string.Empty;
                if (dir == SortDirection.Ascending)
                {
                    dir = SortDirection.Descending;
                    SortDir = "Desc";
                }
                else
                {
                    dir = SortDirection.Ascending;
                    SortDir = "Asc";
                }
                DataView sortedView = new DataView(dt);
                sortedView.Sort = e.SortExpression + " " + SortDir;
                gvCard.DataSource = sortedView;
                gvCard.DataBind();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dtSearch.Select("", "");
        }

        protected void gvCard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCard.PageIndex = e.NewPageIndex;
            bindData();
        }

        protected void gvCard_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cardID = gvCard.DataKeys[e.RowIndex].Values["CardID"].ToString();
            string locid = gvCard.DataKeys[e.RowIndex].Values["locids"].ToString();
            string[] locations = locid.Split(',');
            byte[] datacard = Hubsfile.HexEncoding.GetBytes(cardID, out int d);
            string c = "";

            for (int j = 0; j < cardID.Length;)
            {
                c = c + cardID.Substring(j, 2) + " ";
                j = j + 2;
            }
            hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
            int checksum = 11;
            for (int k = 0; k < datacard.Length; k++)
            {
                checksum = checksum + datacard[k];
            }
            checksum = checksum & Convert.ToByte(0XFF);
            string data = "8B B9 00 07 01 03 " + c + checksum.ToString("X2");
            foreach (string loc in locations)
            {
                string ip = PopulateTree.getIP(loc);
                if (!string.IsNullOrEmpty(ip) && ip != "-1")
                {
                    hubContext.Clients.All.SendControl(ip, data);
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;

            if (gvr.RowType == DataControlRowType.DataRow)
            {
                string Name = (gvr.FindControl("hidlocID") as Label).Text;
                if (Name != null)
                {

                    string cardID = gvr.Cells[3].Text;
                    string[] ipsloc = Name.Split(',');

                    if (ipsloc.Length > 0)
                    {
                        string c = "";
                        int checksum = 9;
                        hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
                        byte[] datacard = Hubsfile.HexEncoding.GetBytes(cardID, out int d);
                        for (int j = 0; j < cardID.Length;)
                        {
                            c = c + cardID.Substring(j, 2) + " ";
                            j = j + 2;
                        }
                        for (int k = 0; k < datacard.Length; k++)
                        {
                            checksum = checksum + datacard[k];
                        }
                        checksum = checksum & Convert.ToByte(0XFF);
                        string data = "8B B9 00 07 01 01 " + c + checksum.ToString("X2");
                        foreach (string loc in ipsloc)
                        {
                            string ip = PopulateTree.getIP(loc);
                            if (!string.IsNullOrEmpty(ip) && ip != "-1")
                            {
                                hubContext.Clients.All.SendControl(ip, data);
                            }

                        }
                    }
                }
            }
        }

        protected void txtloc_TextChanged(object sender, EventArgs e)
        {
            DataTable temp = dtSearch.Clone();
            string search= txtloc.Text.Trim();
            if (!string.IsNullOrEmpty(search))
            {
                string cond = "memberID LIKE '%" + search + "%' or Name LIKE '%" 
                    + search + "%' or CardID LIKE '%" + search + "%'";
                DataRow[] dataRows;
                dataRows = dtSearch.Select(cond);
                try
                {
                    foreach (DataRow dr in dataRows)
                    {
                        temp.ImportRow(dr);
                    }
                }
                catch (Exception ex)
                {
                    gvCard.DataSource = dtSearch;
                    gvCard.DataBind();
                }
                gvCard.DataSource = temp;
                gvCard.DataBind();
            }
            else
            {
                gvCard.DataSource = dtSearch;
                gvCard.DataBind();
            }
            
        }

        protected void gvCard_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCard.EditIndex = -1;
            bindData();
        }

        protected void gvCard_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCard.EditIndex = e.NewEditIndex;
            bindData();
        }

        protected void gvCard_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvCard.Rows[e.RowIndex];           
            if (e.RowIndex > -1)
            {
                PopulateTree tree = new PopulateTree();
                string cardID = row.Cells[3].Text;
                string memid = (row.Cells[1].Controls[0] as TextBox).Text;
                string name = (row.Cells[2].Controls[0] as TextBox).Text;
                string loc = row.Cells[5].Text;
                string pending = row.Cells[6].Text;
                string comment = (row.Cells[7].Controls[0] as TextBox).Text;
                string locid = (row.FindControl("hidlocID") as Label).Text;
                int result = tree.UpdateRegCard(cardID,name,memid,loc,comment,pending, locid);
                UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                HttpContext.Current.Session["UserName"].ToString(), 10);
                gvCard.EditIndex = -1;
                bindData();
            }
        }

        protected void openaccess_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lb.NamingContainer;
            if (row != null)
            {
                selectindex = row.RowIndex; //gets the row index selected
            }           
        }

        protected void addAccess_Click(object sender, EventArgs e)
        {
            string nodes = "";
            if (TreeView1.CheckedNodes.Count > 0)
            {
                int i = 0;
                foreach (TreeNode node in TreeView1.CheckedNodes)
                {
                    if (node.Depth == 2)
                    {
                        nodes = nodes + node.Text + ", ";
                        nodesval = nodesval + node.ToolTip + ",";
                        idsloc.Add(new KeyValuePair<string, string>(gvCard.Rows[selectindex].Cells[3].Text, node.ToolTip));
                    }
                    i++;
                }
                nodesval = nodesval.Substring(0, nodesval.Length - 1);                
                gvCard.Rows[selectindex].Cells[6].Text = nodes;
                (gvCard.Rows[selectindex].FindControl("hidlocID") as Label).Text = nodesval;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MyKey2", "HideTree();", true);
                updatecards();               
            }            
        }

        protected void updatecards()
        {
            GridViewRow row = gvCard.Rows[selectindex];
            PopulateTree tree = new PopulateTree();
            string cardID = row.Cells[3].Text;
            string memid = row.Cells[1].Text;
            string name = row.Cells[2].Text;
            string loc = "";
            string pending = row.Cells[6].Text;
            string comment = row.Cells[7].Text;
            string locid = (row.FindControl("hidlocID") as Label).Text;            
            int result = tree.UpdateRegCard(cardID, name, memid, loc, comment, pending,locid);
            if (result == 1)
            {
                string Name = (row.FindControl("hidlocID") as Label).Text;
                if (Name != null)
                {                   
                    string[] ipsloc = Name.Split(',');
                    if (ipsloc.Length > 0)
                    {
                        string c = "";
                        int checksum = 9;
                        hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
                        byte[] datacard = Hubsfile.HexEncoding.GetBytes(cardID, out int d);
                        for (int j = 0; j < cardID.Length;)
                        {
                            c = c + cardID.Substring(j, 2) + " ";
                            j = j + 2;
                        }
                        for (int k = 0; k < datacard.Length; k++)
                        {
                            checksum = checksum + datacard[k];
                        }
                        checksum = checksum & Convert.ToByte(0XFF);
                        string data = "8B B9 00 07 01 01 " + c + checksum.ToString("X2");
                        foreach (string loc1 in ipsloc)
                        {
                            string ip = PopulateTree.getIP(loc1);
                            if (!string.IsNullOrEmpty(ip) && ip != "-1")
                            {
                                hubContext.Clients.All.SendControl(ip, data);
                            }

                        }
                    }
                }
            }
            bindData();
        }
    }
}