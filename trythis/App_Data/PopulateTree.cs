﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace trythis
{
    public class PopulateTree
    {

        #region Create Tree
        static DataTable dt = new DataTable();
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;

        public void cam(TreeView t, string ptId, TreeNode c)
        {

            DataTable dtcam = ExecuteCommand("Select CamName, CameraID, CameraIP  from Camera_Details where location ='" + ptId + "'");
            if (dtcam.Rows.Count > 0)
            {
                TreeNode nodeCam = new TreeNode
                {
                    Text = "Camera",
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
            DataTable dtControlDevice = ExecuteCommand("Select CCIP,Location from CentralControl where location='" + ptId + "'");

            if (dtControlDevice.Rows.Count > 0)
            {
                TreeNode nodeCentral = new TreeNode
                {
                    Text = "Multimedia Device",
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

            DataTable dt = ExecuteCommand("Select InstituteName, ID, InstituteID from Institute_Details");
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
                    Value = row[1].ToString()
                };
                if (ParentId == 0)
                {
                    t.Nodes.Add(child);
                    DataTable dtChild = ExecuteCommand("Select GradeName, ID, GradeID from Grade_Details where InsID ='" + val + "'");
                    PopulateTreeView(dtChild, int.Parse(child.Value), child, t);
                }
                else
                {
                    if (ParentId != 0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName, ID,ClassID from Class_Details where GradeID='" + val + "'");
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
            SqlConnection con = new SqlConnection(constr);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(Text, con);
                //Opening Connection  
                if (con.State != ConnectionState.Open)
                    con.Open();
                DataTable dt = new DataTable();
                //Loading all data in a datatable from datareader  
                da.Fill(dt);
                //Closing the connection  
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
        public static DataSet GetDataSet(string Text)
        {
            SqlConnection con = new SqlConnection(constr);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(Text, con);
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
            using (SqlConnection con = new SqlConnection(constr))
            {
                using(SqlCommand cmd= new SqlCommand(Query, con))
                {
                    try { con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
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
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Institute", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@InsName", Text);
                        cmd.Parameters.Add("@Ids", SqlDbType.Int);
                        cmd.Parameters["@Ids"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        t = Convert.ToInt32(cmd.Parameters["@Ids"].Value);

                    }

                }
                catch { }
                finally
                {
                    con.Close();
                }
                return t;
            }

        }
        public int InsertGrade(string insID, string Grade)
        {
            Int32 result = 0;
            Int32 i = Convert.ToInt32(insID);
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Grade", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Grade", Grade);
                    cmd.Parameters.AddWithValue("@InsID", i);
                    cmd.Parameters.Add("@Ids", SqlDbType.Int);
                    cmd.Parameters["@Ids"].Direction = ParameterDirection.Output;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@Ids"].Value);


                    }
                    catch
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

        public int InsertClass(string gid, string className)
        {
            Int32 result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Class", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Class", className);
                    cmd.Parameters.AddWithValue("@Grade_ID", gid);
                    cmd.Parameters.Add("@Ids", SqlDbType.Int);
                    cmd.Parameters["@Ids"].Direction = ParameterDirection.Output;
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@Ids"].Value);
                    }
                    catch
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

        public string InsertCam(string camIP, string camId, string camPass, string port, string loc)
        {
            int camloc = Convert.ToInt32(loc);
            string camName = "";
            if (camIP != null && camId != null && camPass != null && port != null && loc != null)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_InsertCam", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CameraIP", camIP);
                            cmd.Parameters.AddWithValue("@CameraID", camId);
                            cmd.Parameters.AddWithValue("@password", camPass);
                            cmd.Parameters.AddWithValue("@id", loc);
                            cmd.Parameters.AddWithValue("@portNo", port);
                            cmd.Parameters.AddWithValue("@CamProvider", "HikVision");

                            cmd.Parameters.Add("@camName", SqlDbType.NVarChar, -1);
                            cmd.Parameters["@camName"].Direction = ParameterDirection.Output;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            camName = cmd.Parameters["@camName"].Value.ToString();
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        con.Close();
                    }

                }
            }
            return camName;
        }

        public int InsertCentralControl(string ccIP, string loc)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    string query = "Insert  into CentralControl (CCIP,location, PortNo) values('" + ccIP + "','" + loc + "',1200)";
                    using (SqlCommand cmd = new SqlCommand("InsCentralControl", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ccip", ccIP);
                        cmd.Parameters.AddWithValue("@loc", loc);
                        cmd.Parameters.Add("@result", SqlDbType.Int);
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                    }

                }
                catch (Exception ex)
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

            public Int32 delCam(string camIP)
            {
                Int32 cid = 2;
                if (camIP != null)
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand("sp_delCam", con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@r", SqlDbType.Int);
                                cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                                cmd.Parameters.AddWithValue("@Cam", camIP);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                cid = Convert.ToInt32(cmd.Parameters["@r"].Value);
                            }
                        }
                        catch
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

            public Int32 DeleteClass(string classId)
            {
                Int32 cid = Convert.ToInt32(classId);
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DelClass", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@r", SqlDbType.Int);
                        cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@class", cid);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            cid = Convert.ToInt32(cmd.Parameters["@r"].Value);
                        }
                        catch
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


            public Int32 DelGrade(string GradeId)
            {
                Int32 cid = Convert.ToInt32(GradeId);
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DelGrade", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", cid);
                        cmd.Parameters.Add("@r", SqlDbType.Int);
                        cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            cid = Convert.ToInt32(cmd.Parameters["@r"].Value);
                        }
                        catch
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

            public Int32 DelInstitute(string insId)
            {
                Int32 cid = Convert.ToInt32(insId);
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_delInstitute", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", cid);
                        cmd.Parameters.Add("@r", SqlDbType.Int);
                        cmd.Parameters["@r"].Direction = ParameterDirection.Output;
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            cid = Convert.ToInt32(cmd.Parameters["@r"].Value);
                        }
                        catch
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

            #endregion

            #region Edit details

            public DataTable camDetails(string ip)
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from fn_camDetails(@camIP)", con))
                    {
                        cmd.Parameters.AddWithValue("@camIP", ip);
                        try
                        {

                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                        catch (Exception ex)
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

            public void updateCam(string ip, string pass, string id, string port)
            {
                int portNo = Convert.ToInt32(port);
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateCam", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@ip", ip);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        cmd.Parameters.AddWithValue("@port", portNo);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();

                        }
                        catch
                        {

                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }
            public void updateIns(Int32 id, string insName)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateIns", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@InsName", insName);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {

                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }

            public void updateGrade(Int32 id, string gradeName)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateGrade", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@gradeName", gradeName);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {

                        }
                        finally
                        {
                            con.Close();
                        }
                    }

                }
            }
            public void updateClass(Int32 id, string className)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateClass", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@className", className);
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch
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

            DataTable dt = ExecuteCommand("Select InstituteName, ID, InstituteID from Institute_Details");
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
                    DataTable dtChild = ExecuteCommand("Select GradeName, ID, GradeID from Grade_Details where InsID ='" + val + "'");
                    populateTreeCard(dtChild, int.Parse(child.Value), child, t);
                }
                else
                {
                    if (ParentId != 0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName,ID, ClassID from Class_Details where GradeID='" + val + "'");
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
            DataTable dt1= new DataTable();
            using(SqlConnection con = new SqlConnection(constr))
            {
                string query = "Select * from tempCardRegister";
                using(SqlDataAdapter da = new SqlDataAdapter(query,con))
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
            int serialno= Convert.ToInt32(sno);
            if (com == "" || com == null)
            {
                com = "No comments";
            }
           
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    //string query = "insert into tempCardRegister values("+serialno+",'"+id+"','" +mem+ "','" + card+"','" +com+   "','Unregistered','--','Select Access')";
                    //SqlCommand cmd = new SqlCommand(query, con);
                    SqlCommand cmd = new SqlCommand("InstempCard", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@memberID", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@ReaderID", card);
                    cmd.Parameters.AddWithValue("@comment", com);
                    cmd.Parameters.AddWithValue("@state", "unregistered");
                    cmd.Parameters.AddWithValue("@sno", serialno);
                    cmd.Parameters.AddWithValue("@access", "--");
                    cmd.Parameters.AddWithValue("@select", "Select Access");
                    cmd.Parameters.Add("@result", SqlDbType.Int);
                    cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                }
                catch (Exception ex)
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
        public int regcard(string sno, string memid, string name, string card,string com, string state, string access,string locnames, string locids)
        {
            int result = 0;
            using(SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    using(SqlCommand cmd = new SqlCommand("RegCard", con))
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
                        cmd.Parameters.Add("@result", SqlDbType.Int);
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        result = Convert.ToInt32(cmd.Parameters["@result"].Value);
                        string query = " delete from tempCardRegister where ReaderID ='" + card+"'";
                        SqlCommand cmd1 = new SqlCommand(query, con);
                        cmd1.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
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
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    string query = "Select CCIP from CentralControl where location ='"+loc+"'"; 
                    using(SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if(con.State!= ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteScalar().ToString();
                    }
                }catch(Exception ex)
                {
                    result = "-1";
                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }
        public int updateStatus(string ip,string card)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using(SqlCommand cmd= new SqlCommand("regOnLoc", con))
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
                    catch(Exception ex)
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
            SqlConnection con = new SqlConnection(constr);
            using (SqlCommand cmd = new SqlCommand("cardLogs", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ip", ip);
                cmd.Parameters.AddWithValue("@id", cardId);
                cmd.Parameters.Add("@newlog", SqlDbType.NVarChar, 100);
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
            string query = "select cc.MemberID cc.Name ";
            using(SqlConnection con= new SqlConnection(constr))
            {
                using(SqlCommand cmd = new SqlCommand("GetCardLogs", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        if(con.State!= ConnectionState.Open)
                        {
                            con.Open();
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
            return dt;
        }
        #endregion
    }
    public class CentralControl
    {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;

        public DataSet ControlDetails()
        {

            DataSet ds = new DataSet();
            //DataTable dt;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                string query = "SELECT * from dbo.[CentralControl]";
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Notification = null;
                        //dt = new DataTable();
                        
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        da.Fill(ds);
                        //dt.Load(reader);    
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            return ds;
        }
    }
    public class ScanReader
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        public static DataTable CardData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "select * from CardRegister";
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        da.Fill(dt);
                    }
                }
                catch(Exception )
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return dt;
        }
    }   
    
}
