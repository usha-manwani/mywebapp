using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;
using CresijApp.DataAccess;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text.RegularExpressions;
using CresijApp.Models;
using System.Text;
using System.Data.OleDb;
using System.Reflection;
using System.Web.SessionState;

namespace CresijApp.Controllers
{
    
    public class DocumentController : ApiController
    {
        string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["SchoolConnectionString"].ConnectionString;
        UploadFile upload;
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
            upload = new UploadFile();
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

                        var fname = UploadLogo(postedFile, folderPath);
                        if (!string.IsNullOrEmpty(fname))
                        {
                            idata.Add("status", "success");
                            idata.Add("filename", fname);
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
                                var studentDataTable = upload.CreateTable(filename, fieldList);
                                idata = upload.UploadStudentData(studentDataTable.Tables[0]);
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
                                var teacherDataTable = upload.CreateTable(filename, fieldList);
                                idata = upload.UploadTeacherData(teacherDataTable.Tables[0]);
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

                                var scheduleDataTable = upload.CreateTable(filename, fieldList);
                                idata = upload.UploadScheduleData(scheduleDataTable.Tables[0]);
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
                                var userDataTable = upload.CreateTable(filename, fieldList);
                                idata = upload.UploadUserData(userDataTable.Tables[0]);
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
                                var classDataTable = upload.CreateTable(filename, fieldList);
                                idata = upload.UploadClassData(classDataTable.Tables[0]);
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
                                var capitalDataTable = upload.CreateTable(filename, fieldList);
                                idata = upload.UploadCapitalData(capitalDataTable.Tables[0]);
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
                                var buildingDataTable = upload.CreateTable(filename, fieldList);
                                idata = upload.UploadBuildingData(buildingDataTable.Tables[0]);
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
                                var floorDataTable = upload.CreateTable(filename, fieldList);
                                idata = upload.UploadFloorData(floorDataTable.Tables[0]);
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
            string fileName = Path.Combine(path + "Logo_" + file.FileName+DateTime.Now.ToString("HHmmss"));
            //Save the File in Folder.
            file.SaveAs(fileName);
            return "~/Uploads/" + new FileInfo(fileName).Name;
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
