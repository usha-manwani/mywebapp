using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using CresijApp.Models;

namespace CresijApp.DataAccess
{
    /// <summary>
    /// Class to Access Database to perform Delete Operation On data
    /// </summary>
    public class DeleteOrgDetails
    {
        string constr = System.Configuration.ConfigurationManager.
           ConnectionStrings["Organisationdatabase"].ConnectionString;
        #region constructor
        public DeleteOrgDetails() { }
        /// <summary>
        /// Contructor to initialize connection string according to required database connection
        /// </summary>
        /// <param name="constring"></param>
        public DeleteOrgDetails(string constring) { constr = constring; }
        #endregion
        #region Methods
        /// <summary>
        /// Connection to database to delete Student Details by List of Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>No. of rows deleted</returns>
        public int DeleteMultipleStudent(List<string> ids)
        {
            int result = 0;
            var st = string.Join("','", ids);
            st = "'" + st + "'";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "delete from studentdata where studentid in (" + st + ")";
                using (MySqlCommand cm = new MySqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    result = cm.ExecuteNonQuery();
                }
            }
            return result;
        }
        /// <summary>
        /// Connection to database to delete Teacher Details by List of Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>No. of rows deleted</returns>
        public int DeleteMultipleTeacher(List<string> ids)
        {
            int result = 0;
            var st = string.Join("','", ids);
            st = "'" + st + "'";
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "delete from teacherdata where teacherid in (" + st + ")";
                using (MySqlCommand cm = new MySqlCommand(query, con))
                {
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    result = cm.ExecuteNonQuery();
                }
            }
            return result;
        }
        /// <summary>
        /// Connection to database to delete Building Details by List of Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>No. of rows deleted</returns>
        public int DeleteMultipleBuilding(List<string> ids)
        {
            int result = 0;
            var st = string.Join(",", ids);
            using (var context = new OrganisationdatabaseEntities())
            {
                using (var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(string d in ids)
                        {
                            var id = Convert.ToInt32(d);
                            var ed = context.userlocationaccesses.Where(x => x.locationid == id && x.Level == "Building").Select(y => y);
                            context.userlocationaccesses.RemoveRange(ed);
                            var bd = context.buildingdetails.Where(x => x.id == id).Select(y => y);
                            context.buildingdetails.RemoveRange(bd);
                        }
                        result = context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        result = -1;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Connection to database to delete Class Details by List of Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>No. of rows deleted</returns>
        public int DeleteMultipleClass(List<string> ids)
        {
            int result = 0;
            var st = string.Join(",", ids);
            List<classdetail> lisClassDetails = new List<classdetail>();
            using (var context = new OrganisationdatabaseEntities())
            {
                using (var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(string d in ids)
                        {
                            var id = Convert.ToInt32(d);
                            var ed = context.userlocationaccesses.Where(x => x.locationid == id && x.Level == "Class").Select(y => y);
                            context.userlocationaccesses.RemoveRange(ed);
                            var cd = context.classdetails.Where(x => x.classID == id).Select(y => y);
                            context.classdetails.RemoveRange(cd);
                        }
                        result = context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        result = -1;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Connection to database to delete Floor Details by List of Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>No. of rows deleted</returns>
        public int DeleteMultipleFloor(List<string> ids)
        {
            int result = 0;
            var st = string.Join(",", ids);
            using (var context = new OrganisationdatabaseEntities())
            {
                using (var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (string d in ids)
                        {
                            var id = Convert.ToInt32(d);
                            var ed = context.userlocationaccesses.Where(x => x.locationid == id && x.Level == "Floor").Select(y => y);
                            context.userlocationaccesses.RemoveRange(ed);
                            var cd = context.floordetails.Where(x => x.id == id).Select(y => y);
                            context.floordetails.RemoveRange(cd);
                        }
                        result = context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        result = -1;
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Connection to database to delete User Details by List of Id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>No. of rows deleted</returns>
        public int DeleteMultipleUser(List<string> ids)
        {
            int result = 0;
            var st = string.Join("','", ids);
            st = "'" + st + "'";
            using (var context = new OrganisationdatabaseEntities())
            {
                using (var dbtransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Database.ExecuteSqlCommand(@"delete from userdetails where loginid in( " + st + ")");
                        result = context.SaveChanges();
                        dbtransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbtransaction.Rollback();
                        result = -1;
                    }

                }
            }
            return result;
        }
        #endregion
    }
}