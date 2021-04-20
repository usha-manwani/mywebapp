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
    public class TokenValidationHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;
            if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
            {
                return false;
            }
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;
            //determine whether a jwt exists or not
            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                //allow requests with no token - whether a action method needs an authentication can be set with the claimsauthorization attribute
                return base.SendAsync(request, cancellationToken);
            }

            try
            {
                const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));


                SecurityToken securityToken;
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = "http://localhost:50191",
                    ValidIssuer = "http://localhost:50191",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };
                //extract and assign the user of the jwt
                Thread.CurrentPrincipal = handler.ValidateToken(token, validationParameters, out securityToken);
                HttpContext.Current.User = handler.ValidateToken(token, validationParameters, out securityToken);

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException e)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode) { });
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }
    }

    public class SessionHandler
    {
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

        public async Task<int> AddUpdateProjectorConfig(List<int> classids , Dictionary<string,string> data)
        {
            
            using(var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()))
            {

            }
            return 0;
        }
        public async Task<int> RemoveUserSession(string cookie)
        {
            int r = 0;
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()))
            {
                if (context.usersessioninfoes.Any(x => x.SessionId == cookie))
                {
                    var us = context.usersessioninfoes.First(x => x.SessionId == cookie);
                    us.SessionEndTime = DateTime.Now;
                    context.usersessioninfoes.Remove(us);
                }
                r = await context.SaveChangesAsync();
            }
            return r;
        }

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
        public async Task<List<string>> GetMacAddress(List<int>classIds)
        {
            var result = new List<string>();
            using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()))
            {
               result =context.classdetails.Where(x => classIds.Contains(x.classID)).Select(x => x.ccmac).ToList();
               
            }
            return result;
        }

        public async Task<int> AddCamMonitorLogs(string altime,string ip, string msg)
        {
            int result = 0;
            try
            {
                using (var context = new OrganisationdatabaseEntities(HttpContext.Current.Session["DBConnection"].ToString()))
                {
                    var cid = context.classdetails.Where(x => x.camipS == ip || x.camipT == ip).Select(x => x.classID).FirstOrDefault();
                    var monitorobj = new alarmmonitorlog()
                    {
                        almMessage = msg,
                        almTime = Convert.ToDateTime(altime),
                        Classid = cid,
                        deviceip = ip
                    };
                    context.alarmmonitorlogs.Add(monitorobj);
                    result = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}