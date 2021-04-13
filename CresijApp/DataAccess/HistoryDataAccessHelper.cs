using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace CresijApp.DataAccess
{
    public class HistoryDataAccessHelper
    {
        string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["Organisationdatabase"].ConnectionString;
        public HistoryDataAccessHelper()
        {

        }
        public HistoryDataAccessHelper(string constring)
        {
            constr = constring;
        }
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using(var con = new MySqlConnection(constr))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                    ad.Fill(dt);
                }
            }
            return dt;
        }
        
    }
}