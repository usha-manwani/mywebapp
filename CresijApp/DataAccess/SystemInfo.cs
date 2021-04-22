// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 05-07-2020
//
// Last Modified By : admin
// Last Modified On : 04-21-2021
// ***********************************************************************
// <copyright file="SystemInfo.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CresijApp.DataAccess
{
    /// <summary>
    /// this class is use to deal with database operation for Website's System Setting
    /// This class is use to deal with adding new school details, like
    /// Time of sessions, semester start dates and weeks of operation, school name,
    /// set different options for appointments and transfer Permissions
    /// Getting all the related data back from database and update it
    /// </summary>
    /// <summary>
    /// Class SystemInfo.
    /// </summary>
    public class SystemInfo
    {
        /// <summary>
        /// Default Connection
        /// </summary>
        /// <summary>
        /// The constr
        /// </summary>
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["Organisationdatabase"].ConnectionString;
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemInfo"/> class.
        /// </summary>
        public SystemInfo() { }
        /// <summary>
        /// session connection
        /// </summary>
        /// <param name="constring"></param>
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemInfo"/> class.
        /// </summary>
        /// <param name="constring">The constring.</param>
        public SystemInfo(string constring) { constr = System.Configuration.ConfigurationManager.
            ConnectionStrings[constring].ConnectionString; }
        /// <summary>
        /// Method to call sp_insertSystemInfo to save school name, semester infoes 
        /// </summary>
        /// <param name="schoolname"></param>
        /// <param name="schooleng"></param>
        /// <param name="logourl"></param>
        /// <param name="semname"></param>
        /// <param name="weeks"></param>
        /// <param name="semstartdate"></param>
        /// <param name="days"></param>
        /// <param name="semno"></param>
        /// <param name="autoholiday"></param>
        /// <returns></returns>
        /// <summary>
        /// Saves the system information.
        /// </summary>
        /// <param name="schoolname">The schoolname.</param>
        /// <param name="schooleng">The schooleng.</param>
        /// <param name="logourl">The logourl.</param>
        /// <param name="semname">The semname.</param>
        /// <param name="weeks">The weeks.</param>
        /// <param name="semstartdate">The semstartdate.</param>
        /// <param name="days">The days.</param>
        /// <param name="semno">The semno.</param>
        /// <param name="autoholiday">The autoholiday.</param>
        /// <returns>System.Int32.</returns>
        public int SaveSystemInfo(string schoolname, string schooleng, string logourl, string semname, string weeks, string semstartdate, Dictionary<string, string> days, int semno, string autoholiday)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_insertSystemInfo", con)) // sp_SaveTempData
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@schname", schoolname);
                    cmd.Parameters.AddWithValue("@scheng", schooleng);
                    cmd.Parameters.AddWithValue("@logoloc", logourl);
                    cmd.Parameters.AddWithValue("@semname", semname);
                    cmd.Parameters.AddWithValue("@semweeks", weeks);
                    cmd.Parameters.AddWithValue("@semstart", semstartdate);
                    cmd.Parameters.AddWithValue("@sun", days["Sunday"]);
                    cmd.Parameters.AddWithValue("@mon", days["Monday"]);
                    cmd.Parameters.AddWithValue("@tue", days["Tuesday"]);
                    cmd.Parameters.AddWithValue("@wed", days["Wednesday"]);
                    cmd.Parameters.AddWithValue("@thu", days["Thursday"]);
                    cmd.Parameters.AddWithValue("@fri", days["Friday"]);
                    cmd.Parameters.AddWithValue("@sat", days["Saturday"]);
                    cmd.Parameters.AddWithValue("@semno", Convert.ToInt32(semno));
                    cmd.Parameters.AddWithValue("@autoholiday", autoholiday);
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
        /// Mehtod to call "sp_insertUpdateSection" to insert record in section infoes 
        /// </summary>
        /// <param name="semname"></param>
        /// <param name="section"></param>
        /// <param name="starttime"></param>
        /// <param name="stoptime"></param>
        /// <returns>no. of affected records</returns>
        /// <summary>
        /// Saves the sections information.
        /// </summary>
        /// <param name="semname">The semname.</param>
        /// <param name="section">The section.</param>
        /// <param name="starttime">The starttime.</param>
        /// <param name="stoptime">The stoptime.</param>
        /// <returns>System.Int32.</returns>
        public int SaveSectionsInfo(string semname, string section, string starttime, string stoptime)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_insertUpdateSection", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@semname", semname);
                    cmd.Parameters.AddWithValue("@sec", section);
                    cmd.Parameters.AddWithValue("@starttime", starttime);
                    cmd.Parameters.AddWithValue("@stoptime", stoptime);


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
        /// Method to call "sp_InsertUpdateReserverTransfer" to insert record for Reserve/Transfer settings
        /// </summary>
        /// <param name="typ"></param>
        /// <param name="nonwork"></param>
        /// <param name="auto"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="semname"></param>
        /// <returns>no of inserted records</returns>
        /// <summary>
        /// Saves the reserve and transfer information.
        /// </summary>
        /// <param name="typ">The typ.</param>
        /// <param name="nonwork">The nonwork.</param>
        /// <param name="auto">The automatic.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="semname">The semname.</param>
        /// <returns>System.Int32.</returns>
        public int SaveReserveAndTransferInfo(string typ, string nonwork, string auto, string start, string end, string semname)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {

                using (MySqlCommand cmd = new MySqlCommand("sp_InsertUpdateReserverTransfer", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@typ", typ);
                    cmd.Parameters.AddWithValue("@nonwork", nonwork);
                    cmd.Parameters.AddWithValue("@autoreview", auto);
                    cmd.Parameters.AddWithValue("@semname", semname);
                    cmd.Parameters.AddWithValue("@startdate", start);
                    cmd.Parameters.AddWithValue("@enddate", end);
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
        /// call to "sp_deleteSection" to delete section infoes belong to a semester
        /// </summary>
        /// <param name="semname"></param>
        /// <returns></returns>
        /// <summary>
        /// Deletes the sections information.
        /// </summary>
        /// <param name="semname">The semname.</param>
        /// <returns>System.Int32.</returns>
        public int DeleteSectionsInfo(string semname)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_deleteSection", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@semname", semname);
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
        /// get floor and class group by building
        /// </summary>
        /// <param name="building"></param>
        /// <returns></returns>
        /// <summary>
        /// Gets the floor class by building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetFloorClassByBuilding(string building)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select fd.floor ,json_arrayagg(json_object('Name',classname , 'Id',classid)) as className from " +
                        "classdetails cd join floordetails fd on fd.id = cd.floor where teachingbuilding=" + building +
                        " and cd.floor in (select id from floordetails where buildingName= " +
                        building + " ) group by cd.floor union " +
                        "select floor,'' from floordetails where buildingname=" + building + " and id not in " +
                        "(select floor from classdetails where teachingbuilding = " +
                         building + ") " +
                        "group by floor order by floor";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    mySqlDataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// call sp_GetipByClass to get machine ip and classname with classids
        /// </summary>
        /// <param name="classlist">The classlist.</param>
        /// <returns>list of machienip:classname</returns>
        public DataTable GetIpByClass(string classlist)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("sp_GetipByClass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@classlist", classlist);
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    mySqlDataAdapter.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// get floor and class group by building that are accessible by user
        /// </summary>
        /// <param name="building">The building.</param>
        /// <param name="userid">The userid.</param>
        /// <returns>DataTable.</returns>
        public DataTable GetFloorClassByBuildingUserAccess(string building, string userid)
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select fd.floor ,json_arrayagg(json_object('Name',classname , 'Id',classid)) as className from " +
                        "classdetails cd join floordetails fd on fd.id = cd.floor where teachingbuilding=" + building + 
                        "and cd.floor in (select id from floordetails where buildingName=" + building + ") " +
                        "group by floor and classid in " +
                    "(select locationid from userlocationaccess where level ='Class' and userserialnum =(select serialno from userdetails" +
                    " where loginid ='" + userid + "')) group by cd.floor ";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }
                    MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                    mySqlDataAdapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}