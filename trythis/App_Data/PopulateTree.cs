using System;
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

        public void cam(TreeView t,string ptId, TreeNode c)
        {

            DataTable dtcam = ExecuteCommand("Select CamName, CameraID, CameraIP  from Camera_Details where location ='" + ptId + "'");
            foreach(DataRow row in dtcam.Rows)
            {
                TreeNode child = new TreeNode
                {
                    Text = row[0].ToString(),
                    Value = row[2].ToString()

                };
                c.ChildNodes.Add(child);
            }
            
        }

        public void function(TreeView t, EventArgs args )
        {
            if (t.Nodes.Count > 0)
            {
                t.Nodes.Clear();
            }
            DataTable dt = ExecuteCommand("Select InstituteName, ID, InstituteID from Institute_Details");
           
            this.PopulateTreeView(dt, 0, null,t);
        }

        
        private void PopulateTreeView(DataTable dtParent, int ParentId, TreeNode treeNode, TreeView t )
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
                    PopulateTreeView(dtChild, int.Parse(child.Value), child,t);
                }
                else
                {
                    if (ParentId !=0)
                    {
                        treeNode.ChildNodes.Add(child);
                        DataTable dtclass = ExecuteCommand("Select ClassName, ID,ClassID from Class_Details where GradeID='" + val + "'");
                        if(dtclass.Rows.Count==0)
                        {
                            cam(t, val,child);
                            
                        }
                        
                        PopulateTreeView(dtclass, int.Parse(child.Value), child,t);
                        
                        
                            
                        
                    }
                       
                    
                    else 
                        treeNode.ChildNodes.Add(child);
                }
            }
            t.CollapseAll();
        }

        private static DataTable ExecuteCommand(string Text)
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

        #endregion

        #region Insert Details
        public Int32 InsertInstitute(string Text)
        {
            Int32 t=0;
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
                catch  { }
                finally
                {
                    con.Close();
                }
                return t;
            }
            
        }
        public Int32 InsertGrade(string insID, string Grade)
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

        public Int32 InsertClass(string gid, string className)
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

        public string InsertCam(String camIP, String camId, string camPass, string port, string loc)
        {
            Int32 camloc = Convert.ToInt32(loc);
            string camName="";
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
                            
                            cmd.Parameters.Add("@camName", SqlDbType.NVarChar,-1);
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

        public Int32 DeleteClass( string classId)
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
                    catch(Exception ex)
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
}
