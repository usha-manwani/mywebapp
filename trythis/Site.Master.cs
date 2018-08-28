using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace trythis
{
   
    public partial class SiteMaster : MasterPage
    {
        
        public event EventHandler selected;
        //int role = Convert.ToInt32(HttpContext.Current.Session["role"]);
        TreeNode root = new TreeNode("Institutes");
        static SqlConnection con;
        public static DataTable dtIns = new DataTable("InsDetails");
        public static DataTable dtGrade = new DataTable("GradeDetails");
        public static DataTable dtClass = new DataTable("ClassDetails");
        public DataTable dt = new DataTable();
        public static string c="";
       // static DataTable dt = new DataTable();
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string s = HttpContext.Current.Session["UserName"].ToString();
                string roleids = HttpContext.Current.Session["role"].ToString();
                if (s != null)
                {
                    username.Text = "  "+ s +"!!";
                    int[] roleIds = roleids.ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
                    displayRole(roleIds, roleids);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
            catch
            {
                Response.Redirect("~/Login.aspx");
            }
            Response.ClearHeaders();
            Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "no-cache");
            if (!this.IsPostBack)
            {
                DataTable dt = ExecuteCommand("Select InstituteName, ID, InstituteID from Institute_Details");
                dtIns = dt;
                TreeMenuView.Nodes.Add(root);
                this.PopulateTreeView(dt, 0, null);

            }
        }

        private void displayRole(int[] roleIds, string roleids)
        {
            manageCam.Visible = false;
            uploadDoc.Visible = false;
            downloadDoc.Visible = false;
            delDoc.Visible = false;
            addUser.Visible = false;
            removeUser.Visible = false;
            approveUser.Visible = false;
            navbarDropdown1.Visible = false;
            navbarDropdown.Visible = false;
            for (int i=0; i< roleIds.Length; i++)
            {
                if(roleIds[i] == 1)
                {
                    
                    manageCam.Visible = true;
                    uploadDoc.Visible = true;
                    downloadDoc.Visible = true;
                    delDoc.Visible = true;
                    addUser.Visible = true;
                    removeUser.Visible = true;
                    approveUser.Visible = true;
                    
                }
               else if (roleIds[i] == 2)
                {
                    
                }
               else if (roleIds[i] == 3)
                {
                    manageCam.Visible = true;
                }
               else if (roleIds[i] == 4)
                {
                    uploadDoc.Visible = true;
                    downloadDoc.Visible = true;
                }
               else if (roleIds[i] == 5)
                {
                    delDoc.Visible = true;
                }
              else  if (roleIds[i] == 6)
                {
                    addUser.Visible = true;
                    removeUser.Visible = true;
                }
              else  if (roleIds[i] == 7)
                {
                    approveUser.Visible = true;
                }
            }

            if(roleids.Contains("4") || roleids.Contains("5") || roleids.Contains("1"))
            {
                navbarDropdown1.Visible = true;
            }
            if(roleids.Contains("2") || roleids.Contains("3") || roleids.Contains("1") || roleids.Contains("7") || roleids.Contains("6"))
            {
                navbarDropdown.Visible = true;
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

                if (ParentId == 0)
                {
                    root.ChildNodes.Add(child);

                    DataTable dtChild = ExecuteCommand("Select GradeName, Id, GradeID from Grade_Details where InsID ='" + val + "'");
                    dtGrade.Merge(dtChild);
                    PopulateTreeView(dtChild, int.Parse(child.Value), child);
                }
                else
                {
                    if (ParentId != 0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName, Id,ClassID from Class_Details where GradeID='" + val + "'");
                        dtClass.Merge(dtclass);
                        PopulateTreeView(dtclass, int.Parse(child.Value), child);
                    }
                    else
                        treeNode.ChildNodes.Add(child);
                }
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
            if (TreeMenuView.SelectedNode.Depth == 3)
            {

                c = TreeMenuView.SelectedValue.ToString();

                if (selected != null)
                {
                    selected(this, EventArgs.Empty);
                }
            }
            else
            {
                TreeMenuView.SelectedNode.Expand();
            }

            


            //this.TreeMenuView.SelectedNode.Selected = false;
        }

   

       
       
    }
    //public class Startup
    //{
    //    public void Configuration(IAppBuilder app)
    //    {
    //        app.MapSignalR();
    //    }
    //}
}