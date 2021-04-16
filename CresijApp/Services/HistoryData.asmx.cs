using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CresijApp.Models;
using System.Web.Services;
using CresijApp.DataAccess;
using System.Data;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for HistoryData
    /// This class deals with the different properties/records of data by machine usage.
    /// Currently It contains one service for getting Power usage data of a machine
    /// Session needs to be added
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class HistoryData : WebService
    {
        /// <summary>
        /// Method to get Power usage data of a machine in a class 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>return data records along with different time interval as required</returns>
        [WebMethod]
        public Dictionary<string,object> GetPowerUsageData(Dictionary<string,string> data)
        {
            var result = new Dictionary<string, object>();
            HistoryDataAccessHelper hd = new HistoryDataAccessHelper();
            var classid = 0;
            string query = "";
            List<MonthPower> m = new List<MonthPower>();
            try
            {


                if (data.ContainsKey("classid"))
                {
                    classid = Convert.ToInt32(data["classid"]);
                }

                var propname = data["propName"].ToString();
                result.Add("Type", propname);
                var startTime = Convert.ToDateTime(data["startTime"]);
                var endTime = Convert.ToDateTime(data["endTime"]);
                var timerange = data["timeRange"];
                if (timerange == "SumOfDays")
                {
                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        var rows = context.machineusagelogs_minute.Where(x => x.recordtime >= startTime && x.recordtime <= endTime
                           && x.attribute == propname && x.classid == classid).Sum(x => x.value);
                        result.Add("value", rows);
                    }
                }
                if (timerange == "Month")
                {
                    query = "select sum(value) as powervalue ," +
                   "concat(year(recordtime),'-',month(recordtime)) as recordtime from machineusagelogs_minute where classid = " + classid + " and " +
                   " month(recordtime) >= month('" + startTime.ToString("yyyy-MM-dd") + "')" +
                   " and year(recordtime)=year('" + startTime.ToString("yyyy-MM-dd") + "')  and month(recordtime) >= month( '"
                   + endTime.ToString("yyyy-MM-dd") + "') and year(recordtime)= year('" + endTime.ToString("yyyy-MM-dd") + "') and attribute='" + propname +
                   "' group by " +
                   "month(recordtime)";

                    var dt = hd.ExecuteQuery(query);
                    if (dt.Rows.Count > 0)
                    {
                        
                        foreach (DataRow dr in dt.Rows)
                        {
                            m.Add(new MonthPower
                            {
                                RecordTime = dr["recordtime"].ToString(),
                                Value = Convert.ToDouble(dr["powervalue"])
                            });
                        };
                       
                    }
                    result.Add("value", m);
                }
                else if (timerange == "Days")
                {
                    query = "select sum(value) as powervalue ," +
                        "date(recordtime) as recordtime from machineusagelogs_minute where classid = " + classid + " and " +
                        " recordtime >= '" + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and recordtime<= '"
                        + endTime.ToString("yyyy-MM-dd HH:mm:ss") + "'" +
                        " and attribute='" + propname + "' group by date(recordtime)";
                    var dt = hd.ExecuteQuery(query);
                    if (dt.Rows.Count > 0)
                    {
                        
                        foreach (DataRow dr in dt.Rows)
                        {
                            m.Add(new MonthPower
                            {
                                RecordTime = Convert.ToDateTime(dr["recordtime"]).ToString("yyyy-MM-dd"),
                                Value = Convert.ToDouble(dr["powervalue"])
                            });
                        };
                       
                    }
                    result.Add("value", m);
                }
                else if (timerange == "Hour")
                {

                    query = "select sum(value) as powervalue ,concat(lpad(Hour(recordtime), 2, '0'), ':00:00') as recordtime" +
                        " from machineusagelogs_minute where attribute = '" + propname + "' " +
                        "and classid = " + classid + " and recordtime >= '"
                        + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "' and recordtime <= '" +
                        endTime.ToString("yyyy-MM-dd HH:mm:ss") + "' group by hour(recordtime)";
                    var dt = hd.ExecuteQuery(query);
                    
                    if (dt.Rows.Count > 0)
                    {
                        
                        foreach (DataRow dr in dt.Rows)
                        {
                            m.Add(new MonthPower
                            {
                                RecordTime = dr["recordtime"].ToString(),
                                Value = Convert.ToDouble(dr["powervalue"])
                            });
                        };
                       
                    }
                    result.Add("value", m);
                }
            }
            catch(Exception ex)
            {
                result.Add("error: " , ex.Message + " inner exception: " + ex.InnerException + " stacktrace: " + ex.StackTrace);
            }
            return result;
        }
    }
    public class MonthPower
    {
        public string RecordTime { get; set; }
        public double Value { get; set; }
    }
}
