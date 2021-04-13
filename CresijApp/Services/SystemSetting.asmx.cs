using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using CresijApp.DataAccess;
using CresijApp.Models;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for SystemSetting
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [ScriptService]
    public class SystemSetting : WebService
    {
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetSystemInfo(int semno)
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
                if (HttpContext.Current.Session["UserLoggedIn"].ToString() == "admin")
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    if (semno != 1 && semno != 2) semno = 1;
                    try
                    {
                        var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                        using (var context = new OrganisationdatabaseEntities(db))
                        {
                            if (context.semesterinfoes.Any(x => x.SemNo == semno))
                            {
                                var ReserveTransfer = context.reserveandtransfers.Where(x => x.SemesterNo == semno).Select(x => x).ToList();
                                List<ReserveTrans> rt = new List<ReserveTrans>();
                                foreach (var r in ReserveTransfer)
                                {
                                    ReserveTrans rs = new ReserveTrans()
                                    {
                                        Type = r.Type,
                                        NonWorkingDays = r.NonWorkingDays != 0 ? true : false,
                                        AutoReview = r.AutoReview != 0 ? true : false,
                                        StartTime = r.StartTime.ToString("yyyy-MM-dd"),
                                        EndTime = r.EndTime.ToString("yyyy-MM-dd"),
                                        SemesterNo = r.SemesterNo,

                                    };
                                    rt.Add(rs);
                                }
                                idata.Add("ReserveTransfer", rt);
                                var Seminfo = context.semesterinfoes.Where(x => x.SemNo == semno).Select(x => x).First();
                                List<SemesterInfo> listSem = new List<SemesterInfo>();
                                if (Seminfo != null)
                                {
                                    SemesterInfo sm = new SemesterInfo()
                                    {
                                        SemesterName = Seminfo.SemesterName,
                                        StartDate = Seminfo.StartDate.ToString("yyyy-MM-dd"),
                                        TotalWeeks = Seminfo.TotalWeeks,
                                        Sunday = Seminfo.Sunday != 0 ? true : false,
                                        Monday = Seminfo.Monday != 0 ? true : false,
                                        Tuesday = Seminfo.Tuesday != 0 ? true : false,
                                        Wednesday = Seminfo.Wednesday != 0 ? true : false,
                                        Thursday = Seminfo.Thursday != 0 ? true : false,
                                        Friday = Seminfo.Friday != 0 ? true : false,
                                        Saturday = Seminfo.Saturday != 0 ? true : false,
                                        AutoHoliday = Seminfo.AutoHoliday != 0 ? true : false,
                                        Semno = Seminfo.SemNo,

                                    };

                                    idata.Add("SemsterInfo", sm);
                                }
                                else idata.Add("SemsterInfo", "");
                                var sectionInfo = context.sectionsinfoes.Where(x => x.SemesterNo == semno).Select(x => x).ToList();
                                List<SectionInfo> secList = new List<SectionInfo>();
                                foreach (var s in sectionInfo)
                                {
                                    SectionInfo sec = new SectionInfo()
                                    {
                                        Section = s.Section,
                                        Semesterno = s.SemesterNo,
                                        StartTime = s.StartTime.ToString(@"hh\:mm"),
                                        StopTime = s.StopTime.ToString(@"hh\:mm"),
                                        Checked = s.Checked != 0 ? true : false
                                    };
                                    secList.Add(sec);
                                }
                                idata.Add("SectionInfo", secList);
                                if (context.systemsettings.Count() > 0)
                                {
                                    var SchoolIn = context.systemsettings.Select(x => x).First();
                                    if (SchoolIn != null)
                                    {
                                        SchoolInfo sc = new SchoolInfo()
                                        {
                                            SchoolEngName = SchoolIn.SchoolEngName,
                                            SchoolName = SchoolIn.SchoolName,
                                            LogoLocation = SchoolIn.LogoLocation,

                                        };

                                        idata.Add("SchoolInfo", sc);
                                    }
                                    else idata.Add("SchoolInfo", "");
                                }
                                else idata.Add("SchoolInfo", "");


                                idata.Add("status", "success");
                            }
                            else
                                idata.Add("status", "None");
                        }
                    }
                    catch (Exception ex)
                    {
                        idata.Add("status", "fail");
                        idata.Add("error", ex.StackTrace);
                    }
                }
                else
                { idata.Add("status", "fail"); idata.Add("Error", "User not authorized"); }
            }
            return idata;
        }

        [WebMethod]
        public Dictionary<string, object> GetSchoolInfo()
        {
            var idata = new Dictionary<string, object>();

            try
            {
                var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                using (var context = new OrganisationdatabaseEntities(db))
                {
                    var semno = context.semesterinfoes.Where(x => x.StartDate < DateTime.Now)
                        .OrderByDescending(x => x.StartDate).Select(x=>x.SemNo).FirstOrDefault();
                    var SchoolIn = context.systemsettings.Select(x => x).First();
                    if (SchoolIn != null)
                    {
                        SchoolInfo sc = new SchoolInfo()
                        {
                            SchoolEngName = SchoolIn.SchoolEngName,
                            SchoolName = SchoolIn.SchoolName,
                            LogoLocation = SchoolIn.LogoLocation,
                        };
                        idata.Add("status", "success");
                        idata.Add("SchoolInfo", sc);
                        idata.Add("Semno", semno);
                    }
                }
            }
            catch (Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("error", ex.StackTrace);
            }
            return idata;
        }
        private class SchoolInfo
        {
            public string SchoolEngName { get; set; }
            public string SchoolName { get; set; }
            public string LogoLocation { get; set; }

        }
        private class SectionInfo
        {
            public int Semesterno { get; set; }
            public string Section { get; set; }
            public string StartTime { get; set; }
            public string StopTime { get; set; }
            public bool Checked { get; set; }

        }
        private class SemesterInfo
        {
            public string SemesterName { get; set; }
            public string StartDate { get; set; }
            public int TotalWeeks { get; set; }
            public bool Sunday { get; set; }
            public bool Monday { get; set; }
            public bool Tuesday { get; set; }
            public bool Wednesday { get; set; }
            public bool Thursday { get; set; }
            public bool Friday { get; set; }
            public bool Saturday { get; set; }
            public int Semno { get; set; }
            public bool AutoHoliday { get; set; }

        }
        private class ReserveTrans
        {
            public string Type { get; set; }
            public bool NonWorkingDays { get; set; }
            public bool AutoReview { get; set; }
            public string StartTime { get; set; }
            public string EndTime { get; set; }
            public int SemesterNo { get; set; }

        }
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> UpdateSystemInfo(Dictionary<string, object> data)
        {
            int result = 0;
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, string> idata = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                //if (HttpContext.Current.Session["UserLoggedIn"].ToString() == "admin")
                // {
                try
                {
                    int semno = Convert.ToInt32(data["Semno"]);
                    var temp = js.Serialize(data["ReserveTransfer"]);
                    var restrans = js.Deserialize<List<ReserveTrans>>(temp);
                    var temp1 = js.Serialize(data["SectionInfo"]);
                    var SectionInfo = js.Deserialize<List<SectionInfo>>(temp1);
                    var temp2 = js.Serialize(data["SemesterInfo"]);
                    var seminfo = js.Deserialize<SemesterInfo>(temp2);
                    var temp3 = js.Serialize(data["SchoolInfo"]);
                    var schinfo = js.Deserialize<systemsetting>(temp3);
                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        foreach (var x in restrans)
                        {
                            if (context.reserveandtransfers.Any(z => z.Type == x.Type && z.SemesterNo == semno))
                            {

                                var resupdate = context.reserveandtransfers.Where(z => z.Type == x.Type && z.SemesterNo == semno).Select(y => y).FirstOrDefault();
                                if (resupdate != null)
                                {
                                    resupdate.NonWorkingDays = x.NonWorkingDays ? Convert.ToSByte(1) : Convert.ToSByte(0);
                                    resupdate.AutoReview = x.AutoReview ? Convert.ToSByte(1) : Convert.ToSByte(0);
                                    resupdate.StartTime = Convert.ToDateTime(x.StartTime);
                                    resupdate.EndTime = Convert.ToDateTime(x.EndTime);
                                }
                            }
                            else
                            {
                                reserveandtransfer rs = new reserveandtransfer()
                                {
                                    Type = x.Type,
                                    NonWorkingDays = x.NonWorkingDays ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                    AutoReview = x.AutoReview ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                    StartTime = Convert.ToDateTime(x.StartTime),
                                    EndTime = Convert.ToDateTime(x.EndTime),
                                    SemesterNo = semno
                                };
                                context.reserveandtransfers.Add(rs);
                            }
                            result = context.SaveChanges();
                        }
                        foreach (var x in SectionInfo)
                        {
                            if (context.sectionsinfoes.Any(z => z.Section == x.Section && z.SemesterNo == semno))
                            {
                                var secupdate = context.sectionsinfoes.Where(z => z.Section == x.Section && z.SemesterNo == semno).Select(z => z).FirstOrDefault();
                                if (secupdate != null)
                                {
                                    secupdate.Section = x.Section;
                                    secupdate.SemesterNo = semno;
                                    secupdate.StartTime = Convert.ToDateTime(x.StartTime).TimeOfDay;
                                    secupdate.StopTime = Convert.ToDateTime(x.StopTime).TimeOfDay;
                                    secupdate.Checked = x.Checked ? Convert.ToSByte(1) : Convert.ToSByte(0);
                                    result = context.SaveChanges();
                                }
                            }
                            else
                            {
                                sectionsinfo ssinfo = new sectionsinfo()
                                {
                                    SemesterNo = semno,
                                    Section = x.Section,
                                    StartTime = Convert.ToDateTime(x.StartTime).TimeOfDay,
                                    StopTime = Convert.ToDateTime(x.StopTime).TimeOfDay,
                                    Checked = x.Checked ? Convert.ToSByte(1) : Convert.ToSByte(0)
                                };
                                context.sectionsinfoes.Add(ssinfo);
                            }
                        }
                        context.SaveChanges();
                        if (context.semesterinfoes.Any(z => z.SemNo == semno))
                        {
                            var semupdate = context.semesterinfoes.Find(semno);
                            semupdate.StartDate = Convert.ToDateTime(seminfo.StartDate).Date;
                            semupdate.TotalWeeks = seminfo.TotalWeeks;
                            semupdate.Monday = seminfo.Monday ? Convert.ToSByte(1) : Convert.ToSByte(0);
                            semupdate.Tuesday = seminfo.Tuesday ? Convert.ToSByte(1) : Convert.ToSByte(0);
                            semupdate.Wednesday = seminfo.Wednesday ? Convert.ToSByte(1) : Convert.ToSByte(0);
                            semupdate.Thursday = seminfo.Thursday ? Convert.ToSByte(1) : Convert.ToSByte(0);
                            semupdate.Friday = seminfo.Friday ? Convert.ToSByte(1) : Convert.ToSByte(0);
                            semupdate.Saturday = seminfo.Saturday ? Convert.ToSByte(1) : Convert.ToSByte(0);
                            semupdate.Sunday = seminfo.Sunday ? Convert.ToSByte(1) : Convert.ToSByte(0);
                            semupdate.AutoHoliday = seminfo.AutoHoliday ? Convert.ToSByte(1) : Convert.ToSByte(0);
                            result = context.SaveChanges();
                        }
                        else
                        {
                            var semobject = new semesterinfo()
                            {
                                StartDate = Convert.ToDateTime(seminfo.StartDate).Date,
                                TotalWeeks = seminfo.TotalWeeks,
                                Monday = seminfo.Monday ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                Tuesday = seminfo.Tuesday ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                Wednesday = seminfo.Wednesday ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                Thursday = seminfo.Thursday ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                Friday = seminfo.Friday ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                Saturday = seminfo.Saturday ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                Sunday = seminfo.Sunday ? Convert.ToSByte(1) : Convert.ToSByte(0),
                                AutoHoliday = seminfo.AutoHoliday ? Convert.ToSByte(1) : Convert.ToSByte(0)
                            };
                            context.semesterinfoes.Add(semobject);
                            result = context.SaveChanges();
                        }
                        if (context.systemsettings.Count() > 0)
                        {
                            var school = context.systemsettings.Select(x => x).First();
                            school.SchoolEngName = schinfo.SchoolEngName;
                            school.SchoolName = schinfo.SchoolName;
                            school.LogoLocation = schinfo.LogoLocation;
                        }
                        else
                        {
                            systemsetting sch = new systemsetting()
                            {
                                SchoolEngName = schinfo.SchoolEngName,
                                SchoolName = schinfo.SchoolName,
                                LogoLocation = schinfo.LogoLocation
                            };
                            context.systemsettings.Add(sch);
                        }
                        context.SaveChanges();
                        idata.Add("status", "Success");
                    }
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("Error", ex.StackTrace);
                }
                //}
                //else
                // { idata.Add("status", "fail"); idata.Add("Error", "User not authorized"); }
            }
            return idata;
        }
        T GetObject<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                type.GetProperty(kv.Key).SetValue(obj, kv.Value);
            }
            return (T)obj;
        }
    }

    public class SectionList
    {
        public string Section { get; set; }
        public string Starttime { get; set; }
        public string Stoptime { get; set; }
    }

}

//[WebMethod(EnableSession = true)]
//public Dictionary<string, string> SaveSystemInfo(Dictionary<string, object> data)
//{
//    int result = 0;
//    Dictionary<string, string> idata = new Dictionary<string, string>();
//    if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
//    {
//        HttpContext.Current.Session.Abandon();
//        idata.Add("status", "fail");
//        idata.Add("errorMessage", "Session Expired");
//        idata.Add("customErrorCode", "440");
//    }
//    else
//    {
//        if (HttpContext.Current.Session["UserLoggedIn"].ToString() == "admin")
//        {
//            try
//            {
//var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
//                using (var context = new OrganisationdatabaseEntities(db))
//                {
//                    var sec = data["Sectionselected"];
//                    var sec1 = ((IEnumerable)sec).Cast<object>();
//                    //IEnumerable<Dictionary<string, object>> section = ((IEnumerable)sec).Cast<object>().ToList().Select(item => (Dictionary<string, object>)item);
//                    List<SectionList> sectionlist = new List<SectionList>();

//                    foreach (Dictionary<string, object> dr in sec1)
//                    {
//                        var test = GetObject<SectionList>(dr);
//                        sectionlist.Add(test);
//                    }

//                    var d = data["Dayselected"];
//                    List<string> strings = ((IEnumerable)d).Cast<object>().ToList().Select(s => (string)s).ToList();
//                    string schoolname = data["Schoolname"].ToString();
//                    string schooleng = data["Schooleng"].ToString();
//                    string logourl = data["Logourl"].ToString();
//                    string semname = data["Semestername"].ToString();
//                    int semno = Convert.ToInt32(data["Semesterno"]);
//                    string semweeks = data["Weeks"].ToString();
//                    string semstartdate = data["Semesterstart"].ToString();
//                    string autoholiday = data["Autoholiday"].ToString();
//                    List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
//                    Dictionary<string, string> allowedDays = new Dictionary<string, string>();
//                    foreach (string s in days)
//                    {
//                        if (strings.Contains(s))
//                        {
//                            allowedDays.Add(s, "true");
//                        }
//                        else { allowedDays.Add(s, "false"); }
//                    }
//                    if (context.systemsettings.Count() > 0)
//                    {
//                        var st = context.systemsettings.Where(x => x.SchoolName == schoolname).Select(x => x);
//                        context.systemsettings.RemoveRange(st);
//                        context.SaveChanges();
//                    }

//                    systemsetting ss = new systemsetting()
//                    {
//                        SchoolEngName = schooleng,
//                        SchoolName = schoolname,
//                        LogoLocation = logourl
//                    };
//                    context.systemsettings.Add(ss);


//                    result = context.SaveChanges();
//                    //SystemInfo cc = new SystemInfo();
//                    //result = cc.SaveSystemInfo(schoolname, schooleng, logourl, semname, semweeks, semstartdate, allowedDays, semno, autoholiday);
//                    if (result > 0)
//                    {

//                        if (context.semesterinfoes.Any(x => x.SemNo == semno))
//                        {
//                            var sem = context.semesterinfoes.Where(x => x.SemNo == semno);
//                            context.semesterinfoes.RemoveRange(sem);
//                            context.SaveChanges();
//                        }

//                        semesterinfo sm = new semesterinfo()
//                        {
//                            SemesterName = semname,
//                            StartDate = Convert.ToDateTime(semstartdate).Date,
//                            TotalWeeks = Convert.ToInt32(semweeks),
//                            Sunday = allowedDays["Sunday"],
//                            Monday = allowedDays["Monday"],
//                            Tuesday = allowedDays["Tuesday"],
//                            Wednesday = allowedDays["Wednesday"],
//                            Thursday = allowedDays["Thursday"],
//                            Friday = allowedDays["Friday"],
//                            Saturday = allowedDays["Saturday"],
//                            SemNo = semno,
//                            AutoHoliday = autoholiday
//                        };

//                        context.semesterinfoes.Add(sm);
//                        if (!context.reserveandtransfers.Any(x => x.Type == "Reserve" && x.SemesterNo == semno))
//                        {
//                            reserveandtransfer re = new reserveandtransfer()
//                            {
//                                AutoReview = data["Resauto"].ToString(),
//                                NonWorkingDays = data["Resnonwork"].ToString(),
//                                Type = "Reserve",
//                                EndTime = Convert.ToDateTime(data["Resstopdate"]).Date,
//                                StartTime = Convert.ToDateTime(data["Resstartdate"]).Date,
//                                SemesterNo = semno
//                            };
//                            context.reserveandtransfers.Add(re);
//                        }
//                        if (!context.reserveandtransfers.Any(x => x.Type == "Transfer" && x.SemesterNo == semno))
//                        {

//                            reserveandtransfer re1 = new reserveandtransfer()
//                            {
//                                AutoReview = data["Transferauto"].ToString(),
//                                NonWorkingDays = data["Transfernonwork"].ToString(),
//                                Type = "Transfer",
//                                EndTime = Convert.ToDateTime(data["Transferstop"]).Date,
//                                StartTime = Convert.ToDateTime(data["Transferstart"]).Date,
//                                SemesterNo = semno
//                            };
//                            context.reserveandtransfers.Add(re1);
//                        }

//                        context.SaveChanges();

//                        foreach (SectionList s in sectionlist)
//                        {
//                            sectionsinfo sectionsinfo = new sectionsinfo();
//                            if (context.sectionsinfoes.Any(x => x.Section == s.Section && x.SemesterNo == semno))
//                            {
//                                var sectionupdate = context.sectionsinfoes.Where(x => x.Section == s.Section && x.SemesterNo == semno).Select(x => x).FirstOrDefault();

//                                if (sectionupdate.id > 0)
//                                {
//                                    sectionupdate.Section = s.Section;
//                                    sectionupdate.SemesterNo = semno;
//                                    sectionupdate.StopTime = Convert.ToDateTime(s.Stoptime).TimeOfDay;
//                                    sectionupdate.StartTime = Convert.ToDateTime(s.Starttime).TimeOfDay;
//                                }
//                            }
//                            else
//                            {
//                                sectionsinfo ssinfo = new sectionsinfo()
//                                {
//                                    SemesterNo = semno,
//                                    Section = s.Section,
//                                    StartTime = Convert.ToDateTime(s.Starttime).TimeOfDay,
//                                    StopTime = Convert.ToDateTime(s.Stoptime).TimeOfDay
//                                };
//                                context.sectionsinfoes.Add(ssinfo);
//                            }
//                        }
//                        context.SaveChanges();
//                    }

//                    idata.Add("status", "success");
//                }
//            }
//            catch (Exception ex)
//            {
//                idata.Add("status", "fail");
//                idata.Add("error", ex.Message);
//            }
//        }
//        else
//        { idata.Add("status", "fail"); idata.Add("Error", "User not authorized"); }
//    }
//    return idata;
//}