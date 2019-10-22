using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebCresij
{
    public partial class MastersChild : MasterPage
    {
        string[] nodenames;
        //int i = 0;
        // public event EventHandler selected;
        //int role = Convert.ToInt32(HttpContext.Current.Session["role"]);
        TreeNode root = new TreeNode(Resources.Resource.Institutes);        
        static MySqlConnection con;
        public static DataTable dtIns = new DataTable("InsDetails");
        public static DataTable dtGrade = new DataTable("GradeDetails");
        public static DataTable dtClass = new DataTable("ClassDetails");
        public DataTable dt = new DataTable();
        PopulateTree tree = new PopulateTree();
        public static string c = "";
        // static DataTable dt = new DataTable();
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                root.SelectAction = TreeNodeSelectAction.Expand;               
                TreeMenuView.Nodes.Add(root);
                DataTable dt = ExecuteCommand("Select ins_name, ID, ins_id from Institute_Details order by ins_name");
                dtIns = dt;
                this.PopulateTreeView(dt, 0, null);
                nodenames = new string[TreeMenuView.Nodes.Count];
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
                    if (ParentId !=0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName, Id, classId from Class_Details where GradeID in"+
                            "(select id from grade_details where grade_id='" + val + "') order by ClassName");
                        dtClass.Merge(dtclass);                        
                        PopulateTreeView(dtclass, int.Parse(child.Value), child);
                    }
                    else
                        treeNode.ChildNodes.Add(child);
                }
            }
            TreeMenuView.ExpandDepth = 3;
        }

        public static DataTable ExecuteCommand(string Text)
        {
            try
            {
                con = new MySqlConnection(constr);
                MySqlDataAdapter da = new MySqlDataAdapter(Text, con);

                //Opening Connection  
                if (con.State != ConnectionState.Open)
                    con.Open();

                DataTable dt = new DataTable();
                //Loading all data in a datatable from datareader  
                da.Fill(dt);
                //Closing the connection  
                con.Close();
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        protected void TreeMenuView_SelectedNodeChanged(object sender, EventArgs e)
        {
            string devicelocations = string.Empty;
            if (TreeMenuView.SelectedNode.Depth == 2)
            {
                HttpContext.Current.Session["GradeName"] = TreeMenuView.SelectedNode.Text;
                HttpContext.Current.Session["InstituteID"] = TreeMenuView.SelectedNode.Parent.Text;
                DataTable dt = ExecuteCommand("select cd.ClassName as loc ,cc.ccip as ip from CentralControl cc join Class_Details cd on cd.ID=cc.location where cd.GradeID='" + TreeMenuView.SelectedNode.Value + "' order by cd.ClassName");
                if (dt.Rows.Count > 0)
                {
                    string[] deviceloc = new string[dt.Rows.Count];
                    Dictionary<string, string> ipsloc = new Dictionary<string, string>();
                    try
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            devicelocations = devicelocations + row[1].ToString() + ":" + row[0].ToString() + ",";
                            ipsloc.Add(row[1].ToString(), row[0].ToString());
                        }
                    }
                    catch (Exception ex){}
                    for (int i = 0; i < deviceloc.Length; i++)
                    {
                        deviceloc[i] = dt.Rows[i][1].ToString() + "," + dt.Rows[i][0].ToString();
                    }
                    devicelocations = devicelocations.Substring(0, devicelocations.Length - 1);
                    HttpContext.Current.Session["iploc"] = ipsloc;
                    HttpContext.Current.Session["deviceloc"] = deviceloc;
                    HttpContext.Current.Session["devices"] = devicelocations;
                }
                else
                {
                    HttpContext.Current.Session["devices"] = devicelocations;
                }
                Response.Redirect("~/Control.aspx");
            }
            if (TreeMenuView.SelectedNode.Depth == 3)
            {
                HttpContext.Current.Session["LocToDisplay"] = TreeMenuView.SelectedNode.Text;
                HttpContext.Current.Session["LocForCam"] = TreeMenuView.SelectedValue;
                string ip = "";
                try
                {
                    string query = "select CCIP from CentralControl where location  = " + TreeMenuView.SelectedValue ;
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
                }
                catch(Exception ex)
                {
                   // HttpContext.Current.Session["DeviceIP"] = ip;
                }
                finally
                {
                    con.Close();
                    Response.Redirect("~/HomePage.aspx");
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
    }
}