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


        public DataTable GetOrgInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = " SELECT org.SerialNo, org.deptcode, departmentName, BusinessCtrlCode, HigherOffice," +
                             "QueueNumber, Public, notes FROM organisationdetails org join " +
                             "departmentdetail dept on org.deptCode = dept.departmentCode ";
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
                    string query = " SELECT usd.SerialNo, LoginID, Username, PersonType, departmentName, PersonnelStatus " +
                        " , telephone, notes FROM userdetails usd join departmentdetail" +
                        " dept on usd.deptCode = dept.departmentCode";
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
                    string query = "SELECT * from Classdetails";
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
                    string query = "select departmentname, businessctrlcode, higheroffice, queuenumber, public, notes " +
                        "from organisationdetails org join departmentdetail d on d.departmentcode " +
                        " = org.deptcode where org.serialno = " + sn;
                    using(MySqlCommand cmd = new MySqlCommand(query, con))
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
    }
}