using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace CresijApp.DataAccess
{
    public class UserAuth
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;
        public int SaveAuthMenu(string[] data, string userid, string adminid, string[] classnames)
        {
            int result = 0;
            int userserial = 0, adminserial = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string q = "select serialno, loginid from userdetails where loginid in('" + userid + "','" + adminid + "')";
                using (MySqlCommand cmd = new MySqlCommand(q, con))
                {
                    try
                    {
                        con.Open();
                        MySqlDataAdapter mySqlData = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        mySqlData.Fill(dt);
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

                            var query1 = "insert into userlocationaccess(`userserialnum`,`classid`,`AuthenticatedBy`) values ";
                            StringBuilder d1 = new StringBuilder();
                            foreach (string s in classnames)
                            {
                                d1.Append("(" + userserial + ", '" + s + "'," + adminserial + "),");
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
        public DataTable GetUserSubMenu(Dictionary<string,object> data)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "select distinct(rolename) as rolenames from roledetails where rolename like '%"+data["subMenuType"]+"%' and "+
                        " id in (select roleid from userpermissions where userserialnum = " +
                        "(select serialno from userdetails where loginid = '"+data["userId"]+"'))";
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

        public int DeleteUserPermissions(string id)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "delete from userpermissions where userserialnum = " +
                        "(select serialno from userdetails where loginid = '" + id + "'); "+
                        "delete from userlocationaccess where userserialnum  = " +
                        "(select serialno from userdetails where loginid = '" + id + "');";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    result = -1;
                }
                finally
                {
                    con.Close();
                }
            }

            return result;
        }

        public DataTable GetUserAllSubMenu(string data)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
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

        public DataTable GetUserAllLocationAccess(string data)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "select distinct(classid) as classname from userlocationaccess where " +
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