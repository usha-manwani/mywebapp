﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int DeleteClass(string id)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = " Delete from ClassDetails where Classid = " + id ;
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

        public int DeleteFloor(string id)
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
    }
}