// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 03-08-2021
//
// Last Modified By : admin
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="HistoryDataAccessHelper.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace CresijApp.DataAccess
{
    /// <summary>
    /// Class HistoryDataAccessHelper.
    /// </summary>
    public class HistoryDataAccessHelper
    {
        /// <summary>
        /// The constr
        /// </summary>
        string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["Organisationdatabase"].ConnectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryDataAccessHelper"/> class.
        /// </summary>
        public HistoryDataAccessHelper()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryDataAccessHelper"/> class.
        /// </summary>
        /// <param name="constring">The constring.</param>
        public HistoryDataAccessHelper(string constring)
        {
            constr = System.Configuration.ConfigurationManager.
            ConnectionStrings[constring].ConnectionString;
        }
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>DataTable.</returns>
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