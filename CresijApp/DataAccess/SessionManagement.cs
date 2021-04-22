// ***********************************************************************
// Assembly         : CresijApp
// Author           : admin
// Created          : 08-10-2020
//
// Last Modified By : admin
// Last Modified On : 04-20-2021
// ***********************************************************************
// <copyright file="SessionManagement.cs" company="Microsoft">
//     Copyright © Microsoft 2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CresijApp.Models;
namespace CresijApp.DataAccess
{

    /// <summary>
    /// Class SessionHandler.
    /// </summary>
    public class SessionHandler
    {
        /// <summary>
        /// this method is called from MyHub.cs to store the client connection id with cookie
        /// in database for future purposes
        /// can be deleted if not needed anymore
        /// </summary>
        /// <param name="cookie">The cookie.</param>
        /// <param name="connectionid">The connectionid.</param>
        /// <returns>no. of rows inserted</returns>
        public async Task<int> AddUpdateConnectionID(string cookie,string connectionid)
        {
            int r = 0;
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()))
            {
                if (context.usersessioninfoes.Any(x => x.SessionId == cookie))
                {
                    var us = context.usersessioninfoes.First(x => x.SessionId == cookie);
                    us.SocketConnectionID = connectionid;
                }                
               r= await context.SaveChangesAsync();
            }
            return r;
        }

        /// <summary>
        /// this method is called from MyHub.cs to insert the logs in userlogs table
        /// </summary>
        /// <param name="cookie">The cookie.</param>
        /// <param name="message">The message.</param>
        /// <param name="machinemac">The machinemac.</param>
        /// <returns>no of rows inserted</returns>
        public async Task<int> AddOperationLogs(string cookie, string message,string machinemac)
        {
            if (message.Contains("Web"))
            {
               message= message.Replace("Web", "");
            }
            int r = 0;
            using(var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()))
            {
                if (context.usersessioninfoes.Any(x => x.SessionId == cookie))
                {
                    var us = context.usersessioninfoes.First(x => x.SessionId == cookie);
                    var userid = us.LoginID;
                    if (userid != null)
                    {
                        int? userserialnum = context.userdetails.Where(x => x.LoginID == userid).Select(x => x.SerialNo).FirstOrDefault();
                        int classid = context.classdetails.Where(x => x.ccmac == machinemac).Select(x => x.classID).FirstOrDefault();
                        if (userserialnum!=0 || userserialnum!=null)
                        {
                            userlog uslog = new userlog()
                            {
                                action = message,
                                Userid = userserialnum,
                                ActionTime = DateTime.Now,
                                ClassID = classid
                            };
                            context.userlogs.Add(uslog);
                        }
                    }
                }
               r= await context.SaveChangesAsync();
            }
            return r;
        }
        /// <summary>
        /// This method is called from MyHub.cs and use to get the mac address of machines by their classids
        /// </summary>
        /// <param name="classIds">The class ids.</param>
        /// <returns>list of mac addresses of machines</returns>
        public async Task<List<string>> GetMacAddress(List<int>classIds)
        {
            var result = new List<string>();
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()))
            {
               result =context.classdetails.Where(x => classIds.Contains(x.classID)).Select(x => x.ccmac).ToList(); 
            }
            return result;
        }       
    }
}