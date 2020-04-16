﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace CresijApp.DataAccess
{
    public class PopulateTree
    {
        #region

        #endregion
        #region create edit tree
        public void EditCam(TreeView t, string ptId, TreeNode c)
        {
            string multimediadevice = Resources.Resource.ResourceManager.GetString("MultimediaDevice");
            string came = Resources.Resource.ResourceManager.GetString("Camera");
            string change = Resources.Resource.ResourceManager.GetString("ChangeUsesTime");

            DataTable dtcam = ExecuteCommand("Select CamName, CameraID, CameraIP from Camera_Details where " +
                "location in (select id from class_details where classid ='" + ptId + "')");
            if (dtcam.Rows.Count > 0)
            {
                TreeNode nodeCam = new TreeNode
                {
                    Text = came,
                    Value = "Camera"
                };
                c.ChildNodes.Add(nodeCam);
                foreach (DataRow row in dtcam.Rows)
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row[0].ToString(),
                        Value = row[2].ToString()

                    };
                    nodeCam.ChildNodes.Add(child);
                }
            }
            DataTable dtControlDevice = ExecuteCommand("Select CCIP,Location from CentralControl where " +
                "location in (select id from class_details where classid ='" + ptId + "')");

            if (dtControlDevice.Rows.Count > 0)
            {
                TreeNode nodeCentral = new TreeNode
                {
                    Text = multimediadevice,
                    Value = "Multimedia"
                };
                c.ChildNodes.Add(nodeCentral);
                foreach (DataRow row in dtControlDevice.Rows)
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row[0].ToString(),
                        Value = row[0].ToString()
                    };
                    nodeCentral.ChildNodes.Add(child);
                }
                TreeNode node = new TreeNode
                {
                    Text = change,
                    Value = ptId
                };
                c.ChildNodes.Add(node);
            }


        }

        public void Editfunction(TreeView t, EventArgs args)
        {
            if (t.Nodes.Count > 0)
            {
                t.Nodes.Clear();
            }
            DataTable dt = ExecuteCommand("Select ins_name, ID, ins_id from Institute_Details order by ins_name");
            this.EditPopulateTreeView(dt, 0, null, t);
        }
        private void EditPopulateTreeView(DataTable dtParent, int ParentId, TreeNode treeNode, TreeView t)
        {
            string val;
            foreach (DataRow row in dtParent.Rows)
            {
                val = row[2].ToString();
                TreeNode child = new TreeNode
                {
                    Text = row[0].ToString(),
                    Value = row[1].ToString(),
                    ToolTip = row[2].ToString(),
                };
                if (ParentId == 0)
                {
                    t.Nodes.Add(child);
                    DataTable dtChild = ExecuteCommand("Select Grade_Name, Id,grade_id from Grade_Details where InsID  in" +
                        "(select id from `cresijdatabase`.institute_details where ins_id='" + val + "') order by Grade_Name");
                    EditPopulateTreeView(dtChild, int.Parse(child.Value), child, t);
                }
                else
                {
                    if (ParentId != 0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName, Id, classId from Class_Details where GradeID in" +
                            "(select id from grade_details where grade_id='" + val + "') order by ClassName");
                        if (dtclass.Rows.Count == 0)
                        {
                            EditCam(t, val, child);
                        }

                        EditPopulateTreeView(dtclass, int.Parse(child.Value), child, t);
                    }
                    else
                        treeNode.ChildNodes.Add(child);
                }
            }
            t.CollapseAll();
        }
        #endregion

        #region Create Tree
        static DataTable dt = new DataTable();
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;



        public void cam(TreeView t, string ptId, TreeNode c)
        {
            string multimediadevice = Resources.Resource.ResourceManager.GetString("MultimediaDevice");
            string came = Resources.Resource.ResourceManager.GetString("Camera");

            DataTable dtcam = ExecuteCommand("Select CamName, CameraID, CameraIP from Camera_Details where " +
                "location in (select id from class_details where classid ='" + ptId + "')");
            if (dtcam.Rows.Count > 0)
            {
                TreeNode nodeCam = new TreeNode
                {
                    Text = came,
                    Value = "Camera"
                };
                c.ChildNodes.Add(nodeCam);
                foreach (DataRow row in dtcam.Rows)
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row[0].ToString(),
                        Value = row[2].ToString()

                    };
                    nodeCam.ChildNodes.Add(child);
                }
            }
            DataTable dtControlDevice = ExecuteCommand("Select CCIP,Location from CentralControl where " +
                "location in (select id from class_details where classid ='" + ptId + "')");

            if (dtControlDevice.Rows.Count > 0)
            {
                TreeNode nodeCentral = new TreeNode
                {
                    Text = multimediadevice,
                    Value = "Multimedia"
                };
                c.ChildNodes.Add(nodeCentral);
                foreach (DataRow row in dtControlDevice.Rows)
                {
                    TreeNode child = new TreeNode
                    {
                        Text = row[0].ToString(),
                        Value = row[0].ToString()
                    };
                    nodeCentral.ChildNodes.Add(child);
                }
            }
        }

        public void function(TreeView t, EventArgs args)
        {
            if (t.Nodes.Count > 0)
            {
                t.Nodes.Clear();
            }
            DataTable dt = ExecuteCommand("Select ins_name, ID, ins_id from Institute_Details order by ins_name");
            this.PopulateTreeView(dt, 0, null, t);
        }

        private void PopulateTreeView(DataTable dtParent, int ParentId, TreeNode treeNode, TreeView t)
        {
            string val;
            foreach (DataRow row in dtParent.Rows)
            {
                val = row[2].ToString();
                TreeNode child = new TreeNode
                {
                    Text = row[0].ToString(),
                    Value = row[1].ToString(),
                    ToolTip = row[2].ToString(),
                };
                if (ParentId == 0)
                {
                    t.Nodes.Add(child);
                    DataTable dtChild = ExecuteCommand("Select Grade_Name, Id,grade_id from Grade_Details where InsID  in" +
                        "(select id from `cresijdatabase`.institute_details where ins_id='" + val + "') order by Grade_Name");
                    PopulateTreeView(dtChild, int.Parse(child.Value), child, t);
                }
                else
                {
                    if (ParentId != 0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName, Id, classId from Class_Details where GradeID in" +
                            "(select id from grade_details where grade_id='" + val + "') order by ClassName");
                        if (dtclass.Rows.Count == 0)
                        {
                            cam(t, val, child);
                        }

                        PopulateTreeView(dtclass, int.Parse(child.Value), child, t);
                    }
                    else
                        treeNode.ChildNodes.Add(child);
                }
            }
            t.CollapseAll();
        }

        public static DataTable ExecuteCommand(string Text)
        {
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(Text, con);
                //Opening Connection  
                if (con.State != ConnectionState.Open)
                    con.Open();

                //Loading all data in a datatable from datareader  
                da.Fill(dt);
                //Closing the connection  

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public static DataSet GetDataSet(string Text)
        {
            MySqlConnection con = new MySqlConnection(constr);
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(Text, con);
                //Opening Connection  
                if (con.State != ConnectionState.Open)
                    con.Open();
                DataSet ds = new DataSet();
                //Loading all data in a datatable from datareader  
                da.Fill(ds);
                //Closing the connection  
                return ds;
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
        #endregion

        #region Insert Details

        public void insertANyData(string Query)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(Query, con))
                {
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

        }
        public int InsertInstitute(string Text)
        {
            int t = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_insertInstitute", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InsName", Text);
                        cmd.Parameters.Add("@Ids", MySqlDbType.Int32);
                        cmd.Parameters["@Ids"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        t = Convert.ToInt32(cmd.Parameters["@Ids"].Value);

                    }

                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                finally
                {
                    con.Close();
                }
                return t;
            }

        }
        public int InsertGrade(string insID, string Grade)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_InsertOnlyGrade", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@gradename", Grade);
                    cmd.Parameters.AddWithValue("@insid", insID);
                    //cmd.Parameters.Add("@Ids", MySqlDbType.Int32);
                    //cmd.Parameters["@Ids"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        //result = Convert.ToInt32(cmd.Parameters["@Ids"].Value);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }

        public void InsertGrade(int insID, string Grade)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertGrade", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@gradename", Grade);
                    cmd.Parameters.AddWithValue("@insid", insID);
                    //cmd.Parameters.Add("@Ids", MySqlDbType.Int32);
                    //cmd.Parameters["@Ids"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public int InsertClass(string gid, string className, string ip)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertClass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Class", className);
                    cmd.Parameters.AddWithValue("@grade", gid);

                    cmd.Parameters.AddWithValue("@ip", ip);

                    cmd.Parameters.Add("@Ids", MySqlDbType.Int32);
                    cmd.Parameters["@Ids"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@Ids"].Value);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }

        public int InsertCam(string camIP, string userId, string camPass, string port, string loc, string insID)
        {

            int result = -1;
            if (camIP != null && userId != null && camPass != null && port != null && loc != null)
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand("sp_insertCamDetails", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ip", camIP);
                            cmd.Parameters.AddWithValue("@pass", camPass);
                            cmd.Parameters.AddWithValue("@loc", loc);
                            cmd.Parameters.AddWithValue("@userid", userId);
                            cmd.Parameters.AddWithValue("@portno", port);
                            cmd.Parameters.AddWithValue("@camprovider", "HikVision");
                            cmd.Parameters.AddWithValue("@ins", insID);
                            cmd.Parameters.Add("@result", MySqlDbType.VarChar, -1);
                            cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                        }
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex) { }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }

        public int InsertCentralControl(string ccIP, string loc, string insId)
        {
            int result = 0;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {

                    using (MySqlCommand cmd = new MySqlCommand("sp_insertCentralControl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ip", ccIP);
                        cmd.Parameters.AddWithValue("@location", loc);
                        cmd.Parameters.AddWithValue("@insId", insId);
                        cmd.Parameters.Add("@result", MySqlDbType.Int32);
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                    }

                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    result = -2;
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }
        #endregion

        #region Delete details

        public int DelCC(string ccip, string loc)
        {
            int result;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_delCConLocation", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ips", ccip);
                    cmd.Parameters.AddWithValue("@loc", loc);
                    cmd.Parameters.Add("@r", MySqlDbType.Int32);
                    cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@r"].Value);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        result = -1;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }
        public int delCam(string camIP, string loc)
        {
            int cid = 2;
            if (camIP != null)
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    try
                    {
                        using (MySqlCommand cmd = new MySqlCommand("sp_deleteCameraonLocation", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@r", MySqlDbType.Int32);
                            cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                            cmd.Parameters.AddWithValue("@camip", camIP);
                            cmd.Parameters.AddWithValue("@loc", loc);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            cid = Convert.ToInt32(cmd.Parameters["@r"].Value);
                        }
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return cid;
        }

        public int DeleteClass(string classId)
        {
            int result = -1;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_deleteClass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@r", MySqlDbType.Int32);
                    cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@class", classId);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@r"].Value);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }


        public int DelGrade(string GradeId)
        {
            int result = -1;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_deletegrade", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@gradeids", GradeId);
                    cmd.Parameters.Add("@r", MySqlDbType.Int32);
                    cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@r"].Value);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }

        public int DelInstitute(string insId)
        {
            int result = -1;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_deleteInstitute", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ins", insId);
                    cmd.Parameters.Add("@r", MySqlDbType.Int32);
                    cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@r"].Value);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }
        public int DelAllCam(string loc)
        {
            int result = -1;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_deleteCamera", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@result", MySqlDbType.Int32);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@loc", loc);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }
        public int DelAllCC(string loc)
        {
            int result = -1;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_deleteCentralControl", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@result", MySqlDbType.Int32);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@loc", loc);
                    try
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }
        public static void AnyTask(string query)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        int result = cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        #endregion

        #region Edit details

        public DataTable camDetails(string camName, string loc)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_camdetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@cname", camName);
                    cmd.Parameters.AddWithValue("@loc", loc);
                    try
                    {
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return dt;
        }

        public void updateCam(string ip, string pass, string id, string port, string camName)
        {
            int portNo = Convert.ToInt32(port);
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_updateCamera", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", id);
                    cmd.Parameters.AddWithValue("@ip", ip);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@portno", portNo);
                    cmd.Parameters.AddWithValue("@cameraName", camName);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        public void updateIns(string id, string insName)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_updateInstitute", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@InsName", insName);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public void updateGrade(string id, string gradeName)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_updateGrade", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@gradeName", gradeName);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        public void updateClass(string id, string className)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_updateClass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@className", className);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    { }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        public void UpdateCentralControl(string ip, string loc)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_updateCentralControl", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Ip", ip);
                    cmd.Parameters.AddWithValue("@className", loc);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }
        #endregion

        #region cardReaderTree
        public void fill(TreeView t)
        {
            if (t.Nodes.Count > 0)
            {
                t.Nodes.Clear();
            }

            DataTable dt = ExecuteCommand("Select Ins_Name, ID, Ins_ID from Institute_Details");
            this.populateTreeCard(dt, 0, null, t);
        }
        private void populateTreeCard(DataTable dtParent, int ParentId, TreeNode treeNode, TreeView t)
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
                child.ToolTip = val;
                if (ParentId == 0)
                {
                    t.Nodes.Add(child);
                    DataTable dtChild = ExecuteCommand("Select Grade_Name, Id,grade_id from Grade_Details where InsID  in" +
                        "(select id from `cresijdatabase`.institute_details where ins_id='" + val + "') order by Grade_Name");
                    populateTreeCard(dtChild, int.Parse(child.Value), child, t);
                }
                else
                {
                    if (ParentId != 0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName, Id, classId from Class_Details where GradeID in" +
                            "(select id from grade_details where grade_id='" + val + "') order by ClassName");
                        populateTreeCard(dtclass, int.Parse(child.Value), child, t);
                    }
                    else
                        treeNode.ChildNodes.Add(child);
                }
            }
            t.CollapseAll();
        }
        #endregion
        #region CardReaderGidview
        public DataTable tempcard()
        {
            DataTable dt1 = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "Select * from tempCardRegister";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                            da.Fill(dt1);
                        }
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return dt1;
        }
        public int inserTempCard(string sno, string id, string name, string card, string com)
        {
            int result = -1;
            int serialno = Convert.ToInt32(sno);
            if (com == "" || com == null)
            {
                com = "No comments";
            }

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    //string query = "insert into tempCardRegister values("+serialno+",'"+id+"','" +mem+ "','" + card+"','" +com+   "','Unregistered','--','Select Access')";
                    //MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlCommand cmd = new MySqlCommand("InstempCard", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@memberID", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@ReaderID", card);
                    cmd.Parameters.AddWithValue("@comment", com);
                    cmd.Parameters.AddWithValue("@state", "unregistered");
                    cmd.Parameters.AddWithValue("@sno", serialno);
                    cmd.Parameters.AddWithValue("@access", "--");
                    cmd.Parameters.AddWithValue("@select", "Select Access");
                    cmd.Parameters.Add("@result", MySqlDbType.Int32);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    result = -2;
                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }
        public int regcard(string sno, string memid, string name, string card, string com, string state, string access, string locnames, string locids)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("RegCard", con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("sno", sno);
                        cmd.Parameters.AddWithValue("memberid", memid);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@cardid", card);
                        cmd.Parameters.AddWithValue("@comment", com);
                        cmd.Parameters.AddWithValue("@state", "Unregistered");
                        cmd.Parameters.AddWithValue("@rightsID", access);
                        cmd.Parameters.AddWithValue("@pending", locnames);
                        cmd.Parameters.AddWithValue("@classId", locids);
                        cmd.Parameters.Add("@result", MySqlDbType.Int32);
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                        string query = " delete from tempCardRegister where ReaderID ='" + card + "'";
                        MySqlCommand cmd1 = new MySqlCommand(query, con);
                        cmd1.ExecuteNonQuery();
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    result = -3;
                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }
        public static string getIP(string loc)
        {
            string result = "";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "Select CCIP from CentralControl where location in " +
                        "(select id from class_Details where classid ='" + loc + "' COLLATE utf8mb4_unicode_ci)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        var i = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            result = i.ToString();
                        }

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                }
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    result = "";
                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }

        public static string getIP(int loc)
        {
            string result = "";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "Select CCIP from CentralControl where location =" + loc;
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        var i = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            result = i.ToString();
                        }

                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    result = "";
                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }

        public int updateStatus(string ip, string card)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("regOnLoc", con))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@cardID", card);
                        cmd.Parameters.AddWithValue("@ip", ip);
                        result = cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        result = -2;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }

        public static string insertCardLogs(string ip, string cardId)
        {
            string newlog = "";
            MySqlConnection con = new MySqlConnection(constr);
            using (MySqlCommand cmd = new MySqlCommand("cardLogs", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ip", ip);
                cmd.Parameters.AddWithValue("@id", cardId);
                cmd.Parameters.Add("@newlog", MySqlDbType.VarChar, 100);
                cmd.Parameters["@newlog"].Direction = ParameterDirection.Output;
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                    newlog = cmd.Parameters["@newlog"].Value.ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            return newlog;
        }
        public DataTable GetCardLogs()
        {
            DataTable dt = null;
            //string query = "select cc.MemberID cc.Name ";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("GetCardLogs", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                }
            }
            return dt;
        }

        public int UpdateRegCard(string cardID, string name, string memberid,
            string loc, string comment, string pending, string locids)
        {
            int result = -1;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_updateCard", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cid", cardID);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@memid", memberid);
                    cmd.Parameters.AddWithValue("@loc", loc);
                    cmd.Parameters.AddWithValue("@pending", pending);
                    cmd.Parameters.AddWithValue("@comment", comment);
                    cmd.Parameters.AddWithValue("@locid", locids);
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();

                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {
                        result = -2;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;

        }
        #endregion

        #region Schedule
        public int setSchedule(string ID, string starttime,
            string stoptime, string timeron, string timeroff,
            string mon, string tue, string wed, string thu,
            string fri, string sat, string sun)
        {
            int success = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateSchedule", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@loc", ID);
                        cmd.Parameters.AddWithValue("@starttime", starttime);
                        cmd.Parameters.AddWithValue("@stoptime", stoptime);
                        cmd.Parameters.AddWithValue("@timer1", timeron);
                        cmd.Parameters.AddWithValue("@timer2", timeroff);
                        cmd.Parameters.AddWithValue("@mon", mon);
                        cmd.Parameters.AddWithValue("@tue", tue);
                        cmd.Parameters.AddWithValue("@wed", wed);
                        cmd.Parameters.AddWithValue("@thu", thu);
                        cmd.Parameters.AddWithValue("@fri", fri);
                        cmd.Parameters.AddWithValue("@sat", sat);
                        cmd.Parameters.AddWithValue("@sun", sun);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        success = cmd.ExecuteNonQuery();
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    success = -1;
                }
                finally
                {
                    con.Close();
                }

            }
            return success;
        }

        public void DelOldSchedule(string ClassID)
        {
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_deleteSchedule", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ClassID", ClassID);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static DataTable GetSchedule(string id)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetSchedule", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@loc", id);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return dt;
        }

        public void UpdateMachineTimer(string timer, string loc)
        {
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_timerMachineUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@timer1", timer);
                    cmd.Parameters.AddWithValue("@loc", loc);
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        cmd.ExecuteNonQuery();
                    }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                    catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                    {

                    }
                }
            }
        }
        #endregion

        #region status
        public DataTable GetStatus()
        {

            DataTable dtStatus = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select MachineStatus, WorkStatus, PCStatus from Status";
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        da.Fill(dtStatus);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dtStatus;
        }

        public DataTable GetStatus(string id)
        {

            DataTable dtStatus = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select count(WorkStatus) total, WorkStatus, id.Ins_ID " +
                    "from Status s join Class_Details c on c.ID = s.Class " +
                    "join Grade_Details g on g.ID = c.GradeID " +
                    "join Institute_Details id on id.ID = g.InsID " +
                     "where g.InsID in (select id from institute_details where ins_id = '" + id +
                     "') group by  g.InsID, WorkStatus order by WorkStatus";
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        da.Fill(dtStatus);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dtStatus;
        }

        public DataTable totalMachines()
        {
            DataTable dtStatus = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select Count(CCIP) from CentralControl";
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        da.Fill(dtStatus);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dtStatus;
        }

        public DataTable totalMachines(string id)
        {
            DataTable dtStatus = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select count( CCIP), id.Ins_ID from CentralControl cc " +
                    " join Class_Details c on c.ID = cc.location " +
                    "join Grade_Details g on g.ID = c.GradeID " +
                    "join Institute_Details id on id.ID = g.InsID where " +
                    " g.InsID in (select id from institute_details where ins_id = '" + id +
                     "') group by g.InsID";
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        da.Fill(dtStatus);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dtStatus;
        }

        public DataTable totalMachinesOnline(string id)
        {
            DataTable dtStatus = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select count( MachineStatus), MachineStatus, id.Ins_ID " +
                    " from Status s join Class_Details c on c.ID = s.Class " +
                    "join Grade_Details g on g.ID = c.GradeID " +
                    "join Institute_Details id on id.ID = g.InsID where " +
                    "MachineStatus='Online' and g.InsID in (select id from institute_details where ins_id = '" + id +
                     "') group by g.InsID, MachineStatus";
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        da.Fill(dtStatus);
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dtStatus;
        }

        #endregion

        #region MobilePages Data
        public static DataTable GetlocationIP(string ip)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select cd.ClassName, gd.grade_name, ins.ins_name from institute_details " +
                    " ins join grade_details gd on gd.insid = ins.id join class_details cd on gd.id = " +
                    "cd.GradeID join centralcontrol cc on cc.location = cd.id where cc.ccip = '" + ip + "' ";
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(dt);
                    }
                }
                catch (Exception)
                {

                }
            }
            return dt;
        }
        #endregion
    }
}