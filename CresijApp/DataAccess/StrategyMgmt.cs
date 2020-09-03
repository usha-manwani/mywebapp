using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace CresijApp.DataAccess
{
    public class StrategyMgmt
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;

        public DataTable GetAllStrategy()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * FROM organisationdatabase.strategyservicesandfeature";
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
                    string query = "SELECT * FROM organisationdatabase.teacheraidequipments";
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
            try
            {
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
            }
            catch (Exception ex) { }
            return result;
        }
    }
}