using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
using System.Data;
using System.Security.Permissions;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for GetSetSystemConfigInfo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class GetSetSystemConfigInfo : WebService
    {
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetFloorClassByBuilding(string building)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<object> idata = new List<object>();
            var cc = HttpContext.Current.Session;
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count==0)
            {
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");
                result.Add("building", building);
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result.Add("building", building);
                    SystemInfo systemInfo = new SystemInfo();
                    DataTable dt = systemInfo.GetFloorClassByBuilding(building);
                    result.Add("status", "success");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            List<ClassNamesList> cl = JsonConvert.DeserializeObject<List<ClassNamesList>>(dr["className"].ToString());
                            ClassFloorStructure fc = new ClassFloorStructure()
                            {
                                Floor = dr["floor"].ToString(),
                                ClassNames = cl
                            };                            
                            idata.Add(fc);
                        }
                        result.Add("value", idata);
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("building", building);
                    result.Add("errorMessage", ex.Message);
                }
            }            
            return result;
        }

        public class ClassFloorStructure
        {
            public string Floor { get; set; }
            public List<ClassNamesList> ClassNames { get; set; } 
        }
        public class ClassNamesList
        {
            public string Name;
            public string Id;
        }
        
        [WebMethod(EnableSession =true)]
        public Dictionary<string, object> GetFloorClassByBuildingForUserAccess(string building)
        {
            string userid = "";
            List<object> idata = new List<object>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");
                result.Add("building", building);
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    if (Session["UserLoggedIn"].ToString() != null)
                    {

                        userid = Session["UserLoggedIn"].ToString();
                        result.Add("building", building);
                        SystemInfo systemInfo = new SystemInfo();
                        DataTable dt = systemInfo.GetFloorClassByBuildingUserAccess(building, userid);
                        result.Add("status", "success");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                List<ClassNamesList> cl = JsonConvert.DeserializeObject<List<ClassNamesList>>(dr["className"].ToString());
                                ClassFloorStructure fc = new ClassFloorStructure()
                                {
                                    Floor = dr["floor"].ToString(),
                                    ClassNames = cl
                                };
                                idata.Add(fc);
                            }
                            result.Add("value", idata);
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        result.Add("status", "fail");
                        result.Add("building", building);
                        result.Add("errorMessage", "Session Expired");
                        result.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("building", building);
                    result.Add("errorMessage", ex.Message);
                }
            }           
            return result;
        }
       
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetIpByClass(string classlist)
        {
            List<CcipStructure> idata = new List<CcipStructure>();
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");               
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    SystemInfo systemInfo = new SystemInfo();
                    DataTable dt = systemInfo.GetIpByClass(classlist);
                    result.Add("status", "success");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            CcipStructure cl =JsonConvert.DeserializeObject<CcipStructure>(dr["ccip"].ToString());
                            idata.Add(cl);
                        }
                        result.Add("value", idata);
                    }
                }
                catch (Exception ex)
                {
                    result.Add("status", "fail");
                    result.Add("errorMessage", ex.Message);
                }
            }            
            return result;
        }

        class CcipStructure
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string CCIP { get; set; }
        }
    }
}
