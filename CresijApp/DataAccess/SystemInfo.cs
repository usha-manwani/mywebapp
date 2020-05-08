﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CresijApp.DataAccess
{
    
    public class SystemInfo
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;
        public int SaveSystemInfo(string schoolname, string schooleng, string logourl, string semname, string weeks,string semstartdate, Dictionary<string,string> days)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_insertSystemInfo", con)) // sp_SaveTempData
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@schname", schoolname);
                        cmd.Parameters.AddWithValue("@scheng", schooleng);
                        cmd.Parameters.AddWithValue("@logoloc", logourl);
                        cmd.Parameters.AddWithValue("@semname", semname);
                        cmd.Parameters.AddWithValue("@semweeks", weeks);
                        cmd.Parameters.AddWithValue("@semstart", semstartdate);
                        cmd.Parameters.AddWithValue("@sun", days["Sunday"]);
                        cmd.Parameters.AddWithValue("@mon", days["Monday"]);
                        cmd.Parameters.AddWithValue("@tue", days["Tuesday"]);
                        cmd.Parameters.AddWithValue("@wed", days["Wednesday"]);
                        cmd.Parameters.AddWithValue("@thu", days["Thursday"]);
                        cmd.Parameters.AddWithValue("@fri", days["Friday"]);
                        cmd.Parameters.AddWithValue("@sat", days["Saturday"]);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result=cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
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

        public int SaveSectionsInfo()
        {
            return 0;
        }
        public int SaveReserveAndTransferInfo(string typ, string nonwork, string auto, string start,string end, string semname)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand("sp_InsertUpdateReserverTransfer", con)) // sp_SaveTempData
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@typ", typ);
                        cmd.Parameters.AddWithValue("@nonwork", nonwork);
                        cmd.Parameters.AddWithValue("@autoreview", auto);
                        cmd.Parameters.AddWithValue("@semname", semname);
                        cmd.Parameters.AddWithValue("@startdate", start);
                        cmd.Parameters.AddWithValue("@enddate", end);
                        
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result = cmd.ExecuteNonQuery();
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
    }
}