using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using CresijApp.DataAccess;
namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for StrategyManagement
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StrategyManagement : WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        private class StrategyDataStructure
        {
            public string StrategyId { get; set; }
            public string StrategyName { get; set; }
            public string StrategyDescription { get; set; }
            public string CreatingDate { get; set; }
            public string TimeFrame { get; set; }
            public dynamic ClassLights { get; set; }
            public dynamic PodiumLights { get; set; }
            public dynamic PodiumCurtainLights { get; set; }
            public dynamic ClassroomCurtainLights { get; set; }
            public dynamic ExhaustFan { get; set; }
            public dynamic FreshAirSystem { get; set; }
            public dynamic AC1 { get; set; }
            public dynamic AC2 { get; set; }
            public dynamic AC3 { get; set; }
            public dynamic AC4 { get; set; }
            public string TeacherAidEquipments { get; set; }
            public string Location { get; set; }
        }

        [WebMethod]
        public Dictionary<string, object> GetStrategyList()
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataAccess.StrategyMgmt strategy = new DataAccess.StrategyMgmt();
            DataTable dt = strategy.GetAllStrategy();
            List<StrategyDataStructure> sd = new List<StrategyDataStructure>();
            idata.Add("status", "success");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    StrategyDataStructure s = new StrategyDataStructure()
                    {
                        StrategyId = dr["strategyId"].ToString(),
                        StrategyDescription = dr["strategyDescription"].ToString(),
                        StrategyName = dr["strategyName"].ToString(),
                        CreatingDate = dr["CreationDate"].ToString(),
                        TimeFrame = dr["timeframe"].ToString(),
                        ClassLights = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["Classlights"].ToString()),
                        PodiumLights = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["Podiumlights"].ToString()),
                        PodiumCurtainLights = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["PodiumCurtainlights"].ToString()),
                        ClassroomCurtainLights = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["ClassroomCurtainlights"].ToString()),
                        ExhaustFan = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["ExhaustFan"].ToString()),
                        FreshAirSystem = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["FreshAirSystem"].ToString()),
                        AC1 = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["AC1"].ToString()),
                        AC2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["AC2"].ToString()),
                        AC3 = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["AC3"].ToString()),
                        AC4 = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["AC4"].ToString()),
                        TeacherAidEquipments = dr["teacherAidEquipments"].ToString(),
                        Location = dr["location"].ToString()
                    };
                    sd.Add(s);
                }
                idata.Add("values", sd);
            }

            return idata;
        }

        [WebMethod]
        public Dictionary<string, object> AddNewStrategy(Dictionary<string, object> data)
        {

            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataAccess.StrategyMgmt strategy = new DataAccess.StrategyMgmt();
            try
            {
                string result = strategy.AddNewStrategy(data);
                idata.Add("status", "success");
                idata.Add("Affected Rows", result);
            }
            catch (Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("ErroMessage", ex.Message);
            }

            return idata;
        }

        [WebMethod]
        public Dictionary<string, object> UpdateStrategy(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataAccess.StrategyMgmt strategy = new DataAccess.StrategyMgmt();
            try
            {
                string result = strategy.AddNewStrategy(data);
                idata.Add("status", "success");
                idata.Add("Affected Rows", result);
            }
            catch (Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("ErroMessage", ex.Message);
            }
            return idata;
        }

        public class TeacherAidStructure
        {
            public string Id{get;set;}
            public string Name { get; set; }
        }

        [WebMethod]
        public Dictionary<string,object> GetTeacherAidsEquip()
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataAccess.StrategyMgmt strategyMgmt = new DataAccess.StrategyMgmt();
            List<TeacherAidStructure> td = new List<TeacherAidStructure>();
            try
            {
                DataTable dt = strategyMgmt.GetteacherAid();
                idata.Add("status", "success");
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        TeacherAidStructure st = new TeacherAidStructure() {
                        Id=dr["id"].ToString(),
                        Name = dr["EquipmentsNames"].ToString()
                        };
                        td.Add(st);
                    }
                }
                idata.Add("value", td);
            }
            catch (Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("ErroMessage", ex.Message);
            }
            return idata;
        }

        [WebMethod]
        public Dictionary<string, object> GetStrategyById(string Id)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataAccess.StrategyMgmt strategy = new DataAccess.StrategyMgmt();
            DataTable dt = strategy.GetStrategyById(Id);
            
            idata.Add("status", "success");
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                StrategyDataStructure s = new StrategyDataStructure()
                {
                    StrategyId = dr["strategyId"].ToString(),
                    StrategyDescription = dr["strategyDescription"].ToString(),
                    StrategyName = dr["strategyName"].ToString(),
                    CreatingDate = dr["CreationDate"].ToString(),
                    TimeFrame = dr["timeframe"].ToString(),
                    ClassLights = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["Classlights"].ToString()),
                    PodiumLights = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["Podiumlights"].ToString()),
                    PodiumCurtainLights = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["PodiumCurtainlights"].ToString()),
                    ClassroomCurtainLights = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["ClassroomCurtainlights"].ToString()),
                    ExhaustFan = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["ExhaustFan"].ToString()),
                    FreshAirSystem = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["FreshAirSystem"].ToString()),
                    AC1 = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["AC1"].ToString()),
                    AC2 = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["AC2"].ToString()),
                    AC3 = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["AC3"].ToString()),
                    AC4 = JsonConvert.DeserializeObject<Dictionary<string, string>>(dr["AC4"].ToString()),
                    TeacherAidEquipments = dr["teacherAidEquipments"].ToString(),
                    Location = dr["location"].ToString()
                };
                idata.Add("values", s);
            }
            return idata;
        }

        [WebMethod]
        public Dictionary<string, object> DeleteStrategyById(string Id)
        {

            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataAccess.StrategyMgmt strategy = new DataAccess.StrategyMgmt();
            try
            {
                string result = strategy.DeleteStrategyById(Id);
                idata.Add("status", "success");
                idata.Add("Affected Rows", result);
            }
            catch (Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("ErroMessage", ex.Message);
            }

            return idata;
        }

        public class StrategyStructure
        {
            public int Id { get; set; }
            public string StrategyName { get; set; }
            public string StrategyDesc { get; set; }
            public string CreationDate { get; set; }
            public string CurrentStatus { get; set; }
            public string StrategyType { get; set; }
            public dynamic Configuration { get; set; }
            //public string Location { get; set; }
            public string StrategyTimeFrame { get; set; }
            public string StrategyTime { get; set; }

        }
        [WebMethod]
        public Dictionary<string,object> GetStrategy()
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            try
            {
                List<StrategyStructure> strategies = new List<StrategyStructure>();
                StrategyMgmt strategyMgmt = new StrategyMgmt();
                DataTable dt = strategyMgmt.GetStrategy();
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        StrategyStructure st = new StrategyStructure()
                        {
                            Id = Convert.ToInt32(dr["strategyid"]),
                            StrategyName =dr["strategyname"].ToString(),
                            StrategyDesc =dr["strategydesc"].ToString(),
                            CreationDate = DateTime.Parse(dr["creationdate"].ToString()).ToString("yyyy-MM-dd H:mm:ss"),
                            CurrentStatus =dr["currentstatus"].ToString(),
                            StrategyType =dr["strategytype"].ToString(),
                            
                            StrategyTimeFrame=dr["strategytimeframe"].ToString(),
                            StrategyTime =dr["strategytime"].ToString(),
                            Configuration = JsonConvert.DeserializeObject<Dictionary<dynamic,dynamic>>(dr["config"].ToString())
                        };
                        strategies.Add(st);
                    }
                }

                idata.Add("status", "success");
                idata.Add("value", strategies);
            }
            catch(Exception ex)
            {

            }
            
            return idata;
        }
    }
}
