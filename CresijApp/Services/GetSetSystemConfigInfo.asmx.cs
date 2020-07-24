using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
using System.Data;
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
    public class GetSetSystemConfigInfo :WebService
    {        
            [WebMethod]
            public List<object> GetFloorClassByBuilding(string building)
            {
                List<object> idata = new List<object>();
                idata.Add(building);
                SystemInfo systemInfo = new SystemInfo();
                DataTable dt = systemInfo.GetFloorClassByBuilding(building);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        idata.Add(dr.ItemArray);
                    }
                }
                return idata;
            }

        [WebMethod]
        public List<object> GetFloorClassByBuildingUserAccess(string[] building)
        {
            List<object> idata = new List<object>();
            idata.Add(building[0]);
            SystemInfo systemInfo = new SystemInfo();
            DataTable dt = systemInfo.GetFloorClassByBuildingUserAccess(building[0],building[1]);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            }
            return idata;
        }
        [WebMethod]
        public List<object> GetIpByClass(string classlist)
        {
            List<object> idata = new List<object>();
            //idata.Add(building);
            SystemInfo systemInfo = new SystemInfo();
            DataTable dt = systemInfo.GetIpByClass(classlist);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            }
            return idata;
        }
    }
}
