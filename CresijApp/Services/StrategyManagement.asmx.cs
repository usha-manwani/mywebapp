using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using CresijApp.DataAccess;
using CresijApp.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for StrategyManagement
    /// This class is use to deal with Strategy and Strategy Description Records in Database
    /// The methods available in this class are for CRUD Operation on Strategy
    /// and Strategy Description Records in Database
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StrategyManagement : WebService
    {
        #region Web Methods
        /// <summary>
        /// Method to get the list of Strategy records with status of execution
        /// </summary>
        /// <param name="data"></param>
        /// <returns>List of StrategyDataStructure</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetStrategyList( Dictionary<string,string>data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            StrategyMgmt strategy = new StrategyMgmt(HttpContext.Current.Session["DBConnection"].ToString());
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                List<object> datalist = strategy.GetAllStrategy(data);
                DataTable dt = datalist[1] as DataTable;
                List<StrategyDataStructure> sd = new List<StrategyDataStructure>();
                idata.Add("status", "success");
                idata.Add("totalRows", datalist[0].ToString());
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var classids = dr["location"].ToString();
                        var query = "select group_concat(distinct(buildingname) separator ',')as buildname from buildingdetails where id in (select " +
                            "teachingbuilding from classdetails where classid in (" + classids + "))";
                        DataTable dt1 = strategy.ExecuteCommand(query);
                        var buildnames = dt1.Rows[0]["buildname"].ToString();

                        
                        StrategyDataStructure s = new StrategyDataStructure()
                        {
                            StrategyId = dr["strategyId"].ToString(),
                            StrategyDescription = dr["strategyDesc"].ToString(),
                            StrategyName = dr["strategyName"].ToString(),
                            CreatingDate = dr["CreationDate"].ToString(),
                            TimeFrame = dr["timeframe"].ToString(),
                            StrategyType = dr["strategytype"].ToString(),
                            Location = buildnames.Split(','),
                            CurrentStatus =dr["CurrentStatus"].ToString(),
                            Fail=Convert.ToInt32(dr["Fail"]),
                            Success=Convert.ToInt32(dr["Success"])
                            
                        };
                        sd.Add(s);
                    }
                    idata.Add("values", sd);
                }
            }
            return idata;
        }

        /// <summary>
        /// Method to Add new Strategy Record
        /// </summary>
        /// <param name="data">
        /// "data" contains params list: "StrategyLocation","StrategyId","CurrentStatus","StrategyName",
        /// "StrategyDesc","StrategyType","StrategyServices"
        /// "StrategyServices" contains params list: "EquipmentId","StrategyTime","StrategyTimeFrame1",
        /// "StrategyTimeFrame2","ServiceConfig"</param>
        /// <returns>Success/fail result with no of rows inserted</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> AddNewStrategy(Dictionary<string, object> data)
        {
            int result = 0;
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, object> idata = new Dictionary<string, object>();
            
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    var temp = js.Serialize(data["StrategyLocation"]);
                    var loc = js.Deserialize<string[]>(temp);
                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        strategymanagement stmgmt = new strategymanagement()
                        {
                            StrategyDesc = data["StrategyDesc"].ToString() ?? "",
                            strategyname = data["StrategyName"].ToString() ?? "",
                            StrategyLocation = string.Join(",", loc) ?? "",
                            CreationDate = DateTime.Now,
                            strategyType = data["StrategyType"].ToString(),
                            CurrentStatus = Convert.ToSByte(data["CurrentStatus"].ToString() == "true" ? 1 : 0),
                        };
                        context.strategymanagements.Add(stmgmt);
                        result = context.SaveChanges();
                        int stmgmtid = stmgmt.strategyId;
                        var obj = js.Serialize(data["StrategyServices"]);
                        var strategyServices = js.Deserialize<List<StrategyServiceStructure>>(obj);

                        List<strategydescription> scd = new List<strategydescription>();
                        foreach (var r in strategyServices)
                        {                            
                            strategydescription sc = new strategydescription()
                            {
                                StrategyRefId = stmgmtid,
                                Equipmentid = Convert.ToInt32(r.EquipmentId),
                                strategyTime = r.StrategyTime??"",
                                StrategyTimeFrame1 = r.StrategyTimeFrame1,
                                StrategyTimeFrame2 = r.StrategyTimeFrame2??"",
                                Config = new JavaScriptSerializer().Serialize(r.ServiceConfig) ?? ""
                            };
                            scd.Add(sc);
                        }

                        context.strategydescriptions.AddRange(scd);
                        context.SaveChanges();
                    }
                    idata.Add("status", "success");
                    idata.Add("totalRows", result);
                }
                catch (DbEntityValidationException e)
                {
                    idata.Add("status", "fail");
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            var mess = "property: " + ve.PropertyName + " value: " +
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName) +
                                " has the following validation errors:" + ve.ErrorMessage;
                            idata.Add("ErroMessage", mess);
                        }                       
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("ErroMessage", ex.Message);
                }
                
            }
            return idata;
        }

        /// <summary>
        /// Method to update strategy record 
        /// </summary>
        /// <param name="data">
        /// "data" contains params list: "StrategyLocation","StrategyId","CurrentStatus","StrategyName",
        /// "StrategyDesc","StrategyType","StrategyServices"
        /// "StrategyServices" contains params list: "EquipmentId","StrategyTime","StrategyTimeFrame1",
        /// "StrategyTimeFrame2","ServiceConfig"
        /// </param>
        /// <returns>No of rows updated with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> UpdateStrategy(Dictionary<string, object> data)
        {
            int result = 0;
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, object> idata = new Dictionary<string, object>();
            
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    var temp = js.Serialize(data["StrategyLocation"]);
                    var loc = js.Deserialize<string[]>(temp);
                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        var strategylocation = string.Join(",", loc) ?? "";
                        var stid = Convert.ToInt32(data["StrategyId"]);
                        var stg = context.strategymanagements.Find(stid);
                        if (stg != null)
                        {
                            stg.StrategyLocation = strategylocation;
                            stg.CurrentStatus = Convert.ToSByte(Convert.ToBoolean(data["CurrentStatus"])? 1 : 0);
                            stg.strategyname = data["StrategyName"].ToString();
                            stg.StrategyDesc = data["StrategyDesc"].ToString() ?? "";
                            stg.strategyType = data["StrategyType"].ToString();
                        }
                            
                        var list = context.strategydescriptions.Where(x => x.StrategyRefId == stid);
                        foreach (var v in list)
                            context.strategydescriptions.Remove(v);

                        var obj = js.Serialize(data["StrategyServices"]);
                        var strategyServices = js.Deserialize<List<StrategyServiceStructure>>(obj);
                        List<strategydescription> scd = new List<strategydescription>();
                        foreach (var r in strategyServices)
                        {
                            
                            strategydescription sc = new strategydescription()
                            {
                                StrategyRefId = stid,
                                Equipmentid = Convert.ToInt32(r.EquipmentId),
                                strategyTime = r.StrategyTime ?? "",
                                StrategyTimeFrame1 = r.StrategyTimeFrame1,
                                StrategyTimeFrame2 =r.StrategyTimeFrame2??"",
                                Config = new JavaScriptSerializer().Serialize(r.ServiceConfig) ?? ""
                            };
                            scd.Add(sc);
                        }
                        context.strategydescriptions.AddRange(scd);
                       result= context.SaveChanges();
                    }
                    idata.Add("status", "success");
                    idata.Add("Affected Rows", result);
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("ErroMessage", ex.Message);
                }
            }
            return idata;
        }

        /// <summary>
        /// Method to get strategy Equipments with name and id to add new equipments into the strategy
        /// </summary>
        /// <returns>List of TeacherAidStructure</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetStrategyEquipments()
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataAccess.StrategyMgmt strategyMgmt = new StrategyMgmt();
            List<TeacherAidStructure> td = new List<TeacherAidStructure>();

            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    DataTable dt = strategyMgmt.GetteacherAid();
                    idata.Add("status", "success");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            TeacherAidStructure st = new TeacherAidStructure()
                            {
                                Id = dr["id"].ToString(),
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
            }
            return idata;
        }

        /// <summary>
        /// method to get Strategy by its id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>StrategyDescStructure</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetStrategyById(string Id)
        {
            
            Dictionary<string, object> idata = new Dictionary<string, object>();
            
            int val = Convert.ToInt32(Id);
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        List<StrategyDescStructure> dataset = (from p in context.strategydescriptions
                                       join e in context.strategyequipments 
                                       on p.Equipmentid equals e.id
                                       where p.StrategyRefId == val
                                       select new
                                       {
                                           StrategyDescId = p.id,
                                           p.StrategyTimeFrame1,
                                           p.StrategyTimeFrame2,
                                           EquipmentId = e.id,
                                           EquipmentName = e.EquipmentsNames,
                                           ServiceConfig =  p.Config ?? "",
                                           StrategyTime = p.strategyTime.ToString()
                                       }).AsEnumerable().Select(x=>new StrategyDescStructure {
                                           StrategyDescId = x.StrategyDescId,
                                           StrategyTimeFrame1 = x.StrategyTimeFrame1,
                                           StrategyTimeFrame2 = x.StrategyTimeFrame2,
                                           EquipmentId =x.EquipmentId,
                                           EquipmentName =x.EquipmentName,
                                           ServiceConfig = new JavaScriptSerializer().DeserializeObject(x.ServiceConfig),
                                           StrategyTime =x.StrategyTime
                                       }).ToList();

                        
                        var location = context.strategymanagements.Where(x => x.strategyId == val)
                            .Select(p => p.StrategyLocation).First().Split(',');
                        idata.Add("status", "success");
                        
                        idata.Add("value", dataset);
                        idata.Add("location", location);
                    }

                }
                catch
                {

                }
            }
            return idata;
        }
        /// <summary>
        /// Delete single or multiple strategy by its id
        /// </summary>
        /// <param name="data"></param>
        /// <returns>No of rows deleted along with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> DeleteStrategyById(List<string> data)
        {
            int result = 0;
            Dictionary<string, object> idata = new Dictionary<string, object>();

            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {

                try
                {
                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        foreach (string id in data)
                        {
                            var tempid = Convert.ToInt32(id);
                            var instance = context.strategymanagements.Where(x => x.strategyId == tempid).First();
                            
                            if (instance != null) context.strategymanagements.Remove(instance);
                        }
                        result = context.SaveChanges();
                    }
                    idata.Add("status", "success");
                    idata.Add("Affected Rows", result);
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("ErroMessage", ex.Message);
                }
            }
            return idata;
        }

        /// <summary>
        /// Method to update strategy Status from Inactive to Active and viceversa
        /// </summary>
        /// <param name="data"></param>
        /// <returns>affected rows with success/fail result </returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> UpdateStrategyStatus(Dictionary<string,string> data)
        {
            int result = 0;
            Dictionary<string, string> idata = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        var tempid = Convert.ToInt32(data["Id"]);
                        var stat = Convert.ToSByte(Convert.ToBoolean(data["CurrentStatus"])?1:0);
                        var instance = context.strategymanagements.Where(x => x.strategyId == tempid).First();

                        if (instance != null)
                            instance.CurrentStatus = stat;
                        result=context.SaveChanges();
                        idata.Add("status", "success");
                        idata.Add("Affected Rows", result.ToString());
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("ErroMessage", ex.Message);
                }
            }
            return idata;
        }
        /// <summary>
        /// Method to get count of strategy execution based on its strategy id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>COunt of executions with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetStrategyCount(int id)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<StrategyExecCount> result = new List<StrategyExecCount>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    StrategyMgmt st = new StrategyMgmt(HttpContext.Current.Session["DBConnection"].ToString());
                    result = st.GetStrategyExectutionCount(id);
                    idata.Add("value", result);
                }

                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }
        #endregion
        #region Method not in use. Can be deleted
        /// <summary>
        /// Method to get list of strategy
        /// </summary>
        /// <returns>list of StrategyStructure</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetStrategy()
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    List<StrategyStructure> strategies = new List<StrategyStructure>();
                    StrategyMgmt strategyMgmt = new StrategyMgmt(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable dt = strategyMgmt.GetStrategy();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            StrategyStructure st = new StrategyStructure()
                            {
                                Id = Convert.ToInt32(dr["strategyid"]),
                                StrategyName = dr["strategyname"].ToString(),
                                StrategyDesc = dr["strategydesc"].ToString(),
                                CreationDate = DateTime.Parse(dr["creationdate"].ToString()).ToString("yyyy-MM-dd H:mm:ss"),
                                CurrentStatus = dr["currentstatus"].ToString(),
                                StrategyType = dr["strategytype"].ToString(),
                                StrategyTimeFrame = dr["strategytimeframe"].ToString(),
                                StrategyTime = dr["strategytime"].ToString(),
                                Configuration = JsonConvert.DeserializeObject<Dictionary<dynamic, dynamic>>(dr["config"].ToString())
                            };
                            strategies.Add(st);
                        }
                    }

                    idata.Add("status", "success");
                    idata.Add("value", strategies);
                }
                catch (Exception ex)
                {

                }
            }
            return idata;
        }
        #endregion
    }
    #region Data Structure
    /// <summary>
    /// Structure for list of Strategies with execution status
    /// </summary>
    class StrategyDataStructure
    {
        public string StrategyId { get; set; }
        public string StrategyName { get; set; }
        public string StrategyDescription { get; set; }
        public string CreatingDate { get; set; }
        public string TimeFrame { get; set; }
        public string StrategyType { get; set; }
        public string[] Location { get; set; }
        public string CurrentStatus { get; set; }
        public int Fail { get; set; }
        public int Success { get; set; }
        public int Pending { get; set; }
    }
    /// <summary>
    /// structure for strategy Description by strategy description id
    /// </summary>
    class StrategyServiceStructure
    {
        public string EquipmentId { get; set; }
        public dynamic ServiceConfig { get; set; }
        public string StrategyTimeFrame1 { get; set; }
        public string StrategyTimeFrame2 { get; set; }
        public string StrategyTime { get; set; }
    }
    /// <summary>
    /// structure for list of strategy description
    /// </summary>
    class StrategyDescStructure
    {
        public int StrategyDescId { get; set; }
        public string StrategyTimeFrame1 { get; set; }
        public string StrategyTimeFrame2 { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public dynamic ServiceConfig { get; set; }
        public string StrategyTime { get; set; }
    }
    /// <summary>
    /// Structure for Strategy List
    /// </summary>
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
    /// <summary>
    /// structure to contains equipment ids and names
    /// </summary>
    public class TeacherAidStructure
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    #endregion
    
}
