using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace WebCresij
{
    /// <summary>
    /// Summary description for ChartData
    /// </summary>
    [WebService(Namespace = "http://localhost:17263/Services")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ChartData : WebService
    {

        Chart chart = new Chart();

        [WebMethod]
        public List<object> GetLineChartData(string name)
        {
            List<object> iData = new List<object>();
            List<string> labels = new List<string>();
            
            DataTable dtDataItemsSets_1 = chart.GetDashboardData();
            List<int> lst_dataItem_1 = new List<int>();
            foreach (DataRow dr in dtDataItemsSets_1.Rows)
            {
                lst_dataItem_1.Add(Convert.ToInt32(dr["count"].ToString()));
                labels.Add(dr["Task"].ToString());
            }
            iData.Add(lst_dataItem_1);            
            iData.Add(labels);
            return iData;
        }

       

        [WebMethod]
        public List<object> GetTempChartData(string name)
        {
            List<object> idata = new List<object>();
            List<object> ilabels = new List<object>();
            DataTable temp = chart.GetTempData();
            List<string> Time = new List<string>();
            List<double> temperature = new List<double>();
            List<double> humid = new List<double>();
            List<double> pm25 = new List<double>();
            List<double> pm10 = new List<double>();
            foreach (DataRow dr in temp.Rows)
            {
                Time.Add(dr["Location"].ToString());
                temperature.Add(Convert.ToDouble(dr["temp"].ToString()));
                humid.Add(Convert.ToDouble(dr["humid"].ToString()));
                pm25.Add(Convert.ToDouble(dr["pm25"].ToString()));
                pm10.Add(Convert.ToDouble(dr["pm10"].ToString()));
            }
            idata.Add(Time);
            idata.Add(temperature);
            idata.Add(humid);
            idata.Add(pm25);
            idata.Add(pm10);
            return idata;

        }

        [WebMethod]
        public List<object> GetTempChartDataAll(string name)
        {
            List<object> idata = new List<object>();
            List<object> ilabels = new List<object>();
            DataTable temp = chart.GetTempDataAll(name.ToString());
            List<string> className = new List<string>();
            List<double> temperature = new List<double>();
            List<double> humid = new List<double>();
            List<double> pm25 = new List<double>();
            List<double> pm10 = new List<double>();
            foreach (DataRow dr in temp.Rows)
            {
                className.Add(dr[0].ToString());
                temperature.Add(Convert.ToDouble( dr["temp"].ToString()));
                humid.Add(Convert.ToDouble(dr["humid"].ToString()));
                pm25.Add(Convert.ToDouble(dr["pm25"].ToString()));
                pm10.Add(Convert.ToDouble(dr["pm10"].ToString()));
            }
            idata.Add(className);
            idata.Add(temperature);
            idata.Add(humid);
            idata.Add(pm25);
            idata.Add(pm10);
            return idata;

        }
        [WebMethod]
        public List<object> GetCustomData(string name)
        {
            List<object> idata = new List<object>();
            List<object> ilabels = new List<object>();
            DataTable temp = chart.getDatacustom(name.ToString());
            List<string> className = new List<string>();
            List<double> temperature = new List<double>();
            List<double> humid = new List<double>();
            List<double> pm25 = new List<double>();
            List<double> pm10 = new List<double>();
            foreach (DataRow dr in temp.Rows)
            {
                className.Add(dr[0].ToString());
                temperature.Add(Convert.ToDouble(dr["temp"].ToString()));
                humid.Add(Convert.ToDouble(dr["humid"].ToString()));
                pm25.Add(Convert.ToDouble(dr["pm25"].ToString()));
                pm10.Add(Convert.ToDouble(dr["pm10"].ToString()));
            }
            idata.Add(className);
            idata.Add(temperature);
            idata.Add(humid);
            idata.Add(pm25);
            idata.Add(pm10);
            return idata;
        }
        public List<object> getDataforClass(string name)
        {
            List<object> idata = new List<object>();
            List<object> ilabels = new List<object>();
            DataTable temp = chart.getDataforClass(name);
            List<string> time = new List<string>();
            List<double> temperature = new List<double>();
            List<double> humid = new List<double>();
            List<double> pm25 = new List<double>();
            List<double> pm10 = new List<double>();
            foreach (DataRow dr in temp.Rows)
            {
                time.Add(dr[0].ToString());
                temperature.Add(Convert.ToDouble(dr["temp"].ToString()));
                humid.Add(Convert.ToDouble(dr["humid"].ToString()));
                pm25.Add(Convert.ToDouble(dr["pm25"].ToString()));
                pm10.Add(Convert.ToDouble(dr["pm10"].ToString()));
            }
            idata.Add(time);
            idata.Add(temperature);
            idata.Add(humid);
            idata.Add(pm25);
            idata.Add(pm10);
            return idata;
        }

    }
}
