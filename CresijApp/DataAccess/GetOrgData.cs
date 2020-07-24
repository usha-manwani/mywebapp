using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace CresijApp.DataAccess
{
    public class GetOrgData
    {
        readonly string constr = System.Configuration.ConfigurationManager.
            ConnectionStrings["SchoolConnectionString"].ConnectionString;
        public int SetOrgInfo(string deptcode, string deptname, string bCtrlCode, string highoff
            , string queno, string permission, string notes)
        {
            int result = 0;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "Insert into departmentdetail (departmentName , departmentCode)" +
                    " values ('" + deptcode+"','"+deptname +"')";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        int num =  cmd.ExecuteNonQuery();
                        if (num > 0)
                        {
                            query = "insert into organisationdetails (deptCode,BusinessCtrlCode," +
                                "HigherOffice,QueueNumber,Public,Notes) values ('"+deptcode+"','"+bCtrlCode+"','"
                                +highoff+"',"+queno+",'"+permission+"','"+notes+"')";
                            MySqlCommand cmd1 = new MySqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                            result = 1;
                        }
                    }
                }
                catch(Exception ex)
                {
                    result = -1;
                }
            }
            return result;
        }


        public DataTable GetOrgBuildingInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = " SELECT id,  buildingName,  schoolname,buildingCode, " +
                             "Queue, Public, remarks FROM buildingdetails join systemsettings";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetuserInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = " SELECT usd.SerialNo, LoginID, Username, PersonType,  buildingname, PersonnelStatus " +
                        " ,phone,  notes, validtill FROM userdetails usd join buildingdetails" +
                        " dept on usd.deptCode = dept.id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetTeacherInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = " SELECT TeacherID,TeacherName,gender,age,faculty,phone,idcard,onecard FROM teacherdata";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { }

            return dt;
        }

        public DataTable GetStudentInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT studentid,studentname,gender,age,deptcode,phone,idcard,onecard FROM studentdata";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch(Exception ex) { }
            return dt;
        }

        public DataTable GetCapitalInfo()
        {
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT `operationmgmt`.`serialno`,`operationmgmt`.`devicename`,`operationmgmt`.`assetno`, "+
                        "`operationmgmt`.`model`,`operationmgmt`.`specification`,`operationmgmt`.`devicetype`, "+
                        "`operationmgmt`.`price`,`operationmgmt`.`factory`,`operationmgmt`.`dateofmanufacture`, "+
                        "`operationmgmt`.`dateofpurchase`,`operationmgmt`.`dateofdelivery`,`operationmgmt`.`warrantytime`, "+
                        "`operationmgmt`.`locationType`,`operationmgmt`.`equipmentstatus` FROM operationmgmt";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable GetClassroomInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * from Classdetails order by classname";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex) {

            }
            return dt;
        }
        public DataTable GetClassData(string classid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * from Classdetails where classid=" +classid;
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
        public DataTable GetDevicesInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * from devicesdetails";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetOrgDataonDemand(int sn)
        {
            DataTable dt = new DataTable();
            try
            {
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
            }
            catch(Exception ex) { }
            return dt;
        }

        public DataTable GetUserDataonDemand(string sn)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * from userdetails where loginid ='" + sn+"'";
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
            }
            catch (Exception ex) { }
            return dt;
        }

        public DataTable GetIPClassByBuilding(string data,string userid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetClassIPByBuilding", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@building", data);
                        cmd.Parameters.AddWithValue("@userid", userid);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex) { }
            return dt;
        }

        public DataTable GetIPClassByBuildingFloor(string building,string floor,string userid)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT ClassName,CCEquipIP from classdetails where teachingbuilding='" + building + "' and floor ='"+floor+"' " +
                        " and classname in (select classid from userlocationaccess where userserialnum = " +
                        " (select serialno from userdetails where loginid= '"+userid+"' COLLATE utf8mb4_unicode_ci))";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetFloorlist(string building)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT floor from floordetails where buildingname='" + building+"'";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetSchoolName(string building)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT SchoolName from SystemSettings limit 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetClassByIP(string ip)
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT classname from classdetails where ccequipip ='"+ip +"' limit 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }
}