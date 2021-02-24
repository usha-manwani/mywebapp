using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Microsoft.AspNet.SignalR;
using CresijApp.Models;

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
    }
}
