using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
namespace CresijApp.DataAccess
{
    /// <summary>
    /// this class is use to save and update database records 
    /// Class contains Save and Update Methods for:UserDetails table, BuildingDetails , StudentDetails, TeacherDetails, ClassDetails
    /// and their different variations according to requirement.
    /// </summary>
    public class SetOrgData
    {
        //default connection string
        string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["Organisationdatabase"].ConnectionString;
        public SetOrgData() { }
        /// <summary>
        /// parameterized
        /// </summary>
        /// <param name="constring"></param>
        public SetOrgData(string constring) { constr = constring; }
        /// <summary>
        /// This method is use to insert new record in teacherdetails table in database
        /// </summary>
        /// <param name="data"></param>
        /// <returns>no of inserted rows</returns>
        public int SaveTeacherData(Dictionary<string, string> data)
        {
            int result = -1;

            string query = "insert into teacherdata values ('" + data["teacherId"] + "','" + data["teacherName"] + "','" + data["gender"] +
                "','" + data["birthday"] + "','" + data["faculty"] + "','" + data["phone"] + "','" + data["idCard"] + "','" + data["oneCard"] + "')";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        /// <summary>
        /// This method is use to insert new record in studentdetails table in database
        /// </summary>
        /// <param name="data"></param>
        /// <returns>no. of inserted rows</returns>
        public int SaveStudentData(Dictionary<string, string> data)
        {
            int result = -1;


            string query = "insert into studentdata values ('" + data["studentId"] + "','" + data["studentName"] + "','" + data["gender"] +
                "','" + data["birthday"] + "','" + data["faculty"] + "','" + data["phone"] + "','" + data["idCard"] + "','" + data["oneCard"] + "')";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        /// <summary>
        /// this method is use to update a record in teacherdetails by its id
        /// </summary>
        /// <param name="data"></param>
        /// <returns>no of updated rows</returns>
        public int UpdateTeacherData(Dictionary<string, string> data)
        {
            int result = -1;

            string query = "update teacherdata set teachername='" + data["teacherName"] +
                "',gender='" + data["gender"] + "', DateOfBirth='" + data["birthday"] + "', faculty='" + data["faculty"] +
                "', phone='" + data["phone"] + "',idcard='" + data["idCard"] +
                "',onecard='" + data["oneCard"] + "' where teacherid ='" + data["teacherId"] + "'";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        /// <summary>
        /// this method is use to update a record in studentdetails by its id
        /// </summary>
        /// <param name="data"></param>
        /// <returns>no of updated rows</returns>
        public int UpdateStudentData(Dictionary<string, string> data)
        {
            int result = -1;

            string query = "update studentdata set studentname='" + data["studentName"] +
                "',gender='" + data["gender"] + "', DateOfBirth='" + data["birthday"] + "', deptcode='" + data["faculty"] +
                "', phone='" + data["phone"] + "',idcard='" + data["idCard"] +
                "',onecard='" + data["oneCard"] + "' where studentid ='" + data["studentId"] + "'";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        /// <summary>
        /// this method is use to insert a record in classdetails table
        /// </summary>
        /// <param name="data"></param>
        /// <returns>no of inserted rows</returns>
        public int SaveClassData(Dictionary<string, string> data)
        {
            int result = -1;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_SaveClassData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("cname", data["className"]);
                    cmd.Parameters.AddWithValue("tbuild", data["building"]);
                    cmd.Parameters.AddWithValue("tfloor", data["floor"]);
                    cmd.Parameters.AddWithValue("tseat", data["seat"]);
                    cmd.Parameters.AddWithValue("camipS", data["camIpS"]);
                    cmd.Parameters.AddWithValue("camipT", data["camIpT"]);
                    cmd.Parameters.AddWithValue("camSmac", data["camSmac"]);
                    cmd.Parameters.AddWithValue("camTmac", data["camTmac"]);
                    cmd.Parameters.AddWithValue("camport", data["camPort"]);
                    cmd.Parameters.AddWithValue("camid", data["camId"]);
                    cmd.Parameters.AddWithValue("campass", data["camPass"]);
                    cmd.Parameters.AddWithValue("ccip", data["centralControlIp"]);
                    cmd.Parameters.AddWithValue("ccmac", data["centralControlMac"]);
                    cmd.Parameters.AddWithValue("deskip", data["desktopIp"]);
                    cmd.Parameters.AddWithValue("deskmac", data["desktopMac"]);
                    cmd.Parameters.AddWithValue("recip", data["recorderIp"]);
                    cmd.Parameters.AddWithValue("recmac", data["recorderMac"]);
                    cmd.Parameters.AddWithValue("callhelpip", data["callHelpIp"]);
                    cmd.Parameters.AddWithValue("callhelpmac", data["callHelpMac"]);

                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        /// <summary>
        /// this method is use to update a record in classdetetails by its id
        /// </summary>
        /// <param name="data"></param>
        /// <returns>no of updated rows</returns>
        public int UpdateClassData(Dictionary<string, string> data)
        {
            int result = -1;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_UpdateClassData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("clsid", data["classID"]);
                    cmd.Parameters.AddWithValue("cname", data["className"]);
                    cmd.Parameters.AddWithValue("tbuild", data["building"]);
                    cmd.Parameters.AddWithValue("tfloor", data["floor"]);
                    cmd.Parameters.AddWithValue("tseat", data["seat"]);
                    cmd.Parameters.AddWithValue("camsip", data["camIpS"]);
                    cmd.Parameters.AddWithValue("camtip", data["camIpT"]);
                    cmd.Parameters.AddWithValue("camsmac", data["camSmac"]);
                    cmd.Parameters.AddWithValue("camtmac", data["camTmac"]);
                    cmd.Parameters.AddWithValue("camport", data["camPort"]);
                    cmd.Parameters.AddWithValue("camid", data["camId"]);
                    cmd.Parameters.AddWithValue("campass", data["camPass"]);
                    cmd.Parameters.AddWithValue("ccip", data["centralControlIp"]);
                    cmd.Parameters.AddWithValue("ccmac", data["centralControlMac"]);
                    cmd.Parameters.AddWithValue("deskip", data["desktopIp"]);
                    cmd.Parameters.AddWithValue("deskmac", data["desktopMac"]);
                    cmd.Parameters.AddWithValue("recip", data["recorderIp"]);
                    cmd.Parameters.AddWithValue("recmac", data["recorderMac"]);
                    cmd.Parameters.AddWithValue("callhelpip", data["callHelpIp"]);
                    cmd.Parameters.AddWithValue("callhelpmac", data["callHelpMac"]);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }
        /// <summary>
        /// this method is use to insert a record in userdetails 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>no of records inserted</returns>
        public int SaveUserData(Dictionary<string, string> data)
        {
            int result = -1;
            if (data["personType"].ToString() == "longterm")
            {
                data["expireDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                data["startDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_SaveUserData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("logid", data["loginId"]);
                    cmd.Parameters.AddWithValue("uname", data["userName"]);
                    cmd.Parameters.AddWithValue("ptype", data["personType"]);

                    cmd.Parameters.AddWithValue("stats", data["personnelStatus"]);
                    cmd.Parameters.AddWithValue("phone", data["phone"]);
                    cmd.Parameters.AddWithValue("note", data["notes"]);
                    cmd.Parameters.AddWithValue("pass", data["password"]);
                    cmd.Parameters.AddWithValue("expiredate", data["expireDate"]);
                    cmd.Parameters.AddWithValue("startdate", data["startDate"]);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }
        /// <summary>
        /// method to update a record in userdetails with its id
        /// </summary>
        /// <param name="data"></param>
        /// <returns>no of updated records</returns>
        public int UpdateUserData(Dictionary<string, string> data)
        {
            int result = -1;
            if (data["personType"].ToString() == "longterm")
            {
                data["expireDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                data["startDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_UpdateUserData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("logid", data["loginId"]);
                    cmd.Parameters.AddWithValue("uname", data["userName"]);
                    cmd.Parameters.AddWithValue("ptype", data["personType"]);

                    cmd.Parameters.AddWithValue("stats", data["personnelStatus"]);
                    cmd.Parameters.AddWithValue("phone", data["phone"]);
                    cmd.Parameters.AddWithValue("note", data["notes"]);
                    cmd.Parameters.AddWithValue("pass", data["password"]);
                    cmd.Parameters.AddWithValue("expiredate", data["expireDate"]);
                    cmd.Parameters.AddWithValue("startdate", data["startDate"]);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

    }
}