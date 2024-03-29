﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using CresijApp.DataAccess;
namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for ScheduleData
    /// </summary>
    [WebService(Namespace = "http://ipaddress/services/ScheduleData.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class ScheduleData : WebService
    {

        #region Common Web methods for Schedule        
        /// <summary>
        /// method to get building id and names accessed by user in session
        /// </summary>
        /// <returns>list of building id and name</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetBuilding()
        {
            Dictionary<string, object> val = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                val.Add("status", "fail");
                val.Add("errorMessage", "Session Expired");
                val.Add("customErrorCode", "440");
            }
            else
            {
                var userid = HttpContext.Current.Session["UserLoggedIn"].ToString();
                try
                {
                    Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable r = schedule.GetBuilding(userid);
                    List<object> idata = new List<object>();
                    val.Add("status", "success");
                    List<BuildingIDName> buildings = new List<BuildingIDName>();
                    if (r.Rows.Count > 0)
                    {
                        foreach (DataRow dr in r.Rows)
                        {
                            BuildingIDName bd = new BuildingIDName()
                            {
                                BuildingId = dr["id"].ToString(),
                                BuildingName=dr["building"].ToString()
                            };
                            buildings.Add(bd);
                        }
                    }
                    val.Add("total", r.Rows.Count);
                    val.Add("value", buildings);
                }
                catch (Exception ex)
                {
                    val.Add("status", "fail");
                    val.Add("errorMessage", ex.Message);
                }
            }            
            return val;
        }
        /// <summary>
        /// method to get all building id and names
        /// </summary>
        /// <returns>list of building id and name</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetAllBuildingNameID()
        {
            Dictionary<string, object> val = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                val.Add("status", "fail");
                val.Add("errorMessage", "Session Expired");
                val.Add("customErrorCode", "440");
            }
            else
            {
                var userid = HttpContext.Current.Session["UserLoggedIn"].ToString();
                try
                {
                    Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable r = schedule.GetBuildingNameandID();
                    List<object> idata = new List<object>();
                    val.Add("status", "success");
                    List<BuildingIDName> buildings = new List<BuildingIDName>();
                    if (r.Rows.Count > 0)
                    {

                        foreach (DataRow dr in r.Rows)
                        {
                            BuildingIDName bd = new BuildingIDName()
                            {
                                BuildingId = dr["id"].ToString(),
                                BuildingName = dr["building"].ToString()
                            };
                            buildings.Add(bd);
                        }
                    }
                    val.Add("total", r.Rows.Count);
                    val.Add("value", buildings);
                }
                catch (Exception ex)
                {
                    val.Add("status", "fail");
                    val.Add("errorMessage", ex.Message);
                }
            }
            return val;
        }
       
        /// <summary>
        /// Method to get teacher name and id list by the course in schedule
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns>teacher name and id list</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetTeacherDetail(string courseName)
        {
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataTable r = new DataTable();
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
                    r = schedule.GetTeacherDetail(courseName);

                    idata.Add("status", "success");
                    List<TeacherDetails> dat = new List<TeacherDetails>();
                    if (r.Rows.Count > 0)
                    {
                        idata.Add("totalRows", r.Rows.Count);
                        foreach (DataRow dr in r.Rows)
                        {
                            TeacherDetails td = new TeacherDetails()
                            {
                                TeacherName = dr["TeacherName"].ToString(),
                                TeacherId = dr["teacherid"].ToString()
                            };
                            dat.Add(td);
                        }
                    }
                    idata.Add("value", dat);
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }

        /// <summary>
        /// Method to get start and end date, auto review values for reservation and transfer
        /// </summary>
        /// <param name="type"> value can be "Transfer" or "Reserve"</param>
        /// <returns>Returns start, end dates and auto review values</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetCalenderDates(string type)
        {
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
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
                    DataTable r = schedule.GetCalenderDates(type);
                    Dictionary<string, string> list = new Dictionary<string, string>();
                    if (r.Rows.Count > 0)
                    {
                        foreach (DataRow dr in r.Rows)
                        {
                            list.Add("autoReviewOfRequest", dr["AutoReview"].ToString());
                            list.Add("nonWorkingDaysRequest", dr["NonWorkingDays"].ToString());
                            list.Add("startDate", dr["starttime"].ToString());
                            list.Add("endDate", dr["endtime"].ToString());
                            list.Add("SemesterNo", dr["semesterno"].ToString());
                        }
                    }
                    idata.Add("status", "success");
                    idata.Add("value", list);
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
        #region Transfer Schedule
        /// <summary>
        /// Web Methods For getting the schedule by selecting the building, week and day that can be transferred
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns schedule for specific time range and building</returns>
        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetTransferScheduleByDay(Dictionary<string, object> data)
        {
            string userid = "";
            Dictionary<string, object> idata = new Dictionary<string, object>();
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
            List<object> dat = new List<object>();
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
                    if (Session["UserLoggedIn"].ToString() != null || HttpContext.Current.Session.Count == 0)
                    {

                        userid = Session["UserLoggedIn"].ToString();
                        var building = data["building"].ToString();
                        var sem = Convert.ToInt32(data["semNum"]);
                        var week = Convert.ToInt32(data["weekNum"]);
                        var day = Convert.ToInt32(data["dayNum"]);

                        var pgindex = Convert.ToInt32(data["pageIndex"]);
                        var pgsize = Convert.ToInt32(data["pageSize"]);
                        dat = schedule.GetTransferScheduleByDay(building, sem, week, day, userid, pgindex, pgsize);

                        idata.Add("status", "success");
                        int total = Convert.ToInt32(dat[0]);
                        KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                        idata.Add("totalRows", total);
                        DataTable dt = dat[1] as DataTable;
                        List<ScheduleDataStructureByBuildingWeek> schedules = new List<ScheduleDataStructureByBuildingWeek>();
                        if (dt.Rows.Count >= 1)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ScheduleDataStructureByBuildingWeek scheduleDataStructure = new ScheduleDataStructureByBuildingWeek()
                                {
                                    RowNum = Convert.ToInt32(dr["RowNumber"]),
                                    ClassId = dr["classid"].ToString(),
                                    Classname = dr["ClassName"].ToString(),
                                    Section1 = dr["Section1"].ToString(),
                                    Section2 = dr["Section2"].ToString(),
                                    Section3 = dr["Section3"].ToString(),
                                    Section4 = dr["Section4"].ToString(),
                                    Section5 = dr["Section5"].ToString(),
                                    Section6 = dr["Section6"].ToString(),
                                    Section7 = dr["Section7"].ToString(),
                                    Section8 = dr["Section8"].ToString(),
                                    Section9 = dr["Section9"].ToString(),
                                    Section10 = dr["Section10"].ToString(),
                                    Section11 = dr["Section11"].ToString(),
                                    Section12 = dr["Section12"].ToString()
                                };
                                schedules.Add(scheduleDataStructure);
                            }
                            idata.Add("value", schedules);
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        idata.Add("status", "fail");
                        idata.Add("errorMessage", "Session Expired");
                        idata.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }

        /// <summary>
        /// Web Methods For getting the schedule by selecting the building and date that can be transferred
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns schedule for specific time range and building</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetTransferScheduleByDate(Dictionary<string, object> data)
        {
            string userid = "";
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<object> dat = new List<object>();
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
                    if (Session["UserLoggedIn"].ToString() != null)
                    {
                        userid = Session["UserLoggedIn"].ToString();
                        var building = data["building"].ToString();
                        var date = data["date"].ToString();
                        var pgindex = data["pageIndex"].ToString();
                        var pgsize = data["pageSize"].ToString();
                        Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
                        dat = schedule.GetScheduleForTransfer(building, date, userid, pgindex, pgsize);
                        idata.Add("status", "success");
                        int total = Convert.ToInt32(dat[0]);
                        KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);

                        DataTable dt = dat[1] as DataTable;
                        List<ScheduleDataStructureByBuildingWeek> schedules = new List<ScheduleDataStructureByBuildingWeek>();
                        idata.Add("totalRows", total);
                        if (dt.Rows.Count >= 1)
                        {

                            foreach (DataRow dr in dt.Rows)
                            {
                                ScheduleDataStructureByBuildingWeek scheduleDataStructure = new ScheduleDataStructureByBuildingWeek()
                                {
                                    RowNum = Convert.ToInt32(dr["RowNumber"]),
                                    ClassId=dr["classid"].ToString(),
                                    Classname = dr["ClassName"].ToString(),
                                    Section1 = dr["Section1"].ToString(),
                                    Section2 = dr["Section2"].ToString(),
                                    Section3 = dr["Section3"].ToString(),
                                    Section4 = dr["Section4"].ToString(),
                                    Section5 = dr["Section5"].ToString(),
                                    Section6 = dr["Section6"].ToString(),
                                    Section7 = dr["Section7"].ToString(),
                                    Section8 = dr["Section8"].ToString(),
                                    Section9 = dr["Section9"].ToString(),
                                    Section10 = dr["Section10"].ToString(),
                                    Section11 = dr["Section11"].ToString(),
                                    Section12 = dr["Section12"].ToString()
                                };
                                schedules.Add(scheduleDataStructure);
                            }
                            idata.Add("value", schedules);
                        }
                        else
                            idata.Add("value", "");
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        idata.Add("status", "fail");
                        idata.Add("errorMessage", "Session Expired");
                        idata.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;

        }
        
        /// <summary>
        /// Method to get the list of transfered schedules
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Return list of all transferred schedule</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetTransferScheduleList(Dictionary<string,string>data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
            List<TransferScheduleListStructure> list = new List<TransferScheduleListStructure>();
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
                    List<object> res  = schedule.GetTransferSchedule(data);
                    DataTable r = res[1] as DataTable;
                    DataTable sections = schedule.GetSectionsInfo();
                    idata.Add("status", "success");
                    if (sections.Rows.Count > 0)
                    {
                        if (r.Rows.Count > 0)
                        {
                            idata.Add("totalRows", res[0].ToString());
                            foreach (DataRow dr in r.Rows)
                            {
                                var temp1 = dr["oldsection"].ToString();
                                var oldsection = sections.AsEnumerable().Where(x => x.Field<string>("section").Equals(temp1)
                                && x.Field<int>("semesterno") == Convert.ToInt32( dr["sem"].ToString()))
                                                                        .Select(x=>x.Field<TimeSpan>("starttime"))
                                                                        .FirstOrDefault().ToString(@"hh\:mm");
                                var temp2 = dr["newsection"].ToString();
                                var newsection = sections.AsEnumerable().Where(x => x.Field<string>("section").Equals(temp2)
                                && x.Field<int>("semesterno") == Convert.ToInt32(dr["sem"].ToString()))
                                                                        .Select(x => x.Field<TimeSpan>("starttime"))
                                                                        .FirstOrDefault().ToString(@"hh\:mm");
                                var oldtime = dr["oldtime"].ToString().Split(',');
                                var newtime = dr["newtime"].ToString().Split(',');
                                var startdate = dr["startdate"].ToString();
                               
                                var date2 = new DateTime();
                                
                                var newdate = new DateTime();
                              
                                DateTime.TryParse(startdate, out date2);
                                if (Convert.ToInt32(newtime[0]) == 1)
                                {
                                    newdate = date2.AddDays(Convert.ToInt32(newtime[0]));
                                }
                                else
                                {
                                    var daytemp = Convert.ToInt16(date2.DayOfWeek);
                                    if (daytemp == 0) daytemp = 7;
                                    var datetocount = date2.AddDays(7 - daytemp);
                                    var tempdate2 = datetocount.AddDays(7 * (Convert.ToInt32(newtime[0]) - 2));
                                    newdate = tempdate2.AddDays(Convert.ToInt32(newtime[1]));
                                }
                                var finalnewdate = newdate.ToString("yyyy-MM-dd") + "," + newsection;
                                
                                var finalolddate = Convert.ToDateTime(oldtime[0]).ToString("yyyy-MM-dd") + "," + oldsection;

                                TransferScheduleListStructure transfer = new TransferScheduleListStructure()
                                {
                                    OldClassName = dr["oldclass"].ToString(),
                                    NewClassName = dr["newClass"].ToString(),
                                    OldTime = finalolddate,
                                    NewTime = finalnewdate,
                                    OldTeacherName = dr["oldteacher"].ToString(),
                                    NewTeacherName = dr["newteacher"].ToString(),
                                    ClassType = dr["classtype"].ToString(),
                                    CurrentStatus = dr["currentStatus"].ToString(),
                                    Reason = dr["reason"].ToString(),
                                    CourseName = dr["coursename"].ToString(),
                                    ID = dr["id"].ToString()
                                };
                                list.Add(transfer);
                            }
                            idata.Add("value", list);
                        }
                    }                   
                    else
                    {
                        idata.Add("totalRows", 0);
                        idata.Add("value", "");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail"); idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }
        
        /// <summary>
        /// Method to get details about a schedule by its id for making a transfer
        /// </summary>
        /// <param name="id"></param>
        /// <returns>schedule details by id</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetCourseDetailsForTransferID(string id)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
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
                    DataTable dt = schedule.GetCourseDetailsForTransfer(id);
                    idata.Add("status", "success");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            TransferCourseDetailStructure transfer = new TransferCourseDetailStructure()
                            {
                                TeacherName = dr["Teachername"].ToString(),
                                CourseName = dr["coursename"].ToString(),
                                ClassName = dr["classname"].ToString(),
                                ClassId = dr["classId"].ToString(),
                                WeekStart = dr["Weekstart"].ToString(),
                                Weekend = dr["Weekend"].ToString(),
                                DayNum = dr["dayno"].ToString(),
                                Section = dr["section"].ToString(),
                                Building = dr["building"].ToString(),
                                StartDate = dr["Startdate"].ToString(),
                                SemNum = dr["semNum"].ToString(),
                                TotalWeeks = dr["TotalWeeks"].ToString()
                            };
                            idata.Add("value", transfer);
                        }
                    }
                    else
                        idata.Add("value", "");

                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }
        
        /// <summary>
        /// Method to add new record for transfer schedule
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Method to</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> AddTransferSchedule(Dictionary<string, object> data)
        {
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> d = new List<string>();
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
                    Dictionary<string, string> temp = new Dictionary<string, string>();
                    temp.Add("oldClass",data["currentClassId"].ToString());
                    temp.Add("courseName",data["courseName"].ToString());
                    temp.Add("reason",data["reason"].ToString());
                    temp.Add("newWeek",data["newWeek"].ToString());
                    temp.Add("newday",data["newday"].ToString());
                    temp.Add("newSection",data["newSection"].ToString());
                    temp.Add("newBuilding",data["newBuilding"].ToString());
                    temp.Add("newClassId",data["newClassId"].ToString());
                    temp.Add("newTeacherID",data["newTeacherID"].ToString());
                    temp.Add("currentRefrenceID",data["currentRefrenceID"].ToString());
                    if (data.ContainsKey("oldDate"))
                    {
                        temp.Add("oldDate",data["oldDate"].ToString());
                    }
                    else
                    {
                        temp.Add("sem",data["sem"].ToString());
                        temp.Add("oldWeek",data["oldWeek"].ToString());
                        temp.Add("oldDay",data["oldDay"].ToString());
                    }
                    int r = schedule.SaveTransferSchedule(temp);
                    if (r >= 0)
                    {
                        idata.Add("status", "success");
                        idata.Add("AffectedRows", r);
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }
        
        /// <summary>
        /// Method to update the status of a transfer schedule
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> UpdateTransferScheduleStatus(Dictionary<string, object>  data)
        {
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, object> idata = new Dictionary<string, object>();
            int r = 0;
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
                    var status = data["status"].ToString();
                    var id = data["id"].ToString();
                    r = schedule.SaveTransferScheduleStat(status, id);

                    if (r > 0)
                    {
                        idata.Add("status", "success");
                    }
                    else
                    {
                        idata.Add("status", "fail");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
            
        }

        /// <summary>
        /// method to get available classes accessed by user which has no schedule session
        /// </summary>
        /// <param name="data">the parameters include building id, weeknum and sem no</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetAvailClasses(Dictionary<string, object> data)
        {
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
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
                    if (HttpContext.Current.Session["UserLoggedIn"].ToString() != null)
                    {
                        string userid = Session["UserLoggedIn"].ToString();
                        DataTable r = new DataTable();
                        List<object> dat = new List<object>();
                        var building = data["building"].ToString();
                        var week = data["weekNum"].ToString();
                        var semno = data["semNum"].ToString();
                        r = schedule.GetAvailClasses(week, building, userid, semno);
                        idata.Add("status", "success");
                        if (r.Rows.Count > 0)
                        {
                            int total = r.Rows.Count;
                            KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                            idata.Add("totalRows", total);
                            foreach (DataRow dr in r.Rows)
                            {
                                if (Convert.ToInt32(dr["section"]) < 42)
                                {
                                    AvailClasses ad = new AvailClasses()
                                    {
                                        ClassId = dr["classid"].ToString(),
                                        ClassName = dr["classname"].ToString()
                                    };
                                    dat.Add(ad);
                                }

                            }
                            idata.Add("value", dat);
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        idata.Add("status", "fail");
                        idata.Add("errorMessage", "Session Expired");
                        idata.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }
        
        /// <summary>
        /// Method to get free days and section in a class which has no schedule session
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Free days and sections list </returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetAvailDay(Dictionary<string, object> data)
        {
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, object> idata = new Dictionary<string, object>();
            DataTable r = new DataTable();
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
                    List<object> dat = new List<object>();
                    var classid = data["classId"].ToString();
                    var week = data["weekNum"].ToString();
                    var semno = data["semNum"].ToString();
                    r = schedule.GetAvailDay(week, classid, semno);
                    List<DaysAndSection> listofclass = new List<DaysAndSection>();
                    if (r.Rows.Count > 0)
                    {
                        int total = r.Rows.Count;
                        KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                        idata.Add("totalRows", total);
                        for (int i = 1; i <= 7; i++)
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

                            if (section.Section.Count > 0)
                                listofclass.Add(section);
                        }
                        idata.Add("value", listofclass);
                    }
                    else
                    {
                        listofclass.Clear();
                        for (int i = 1; i <= 7; i++)
                        {
                            DaysAndSection section = new DaysAndSection();
                            section.Day = i;
                            listofclass.Add(section);
                        }
                        idata.Add("status", "success");
                        idata.Add("totalRows", 7);
                        idata.Add("value", listofclass);
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }    
        /// <summary>
        /// Method to week total weeks in a semester by its number
        /// </summary>
        /// <param name="semNum"></param>
        /// <returns>NO. of total weeks</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetTotalWeek(string semNum)
        {
            Dictionary<string, object> val = new Dictionary<string, object>();
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                val.Add("status", "fail");
                val.Add("errorMessage", "Session Expired");
                val.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    DataTable r = schedule.GetTotalWeek(semNum);
                    val.Add("status", "success");
                    if (r.Rows.Count > 0)
                    {
                        foreach (DataRow dr in r.Rows)
                        {
                            val.Add("value", dr["totalweeks"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    val.Add("status", "fail");
                    val.Add("ErrorMessage", ex.Message);
                }
            }
            return val;
        }
        #endregion

        #region Schedule and Reserve Schedule

        /// <summary>
        /// Method to get Schedule by building,week and day
        /// </summary>
        /// <param name="data"></param>
        /// <returns>schedule list</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetScheduleByDay(Dictionary<string, object> data)
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
                Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
                List<object> dat = new List<object>();
                try
                {
                    if (Session["UserLoggedIn"].ToString() != null)
                    {
                        var userid = Session["UserLoggedIn"].ToString();
                        var building = data["building"].ToString();
                        var sem = Convert.ToInt32(data["semNum"]);
                        var week = Convert.ToInt32(data["weekNum"]);
                        var day = Convert.ToInt32(data["dayNum"]);

                        var pgindex = Convert.ToInt32(data["pageIndex"]);
                        var pgsize = Convert.ToInt32(data["pageSize"]);

                        dat = schedule.GetScheduleByDay(building, sem, week, day, userid, pgindex, pgsize);

                        idata.Add("status", "success");
                        int total = Convert.ToInt32(dat[0]);
                        KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                        idata.Add("totalRows", total);
                        DataTable dt = dat[1] as DataTable;
                        List<ScheduleDataStructureByBuildingWeek> schedules = new List<ScheduleDataStructureByBuildingWeek>();
                        if (dt.Rows.Count >= 1)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ScheduleDataStructureByBuildingWeek scheduleDataStructure = new ScheduleDataStructureByBuildingWeek()
                                {
                                    RowNum = Convert.ToInt32(dr["RowNumber"]),
                                    ClassId = dr["classid"].ToString(),
                                    Classname = dr["ClassName"].ToString(),
                                    Section1 = dr["Section1"].ToString(),
                                    Section2 = dr["Section2"].ToString(),
                                    Section3 = dr["Section3"].ToString(),
                                    Section4 = dr["Section4"].ToString(),
                                    Section5 = dr["Section5"].ToString(),
                                    Section6 = dr["Section6"].ToString(),
                                    Section7 = dr["Section7"].ToString(),
                                    Section8 = dr["Section8"].ToString(),
                                    Section9 = dr["Section9"].ToString(),
                                    Section10 = dr["Section10"].ToString(),
                                    Section11 = dr["Section11"].ToString(),
                                    Section12 = dr["Section12"].ToString()
                                };
                                schedules.Add(scheduleDataStructure);
                            }
                            idata.Add("value", schedules);
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        idata.Add("status", "fail");
                        idata.Add("errorMessage", "Session Expired");
                        idata.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }

        /// <summary>
        /// Method to get Schedule by building and date
        /// </summary>
        /// <param name="data"></param>
        /// <returns>schedule list</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetScheduleByDate(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            var cc = HttpContext.Current.Session;
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
                    if (HttpContext.Current.Session["UserLoggedIn"].ToString() != null)
                    {
                        var userid = HttpContext.Current.Session["UserLoggedIn"].ToString();
                        List<object> dat = new List<object>();

                        var building = data["building"].ToString();
                        var date = data["date"].ToString();

                        var pgindex = data["pageIndex"].ToString();
                        var pgsize = data["pageSize"].ToString();
                        Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
                        dat = schedule.GetScheduleByDate(building, date, userid, pgindex, pgsize);

                        idata.Add("status", "success");
                        int total = Convert.ToInt32(dat[0]);
                        KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                        idata.Add("totalRows", total);
                        DataTable dt = dat[1] as DataTable;
                        List<ScheduleDataStructureByBuildingWeek> schedules = new List<ScheduleDataStructureByBuildingWeek>();
                        if (dt.Rows.Count >= 1)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                ScheduleDataStructureByBuildingWeek scheduleDataStructure = new ScheduleDataStructureByBuildingWeek()
                                {
                                    RowNum = Convert.ToInt32(dr["RowNumber"]),
                                    ClassId = dr["classid"].ToString(),
                                    Classname = dr["ClassName"].ToString(),
                                    Section1 = dr["Section1"].ToString(),
                                    Section2 = dr["Section2"].ToString(),
                                    Section3 = dr["Section3"].ToString(),
                                    Section4 = dr["Section4"].ToString(),
                                    Section5 = dr["Section5"].ToString(),
                                    Section6 = dr["Section6"].ToString(),
                                    Section7 = dr["Section7"].ToString(),
                                    Section8 = dr["Section8"].ToString(),
                                    Section9 = dr["Section9"].ToString(),
                                    Section10 = dr["Section10"].ToString(),
                                    Section11 = dr["Section11"].ToString(),
                                    Section12 = dr["Section12"].ToString()
                                };
                                schedules.Add(scheduleDataStructure);
                            }
                            idata.Add("value", schedules);
                        }
                    }
                    else
                    {
                        HttpContext.Current.Session.Abandon();
                        idata.Add("status", "fail");
                        idata.Add("errorMessage", "Session Expired");
                        idata.Add("customErrorCode", "440");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                    if(ex.Data["Server Error Code"].ToString() == "1292")
                    {
                        idata.Add("customMessage", "No data found");
                    }
                }                
            }
            return idata;
        }
        /// <summary>
        /// Methods to get week, year, semester in which the date falls 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>returns week year,semester</returns>
               
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetWeekYearSemester(string date)
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
                    Schedule sc = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
                    string week = sc.GetWeekByDate(date);
                    string[] dat = sc.GetYearAndSemester(date);
                    idata.Add("status", "success");
                    idata.Add("weekNum", week);
                    idata.Add("semNum", dat[0]);
                    idata.Add("yearNum", dat[1]);
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }
        
        /// <summary>
        /// Method to add new reserve/appointment schedule
        /// </summary>
        /// <param name="data"></param>
        /// <returns>returns success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> AddReserveSchedule(Dictionary<string, object> data)
        {
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
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
                    List<string> name = new List<string>();
                    name.Add(data["schoolYear"].ToString());
                    name.Add(data["semNum"].ToString());
                    name.Add(data["week"].ToString());
                    name.Add(data["reservedate"].ToString());
                    name.Add(data["section"].ToString());
                    name.Add(data["classId"].ToString());
                    name.Add(data["borrowingUnit"].ToString());
                    name.Add(data["phoneNum"].ToString());
                    name.Add(data["personName"].ToString());
                    name.Add(data["personID"].ToString());
                    name.Add(data["contactNum"].ToString());
                    name.Add(data["purpose"].ToString());
                    name.Add(data["reservationPurpose"].ToString());
                    name.Add(data["equipment"].ToString());
                    name.Add(data["OpenMode"].ToString());
                    int r = -1;
                    r = schedule.SaveReserveSchedule(name);
                    if (r > 0)
                    {
                        idata.Add("status", "success");
                        idata.Add("totalRows", r);
                    }
                    else
                        idata.Add("status", "fail");
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }

        /// <summary>
        /// Method to get list of reserve/appointment schedules
        /// </summary>
        /// <param name="data"></param>
        /// <returns>list of reserve/appointment schedule</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetReserveScheduleList(Dictionary<string,string> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<ReserveScheduleListDataStructure> reserveScheduleLists = new List<ReserveScheduleListDataStructure>();
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
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
                    List<object> res = schedule.GetReserveSchedule(data);
                    DataTable r = res[1] as DataTable;
                    idata.Add("status", "Success");
                    if (r.Rows.Count > 0)
                    {
                        idata.Add("totalRows", res[0].ToString());
                        foreach (DataRow dr in r.Rows)
                        {
                            ReserveScheduleListDataStructure reserve = new ReserveScheduleListDataStructure()
                            {
                                ID = Convert.ToInt32(dr["id"]),
                                SchoolYear = dr["SchoolYear"].ToString(),
                                Semester = dr["semestername"].ToString(),
                                Week = dr["Week"].ToString(),
                                Date = DateTime.Parse(dr["reservedate"].ToString()).ToString("yyyy-MM-dd"),
                                Section = dr["Section"].ToString(),
                                Classroom = dr["Classname"].ToString(),
                                BorrowingUnit = dr["BorrowingUnit"].ToString(),
                                WorkPhone = dr["WorkPhone"].ToString(),
                                PersonName = dr["PersonName"].ToString(),
                                PersonID = dr["personID"].ToString(),
                                ContactNum = dr["ContactNo"].ToString(),
                                Purpose = dr["purpose"].ToString(),
                                ReservationPurpose = dr["Reason"].ToString(),
                                Equipments = dr["ReservationDevices"].ToString(),
                                Status = dr["Status"].ToString(),
                                OpenMode=dr["OpenMode"].ToString()
                                
                            };
                            reserveScheduleLists.Add(reserve);
                        }
                        idata.Add("value", reserveScheduleLists);
                    }
                    else
                    {
                        idata.Add("totalRows", 0);
                        idata.Add("value", "");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }

        /// <summary>
        /// Method to update the status of reserve schedule from pending to Reject/approve
        /// </summary>
        /// <param name="data"></param>
        /// <returns>success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> UpdateReserveScheduleStatus(Dictionary<string, object> data)
        {
            Schedule schedule = new Schedule(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, object> idata = new Dictionary<string, object>();
            int r = 0;
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
                    var status = data["status"].ToString();
                    var id = data["id"].ToString();
                    r = schedule.ChangeReserveStatus(status, id);

                    if (r > 0)
                    {
                        idata.Add("status", "success");
                    }
                    else
                    {
                        idata.Add("status", "fail");
                    }
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

        #region Web Methods Not in use currently
       
       
        

        public List<BusySchedule> GetFreeSchedule(DataTable dt)
        {
            List<BusySchedule> idata = new List<BusySchedule>();
            int maxweek = 22;
            for (int i = 1; i <= maxweek; i++)
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
                catch (Exception ex)
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

        /// <summary>
        /// Gets the weekdays.
        /// </summary>
        /// <param name="idata">The idata.</param>
        public void GetWeekdays(List<BusySchedule> idata)
        {
            string[] totaldays = new string[] { "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday" };


            foreach (BusySchedule busy in idata)
            {
                foreach (string d in totaldays)
                {
                    if (busy.Day.Contains(d))
                    {

                    }
                }
            }
        }
        #endregion
    }
    #region Data Structure

    /// <summary>
    /// structure for building id and name for task of transferring schedule
    /// </summary>
    class BuildingIDName
    {
        public string BuildingName { get; set; }
        public string BuildingId { get; set; }
    }

    /// <summary>
    /// structure for teacher name and id for the specific course
    /// </summary>
    class TeacherDetails
    {
        public string TeacherName { get; set; }
        public string TeacherId { get; set; }
    }

    /// <summary>
    /// structure for transfer schedule List
    /// </summary>
    public class TransferScheduleListStructure
    {
        public string OldClassName { get; set; }
        public string NewClassName { get; set; }
        public string OldTime { get; set; }
        public string NewTime { get; set; }
        public string OldTeacherName { get; set; }
        public string NewTeacherName { get; set; }
        public string ClassType { get; set; }
        public string CurrentStatus { get; set; }
        public string Reason { get; set; }
        public string CourseName { get; set; }
        public string ID { get; set; }

    }
    /// <summary>
    /// Structure for Details of the schedule which is requested to be transfered .
    /// </summary>
    public class TransferCourseDetailStructure
    {
        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public string ClassName { get; set; }
        public string ClassId { get; set; }
        public string WeekStart { get; set; }
        public string Weekend { get; set; }
        public string DayNum { get; set; }
        public string Section { get; set; }
        public string Building { get; set; }
        public string StartDate { get; set; }
        public string SemNum { get; set; }
        public string TotalWeeks { get; set; }
    }
    /// <summary>
    /// Structure for classid and name
    /// </summary>
    class AvailClasses
    {
        public string ClassName { get; set; }
        public string ClassId { get; set; }
    }

    /// <summary>
    /// Data structure to return free days and section in a week in a specific class
    /// Total Sections in database is fixed and so here also
    /// </summary>
    public class DaysAndSection
    {
        public int Day { get; set; }
        public List<int> Section { get; set; }
        public DaysAndSection()
        {
            Section = new List<int>() { 1, 3, 5, 7, 9, 11 };
        }
    }
    /// <summary>
    /// Structure for schedule
    /// </summary>
    class ScheduleDataStructureByBuildingWeek
    {
        public int RowNum { get; set; }
        public string ClassId { get; set; }
        public string Classname { get; set; }
        public string Section1 { get; set; }
        public string Section2 { get; set; }
        public string Section3 { get; set; }
        public string Section4 { get; set; }
        public string Section5 { get; set; }
        public string Section6 { get; set; }
        public string Section7 { get; set; }
        public string Section8 { get; set; }
        public string Section9 { get; set; }
        public string Section10 { get; set; }
        public string Section11 { get; set; }
        public string Section12 { get; set; }
    }
    /// <summary>
    /// Structure for reserve/appointment schedule
    /// </summary>
    class ReserveScheduleListDataStructure
    {
        public int ID { get; set; }
        public string SchoolYear { get; set; }
        public string Semester { get; set; }
        public string Week { get; set; }
        public string Date { get; set; }
        public string Section { get; set; }
        public string Classroom { get; set; }
        public string BorrowingUnit { get; set; }
        public string WorkPhone { get; set; }
        public string PersonName { get; set; }
        public string PersonID { get; set; }
        public string ContactNum { get; set; }
        public string Purpose { get; set; }
        public string ReservationPurpose { get; set; }
        public string Equipments { get; set; }
        public string Status { get; set; }
        public string OpenMode { get; set; }
    }
    #endregion
}
