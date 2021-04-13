using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CresijApp.DataAccess
{
    public class UserLogsDataAccess
    {
        string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["Organisationdatabase"].ConnectionString;
        public UserLogsDataAccess()
        {

        }
        public UserLogsDataAccess(string constring)
        {
            constr= System.Configuration.ConfigurationManager.
            ConnectionStrings[constring].ConnectionString;
        }
        public DataTable Login(string id, string pass)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_LoginUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", id);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    mySqlDataAdapter.Fill(dt);
                }
            }
            return dt;
        }
        public List<object> GetUserLogDetails(string pageIndex,string pageSize)
        {
            List<object> result = new List<object>();
            DataTable dt = new DataTable();
            var count = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {

                    using (MySqlCommand cmd = new MySqlCommand("sp_GetUserLogs", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("_PageIndex", Convert.ToInt32(pageIndex));
                        cmd.Parameters.AddWithValue("_PageSize", Convert.ToInt32(pageSize));
                        cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32);
                        cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                        mySqlDataAdapter.Fill(dt);
                        count = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                        result.Add(dt);
                        result.Add(count);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return result;
        }

        public DataTable GetLogDetails()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "select distinct(action) as action, count(action) as Count from userlogs group by action";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                        mySqlDataAdapter.Fill(dt);
                    }
                }
                catch (Exception ex)
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