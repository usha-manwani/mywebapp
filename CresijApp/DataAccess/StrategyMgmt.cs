// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 08-21-2020
//
// Last Modified By : admin
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="StrategyMgmt.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace CresijApp.DataAccess
{
    /// <summary>
    /// this class is use to deal with database for strategy related operations
    /// </summary>
    /// <summary>
    /// Class StrategyMgmt.
    /// </summary>
    public class StrategyMgmt
    {
        #region Method
        /// <summary>
        /// dedault connection
        /// </summary>
        /// <summary>
        /// The constr
        /// </summary>
        string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["Organisationdatabase"].ConnectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="StrategyMgmt"/> class.
        /// </summary>
        public StrategyMgmt() { }
        /// <summary>
        /// session connection
        /// </summary>
        /// <param name="constring"></param>
        /// <summary>
        /// Initializes a new instance of the <see cref="StrategyMgmt"/> class.
        /// </summary>
        /// <param name="constring">The constring.</param>
        public StrategyMgmt(string constring) { constr = System.Configuration.ConfigurationManager.
            ConnectionStrings[constring].ConnectionString; }
        /// <summary>
        /// Method to call the sp_GetStrategyList to get the list of strategy
        /// </summary>
        /// <param name="data"></param>
        /// <returns>list of strategy</returns>
        /// <summary>
        /// Gets all strategy.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>List&lt;System.Object&gt;.</returns>
        public List<object> GetAllStrategy( Dictionary<string,string>data)
        {
            int totalrows = 0;
            DataTable dt = new DataTable();
            List<object> result = new List<object>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {                    
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetStrategyList", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("_PageIndex", data["pageIndex"].ToString());
                        cmd.Parameters.AddWithValue("_PageSize", data["pageSize"].ToString());
                        cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32);
                        cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                        mySqlDataAdapter.Fill(dt);
                        totalrows = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    }
                }
                result.Add(totalrows);
                result.Add(dt);
            }
            catch (Exception ex) { }
            return result;
        }

        /// <summary>
        /// method to get the devices list from database
        /// </summary>
        /// <returns>devices list</returns>
        /// <summary>
        /// Getteachers the aid.
        /// </summary>
        /// <returns>DataTable.</returns>
        public DataTable GetteacherAid()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * FROM strategyequipments";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }
        /// <summary>
        /// Method to execute any select query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>DataTable.</returns>
        public DataTable ExecuteCommand(string query)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(constr))
            {               
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
            
        }

        /// <summary>
        /// Method to get the strategy execution count for fail,pending and 
        /// success groupby classids by its id for a specific strategy execution
        /// </summary>
        /// <param name="id"></param>
        /// <returns>count of strategy execution </returns>
        /// <summary>
        /// Gets the strategy exectution count.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List&lt;StrategyExecCount&gt;.</returns>
        public List<StrategyExecCount> GetStrategyExectutionCount( int id)
        {
            DataTable dt = new DataTable();
           
            string query = "with cte as(select classname,classid, "+
                " ifnull(concat(case when status = 'Fail' then count(status)  end),0) as 'Fail', "+
                    "ifnull(concat(case when status = 'Pending' then count(status)  end), 0) as 'Pending', "+
                    "ifnull(concat(case when status = 'Success' then count(status)  end), 0) as 'Success' from "+
                    " (select id, Instruction, executiontime, machinemac as classid, cd.ClassName, stmg.strategyId, status"+
                    " from strategylogs log join strategymanagement stmg on "+
                    " log.StrategyDescId = stmg.strategyId join classdetails cd on cd.classid = log.machinemac "+
                        " where log.id in (select id from strategylogs "+
                            " where strategydescid="+id+" and date(ExecutionTime) =date(now()) order by executiontime)" +
                    " and log.equipmentid in "+
                    "(select equipmentid from strategydescription where StrategyRefId = "+id+ 
                    " ) )as c " +
                    " group by classid,status) select classname, classid, max(Fail) as 'Fail',max(Success) as 'Success', "+
                    "max(Pending) as 'Pending' from cte t1 group by classname,classid";
            List<StrategyExecCount> result = new List<StrategyExecCount>();

            using (var con = new MySqlConnection(constr))
            {
                con.Open();
                using(MySqlCommand cmd = con.CreateCommand())
                {                    
                    cmd.CommandText = query;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        var obj = new StrategyExecCount()
                        {
                            Success = Convert.ToInt32(dr["Success"]),
                            Fail = Convert.ToInt32(dr["Fail"]),
                            Pending = Convert.ToInt32(dr["Pending"]),
                            ClassName = dr["classname"].ToString(),
                            ClassId= Convert.ToInt32(dr["classid"])
                        };
                        result.Add(obj);
                    }
                }
            }
            return result;
        }
        #endregion
    }
    #region Data Structure
    /// <summary>
    /// Data structure for Strategy logs
    /// </summary>
    /// <summary>
    /// Class InterStrategyLogs.
    /// </summary>
    public class InterStrategyLogs{
        /// <summary>
        /// Gets or sets the strategy identifier.
        /// </summary>
        /// <value>The strategy identifier.</value>
        public int StrategyId { get; set; }
        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>The class identifier.</value>
        public int ClassId { get; set; }
        /// <summary>
        /// Gets or sets the execution time.
        /// </summary>
        /// <value>The execution time.</value>
        public DateTime ExecutionTime { get; set; }
        /// <summary>
        /// Gets or sets the instruction.
        /// </summary>
        /// <value>The instruction.</value>
        public string Instruction { get; set; }
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
        public string ClassName { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }        
    }
    /// <summary>
    /// Data structure for strategy execution count
    /// </summary>
    /// <summary>
    /// Class StrategyExecCount.
    /// </summary>
    public class StrategyExecCount
    {
        /// <summary>
        /// Gets or sets the fail.
        /// </summary>
        /// <value>The fail.</value>
        public int Fail { get; set; }
        /// <summary>
        /// Gets or sets the success.
        /// </summary>
        /// <value>The success.</value>
        public int Success { get; set; }
        /// <summary>
        /// Gets or sets the pending.
        /// </summary>
        /// <value>The pending.</value>
        public int Pending { get; set; }
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
        public string ClassName { get; set; }
        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>The class identifier.</value>
        public int ClassId { get; set; }
    }
    #endregion
}