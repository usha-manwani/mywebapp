using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CresijApp.DataAccess;
using System.Web.Script.Serialization;

namespace CresijApp.HubsFile
{
    public class MyHub :Hub
    {
        
        private static List<Users> users = new List<Users>();
        static Dictionary<string, string> keyValues = new Dictionary<string, string>();
       
        public async override Task OnConnected()
        {
            await base.OnConnected();
            //if(Context.User)
            //var name =Context.User.Identity.Name;
            var connectionID = Context.ConnectionId;
            if (!users.Any(x => x.ConnectionId == connectionID))
            {
                users.Add(new Users {ConnectionId=connectionID });
                
            }
           // SendData();

        }
        public override async Task OnDisconnected(bool stopCalled)
        {
            if (users.Any(x => x.ConnectionId== Context.ConnectionId))
            {
                Users disconnectedUser = users.First(x => x.ConnectionId == Context.ConnectionId);
                var cookie = disconnectedUser.AuthCookie;
                users.Remove(disconnectedUser);
                SessionHandler ss = new SessionHandler();
                //await ss.RemoveUserSession(disconnectedUser.AuthCookie);
                //await ss.AddOperationLogs(cookie, "Logout");
            }
            await base.OnDisconnected(stopCalled);
        }
        ///show status of all machines
       
        public void SendMessage(string sender, string data1)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();            
            dynamic DatatoSend = js.Deserialize<dynamic>(data1);
            
            if (DatatoSend["Log"] == "SystemOn")
            {
                TriggerAlarm(sender, "TriggerOn");
            }
            else if (DatatoSend["Log"] == "SystemOff")
            {
                TriggerAlarm(sender, "TriggerOff");
            }
            Clients.All.broadcastMessage(sender, DatatoSend);
           // Clients.All.envMessage(sender, data1);
        }
        public void ReceiveDesktopEvent(string sender, string data1)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, string> DatatoSend = js.Deserialize<Dictionary<string, string>>(data1);
            Clients.All.desktopEvent(sender, DatatoSend);
        }
        public void ReceiveMachineException(string sender, string data1)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, string> DatatoSend = js.Deserialize<Dictionary<string, string>>(data1);
            Clients.All.machineException(sender, DatatoSend);
        }
        public async Task SetProjectorConfig(List<int> classIds, Dictionary<string, string> data, string cookies)
        {
            var id = Context.ConnectionId;
            SessionHandler ss = new SessionHandler();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var cook = js.Deserialize<Dictionary<string, string>>(cookies);
            var macaddress =await ss.GetMacAddress(classIds);
            await Clients.All.SetProjectorConfiguration(macaddress, data);
            if (users.Any(x => x.ConnectionId == id))
            {
                var us = users.Where(x => x.ConnectionId == id).FirstOrDefault();
                us.AuthCookie = cook["AuthCookie"];
            }
            int r1 = await ss.AddUpdateConnectionID(cook["AuthCookie"], id);
            foreach(var m in macaddress)
            {
                int r = await ss.AddOperationLogs(cook["AuthCookie"], "SetProjectorConfig", m);
            }            
        }
        //public async Task SetProjectorConfig1(List<int> classIds, Dictionary<string, string> data, string cookies)
        //{
        //    var id = Context.ConnectionId;
        //    SessionHandler ss = new SessionHandler();
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    var cook = js.Deserialize<Dictionary<string, string>>(cookies);
        //    var macaddress = await ss.GetMacAddress(classIds);
        //    await Clients.All.SetProjectorConfiguration1(macaddress, data);
        //    if (users.Any(x => x.ConnectionId == id))
        //    {
        //        var us = users.Where(x => x.ConnectionId == id).FirstOrDefault();
        //        us.AuthCookie = cook["AuthCookie"];
        //    }
        //    int r1 = await ss.AddUpdateConnectionID(cook["AuthCookie"], id);
        //    foreach (var m in macaddress)
        //    {
        //        int r = await ss.AddOperationLogs(cook["AuthCookie"], "SetProjectorConfig", m);
        //    }
        //}
        public async Task GetProjectorConfig(int classId, string code, string cookies)
        {
            var id = Context.ConnectionId;
            JavaScriptSerializer js = new JavaScriptSerializer();
            var cook = js.Deserialize<Dictionary<string, string>>(cookies);
            SessionHandler ss = new SessionHandler();
            var machine = await ss.GetMacAddress(new List<int>() { classId });
            int val = 0;
            await Clients.All.SendControl(machine.FirstOrDefault(), code, val);
            if (users.Any(x => x.ConnectionId == id))
            {
                var us = users.Where(x => x.ConnectionId == id).FirstOrDefault();
                us.AuthCookie = cook["AuthCookie"];
            }
            int r1 = await ss.AddUpdateConnectionID(cook["AuthCookie"], id);
            int r = await ss.AddOperationLogs(cook["AuthCookie"], "ReadProjectorConfig", machine.FirstOrDefault());
        }
        
        public async Task AlarmMessage(string alm)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, string> DatatoSend = js.Deserialize<Dictionary<string, string>>(alm);
            //SessionHandler ss = new SessionHandler();
            //await ss.AddCamMonitorLogs(DatatoSend["AlarmTime"].ToString(), 
            //    DatatoSend["DeviceIp"].ToString(), 
            //    DatatoSend["AlarmMsg"].ToString());
            await Clients.All.messageAlarmMotion(DatatoSend);
        }
        public void TriggerAlarm(string sender,string data)
        {
           Clients.All.AlarmEvent(sender, data);
        }
        ///send to server to get status of all machines
        public void SendData()
        {
            Clients.All.SendToMachine(1);
        }
        ///check status of a selected ip
        public void CheckStatus(string ip)
        {
            Clients.All.RefreshStatus(ip);
        }
        ///send ip and data to console server
        public async Task SendControlKeys(string machine, string code, string cookies)
        {
            int val = 0;
            var id = Context.ConnectionId;
            SessionHandler ss = new SessionHandler();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var cook = js.Deserialize<Dictionary<string,string>>(cookies);
            if (cook.ContainsKey("value"))
            {
                val = Convert.ToInt32(cook["value"]);
            }
            await Clients.All.SendControl(machine, code,val);
            if (users.Any(x => x.ConnectionId == id))
            {
                var us = users.Where(x => x.ConnectionId == id).FirstOrDefault();
                us.AuthCookie = cook["AuthCookie"];
            }
            int r1 = await ss.AddUpdateConnectionID(cook["AuthCookie"], id);
            int r = await ss.AddOperationLogs(cook["AuthCookie"], code,machine);
        }
        public void GetStatus()
        {
          
            Clients.All.RefreshStatus(1);
            
        }
       
        public void CountMachines(int count)
        {           
            Clients.All.machineCounts(count);
        }
        
        public void CountMachinesAll(int i)
        {
            Clients.All.CountsMachines(1);
        }
    }
    public class Users
    {
       // public string Name { get; set; }
        public string AuthCookie { get; set; }
        public string ConnectionId { get; set; }
    }
    
    
}