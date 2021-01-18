using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using CresijApp.Models;
using System.Text;
using System.Data.OleDb;
using System.Reflection;

namespace CresijApp.Controllers
{
    public class DocumentController : ApiController
    {
        readonly string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["SchoolConnectionString"].ConnectionString;
        // GET: api/Document
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Document/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Document
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Document/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Document/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        public Dictionary<string, object> UploadFiles()
        {
            var idata = new Dictionary<string, object>();
            var request = HttpContext.Current.Request;
            string filename = "";
            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
            // Checking no of files injected in Request object  
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                // TODO: Add insert logic here
                try
                {
                    var fieldList =  request.Form.GetValues("FieldList");

                    //Upload Logo
                    if (request["Type"] == "UploadLogo")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.

                        filename = UploadLogo(postedFile, folderPath);
                        if (!string.IsNullOrEmpty(filename))
                        {
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                        }
                    }
                    else
                    {
                        if (fieldList.Length == 0)
                            idata.Add("status", "fail due to no column list found");
                        else
                        {
                            //Upload Student File
                            if (request["Type"] == "UploadStudentData")
                            {
                                //Fetch the Uploaded File.
                                HttpPostedFile postedFile = request.Files[0];
                                //Set the Folder Path.
                                var fname = "UploadStudentData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                                filename = Path.Combine(folderPath + fname + Path.GetExtension(postedFile.FileName));
                                if (File.Exists(filename))
                                    File.Delete(filename);
                                postedFile.SaveAs(filename);
                                var studentDataTable = CreateTable(filename, fieldList);
                                idata = UploadStudentData(studentDataTable.Tables[0]);
                                idata.Add("status", "success");
                            }

                            //upload teacher file
                            else if (request["Type"] == "UploadTeacherData")
                            {
                                //Fetch the Uploaded File.
                                HttpPostedFile postedFile = request.Files[0];
                                //Set the Folder Path.
                                //if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                                //{
                                var fname = "UploadTeacherData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                                filename = Path.Combine(folderPath + fname + Path.GetExtension(postedFile.FileName));
                                if (File.Exists(filename))
                                    File.Delete(filename);
                                postedFile.SaveAs(filename);
                                var teacherDataTable = CreateTable(filename, fieldList);
                                idata = UploadTeacherData(teacherDataTable.Tables[0]);
                                idata.Add("status", "success");
                                //}
                                //else
                                //{
                                //    idata.Add("status", "fail");
                                //    idata.Add("message", "file was in incorrect format!");
                                //}
                            }

                            //upload schedule
                            else if (request["Type"] == "UploadScheduleData")
                            {
                                //Fetch the Uploaded File.
                                HttpPostedFile postedFile = request.Files[0];
                                //Set the Folder Path.
                                var fname = "UploadScheduleData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;

                                filename = Path.Combine(folderPath + fname + Path.GetExtension(postedFile.FileName));
                                if (File.Exists(filename))
                                    File.Delete(filename);
                                postedFile.SaveAs(filename);

                                var scheduleDataTable = CreateTable(filename, fieldList);
                                idata = UploadScheduleData(scheduleDataTable.Tables[0]);
                                idata.Add("status", "success");
                            }

                            //upload user
                            else if (request["Type"] == "UploadUserData")
                            {
                                //Fetch the Uploaded File.
                                HttpPostedFile postedFile = request.Files[0];
                                //Set the Folder Path.
                                var fname = "UploadUserData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                                filename = Path.Combine(folderPath + fname + Path.GetExtension(postedFile.FileName));
                                if (File.Exists(filename))
                                    File.Delete(filename);
                                postedFile.SaveAs(filename);
                                var userDataTable = CreateTable(filename, fieldList);
                                idata = UploadUserData(userDataTable.Tables[0]);
                                idata.Add("status", "success");

                            }

                            //upload class
                            else if (request["Type"] == "UploadClassData")
                            {
                                //Fetch the Uploaded File.
                                HttpPostedFile postedFile = request.Files[0];
                                var fname = "UploadClassData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                                filename = Path.Combine(folderPath + fname + Path.GetExtension(postedFile.FileName));
                                if (File.Exists(filename))
                                    File.Delete(filename);
                                postedFile.SaveAs(filename);
                                var classDataTable = CreateTable(filename, fieldList);
                                idata = UploadClassData(classDataTable.Tables[0]);
                                idata.Add("status", "success");
                            }

                            //upload Capital Data
                            else if (request["Type"] == "UploadCapitalData")
                            {
                                //Fetch the Uploaded File.
                                HttpPostedFile postedFile = request.Files[0];
                                //Set the Folder Path.
                                var fname = "UploadCapitalData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                                filename = Path.Combine(folderPath + fname + Path.GetExtension(postedFile.FileName));
                                if (File.Exists(filename))
                                    File.Delete(filename);
                                postedFile.SaveAs(filename);
                                var capitalDataTable = CreateTable(filename, fieldList);
                                idata = UploadCapitalData(capitalDataTable.Tables[0]);
                                    idata.Add("status", "success");
                                
                            }

                            else if (request["Type"] == "UploadBuildingData")
                            {
                                //Fetch the Uploaded File.
                                HttpPostedFile postedFile = request.Files[0];
                                //Set the Folder Path.
                                var fname = "UploadBuildingData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                                filename = Path.Combine(folderPath + fname + Path.GetExtension(postedFile.FileName));
                                if (File.Exists(filename))
                                    File.Delete(filename);
                                postedFile.SaveAs(filename);
                                var buildingDataTable = CreateTable(filename, fieldList);
                                idata = UploadBuildingData(buildingDataTable.Tables[0]);
                                    idata.Add("status", "success");
                                
                            }

                            else if (request["Type"] == "UploadFloorData")
                            {
                                //Fetch the Uploaded File.
                                HttpPostedFile postedFile = request.Files[0];
                                //Set the Folder Path.

                                var fname = "UploadFloorData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                                filename = Path.Combine(folderPath + fname + Path.GetExtension(postedFile.FileName));
                                if (File.Exists(filename))
                                    File.Delete(filename);
                                postedFile.SaveAs(filename);
                                var floorDataTable = CreateTable(filename, fieldList);
                                idata = UploadFloorData(floorDataTable.Tables[0]);
                                idata.Add("status", "success");
                            }
                            return idata;
                        }

                    }

                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("Message ", ex.Message);
                    return idata;
                }
                finally
                {
                    if (File.Exists(filename))
                        File.Delete(filename);
                }
            }
            idata.Add("status", "fail");
            idata.Add("message", "No File Found");
            return idata;
        }

        private string UploadLogo(HttpPostedFile file, string path)
        {
            //Set the File Name.
            string fileName = Path.Combine(path + "Logo_" + file.FileName);
            //Save the File in Folder.
            file.SaveAs(fileName);
            return fileName;
        }

        private Dictionary<string, object> UploadStudentData(DataTable dt)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            int numofrows = 0;
            using (var context = new OrganisationdatabaseEntities())
            {
                if (dt.Rows.Count > 0)
                {
                    List<studentdata> tdList = new List<studentdata>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        studentdata td = new studentdata()
                        {
                            studentid = dr["studentid"].ToString(),
                            studentname = dr["studentname"].ToString(),
                            gender = dr["gender"].ToString(),                           
                            deptcode = dr["faculty"].ToString() ?? "",
                            phone = dr["phone"].ToString() ?? "",
                            idcard = dr["idcard"].ToString() ?? "",
                            onecard = dr["onecard"].ToString() ?? ""
                        };
                        int age = 0;
                        if (int.TryParse("-" + dr["age"].ToString(), out age))
                        {
                            var myDate = DateTime.Now.AddYears(age);
                            td.Dateofbirth = Convert.ToDateTime("01-01-" + myDate.Year);
                        }
                        else
                            td.Dateofbirth = Convert.ToDateTime("01-01-0001");
                        tdList.Add(td);
                    }
                    foreach (studentdata std in tdList.Where(x => !context.studentdatas.Any(b => b.studentid == x.studentid)))
                        context.studentdatas.Add(std);
                   
                    numofrows = context.SaveChanges();
                }
            }
            idata.Add("Rows Inserted", numofrows);
            idata.Add("Import warnings", messages);
            return idata;
        }

        private Dictionary<string, object> UploadTeacherData(DataTable dt)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();

            int numofrows = 0;

            using (var context = new OrganisationdatabaseEntities())
            {
               
                if (dt.Rows.Count > 0)
                {
                    List<teacherdata> tdList = new List<teacherdata>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        teacherdata td = new teacherdata()
                        {
                            TeacherID = dr["teacherid"].ToString(),
                            TeacherName = dr["teachername"].ToString(),
                            gender = dr["gender"].ToString(),
                            faculty = dr["faculty"].ToString() ?? "",
                            phone = dr["phone"].ToString() ?? "",
                            idcard = dr["idcard"].ToString() ?? "",
                            onecard = dr["onecard"].ToString() ?? ""
                        };
                        int age = 0;
                        if (int.TryParse("-" + dr["age"].ToString(), out age))
                        {
                            var myDate = DateTime.Now.AddYears(age);
                            td.dateofbirth = Convert.ToDateTime(myDate.Year +"-01-01");
                        }
                        else
                            td.dateofbirth = Convert.ToDateTime("0001-01-01");
                        tdList.Add(td);

                    }
                    foreach (teacherdata std in tdList.Where(x => !context.teacherdatas.Any(b => b.TeacherID == x.TeacherID)))
                        context.teacherdatas.Add(std);
                    numofrows = context.SaveChanges();
                }
            }

            idata.Add("Rows Inserted", numofrows);
            idata.Add("Import warnings", messages);

            return idata;
        }

        private Dictionary<string, object> UploadScheduleData(DataTable dt)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();

            int numofrows = 0;

            using (var context = new OrganisationdatabaseEntities())
            {

                if (dt.Rows.Count > 0)
                {
                    List<schedule> scheduleList = new List<schedule>();
                    foreach (DataRow dr in dt.Rows)
                    {

                        schedule schedule = new schedule()
                        {
                            year = dr["year"].ToString().Trim(),
                            sem = Convert.ToInt16(dr["sem"].ToString().Trim()),
                            teacherid = dr["teacherid"].ToString().Trim(),
                            teachername = dr["teachername"].ToString().Trim(),
                            courseid = dr["courseid"].ToString().Trim(),
                            classname = dr["classname"].ToString().Trim(),
                            coursename = dr["coursename"].ToString().Trim(),
                            weekstart = Convert.ToInt16(dr["weekstart"].ToString().Trim()),
                            weekend = Convert.ToInt16(dr["weekend"].ToString().Trim()),
                            dayno = Convert.ToInt32(dr["dayno"].ToString().Trim()),
                            section = Convert.ToInt16(dr["section"].ToString().Trim()),
                            teachingbuilding = dr["teachingbuilding"].ToString().Trim(),
                            floor = dr["floor"].ToString().Trim()
                        };
                        scheduleList.Add(schedule);                        
                    }           
					var finalScheduleList = new List<schedule>();
                    foreach(schedule s in scheduleList)
                    {
                        if(context.buildingdetails.Any(x => x.BuildingName == s.teachingbuilding))
                        {
                            var build = context.buildingdetails.Where(x => x.BuildingName == s.teachingbuilding).Select(x=>x.id).FirstOrDefault();
                            var floor = context.floordetails.Where(x => x.BuildingName == build && s.floor == x.floor).Select(x=>x.id).FirstOrDefault();
                            if(floor > 0)
                            {
                                var classid = context.classdetails.Where(x => x.teachingBuilding == build && x.floor == floor && x.ClassName == s.classname).Select(x => x.classID).FirstOrDefault();
                                if (classid > 0) finalScheduleList.Add(s);
                            }
                        }
                    }
                    context.schedules.AddRange(finalScheduleList);
                    numofrows = context.SaveChanges();
                }
            }
            idata.Add("Rows Inserted", numofrows);
            idata.Add("Import warnings", messages);
            return idata;
        }

        private Dictionary<string, object> UploadUserData(DataTable dt)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            int numofrows = 0;
            using (var context = new OrganisationdatabaseEntities())
            {

                if (dt.Rows.Count > 0)
                {
                    List<userdetail> userList = new List<userdetail>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        userdetail usd = new userdetail()
                        {
                            LoginID = dr["loginID"].ToString(),
                            UserName = dr["UserName"].ToString(),
                            PersonnelStatus = dr["personnelstatus"].ToString(),
                            
                            Notes = dr["Notes"].ToString() ?? "",
                            Password = dr["Password"].ToString(),
                            phone = dr["phone"].ToString()
                        };
                        if (dr["PersonType"].ToString().Trim().Equals("长期") || dr["PersonType"].ToString().Trim().Equals("永久"))
                            usd.PersonType = "longterm";
                        else if (dr["PersonType"].ToString().Trim().Equals("临时"))
                            usd.PersonType = "temporary";
                        else
                            usd.PersonType = "";

                        if (string.IsNullOrEmpty(dr["startdate"].ToString()))
                            usd.startDate = Convert.ToDateTime("0001-01-01");
                        else
                            usd.startDate = Convert.ToDateTime(dr["startdate"].ToString());
                        if (string.IsNullOrEmpty(dr["expiredate"].ToString()))
                            usd.expireDate = Convert.ToDateTime("0001-01-01");
                        else
                            usd.expireDate = Convert.ToDateTime(dr["expiredate"].ToString());
                        userList.Add(usd);
                    }
                    foreach (userdetail usd in userList.Where(x => !context.userdetails.Any(b => b.LoginID == x.LoginID)))
                        context.userdetails.Add(usd);
                    
                    numofrows = context.SaveChanges();
                }

            }
            idata.Add("Rows Inserted", numofrows);
            idata.Add("Import warnings", messages);
            return idata;
        }

        private Dictionary<string, object> UploadClassData(DataTable dt)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();            
            int numofrows = 0;
                ///steps to find distinct buildingnames and save it in buildingdetails table database
                List<string> distinctBuildings = dt.AsEnumerable().Select(row => row.Field<string>("teachingbuilding")).Distinct().ToList();

                using (var context = new OrganisationdatabaseEntities())
                {
                    List<buildingdetail> blist = new List<buildingdetail>();
                    foreach (string bname in distinctBuildings)
                    {
                        buildingdetail bd = new buildingdetail()
                        {
                            BuildingName = bname,
                            buildingcode = "",
                            Queue = "",
                            Public = "true",
                            Remarks = ""
                        };
                        blist.Add(bd);
                    }
                    foreach (buildingdetail bds in blist.Where(x => !context.buildingdetails.Any(b => b.BuildingName == x.BuildingName)))
                        context.buildingdetails.Add(bds);
                    context.SaveChanges();
                    var buildinglist = context.buildingdetails.Select(x => new { buildingid = x.id, buildingname = x.BuildingName }).ToDictionary(e => e.buildingname, e => e.buildingid);
                    ///replace buildingname to buildingid in the class data datatable
                    foreach (KeyValuePair<string, int> kp in buildinglist)
                    {
                        DataRow[] sl = dt.Select("teachingbuilding='" + kp.Key + "'");
                        sl.ToList().ForEach(x => x.SetField("teachingbuilding", kp.Value));
                    }
                    //steps to find distinct combination of floor and building id and adding it to floor details
                    var floordt = dt.DefaultView.ToTable(true, new string[] { "teachingbuilding", "floor" });
                    List<floordetail> listfloor = new List<floordetail>();
                    foreach (DataRow dr in floordt.Rows)
                    {
                        floordetail fdt = new floordetail()
                        {
                            floor = dr["floor"].ToString(),
                            BuildingName = Convert.ToInt32(dr["teachingbuilding"]),
                            Remarks = "",
                            buildingcode = "",
                            Public = "",
                            Queue = ""
                        };

                        listfloor.Add(fdt);
                    }
                    foreach (floordetail fd in listfloor.Where(x => !context.floordetails.Any(b => b.BuildingName == x.BuildingName && b.floor == x.floor)))
                        context.floordetails.Add(fd);
                    context.SaveChanges();
                    ///replace floor names with floor ids
                    var floordataFromDatabase = context.floordetails.Select(x =>
                    new { buildingid = x.BuildingName, x.floor, floorid = x.id });

                    foreach (var a in floordataFromDatabase)
                    {
                        DataRow[] sl = dt.Select("[teachingbuilding] =" + a.buildingid + "AND [floor]='" + a.floor + "'");
                        sl.ToList().ForEach(x => x.SetField("floor", a.floorid));
                    }
                    //inserting class data into class details
                    List<classdetail> classdetailsList = new List<classdetail>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        int.TryParse(dr["Seats"].ToString(), out int seats);
                        classdetail cd = new classdetail()
                        {
                            ClassName = dr["classname"].ToString(),
                            teachingBuilding = Convert.ToInt32(dr["teachingbuilding"]),
                            floor = Convert.ToInt32(dr["floor"]),
                            Seats = seats,
                            camipS = dr["camipS"].ToString() ?? "",
                            camipT = dr["camipT"].ToString() ?? "",
                            camSmac = dr["camSmac"].ToString() ?? "",
                            camTmac = dr["camTmac"].ToString() ?? "",
                            camport = Convert.ToInt32(dr["camport"]),
                            campass = dr["campass"].ToString(),
                            camuserid = dr["camuserid"].ToString(),
                            CCEquipIP = dr["CCEquipIP"].ToString(),
                            ccmac = dr["ccmac"].ToString(),
                            desktopip = dr["desktopip"].ToString(),
                            deskmac = dr["deskmac"].ToString(),
                            recordingEquip = dr["recordingEquip"].ToString(),
                            recordermac = dr["recordermac"].ToString(),
                            callhelpip = dr["callhelpip"].ToString(),
                            callhelpmac = dr["callhelpmac"].ToString()
                        };
                        classdetailsList.Add(cd);
                    }
                    foreach (classdetail cd in classdetailsList)
                    {
                        if (context.classdetails.Any(b => b.teachingBuilding == cd.teachingBuilding && b.floor == cd.floor && b.ClassName == cd.ClassName))
                        {
                            int classid = context.classdetails.Where(b => b.teachingBuilding == cd.teachingBuilding && b.floor == cd.floor && b.ClassName == cd.ClassName).Select(x => x.classID).FirstOrDefault();
                            var classdata = context.classdetails.Find(classid);
                            if (classdata != null)
                            {
                                classdata.ClassName = cd.ClassName;
                                classdata.teachingBuilding = cd.teachingBuilding;
                                classdata.floor = cd.floor;
                                classdata.camipS = cd.camipS;
                                classdata.camipT = cd.camipT;
                                classdata.camSmac = cd.camSmac;
                                classdata.camTmac = cd.camTmac;
                                classdata.camuserid = cd.camuserid;
                                classdata.campass = cd.campass;
                                classdata.camport = cd.camport;
                                classdata.CCEquipIP = cd.CCEquipIP;
                                classdata.ccmac = cd.ccmac;
                                classdata.desktopip = cd.desktopip;
                                classdata.deskmac = cd.deskmac;
                                classdata.recordingEquip = cd.recordingEquip;
                                classdata.recordermac = cd.recordermac;
                                classdata.Seats = cd.Seats;
                                classdata.callhelpip = cd.callhelpip;
                                classdata.callhelpmac = cd.callhelpmac;
                            }

                        }
                        else
                            context.classdetails.Add(cd);
                    }
                    numofrows = context.SaveChanges();
                }
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            return idata;
        }

        private Dictionary<string, object> UploadCapitalData(DataTable dt)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            int numofrows = 0;
            using (var context = new OrganisationdatabaseEntities())
            {
                List<operationmgmt> mgmt = new List<operationmgmt>();
                foreach(DataRow dr in dt.Rows)
                {
                    operationmgmt mgt = new operationmgmt()
                    {
                        assetno = dr["assetno"].ToString() ?? "",
                        devicename = dr["devicename"].ToString() ?? "",
                        model = dr["model"].ToString() ?? "",
                        specification = dr["specification"].ToString() ?? "",
                        devicetype = dr["devicetype"].ToString() ?? "",
                        price = dr["price"].ToString() ?? "",
                        factory = dr["factory"].ToString() ?? "",
                        dateofmanufacture = dr["dateofmanufacture"].ToString() ?? "",
                        dateofpurchase = dr["dateofpurchase"].ToString() ?? "",
                        dateofdelivery = dr["dateofdelivery"].ToString(),
                        warrantytime = dr["warrantytime"].ToString() ?? "",
                        locationType = dr["locationType"].ToString() ?? "",
                        equipmentstatus = dr["EquipmentStatus"].ToString() ?? ""
                    };
                    mgmt.Add(mgt);
                }
                
                context.operationmgmts.AddRange(mgmt);
                numofrows = context.SaveChanges();
            }
            idata.Add("Rows Inserted", numofrows);
            idata.Add("Import warnings", messages);
            return idata;
        }

        private Dictionary<string, object> UploadBuildingData(DataTable dt)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            
            int numofrows = 0;

            using (var context = new OrganisationdatabaseEntities())
            {
                List<buildingdetail> mgmt = new List<buildingdetail>();
                foreach (DataRow dr in dt.Rows)
                {
                    buildingdetail mgt = new buildingdetail()
                    {
                        buildingcode = dr["buildingcode"].ToString() ?? "",
                        BuildingName = dr["buildingname"].ToString(),
                        Queue= dr["queue"].ToString() ?? "",
                        Remarks = dr["remarks"].ToString() ?? "",
                        Public = dr["Public"].ToString() ?? "",
                        
                    };
                    mgmt.Add(mgt);
                }

                foreach (buildingdetail bds in mgmt.Where(x => !context.buildingdetails.Any(b => b.BuildingName == x.BuildingName)))
                    context.buildingdetails.Add(bds);
                numofrows = context.SaveChanges();
            }
            idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            return idata;
        }

        private Dictionary<string, object> UploadFloorData(DataTable dt)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            
            int numofrows = 0;
            
                ///steps to find distinct buildingnames and save it in buildingdetails table database
                var distinctBuildings = dt.DefaultView.ToTable(true, new string[] { "buildingName", "buildingCode" });
                using (var context = new OrganisationdatabaseEntities())
                {
                    List<buildingdetail> blist = new List<buildingdetail>();
                    foreach (DataRow dr in distinctBuildings.Rows)
                    {
                        buildingdetail bd = new buildingdetail()
                        {
                            BuildingName = dr["buildingName"].ToString(),
                            buildingcode = dr["buildingCode"].ToString(),
                            Queue = "",
                            Public = "",
                            Remarks = ""
                        };
                        blist.Add(bd);
                    }
                    foreach (buildingdetail bds in blist.Where(x => !context.buildingdetails.Any(b => b.BuildingName == x.BuildingName)))
                        context.buildingdetails.Add(bds);
                    context.SaveChanges();
                    var buildinglist = context.buildingdetails.Select(x => new { buildingid = x.id, buildingname = x.BuildingName }).ToDictionary(e => e.buildingname, e => e.buildingid);
                    ///replace buildingname to buildingid in the class data datatable
                    foreach (KeyValuePair<string, int> kp in buildinglist)
                    {
                        DataRow[] sl = dt.Select("buildingName='" + kp.Key + "'");
                        sl.ToList().ForEach(x => x.SetField("buildingName", kp.Value));
                    }

                    List<floordetail> listfloor = new List<floordetail>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        floordetail fdt = new floordetail()
                        {
                            floor = dr["floor"].ToString(),
                            BuildingName = Convert.ToInt32(dr["buildingName"]),
                            Remarks = dr["Remarks"].ToString() ?? "",
                            buildingcode = dr["buildingCode"].ToString() ?? "",
                            Public = dr["Public"].ToString() ?? "Public",
                            Queue = dr["Queue"].ToString() ?? ""
                        };

                        listfloor.Add(fdt);
                    }
                    foreach (floordetail fd in listfloor.Where(x => !context.floordetails.Any(b => b.BuildingName == x.BuildingName && b.floor == x.floor)))
                        context.floordetails.Add(fd);
                   numofrows= context.SaveChanges();
                }
              
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            return idata;
        }
        public static DataTable ConvertCSVtoDataTable(string sCsvFilePath)
        {
            DataTable dtTable = new DataTable();
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            using (StreamReader sr = new StreamReader(sCsvFilePath, Encoding.Unicode))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dtTable.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = CSVParser.Split(sr.ReadLine());
                    DataRow dr = dtTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i].Replace("\"", string.Empty);
                    }
                    if (!(dr == null || dr.ItemArray.All(i => string.IsNullOrWhiteSpace(i.ToString()) || string.IsNullOrEmpty(i.ToString()))))
                        dtTable.Rows.Add(dr);
                }
            }

            return dtTable;
        }
        public DataSet CreateTable(string source, string[] columnnames)
        {
            string Import_FileName = source;
            string fileExtension = Path.GetExtension(Import_FileName);
            var connectionstring = "";
            //if (fileExtension == ".xls")
            //    connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=NO;'";
            //if (fileExtension == ".xlsx")
            connectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=NO;'";
            using (var connection = new OleDbConnection(connectionstring))
            {
                var dataSet = new DataSet();

                connection.Open();
                var schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (schemaTable == null)
                    return dataSet;

                var sheetName = "";
                foreach (DataRow row in schemaTable.Rows)
                {
                    sheetName = row["TABLE_NAME"].ToString();
                    break;
                }
                var command = string.Format("SELECT * FROM [{0}]", sheetName);
                var adapter = new OleDbDataAdapter(command, connection);
                dataSet.Tables.Add(sheetName);
                foreach (string s in columnnames)
                {
                    dataSet.Tables[sheetName].Columns.Add(s);
                }
                var dtm = adapter.TableMappings.Add("TABLE", sheetName);
                for (int i = 1; i <= columnnames.Length; i++)
                {
                    var cl = "F" + i;
                    dtm.ColumnMappings.Add(cl, columnnames[i - 1]);
                }
                adapter.Fill(dataSet.Tables[sheetName]);
                DataRow row1 = dataSet.Tables[0].Rows[0];
                dataSet.Tables[0].Rows.Remove(row1);
                connection.Close();
                return dataSet;
            }
        }

        //public static DataTable GetDistinctRecords(DataTable dt, string[] Columns)
        //{
        //    DataTable dtUniqRecords = new DataTable();
        //    dtUniqRecords = dt.DefaultView.ToTable(true, Columns);
        //    return dtUniqRecords;
        //}

        //private DataTable ReadExcelFile(string sheetName, string path)
        //{

        //    using (OleDbConnection conn = new OleDbConnection())
        //    {
        //        DataTable dt = new DataTable();
        //        string Import_FileName = path;
        //        string fileExtension = Path.GetExtension(Import_FileName);
        //        if (fileExtension == ".xls")
        //            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
        //        if (fileExtension == ".xlsx")
        //            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
        //        using (OleDbCommand comm = new OleDbCommand())
        //        {
        //            comm.CommandText = "Select * from [" + sheetName + "$]";
        //            comm.Connection = conn;
        //            using (OleDbDataAdapter da = new OleDbDataAdapter())
        //            {
        //                da.SelectCommand = comm;
        //                da.Fill(dt);
        //                return dt;
        //            }
        //        }
        //    }
        //}
    }
}
