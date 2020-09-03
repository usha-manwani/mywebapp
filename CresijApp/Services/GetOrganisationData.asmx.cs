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
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string,object> GetBuildingsDetails(Dictionary<string,object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<BuildingDataStructure> buildings = new List<BuildingDataStructure>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = new DataTable();
            try
            {
                var pageIndex = data["pageIndex"].ToString();
                var pageSize = data["pageSize"].ToString();
                var result = gd.GetOrgBuildingInfo(pageIndex,pageSize);
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
            catch(Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("errorMessage", ex.Message);
            }
            return idata;
        }

        private class StudentDataStructure
        {
            public string StudentID { get; set; }
            public string StudentName { get; set; }
            public string Gender { get; set; }
            public string DeptName { get; set; }
            public string Phone { get; set; }
            public int Age { get; set; }
            public string IdCard { get; set; }
            public string OneCard { get; set; }
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string,object> GetStudentData(Dictionary<string, object> data)
        {
            Dictionary<string,object> idata = new Dictionary<string, object>();
            GetOrgData gd = new GetOrgData();
            try
            {
                List<object> dat = gd.GetStudentInfo(data["pageIndex"].ToString(), data["pageSize"].ToString());
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
                        Age = Convert.ToInt32(row["age"]),
                        DeptName = row["deptcode"].ToString(),
                        Phone = row["phone"].ToString(),
                        IdCard = row["idcard"].ToString(),
                        OneCard = row["onecard"].ToString()
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
            return idata;
        }

        private class TeacherDataStructure
        {
            public string TeacherID { get; set; }
            public string TeacherName { get; set; }
            public string Gender { get; set; }
            public string DeptName { get; set; }
            public string Phone { get; set; }
            public int Age { get; set; }
            public string IdCard { get; set; }
            public string OneCard { get; set; }
        }
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetTeacherData(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            GetOrgData gd = new GetOrgData();
            try
            {
                List<object> dat = gd.GetTeacherInfo(data["pageIndex"].ToString(), data["pageSize"].ToString());
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
                        Age = Convert.ToInt32(row["age"]),
                        DeptName = row["faculty"].ToString(),
                        Phone = row["phone"].ToString(),
                        IdCard = row["idcard"].ToString(),
                        OneCard = row["onecard"].ToString()
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


            return idata;
        }

        public class UserDataStructure
        {
            public string SerialNo { get; set; }
            public string LoginID { get; set; }
            public string UserName { get; set; }
            public string PersonType { get; set; }
            public string BuildingName { get; set; }
            public string PersonnelStatus { get; set; }
            public string Phone { get; set; }
            public string Password { get; set; }
            public string Notes { get; set; }
            public string ValidityDate { get; set; }
            public string ExpireTime { get; set; }
        }
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetUserData(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = new DataTable();
            try
            {
                List<object> result = new List<object>();
                result = gd.GetuserInfo(data["pageIndex"].ToString(), data["pageSize"].ToString());
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
                                   BuildingName = dr["buildingName"].ToString(),
                                   PersonnelStatus = dr["PersonnelStatus"].ToString(),
                                   Phone = dr["phone"].ToString(),
                                   Notes = dr["Notes"].ToString(),
                                   Password = dr["Password"].ToString(),
                                   ValidityDate = dr["validtill"].ToString(),
                                   ExpireTime = dr["expiretime"].ToString(),
                                   
                               }).ToList();
                }
                idata.Add("value", list);
            }
            catch (Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("errorMessage", ex.Message);
            }

            return idata;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetUserByID(string id)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            Dictionary<string, string> list = new Dictionary<string, string>();
            GetOrgData gd = new GetOrgData();
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
                    list.Add("buildingName", dt.Rows[0]["DeptCode"].ToString());
                    list.Add("PersonnelStatus", dt.Rows[0]["PersonnelStatus"].ToString());
                    list.Add("Notes", dt.Rows[0]["Notes"].ToString());
                    list.Add("Password", dt.Rows[0]["Password"].ToString());
                    list.Add("phone", dt.Rows[0]["phone"].ToString());
                    list.Add("validityDate", dt.Rows[0]["validtill"].ToString());
                    list.Add("expiretime", dt.Rows[0]["expiretime"].ToString());
                }
                idata.Add("value", list);
            }
            catch (Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("errorMessage", ex.Message);
            }
            return idata;
        }
        public class ClassDetails{
            public string Classid { get; set; }
            public string Classname { get; set; }
            public string Building { get; set; }
            public string Floor { get; set; }
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
        public class DeviceDetails
        {
            public string Ip { get; set; }
            public string Mac { get; set; }
            public string Port { get; set; }
            public string Userid { get; set; }
            public string Pass { get; set; }
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetClassData(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            try
            {
                GetOrgData gd = new GetOrgData();
                DataTable dt = new DataTable();
                List<ClassDetails> cdList = new List<ClassDetails>();
                List<object> d = new List<object>();
                d = gd.GetClassroomInfo(data["pageIndex"].ToString(), data["pageSize"].ToString());
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
                            Building = dr["teachingBuilding"].ToString(),
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
                            CallHelpmac = dr["callhelpmac"].ToString()
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
            return idata;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetOpedata(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            try
            {
                GetOrgData gd = new GetOrgData();
                DataTable dt = new DataTable();
                List<object> dd = new List<object>();
                dd = gd.GetCapitalInfo(data["pageIndex"].ToString(), data["pageSize"].ToString());
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
            return idata;
        }

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

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetBuildingByID(string id)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            Dictionary<string, string> idata = new Dictionary<string, string>();
            GetOrgData gd = new GetOrgData();
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
            return d;
        }
        private class IPClassByBuildingStructure
        {
            public int RowNum { get; set; }
            public string ClassName { get; set; }
            public string Floor { get; set; }
            public string CCEquipIP { get; set; }
        }
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetIPClassByBuilding(Dictionary<string, object> data)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            try
            {
                GetOrgData gd = new GetOrgData();
                List<object> dat = gd.GetIPClassByBuilding(data["pageIndex"].ToString(), data["pageSize"].ToString(),
                    data["buildingName"].ToString(), data["userID"].ToString());
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
                            CCEquipIP = dr["ccequipip"].ToString()

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
            return idata;
        }

        private class IPClassByBuildingFloorStructure
        {
            public int RowNum { get; set; }
            public string ClassName { get; set; }
            public string Floor { get; set; }
            public string CCEquipIP { get; set; }
        }
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetIPClassByBuildingFloor(Dictionary<string, object> data)
        {
            // idata is new KeyValuePair<string, object> i am not good for c#
            Dictionary<string,object> idata = new Dictionary<string, object>();
            try
            {
                GetOrgData gd = new GetOrgData();
                List<object> dat = gd.GetIPClassByBuildingFloor(data["buildingName"].ToString(), data["floor"].ToString(),
                    data["userID"].ToString(), data["pageIndex"].ToString(), Convert.ToInt32(data["pageSize"].ToString()));
                DataTable dt = dat[1] as DataTable;
                int total = Convert.ToInt32(dat[0]);
                KeyValuePair<string, int> totalRowCount = new KeyValuePair<string, int>("totalRows", total);
                idata.Add("totalRows", total);
                List<IPClassByBuildingFloorStructure> iPClassByBuildings = new List<IPClassByBuildingFloorStructure>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        IPClassByBuildingFloorStructure iPClass = new IPClassByBuildingFloorStructure()
                        {
                            RowNum = Convert.ToInt32(dr["rownumber"]),
                            ClassName = dr["classname"].ToString(),
                            Floor = dr["floor"].ToString(),
                            CCEquipIP = dr["ccequipip"].ToString()
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
            return idata;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetClassDataById(string id)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            GetOrgData gd = new GetOrgData();
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
                            Building = dr["teachingBuilding"].ToString(),
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
                            CallHelpmac = dr["callhelpmac"].ToString()
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

            return idata;
        }
        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetFloorlist(string building)
        {
            Dictionary<string, object> val = new Dictionary<string, object>();
            try
            {
                List<object> idata = new List<object>();
                GetOrgData gd = new GetOrgData();
                DataTable dt = gd.GetFloorlist(building);
                if (dt.Rows.Count > 0)
                {
                    val.Add("totalRows", dt.Rows.Count);
                    foreach (DataRow dr in dt.Rows)
                    {
                        idata.Add(dr["floor"].ToString());
                    }

                }
                val.Add("value", idata);
            }
            catch (Exception ex)
            {
                val.Add("status", "fail");
                val.Add("errorMessage", ex.Message);
            }
            return val;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetSchoolName(string building)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            try
            {
                GetOrgData gd = new GetOrgData();
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
            return idata;
        }

        [PrincipalPermission(SecurityAction.Demand)]
        [WebMethod]
        public Dictionary<string, object> GetClassByIP(string ip)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            try
            {
                GetOrgData gd = new GetOrgData();
                DataTable dt = gd.GetClassByIP(ip);
                idata.Add("status", "success");
                idata.Add("value", dt.Rows[0]["classname"].ToString());
            }
            catch (Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("errorMessage", ex.Message);
            }
            return idata;
        }

        private class FloorDataStructure
        {
            public string ID { get; set; }
            public string BuildingName { get; set; }
            public string Floor{ get; set; }
            public string BuildingCode { get; set; }
            public string Queue { get; set; }
            public string Type { get; set; }
            public string Remarks { get; set; }
        }
        
        [WebMethod]
        public Dictionary<string,object> GetFloorDetails(string building)
        {
            var idata = new Dictionary<string, object>();
            try
            {
                GetOrgData gd = new GetOrgData();
                DataTable dt = gd.GetFloorDetails(building);
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
                            Remarks = row["Remarks"].ToString()
                        };
                        fd.Add(st);
                    }
                }
                idata.Add("value", fd);

            }
            catch(Exception ex)
            {
                idata.Add("status", "fail");
                idata.Add("errorMessage", ex.Message);
            }
            return idata;
        }
    }
}
