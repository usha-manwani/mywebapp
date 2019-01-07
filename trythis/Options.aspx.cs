using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;


namespace WebCresij
{
    public partial class Options : System.Web.UI.Page
    {
        protected string Values;
       
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
        }

        #region Add
        protected void TreeMenuView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            int level = TreeMenuView1.SelectedNode.Depth;
            if (level == 0)
            {
                instext.Text = TreeMenuView1.SelectedNode.ToolTip;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "DisplayGrade", "displayGrade();", true);
            }
            else if (level == 1)
            {
                TextGrade.Text = TreeMenuView1.SelectedNode.ToolTip;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowClass", "displayClass();", true);
            }
            else if (level == 2)
            {
                tbSelectedClass.Text = TreeMenuView1.SelectedNode.ToolTip;
                string classid = TreeMenuView1.SelectedNode.ToolTip;
                string ip = PopulateTree.getIP(classid);
                if (!string.IsNullOrEmpty(ip))
                {
                    ccSystem.Text = ip;
                    ccSystem.Enabled = false;
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowCam", "displayCam();", true);

            }
            else if(level==3)
            {                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Can not add more items inside Devices Details!!')", true);            
            }
                      
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
            bindTree();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "HideGrade", "xx();", true);
        }
        protected void BtnClassSave_Click(object sender, EventArgs e)
        {            
            int result = 0;
            int v = 0;
            v = fillTree.InsertClass(TextGrade.Text, Class_Name.Text);
           
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
            bindTree();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "HideClass", "hideClass();", true);
        }
        protected void BtnCamSave_Click(object sender, EventArgs e)
        {
            int f = 0;
            if (!string.IsNullOrEmpty(ccSystem.Text) && !string.IsNullOrWhiteSpace(ccSystem.Text))
            {
               f= fillTree.InsertCentralControl(ccSystem.Text, tbSelectedClass.Text);
            }
            if (f != 0 && f != 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alertip", "duplicateIP();", true);
            }
            else
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
                    }
                } 
            }
            bindTree();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "HideCam", "hideCam();", true);
        }
       
        #endregion

        #region Edit
        //edit
        protected void TreeViewEdit_SelectedNodeChanged(object sender, EventArgs e)
        {
            int level = TreeViewEdit.SelectedNode.Depth;
            if(level==4)
            {
                if (TreeViewEdit.SelectedNode.Parent.Text == "Camera")
                {
                    string p = TreeViewEdit.SelectedNode.Value;
                    DataTable dt = fillTree.camDetails(p);
                    camEditIP.Text = dt.Rows[0][0].ToString();
                    portEdit.Text = dt.Rows[0][3].ToString();
                    idEditcam.Text = dt.Rows[0][1].ToString();
                    passEditcam.Text = dt.Rows[0][2].ToString();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowEditCam", "EditCam();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "noteditable", "DeviceNotEdit();", true);
                    bindTree();
                }
            }
            else if (level == 3)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "donothing", "donothing();", true);
            }
            else
            {
                renameText.Value = TreeViewEdit.SelectedNode.ToolTip;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowRename", "Rename();", true);
            }                           
        }
        protected void saveCamEdit_Click(object sender, EventArgs e)
        {
            string prent = TreeViewEdit.SelectedNode.Parent.Parent.ToolTip;
            fillTree.updateCam(camEditIP.Text, passEditcam.Text, idEditcam.Text, portEdit.Text, prent);
            bindTree();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "HideEditCam", "hideEdit();", true);            
        }
        protected void saveRename_Click(object sender, EventArgs e)
        {
            string v = TreeViewEdit.SelectedNode.ToolTip;
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
            
            bindTree();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "HideRename", "hideRename();", true);
            
        }
        #endregion
        #region delete
        //del
        protected void TreeViewDelete_SelectedNodeChanged(object sender, EventArgs e)
        {
            if(TreeViewDelete.SelectedNode.Depth == 3)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "nodelete", "nodelete();", true);
            }
            else
            delvalue.Text = TreeViewDelete.SelectedValue;            
            ScriptManager.RegisterStartupScript(this, typeof(Page), "ConfirmDel", "ConfirmDel();", true);
        }
        protected void btndel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "HideDel", "hideDelConfirm();", true);
            string cam = delvalue.Text;
             int result = 2;    
                    if (TreeViewDelete.SelectedNode.Depth == 4)
                    {
                        if (TreeViewDelete.SelectedNode.Parent.Text == "Camera")
                        { 
                            result = fillTree.delCam(cam, TreeViewDelete.SelectedNode.Parent.Parent.ToolTip);
                        }
                        else
                        {
                            result = fillTree.DelCC(cam, TreeViewDelete.SelectedNode.Parent.Parent.ToolTip);
                        }
                    }
                    else if (TreeViewDelete.SelectedNode.Depth == 2)
                    {
                        result = fillTree.DeleteClass(TreeViewDelete.SelectedNode.ToolTip);
                    }
                    else if (TreeViewDelete.SelectedNode.Depth == 1)
                    {
                        result = fillTree.DelGrade(TreeViewDelete.SelectedNode.ToolTip);
                    }
                    else if (TreeViewDelete.SelectedNode.Depth == 0)
                    {
                        result = fillTree.DelInstitute(TreeViewDelete.SelectedNode.ToolTip);
                    }

            
            bindTree();
            if (result == 1 || result==0)
            {                                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Deleted Successfully');", true);               
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('The requested Item can not be deleted at this moment. Please try later'); ", true);    
            }            
        }

        #endregion

        //close all popups
        

        protected void bindTree()
        {
            fillTree.function(TreeMenuView1, null);
            fillTree.function(TreeViewEdit, null);
            fillTree.function(TreeViewDelete, null);
        }      
    }
}