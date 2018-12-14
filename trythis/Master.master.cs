using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trythis
{
    public partial class Master : System.Web.UI.MasterPage
    {
        string[] nodenames;
        int i = 0;
        public event EventHandler selected;
        //int role = Convert.ToInt32(HttpContext.Current.Session["role"]);
        TreeNode root = new TreeNode("Institutes");
        static SqlConnection con;
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
                TreeMenuView.Nodes.Add(root);
                DataTable dt = ExecuteCommand("Select InstituteName, ID, InstituteID from Institute_Details");
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
                    root.ChildNodes.Add(child);

                    DataTable dtChild = ExecuteCommand("Select GradeName, Id, GradeID from Grade_Details where InsID ='" + val + "'");
                    dtGrade.Merge(dtChild);
                    PopulateTreeView(dtChild, int.Parse(child.Value), child);
                }
                //else
                //{
                //    if (ParentId != 0)
                //    {
                //        treeNode.ChildNodes.Add(child);
                //        DataTable dtclass = ExecuteCommand("Select ClassName, Id,ClassID from Class_Details where GradeID='" + val + "'");
                //        dtClass.Merge(dtclass);
                //        if (dtclass.Rows.Count == 0)
                //        {
                //            tree.cam(TreeMenuView, val, child);
                //        }
                //        PopulateTreeView(dtclass, int.Parse(child.Value), child);
                //    }
                    else
                        treeNode.ChildNodes.Add(child);
                //}
            }
            TreeMenuView.CollapseAll();
        }

        public static DataTable ExecuteCommand(string Text)
        {
            try
            {
                con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter(Text, con);

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
              DataTable dt=  ExecuteCommand("select cd.ClassName as loc ,cc.CCIP as ip from CentralControl cc join Class_Details cd on cd.ClassID=cc.location where cd.GradeID='" + TreeMenuView.SelectedNode.ToolTip + "'");
                if (dt.Rows.Count > 0)
                {
                   
                    string[] deviceloc = new string[dt.Rows.Count];
                    Dictionary<string, string> ipsloc = new Dictionary<string, string>();
                    foreach(DataRow row in dt.Rows)
                    {
                        devicelocations = devicelocations+ row[1].ToString() + ":" + row[0].ToString() + ",";
                        ipsloc.Add(row[1].ToString(), row[0].ToString());
                    }
                    for(int i = 0; i < deviceloc.Length; i++)
                    {
                        deviceloc[i]= dt.Rows[i][1].ToString()+","+dt.Rows[i][0].ToString();
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
            //if (TreeMenuView.SelectedNode.Depth == 5)
            //{
            //    c = TreeMenuView.SelectedValue.ToString();
            //    if (TreeMenuView.SelectedNode.Parent.Value == "Camera")
            //    {

            //    }
            //    else if (TreeMenuView.SelectedNode.Parent.Value == "Multimedia")
            //    {
            //        HttpContext.Current.Session["DeviceIP"] = c;
            //        HttpContext.Current.Session["loc"] = TreeMenuView.SelectedNode.Parent.Parent.Text;
            //        Response.Redirect("~/Control.aspx");
            //    }

            //    if (selected != null)
            //    {
            //        selected(this, EventArgs.Empty);
            //    }
            //}
            else
            {
                TreeMenuView.SelectedNode.Expand();
            }




            //this.TreeMenuView.SelectedNode.Selected = false;
        }

    }

}