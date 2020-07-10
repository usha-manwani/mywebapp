using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using CresijApp.DataAccess;
namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for GetOrganisationData
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class GetOrganisationData : WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<object> GetOrgDataBuilding()
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = new DataTable();
            dt = gd.GetOrgBuildingInfo();
           
            foreach (DataRow row in dt.Rows)
            {
                idata.Add(row.ItemArray);
            }
            
            return idata;

        }

        [WebMethod]
        public List<object> GetStudentData()
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = new DataTable();
            dt = gd.GetStudentInfo();

            List<string> studentid = new List<string>();
            List<string> studentname = new List<string>();
            List<string> gender = new List<string>();
            List<string> deptcode = new List<string>();
            List<string> phone = new List<string>();
            List<int> age = new List<int>();
            List<string> idcard = new List<string>();
            List<string> onecard = new List<string>();
            foreach (DataRow row in dt.Rows)
            {

                studentid.Add(row[0].ToString());
                studentname.Add(row[1].ToString());
                gender.Add(row[2].ToString());
                age.Add(Convert.ToInt32(row[3]));
                deptcode.Add(row[4].ToString());
                phone.Add(row[5].ToString());
                idcard.Add(row[6].ToString());
                onecard.Add(row[7].ToString());
            }

            idata.Add(studentid);
            idata.Add(studentname);
            idata.Add(gender);
            idata.Add(age);
            idata.Add(deptcode);
            idata.Add(phone);
            idata.Add(idcard);
            idata.Add(onecard);
            return idata;

        }

        [WebMethod]
        public List<object> GetTeacherData()
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = new DataTable();
            dt = gd.GetTeacherInfo();

            List<string> teacherid = new List<string>();
            List<string> teachername = new List<string>();
            List<string> gender = new List<string>();
            List<string> faculty = new List<string>();
            List<string> phone = new List<string>();
            List<int> age = new List<int>();
            List<string> idcard = new List<string>();
            List<string> onecard = new List<string>();
            foreach (DataRow row in dt.Rows)
            {

                teacherid.Add(row[0].ToString());
                teachername.Add(row[1].ToString());
                gender.Add(row[2].ToString());
                age.Add(Convert.ToInt32(row[3]));
                faculty.Add(row[4].ToString());
                phone.Add(row[5].ToString());
                idcard.Add(row[6].ToString());
                onecard.Add(row[7].ToString());
            }

            idata.Add(teacherid);
            idata.Add(teachername);
            idata.Add(gender);
            idata.Add(age);
            idata.Add(faculty);
            idata.Add(phone);
            idata.Add(idcard);
            idata.Add(onecard);
            return idata;

        }
        [WebMethod]
        public List<object> GetUserData()
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = new DataTable();
            dt = gd.GetuserInfo();
            List<int> sno = new List<int>();
            List<string> loginid = new List<string>();
            List<string> username = new List<string>();
            List<string> persontype = new List<string>();
            List<string> deptname = new List<string>();
            List<string> personalstatus = new List<string>();
            List<string> telephone = new List<string>();
            List<string> notes = new List<string>();

            foreach (DataRow row in dt.Rows)
            {
                sno.Add(Convert.ToInt32(row[0]));
                loginid.Add(row[1].ToString());
                username.Add(row[2].ToString());
                persontype.Add(row[3].ToString());
               
                deptname.Add(row[4].ToString());
                personalstatus.Add(row[5].ToString());
                telephone.Add(row[6].ToString());
                notes.Add(row[7].ToString());

            }
            idata.Add(sno);
            idata.Add(loginid);
            idata.Add(username);
            idata.Add(persontype);
           
            idata.Add(deptname);
            idata.Add(personalstatus);
            idata.Add(telephone);
            idata.Add(notes);

            return idata;

        }

        [WebMethod]
        public List<object> GetUserOnDemand(string name)
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = gd.GetUserDataonDemand(name);
            idata.Add(dt.Rows[0].ItemArray);
            return idata;

        }
        public class ClassDetails{
            public string Classid { get; set; }
            public string Classname { get; set; }
            public string Building { get; set; }
            public string Floor { get; set; }
            public string Seat { get; set; }
            public string Ccip { get; set; }
            public string CamipS { get; set; }
            public string CamipN { get; set; }
            public string DesktopIp { get; set; }
            public string RecorderIp { get; set; }
            public string CCmac { get; set; }
            public string CCPort { get; set; }
            public string CCuserid { get; set; }
            public string CCpass { get; set; }
            public string CamSmac { get; set; }
            public string CamSPort { get; set; }
            public string CamSuserid { get; set; }
            public string CamSpass { get; set; }
            public string CamNmac { get; set; }
            public string CamNPort { get; set; }
            public string CamNuserid { get; set; }
            public string CamNpass { get; set; }
            public string Deskmac { get; set; }
            public string DeskPort { get; set; }
            public string Deskuserid { get; set; }
            public string Deskpass { get; set; }
            public string Recordermac { get; set; }
            public string RecorderPort { get; set; }
            public string Recorderuserid { get; set; }
            public string Recorderpass { get; set; }
            public string CallHelp { get; set; }
        }
        public class DeviceDetails
        {
            public string Ip { get; set; }
            public string Mac { get; set; }
            public string Port { get; set; }
            public string Userid { get; set; }
            public string Pass { get; set; }
        }

        [WebMethod]
        public List<object> GetClassData()
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = new DataTable();
            dt = gd.GetClassroomInfo();
            foreach (DataRow dr in dt.Rows)
                idata.Add(dr.ItemArray);
            dt.Clear();
            //dt = gd.GetDevicesInfo();
           
            //List<string> pass = new List<string>();
            //List<DeviceDetails> devicedata = new List<DeviceDetails>();
            //devicedata = (from DataRow dr in dt.Rows
            //              select new DeviceDetails() {
            //                  Ip = dr[0].ToString(),
            //                  Mac = dr[1].ToString(),
            //                  Port = dr[2].ToString(),
            //                  Userid =dr[3].ToString(),
            //                  Pass = dr[4].ToString()
            //              }).ToList();           
            

            
            return idata;
        }

        [WebMethod]
        public List<Opedata> GetOpedata()
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = new DataTable();
            dt = gd.GetCapitalInfo();
            List<Opedata> opeList = new List<Opedata>();
            opeList = (from DataRow dr in dt.Rows
                       select new Opedata()
                       {
                           Sno = Convert.ToInt32(dr[0]),
                           Devicename = dr[1].ToString(),
                           Assetno = dr[2].ToString(),
                           Model = dr[3].ToString(),
                           Spec = dr[4].ToString(),
                           Devicetype = dr[5].ToString(),
                           Price = dr[6].ToString(),
                           Factory = dr[7].ToString(),
                           Mfd =  dr[8].ToString(),
                           Dopurchase = dr[9].ToString(),
                           Dod = dr[10].ToString(),
                           Warrantytime = dr[11].ToString(),
                           Locationtype = dr[12].ToString(),
                           EquipStat = dr[13].ToString()
                       }).ToList();
            return opeList;
        }

        public class Opedata
        {
            public int Sno {get ; set; }
            public string Devicename { get; set; }
            public string Assetno { get; set; }
            public string Model { get; set; }
            public string Spec { get; set; }
            public string Devicetype { get; set; }
            public string Price { get; set; }
            public string Factory { get; set; }
            public string Mfd { get; set; }
            public string Dopurchase { get; set; }
            public string Dod { get; set; }
            public string Warrantytime { get; set; }
            public string Locationtype { get; set; }
            public string EquipStat { get; set; }
        }

        [WebMethod]
        public List<object> GetOrgOnDemand(string name)
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt =gd.GetOrgDataonDemand(Convert.ToInt32(name));
            idata.Add(dt.Rows[0].ItemArray);
            return idata;
        }

        [WebMethod]
        public List<object> GetIPClassByBuilding(string data)
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = gd.GetIPClassByBuilding(data);
            if(dt.Rows.Count>0)
            foreach(DataRow dr in dt.Rows)
            {
                idata.Add(dr.ItemArray);
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetIPClassByBuildingFloor(string[] data)
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = gd.GetIPClassByBuildingFloor(data[0],data[1]);
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            return idata;
        }

        [WebMethod]
        public List<object> GetClassDataOnId(string classData)
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = gd.GetClassData(classData);
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            return idata;
        }
        [WebMethod]
        public List<object> GetFloorlist(string building)
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = gd.GetFloorlist(building);
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            return idata;
        }

        [WebMethod]
        public List<object> GetSchoolName(string building)
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = gd.GetSchoolName(building);
            if (dt.Rows.Count > 0)
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            return idata;
        }

        [WebMethod]
        public List<object> GetClassByIP(string data)
        {
            List<object> idata = new List<object>();
            GetOrgData gd = new GetOrgData();
            DataTable dt = gd.GetClassByIP(data);
            idata.Add(dt.Rows[0].ItemArray);
            return idata;
        }
    }
}
