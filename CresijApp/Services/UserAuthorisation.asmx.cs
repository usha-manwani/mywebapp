using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for UserAuthorisation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class UserAuthorisation : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<object> GetUserAuthentications()
        {
            List<object> idata = new List<object>();
            return idata;
        }

        [WebMethod]
        public int SaveUserAuthentications(string[] name)
        {
            string[] authmenu = name[0].Split(',');
            string[] authloc = name[1].Split(',');
            var adminid = name[2];
            var userid = name[3];
            DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
            userAuth.DeleteUserPermissions(userid);
           int result = userAuth.SaveAuthMenu(authmenu, userid,adminid, authloc);

            return result;
        }

        [WebMethod]
        public List<object> GetUserTopMenu(string userid)
        {
            List<object> idata = new List<object>();

            DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
            DataTable dt =new DataTable();
            dt= userAuth.GetUserTopMenu(userid);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetUserSubMenu(string[] data)
        {
            List<object> idata = new List<object>();

            DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
            DataTable dt = new DataTable();
            dt = userAuth.GetUserSubMenu(data);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetUserAllSubMenu(string data)
        {
            List<object> idata = new List<object>();

            DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
            DataTable dt = new DataTable();
            dt = userAuth.GetUserAllSubMenu(data);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            }
            return idata;
        }

        [WebMethod]
        public List<object> GetUserAllLocationAccess(string data)
        {
            List<object> idata = new List<object>();

            DataAccess.UserAuth userAuth = new DataAccess.UserAuth();
            DataTable dt = new DataTable();
            dt = userAuth.GetUserAllLocationAccess(data);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    idata.Add(dr.ItemArray);
                }
            }
            return idata;
        }

    }
}
