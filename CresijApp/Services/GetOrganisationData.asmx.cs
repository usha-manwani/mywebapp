using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for GetOrganisationData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GetOrganisationData : WebService
    {
        /// <summary>
        /// Structure for Building Details as a result/response to the request
        /// </summary>
        private class BuildingDataStructure
        {
            public string ID { get; set; }
            public string BuildingName { get; set; }
            public string SchoolName { get; set; }
            public string BuildingCode { get; set; }
            public string Queue { get; set; }
            public string Type { get; set; }
            public string Remarks { get; set; }
        }
        
        /// <summary>
        /// Method to Get Building Details associated with current user id(session)
        /// </summary>
        /// <param name="data"></param>
        /// <returns>return Dictionary type for Building Details list with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetBuildingsDetails(Dictionary<string,object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<BuildingDataStructure> buildings = new List<BuildingDataStructure>();
            GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            DataTable dt = new DataTable();
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
                    var userid = HttpContext.Current.Session["UserLoggedIn"].ToString();
                    var pageIndex = data["pageIndex"].ToString();
                    var pageSize = data["pageSize"].ToString();
                    var result = gd.GetOrgBuildingInfo(pageIndex, pageSize,userid);
                    idata.Add("status", "success");
                    int total = Convert.ToInt32(result[0]);
                    KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                    idata.Add("totalRows", total);
                    dt = result[1] as DataTable;
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            BuildingDataStructure st = new BuildingDataStructure()
                            {
                                ID = row["id"].ToString(),
                                BuildingName = row["BuildingName"].ToString(),
                                SchoolName = row["schoolName"].ToString(),
                                BuildingCode = row["buildingcode"].ToString(),
                                Queue = row["Queue"].ToString(),
                                Type = row["Public"].ToString(),
                                Remarks = row["Remarks"].ToString()
                            };
                            buildings.Add(st);
                        }
                    }
                    idata.Add("value", buildings);
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
        /// Structure for Student Details as a result/response to the request
        /// </summary>
        
        private class StudentDataStructure
        {
            public string StudentID { get; set; }
            public string StudentName { get; set; }
            public string Gender { get; set; }
            public string DeptName { get; set; }
            public string Phone { get; set; }
            public string Age { get; set; }
            public string IdCard { get; set; }
            public string OneCard { get; set; }
            public string DateOfBirth { get; set; } 
        }

        /// <summary>
        /// Method to get Student Details with optional search text
        /// </summary>
        /// <param name="data"></param>
        /// <returns>return Dictionary type for Student details list with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetStudentData(Dictionary<string, object> data)
        {
            Dictionary<string,object> idata = new Dictionary<string, object>();
            GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
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
                    var text = "";
                    if (data.ContainsKey("query"))
                    {
                        text = data["query"].ToString();
                    }
                    List<object> dat = gd.GetStudentInfo(data["pageIndex"].ToString(), data["pageSize"].ToString(),text);
                    idata.Add("status", "success");
                    int total = Convert.ToInt32(dat[0]);
                    KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                    idata.Add("totalRows", total);
                    List<StudentDataStructure> students = new List<StudentDataStructure>();
                    DataTable dt = dat[1] as DataTable;
                    foreach (DataRow row in dt.Rows)
                    {
                        StudentDataStructure studentData = new StudentDataStructure()
                        {
                            StudentID = row["studentid"].ToString(),
                            StudentName = row["studentName"].ToString(),
                            Gender = row["gender"].ToString(),
                            Age = row["age"].ToString(),
                            DeptName = row["deptcode"].ToString(),
                            Phone = row["phone"].ToString(),
                            IdCard = row["idcard"].ToString(),
                            OneCard = row["onecard"].ToString(),
                            DateOfBirth=row["dateofbirth"].ToString()
                        };
                        students.Add(studentData);
                    }
                    idata.Add("value", students);
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
        /// Structure for teacher details as a result/response to the request
        /// </summary>
        private class TeacherDataStructure
        {
            public string TeacherID { get; set; }
            public string TeacherName { get; set; }
            public string Gender { get; set; }
            public string DeptName { get; set; }
            public string Phone { get; set; }
            public string Age { get; set; }
            public string IdCard { get; set; }
            public string OneCard { get; set; }
            public string DateOfBirth { get; set; }
        }

        /// <summary>
        /// Method to get Teacher details with optional search text
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Dictionary with TeacherDataStructure List and success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetTeacherData(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            string text = "";
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
                    if (data.ContainsKey("query"))
                    {
                        text = data["query"].ToString();
                    }
                    List<object> dat = gd.GetTeacherInfo(data["pageIndex"].ToString(), data["pageSize"].ToString(),text);
                    idata.Add("status", "success");
                    int total = Convert.ToInt32(dat[0]);
                    KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                    idata.Add("totalRows", total);
                    List<TeacherDataStructure> students = new List<TeacherDataStructure>();
                    DataTable dt = dat[1] as DataTable;
                    foreach (DataRow row in dt.Rows)
                    {
                        TeacherDataStructure studentData = new TeacherDataStructure()
                        {
                            TeacherID = row["teacherID"].ToString(),
                            TeacherName = row["teacherName"].ToString(),
                            Gender = row["gender"].ToString(),
                            Age = row["age"].ToString(),
                            DeptName = row["faculty"].ToString(),
                            Phone = row["phone"].ToString(),
                            IdCard = row["idcard"].ToString(),
                            OneCard = row["onecard"].ToString(),
                            DateOfBirth = row["dateofbirth"].ToString()
                        };
                        students.Add(studentData);
                    }
                    idata.Add("value", students);
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
        /// Structure for User Details as a result/response to a request
        /// </summary>
        public class UserDataStructure
        {
            public string SerialNo { get; set; }
            public string LoginID { get; set; }
            public string UserName { get; set; }
            public string PersonType { get; set; }
            
            public string PersonnelStatus { get; set; }
            public string Phone { get; set; }
            public string DepartmentId { get; set; }
            public string Notes { get; set; }
            public string StartDate { get; set; }
            public string ExpireDate { get; set; }
        }

        /// <summary>
        /// Method to get User Details along with optional search text
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Dictionary with UserDataStructure List and success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetUserData(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            DataTable dt = new DataTable();
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
                    var text = "";
                    if (data.ContainsKey("query"))
                    {
                        text = data["query"].ToString();
                    }
                    List<object> result = new List<object>();
                    result = gd.GetuserInfo(data["pageIndex"].ToString(), data["pageSize"].ToString(),text);
                    idata.Add("status", "success");
                    idata.Add("totalRows", result[0].ToString());
                    dt = result[1] as DataTable;
                    List<UserDataStructure> list = new List<UserDataStructure>();
                    if (dt.Rows.Count > 0)
                    {
                        list = (from DataRow dr in dt.Rows
                                select new UserDataStructure()
                                {
                                    SerialNo = dr["SerialNo"].ToString(),
                                    LoginID = dr["LoginID"].ToString(),
                                    UserName = dr["UserName"].ToString(),
                                    PersonType = dr["PersonType"].ToString(),
                                    
                                    PersonnelStatus = dr["PersonnelStatus"].ToString(),
                                    Phone = dr["phone"].ToString(),
                                    Notes = dr["Notes"].ToString(),
                                    
                                    StartDate = dr["startdate"].ToString(),
                                    ExpireDate = dr["expiredate"].ToString(),

                                }).ToList();
                    }
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
       
        /// <summary>
        /// Get user details by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dictionary with specific user details and success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetUserByID(string id)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            Dictionary<string, string> list = new Dictionary<string, string>();
            GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
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
                    DataTable dt = gd.GetUserDataonDemand(id);
                    idata.Add("status", "success");
                    if (dt.Rows.Count > 0)
                    {
                        list.Add("SerialNo", dt.Rows[0]["SerialNo"].ToString());
                        list.Add("LoginID", dt.Rows[0]["LoginID"].ToString());
                        list.Add("UserName", dt.Rows[0]["UserName"].ToString());
                        list.Add("PersonType", dt.Rows[0]["PersonType"].ToString());
                        													  
                        list.Add("PersonnelStatus", dt.Rows[0]["PersonnelStatus"].ToString());
                        list.Add("Notes", dt.Rows[0]["Notes"].ToString());
                        list.Add("Password", dt.Rows[0]["Password"].ToString());
                        list.Add("phone", dt.Rows[0]["phone"].ToString());
                        list.Add("expireDate", dt.Rows[0]["expiredate"].ToString());
                        list.Add("startDate", dt.Rows[0]["startdate"].ToString());
                    }
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

        /// <summary>
        /// Structure for providing details of a class/class list from database
        /// </summary>
        public class ClassDetails{
            public string Classid { get; set; }
            public string Classname { get; set; }
            public string Building { get; set; }
            public string Floor { get; set; }
            public int BuildingId { get; set; }
            public int FloorId { get; set; }
            public string Seat { get; set; }
            public string Ccip { get; set; }
            public string CamipS { get; set; }
            public string CamipT { get; set; }
            public string DesktopIp { get; set; }
            public string RecorderIp { get; set; }
            public string CCmac { get; set; }
            //public string CCPort { get; set; }
            //public string CCuserid { get; set; }
            //public string CCpass { get; set; }
            public string CamSmac { get; set; }
            //public string CamSPort { get; set; }
           // public string CamSuserid { get; set; }
           // public string CamSpass { get; set; }
            public string CamTmac { get; set; }
            public string CamPort { get; set; }
            public string Camuserid { get; set; }
            public string Campass { get; set; }
            public string Desktopmac { get; set; }
            //public string DeskPort { get; set; }
            //public string Deskuserid { get; set; }
            //public string Deskpass { get; set; }
            public string Recordermac { get; set; }
            //public string RecorderPort { get; set; }
            //public string Recorderuserid { get; set; }
            //public string Recorderpass { get; set; }
            public string CallHelpIP { get; set; }
            public string CallHelpmac { get; set; }
        }
        /// <summary>
        /// Structure for providing Devices details from the ClassDetails table in database
        /// </summary>
        public class DeviceDetails
        {
            public string Ip { get; set; }
            public string Mac { get; set; }
            public string Port { get; set; }
            public string Userid { get; set; }
            public string Pass { get; set; }
        }

        /// <summary>
        ///Method to Get List of Classroom data 
        ///optional search text as "query" param inside "data"
        /// </summary>
        /// <param name="data"></param>
        /// <returns> Dictionary with ClassDetails list and success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetClassData(Dictionary<string, string> data)
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
               var userid= HttpContext.Current.Session["UserLoggedIn"].ToString();
                try
                {
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable dt = new DataTable();
                    List<ClassDetails> cdList = new List<ClassDetails>();
                    List<object> d = new List<object>();
                    var text = "";
                    if (data.ContainsKey("query"))
                    {
                        text = data["query"].ToString();
                    }
                    d = gd.GetClassroomInfo(data["pageIndex"].ToString(), data["pageSize"].ToString(),userid,text);
                    idata.Add("status", "success");
                    idata.Add("totalRow", d[0].ToString());
                    dt = d[1] as DataTable;
                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dt.Rows)
                        {
                            ClassDetails cd = new ClassDetails()
                            {
                                Classid = dr["classID"].ToString(),
                                Classname = dr["className"].ToString(),
                                Building = dr["buildingname"].ToString(),
                                Floor = dr["floor"].ToString(),
                                Seat = dr["seats"].ToString(),
                                CamipS = dr["camipS"].ToString(),
                                CamipT = dr["camipT"].ToString(),
                                CamSmac = dr["camSmac"].ToString(),
                                CamTmac = dr["camTmac"].ToString(),
                                CamPort = dr["camPort"].ToString(),
                                Campass = dr["camPass"].ToString(),
                                Camuserid = dr["camuserid"].ToString(),
                                Ccip = dr["ccequipIP"].ToString(),
                                CCmac = dr["ccmac"].ToString(),
                                DesktopIp = dr["desktopIP"].ToString(),
                                Desktopmac = dr["deskmac"].ToString(),
                                RecorderIp = dr["recordingEquip"].ToString(),
                                Recordermac = dr["Recordermac"].ToString(),
                                CallHelpIP = dr["callhelpip"].ToString(),
                                CallHelpmac = dr["callhelpmac"].ToString(),
                                BuildingId = Convert.ToInt32(dr["buildingId"]),
                                FloorId =Convert.ToInt32(dr["floorid"])
                            };
                            cdList.Add(cd);
                        }
                    }
                    idata.Add("value", cdList);
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
        ///Method to Get List of Operation Management data 
        ///optional search text as "query" param inside "data"
        /// </summary>
        /// <param name="data"></param>
        /// <returns>list of Opedata with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetOpedata(Dictionary<string, object> data)
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
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable dt = new DataTable();
                    List<object> dd = new List<object>();
                    var text = "";
                    if (data.ContainsKey("query"))
                    {
                        text = data["query"].ToString();
                    }
                    dd = gd.GetCapitalInfo(data["pageIndex"].ToString(), data["pageSize"].ToString(),text);
                    idata.Add("status", "success");
                    idata.Add("totalRows", dd[0].ToString());
                    dt = dd[1] as DataTable;
                    List<Opedata> opeList = new List<Opedata>();
                    opeList = (from DataRow dr in dt.Rows
                               select new Opedata()
                               {
                                   Sno = Convert.ToInt32(dr["serialno"]),
                                   Devicename = dr["devicename"].ToString(),
                                   Assetno = dr["assetno"].ToString(),
                                   Model = dr["model"].ToString(),
                                   Spec = dr["specification"].ToString(),
                                   Devicetype = dr["devicetype"].ToString(),
                                   Price = dr["price"].ToString(),
                                   Factory = dr["factory"].ToString(),
                                   Mfd = dr["dateofmanufacture"].ToString(),
                                   Dopurchase = dr["dateofpurchase"].ToString(),
                                   Dod = dr["dateofdelivery"].ToString(),
                                   Warrantytime = dr["warrantytime"].ToString(),
                                   Locationtype = dr["locationType"].ToString(),
                                   EquipStat = dr["equipmentstatus"].ToString()
                               }).ToList();
                    idata.Add("value", opeList);
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
        /// Structure for Operation Management Data list
        /// </summary>
        public class Opedata
        {
            public int Sno {get ; set; }
            public string Devicename { get; set; }
            public string Assetno { get; set; }
            public string Model { get; set; }
            public string Spec { get; set; }
            public string Devicetype { get; set; }
            public string Price { get; set; }
            public string Factory { get; set; }
            public string Mfd { get; set; }
            public string Dopurchase { get; set; }
            public string Dod { get; set; }
            public string Warrantytime { get; set; }
            public string Locationtype { get; set; }
            public string EquipStat { get; set; }
        }

        /// <summary>
        /// Method to get Building Details based on building id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> building detail with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetBuildingByID(string id)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            Dictionary<string, string> idata = new Dictionary<string, string>();
            GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
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
                    DataTable dt = gd.GetOrgDataonDemand(Convert.ToInt32(id));
                    d.Add("status", "success");
                    idata.Add("id", dt.Rows[0]["id"].ToString());
                    idata.Add("buildingName", dt.Rows[0]["buildingName"].ToString());
                    idata.Add("buildingCode", dt.Rows[0]["buildingCode"].ToString());
                    idata.Add("schoolName", dt.Rows[0]["schoolname"].ToString());
                    idata.Add("queue", dt.Rows[0]["Queue"].ToString());
                    idata.Add("public", dt.Rows[0]["Public"].ToString());
                    idata.Add("remarks", dt.Rows[0]["remarks"].ToString());
                    d.Add("value", idata);
                }
                catch (Exception ex)
                {
                    d.Add("status", "fail");
                    d.Add("errorMessage", ex.Message);
                }
            }
            return d;
        }

        /// <summary>
        /// Structure for getting Central control machine details with class ids and schedule
        /// </summary>
       
        private class IPClassByBuildingStructure
        {
            public int RowNum { get; set; }
            public string ClassName { get; set; }
            public string Floor { get; set; }
            public string ClassId { get; set; }
            public string CCEquipIP { get; set; }
            public string MacAddress { get; set; }
            public string ScheduleId { get; set; }
            public string CourseId { get; set; }
            public string CourseName { get; set; }
            public string TeacherName { get; set; }
        }
        /// <summary>
        /// Method used for getting list of central control machines with class ids 
        /// and the current schedule by providing building id as input
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Dictoinary data with IPClassByBuildingStructure List with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetIPClassByBuilding(Dictionary<string, object> data)
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
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    List<object> dat = gd.GetIPClassByBuilding(data["pageIndex"].ToString(), data["pageSize"].ToString(),
                        data["building"].ToString(), HttpContext.Current.Session["UserLoggedIn"].ToString());
                    DataTable dt = dat[1] as DataTable;
                    int total = Convert.ToInt32(dat[0]);
                    KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                    idata.Add("totalRows", total);
                    List<IPClassByBuildingStructure> iPClassByBuildings = new List<IPClassByBuildingStructure>();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            IPClassByBuildingStructure iPClass = new IPClassByBuildingStructure()
                            {
                                RowNum = Convert.ToInt32(dr["rownumber"]),
                                ClassName = dr["classname"].ToString(),
                                Floor = dr["floor"].ToString(),
                                ClassId = dr["classid"].ToString(),
                                CCEquipIP = dr["ccequipip"].ToString(),
                                MacAddress = dr["ccmac"].ToString(),
                                ScheduleId = dr["scheduleid"].ToString(),
                                CourseId = dr["courseid"].ToString(),
                                CourseName = dr["coursename"].ToString(),
                                TeacherName =dr["teachername"].ToString()
                                
                            };
                            iPClassByBuildings.Add(iPClass);
                        }
                    }
                    idata.Add("value", iPClassByBuildings);
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
        /// Method used for getting list of central control machines with class ids and
        /// the current schedule by providing building id and floor id as input
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Dictoinary data with IPClassByBuildingStructure List with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetIPClassByBuildingFloor(Dictionary<string, object> data)
        {            
            Dictionary<string,object> idata = new Dictionary<string, object>();
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
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    List<object> dat = gd.GetIPClassByBuildingFloor(data["building"].ToString(), data["floor"].ToString(),
                        HttpContext.Current.Session["UserLoggedIn"].ToString(), data["pageIndex"].ToString(), Convert.ToInt32(data["pageSize"].ToString()));
                    DataTable dt = dat[1] as DataTable;
                    int total = Convert.ToInt32(dat[0]);
                    KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                    idata.Add("totalRows", total);
                    List<IPClassByBuildingStructure> iPClassByBuildings = new List<IPClassByBuildingStructure>();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            IPClassByBuildingStructure iPClass = new IPClassByBuildingStructure()
                            {
                                RowNum = Convert.ToInt32(dr["rownumber"]),
                                ClassName = dr["classname"].ToString(),
                                ClassId =dr["classid"].ToString(),
                                Floor = dr["floor"].ToString(),
                                CCEquipIP = dr["ccequipip"].ToString(),
                                MacAddress=dr["ccmac"].ToString(),
                                ScheduleId = dr["scheduleid"].ToString(),
                                CourseId = dr["courseid"].ToString(),
                                CourseName = dr["coursename"].ToString(),
                                TeacherName = dr["teachername"].ToString()
                            };
                            iPClassByBuildings.Add(iPClass);
                        }
                    }
                    idata.Add("value", iPClassByBuildings);
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
        /// Method to Get Classdetails by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Class Details of specific classid with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetClassDataById(string id)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
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
                    DataTable dt = gd.GetClassData(id);
                    if (dt.Rows.Count > 0)
                    {
                        idata.Add("status", "success");
                        foreach (DataRow dr in dt.Rows)
                        {
                            ClassDetails cd = new ClassDetails()
                            {
                                Classid = dr["classID"].ToString(),
                                Classname = dr["className"].ToString(),
                                Building = dr["buildingname"].ToString(),
                                Floor = dr["floor"].ToString(),
                                Seat = dr["seats"].ToString(),
                                CamipS = dr["camipS"].ToString(),
                                CamipT = dr["camipT"].ToString(),
                                CamSmac = dr["camSmac"].ToString(),
                                CamTmac = dr["camTmac"].ToString(),
                                CamPort = dr["camPort"].ToString(),
                                Campass = dr["camPass"].ToString(),
                                Camuserid = dr["camuserid"].ToString(),
                                Ccip = dr["ccequipIP"].ToString(),
                                CCmac = dr["ccmac"].ToString(),
                                DesktopIp = dr["desktopIP"].ToString(),
                                Desktopmac = dr["deskmac"].ToString(),
                                RecorderIp = dr["recordingEquip"].ToString(),
                                Recordermac = dr["Recordermac"].ToString(),
                                CallHelpIP = dr["callhelpip"].ToString(),
                                CallHelpmac = dr["callhelpmac"].ToString(),
                                BuildingId =Convert.ToInt32(dr["buildingid"]),
                                FloorId =Convert.ToInt32(dr["floorid"])
                            };
                            idata.Add("value", cd);
                        }

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
        /// Structure for returning Floor Name and ID
        /// </summary>
        class FloorList
        {
            public string FloorName { get; set; }
            public string FloorId { get; set; }
        }

        /// <summary>
        /// Method used to get floor List by building Id
        /// </summary>
        /// <param name="building"></param>
        /// <returns>Dictoinary data with Floor Name and id List and success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetFloorlist(string building)
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
                try
                {
                    List<FloorList> idata = new List<FloorList>();
                    
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable dt = gd.GetFloorlist(building);
                    if (dt.Rows.Count > 0)
                    {
                        val.Add("totalRows", dt.Rows.Count);
                        foreach (DataRow dr in dt.Rows)
                        {
                            FloorList fl = new FloorList()
                            {
                                FloorId = dr["id"].ToString(),
                                FloorName = dr["floor"].ToString()
                            };

                            idata.Add(fl);
                        }

                    }
                    val.Add("value", idata);
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
        /// method use to get School name from building ID
        /// </summary>
        /// <param name="building"></param>
        /// <returns>returns school name with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetSchoolName(string building)
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
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable dt = gd.GetSchoolName(building);
                    if (dt.Rows.Count > 0)
                        foreach (DataRow dr in dt.Rows)
                        {
                            idata.Add("status", "success");
                            idata.Add("value", dt.Rows[0]["schoolName"].ToString());
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
        /// Method use to get class name and id by the central control machine ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns>classname and class id with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetClassByIP(string ip)
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
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable dt = gd.GetClassByIP(ip); // Method to connect to database to get the required data
                    Dictionary<string, string> val = new Dictionary<string, string>();
                    if (dt.Rows.Count > 0)
                    {
                        idata.Add("status", "success");
                        
                        val.Add("ClassName", dt.Rows[0]["classname"].ToString());
                        val.Add("ClassId", dt.Rows[0]["classid"].ToString());
                    }
                    idata.Add("value", val);
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
        /// Structure to return floor details
        /// </summary>
        private class FloorDataStructure
        {
            public string ID { get; set; }
            public string BuildingName { get; set; }
            public string Floor{ get; set; }
            public string BuildingCode { get; set; }
            public string Queue { get; set; }
            public string Type { get; set; }
            public string Remarks { get; set; }
            public int BuildingID { get; set; }
        }
        
        /// <summary>
        /// MEthod use to get floor details on basis of building id
        /// </summary>
        /// <param name="building"></param>
        /// <returns>floor details with success/fail status</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> GetFloorDetails(string building)
        {
            var idata = new Dictionary<string, object>();
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
                    var userid = HttpContext.Current.Session["UserLoggedIn"].ToString();
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    DataTable dt = gd.GetFloorDetails(building,userid);
                    List<FloorDataStructure> fd = new List<FloorDataStructure>();
                    idata.Add("status", "success");
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            FloorDataStructure st = new FloorDataStructure()
                            {
                                ID = row["id"].ToString(),
                                BuildingName = row["BuildingName"].ToString(),
                                Floor = row["floor"].ToString(),
                                BuildingCode = row["buildingcode"].ToString(),
                                Queue = row["Queue"].ToString(),
                                Type = row["Public"].ToString(),
                                Remarks = row["Remarks"].ToString(),
                                BuildingID = Convert.ToInt32(row["buildingid"])
                            };
                            fd.Add(st);
                        }
                    }
                    idata.Add("value", fd);

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
        /// to get camera details by specific classid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns student and teacher camera details with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetCameraByClassId(string id)
        {
            var idata = new Dictionary<string, object>();
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
                    var classId = Convert.ToInt32(id);
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    var data= gd.GetCameraByClassId(classId);
                    idata.Add("status", "Success");
                    idata.Add("value",data);

                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage",ex.Message);
                }
            }
            return idata;
        }

        /// <summary>
        /// get camera details for multiple classes by class ids
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns student and teacher camera details with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetCameraByMultipleClassIds(List<int> id)
        {
            var idata = new Dictionary<string, object>();
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
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    var data = gd.GetCameraByClassIds(id);
                    idata.Add("status", "Success");
                    idata.Add("value", data);

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
        /// get camera details By different search conditions 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetCameraDetailsByUser(Dictionary<string,object>data)
        {
            var idata = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                idata.Add("status", "fail");
                idata.Add("errorMessage", "Session Expired");
                idata.Add("customErrorCode", "440");
            }
            else
            {
                List<object> data1 = new List<object>();
                try
                {
                    string id = HttpContext.Current.Session["UserLoggedIn"].ToString();
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    var keyword = data["keyword"].ToString(); //search keyword
                    var inOut = Convert.ToBoolean(data["in_or_out"]); //whether to include or exclude class ids in the classid list
                    var filter = Convert.ToBoolean(data["filter"]);// condition
                    if (filter) //with multiple conditions 
                    {                        
                        var state = data["state"] as Dictionary<string, object>;
                        var systemstate = state["system"].ToString();
                        var hasTeacher = Convert.ToBoolean(state["hasTeacher"]);
                        var classids = ((object[])data["classids"]).Cast<int>().ToList();
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            // according to search keyword
                            data1 = gd.GetCameraBySearchWithCondition(id,keyword, Convert.ToInt32(data["pageSize"]),
                            Convert.ToInt32(data["pageIndex"]), systemstate, hasTeacher,classids, inOut);
                        }
                        else
                        {
                            //classes which are permissioned to user
                            data1 = gd.GetCameraByUserIdWithCondition(id, Convert.ToInt32(data["pageSize"]),
                                       Convert.ToInt32(data["pageIndex"]), systemstate, hasTeacher, classids, inOut);
                        }
                        
                    }
                    else
                    {
                        var classids = ((object[])data["classids"]).Cast<int>().ToList();
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            data1 = gd.GetCameraBySearch(id,keyword, Convert.ToInt32(data["pageSize"]),
                            Convert.ToInt32(data["pageIndex"]), classids, inOut);
                        }
                        else
                        {
                            
                            data1 = gd.GetCameraByUserId(id, Convert.ToInt32(data["pageSize"]),
                            Convert.ToInt32(data["pageIndex"]), classids, inOut);
                        }
                    }
                    idata.Add("status", "Success");
                    idata.Add("value", data1[0]);
                    idata.Add("totalRows", data1[1]);

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
        /// use to get desktop event logs from database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetDesktopEventLogs(Dictionary<string, string> data)
        {
            var idata = new Dictionary<string, object>();
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
                    GetOrgData gd = new GetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
                    var data1 = gd.GetDesktopEventLogs(Convert.ToInt32(data["pageSize"]), Convert.ToInt32(data["pageIndex"]));
                    idata.Add("status", "Success");
                    idata.Add("value", data1["data"]);
                    idata.Add("totalRows", data1["Total"]);
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("errorMessage", ex.Message);
                }
            }
            return idata;
        }

    }
}
