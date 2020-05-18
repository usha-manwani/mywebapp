using System;
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
            idata.Add(r);
            return idata;
        }
        [WebMethod]
        public List<BusySchedule> getFreeWeek()
        {
            List<int> freeweek = new List<int>();
            
            Schedule schedule = new Schedule();
            DataTable dt = schedule.GetScheduleFree(); //.GetFreeWeek();
            List<BusySchedule> idata = new List<BusySchedule>();
            //foreach(DataRow dr in dt.Rows)
            //{
            //    idata.Add(dr.ItemArray);                
            //}
           idata= GetFreeSchedule(dt);
            return idata;
        }

        [WebMethod]
        public List<object> GetFreeDay(string name)
        {
            List<int> freeweek = new List<int>();

            Schedule schedule = new Schedule();
            DataTable dt = schedule.GetFreeDay(Convert.ToInt32(name));
            List<object> idata = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                idata.Add(dr.ItemArray);
            }

            return idata;
        }

        public List<BusySchedule> GetFreeSchedule(DataTable dt)
        {
            List<BusySchedule> idata = new List<BusySchedule>();
            int maxweek = 22;
            for(int i=1; i <= maxweek; i++)
            {
                BusySchedule schedule = new BusySchedule
                {
                    Week = i
                };
                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (Convert.ToInt32(dr[1]) <= i && Convert.ToInt32(dr[2]) >= i)
                        {
                            schedule.Day.Add(dr[3].ToString());
                            schedule.Classnames.Add(dr[0].ToString());
                            schedule.Section.Add(Convert.ToInt32(dr[4]));
                        }
                    }
                    idata.Add(schedule);
                   // GetWeekdays(idata);
                }
                catch(Exception ex)
                {

                }
            }
            
            return idata;
        }

        public class BusySchedule
        {
            public int Week { get; set; }
            public List<string> Day { get; set; }
            public List<string> Classnames { get; set; }
            public List<int> Section { get; set; }

            public BusySchedule()
            {
                Day = new List<string>();
                Classnames = new List<string>();
                Section = new List<int>();
            }
        }

        public void GetWeekdays(List<BusySchedule> idata)
        {
            string[] totaldays = new string[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };
            

            foreach(BusySchedule busy in idata)
            {
                foreach(string d in totaldays)
                {
                    if (busy.Day.Contains(d))
                    {

                    }
                }
            }
        }

        [WebMethod]
        public List<object> GetBuilding()
        {
            Schedule schedule = new Schedule();
            DataTable r = schedule.GetBuilding();
            List<object> idata = new List<object>();
            foreach(DataRow dr in r.Rows)
            {
                idata.Add(dr.ItemArray);
            }
            return idata;
        }
        [WebMethod]
        public List<object> GetAvailClasses(string[] name)
        {
            Schedule schedule = new Schedule();
            DataTable r = schedule.GetAvailClasses(name[0],name[1]);
            List<object> idata = new List<object>();
            foreach (DataRow dr in r.Rows)
            {
                if(Convert.ToInt32(dr[1])<42)
                idata.Add(dr[0].ToString());
            }
            return idata;
        }

        [WebMethod]
        public List<DaysAndSection> GetAvailDay(string[] name)
        {
            Schedule schedule = new Schedule();
            DataTable r = schedule.GetAvailDay(name[0], name[1]);
            List<DaysAndSection> idata = new List<DaysAndSection>();
           
                for(int i=1; i <= 7; i++)
                {
                DaysAndSection section = new DaysAndSection();
                section.Day = i;
                if (r.Rows.Count > 0)
                {
                    foreach (DataRow dr in r.Rows)
                    {

                        string[] sec = dr[1].ToString().Split(',');
                        if (Convert.ToInt32(dr[0]) == section.Day)
                        {

                            for (int k = 0; k < sec.Length; k++)
                            {
                                section.Section.Remove(Convert.ToInt32(sec[k]));
                            }

                            break;
                        }
                    }
                }
                
                if (section.Section.Count>0)
                    idata.Add(section);
            }
            return idata;
        }

        public class DaysAndSection
        {
            public int Day { get; set; }
            public List<int> Section { get; set; }
            public DaysAndSection()
            {
                Section = new List<int>() { 1,3,5,7,9,11};
            }
        }

        [WebMethod]
        public List<object> GetTeacherDetail(string name)
        {
            Schedule schedule = new Schedule();
            DataTable r = schedule.GetTeacherDetail(name);
            List<object> idata = new List<object>();
            foreach (DataRow dr in r.Rows)
            {
                idata.Add(dr.ItemArray);
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetTransferedSchedule()
        {
            Schedule schedule = new Schedule();
            DataTable r = schedule.GetTransferSchedule();
            List<object> idata = new List<object>();
            foreach(DataRow dr in r.Rows)
            {
                idata.Add(dr.ItemArray);
            }
            
            return idata;
        }

        [WebMethod]
        public int SaveScheduleStatus(string[] name)
        {
            Schedule schedule = new Schedule();
            int r = schedule.SaveScheduleStat(name);
            
            return r;
        }

        [WebMethod]
        public List<object> GetScheduleForDate(string date)
        {
            Schedule schedule = new Schedule();
            //string dd = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable r = schedule.GetScheduleForDate(date);
            List<object> data = new List<object>();
            foreach(DataRow dr in r.Rows)
            {
                data.Add(dr.ItemArray);
            }
            return data;
        }

        [WebMethod]
        public List<object> GetClassesByDateAndBuilding(string[] name)
        {
            Schedule schedule = new Schedule();
            DataTable r = schedule.GetClassesByDateAndBuilding(name[0], name[1]);
            List<object> idata = new List<object>();
            foreach (DataRow dr in r.Rows)
            {
                idata.Add(dr.ItemArray);
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetWeekYearSemester(string name)
        {
            List<object> idata = new List<object>();
            Schedule sc = new Schedule();
            string week = sc.GetWeekByDate(name);
            string[] data = sc.GetYearAndSemester(name);
            idata.Add(week);
            idata.Add(data[0]);
            idata.Add(data[1]);
            return idata;
        }

        [WebMethod]
        public int SaveReserveSchedule(string[] name)
        {
            Schedule schedule = new Schedule();
            int r = schedule.SaveReserveSchedule(name);
            return r;
        }

        [WebMethod]
        public List<object> GetReserveSchedule()
        {
            Schedule schedule = new Schedule();
            DataTable r = schedule.GetReserveSchedule();
            List<object> idata = new List<object>();
            foreach (DataRow dr in r.Rows)
            {
                idata.Add(dr.ItemArray);
            }

            return idata;
        }

        [WebMethod]
        public int ChangeReserveStatus(string[] name)
        {
            Schedule schedule = new Schedule();
            int r = schedule.ChangeReserveStatus(name);

            return r;
        }

    }
}
