using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CresijApp.DataAccess
{
    public class Schedule
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        readonly string constring = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;
        //public DataTable GetSchedule()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        using (MySqlConnection con = new MySqlConnection(constr))
        //        {
        //            string query = "select concat_ws(', ',teacherName, Coursename, classname, weekstart, weekEnd, dayno, section)" +
        //                           " as details , dayno, classname from scheduletable";
        //            using (MySqlCommand cmd = new MySqlCommand(query, con))
        //            {
        //                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
        //                dataAdapter.Fill(dt);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }

        //    return dt;
        //}
        public DataTable GetCourse()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    string query = "select  section,className, coursename, id from schedule";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dt;
        }
        public DataTable GetSchedule()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand("sp_GetSchedule", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dt;
        }

        public DataTable GetCourseDetails(string[] name)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {
                    string query = "select teachername, coursename, cs.Classname, " +
                        "teachingbuilding, weekstart,weekend, dayno, section from schedule sc" +
                        " join classdetails cs on sc.Classname = cs.classname " +
                        "where sc.classname = '" + name[0] + "' and coursename = '" + name[1] + "' ";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return dt;

        }
    }
}