﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Microsoft.AspNet.SignalR;
using CresijApp.Models;
using Newtonsoft.Json;

namespace CresijApp.Services
{
    /// <summary>
    /// Summary description for CardRegistration
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CardRegistration : System.Web.Services.WebService
    {
        IHubContext hubContext;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int RegisterCard(Dictionary<string, object>data)
        {
            int updatedRows = 0;
            List<int> classids = new List<int>();           
            var cardid = data["cardId"].ToString();
            var teacherId = data["teacherId"].ToString();
            var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
            using (var context = new OrganisationdatabaseEntities(db))
            {
                if (data["classids"].ToString() != "*")
                    classids = ((object[])data["classids"]).Cast<int>().ToList();
                else
                    classids = context.classdetails.Select(x => x.classID).ToList();
                foreach (var c in classids)
                {
                    card_registration cd = new card_registration()
                    {
                        calssId = c, OneCardId = cardid, TeacherId = teacherId,
                        Status = "Pending", UpdateTime = DateTime.Now
                    };
                    if (!context.card_registration.Any(x => x.calssId == c && x.TeacherId == teacherId
                     && x.OneCardId == cardid))
                        context.card_registration.Add(cd);
                    else
                    {
                        var row = context.card_registration.Where(x => x.calssId == c && x.TeacherId == teacherId
                       && x.OneCardId == cardid).Select(x => x).FirstOrDefault();
                        if (row != null)
                            row.Status = "Pending";
                        row.UpdateTime = DateTime.Now;
                    }
                }
                updatedRows = context.SaveChanges();
                var machinemacs = context.classdetails.Where(x => classids.Contains(x.classID))
                    .Select(x => x.ccmac).ToList();
                hubContext = GlobalHost.ConnectionManager.GetHubContext<HubsFile.MyHub>();
                hubContext.Clients.All.RegisterCard(machinemacs, cardid);

            }
            return updatedRows; 
        }

        [WebMethod]
        public int RegisterMultipleCardToClass(Dictionary<string, object> data)
        {
            int updatedRows = 0;
            List<int> classids = new List<int>();
            List<string> teacherIdlist = new List<string>();
            //var classid = data["classid"].ToString();
            var teacherId =  data["teachers"].ToString();
            var dd = new Dictionary<string, string>();
            var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
            using (var context = new OrganisationdatabaseEntities(db))
            {               
                if (data["classids"].ToString() != "*")
                    classids = ((object[])data["classids"]).Cast<int>().ToList();
                else
                    classids = context.classdetails.Select(x => x.classID).ToList();

                if (data["teachers"].ToString() != "*")
                {
                    var json = JsonConvert.SerializeObject(data["teachers"]);
                    var list = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(json);
                    dd = list.ToDictionary(x => (string)x.teacherId, x => ((string)x.cardId).Trim());
                }
                else
                    dd = context.teacherdatas.ToDictionary(x => x.TeacherID, x => x.onecard);
                if(dd.Count>0 && classids.Count > 0)
                {
                    foreach (var c in classids)
                    {
                        foreach(var y in dd)
                        {
                            if (!context.card_registration.Any(x => x.calssId == c && x.TeacherId == y.Key
                                && x.OneCardId == y.Value))
                            {
                                card_registration cd = new card_registration()
                                {
                                    calssId = c,
                                    OneCardId = y.Value,
                                    TeacherId = y.Key,
                                    Status = "Pending",
                                    UpdateTime = DateTime.Now
                                };
                                context.card_registration.Add(cd);
                            }
                            else
                            {
                                var row = context.card_registration.Where(x => x.calssId == c && x.TeacherId == y.Key
                                 && x.OneCardId == y.Value).Select(x => x).FirstOrDefault();
                                row.Status = "Pending";
                                row.UpdateTime = DateTime.Now;
                            }
                        }    
                    }
                    updatedRows = context.SaveChanges();
                    var machinemacs = context.classdetails.Where(x => classids.Contains(x.classID))
                        .Select(x => x.ccmac).ToList();
                    hubContext = GlobalHost.ConnectionManager.GetHubContext<HubsFile.MyHub>();
                    hubContext.Clients.All.RegisterMultipleCard(machinemacs, dd.Values.ToList());
                }
            }
            return updatedRows;
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string,object> CheckCardRegistration(Dictionary<string, object> data)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            bool stat = true;
            List<card_registration> idata = new List<card_registration>();
            List<int> classids = new List<int>();
            List<string> teacherIdlist = new List<string>();
            //var classid = data["classid"].ToString();
            try

            {
                var teacherId = data["teachers"].ToString();
                var dd = new Dictionary<string, string>();
                var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                using (var context = new OrganisationdatabaseEntities(db))
                {
                    
                    if (data["classids"].ToString() != "*")
                        classids = ((object[])data["classids"]).Cast<int>().ToList();
                    else
                        classids = context.classdetails.Select(x => x.classID).ToList();

                    if (data["teachers"].ToString() != "*")
                    {
                        var json = JsonConvert.SerializeObject(data["teachers"]);

                        var list = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(json);
                        dd = list.ToDictionary(x => (string)x.teacherId, x => ((string)x.cardId).Trim());
                    }
                    else
                        dd = context.teacherdatas.ToDictionary(x => x.TeacherID, x => x.onecard);
                    if (dd.Count > 0 && classids.Count > 0)
                    {
                        foreach (var c in classids)
                        {
                            foreach (var y in dd)
                            {
                                if (!context.card_registration.Any(x => x.calssId == c && x.TeacherId == y.Key
                                       && x.OneCardId == y.Value))
                                {
                                    result.Add("stat", false);
                                    return result;
                                }
                                else
                                {
                                    var cdata = context.card_registration.Where(x => x.calssId == c && x.TeacherId == y.Key
                                         && x.OneCardId == y.Value).FirstOrDefault();
                                    if (cdata.Status == "Pending")
                                    {
                                        stat = false;
                                        result.Add("stat", stat);
                                        return result;
                                    }

                                }

                            }
                        }
                    }
                    else
                    {
                        result.Add("stat", false);
                        return result;
                    }
                }
                result.Add("stat", true);
            }
           catch(Exception ex)
            {
                result.Add("status", "fail");
                result.Add("Error", ex.Message);
            }
            return result;
        }

        [WebMethod(EnableSession = true)]
        public Dictionary<string, object> GetCardLogsList(Dictionary<string, string> data)
        {
            var result = new Dictionary<string, object>();
            if (HttpContext.Current.Session["UserLoggedIn"] == null || HttpContext.Current.Session.Count == 0)
            {
                HttpContext.Current.Session.Abandon();
                result.Add("status", "fail");
                result.Add("errorMessage", "Session Expired");
                result.Add("customErrorCode", "440");
            }
            else
            {
                result.Add("status", "success");
                var pageSize = Convert.ToInt32(data["pageSize"]);
                var pageIndex = Convert.ToInt32(data["pageIndex"]);
                var db = HttpContext.Current.Session["DBConnection"].ToString() + "Entities";
                var logslistobj = new List<CardLogsList>();
                using (var context = new OrganisationdatabaseEntities(db))
                {
                    logslistobj = (from c2 in context.cardlogs
                                    join c1 in context.teacherdatas
                               on c2.cardId equals  c1.onecard into sub
                                   from x in sub.DefaultIfEmpty()
                                   join c3 in context.classdetails on c2.ClassId
                                       equals c3.classID into sub1 from y in sub1.DefaultIfEmpty()
                                   select new CardLogsList
                                   {
                                       CardID = c2.cardId,
                                       TeacherName = x.TeacherName??"",
                                       ClassName = y.ClassName??"",
                                       Message = c2.Message,
                                       ActionTime = c2.ActionTime.ToString()
                                   }).OrderByDescending(x=>x.ActionTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();


                    var count = (from c1 in context.teacherdatas
                                   join c2 in context.cardlogs
                               on c1.onecard equals c2.cardId
                                   join c3 in context.classdetails on c2.ClassId
                                       equals c3.classID
                                 select new
                                       {
                                           CardID = c2.cardId
                                       }).Count();
                    result.Add("TotalRows", count);
                }
                result.Add("value", logslistobj);
            }
            return result;
        }

        //[WebMethod]
        //public Dictionary<string,object> GetCardLogs(Dictionary<string,string> data)
        //{
        //    using(var context = new OrganisationdatabaseEntities())
        //    {
        //        var pageIndex = Convert.ToInt32(data["pageIndex"]);
        //        var pageSize = Convert.ToInt32(data["pageSize"]);
        //    }
        //}

    }
    public class CardLogsList
    {
        public string CardID { get; set; }
        public string TeacherName { get; set; }
        public string ClassName { get; set; }
        public string Message { get; set; }
        public string ActionTime { get; set; }
    }
}
