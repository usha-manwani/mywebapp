﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for ScheduleData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ScheduleData : WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //[WebMethod]
        //public List<object> GetSchedule(string name)
        //{
        //    Schedule schedule = new Schedule();
        //    DataTable dt=  schedule.GetSchedule();
        //    List<object> idata = new List<object>();
        //    List<string> data = new List<string>();
        //    List<string> data1 = new List<string>();
        //    List<string> data2 = new List<string>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        data.Add(dr[0].ToString());
        //        data1.Add(dr[1].ToString());
        //        data2.Add(dr[2].ToString());
        //    }
        //    idata.Add(data);
        //    idata.Add(data1);
        //    idata.Add(data2);
        //    return idata;
        //}

        [WebMethod]
        public List<object> GetCourse(string name)
        {
            Schedule schedule = new Schedule();
            DataTable dt = schedule.GetCourse();
            List<object> idata = new List<object>();
            List<string> data = new List<string>();
            List<string> data1 = new List<string>();
            List<string> data2 = new List<string>();
            List<string> data3 = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                data.Add(dr[0].ToString());
                data1.Add(dr[1].ToString());
                data2.Add(dr[2].ToString());
                data3.Add(dr[3].ToString());
            }
            idata.Add(data);
            idata.Add(data1);
            idata.Add(data2);
            idata.Add(data3);
            return idata;
        }

        [WebMethod]
        public List<object> GetSchedule(string name)
        {
            Schedule schedule = new Schedule();
            DataTable dt = schedule.GetSchedule();
            List<object> idata = new List<object>();
            foreach(DataRow dr in dt.Rows)
            {
                idata.Add(dr.ItemArray);
            }
            //idata.Add(dt.Rows);
            return idata;
        }

        [WebMethod]
        public List<object> GetCourseDetails(string[] name)
        {
            Schedule schedule = new Schedule();
            DataTable dt = schedule.GetCourseDetails(name);
            List<object> idata = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                idata.Add(dr.ItemArray);
            }
            //idata.Add(dt.Rows);
            return idata;
        }

        [WebMethod]
        public List<object> SaveTransferSchedule(string[] name)
        {
            Schedule schedule = new Schedule();
            int r = schedule.SaveTransferSchedule(name);
            List<object> idata = new List<object>();            
            return idata;
        }
        [WebMethod]
        public List<object> getFreeWeek()
        {
            List<int> freeweek = new List<int>();
            int maxweek = 22, minweek = 1;
            Schedule schedule = new Schedule();
            DataTable dt = schedule.GetFreeWeek();
            List<object> idata = new List<object>();
            foreach(DataRow dr in dt.Rows)
            {
                idata.Add(dr.ItemArray);                
            }
            
            return idata;
        }
    }
}
