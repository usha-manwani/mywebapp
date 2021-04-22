// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 06-05-2020
//
// Last Modified By : admin
// Last Modified On : 04-20-2021
// ***********************************************************************
// <copyright file="UserLogsDataAccess.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CresijApp.DataAccess
{
    /// <summary>
    /// this class is to deal with database 
    ///  This class contains method for User login,
    /// Get User Logs list,Get ClassLogs list(machine logs) from database
    /// </summary>
    /// <summary>
    /// Class UserLogsDataAccess.
    /// </summary>
    public class UserLogsDataAccess
    {
        /// <summary>
        /// default connection
        /// </summary>
        /// <summary>
        /// The constr
        /// </summary>
        string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["Organisationdatabase"].ConnectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogsDataAccess"/> class.
        /// </summary>
        public UserLogsDataAccess()
        {

        }
        /// <summary>
        /// session connection
        /// </summary>
        /// <param name="constring"></param>
        /// <summary>
        /// Initializes a new instance of the <see cref="UserLogsDataAccess"/> class.
        /// </summary>
        /// <param name="constring">The constring.</param>
        public UserLogsDataAccess(string constring)
        {
            constr= System.Configuration.ConfigurationManager.
            ConnectionStrings[constring].ConnectionString;
        }
        /// <summary>
        /// method to call "sp_LoginUser" to login and get the user detail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pass"></param>
        /// <returns>user details if successful</returns>
        /// <summary>
        /// Logins the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="pass">The pass.</param>
        /// <returns>DataTable.</returns>
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
        /// <summary>
        /// method to call sp_GetUserLogs to get list of user logs
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>List&lt;System.Object&gt;.</returns>
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

        /// <summary>
        /// Method to get list of count(actions) group by actions
        /// </summary>
        /// <returns>DataTable.</returns>
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