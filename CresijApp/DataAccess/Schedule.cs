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
                    string query = "select teachername, coursename, sc.Classname," +
                        " weekstart,weekend, dayno, section, teachingbuilding from schedule sc " +
                        "join classdetails cd on sc.classname =cd.classname "+                        
                        "where sc.classname = '" + name[0] + "' and sc.coursename = '" + name[1] + "' ";
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

        public DataTable GetFreeWeek()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select classname, weekstart, weekend from schedule";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

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
        public int SaveTransferSchedule(string[] name)
        {
            int num = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(constring))
                {

                    using (MySqlCommand cmd = new MySqlCommand("sp_InsertChangeSchedule", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("oldclass", name[0]);
                        cmd.Parameters.AddWithValue("course",name[1]);
                        cmd.Parameters.AddWithValue("reason", name[2]);
                        cmd.Parameters.AddWithValue("weeknum",name[3]);
                        cmd.Parameters.AddWithValue("daynum",name[4]);
                        cmd.Parameters.AddWithValue("sec",name[5]);
                        cmd.Parameters.AddWithValue("buildingname",name[6]);
                        cmd.Parameters.AddWithValue("newcl",name[7]);
                        cmd.Parameters.AddWithValue("teacherid",name[8]);
                       num= cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return num;
        }

        public DataTable GetFreeDay(int weeknum)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select  dayno as day, group_concat(section) as lecture from schedule where weekstart <="+weeknum+"  group by day";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

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
        public DataTable GetScheduleFree()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select classname, weekstart, weekend, dayno, section from schedule";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

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

        public DataTable GetBuilding()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select distinct(teachingbuilding) as building from classdetails order by teachingbuilding";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

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

        public DataTable GetAvailClasses(string week , string building)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select sc.classname, count(section) as section "+
                                "from schedule sc join classdetails cd on sc.classname = cd.classname "+
                                "where weekStart <= "+week+" and weekend>= "+week+" and teachingbuilding = '"+building+"'"+
                                "group by  sc.classname order by sc.classname; ";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

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

        public DataTable GetAvailDay(string week, string classname)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select dayno, group_concat( section) as section from schedule "+
                                "where weekStart<= "+week+ " and weekend>= " + week + " and classname = '"+classname+"' group by dayno ";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

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
        public DataTable GetTeacherDetail(string coursename)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "select distinct(teachername) from schedule where coursename='"+coursename+"'";
                using (MySqlConnection con = new MySqlConnection(constring))
                {

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