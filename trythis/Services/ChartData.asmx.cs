﻿using System;
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
            PopulateTree pt = new PopulateTree();
            if (name.ToString() == "All")
            {
                DataTable temp1 = pt.GetStatus();
                if (temp1.Rows.Count > 0)
                {
                    string machineOnline = temp1.Select("MachineStatus='Online'").Count().ToString();
                    string machineOffline = temp1.Select("MachineStatus='Offline'").Count().ToString();
                    string workOpen = temp1.Select("WorkStatus='OPEN'").Count().ToString();
                    string workClose = temp1.Select("WorkStatus='CLOSED'").Count().ToString();
                    DataTable dt = pt.totalMachines();
                    machineOffline =  (Convert.ToInt32(dt.Rows[0][0]) - Convert.ToInt32(machineOnline)).ToString();
                    idata.Add(machineOnline);
                    idata.Add(machineOffline);
                    idata.Add(workOpen);
                    idata.Add(workClose);
                }    
            }
            else
            {
                DataTable dt = pt.GetStatus(name.ToString());
                string workopen = "0";
                string workclose = "0";
                string Online = "0";
                string offline = "0";
                string total="0";
                if (dt.Rows.Count > 0)
                {
                    workclose = dt.Rows[0][0].ToString();
                    if (dt.Rows.Count > 1)
                    {
                        workopen = dt.Rows[1][0].ToString();
                    }
                }
                dt = pt.totalMachinesOnline(name.ToString());
                if (dt.Rows.Count > 0)
                {
                    Online = dt.Rows[0][0].ToString();
                }
                dt = pt.totalMachines(name.ToString());
                if (dt.Rows.Count > 0)
                {
                    total = dt.Rows[0][0].ToString();
                }
                offline = (Convert.ToInt32(total) - Convert.ToInt32(Online)).ToString();
                idata.Add(Online);
                idata.Add(offline);
                idata.Add(workopen);
                idata.Add(workclose);
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetCustomData(string name, string location)
        {
            string loc = location.Substring(0, 3);
            string query = "";
            List<object> idata = new List<object>();
            List<object> ilabels = new List<object>();
            switch (loc)
            {
                case "Ins":
                    query = chart.QueryForIns(name, location);
                    break;
                case "Gra":
                    query = chart.QueryForgrade(name, location);
                    break;
                case "Cla":
                    query = chart.QueryForClass(name, location);
                    break;
                default:
                    query = chart.query(name);
                    break;
            }
            DataTable temp = chart.getDatacustom(query);
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

        [WebMethod]
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

        [WebMethod]
        public string GetMachineCount(string name)
        {
            DataTable dt = chart.MachineCount();
            string num = dt.Rows[0][0].ToString();
            return num;
        }

        [WebMethod]
        public List<object> GetIpClass(string gradeid)
        {
            DataTable dt = chart.MachineIPLoc(gradeid);
            List<string> names = new List<string>();
            List<string> ip = new List<string>();
            List<object> idata = new List<object>();
            foreach(DataRow dr in dt.Rows)
            {
                names.Add(dr[0].ToString());
                ip.Add(dr[1].ToString());
            }
            idata.Add(names);
            idata.Add(ip);
            dt = chart.getGradeName(gradeid);
            string gradename = dt.Rows[0][1].ToString();
            string insname = dt.Rows[0][0].ToString();
            idata.Add(insname);
            idata.Add(gradename);           
            return idata;
        }

        [WebMethod]
        public List<object> GetInsIds(string name)
        {
            DataTable dt = chart.InsIDs();
            List<object> idata = new List<object>();
            List<string> insids = new List<string>();
            List<string> insName = new List<string>();
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    insids.Add(dr[0].ToString());
                    insName.Add(dr[1].ToString());
                }
            }
            idata.Add(insids);
            idata.Add(insName);
            return idata;
        }

        [WebMethod]
        public List<object> GetGradeIds(string insid)
        {
            DataTable dt = chart.GradeIDs(insid);
            List<object> idata = new List<object>();
            List<string> gradeids = new List<string>();
            List<string> gname = new List<string>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    gradeids.Add(dr[0].ToString());
                    gname.Add(dr[1].ToString());
                }
            }
            idata.Add(gradeids);
            idata.Add(gname);
            
            return idata;
        }
    }
}
