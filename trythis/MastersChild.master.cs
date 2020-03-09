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
        //TreeNode root = new TreeNode("莱阳卫校"); 
        TreeNode root = new TreeNode(Resources.Resource.Institutes);
        static MySqlConnection con;
        public static DataTable dtIns = new DataTable("InsDetails");
        public static DataTable dtGrade = new DataTable("GradeDetails");
        public static DataTable dtClass = new DataTable("ClassDetails");
        public DataTable dt = new DataTable();
        PopulateTree tree = new PopulateTree();
        
        // static DataTable dt = new DataTable();
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings
            ["CresijCamConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                root.SelectAction = TreeNodeSelectAction.Expand;               
                TreeMenuView.Nodes.Add(root);
                DataTable dt = ExecuteCommand("Select ins_name, ID, ins_id from Institute_Details order by ins_name");
                dtIns = dt;
                this.PopulateTreeView(dt, 0, null);
                nodenames = new string[TreeMenuView.Nodes.Count];
                TreeviewHelper.RestoreTreeViewStateFromSession(TreeMenuView);
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
            catch(Exception ex)
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
            TreeviewHelper.StoreTreeViewStateToSession((TreeView)sender);
            // TreeNode t = (TreeNode)sender;
            string devicelocations = string.Empty;
            if (TreeMenuView.SelectedNode.Depth == 2)
            {
                HttpContext.Current.Session["GradeName"] = TreeMenuView.SelectedNode.Text;
                HttpContext.Current.Session["InstituteID"] = TreeMenuView.SelectedNode.Parent.Text;
                DataTable dt = ExecuteCommand("select cd.ClassName as loc ,cc.ccip as ip from " +
                    "CentralControl cc join Class_Details cd on cd.ID=cc.location where cd.GradeID='"
                    + TreeMenuView.SelectedNode.Value + "' order by cd.ClassName");
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
                    #pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex){}
                        #pragma warning restore CS0168 // The variable 'ex' is declared but never used
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
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
    }

    public static class TreeviewHelper
    {
        private static string strVarName="";
        public static void RestoreTreeViewStateFromSession(TreeView tvIn)
        {
            // Takes the Session-stored TreeView state and restores it
            // to the passed-in TreeView control.
            // Call this method on entry to the page.  Nothing will
            // happen if the variable doesn't exist.
            //string strVarName;
            // See if stored data exists for this treeview
            //strVarName = "tv_" + HttpContext.Current.Request.ServerVariables["path_info"];

            //if(strVarName.ToUpper() == "TV_/HOMEPAGE" || strVarName.ToUpper() =="TV_/CONTROL" || strVarName.ToUpper() == "TV_/HOME")
            //{
            if (HttpContext.Current.Session[strVarName] + "" != "")
            {
                string strSelectedNodeIndex = "";
                foreach (string strCurrent in HttpContext.Current.Session[strVarName].ToString().Split(','))
                {
                    if (strSelectedNodeIndex == "") // First element in list is selected node
                    {
                        strSelectedNodeIndex = strCurrent;
                    }
                    else
                    {
                        try
                        {
                            tvIn.FindNode(strCurrent).Expanded = true;
                        }
                        catch (Exception ex)
                        {
                            //eat exception
                        }
                    }
                }
                try
                {
                    // Verify that node exists before setting SelectedNodeIndex
                    TreeNode tnTest = tvIn.FindNode(strSelectedNodeIndex);
                    // Select the node (will only happen if it exists)
                    tvIn.FindNode(strSelectedNodeIndex).Select();
                    // Ensure the selected node's parent is expanded
                    tvIn.FindNode(tvIn.SelectedNode.ValuePath).Parent.Expanded = true;
                }
                catch (Exception ex)
                {
                    // eat exception
                }
            }
            //}
            HttpContext.Current.Session.Remove(strVarName);
        }

        public static void StoreTreeViewStateToSession(TreeView tvIn)
        {
            // Takes the TreeView's state and saves it in a Session variable
            // Call this method before leaving the page if we expect to be back
            //string strVarName;
            string strList = "";            
            strVarName = "tv_" + HttpContext.Current.Request.ServerVariables["path_info"];
            if (HttpContext.Current.Session[strVarName] + "" != "")
            {
                HttpContext.Current.Session.Remove(strVarName);
            }
            StoreTreeViewStateToSession_Recurse(tvIn.Nodes[0], ref strList);
            strList = tvIn.SelectedNode.ValuePath + strList;
           
            HttpContext.Current.Session.Add(strVarName, strList);
        }
        private static void StoreTreeViewStateToSession_Recurse(TreeNode tnIn, ref string strList)
        {
            if (tnIn.Expanded == true)
            {
                strList = "," + tnIn.ValuePath + strList;
            }
            foreach (TreeNode tnCurrent in tnIn.ChildNodes)
            {
                StoreTreeViewStateToSession_Recurse(tnCurrent, ref strList);
            }
        }
    }
}