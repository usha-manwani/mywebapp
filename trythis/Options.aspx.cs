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
    public partial class Options : BasePage
    {
        protected string Values;       
        PopulateTree fillTree = new PopulateTree();
        static DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            string tabindex = Request.QueryString["tab"];
            try
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Session["UserId"].ToString()))
                {
                    if (!IsPostBack)
                    {
                        if (!string.IsNullOrEmpty(tabindex))
                        {
                            tabpanel.ActiveTabIndex = Convert.ToInt32(tabindex);
                        }
                        string query = "select * from institute_details";
                        DataTable dt = PopulateTree.ExecuteCommand(query);
                        ddlInstitute.DataSource = dt;
                        ddlInstitute.DataTextField = "Ins_Name";
                        ddlInstitute.DataValueField = "Ins_ID";
                        ddlInstitute.DataBind();
                        fillTree.function(TreeMenuView1, e);
                        fillTree.Editfunction(TreeViewEdit, e);
                        fillTree.function(TreeViewDelete, e);
                    }
                    else
                    {
                        UserActivities.UserLogs.Task1(HttpContext.Current.Session["UserId"].ToString(),
                        HttpContext.Current.Session["UserName"].ToString(), 3);
                    }
                }
            }
            catch
            {
                Response.Redirect("Logout.aspx");
            }
            
            
        }
        #region Add
        protected void TreeMenuView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                int level = TreeMenuView1.SelectedNode.Depth;
                if (level == 0)
                {
                    instext.Text = TreeMenuView1.SelectedNode.ToolTip;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), 
                        "DisplayGrade", "displayGrade();", true);
                }
                else if (level == 1)
                {
                    TextGrade.Text = TreeMenuView1.SelectedNode.ToolTip;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), 
                        "ShowClass", "displayClass();", true);
                }
                else if (level == 2)
                {
                    tbSelectedClass.Text = TreeMenuView1.SelectedNode.ToolTip;
                    instext.Text = TreeMenuView1.SelectedNode.Parent.Parent.ToolTip;
                    //string classid = TreeMenuView1.SelectedNode.ToolTip;
                    int classid = Convert.ToInt32(TreeMenuView1.SelectedNode.Value);
                    string ip = PopulateTree.getIP(classid);
                    if (!string.IsNullOrEmpty(ip))
                    {
                        ccSystem.Text = ip;
                        ccSystem.Enabled = false;
                    }
                    else
                    {
                        ccSystem.Text = "";
                        ccSystem.Enabled = true;
                    }
                    ScriptManager.RegisterStartupScript(this, typeof(Page),
                        "ShowCam", "displayCam();", true);
                }
                else if (level == 3)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), 
                        "alertMessage", "alert('Please click on ClassName " +
                        "to add Device(s) Details!!')", true);
                }
                TreeMenuView1.SelectedNode.Selected = false;
            }
            catch
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "error3", "alert('" + message + "');", true);
                bindTree();
            }
        }
        protected void btnGradesave_Click(object sender, EventArgs e)
        {
            try
            {
                int v = 0;
                if (!string.IsNullOrEmpty(Grade_Name.Text) && 
                    !string.IsNullOrWhiteSpace(Grade_Name.Text))
                    v = fillTree.InsertGrade(instext.Text, Grade_Name.Text);
                string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                this.Values = serializer.Serialize(textboxValues);
                if (textboxValues != null)
                {
                    foreach (string textboxValue in textboxValues)
                    {
                        if(!string.IsNullOrEmpty(textboxValue) && 
                            !string.IsNullOrWhiteSpace(textboxValue))
                        v = fillTree.InsertGrade(instext.Text, textboxValue);
                    }
                }
            }
            catch
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "gradesaveerror1", "alert('" + message + "');", true);
            }
            finally
            {
                bindTree();
                EmptyTextBox();
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "HideGrade", "xx();", true);
            }
        }
        protected void BtnClassSave_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;                               
                if (!string.IsNullOrEmpty(Class_Name.Text) && !string.IsNullOrWhiteSpace(Class_Name.Text))
                {
                    int v = 0;
                    if (!string.IsNullOrEmpty(tbip.Text) && !string.IsNullOrWhiteSpace(tbip.Text))
                    v = fillTree.InsertClass(TextGrade.Text, Class_Name.Text, tbip.Text.Trim());
                    else
                    {
                        v = fillTree.InsertClass(TextGrade.Text, Class_Name.Text, "1");
                    }
                }
                string[] textboxValues = Request.Form.GetValues("DynamicTextClass");
                string[] textboxip = Request.Form.GetValues("DynamicIP");
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                var c = serializer.Serialize(textboxValues);
                var i = serializer.Serialize(textboxip);
                if (textboxValues != null)
                {
                    for (int n = 0; n < textboxValues.Length; n++)
                    {
                        if(!string.IsNullOrEmpty(textboxValues[n]) && !string.IsNullOrWhiteSpace(textboxValues[n]))
                        {
                            if (!string.IsNullOrEmpty(tbip.Text) && !string.IsNullOrWhiteSpace(tbip.Text))
                            {
                                if (!string.IsNullOrEmpty(textboxip[n]) && !string.IsNullOrWhiteSpace(textboxip[n]))
                                    result = fillTree.InsertClass(TextGrade.Text, textboxValues[n], textboxip[n]);
                                else
                                {
                                    result = fillTree.InsertClass(TextGrade.Text, textboxValues[n], "1");
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "classaveerror1", "alert('" + message + "');", true);
            }
            finally
            {
                bindTree();
                EmptyTextBox();
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "HideClass", "hideClass();", true);
            }            
        }
        protected void BtnCamSave_Click(object sender, EventArgs e)
        {
            try
            {
                int f = 0;
                if (ccSystem.Enabled != false)
                {
                    if (!string.IsNullOrEmpty(ccSystem.Text) && 
                        !string.IsNullOrWhiteSpace(ccSystem.Text))
                    {
                        f = fillTree.InsertCentralControl(ccSystem.Text, 
                            tbSelectedClass.Text, instext.Text);
                    }
                    if (f != 0 && f != 1)
                    {
                        string message = Resources.Resource.ResourceManager.GetString("AlertErrorIP");
                        ScriptManager.RegisterStartupScript(this, typeof(Page),
                            "alertip", "alert('" + message + "');", true);
                    }
                }
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
                    int result = -2;
                    for (int n = 0; n < ip.Length; n++)
                    {
                        var camip = ip[n];
                        var id = user[n];
                        var pa = pass[n];
                        var portno = port[n];
                        if(!string.IsNullOrEmpty(camip)&& !string.IsNullOrEmpty(id) 
                            &&!string.IsNullOrEmpty(pa) && !string.IsNullOrEmpty(portno))
                            result = fillTree.InsertCam(camip, id, pa, portno,
                                tbSelectedClass.Text, instext.Text);
                    }
                    if(result == -2)
                    {
                        string message = Resources.Resource.ResourceManager.GetString("NoMoreCam");
                        ScriptManager.RegisterStartupScript(this, typeof(Page),
                            "showcamins", "alert('"+message+"');", true);
                    }                                           
                    else if(result==-1)                        
                    {
                        string message = Resources.Resource.ResourceManager.GetString("AlertErrorIP");
                        ScriptManager.RegisterStartupScript(this, typeof(Page),
                            "alertip1", "alert('"+message+"');", true);
                    }
                }                
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "camError", "alert('"+message+"');", true);
            }
            finally
            {
                bindTree();
                EmptyTextBox();
                // ScriptManager.RegisterStartupScript(this, typeof(Page),
                //"HideCam", "hideCam();", true);   
            }           
        }

        protected void save_Click(object sender, EventArgs e)
        {
            int r = fillTree.InsertInstitute(txtIns.Text);
            string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            this.Values = serializer.Serialize(textboxValues);
            if (textboxValues != null)
            {
                foreach (string textboxValue in textboxValues)
                {
                   fillTree.InsertGrade(r, textboxValue);
                }
            }            
            bindTree();
            EmptyTextBox();
        }
        #endregion

        #region Edit
        //edit
        protected void TreeViewEdit_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                int level = TreeViewEdit.SelectedNode.Depth;
                if (level == 4)
                {
                    tbSelectedClass.Text = TreeViewEdit.SelectedNode.Parent.Parent.ToolTip;
                    if (TreeViewEdit.SelectedNode.Parent.Value == "Camera")
                    {
                        string p = TreeViewEdit.SelectedNode.Text;
                        try
                        {
                            DataTable dt = fillTree.camDetails(p, tbSelectedClass.Text);
                            hiddencamName.Text = p;
                            camEditIP.Text = dt.Rows[0]["CameraIP"].ToString();
                            portEdit.Text = dt.Rows[0]["portNo"].ToString();
                            idEditcam.Text = dt.Rows[0]["ID"].ToString();
                            passEditcam.Text = dt.Rows[0]["password"].ToString();
                            ScriptManager.RegisterStartupScript(this, typeof(Page),
                                "ShowEditCam", "EditCam();", true);
                        }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                        catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                        {
                            bindTree();
                        }
                    }
                    else
                    {
                        txtRename.Text = TreeViewEdit.SelectedNode.Text;
                        edittbip.Text = TreeViewEdit.SelectedNode.Text;
                       // edittbip.Text = TreeViewEdit.SelectedNode.Text;
                        ScriptManager.RegisterStartupScript(this, typeof(Page),
                            "ShowRename2", "ShowEditIPModal();", true);
                    }
                }
                else if (level == 3)
                {
                    //AddClearTime(TreeViewEdit.SelectedNode,
                    //TreeViewEdit.SelectedNode.ChildNodes[0].Text, e);
                    string change = Resources.Resource.ResourceManager.GetString("ChangeUsesTime");
                    if (TreeViewEdit.SelectedNode.Text == change)
                    {
                        hourclass.Text = TreeViewEdit.SelectedNode.Parent.Text;
                        hourgrade.Text = TreeViewEdit.SelectedNode.Parent.Parent.Text;
                        hourins.Text = TreeViewEdit.SelectedNode.Parent.Parent.Parent.Text;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Showworkhour", 
                            "showworkingHour('" + TreeViewEdit.SelectedNode.Value + "');", true);
                    }
                    else
                    TreeViewEdit.SelectedNode.Expand();
                    // ScriptManager.RegisterStartupScript(this, typeof(Page),
                    //"donothing", "donothing();", true);
                }
                else
                {
                    txtRename.Text = TreeViewEdit.SelectedNode.ToolTip;
                    tbRename.Text = TreeViewEdit.SelectedNode.Text;
                    ScriptManager.RegisterStartupScript(this, typeof(Page),
                        "ShowRename3", "Rename();", true);
                }
                TreeViewEdit.SelectedNode.Selected = false;
            }
            catch
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "error6", "alert('" + message + "');", true);
                bindTree();
                EmptyTextBox();
            }
        }
        protected void saveCamEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string prent = hiddencamName.Text;
                fillTree.updateCam(camEditIP.Text, passEditcam.Text,
                    idEditcam.Text, portEdit.Text, prent);
            }
            catch
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "savecamerror2", "alert('" + message + "');", true);
            }
            finally
            {
                bindTree();
                EmptyTextBox();
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "HideEditCam", "hideEdit();", true);
            }
        }
        protected void saveRename_Click(object sender, EventArgs e)
        {
            try
            {
                string v = txtRename.Text;
                if (v.Contains("Ins"))
                {
                    fillTree.updateIns(v, tbRename.Text);
                }
                else if (v.Contains("Grade"))
                {
                    fillTree.updateGrade(v, tbRename.Text);
                }
                else if (v.Contains("Class"))
                {
                    fillTree.updateClass(v, tbRename.Text);
                }
                else
                {
                    fillTree.UpdateCentralControl(tbRename.Text, tbSelectedClass.Text);
                }
            }
            catch
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "saverenameerror2", "alert('" + message + "');", true);
            }
            finally
            {
                bindTree();
                EmptyTextBox();
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "HideRename", "hideRename();", true);
            }
            
        }
        protected void Saveeditip_Click(object sender, EventArgs e)
        {
            try
            {
                fillTree.UpdateCentralControl(edittbip.Text, tbSelectedClass.Text);
            }
            catch
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "editiperror2", "alert('" + message + "');", true);
            }
            finally
            {
                bindTree();
                EmptyTextBox();
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "Hideeditip", "hideEditIPModal();", true);
            }
        }
        #endregion

        #region delete
        //del
        protected void TreeViewDelete_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                delvalue.Text = TreeViewDelete.SelectedValue;
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "ConfirmDel", "ConfirmDel();", true);
            }
            catch
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "deleteerror1", "alert('" + message + "');", true);
                bindTree();
                EmptyTextBox();
            }           
        }
        protected void Btndel_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "HideDel", "hideDelConfirm();", true);
                string cam = delvalue.Text;
                int result = 2;
                if (TreeViewDelete.SelectedNode.Depth == 3)
                {
                    if (TreeViewDelete.SelectedNode.Value=="Camera")
                    {
                        
                        result = fillTree.DelAllCam(TreeViewDelete.SelectedNode.Parent.ToolTip);
                    }
                    else
                    {
                        result = fillTree.DelAllCC(loc: TreeViewDelete.SelectedNode.Parent.ToolTip);
                    }
                }
                if (TreeViewDelete.SelectedNode.Depth == 4)
                {
                    if (TreeViewDelete.SelectedNode.Parent.Value == "Camera")
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
                if (result != 1 && result != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), 
                        "alertMessage", "alert('The requested Item can not be " +
                        "deleted at this moment. Please try later'); ", true);
                }                
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                string message = Resources.Resource.ResourceManager.GetString("AlertError");
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "error5", "alert('" + message + "');", true);
            }
            finally
            {
                bindTree();
                EmptyTextBox();
            }         
        }

        #endregion

        //close all popups        
        protected void bindTree()
        {
            fillTree.function(TreeMenuView1, null);
            fillTree.Editfunction(TreeViewEdit, null);
            fillTree.function(TreeViewDelete, null);
        }      

        private void EmptyTextBox()
        {
            tbip.Text = "";
            Class_Name.Text = "";
            Grade_Name.Text = "";
            instext.Text = "";
            camEditIP.Text = "";
            portEdit.Text = "";
            idEditcam.Text = "";
            passEditcam.Text = "";
            edittbip.Text = "";
        }
        
    }
}