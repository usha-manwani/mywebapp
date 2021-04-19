using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
using CresijApp.Models;
namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for SaveOrganisationData
    /// The class is use to save/update data in database of selection done by user at login time.
    /// Class contains Save and Update Methods for:UserDetails table, BuildingDetails , StudentDetails, TeacherDetails, ClassDetails
    /// and their different variations according to requirement.
    /// </summary>
    [WebService(Namespace = "http://ipaddress/services/SaveOrganisationData.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class SaveOrganisationData : WebService
    {
        
        /// <summary>
        /// Save new Building data or update building data in building details
        /// Give access of that building to the current user in session
        /// </summary>
        /// <param name="data"></param>
        /// <returns>success/failresult with count of rows</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> SaveBuildingData(Dictionary<string,string> data)
        {            
              int result = -1 ;
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");                
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    var adminid = Session["UserLoggedIn"].ToString();

                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        var buildid = 0;
                        buildingdetail bd = new buildingdetail()
                        {
                            buildingcode = data["buildingCode"].ToString(),
                            BuildingName = data["buildingName"].ToString(),
                            Queue = data["queue"].ToString(),
                            Remarks = data["notes"].ToString(),
                            Public = data["accessType"].ToString()
                        };
                        if ( !context.buildingdetails.Any(b => b.BuildingName == bd.BuildingName))
                        {
                            context.buildingdetails.Add(bd);
                            result = context.SaveChanges();
                            buildid = bd.id;
                        }                       
                        else
                        {
                            var buildingdata = context.buildingdetails.Where(b => b.BuildingName == bd.BuildingName).Select(x=>x).FirstOrDefault();
                          
                            if (buildingdata != null)
                            {
                                buildingdata.buildingcode = data["buildingCode"].ToString();
                                buildingdata.BuildingName = data["buildingName"].ToString();
                                buildingdata.Queue = data["queue"].ToString();
                                buildingdata.Remarks = data["notes"].ToString();
                                buildingdata.Public = data["accessType"].ToString();
                            }
                            result = context.SaveChanges();
                            buildid = buildingdata.id;
                        }
                        
                        if (result >= 0) {
                            var userserialno = context.userdetails.Where(b => b.LoginID == adminid).Select(x => x.SerialNo).First();
                            var userlocation = new userlocationaccess()
                            {
                                locationid = buildid,
                                authenticatedby = userserialno,
                                userserialnum = userserialno,
                                Level="Building"
                            };
                            if (!context.userlocationaccesses.Any(x => x.Level == "Building" && x.userserialnum == userserialno && x.locationid == buildid))
                                context.userlocationaccesses.Add(userlocation);
                            var adminserialno = context.userdetails.Where(b => b.LoginID == "admin").Select(x => x.SerialNo).First();
                            var userlocation1 = new userlocationaccess()
                            {
                                locationid = buildid,
                                authenticatedby = adminserialno,
                                userserialnum = adminserialno,
                                Level = "Building"
                            };
                            if (!context.userlocationaccesses.Any(x => x.Level == "Building" && x.userserialnum == userserialno 
                            && x.locationid == buildid) && userserialno != adminserialno)
                                context.userlocationaccesses.Add(userlocation1);
                            context.SaveChanges();
                            keyValue.Add("status", "success");
                            keyValue.Add("InsertedRows", result.ToString());
                        }
                    }    
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
        }

        /// <summary>
        /// Save new Building data or update building data in building details
        /// </summary>
        /// <param name="data"></param>
        /// <returns>count of rows with success/fail result</returns>
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> SaveFloorData(Dictionary<string, string> data)
        {
            int result=-1;
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    var adminid = Session["UserLoggedIn"].ToString();
                    var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                    using (var context = new OrganisationdatabaseEntities(db))
                    {
                        var flid = 0;
                        floordetail fd = new floordetail()
                        {
                            floor = data["floorName"].ToString(),
                            Queue = data["queue"].ToString(),
                            buildingcode = data["buildingCode"].ToString(),
                            BuildingName = Convert.ToInt32(data["building"]),
                            Remarks = data["notes"].ToString(),
                            Public = data["accessType"].ToString()
                        };
                        if(!context.floordetails.Any(x=>x.floor==fd.floor && x.BuildingName == fd.BuildingName))
                        {
                            context.floordetails.Add(fd);
                            result = context.SaveChanges();
                            flid = fd.id;
                        }
                        
                        else
                        {
                            var floordata = context.floordetails.Where(x => x.floor == fd.floor && x.BuildingName == fd.BuildingName).Select(x => x).FirstOrDefault();
                            
                            if (floordata != null)
                            {
                                floordata.floor = data["floorName"].ToString();
                                floordata.Queue = data["queue"].ToString();
                                floordata.buildingcode = data["buildingCode"].ToString();
                                floordata.BuildingName = Convert.ToInt32(data["building"]);
                                floordata.Remarks = data["notes"].ToString();
                                floordata.Public = data["accessType"].ToString();
                            }
                            result = context.SaveChanges();
                            flid = floordata.id;
                        }
                        
                        if (result >= 0)
                        {
                            var userserialno = context.userdetails.Where(b => b.LoginID == adminid).Select(x => x.SerialNo).First();
                            var userlocation = new userlocationaccess()
                            {
                                locationid = flid,
                                authenticatedby = userserialno,
                                userserialnum = userserialno,
                                Level = "Floor"
                            };
                            if (!context.userlocationaccesses.Any(x => x.Level == "Floor" && x.userserialnum == userserialno && x.locationid == flid))
                                context.userlocationaccesses.Add(userlocation);
                            
                            var adminserialno = context.userdetails.Where(b => b.LoginID == "admin").Select(x => x.SerialNo).First();
                            var userlocation1 = new userlocationaccess()
                            {
                                locationid = flid,
                                authenticatedby = adminserialno,
                                userserialnum = adminserialno,
                                Level = "Floor"
                            };
                            if(!context.userlocationaccesses.Any(x=>x.Level=="Floor" && x.userserialnum == adminserialno && x.locationid==flid)&& userserialno != adminserialno)
                            context.userlocationaccesses.Add(userlocation1);
                            context.SaveChanges();
                            keyValue.Add("status", "success");
                            keyValue.Add("InsertedRows", result.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
           
        }
        
        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> SaveTeacherData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result = orgData.SaveTeacherData(data).ToString();

                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
        }

       
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> UpdateTeacherData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result = orgData.UpdateTeacherData(data).ToString();

                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);

                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;           
        }

        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> SaveStudentData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result = orgData.SaveStudentData(data).ToString();
                    
                        keyValue.Add("status", "success");
                        keyValue.Add("InsertedRows", result);
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
        }

        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> UpdateStudentData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result = orgData.UpdateStudentData(data).ToString();

                    keyValue.Add("status", "success");
                    keyValue.Add("UpdatedRows", result);

                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
            
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> SaveClassData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result = orgData.SaveClassData(data).ToString();

                    keyValue.Add("status", "success");
                    keyValue.Add("InsertedRows", result);

                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
            
        }
 
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> UpdateClassData(Dictionary<string, string> data)
        {
            int result = 0 ;
            SetOrgData orgData = new SetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result = orgData.UpdateClassData(data);
                    if (result > 0)
                    {
                        keyValue.Add("status", "success");
                        keyValue.Add("UpdatedRows", result.ToString());
                    }
                    
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;            
        }
        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> AddUserData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result = orgData.SaveUserData(data).ToString();                    
                        keyValue.Add("status", "success");
                        keyValue.Add("InsertedRows", result);
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
           
        }

        
        [WebMethod(EnableSession = true)]
        public Dictionary<string, string> UpdateUserData(Dictionary<string, string> data)
        {
            string result = "";
            SetOrgData orgData = new SetOrgData(HttpContext.Current.Session["DBConnection"].ToString());
            Dictionary<string, string> keyValue = new Dictionary<string, string>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                keyValue.Add("status", "fail");
                keyValue.Add("errorMessage", "Session Expired");
                keyValue.Add("customErrorCode", "440");
            }
            else
            {
                try
                {
                    result = orgData.UpdateUserData(data).ToString();
                   
                        keyValue.Add("status", "success");
                        keyValue.Add("UpdatedRows", result);
                    
                }
                catch (Exception ex)
                {
                    keyValue.Add("status", "fail");
                    keyValue.Add("exception", ex.Message);
                }
            }
            return keyValue;
            
        }

    }
}
