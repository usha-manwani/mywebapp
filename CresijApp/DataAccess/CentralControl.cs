using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CresijApp.DataAccess
{
    public class CentralControl
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["CresijCamConnectionString"].ConnectionString;

        public void SaveDatainDatabase(string sender, string data)
        {
            string[] status = data.Split(',');

            string s = "";
            if (status[2] == "在线")
                s = "Online";
            else
                s = "Offline";
            string t = "";
            if (status[3] == "运行中")
                t = "OPEN";
            else if (status[3] == "待机")
                t = "CLOSED";

            string u = "";
            if (status[5] == "已关机")
                u = "Off";
            else if (status[5] == "已开机")
                u = "On";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdateStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ip", sender);

                        cmd.Parameters.AddWithValue("@mstat", s);

                        cmd.Parameters.AddWithValue("@wstat", t);

                        cmd.Parameters.AddWithValue("@cstat", u);

                        try
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }
                            cmd.ExecuteNonQuery();
                        }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                        catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                        {
                            // Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                finally
                {
                    con.Close();
                }
            }
        }

        public DataSet ControlDetails(string InsID)
        {

            DataSet ds = new DataSet();
            //DataTable dt;
            using (MySqlConnection connection = new MySqlConnection(constr))
            {
                string query = "SELECT gd.Grade_Name as Grade, ip as CCIP,cd.ClassName as loc, " +
                     " Status,workstatus as PowerStatus,Timer as TimerService,pcstatus as ComputerPower" +
                     ",projectorstatus as ProjectorPower, " +
                   " Projhour as ProjectorUsedHour, Curtain as CurtainStatus, Screen as ScreenStatus," +
                     " light, MediaSignal, centrallock , " +
                     " PodiumLock, ClassLock, temperature, humidity," +
                     " pm25, pm10 from `cresijdatabase`.temp_centralcontrol cc" +
                    " join `cresijdatabase`.Class_Details cd on cc.loc = cd.id" +
                     " join `cresijdatabase`.Grade_Details gd on gd.id = cd.GradeID" +
                     " where cc.loc in " +
                     " (select id from `cresijdatabase`.Class_Details where GradeID in " +
                    " (select id from `cresijdatabase`.Grade_Details where insid = " + InsID + ")) " +
                     " order by gd.id, cd.ClassName";
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {

                        //command.Notification = null;
                        //dt = new DataTable();

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(command);
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

        #region cam
        public DataTable CamDetails(string loc)
        {
            DataTable dtcam = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select CameraIP, user_id, password, port from Camera_Details where location in (select id from class_details where classid = '" + loc + "')";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dtcam);

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
            return dtcam;
        }
        #endregion

        public DataTable GetStatusOnGrade(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT gd.Grade_Name as Grade, ip as CCIP,cd.ClassName as loc, " +
                      "Status,workstatus as PowerStatus,Timer as TimerService,pcstatus as ComputerPower " +
                     ",projectorstatus as ProjectorPower,  " +
                   "Projhour as ProjectorUsedHour, Curtain as CurtainStatus, Screen as ScreenStatus, " +
                      "light, MediaSignal, centrallock ,  " +
                      "PodiumLock, ClassLock, temperature, humidity, " +
                      "pm25, pm10 from `cresijdatabase`.temp_centralcontrol cc " +
                     "join `cresijdatabase`.Class_Details cd on cc.loc = cd.id " +
                      "join `cresijdatabase`.Grade_Details gd on gd.id = cd.GradeID " +
                      "where cc.loc in (select id from `cresijdatabase`.Class_Details where " +
                      "GradeID = " + id + ") order by gd.id, cd.ClassName";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    try
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();

                        mySqlDataAdapter.Fill(dt);
                    }
                    catch (Exception ex) { }
                    finally
                    {
                        mySqlDataAdapter.Dispose();
                        con.Close();
                    }
                }
            }
            return dt;
        }
        public DataTable Getlocation(string ip)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    string query = "select id.Ins_Name as InsName, gd.Grade_Name as GradeName, " +
                    "cd.ClassName as ClassName from Institute_Details id join Grade_Details gd on " +
                    "gd.InsID = id.ID join Class_Details cd on cd.GradeID = gd.ID " +
                    "join CentralControl cc on cc.location = cd.ID where cc.CCIP = '" + ip + "'";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                            da.Fill(dt);
                        }
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
                finally
                {
                    con.Close();
                }
                return dt;
            }
        }
        public string GetIp( string name)
        {
            string ip = "";
            using(MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select ccip from CentralControl where location in (select id from class_details where classid = '" + name + "')";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    ip = cmd.ExecuteScalar().ToString();
                }
            }
            return ip;
        }
    }
}