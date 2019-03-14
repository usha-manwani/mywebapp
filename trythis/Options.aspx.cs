﻿using System;
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
            try
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
                    instext.Text = TreeMenuView1.SelectedNode.Parent.Parent.ToolTip;
                    string classid = TreeMenuView1.SelectedNode.ToolTip;
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
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowCam", "displayCam();", true);
                }
                else if (level == 3)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Please click on ClassName to add Device(s) Details!!')", true);
                }
                TreeMenuView1.SelectedNode.Selected = false;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error3", "camError();", true);
                bindTree();
            }
                      
        }
        protected void btnGradesave_Click(object sender, EventArgs e)
        {
            try
            {
                int v = 0;
                if (!string.IsNullOrEmpty(Grade_Name.Text) && !string.IsNullOrWhiteSpace(Grade_Name.Text))
                    v = fillTree.InsertGrade(instext.Text, Grade_Name.Text);
                string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                this.Values = serializer.Serialize(textboxValues);
                if (textboxValues != null)
                {
                    foreach (string textboxValue in textboxValues)
                    {
                        if(!string.IsNullOrEmpty(textboxValue) && !string.IsNullOrWhiteSpace(textboxValue))
                        v = fillTree.InsertGrade(instext.Text, textboxValue);
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error1", "camError();", true);
            }
            finally
            {
                bindTree();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "HideGrade", "xx();", true);
            }
        }
        protected void BtnClassSave_Click(object sender, EventArgs e)
        {
            try
            {
                int result = 0;
                int v = 0;
                if (!string.IsNullOrEmpty(Class_Name.Text) && !string.IsNullOrWhiteSpace(Class_Name.Text))
                    v = fillTree.InsertClass(TextGrade.Text, Class_Name.Text);

                string[] textboxValues = Request.Form.GetValues("DynamicTextClass");
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                this.Values = serializer.Serialize(textboxValues);
                if (textboxValues != null)
                {
                    foreach (string textboxValue in textboxValues)
                    {
                        if(!string.IsNullOrEmpty(textboxValue) && !string.IsNullOrWhiteSpace(textboxValue))
                        result = fillTree.InsertClass(TextGrade.Text, textboxValue);
                    }
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error1", "camError();", true);
            }
            finally
            {
                bindTree();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "HideClass", "hideClass();", true);
            }
            
        }
        protected void BtnCamSave_Click(object sender, EventArgs e)
        {
            try
            {
                int f = 0;
                if (ccSystem.Enabled != false)
                {
                    if (!string.IsNullOrEmpty(ccSystem.Text) && !string.IsNullOrWhiteSpace(ccSystem.Text))
                    {
                        f = fillTree.InsertCentralControl(ccSystem.Text, tbSelectedClass.Text, instext.Text);
                    }
                    if (f != 0 && f != 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertip", "duplicateIP();", true);
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
                        if(!string.IsNullOrEmpty(camip)&& !string.IsNullOrEmpty(id) &&!string.IsNullOrEmpty(pa) && !string.IsNullOrEmpty(portno))
                            result = fillTree.InsertCam(camip, id, pa, portno, tbSelectedClass.Text, instext.Text);
                    }
                    if(result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "showcamins", "CamIns();", true);
                    }                                           
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alertip1", "duplicateIP();", true);
                    }
                }                
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "camError", "camError();", true);
            }
            finally
            {
                bindTree();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "HideCam", "hideCam();", true);
                
            }
           
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
                    if (TreeViewEdit.SelectedNode.Parent.Text == "Camera")
                    {
                        string p = TreeViewEdit.SelectedNode.Value;
                        try
                        {
                            DataTable dt = fillTree.camDetails(p, tbSelectedClass.Text);
                            camEditIP.Text = dt.Rows[0]["CameraIP"].ToString();
                            portEdit.Text = dt.Rows[0]["portNo"].ToString();
                            idEditcam.Text = dt.Rows[0]["ID"].ToString();
                            passEditcam.Text = dt.Rows[0]["password"].ToString();
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowEditCam", "EditCam();", true);
                        }
                        catch (Exception ex)
                        {
                            bindTree();
                        }

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
                    txtRename.Text = TreeViewEdit.SelectedNode.ToolTip;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowRename", "Rename();", true);
                }
                TreeViewEdit.SelectedNode.Selected = false;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error6", "camError();", true);
                bindTree();
            }
        }
        protected void saveCamEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string prent = tbSelectedClass.Text;
                fillTree.updateCam(camEditIP.Text, passEditcam.Text, idEditcam.Text, portEdit.Text, prent);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error2", "camError();", true);
            }
            finally
            {
                bindTree();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "HideEditCam", "hideEdit();", true);
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
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error4", "camError();", true);
            }
            finally
            {
                bindTree();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "HideRename", "hideRename();", true);
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
                ScriptManager.RegisterStartupScript(this, typeof(Page), "ConfirmDel", "ConfirmDel();", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error1", "camError();", true);
                bindTree();
            }           
        }
        protected void Btndel_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "HideDel", "hideDelConfirm();", true);
                string cam = delvalue.Text;
                int result = 2;
                if (TreeViewDelete.SelectedNode.Depth == 3)
                {
                    if (TreeViewDelete.SelectedNode.Text=="Camera")
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
                if (result == 1 || result == 0)
                {
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Deleted Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('The requested Item can not be deleted at this moment. Please try later'); ", true);
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "error5", "camError();", true);
            }
            finally
            {
                bindTree();
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