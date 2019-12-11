using Microsoft.AspNet.SignalR;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Mobile
{
    public partial class Control : BasePage
    {
        string[] nodenames;
        static string ipmachine="";

        TreeNode root;
        static MySqlConnection con;
        public static DataTable dtIns = new DataTable("InsDetails");
        public static DataTable dtGrade = new DataTable("GradeDetails");
        public static DataTable dtClass = new DataTable("ClassDetails");
        public DataTable dt = new DataTable();
        PopulateTree tree = new PopulateTree();
        public static string c = "";
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = HttpContext.Current.Session["UserId"].ToString();
            string roleids = HttpContext.Current.Session["role"].ToString();
            if (s != null)
            {
                if (!IsPostBack)
                {
                    if (!this.IsPostBack)
                    {
                        string ins = Resources.Resource.ResourceManager.GetString("Institutes");
                        root = new TreeNode(ins, "");
                        root.SelectAction = TreeNodeSelectAction.Expand;
                        TreeMenuView.Nodes.Add(root);
                        DataTable dt = ExecuteCommand("Select ins_name, ID, ins_id from Institute_Details order by ins_name");
                        dtIns = dt;
                        this.PopulateTreeView(dt, 0, null);
                        DefaultClass();
                        // nodenames = new string[TreeMenuView.Nodes.Count];

                    }
                    else
                    {
                        string Ip = Session["DeviceIP"].ToString();
                        CentralControl ct = new CentralControl();
                        DataTable dt1 = ct.Getlocation(Ip);
                        if (dt1.Rows.Count > 0)
                        {
                            insName.Text = dt1.Rows[0][0].ToString();
                            GradeName.Text = dt1.Rows[0][1].ToString();
                            ClassName.Text = dt1.Rows[0][2].ToString();

                        }
                    }
                }
            }
            else
            {
                Response.Redirect("../Mobile/Login.aspx");
            }
        }

        public void PopulateTreeView(DataTable dtParent, int ParentId, TreeNode treeNode)
        {
            string val;
            foreach (DataRow row in dtParent.Rows)
            {
                val = row[2].ToString();
                TreeNode child = new TreeNode
                {
                    Text = row[0].ToString(),
                    Value = row[1].ToString()
                };
                child.ToolTip = row[2].ToString();

                if (ParentId == 0)
                {
                    child.SelectAction = TreeNodeSelectAction.Expand;
                    root.ChildNodes.Add(child);
                    DataTable dtChild = ExecuteCommand("Select Grade_Name, Id,grade_id from Grade_Details where InsID  in" +
                        "(select id from `cresijdatabase`.institute_details where ins_id='" + val + "') order by Grade_Name");
                    dtGrade.Merge(dtChild);
                    PopulateTreeView(dtChild, int.Parse(child.Value), child);
                }
                else
                {
                    if (ParentId != 0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName, Id, classId from Class_Details where GradeID in" +
                            "(select id from grade_details where grade_id='" + val + "') order by ClassName");
                        dtClass.Merge(dtclass);
                        PopulateTreeView(dtclass, int.Parse(child.Value), child);
                    }
                    else
                        treeNode.ChildNodes.Add(child);
                }
            }
            TreeMenuView.ExpandDepth = 1;
        }

        public static DataTable ExecuteCommand(string Text)
        {
            DataTable dt = new DataTable();
            try
            {
                con = new MySqlConnection(constr);
                MySqlDataAdapter da = new MySqlDataAdapter(Text, con);
                //Opening Connection  
                if (con.State != ConnectionState.Open)
                    con.Open();
                //Loading all data in a datatable from datareader  
                da.Fill(dt);
                //Closing the connection  
                con.Close();
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                // throw;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        protected void TreeMenuView_SelectedNodeChanged(object sender, EventArgs e)
        {
            string devicelocations = string.Empty;
            
            if (TreeMenuView.SelectedNode.Depth == 3)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "grey", " allGrey();", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "sysgrey", " sysGrey();", true);
                HttpContext.Current.Session["LocToDisplay"] = TreeMenuView.SelectedNode.Text;
                HttpContext.Current.Session["LocForCam"] = TreeMenuView.SelectedValue;
                string ip = "";
                try
                {
                    string query = "select CCIP from CentralControl where location  = " + TreeMenuView.SelectedValue;
                    con = new MySqlConnection(constr);
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //Opening Connection  
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        ip = result.ToString();
                    }
                    HttpContext.Current.Session["DeviceIP"] = ip;
                    string Ip = Session["DeviceIP"].ToString();
                    ipmachine = ip;
                    CentralControl ct = new CentralControl();
                    DataTable dt = ct.Getlocation(Ip);
                    if (dt.Rows.Count > 0)
                    {
                        insName.Text = dt.Rows[0][0].ToString();
                        GradeName.Text =dt.Rows[0][1].ToString();
                        ClassName.Text = dt.Rows[0][2].ToString();
                        iptocam.Value = Ip;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "showdiv", "showhiddendiv();", true);
                        IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
                        hubContext.Clients.All.SendControl(Ip, "8B B9 00 03 05 01 09");
                    }
                    else
                    {
                        insName.Text = TreeMenuView.SelectedNode.Parent.Parent.Text;
                        GradeName.Text = TreeMenuView.SelectedNode.Parent.Text;
                        ClassName.Text = TreeMenuView.SelectedNode.Text;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "showdiv", "showhiddendiv();", true);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    // HttpContext.Current.Session["DeviceIP"] = ip;
                }
                finally
                {
                    con.Close();
                    TreeMenuView.CollapseAll();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "hideallins", "barclick();", true);
                    
                }
            }
            else
            {
                TreeMenuView.SelectedNode.Expand();
            }
        }

        protected void TreeMenuView_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            
            e.Node.Expand();
        }

        protected void TreeMenuView_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
        {
            e.Node.Collapse();
        }

        protected void DefaultClass()
        {
            string ip = "";
            try
            {
                string query = "select CCIP from CentralControl where location  = " + TreeMenuView.Nodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].Value;
                con = new MySqlConnection(constr);
                MySqlCommand cmd = new MySqlCommand(query, con);
                //Opening Connection  
                if (con.State != ConnectionState.Open)
                    con.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    ip = result.ToString();
                }
                HttpContext.Current.Session["DeviceIP"] = ip;
                string Ip = Session["DeviceIP"].ToString();
                ipmachine = ip;
                CentralControl ct = new CentralControl();
                DataTable dt = ct.Getlocation(Ip);
                if (dt.Rows.Count > 0)
                {
                    insName.Text = dt.Rows[0][0].ToString();
                    GradeName.Text = dt.Rows[0][1].ToString();
                    ClassName.Text = dt.Rows[0][2].ToString();
                    iptocam.Value = Ip;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "showdivdefault1", "showhiddendiv();", true);
                    IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<Hubsfile.MyHub>();
                    hubContext.Clients.All.SendControl(Ip, "8B B9 00 03 05 01 09");
                }
                else
                {
                    insName.Text = TreeMenuView.Nodes[0].ChildNodes[0].Text;
                    GradeName.Text = TreeMenuView.Nodes[0].ChildNodes[0].ChildNodes[0].Text;
                    ClassName.Text = TreeMenuView.Nodes[0].ChildNodes[0].ChildNodes[0].ChildNodes[0].Text;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "showdivdefault", "showhiddendiv();", true);
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                // HttpContext.Current.Session["DeviceIP"] = ip;
            }
            finally
            {
                con.Close();
                TreeMenuView.CollapseAll();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "hideallins1", "hidesidebar();", true);

            }            
        }
    }
}