using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trythis
{
    public partial class editDelCard : System.Web.UI.Page
    {
        IHubContext hubContext;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindData();
            }
        }

        private void bindData()
        {
            
            string query = "select * from CardRegister";
            ds = PopulateTree.GetDataSet(query);
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
                if(!string.IsNullOrEmpty(ip) && ip!="-1" )
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
                     
                    string cardID = (gvr.FindControl("cardId") as Label).Text;
                    string[] ipsloc = Name.Split(',');

                    if (ipsloc.Length > 0)
                    {
                        foreach (string loc in ipsloc)
                        {
                            string ip = PopulateTree.getIP(loc);
                            if (!string.IsNullOrEmpty(ip) && ip != "-1")
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
                                hubContext.Clients.All.SendControl(ip, data);
                            }
                           
                        }
                    }
                }
               
            }
        }

        protected void txtloc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}