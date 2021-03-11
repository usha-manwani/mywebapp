using System;
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
            using (var context = new OrganisationdatabaseEntities())
            {
                if (data["classids"].ToString() != "*")
                    classids = ((object[])data["classids"]).Cast<int>().ToList();
                else
                    classids = context.classdetails.Select(x => x.classID).ToList();
                foreach (var c in classids)
                {
                    card_registration cd = new card_registration()
                    {
                        calssId = c, OneCardId=cardid, TeacherId=teacherId,
                        Status="Pending"
                    };
                    if (!context.card_registration.Any(x => x.calssId == c && x.TeacherId == teacherId
                     && x.OneCardId == cardid))
                        context.card_registration.Add(cd);                    
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
            using (var context = new OrganisationdatabaseEntities())
            {               
                if (data["classids"].ToString() != "*")
                    classids = ((object[])data["classids"]).Cast<int>().ToList();
                else
                    classids = context.classdetails.Select(x => x.classID).ToList();

                if (data["teachers"].ToString() != "*")
                {
                    var json = JsonConvert.SerializeObject(data["teachers"]);
                    var list = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(json);
                    dd = list.ToDictionary(x => (string)x.teacherId, x => (string)x.cardId);
                }
                else
                    dd = context.teacherdatas.ToDictionary(x => x.TeacherID, x => x.onecard);
                if(dd.Count>0 && classids.Count > 0)
                {
                    foreach (var c in classids)
                    {
                        foreach(var y in dd)
                        {
                            card_registration cd = new card_registration()
                            {
                                calssId = c,
                                OneCardId = y.Value,
                                TeacherId = y.Key,
                                Status = "Pending"
                            };
                            if (!context.card_registration.Any(x => x.calssId == c && x.TeacherId == y.Key
                                && x.OneCardId == y.Value))
                                context.card_registration.Add(cd);
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
            
                var teacherId = data["teachers"].ToString();
                var dd = new Dictionary<string, string>();
                using (var context = new OrganisationdatabaseEntities())
                {

                    if (data["classids"].ToString() != "*")
                        classids = ((object[])data["classids"]).Cast<int>().ToList();
                    else
                        classids = context.classdetails.Select(x => x.classID).ToList();

                    if (data["teachers"].ToString() != "*")
                    {
                        var json = JsonConvert.SerializeObject(data["teachers"]);

                        var list = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(json);
                        dd = list.ToDictionary(x => (string)x.teacherId, x => (string)x.cardId);

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
            return result;
        }

    }
}
