// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 07-13-2020
//
// Last Modified By : admin
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="UserAuth.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CresijApp.DataAccess
{
    /// <summary>
    /// This class contains methods to deal with database to
    /// user permissions for menu options and location accesses.
    /// CRUD Operations is done on the Permissions
    /// </summary>
    /// <summary>
    /// Class UserAuth.
    /// </summary>
    public class UserAuth
    {
        /// <summary>
        /// default connection
        /// </summary>
        
        string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["Organisationdatabase"].ConnectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuth"/> class.
        /// </summary>
        public UserAuth() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAuth"/> class.
        /// </summary>
        /// <param name="constring">The constring.</param>
        public UserAuth(string constring) { constr = System.Configuration.ConfigurationManager.
            ConnectionStrings[constring].ConnectionString; }
        /// <summary>
        /// method to insert or update the user permissions related to menu and locations
        /// </summary>
        /// <param name="data"></param>
        /// <param name="userid"></param>
        /// <param name="adminid"></param>
        /// <param name="classnames"></param>
        /// <returns>no of affected record</returns>
        
        public int SaveAuthMenu(string[] data, string userid, string adminid, string[] classnames)
        {
            int result = 0;
            int userserial = 0, adminserial = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string q = "select serialno, loginid from userdetails where loginid in('" + userid + "','" + adminid + "')";
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {

                        con.Open();
                        MySqlDataAdapter mySqlData = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        mySqlData.Fill(dt);
                    if (dt.Rows.Count == 2)
                    {
                        if (dt.Rows[0][1].ToString() == adminid)
                        {
                            adminserial = Convert.ToInt32(dt.Rows[0][0]);
                            userserial = Convert.ToInt32(dt.Rows[1][0]);
                        }
                        else
                        {
                            userserial = Convert.ToInt32(dt.Rows[0][0]);
                            adminserial = Convert.ToInt32(dt.Rows[1][0]);
                        }

                    }
                    else if(dt.Rows.Count==1 && adminid==userid)
                    {
                        adminserial = Convert.ToInt32(dt.Rows[0][0]);
                        userserial = Convert.ToInt32(dt.Rows[0][0]);
                    }
                    if (userserial != 0)
                            {
                                var query = "insert into userpermissions(`userserialnum`,`roleid`,`AuthenticatedBy`) values ";
                                StringBuilder d = new StringBuilder();
                                foreach (string s in data)
                                {
                                    d.Append("(" + userserial + ", " + s + "," + adminserial + "),");
                                }
                                d.Remove(d.Length - 1, 1);
                                query = query + d.ToString();
                                using (MySqlCommand cmd1 = new MySqlCommand(query, con))
                                {
                                    if (con.State != ConnectionState.Open)
                                        con.Open();
                                    result = cmd1.ExecuteNonQuery();
                                }
                                if (classnames.Length > 0)
                                {
                                    var query1 = "insert into userlocationaccess(`userserialnum`,`locationid`,`AuthenticatedBy`, `Level`) values ";
                                    StringBuilder d1 = new StringBuilder();
                                    foreach (string s in classnames)
                                    {
                                        d1.Append("(" + userserial + ", '" + s + "'," + adminserial + ",'Class'),");
                                    }
                                    d1.Remove(d1.Length - 1, 1);
                                    query1 = query1 + d1.ToString();
                                    using (MySqlCommand cmd2 = new MySqlCommand(query1, con))
                                    {
                                        if (con.State != ConnectionState.Open)
                                            con.Open();
                                        result = cmd2.ExecuteNonQuery();
                                    }
                                }
                                
                            }
                        
                        

                }
            }
            return result;

        }

        /// <summary>
        /// query to get top menu options accessed by the userid
        /// </summary>
        /// <param name="userid"></param>
        /// <returns>list of top menu options</returns>
        
        public DataTable GetUserTopMenu(string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "select rolename as rolenames from roledetails where id in (select roleid from userpermissions where " +
                        "userserialnum in(select serialno from userdetails where loginid='" + userid + "'))";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        MySqlDataAdapter mySqlData = new MySqlDataAdapter(cmd);

                        mySqlData.Fill(dt);
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
        /// <summary>
        /// query to get submenu options by top menu option type and userid
        /// </summary>
        /// <param name="subMenuType">Type of the sub menu.</param>
        /// <param name="userid">The userid.</param>
        /// <returns>list of submenu options</returns>
        public DataTable GetUserSubMenu(string subMenuType, string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "select distinct(rolename) as rolenames from roledetails where rolename like '%"+subMenuType+"%' and "+
                        " id in (select roleid from userpermissions where userserialnum = " +
                        "(select serialno from userdetails where loginid = '"+userid+"'))";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        MySqlDataAdapter mySqlData = new MySqlDataAdapter(cmd);

                        mySqlData.Fill(dt);
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
        /// <summary>
        /// method to delete all location access of a user by its id
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>no. of affected records</returns>
        public int DeleteUserPermissions(string id)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
               
                    string query = "delete from userpermissions where userserialnum = " +
                        "(select serialno from userdetails where loginid = '" + id + "'); "+
                        "delete from userlocationaccess where userserialnum  = " +
                        "(select serialno from userdetails where loginid = '" + id + "');";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        result =cmd.ExecuteNonQuery();
                    }
                    
            }

            return result;
        }
        /// <summary>
        /// Get all submenus authorized to user
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetUserAllSubMenu(string data)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                
                    string query = "select distinct(roleid) as roleid from userpermissions where userserialnum = " +
                        "(select serialno from userdetails where loginid = '" + data + "')";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        MySqlDataAdapter mySqlData = new MySqlDataAdapter(cmd);

                        mySqlData.Fill(dt);
                    }
                
            }

            return dt;
        }
        /// <summary>
        /// get all classids accessed by user
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>list of classids</returns>
        public DataTable GetUserAllLocationAccess(string data)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                    string query = "select distinct(locationid) as classname from userlocationaccess where Level ='Class' and " +
                        " userserialnum = " +
                        "(select serialno from userdetails where loginid = '" + data + "')";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        MySqlDataAdapter mySqlData = new MySqlDataAdapter(cmd);

                        mySqlData.Fill(dt);
                    }
                
            }

            return dt;
        }
    }
}