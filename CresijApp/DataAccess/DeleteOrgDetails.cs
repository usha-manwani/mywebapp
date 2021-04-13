using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CresijApp.Models;

namespace CresijApp.DataAccess
{
    public class DeleteOrgDetails
    {
        string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["Organisationdatabase"].ConnectionString;
        public DeleteOrgDetails() { }
        public DeleteOrgDetails(string constring) { constr = constring; }
        public int DeleteOrg(int id)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_DeleteBuilding", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("sno", id);
                    if (con.State != System.Data.ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int DeleteTeacher(string id)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = " Delete from TeacherData where teacherid = '" + id + "'";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        public int DeleteStudent(string id)
        {
            int result = 0;


            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = " Delete from StudentData where studentid = '" + id + "'";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
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
            return result;
        }

        public int DeleteFloor(int id)
        {
            int result = 0;


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
            var st = string.Join("','", ids);
            st = "'" + st + "'";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "delete from studentdata where studentid in (" + st + ")";
                using (MySqlCommand cm = new MySqlCommand(query, con))
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
            var st = string.Join(",", ids);
            using (var context = new OrganisationdatabaseEntities())
            {
                using (var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(string d in ids)
                        {
                            var id = Convert.ToInt32(d);
                            var ed = context.userlocationaccesses.Where(x => x.locationid == id && x.Level == "Building").Select(y => y);
                            context.userlocationaccesses.RemoveRange(ed);
                            var bd = context.buildingdetails.Where(x => x.id == id).Select(y => y);
                            context.buildingdetails.RemoveRange(bd);
                        }
                        result = context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        result = -1;
                    }
                }
            }
            return result;
        }

        public int DeleteMultipleClass(List<string> ids)
        {
            int result = 0;
            var st = string.Join(",", ids);
            List<classdetail> lisClassDetails = new List<classdetail>();
            using (var context = new OrganisationdatabaseEntities())
            {
                using (var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(string d in ids)
                        {
                            var id = Convert.ToInt32(d);
                            var ed = context.userlocationaccesses.Where(x => x.locationid == id && x.Level == "Class").Select(y => y);
                            context.userlocationaccesses.RemoveRange(ed);
                            var cd = context.classdetails.Where(x => x.classID == id).Select(y => y);
                            context.classdetails.RemoveRange(cd);
                        }
                        result = context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        result = -1;
                    }
                }
            }
            return result;
        }

        public int DeleteMultipleFloor(List<string> ids)
        {
            int result = 0;
            var st = string.Join(",", ids);
            using (var context = new OrganisationdatabaseEntities())
            {
                using (var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (string d in ids)
                        {
                            var id = Convert.ToInt32(d);
                            var ed = context.userlocationaccesses.Where(x => x.locationid == id && x.Level == "Floor").Select(y => y);
                            context.userlocationaccesses.RemoveRange(ed);
                            var cd = context.floordetails.Where(x => x.id == id).Select(y => y);
                            context.floordetails.RemoveRange(cd);
                        }
                        result = context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        result = -1;
                    }
                }
            }
            return result;
        }

        public int DeleteMultipleUser(List<string> ids)
        {
            int result = 0;
            var st = string.Join("','", ids);
            st = "'" + st + "'";
            using (var context = new OrganisationdatabaseEntities())
            {
                using (var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Database.ExecuteSqlCommand(@"delete from userdetails where loginid in( " + st + ")");
                        result = context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
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