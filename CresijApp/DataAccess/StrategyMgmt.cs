using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CresijApp.Models;
using System.Web.Script.Serialization;

namespace CresijApp.DataAccess
{
    public class StrategyMgmt
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["Organisationdatabase"].ConnectionString;
        public StrategyMgmt() { }
        public StrategyMgmt(string constring) { constr = constring; }
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

        public DataTable GetStrategyById(string Id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * FROM organisationdatabase.strategyservicesandfeature where strategyId ="+Id;
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

        public string AddNewStrategy(Dictionary<string,object> data)
        {
            var result = "0";
            var strname = data["StrategyName"].ToString();
            var strdesc = data["StrategyDescription"].ToString();
            var cdate1 = data["CreatingDate"].ToString();
            var cdate = Convert.ToDateTime(cdate1).ToString("yyyy-MM-dd HH:mm:ss"); 
            var tframe = data["TimeFrame"].ToString();
            var Classlights = new JavaScriptSerializer().Serialize(data["ClassLights"]);
            var Podiumlights = new JavaScriptSerializer().Serialize(data["PodiumLights"]);
            var PodiumCurtainLights = new JavaScriptSerializer().Serialize(data["PodiumCurtainLights"]);
            var ClassroomCurtainLights = new JavaScriptSerializer().Serialize(data["ClassroomCurtainLights"]);
            var ExhaustFan = new JavaScriptSerializer().Serialize(data["ExhaustFan"]);
            var FreshAirSystem = new JavaScriptSerializer().Serialize(data["FreshAirSystem"]);
            var AC1 = new JavaScriptSerializer().Serialize(data["AC1"]);
            var AC2 = new JavaScriptSerializer().Serialize(data["AC2"]);
            var AC3 = new JavaScriptSerializer().Serialize(data["AC3"]);
            var AC4 = new JavaScriptSerializer().Serialize(data["AC4"]);
            var equip = data["TeacherAidEquipments"].ToString();
            var Location = data["Location"].ToString();
            string query = "Insert into strategyservicesandfeature (`StrategyName`,`StrategyDescription`,`CreationDate`,`Timeframe`,"+
                            "`ClassLights`,`podiumLights`,`PodiumCurtainLights`,`ClassroomCurtainLights`,`ExhaustFan`,"+
                                "`FreshAirSystem`,`AC1`,`AC2`,`AC3`,`AC4`,`teacherAidEquipments`,`Location`) values('"+
                                strname+"','"+strdesc+"','"+cdate + "','" +tframe + "','"+Classlights + "','"+Podiumlights
                                + "','"+PodiumCurtainLights + "','"+ClassroomCurtainLights + "','"+ExhaustFan
                                + "','"+FreshAirSystem + "','"+AC1 + "','"+AC2 + "','"+AC3 + "','"+AC4 + "','"+equip
                                + "','"+Location+ "')";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using(MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if(con.State!= ConnectionState.Open)
                    {
                        con.Open();
                        result =cmd.ExecuteNonQuery().ToString();
                    }
                }
            }
            return result;
        }

        public string UpdateStrategy(Dictionary<string, object> data)
        {
            var result = "0";
            var strid = data["StrategyId"].ToString();
            var strname = data["StrategyName"].ToString();
            var strdesc = data["StrategyDescription"].ToString();
            var cdate1 = data["CreatingDate"].ToString();
            var cdate = Convert.ToDateTime(cdate1).ToString("yyyy-MM-dd HH:mm:ss");
            var tframe = data["TimeFrame"].ToString();
            var Classlights = new JavaScriptSerializer().Serialize(data["ClassLights"]);
            var Podiumlights = new JavaScriptSerializer().Serialize(data["PodiumLights"]);
            var PodiumCurtainLights = new JavaScriptSerializer().Serialize(data["PodiumCurtainLights"]);
            var ClassroomCurtainLights = new JavaScriptSerializer().Serialize(data["ClassroomCurtainLights"]);
            var ExhaustFan = new JavaScriptSerializer().Serialize(data["ExhaustFan"]);
            var FreshAirSystem = new JavaScriptSerializer().Serialize(data["FreshAirSystem"]);
            var AC1 = new JavaScriptSerializer().Serialize(data["AC1"]);
            var AC2 = new JavaScriptSerializer().Serialize(data["AC2"]);
            var AC3 = new JavaScriptSerializer().Serialize(data["AC3"]);
            var AC4 = new JavaScriptSerializer().Serialize(data["AC4"]);
            var equip = data["TeacherAidEquipments"].ToString();
            var Location = data["Location"].ToString();
            
            string query = "UPDATE `organisationdatabase`.`strategyservicesandfeature` SET "+
                        "`StrategyName` = '"+strname+"',`StrategyDescription` = '"+strdesc+"', "+
                        "`CreationDate` = '"+cdate1+ "',`Timeframe` = '"+tframe+ "',`ClassLights` = '"+Classlights+"', " +
                        "`podiumLights` = '"+Podiumlights+ "',`PodiumCurtainLights` = '"+PodiumCurtainLights+"'," +
                        "`ClassroomCurtainLights` = '"+ClassroomCurtainLights+"', " +
                        "`ExhaustFan` = '"+ExhaustFan+ "',`FreshAirSystem` = '"+FreshAirSystem+ "',`AC1` = '"+AC1+"', " +
                        "`AC2` = '"+AC2+ "',`AC3` = '"+AC3+"', " +
                        "`AC4` = '"+AC4+ "',`teacherAidEquipments` = '"+equip+"', " +
                        "`Location` = '"+Location+ "' WHERE `StrategyId` = "+strid;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                        result = cmd.ExecuteNonQuery().ToString();
                    }
                }
            }

            return result;
        }


        public DataTable GetteacherAid()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * FROM organisationdatabase.strategyequipments";
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

        public string DeleteStrategyById(string Id)
        {
            string result = "";
            
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "Delete FROM organisationdatabase.strategyservicesandfeature where strategyId =" + Id;
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        result =cmd.ExecuteNonQuery().ToString();
                    }
                }
           
            return result;
        }

        public DataTable GetStrategy()
        {
            DataTable dt = new DataTable();
           
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "select strategyid, strategyname,strategydesc, creationdate, "+
                    "currentstatus,strategytype,"+
                    "group_concat('{\"EquipmentId\":\"',equipmentid,'\", \"EquipmentName\":\"'," +
                    "equipmentsNames,'\", \"config\":{',config,'}, \"location\":\"',location,'\"}') as config," +
                    " strategytimeframe, strategytime from " +
                    "strategymanagement stgm join strategydescription stgd on "+
                    " stgm.strategyId = stgd.StrategyRefId join strategyequipments stgq "+
                    "on stgq.id = stgd.Equipmentid group by strategyid";
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
    }

    public class InterStrategyLogs{
        public int StrategyId { get; set; }
        public int ClassId { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Instruction { get; set; }
        public string ClassName { get; set; }
        public string Status { get; set; }        
    }
    public class StrategyExecCount
    {
        public int Fail { get; set; }
        public int Success { get; set; }
        public int Pending { get; set; }
        public string ClassName { get; set; }   
        public int ClassId { get; set; }
    }
}