using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;


namespace trythis
{
    public partial class Options : System.Web.UI.Page
    {
        protected string Values;
        Int32 index;
        PopulateTree fillTree = new PopulateTree();
        static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
          if(!IsPostBack)
            {
                fillTree.function(TreeMenuView1, e);
                fillTree.function(TreeViewEdit, e);
                fillTree.function(TreeViewDelete, e);
            }
          
                closeDiv();
            
        }

        #region Add
        protected void TreeMenuView1_SelectedNodeChanged(object sender, EventArgs e)
        {


            int level = TreeMenuView1.SelectedNode.Depth;
            if (level == 0)
            {
                instext.Text = TreeMenuView1.SelectedValue;
                closeDiv();
                idGrade.Style.Add("display", "block");
                
            }
            else if (level == 1)
            {
                TextGrade.Text = TreeMenuView1.SelectedValue;
                closeDiv();
                idClass.Style.Add("display", "block");
                
            }
            else if (level == 2)
            {
                tbSelectedClass.Text = TreeMenuView1.SelectedValue;
                closeDiv();
                idCamera.Style.Add("display", "block");
                
            }
            else if(level==3)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Can not add more items inside Camera!!')", true);
                closeDiv();
            }
            TreeMenuView1.SelectedNode.Selected = false;
           

        }
        protected void btnGradesave_Click(object sender, EventArgs e)
        {
            
            int v = 0;
            v = fillTree.InsertGrade(instext.Text, Grade_Name.Text);

            string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            this.Values = serializer.Serialize(textboxValues);
            if (textboxValues != null)
            {
                foreach (string textboxValue in textboxValues)
                {
                    v = fillTree.InsertGrade(instext.Text, textboxValue);

                }
            }
            closeDiv();
            Response.Redirect("~/Options.aspx");

        }
        protected void BtnClassSave_Click(object sender, EventArgs e)
        {
            
            int result = 0;
            


            string[] textboxValues = Request.Form.GetValues("DynamicTextClass");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            this.Values = serializer.Serialize(textboxValues);
            if (textboxValues != null)
            {
                foreach (string textboxValue in textboxValues)
                {
                    result = fillTree.InsertClass(TextGrade.Text, textboxValue);

                }
            }
            closeDiv();
            Response.Redirect("~/Options.aspx");

        }
        protected void BtnCamSave_Click(object sender, EventArgs e)
        {
          
            string[] ip = Request.Form.GetValues("IP");
            string[] port = Request.Form.GetValues("Port");
            string[] user = Request.Form.GetValues("User");
            string[] pass = Request.Form.GetValues("Pass");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var i = serializer.Serialize(ip);
            var p = serializer.Serialize(port);
            var u = serializer.Serialize(user);
            var pas = serializer.Serialize(pass);
            if (ip != null)
            {

                for (int n = 0; n < ip.Length; n++)
                {
                    var camip = ip[n];
                    var id = user[n];
                    var pa = pass[n];
                    var portno = port[n];
                    string camName = fillTree.InsertCam(camip, id, pa, portno, tbSelectedClass.Text);
                    TreeNode node = new TreeNode
                    {
                        Text = camName,
                        Value = camip
                    };
                    node.PopulateOnDemand = false;

                    TreeMenuView1.SelectedNode.ChildNodes.Add(node);

                }
            }
            closeDiv();
            Response.Redirect("~/Options.aspx");
        }
        #endregion

        #region Edit
        //edit
        protected void TreeViewEdit_SelectedNodeChanged(object sender, EventArgs e)
        {
            Int32 level = TreeViewEdit.SelectedNode.Depth;
            if(level==3)
            {
                string p = TreeViewEdit.SelectedNode.Value;
                
                DataTable dt = fillTree.camDetails(p);
                camEditIP.Text = dt.Rows[0][0].ToString();
                portEdit.Text = dt.Rows[0][3].ToString();
                idEditcam.Text = dt.Rows[0][1].ToString();
                passEditcam.Text = dt.Rows[0][2].ToString();
                closeDiv();
                edit.Style.Add("display", "block");
                
            }
            else
            {
                edit.Style.Add("display", "none");
                closeDiv();
                DivRename.Style.Add("display", "block");
            }
            
                
        }
        protected void saveCamEdit_Click(object sender, EventArgs e)
        {
            fillTree.updateCam(camEditIP.Text, passEditcam.Text, idEditcam.Text, portEdit.Text);
            closeDiv();
            Response.Redirect("~/Options.aspx");
        }
        protected void saveRename_Click(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(TreeViewEdit.SelectedNode.Value);
            if (TreeViewEdit.SelectedNode.Depth == 0)
            {
                fillTree.updateIns(v, tbRename.Text);
            }
            else if (TreeViewEdit.SelectedNode.Depth == 1)
            {
                fillTree.updateGrade(v, tbRename.Text);
            }
            else if (TreeViewEdit.SelectedNode.Depth == 2)
            {
                fillTree.updateClass(v, tbRename.Text);
            }

            closeDiv();
            Response.Redirect("~/Options.aspx");
        }
        #endregion

        #region delete
        //del
        protected void TreeViewDelete_SelectedNodeChanged(object sender, EventArgs e)
        {

            delvalue.Text = TreeViewDelete.SelectedValue;
            index = TreeViewDelete.Nodes.IndexOf(TreeViewDelete.SelectedNode);
            closeDiv();
            del.Style.Add("display", "block");

        }
        protected void btndel_Click(object sender, EventArgs e)
        {
            closeDiv();
            string cam = "";
            int result = 2;

            
                    if (TreeViewDelete.SelectedNode.Depth == 3)
                    {
                        cam = delvalue.Text;
                        result = fillTree.delCam(cam);
                    }
                    else if (TreeViewDelete.SelectedNode.Depth == 2)
                    {
                        cam = delvalue.Text;
                        result = fillTree.DeleteClass(cam);
                    }
                    else if (TreeViewDelete.SelectedNode.Depth == 1)
                    {
                        cam = delvalue.Text;
                        result = fillTree.DelGrade(cam);
                    }
                    else if (TreeViewDelete.SelectedNode.Depth == 0)
                    {
                        cam = delvalue.Text;
                        result = fillTree.DelInstitute(cam);
                    }
                
            if (result == 1)
            {
                
                TreeNode tt = TreeViewDelete.SelectedNode;
                TreeViewEdit.Nodes.Remove(tt);
                TreeMenuView1.Nodes.Remove(tt);
                TreeViewDelete.Nodes.Remove(tt);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Deleted Successfully'); location.href='Options.aspx';", true);


            }
            else if (result == 0 || result == 2)
            {

                closeDiv();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('The requested Item can not be deleted at this moment. Please try later'); location.href='Options.aspx';", true);
                
            }
           
            
        }

        #endregion

        //close all popups
        protected void closeDiv()
        {
            DivRename.Style.Add("display", "none");
            edit.Style.Add("display", "none");
            idClass.Style.Add("display", "none");
            idGrade.Style.Add("display", "none");
            idCamera.Style.Add("display", "none");
            del.Style.Add("display", "none");
            delnot.Style.Add("display", "none");
        }
    }
}