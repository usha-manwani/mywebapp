using System;

using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebCresij.Services
{
    /// <summary>
    /// Summary description for MaintainanceWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class MaintainanceWebService : WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<string> GetTask()
        {
            List<string> taskdetails = new List<string>();
            List<DateTime> time1   = new List<DateTime>();
            List<DateTime> time2   = new List<DateTime>();            
            return null;
        }

        [WebMethod]
        public List<object> GetFaultInfos(string name)
        {
            string insid = name.ToString();
            string query = " select  gd.GradeName,(select count(stat) from FaultInfo where "+
                 "gradeId = fi.gradeId) as total,(select COALESCE(count(stat), 0) from "+
                 "FaultInfo where stat = 'resolved' and gradeId = fi.gradeId) as resolved "+
                  "from FaultInfo fi join Grade_Details gd on gd.GradeID = fi.gradeId "+
                  "join Institute_Details id on gd.InsID = id.InstituteID "+
                  "where InstituteID = '"+insid+"' group by GradeName,fi.gradeId";
            
            DataTable dt = PopulateTree.ExecuteCommand(query);
            List<object> data = new List<object>();
            string sb;
            
            foreach (DataRow dr in dt.Rows)
            {
                sb= string.Join(",", dr.ItemArray);
                data.Add(sb);
            }            
            return data;
        }

        [WebMethod]
        public List<object> GetFaultCount(string name)
        {
            string query = "select count(distinct(ip)) as total from FaultInfo";
            DataTable dt= PopulateTree.ExecuteCommand(query);
            List<object> data = new List<object>();
            if (dt.Rows.Count > 0)
            {
                data.Add(dt.Rows[0][0].ToString());
                query = "select count(stat) as counter, stat from FaultInfo group by stat order by stat";
                dt= PopulateTree.ExecuteCommand(query);
                data.Add(dt.Rows[0][0]);
                data.Add(dt.Rows[1][0]);
                query = "select count(stat) as counter from FaultInfo where  CONVERT(date, LastUpdated)" +
                    " = CONVERT(date, getdate()) and stat='resolved'";
                dt = PopulateTree.ExecuteCommand(query);
                data.Add(dt.Rows[0][0]);
            }
            else
            {
                data.Add(0);
                data.Add(0);
                data.Add(0);
                data.Add(0);
            }
            return data;
        }

        
    }
}
