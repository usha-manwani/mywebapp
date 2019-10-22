using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;

namespace WebCresij.UserActivities
{
    public class UserLogs
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        public static void Task1(string UserID, string Name, int tasknumber)
        {
            string task = TaskName(tasknumber);
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertUserLogs", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", UserID);
                    //cmd.Parameters.AddWithValue("@userName", Name);
                    cmd.Parameters.AddWithValue("@task", task);
                    if(con.State!= ConnectionState.Open)
                    {
                        con.Open();
                    }
                    try
                    {
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
        private static string TaskName(int tasknumber)
        {
            
            if (tasknumber == 1)
            {
                
                return TaskList.Task1;
            }
            else if (tasknumber == 2)
            {
                return TaskList.Task2;
            }
            else if (tasknumber == 3)
            {
                return TaskList.Task3;
            }
            else if (tasknumber == 4)
            {
                return TaskList.Task4;
            }
            else if (tasknumber == 5)
            {
                return TaskList.Task5;
            }
            else if (tasknumber == 6)
            {
                return TaskList.Task6;
            }
            else if (tasknumber == 7)
            {
                return TaskList.Task7;
            }

            else if (tasknumber == 8)
            {
                return TaskList.Task8;
            }
            else if (tasknumber == 9)
            {
                return TaskList.Task9;
            }
            else if (tasknumber == 10)
            {
                return TaskList.Task10;
            }
            else if (tasknumber == 11)
            {
                return TaskList.Task11;
            }
            else if (tasknumber == 12)
            {
                return TaskList.Task12;
            }
            else if (tasknumber == 13)
            {
                return TaskList.Task13;
            }
            else 
            {
                return TaskList.Task14;
            }

        }
        public static void LoggedinUser(string userID)
        {           
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertCurrentUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("userid", userID);
                    if(con.State != ConnectionState.Open)
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void LoggedOutUser(string userID)
        {
            string query = "Delete from Current_LoggedUser where userid ='" + userID + "'";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static DataTable LogsRecord()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select * from user_logs order by Time desc";
                try
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        da.Fill(dt);
                    }
                }
                catch
                {

                }
                finally
                {
                    con.Close();
                }
                return dt;
            }
        }

        public static int CurrentUser()
        {
            int count = 0;
            string query = "SELECT count(distinct userid) FROM current_loggeduser";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        
                    }
                    try
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());   
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
            return count;

        }

        public static int TotalUser()
        {
            int count = 0;
            string query = "SELECT count(*) FROM user_details";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();

                    }
                    try
                    {
                        count = Convert.ToInt32(cmd.ExecuteScalar());
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
            return count;

        }
    }
    public class TaskList
    {
        public static string Task1 { get; } = "Login";
        public static string Task2 { get; } = "Logout";
        public static string Task3 { get; } = "Updated Institute, Grade or Class Details";
        public static string Task4 { get; } = "Performed User related actions";
        public static string Task5 { get; } = "Uploaded document";
        public static string Task6 { get; } = "Downloaded Document";
        public static string Task7 { get; } = "Deleted Document";
        public static string Task8 { get; } = "Played audio video file";
        public static string Task9 { get; } = "Registered new IC Card";
        public static string Task10 { get; } = "Edited IC Card Details";
        public static string Task11 { get; } = "Edited Schedule";
        public static string Task12 { get; } = "Visited Status Page";
        public static string Task13 { get; } = "Visited Configuration Settings Page";        
        public static string Task14 { get; } = "Visited Machine Control Page";            

    }
}