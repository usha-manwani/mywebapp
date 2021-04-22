// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 08-20-2020
//
// Last Modified By : admin
// Last Modified On : 04-20-2021
// ***********************************************************************
// <copyright file="DocumentController.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using CresijApp.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace CresijApp.Controllers
{
    /// <summary>
    /// the controller is used to upload csv/xls files
    /// </summary>
    /// <summary>
    /// Class DocumentController.
    /// Implements the <see cref="System.Web.Http.ApiController" />
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class DocumentController : ApiController
    {

        /// <summary>
        /// The upload
        /// </summary>
        UploadFile upload;

        /// <summary>
        /// this web method is use to call for documents uploading
        /// </summary>
        /// <returns>success/fail result</returns>
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
                    var fieldList = request.Form.GetValues("FieldList");

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
                        {
                            idata.Add("status", "fail due to no column list found");
                        }
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
                                {
                                    File.Delete(filename);
                                }

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
                                {
                                    File.Delete(filename);
                                }

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
                                {
                                    File.Delete(filename);
                                }

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
                                {
                                    File.Delete(filename);
                                }

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
                                {
                                    File.Delete(filename);
                                }

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
                                {
                                    File.Delete(filename);
                                }

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
                                {
                                    File.Delete(filename);
                                }

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
                                {
                                    File.Delete(filename);
                                }

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
                    {
                        File.Delete(filename);
                    }
                }
            }
            idata.Add("status", "fail");
            idata.Add("message", "No File Found");
            return idata;
        }

        /// <summary>
        /// Uploads the logo.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="path">The path.</param>
        /// <returns>System.String.</returns>
        private string UploadLogo(HttpPostedFile file, string path)
        {
            //Set the File Name.
            string fileName = Path.Combine(path + "Logo_" + file.FileName + DateTime.Now.ToString("HHmmss"));
            //Save the File in Folder.
            file.SaveAs(fileName);
            return "~/Uploads/" + new FileInfo(fileName).Name;
        }

    }
}
