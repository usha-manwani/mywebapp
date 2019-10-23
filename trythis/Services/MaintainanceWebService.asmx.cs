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
    [WebService(Namespace = "http://localhost:17263/Services")]
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
            string query = " select  gd.Grade_Name,(select count(status) from Fault_Info where "+ 
                 "gd.grade_Id = fi.gradeId) as total,(select COALESCE(count(status), 0) from "+
                 "Fault_Info where status = 'resolved' and gd.grade_Id = fi.gradeId) as resolved "+
                  "from cresijdatabase.Fault_Info fi join cresijdatabase.Grade_Details gd "+
                  "on gd.Grade_ID = fi.gradeId join cresijdatabase.Institute_Details ins "+ 
                  "on gd.InsID = ins.id where Ins_ID = '"+insid+"' group by Grade_Name,fi.gradeId";
            
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
            string query = "select count(distinct(ip)) as total from Fault_Info";
            DataTable dt= PopulateTree.ExecuteCommand(query);
            List<object> data = new List<object>();
            if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
            {
                data.Add(dt.Rows[0][0].ToString());
                query = "select count(status) as counter, status from Fault_Info group by status order by status";
                dt= PopulateTree.ExecuteCommand(query);
                //foreach(DataRow r in dt.Rows)
                //{
                //    data.Add(r[0]);
                //}
                if (dt.Rows.Count == 2)
                {
                     data.Add(dt.Rows[0][0]);
                     data.Add(dt.Rows[1][0]);
                }
                else
                {
                    if(dt.Rows[0][1].ToString() == "Pending")
                    {
                        data.Add(dt.Rows[0][0]);
                        data.Add(0);
                    }
                    else
                    {                        
                        data.Add(0);
                        data.Add(dt.Rows[0][0]);
                    }
                    
                }
                query = "select count(status) as counter from Fault_Info where Date(LastUpdated)" +
                    " = Date(now()) and status='Resolved'";
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
