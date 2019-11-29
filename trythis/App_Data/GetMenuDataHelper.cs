using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCresij
{
    public class GetMenuDataHelper
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings
            ["CresijCamConnectionString"].ConnectionString;
        public DataTable GetInstitutes()
        {
            DataTable dt = new DataTable();
            string query = "Select Ins_id, Ins_name from Institute_Details";
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }

            }
            return dt;
        }
        // Get Grade according to Ins
        public DataTable GetGrades(string ins)
        {
            DataTable dt = new DataTable();
            string query = "Select Grade_id, Grade_name from Grade_Details gd where " +
                "insid in ( select id from institute_details where ins_id ='" + ins + "')";
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
            }
            return dt;
        }
        //GEt Classes according to grade
        public DataTable GetClasses(string grade)
        {
            DataTable dt = new DataTable();
            string query = "Select classid, classname from class_Details cd where " +
                "gradeid in ( select id from Grade_details where grade_id ='" + grade + "')";
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {

                }
            }
            return dt;
        }
    }
}