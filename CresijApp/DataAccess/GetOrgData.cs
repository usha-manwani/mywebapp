// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 03-17-2020
//
// Last Modified By : admin
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="GetOrgData.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using CresijApp.Models;
using System.Data.Entity;

namespace CresijApp.DataAccess
{
    /// <summary>
    /// This Class is use to fetch different data from database tables
    /// Class contains Get Methods for: UserDetails table, BuildingDetails , StudentDetails, TeacherDetails, ClassDetails
    /// and their different variations according to requirement.
    /// </summary>
    /// <summary>
    /// Class GetOrgData.
    /// </summary>
    public class GetOrgData
    {
        /// <summary>
        /// The constr
        /// </summary>
        string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["Organisationdatabase"].ConnectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrgData"/> class.
        /// </summary>
        public GetOrgData() { }
        //Constructor for initializing with required connection string
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrgData"/> class.
        /// </summary>
        /// <param name="constring">The constring.</param>
        public GetOrgData(string constring)
        {
            constr= System.Configuration.ConfigurationManager.
            ConnectionStrings[constring].ConnectionString;
        }

        /// <summary>
        /// Get associated building details List according to request by current user
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="userid"></param>
        /// <returns>List of building details list according to page size and count of rows</returns>
        
        public List<object> GetOrgBuildingInfo(string pageIndex, string pageSize,string userid)
        {
            DataTable dt = new DataTable();
            var total=0;
            
            List<object> result = new List<object>();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                
                using (MySqlCommand cmd = new MySqlCommand("sp_GetBuildingDetailsInfo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@_PageSize", pageSize);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.Add("@_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["@_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["@_RecordCount"].Value);
                }
                result.Add(total);
                result.Add(dt);
            }
            return result;
        }

        /// <summary>
        /// Get User Details List with optional search text
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="text"></param>
        /// <returns>returns user details List according to size with count of rows</returns>
       
        public List<object> GetuserInfo(string pageIndex, string pageSize,string text)
        {
            DataTable dt = new DataTable();
            var total = 0;
            List<object> result = new List<object>();

            using (MySqlConnection con = new MySqlConnection(constr))
                {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetAllUserDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@_PageSize", pageSize);
                    cmd.Parameters.AddWithValue("@con", text);
                    cmd.Parameters.Add("@_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["@_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["@_RecordCount"].Value);
                }
                result.Add(total);
                result.Add(dt);
            }
            return result;
        }

        /// <summary>
        /// get teacher details list with optional search text
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="query"></param>
        /// <returns>return teacher details list according to size with count of rows</returns>
       
        public List<object> GetTeacherInfo(string pageindex, string pagesize, string text)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetTeacherData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.AddWithValue("@con", text);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                   
                    adapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    data.Add(total);
                    data.Add(dt);
                }
            }
            return data;
        }

        /// <summary>
        /// Get Student Details list with optional search text
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="text"></param>
        /// <returns>returns student details list according to size with count of rows </returns>
       
        public List<object> GetStudentInfo(string pageindex, string pagesize,string text)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;

            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_GetStudentData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.AddWithValue("@con", text);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    data.Add(total);
                    data.Add(dt);
                }
            }

            return data;
        }

        /// <summary>
        /// Get Operation Management List data from database with optional search text       
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="text"></param>
        /// <returns>
        /// returns list of Operation Management List according to size with count of rows</returns>
        
        public List<object> GetCapitalInfo( string pageindex, string pagesize,string text)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                
                using (MySqlCommand cmd = new MySqlCommand("sp_GetOperationMgmtData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.AddWithValue("@con", text);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    data.Add(total);
                    data.Add(dt);
                }
            }
            return data;
        }

        /// <summary>
        /// Get Class Details list associated with user permissions with optional search text
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="userid"></param>
        /// <param name="text"></param>
        /// <returns>returns list of classdetails according to size with count of rows </returns>
        
        public List<object> GetClassroomInfo(string pageindex, string pagesize,string userid,string text)
        {
            List<object> data = new List<object>();
            DataTable dt = new DataTable();
            var total = 0;

            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_GetAllClassDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@con", text);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    data.Add(total);
                    data.Add(dt);
                }
            }

            return data;
        }
        /// <summary>
        /// method to get class data by its id
        /// </summary>
        /// <param name="classid"></param>
        /// <returns>class details data</returns>
        
        public DataTable GetClassData(string classid)
        {
            DataTable dt = new DataTable();
            
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT classID, ClassName, bd.buildingname, fd.floor,Seats,`camipS`,`camipT`, `camSmac`, " +
                    "`camTmac`,`camport`,`camuserid`,`campass`,`CCEquipIP`,`ccmac`, `desktopip`,`deskmac`, " +
                    "`recordingEquip`,`recordermac`,`callhelpip`,`callhelpmac`, " +
                    "bd.id as buildingid, fd.id as floorid FROM `organisationdatabase`.`classdetails` cd " +
                    "join buildingdetails bd on bd.id = cd.teachingbuilding join floordetails fd on fd.id = cd.floor" +
                    " where classid=" + classid;
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            
            return dt;
        }
        /// <summary>
        /// Get Building details by its ID
        /// </summary>
        /// <param name="sn"></param>
        /// <returns>Specific building detail</returns>
       
        public DataTable GetBuildingById(int sn)
        {
            DataTable dt = new DataTable();            
                using(MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT id,  buildingName, buildingCode, schoolname, " +
                             "Queue, Public, remarks FROM buildingdetails bd join systemsettings where bd.id ="+sn;
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if(con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
            
            return dt;
        }
        /// <summary>
        /// Get user details by id
        /// </summary>
        /// <param name="sn"></param>
        /// <returns>specific user detail</returns>
       
        public DataTable GetUserById(string sn)
        {
            DataTable dt = new DataTable();
           
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT usd.serialNo, loginID, userName, PersonType, " +
                        " PersonnelStatus, Notes, password, phone,startdate,expiredate" +
                        " from userdetails usd " +
                        " where loginid ='" + sn + "'";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
            
            return dt;
        }

        /// <summary>
        /// Get machine details and class ids and names by building id, specific to user
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="data"></param>
        /// <param name="userid"></param>
        /// <returns>list of class and machine ip </returns>
        
        public List<object> GetIPClassByBuilding(string pageindex, string pagesize,string data,string userid)
        {
            DataTable dt = new DataTable();
            var total = 0;
            List<object> list = new List<object>();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetClassIPByBuilding", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@building", data);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                    cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                    cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                    cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    adapter.Fill(dt);
                    total = Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                    list.Add(total);
                    list.Add(dt);
                }
            }
            return list;
        }
        /// <summary>
        /// Get machine details and class ids and names by building id and floor id, specific to user
        /// </summary>
        /// <param name="building"></param>
        /// <param name="floor"></param>
        /// <param name="userid"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <returns>list of class and machine ip</returns>
        
        public List<object> GetIPClassByBuildingFloor(string building,string floor,string userid,string pageindex,int pagesize)
        {
            DataTable dt = new DataTable();
            var total = 0;
            List<object> list = new List<object>();
           
                using (MySqlConnection con = new MySqlConnection(constr))
                {

                    using (MySqlCommand cmd = new MySqlCommand("sp_GetIPClassByBuildingFloor", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@building", building);
                        cmd.Parameters.AddWithValue("@userid", userid);
                        cmd.Parameters.AddWithValue("@_PageIndex", pageindex);
                        cmd.Parameters.AddWithValue("@_PageSize", pagesize);
                        cmd.Parameters.AddWithValue("@floornum", floor);
                        cmd.Parameters.Add("_RecordCount", MySqlDbType.Int32, 4);
                        cmd.Parameters["_RecordCount"].Direction = ParameterDirection.Output;
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                        total =Convert.ToInt32(cmd.Parameters["_RecordCount"].Value);
                        list.Add(total);
                        list.Add(dt);
                    }
                }
          
            return list;
        }

        /// <summary>
        /// Method to get the floor list by building id
        /// </summary>
        /// <param name="building"></param>
        /// <returns>floor list </returns>
       
        public DataTable GetFloorlist(string building)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT floor, id from floordetails where buildingname="+building;
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        /// <summary>
        /// Method to get school name
        /// </summary>
        /// <param name="building"></param>
        /// <returns></returns>
        
        public DataTable GetSchoolName(string building)
        {
            DataTable dt = new DataTable();
            
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT SchoolName from SystemSettings limit 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            return dt;
        }

        /// <summary>
        /// Method to get class name and id by machine ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns>Class name and id</returns>
        
        public DataTable GetClassByIP(string ip)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT classname, classid from classdetails where ccequipip ='" + ip + "' limit 1";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        /// <summary>
        /// Method to get the floor list by building id specific to user id
        /// </summary>
        /// <param name="building"></param>
        /// <param name="userid"></param>
        /// <returns>floor list</returns>
       
        public DataTable GetFloorDetails(string building, string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT fd.id,fd.floor,bd.buildingName as buildingname, " +
                    " fd.BuildingCode as buildingcode, fd.queue, " +
                    "fd.Public,fd.remarks, bd.id as buildingid from Floordetails fd join buildingdetails bd " +
                    " on fd.Buildingname =bd.id where fd.id in (select floor from classdetails  " +
                    " where classid in " +
                    "(select locationid from userlocationaccess where Level ='Class' and " +
                    " userserialnum = (select serialno from userdetails " +
                    "where loginid = '"+userid+"'))) and fd.BuildingName =" + building+ 
                    " union select fd.id,fd.floor,bd.buildingName as buildingname, " +
                    " fd.BuildingCode as buildingcode, fd.queue, " +
                    "fd.Public,fd.remarks, bd.id as buildingid from Floordetails fd join buildingdetails bd " +
                    " on fd.Buildingname =bd.id where fd.buildingname="+ building+ " and fd.id in(select locationid from userlocationaccess where Level ='Floor' and " +
                    "locationid not in(select floor from classdetails)) group by fd.id";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// Gets the camera by class identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ClassDataDetails.</returns>
        public ClassDataDetails GetCameraByClassId(int id)
        {
            
            DataTable dt = new DataTable();
            var coursename = "";
            var courseid = "";
            using(var con = new MySqlConnection(constr))
            {
                using(var cmd = new MySqlCommand("sp_GetCourseByClassID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id", id);
                    var adp = new MySqlDataAdapter(cmd);
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        coursename = dt.Rows[0]["coursename"].ToString();
                        courseid = dt.Rows[0]["Courseid"].ToString();
                    }
                }
            }
            
            using(var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()+"Entities"))
            {
                var cameradetails = new ClassDataDetails();
               
                cameradetails = context.classdetails.Where(x => x.classID == id).Select(o=>new ClassDataDetails { CamStudentIp= o.camipS ,
                   CamStudentMac= o.camSmac, CamTeacherIp=o.camipT,CamTeacherMac= o.camTmac,
                   CamPassword= o.campass,CamLoginId= o.camuserid, CamPort=o.camport,
                    CCEquipIp =o.CCEquipIP, CCMac=o.ccmac,
                    ClassId = o.classID,
                    ClassName = o.ClassName, DesktopIp=o.desktopip,DesktopMac=o.deskmac
                }).FirstOrDefault();
                cameradetails.CourseName = coursename;
                cameradetails.CourseId = courseid;
                return cameradetails;
            }
            
        }
        
        /// <summary>
        /// Gets the camera by class ids.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of ClassDataDetails and total count of rows.</returns>
        public List<ClassDataDetails> GetCameraByClassIds(List<int> id)
        {
            List<ClassDataDetails> details = new List<ClassDataDetails>();
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()+"Entities"))
            {
                details = context.classdetails.Where(x => id.Contains(x.classID)).Select(o => new ClassDataDetails
                {
                    CamStudentIp = o.camipS,
                    CamStudentMac = o.camSmac,
                    CamTeacherIp = o.camipT,
                    CamTeacherMac = o.camTmac,
                    CamPassword = o.campass,
                    CamLoginId = o.camuserid,
                    CamPort = o.camport,
                    CCEquipIp = o.CCEquipIP,
                    CCMac = o.ccmac,
                    ClassId = o.classID,
                    ClassName=o.ClassName,
                    DesktopIp=o.desktopip,
                    DesktopMac=o.deskmac                    
                }).ToList();
                
               
            }
            return details;
        }

        /// <summary>
        /// Gets the camera by user identifier with condition.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNum">The page number.</param>
        /// <param name="systemstate">The systemstate.</param>
        /// <param name="hasTeacher">if set to <c>true</c> [has teacher].</param>
        /// <param name="ids">The ids.</param>
        /// <param name="inout">if set to <c>true</c> [inout].</param>
        /// <returns>List of ClassDataDetails and total count of rows.</returns>
        public List<object> GetCameraByUserIdWithCondition(string userid, int pageSize, int pageNum,
            string systemstate,bool hasTeacher, List<int>ids, bool inout)
        {
            var result = new List<object>();
            List<ClassDataDetails> details = new List<ClassDataDetails>();
            var finalids = new List<int>();
            List<int> classids = new List<int>();
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()+"Entities"))
            {
                if (inout == true)
                {
                    classids.AddRange(ids);
                }
                else
                {
                    int serialn = context.userdetails.Where(x => x.LoginID == userid).Select(x => x.SerialNo).FirstOrDefault();
                    classids = context.userlocationaccesses.Where
                        (x => x.userserialnum == serialn && x.Level == "Class").Select(x => x.locationid).ToList();
                    classids.RemoveAll(x => ids.Contains(x));
                }
                    var tempclassid = context.temp_machinestatus.Where(x => x.machineStatus == systemstate
                    && classids.Contains(x.classid)).Select(x => x.classid).ToList();
                    var templist2 = classids.Intersect(tempclassid).ToList();
                    var datetime = DateTime.Now.AddMinutes(-5);
                    var templist1 = context.temp_desktopevents.Where(x => classids.Contains(x.classid)
                    && x.ActionTime >= datetime).Select(x => x.classid).Union(
                    context.alarmmonitorlogs.Where(x => classids.Contains(x.Classid)
                    && x.almTime >= datetime).Select(x => x.Classid)).ToList();

                if (systemstate != "SystemOff")
                {
                    if (hasTeacher)
                    {
                        finalids = templist2.Intersect(templist1).ToList();
                    }
                    else
                    {
                        tempclassid.RemoveAll(x => templist1.Contains(x));
                        finalids = tempclassid;
                    }
                }
                else
                {
                    finalids = templist2;
                }              
                details = context.classdetails.Where(x => finalids.Contains(x.classID)).Select(o => new ClassDataDetails
                {
                    CamStudentIp = o.camipS,
                    CamStudentMac = o.camSmac,
                    CamTeacherIp = o.camipT,
                    CamTeacherMac = o.camTmac,
                    CamPassword = o.campass,
                    CamLoginId = o.camuserid,
                    CamPort = o.camport,
                    CCEquipIp = o.CCEquipIP,
                    CCMac = o.ccmac,
                    ClassId = o.classID,
                    ClassName = o.ClassName,
                    DesktopIp=o.desktopip,
                    DesktopMac=o.deskmac
                }).OrderBy(x=>x.ClassId).Skip(pageSize*(pageNum-1)).Take(pageSize).ToList();
                result.Add(details);
                var total = context.classdetails.Where(x => finalids.Contains(x.classID)).Count();
                result.Add(total);
            }
            return result;
        }

        ///<summary>
        /// Gets the camera by user identifier and filters.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNum">The page number.</param>
        /// <param name="ids">The ids.</param>
        /// <param name="inout">if set to <c>true</c> [inout].</param>
        /// <returns>List of ClassDataDetails and total count of rows.</returns>
        public List<object> GetCameraByUserId(string userid, int pageSize, int pageNum,
            List<int> ids, bool inout)
        {
            var result = new List<object>();
            List<ClassDataDetails> details = new List<ClassDataDetails>();
            var finalids = new List<int>();
            List<int> classids = new List<int>();
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()+"Entities"))
            {
                if (inout == true)
                {
                    classids.AddRange(ids);
                }
                else
                {
                    int serialn = context.userdetails.Where(x => x.LoginID == userid).Select(x => x.SerialNo).FirstOrDefault();
                    classids = context.userlocationaccesses.Where
                        (x => x.userserialnum == serialn && x.Level == "Class").Select(x => x.locationid).ToList();
                    classids.RemoveAll(x => ids.Contains(x));
                }
                
                details = context.classdetails.Where(x => classids.Contains(x.classID)).Select(o => new ClassDataDetails
                {
                    CamStudentIp = o.camipS,
                    CamStudentMac = o.camSmac,
                    CamTeacherIp = o.camipT,
                    CamTeacherMac = o.camTmac,
                    CamPassword = o.campass,
                    CamLoginId = o.camuserid,
                    CamPort = o.camport,
                    CCEquipIp = o.CCEquipIP,
                    CCMac = o.ccmac,
                    ClassId = o.classID,
                    ClassName = o.ClassName,
                    DesktopIp=o.desktopip,
                    DesktopMac=o.deskmac

                }).OrderBy(x => x.ClassId).Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
                result.Add(details);
                var total = context.classdetails.Where(x => classids.Contains(x.classID)).Count();
                result.Add(total);
            }
            return result;
        }
        
        /// <summary>
        /// Get camera and machine details with filters using search keyword
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="keyword">The keywword.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNum">The page number.</param>
        /// <param name="ids">The ids.</param>
        /// <param name="inout">if set to <c>true</c> [inout].</param>
        /// <returns>List of ClassDataDetails and total count of rows.</returns>
        public List<object> GetCameraBySearch(string user,string keyword, int pageSize, int pageNum,
            List<int> ids, bool inout)
        {
            var result = new List<object>();
            List<ClassDataDetails> details = new List<ClassDataDetails>();
            
            List<int> classids = new List<int>();
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()+"Entities"))
            {
                if (inout == true)
                {
                    classids.AddRange(ids);
                }
                else
                {
                    int serialn = context.userdetails.Where(x => x.LoginID == user).Select(x => x.SerialNo).FirstOrDefault();
                    classids = context.userlocationaccesses.Where
                        (x => x.userserialnum == serialn && x.Level == "Class").Select(x => x.locationid).ToList();
                    classids.RemoveAll(x => ids.Contains(x));
                }
                details = context.classdetails.Where(x => x.ClassName.Contains(keyword) 
                            && classids.Contains(x.classID)).Select(o => new ClassDataDetails
                {
                    CamStudentIp = o.camipS,
                    CamStudentMac = o.camSmac,
                    CamTeacherIp = o.camipT,
                    CamTeacherMac = o.camTmac,
                    CamPassword = o.campass,
                    CamLoginId = o.camuserid,
                    CamPort = o.camport,
                    CCEquipIp = o.CCEquipIP,
                    CCMac = o.ccmac,
                    ClassId = o.classID,
                    ClassName = o.ClassName,
                    DesktopIp=o.desktopip,
                    DesktopMac=o.deskmac

                }).OrderBy(x => x.ClassId).Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
                result.Add(details);
                var total = context.classdetails.Where(x => x.ClassName.Contains(keyword)
                            && classids.Contains(x.classID)).Count();
                result.Add(total);
            }
            return result;
        }

        /// <summary>
        /// Get camera and machine details with filters and search keywords using userid
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="keywword">The keywword.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNum">The page number.</param>
        /// <param name="systemstate">The systemstate.</param>
        /// <param name="hasTeacher">if set to <c>true</c> [has teacher].</param>
        /// <param name="ids">The ids.</param>
        /// <param name="inout">if set to <c>true</c> [inout].</param>
        /// <returns>List of ClassDataDetails and total count of rows</returns>
        public List<object> GetCameraBySearchWithCondition(string user,string keywword, int pageSize, int pageNum,
            string systemstate, bool hasTeacher, List<int> ids, bool inout)
        {
            var result = new List<object>();
            List<ClassDataDetails> details = new List<ClassDataDetails>();
            var finalids = new List<int>();
            List<int> classids = new List<int>();
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()+"Entities"))
            {
                if (inout == true)
                {
                    classids.AddRange(ids);
                }
                else
                {
                    int serialn = context.userdetails.Where(x => x.LoginID == user).Select(x => x.SerialNo).FirstOrDefault();
                    classids = context.userlocationaccesses.Where
                        (x => x.userserialnum == serialn && x.Level == "Class").Select(x => x.locationid).ToList();
                    classids.RemoveAll(x => ids.Contains(x));
                }
                var tempclassid = context.temp_machinestatus.Where(x => x.machineStatus == systemstate
                && classids.Contains(x.classid)).Select(x => x.classid).ToList();
                var templist2 = classids.Intersect(tempclassid).ToList();
                var datetime = DateTime.Now.AddMinutes(-5);
                var templist1 = context.temp_desktopevents.Where(x => classids.Contains(x.classid)
                && x.ActionTime >= datetime).Select(x => x.classid).Union(
                context.alarmmonitorlogs.Where(x => classids.Contains(x.Classid)
                && x.almTime >= datetime).Select(x => x.Classid)).ToList();
                if (hasTeacher)
                {
                    finalids = templist2.Intersect(templist1).ToList();
                }
                else
                {
                    tempclassid.RemoveAll(x => templist1.Contains(x));
                    finalids = tempclassid;
                }
                details = context.classdetails.Where(x => x.ClassName.Contains(keywword)
                        && finalids.Contains(x.classID)).Select(o => new ClassDataDetails
                        {
                    CamStudentIp = o.camipS,
                    CamStudentMac = o.camSmac,
                    CamTeacherIp = o.camipT,
                    CamTeacherMac = o.camTmac,
                    CamPassword = o.campass,
                    CamLoginId = o.camuserid,
                    CamPort = o.camport,
                    CCEquipIp = o.CCEquipIP,
                    CCMac = o.ccmac,
                    ClassId = o.classID,
                    ClassName = o.ClassName,
                    DesktopIp = o.desktopip,
                    DesktopMac=o.deskmac
                })
                .OrderBy(x => x.ClassId)
                .Skip(pageSize * (pageNum - 1)).Take(pageSize).ToList();
                result.Add(details);
                var total = context.classdetails.Where(x => x.ClassName.Contains(keywword)
                && finalids.Contains(x.classID)).Count();
                result.Add(total);
            }
            return result;
        }

        /// <summary>
        /// Method to get Desktop Event logs
        /// Not Used Yet
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        #region Not Used Method Name: GetDesktopEventLogs
        /// <summary>
        /// Gets the desktop event logs.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns>Dictionary&lt;System.String, System.Object&gt;.</returns>
        internal Dictionary<string,object> GetDesktopEventLogs(int pageSize, int pageIndex)
        {
            var result = new Dictionary<string, object>();
            using(var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()+"Entities"))
            {
                var data = context.temp_desktopevents.Select(x => new DesktopEvent
                {
                   Action= x.Action,
                   ActionTime= x.ActionTime.ToString("yyyy-MM-dd HH:mm:ss"),
                   Deskmac= x.Deskmac
                }).Skip(pageSize * pageIndex).Take(pageSize).ToList();
                result.Add("Data", data);
                var total = context.temp_desktopevents.Count();
                result.Add("Total", total);
                return result;
            }
        }
        #endregion

        
        /// <summary>
        /// Gets the alarm monitor logs.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns>AlarmMonitorEvent list and total rows</returns>
        internal Dictionary<string, object> GetAlarmMonitorLogs(int pageSize, int pageIndex)
        {
            var result = new Dictionary<string, object>();
            var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
            using (var context = new OrganisationdatabaseEntities(db))
            {
                var data = context.alarmmonitorlogs.Select(x => new AlarmMonitorEvent
                {
                    Action = x.almMessage,
                    ActionTime = x.almTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    DeviceIp = x.deviceip
                }).Skip(pageSize*pageIndex).Take(pageSize).ToList();
                result.Add("Data", data);
                var total = context.alarmmonitorlogs.Count();
                result.Add("Total", total);
                return result;
            }
        }
    }

    /// <summary>
    /// Structure for desktop Event Logs
    /// </summary>
    /// <summary>
    /// Class DesktopEvent.
    /// </summary>
    public class DesktopEvent
    {
        /// <summary>
        /// Gets or sets the action time.
        /// </summary>
        /// <value>The action time.</value>
        public string ActionTime { get; set; }
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets the deskmac.
        /// </summary>
        /// <value>The deskmac.</value>
        public string Deskmac { get; set; }
    }

    /// <summary>
    /// Structure for camera Monitor Logs
    /// </summary>
    /// <summary>
    /// Class AlarmMonitorEvent.
    /// </summary>
    public class AlarmMonitorEvent
    {
        /// <summary>
        /// Gets or sets the action time.
        /// </summary>
        /// <value>The action time.</value>
        public string ActionTime { get; set; }
        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        public string Action { get; set; }
        /// <summary>
        /// Gets or sets the device ip.
        /// </summary>
        /// <value>The device ip.</value>
        public string DeviceIp { get; set; }
    }

    /// <summary>
    /// Structure for class equipment details with current Schedule(course name)
    /// </summary>
    /// <summary>
    /// Class ClassDataDetails.
    /// </summary>
    public class ClassDataDetails
    {
        /// <summary>
        /// Gets or sets the class identifier.
        /// </summary>
        /// <value>The class identifier.</value>
        public int    ClassId { get; set; }
        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>The name of the class.</value>
        public string ClassName { get; set; }
        /// <summary>
        /// Gets or sets the cam teacher ip.
        /// </summary>
        /// <value>The cam teacher ip.</value>
        public string CamTeacherIp { get; set; }
        /// <summary>
        /// Gets or sets the cam student ip.
        /// </summary>
        /// <value>The cam student ip.</value>
        public string CamStudentIp { get; set; }
        /// <summary>
        /// Gets or sets the cam teacher mac.
        /// </summary>
        /// <value>The cam teacher mac.</value>
        public string CamTeacherMac { get; set; }
        /// <summary>
        /// Gets or sets the cam student mac.
        /// </summary>
        /// <value>The cam student mac.</value>
        public string CamStudentMac { get; set; }
        /// <summary>
        /// Gets or sets the cam password.
        /// </summary>
        /// <value>The cam password.</value>
        public string CamPassword { get; set; }
        /// <summary>
        /// Gets or sets the cam login identifier.
        /// </summary>
        /// <value>The cam login identifier.</value>
        public string CamLoginId { get; set; }
        /// <summary>
        /// Gets or sets the cam port.
        /// </summary>
        /// <value>The cam port.</value>
        public int    CamPort { get; set; }
        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
        /// <value>The name of the course.</value>
        public string CourseName { get; set; }
        /// <summary>
        /// Gets or sets the course identifier.
        /// </summary>
        /// <value>The course identifier.</value>
        public string CourseId { get; set; }
        /// <summary>
        /// Gets or sets the cc equip ip.
        /// </summary>
        /// <value>The cc equip ip.</value>
        public string CCEquipIp { get; set; }
        /// <summary>
        /// Gets or sets the cc mac.
        /// </summary>
        /// <value>The cc mac.</value>
        public string CCMac { get; set; }
        /// <summary>
        /// Gets or sets the desktop ip.
        /// </summary>
        /// <value>The desktop ip.</value>
        public string DesktopIp { get; set; }
        /// <summary>
        /// Gets or sets the desktop mac.
        /// </summary>
        /// <value>The desktop mac.</value>
        public string DesktopMac { get; set; }
    }
}