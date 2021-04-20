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
       /// <summary>
       /// this method belongs to signalR
       /// whenever there is a new connection this method is called
       /// this method is being used to maintain the list of connected clients
       /// </summary>
       /// <returns></returns>
        public async override Task OnConnected()
        {
            await base.OnConnected();            
            var connectionID = Context.ConnectionId;
            if (!users.Any(x => x.ConnectionId == connectionID))
            {
                users.Add(new Users {ConnectionId=connectionID });
                
            }
        }
        /// <summary>
        /// this method belongs to signalR
        /// whenever a connection is destroyed this method is called
        /// /// this method is being used to maintain the list of connected clients
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override async Task OnDisconnected(bool stopCalled)
        {
            if (users.Any(x => x.ConnectionId== Context.ConnectionId))
            {
                Users disconnectedUser = users.First(x => x.ConnectionId == Context.ConnectionId);
                var cookie = disconnectedUser.AuthCookie;
                users.Remove(disconnectedUser);
                SessionHandler ss = new SessionHandler();
                //await ss.RemoveUserSession(disconnectedUser.AuthCookie);
                
            }
            await base.OnDisconnected(stopCalled);
        }
        /// <summary>
        /// This method is use to receive most messages from tcp server.
        /// </summary>
        /// <param name="sender">mac address of machine</param>
        /// <param name="data1">is the list of dictionary items</param>
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
            ///this lies in web client and is use to get messages came from machines
            Clients.All.broadcastMessage(sender, DatatoSend);
           
        }
        /// <summary>
        /// This method lies in the tcp server and is use to get the desktop events
        /// desktop events contains type of events: keyboard event and mouse events
        /// </summary>
        /// <param name="sender">desktop mac address</param>
        /// <param name="data1">dictionary item</param>
        public void ReceiveDesktopEvent(string sender, string data1)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, string> DatatoSend = js.Deserialize<Dictionary<string, string>>(data1);
            Clients.All.desktopEvent(sender, DatatoSend);
        }
        /// <summary>
        /// THis method lies in the tcp server.
        /// This method receives the error code regarding machines instructions
        /// Error code generates when machine sending different response than the expected
        /// </summary>
        /// <param name="sender">Here sender is the classid</param>
        /// <param name="data1">data contains the errorcode</param>
        public void ReceiveMachineException(string sender, string data1)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, string> DatatoSend = js.Deserialize<Dictionary<string, string>>(data1);
            Clients.All.machineException(sender, DatatoSend);
        }
        /// <summary>
        /// This method is called from web client to send the instruction related to machine's basic settings
        /// </summary>
        /// <param name="classIds">list of classids</param>
        /// <param name="data">list of data times</param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public async Task SetProjectorConfig(List<int> classIds, Dictionary<string, string> data, string cookies)
        {
            var id = Context.ConnectionId;
            SessionHandler ss = new SessionHandler();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var cook = js.Deserialize<Dictionary<string, string>>(cookies);
            var macaddress =await ss.GetMacAddress(classIds);
            ///this method lies in the tcp server and is use to send instruction to given machines
            await Clients.All.SetProjectorConfiguration(macaddress, data);
            if (users.Any(x => x.ConnectionId == id))
            {
                var us = users.Where(x => x.ConnectionId == id).FirstOrDefault();
                us.AuthCookie = cook["AuthCookie"];
            }
            int r1 = await ss.AddUpdateConnectionID(cook["AuthCookie"], id);
            foreach(var m in macaddress)
            {
                ///this method adds user logs in database
                int r = await ss.AddOperationLogs(cook["AuthCookie"], "SetProjectorConfig", m);
            }            
        }
       
        /// <summary>
        /// this method is called from web client to get the system and projector config from machine
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="code">instruction code</param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public async Task GetProjectorConfig(int classId, string code, string cookies)
        {
            var id = Context.ConnectionId;
            JavaScriptSerializer js = new JavaScriptSerializer();
            var cook = js.Deserialize<Dictionary<string, string>>(cookies);
            SessionHandler ss = new SessionHandler();
            var machine = await ss.GetMacAddress(new List<int>() { classId });
            int val = 0;
            ///this methods is in the tcp server and is use to send instruction to machine
            await Clients.All.SendControl(machine.FirstOrDefault(), code, val);
            if (users.Any(x => x.ConnectionId == id))
            {
                var us = users.Where(x => x.ConnectionId == id).FirstOrDefault();
                us.AuthCookie = cook["AuthCookie"];
            }
            int r1 = await ss.AddUpdateConnectionID(cook["AuthCookie"], id);
            ///this method is use to add userlogs in database
            int r = await ss.AddOperationLogs(cook["AuthCookie"], "ReadProjectorConfig", machine.FirstOrDefault());
        }

        /// <summary>
        /// this method lies inside "AlarmTrigger" application
        /// receives data with the alarm message.
        /// </summary>
        /// <param name="alm"></param>
        /// <returns></returns>
        public async Task AlarmMessage(string alm)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Dictionary<string, string> DatatoSend = js.Deserialize<Dictionary<string, string>>(alm);
            ///message is being sent to web client
            await Clients.All.messageAlarmMotion(DatatoSend);
        }
        /// <summary>
        /// THis method is called to start/shutdown the trigger 
        /// in a camera on the basis of the machine start and shutdown in that specific class
        /// </summary>
        /// <param name="sender">mac address of the machine in a particular class</param>
        /// <param name="data"> has the value as "TriggerOn" or "TriggerOff"</param>
        public void TriggerAlarm(string sender,string data)
        {
            /// This method sends instruction to "AlarmTrigger" Client to on/off the trigger of a specific camera.
            /// Client application finds the camera ip from database through machine mac address that is
            /// passed from here
            Clients.All.AlarmEvent(sender, data);
        }
        
        /// <summary>
        /// this method is called from web client to sent the status instruction to the 
        /// selected machine
        /// </summary>
        /// <param name="ip">here ip means the mac address of machine</param>
        public void CheckStatus(string ip)
        {
            ///RefreshStatus() method lies in the tcp server which tells it to send
            ///status instruction to every connected machine.
            ///ip here is machine mac address
            Clients.All.RefreshStatus(ip);
        }
        /// <summary>
        /// this method is the method which sends different data instructions to tcp server 
        /// to forward it to machine connected
        /// This method also calls the method to adds logs to userlogs table
        /// This method can be used to manage session but its not in use anywhere else.
        /// </summary>
        /// <param name="machine">machine is the machine mac address</param>
        /// <param name="code">this is a string keyword pre-determined in the tcp server application</param>
        /// <param name="cookies"></param>
        /// <returns></returns>
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
        /// <summary>
        /// this method is called from web client to sent the status instruction to all the connected machines
        /// </summary>
        public void GetStatus()
        {
          ///RefreshStatus() method lies in the tcp server which tells it to send
          ///status instruction to every connected machine
            Clients.All.RefreshStatus(1);
            
        }
       
        /// <summary>
        /// this is method is called from tcp server to send the total count of machines connected
        /// </summary>
        /// <param name="count"></param>
        public void CountMachines(int count)
        {     ///this method lies in the web client and provides the total count of connected machines      
            Clients.All.machineCounts(count);
        }
        /// <summary>
        /// This method is called from web client to get the count of all the machines
        /// connected to tcp server
        /// </summary>
        /// <param name="i">i is nothing but "1". i is used just because some parameter is needed.
        /// but its of no use other than that</param>
        public void CountMachinesAll(int i)
        {
            ///This method lies in the tcp server which tells to get the count of all the machines
            /// connected
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