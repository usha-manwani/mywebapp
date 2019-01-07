using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij
{
    
    public partial class CardReader : System.Web.UI.Page
    {
        string nodesval = "";
        
        PopulateTree pp = new PopulateTree();
        DataTable _dt = new DataTable();
        DataTable _dtInstitute = new DataTable();
        static int selectindex = 0;
        private const int _firstEditCellIndex = 2;
        static Dictionary<int, string> valuePairs = new Dictionary<int, string>();
        static Dictionary<string, string> cardtoregister = new Dictionary<string, string>();
        static List<KeyValuePair<string, string>> idsloc = new List<KeyValuePair<string, string>>();
        
        IHubContext hubContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                string query = "select * from Institute_Details";
                _dtInstitute = PopulateTree.ExecuteCommand(query);
                PopulateTree populateTree = new PopulateTree();
                populateTree.fill(TreeView1);
                //GridViewSource();
            }
            if (this.GridView1.SelectedIndex > -1)
            {
                // Call UpdateRow on every postback
                this.GridView1.UpdateRow(this.GridView1.SelectedIndex, false);
            }
        }        
        //public void GridViewSource()
        //{
        //    //DataTable dt = pp.tempcard();
        //    //if (dt.Rows.Count == 0)
        //    //{
        //    //    DataRow dr = dt.NewRow();
        //    //    dt.Rows.Add(dr);
        //    //}
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Sno", typeof(string));
        //    dt.Columns.Add("name", typeof(string));
        //    dt.Columns.Add("memberID", typeof(string));
        //    dt.Columns.Add("cardID", typeof(string));
        //    dt.Columns.Add("comment", typeof(string));
        //    dt.Columns.Add("state", typeof(string));
        //    dt.Columns.Add("Access", typeof(string));
        //    dt.Columns.Add("SelectAccess", typeof(string));
        //    DataRow dr = null;
        //    dr = dt.NewRow();
        //    DataRow dr1 = dt.NewRow();
        //    DataRow dr2 = dt.NewRow();
        //    DataRow dr3 = dt.NewRow();
        //    DataRow dr4 = dt.NewRow();
        //    dt.Rows.Add(dr);
        //    dt.Rows.Add(dr1);
        //    dt.Rows.Add(dr2);
        //    dt.Rows.Add(dr3);
        //    dt.Rows.Add(dr4);
        //    for(int i=0; i<5; i++)
        //    {
        //        dt.Rows[i][0] = i+1;
        //    }
        //    ViewState["_data"] = dt;
        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //    //cardscans.RemoveRange(0, cardscans.Count - 1); 
            
        //}
        
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            _dt.Columns.Add("sno", typeof(int));
            _dt.Columns.Add("memIDs", typeof(string));
            _dt.Columns.Add("name", typeof(string));
            _dt.Columns.Add("cardIds", typeof(string));
            _dt.Columns.Add("comments", typeof(string));
            _dt.Columns.Add("states", typeof(string));
            _dt.Columns.Add("access", typeof(string));
            string[] SerialNo = Request.Form.GetValues("txtSno");
            string[] memberID = Request.Form.GetValues("memID");
            string[] names = Request.Form.GetValues("txtname");
            string[] cardIDs = Request.Form.GetValues("txtCard");
            string[] comments = Request.Form.GetValues("txtcom");
            int counter = -1;
            for(int i=0; i < cardIDs.Length; i++)
            {
                int p = -1;
                if (!string.IsNullOrEmpty(names[i]))
                {
                    p = pp.inserTempCard(SerialNo[i], memberID[i], names[i], cardIDs[i], comments[i]);
                    if (p == 1)
                    {
                        counter = counter + 1;
                        DataRow dr = _dt.NewRow();
                        _dt.Rows.Add(dr);
                        _dt.Rows[counter][0] = SerialNo[i];
                        _dt.Rows[counter][1] = memberID[i];
                        _dt.Rows[counter][2] = names[i];
                        _dt.Rows[counter][3] = cardIDs[i];
                        _dt.Rows[counter][4] = comments[i];
                        _dt.Rows[counter][5] = "Unregistered";
                        _dt.Rows[counter][6] = "--";
                    }
                }               
            }
            if (_dt.Rows.Count > 0)
            {
                GridView1.DataSource = _dt;
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MyKey", "showGrid();", true);
            }
            else
            {
                info.Text = "The card(s) you have scanned might have already registered!! Please check and scan again.";
            }
           
            
        }
        //access to cards
        protected void addAccess_Click(object sender, EventArgs e)
        { 
            string nodes="";
            if (TreeView1.CheckedNodes.Count > 0)
            {                
                int i = 0;
                foreach (TreeNode node in TreeView1.CheckedNodes)
                {
                    if (node.Depth==2)
                    {
                        nodes = nodes + node.Text + ", ";
                        nodesval = nodesval + node.ToolTip + ",";
                        idsloc.Add(new KeyValuePair<string, string>(GridView1.Rows[selectindex].Cells[3].Text, node.ToolTip));
                    }                
                    i++;     
                }                
                nodesval = nodesval.Substring(0, nodesval.Length - 1);
                cardtoregister.Add(GridView1.Rows[selectindex].Cells[3].Text, nodesval);
                GridView1.Rows[selectindex].Cells[6].Text = nodes;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "MyKey2", "HideTree();", true);
            }            
        }
        protected void TreeView1_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            string[] nodes = new string[TreeView1.CheckedNodes.Count];
            int i = 0;
            foreach (TreeNode node in TreeView1.CheckedNodes)
            {
                nodes[i] = node.Text.ToString();
                i++;
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
            PopulateTree tree = new PopulateTree();
            string access = "";
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string locs = "";
                if (cardtoregister.ContainsKey(GridView1.Rows[i].Cells[3].Text))
                {
                    cardtoregister.TryGetValue(GridView1.Rows[i].Cells[3].Text, out string loc);
                    locs = loc;
                }
                int result = tree.regcard(GridView1.Rows[i].Cells[0].Text, GridView1.Rows[i].Cells[1].Text, GridView1.Rows[i].Cells[2].Text, GridView1.Rows[i].Cells[3].Text, GridView1.Rows[i].Cells[4].Text, GridView1.Rows[i].Cells[5].Text, access, GridView1.Rows[i].Cells[6].Text,locs);
                if (result == 1)
                {
                    foreach (KeyValuePair<string, string> keyValue in idsloc)
                    {
                        if (keyValue.Key == GridView1.Rows[i].Cells[3].Text)
                        {
                            string ip = PopulateTree.getIP(keyValue.Value);
                            if (!string.IsNullOrEmpty(ip) && ip!="-1")
                            {
                            string cardbytes = keyValue.Key;
                            string c = "";
                            int checksum = 9;
                            byte[] datacard = Hubsfile.HexEncoding.GetBytes(keyValue.Key, out int d);
                            for (int j = 0; j < cardbytes.Length;)
                            {
                                c = c + cardbytes.Substring(j, 2) + " ";
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
            GridView1.DataSource = null;
            GridView1.DataBind();
            valuePairs.Clear();
            idsloc.Clear();
            nodesval = "";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyKey1", "hideGrid();", true);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            PopulateTree.ExecuteCommand("delete from tempCardRegister");
            GridView1.DataSource = null;
            GridView1.DataBind();
            valuePairs.Clear();
            idsloc.Clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "MyKey3", "xx();", true);
        }
        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{

        //    int i = e.NewEditIndex;
        //    Label card = (Label)GridView1.Rows[e.NewEditIndex].FindControl("cardID");
        //    Label states = (Label)GridView1.Rows[e.NewEditIndex].FindControl("state");

        //    //List<CardData> cardscans = HttpContext.Current.Session["myCardList"] as List<CardData>;
        //    //card.Text = cardscans[i].cardids;
        //    //states.Text = cardscans[1].state;
        //    GridView1.EditIndex = e.NewEditIndex;

        //    GridView1.DataSource = (DataTable)ViewState["_data"];
        //    GridView1.DataBind();
        //}

        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int i = e.RowIndex;
        //    TextBox txtsno = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Sno");
        //    TextBox txtname = (TextBox)GridView1.Rows[e.RowIndex].FindControl("name");
        //    TextBox txtmember = (TextBox)GridView1.Rows[e.RowIndex].FindControl("MemberID");
        //    TextBox txtcomment = (TextBox)GridView1.Rows[e.RowIndex].FindControl("comment");
        //    Label card = (Label)GridView1.Rows[e.RowIndex].FindControl("cardID");
        //    Label states = (Label)GridView1.Rows[e.RowIndex].FindControl("state");
        //    Label access = (Label)GridView1.Rows[e.RowIndex].FindControl("Access");



        //    GridView1.EditIndex = -1;
        //   // updatingData(i, txtsno.Text, txtname.Text,txtmember.Text,txtcomment.Text,card.Text,states.Text,access.Text);


        //}

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{            
        //}

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;            
        //    GridView1.DataSource = (DataTable)ViewState["_data"];
        //    GridView1.DataBind();
        //}
    }
    }