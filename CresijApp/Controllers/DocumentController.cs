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
        public Dictionary<string,object> UploadFiles()
        {
           var idata= new Dictionary<string, object>();
           var request = HttpContext.Current.Request;
            string filename = "";
            // Checking no of files injected in Request object  
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                // TODO: Add insert logic here
                try
                {
                    //Upload Logo
                    if (request["Type"] == "UploadLogo")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                        filename= UploadLogo(postedFile, folderPath);
                        if (!string.IsNullOrEmpty(filename))
                        {
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                        }
                    }

                    //Upload Student File
                    else if (request["Type"] == "UploadStudentData")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                        {
                            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            idata = UploadStudentData(postedFile, folderPath);
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                            idata.Add("message", "file was in incorrect format!");
                        }
                    }

                    //upload teacher file
                    else if (request["Type"] == "UploadTeacherData")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                        {
                            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            idata = UploadTeacherData(postedFile, folderPath);
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                            idata.Add("message", "file was in incorrect format!");
                        }
                    }

                    //upload schedule
                    else if (request["Type"] == "UploadScheduleData")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                        {
                            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            idata = UploadScheduleData(postedFile, folderPath);
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                            idata.Add("message", "file was in incorrect format!");
                        }
                    }
                   
                    //upload user
                    else if (request["Type"] == "UploadUserData")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                        {
                            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            idata = UploadUserData(postedFile, folderPath);
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                            idata.Add("message", "file was in incorrect format!");
                        }
                    }
                   
                    //upload class
                    else if (request["Type"] == "UploadClassData")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                        {
                            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            idata = UploadClassData(postedFile, folderPath);
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                            idata.Add("message", "file was in incorrect format!");
                        }
                    }

                    //upload Capital Data
                    else if (request["Type"] == "UploadCapitalData")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                        {
                            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            idata= UploadCapitalData(postedFile, folderPath);
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                            idata.Add("message", "file was in incorrect format!");
                        }
                    }

                    else if (request["Type"] == "UploadBuildingData")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                        {
                            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            idata = UploadBuildingData(postedFile, folderPath);
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                            idata.Add("message", "file was in incorrect format!");
                        }
                    }
                    else if (request["Type"] == "UploadFloorData")
                    {
                        //Fetch the Uploaded File.
                        HttpPostedFile postedFile = request.Files[0];
                        //Set the Folder Path.
                        if (Path.GetExtension(postedFile.FileName).Equals(".txt") || Path.GetExtension(postedFile.FileName).Equals(".csv"))
                        {
                            string folderPath = HttpContext.Current.Server.MapPath("~/Uploads/");
                            idata = UploadBuildingData(postedFile, folderPath);
                            idata.Add("status", "success");
                        }
                        else
                        {
                            idata.Add("status", "fail");
                            idata.Add("message", "file was in incorrect format!");
                        }
                    }
                    return idata;
                }
                catch (Exception ex)
                {
                    idata.Add("status", "fail");
                    idata.Add("Message " , ex.Message);
                    return idata;
                }  
            }
            idata.Add("status", "fail");
            idata.Add("message", "No File Found");
            return idata;
        }

        private string UploadLogo(HttpPostedFile file, string path)
        {
            //Set the File Name.
            string fileName =Path.Combine( path + "Logo_" + file.FileName);
            //Save the File in Folder.
            file.SaveAs(fileName);
            return fileName;
        }

        private Dictionary<string, object> UploadStudentData(HttpPostedFile file, string path)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            string filename = "";
            int numofrows = 0;
            if (Path.GetExtension(file.FileName).Equals(".txt") || Path.GetExtension(file.FileName).Equals(".csv"))
            {
                var fname = "UploadStudentData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                filename = Path.Combine(path + fname + Path.GetExtension(file.FileName));
                if (File.Exists(filename))
                    File.Delete(filename);
                file.SaveAs(filename);
                using (var conn = new MySqlConnection(constr))
                {
                    string filename1 = filename.Replace("\\", "/");
                    var query = "load data infile '" + filename1 + "' Replace into table organisationdatabase.studentdata fields " +
                        "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    conn.InfoMessage += delegate (object sender, MySqlInfoMessageEventArgs e)
                    {
                        foreach (MySqlError err in e.errors)
                        {
                            messages.Add(err.Message);
                        }
                    };
                    cmd.CommandTimeout = 5000000;
                    numofrows = cmd.ExecuteNonQuery();
                }
                if (File.Exists(filename))
                    File.Delete(filename);
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            }
            return idata;
        }

        private Dictionary<string, object> UploadTeacherData(HttpPostedFile file, string path)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            string filename = "";
            int numofrows = 0;
            if (Path.GetExtension(file.FileName).Equals(".txt") || Path.GetExtension(file.FileName).Equals(".csv"))
            {
                var fname = "UploadTeacherData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                filename = Path.Combine(path + fname + Path.GetExtension(file.FileName));
                if (File.Exists(filename))
                    File.Delete(filename);
                file.SaveAs(filename);
                using (var conn = new MySqlConnection(constr))
                {
                    string filename1 = filename.Replace("\\", "/");
                    var query = "load data infile '" + filename1 + "' Replace into table organisationdatabase.teacherdata fields " +
                        "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    conn.InfoMessage += delegate (object sender, MySqlInfoMessageEventArgs e)
                    {
                        foreach (MySqlError err in e.errors)
                        {
                            messages.Add(err.Message);
                        }
                    };
                    cmd.CommandTimeout = 5000000;
                    numofrows = cmd.ExecuteNonQuery(); 
                }
                if (File.Exists(filename))
                    File.Delete(filename);
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            }
            return idata;
        }

        private Dictionary<string, object> UploadScheduleData(HttpPostedFile file, string path)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            string filename = "";
            int numofrows = 0;
            if (Path.GetExtension(file.FileName).Equals(".txt") || Path.GetExtension(file.FileName).Equals(".csv"))
            {
                var fname = "UploadScheduleData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                filename = Path.Combine(path + fname + Path.GetExtension(file.FileName));
                if (File.Exists(filename))
                    File.Delete(filename);
                file.SaveAs(filename);
                using (var conn = new MySqlConnection(constr))
                {
                    string filename1 = filename.Replace("\\", "/");
                    var query = "load data infile '" + filename1 + "' Replace into table organisationdatabase.schedule fields " +
                               "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`year`,`sem`,`teacherid`," +
                               "`teachername`,`courseid`,`classname`,`coursename`,`weekstart`,`weekend`,`dayno`,`section`,`teachingbuilding`,`floor`)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    conn.InfoMessage += delegate (object sender, MySqlInfoMessageEventArgs e)
                    {
                        foreach (MySqlError err in e.errors)
                        {
                            messages.Add(err.Message);
                        }
                    };
                    cmd.CommandTimeout = 5000000;
                    numofrows = cmd.ExecuteNonQuery();
                }
                if (File.Exists(filename))
                    File.Delete(filename);
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            }
            return idata;
        }

        private Dictionary<string,object> UploadUserData(HttpPostedFile file, string path)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            string filename = "";
            int numofrows = 0;
            if (Path.GetExtension(file.FileName).Equals(".txt") || Path.GetExtension(file.FileName).Equals(".csv"))
            {
                var fname = "UploadUserData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                filename = Path.Combine(path + fname + Path.GetExtension(file.FileName));
                if (File.Exists(filename))
                    File.Delete(filename);
                file.SaveAs(filename);
                using (var conn = new MySqlConnection(constr))
                {
                    
                    string filename1 = filename.Replace("\\", "/");
                    var query = "load data infile '" + filename1 + "' ignore into table organisationdatabase.userdetails fields " +
                                 "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`loginID`,`UserName`,`PersonType`," +
                                 "`Deptcode`,`PersonnelStatus`,`Notes`,`Password`,`phone`,`startdate`,`expiredate`)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    conn.InfoMessage += delegate (object sender, MySqlInfoMessageEventArgs e)
                    {
                        foreach (MySqlError err in e.errors)
                        {
                            messages.Add(err.Message);
                        }
                    };
                    cmd.CommandTimeout = 5000000;
                    numofrows = cmd.ExecuteNonQuery();
                }
                if (File.Exists(filename))
                    File.Delete(filename);
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            }
            return idata;
        }

        private Dictionary<string, object> UploadClassData(HttpPostedFile file, string path)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            string filename = "";
            int numofrows = 0;
            if (Path.GetExtension(file.FileName).Equals(".txt") || Path.GetExtension(file.FileName).Equals(".csv"))
            {
                var fname = "UploadClassData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                filename = Path.Combine(path + fname + Path.GetExtension(file.FileName));
                if (File.Exists(filename))
                    File.Delete(filename);
                file.SaveAs(filename);
                using (var conn = new MySqlConnection(constr))
                {
                    string filename1 = filename.Replace("\\", "/");
                    var query = "load data infile '" + filename1 + "' Replace into table organisationdatabase.classdetails fields " +
                                 "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`ClassName`,`teachingbuilding`," +
                                 "`floor`,`seats`,`camipS`,`camipT`,`camSmac`,`camTmac`,`camport`,`camuserid`,`campass`," +
                                 "`ccequipIP`,`ccmac`,`desktopip`,`deskmac`,`recordingEquip`,`recordermac`,`callhelpip`,`callhelpmac`)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    conn.InfoMessage += delegate (object sender, MySqlInfoMessageEventArgs e)
                    {
                        foreach (MySqlError err in e.errors)
                        {
                            messages.Add(err.Message);
                        }
                    };
                    cmd.CommandTimeout = 5000000;
                    numofrows = cmd.ExecuteNonQuery();
                }
                if (File.Exists(filename))
                    File.Delete(filename);
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            }
            return idata;
        }

        private Dictionary<string, object> UploadCapitalData(HttpPostedFile file, string path)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            string filename = "";
            int numofrows = 0;
            if (Path.GetExtension(file.FileName).Equals(".txt") || Path.GetExtension(file.FileName).Equals(".csv"))
            {
                var fname = "UploadCapitalData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                filename = Path.Combine(path + fname + Path.GetExtension(file.FileName));
                if (File.Exists(filename))
                    File.Delete(filename);
                file.SaveAs(filename);
                using (var conn = new MySqlConnection(constr))
                {
                    string filename1 = filename.Replace("\\", "/");
                    var query = "load data infile '" + filename1 + "' Replace into table organisationdatabase.operationmgmt fields " +
                                 "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`devicename`,`assetno`,`model`," +
                                 "`specification`,`devicetype`,`price`,`factory`,`dateofmanufacture`,`dateofpurchase`,`dateofdelivery`," +
                                 "`warrantytime`,`locationType`,`equipmentstatus`)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    conn.InfoMessage += delegate (object sender, MySqlInfoMessageEventArgs e)
                    {
                        foreach (MySqlError err in e.errors)
                        {
                            messages.Add(err.Message);
                        }
                    };
                    cmd.CommandTimeout = 5000000;
                    numofrows = cmd.ExecuteNonQuery();
                }
                if (File.Exists(filename))
                    File.Delete(filename);
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            }
            return idata;
        }

        private Dictionary<string, object> UploadBuildingData(HttpPostedFile file, string path)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            string filename = "";
            int numofrows = 0;
            if (Path.GetExtension(file.FileName).Equals(".txt") || Path.GetExtension(file.FileName).Equals(".csv"))
            {
                var fname = "UploadBuildingData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                filename = Path.Combine(path + fname + Path.GetExtension(file.FileName));
                if (File.Exists(filename))
                    File.Delete(filename);
                file.SaveAs(filename);
                using (var conn = new MySqlConnection(constr))
                {
                    string filename1 = filename.Replace("\\", "/");
                    var query = "load data infile '" + filename1 + "' ignore into table organisationdatabase.buildingdetails fields " +
                                 "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`BuildingName`,`Buildingcode`," +
                                 "`Queue`,`Public`,`remarks`)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    conn.InfoMessage += delegate (object sender, MySqlInfoMessageEventArgs e)
                    {
                        foreach (MySqlError err in e.errors)
                        {
                            messages.Add(err.Message);
                        }
                    };
                    cmd.CommandTimeout = 5000000;
                    numofrows = cmd.ExecuteNonQuery();
                }
                if (File.Exists(filename))
                    File.Delete(filename);
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            }
            return idata;
        }

        private Dictionary<string, object> UploadFloorData(HttpPostedFile file, string path)
        {
            Dictionary<string, object> idata = new Dictionary<string, object>();
            List<string> messages = new List<string>();
            string filename = "";
            int numofrows = 0;
            if (Path.GetExtension(file.FileName).Equals(".txt") || Path.GetExtension(file.FileName).Equals(".csv"))
            {
                var fname = "UploadFloorData" + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second;
                filename = Path.Combine(path + fname + Path.GetExtension(file.FileName));
                if (File.Exists(filename))
                    File.Delete(filename);
                file.SaveAs(filename);
                using (var conn = new MySqlConnection(constr))
                {
                    string filename1 = filename.Replace("\\", "/");
                    var query = "load data infile '" + filename1 + "' ignore into table organisationdatabase.floordetails fields " +
                                 "terminated by ',' enclosed by '\"' lines terminated by '\n' IGNORE 1 LINES(`floor`,`BuildingName`,`Buildingcode`," +
                                 "`Queue`,`Public`,`remarks`)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();
                    conn.InfoMessage += delegate (object sender, MySqlInfoMessageEventArgs e)
                    {
                        foreach (MySqlError err in e.errors)
                        {
                            messages.Add(err.Message);
                        }
                    };
                    cmd.CommandTimeout = 5000000;
                    numofrows = cmd.ExecuteNonQuery();
                }
                if (File.Exists(filename))
                    File.Delete(filename);
                idata.Add("Rows Inserted", numofrows);
                idata.Add("Import warnings", messages);
            }
            return idata;
        }
    }
}
