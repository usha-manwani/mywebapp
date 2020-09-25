using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CresijApp.DataAccess
{
    public class DeleteOrgDetails
    {
        readonly string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["SchoolConnectionString"].ConnectionString;
        public int DeleteOrg(int id)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                   
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeleteBuilding", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("sno", id);
                        if(con.State != System.Data.ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int DeleteTeacher(string id)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = " Delete from TeacherData where teacherid = '" + id +"'";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != System.Data.ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int DeleteStudent(string id)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = " Delete from StudentData where studentid = '" + id +"'";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != System.Data.ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int DeleteClass(int id)
        {
            int result = 0;
            
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                   
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeleteClass", con))
                    {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idno", id);
                        if (con.State != System.Data.ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }
            
            return result;
        }

        public int DeleteUser(string id)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {                    
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeleteUser", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("userid", id);
                        if (con.State != System.Data.ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int DeleteFloor(int id)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeleteFloor", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("floorid", id);
                        if (con.State != System.Data.ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int DeleteMultipleOrg(string id)
        {
            int result = 0;
            return result;
        }

        public int DeleteMultipleStudent(List<string> ids)
        {
            int result = 0;
            
            var st =string.Join("','",  ids);
            st = "'" + st + "'";
            
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "delete from studentdata where studentid in (" + st + ")";
                using(MySqlCommand cm = new MySqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    result = cm.ExecuteNonQuery();
                }
            }
            return result;
        }
        public int DeleteMultipleTeacher(List<string> ids)
        {
            int result = 0;
            var st = string.Join("','", ids);
            st = "'" + st + "'";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "delete from teacherdata where teacherid in (" + st + ")";
                using (MySqlCommand cm = new MySqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    result = cm.ExecuteNonQuery();
                }
            }
            return result;
        }
        public int DeleteMultipleBuilding(List<string> ids)
        {
            int result = 0;
            var st = string.Join("','", ids);
            st = "'" + st + "'";
            
            using (var context = new Models.OrganisationdatabaseEntities())
            {
                using(var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        
                        context.Database.ExecuteSqlCommand(@"delete from schedule where classname 
                            in(select classname from classdetails where teachingbuilding in( "+st+"))");
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand(@"delete from schedulereserve where classroom  
                            in(select classid from classdetails where teachingbuilding in( " + st + "))");
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand(@"delete from scheduletransfer where newclass 
                            in(select classid from classdetails where teachingbuilding in( " + st + "))");
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand(@"delete from userlocationaccess where 
                            classid in(select classid from classdetails where teachingbuilding in( " + st + "))"); 
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand(@"delete from classdetails where teachingbuilding 
                            in( " + st + ")");
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand(@"delete from floordetails where buildingname in( " + st + ")");
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand(@"update userdetails set deptcode =null where deptcode in( " + st + ")");
                        context.SaveChanges();
                        context.Database.ExecuteSqlCommand(@"delete from buildingdetails where id in( " + st + ")");
                        context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        dbtransaction.Rollback();
                        result = -1;
                    }

                }
            }
            return result;
        }
    }
}