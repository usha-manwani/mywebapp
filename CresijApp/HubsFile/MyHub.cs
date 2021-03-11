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
        // string constr = ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        private static List<Users> users = new List<Users>();
        static Dictionary<string, string> keyValues = new Dictionary<string, string>();
        //public void GetUsers()
        //{
        //    DataTable dt;
        //    using (var connection = new MySqlConnection(constr))
        //    {
        //        string query = "SELECT * from dbo.[CentralControl]";
        //        try
        //        {
        //            connection.OpenAsync();
        //            using (MySqlCommand command = new MySqlCommand(query, connection))
        //            {
        //                //command.Notification = null;
        //                dt = new DataTable();
        //                DataSet ds = new DataSet();

        //                //SqlDependency dependency = new SqlDependency(command);
        //                //dependency.OnChange += dependency_OnChange;
        //                if (connection.State == ConnectionState.Closed)
        //                    connection.OpenAsync();
        //                SqlDependency.Start(connection.ConnectionString);
        //                var reader = command.ExecuteReader();
        //                dt.Load(reader);
        //            }
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //        if (dt.Rows.Count > 0)
        //        {
        //            HttpContext.Current.Application.Lock();
        //            HttpContext.Current.Application["ScoreTable"] = dt;
        //            HttpContext.Current.Application.UnLock();
        //        }
        //    }
            
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        //    context.Clients.All.recieveNotification(dt);
        //}
        //void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        //{
        //    if (e.Type == SqlNotificationType.Change)
        //    {
        //        MyHub _dataHub = new MyHub();
        //        _dataHub.GetUsers();
        //    }
        //}
        ///[HubMethodName("sendMessages")]
        ///public static void SendMessages()
        ///{
        ///    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        ///    context.Clients.All.updateMessages();     
        ///}
        ///DataTable ScoresTable = HttpContext.Current.Application["ScoresTable"] as DataTable;
        
        public void Hello()
        {
            
            Clients.All.hello();
        }
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

        
        private void saveStatusinDatebase(string sender, string data)
        {
            
            //CentralControl cc = new CentralControl();
            //cc.SaveDatainDatabase(sender, data);
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
            //int dis;
            Clients.All.RefreshStatus(1);
            //byte[] statusRec = HexEncoding.GetBytes(Message, out dis);
           // Clients.All.broadcastMessage(sender, statusRec);
        }
        ///card status
        //public void updatecardstatus(string ip, string data)
        //{
        //    string[] msg = data.Split(',');
        //    string cardID = msg[2];
        //    PopulateTree tree = new PopulateTree();
        //    tree.updateStatus(ip, cardID);
        //}
        ///card logs
        //public void updateCardLogs(string ip, string data)
        //{
        //    string[] msg = data.Split(',');
        //    string cardID = msg[2];
        //    string newdata = PopulateTree.insertCardLogs(ip, cardID);
        //    if (!string.IsNullOrEmpty(newdata))
        //        Clients.All.logs(newdata);
        //}
        public void CountMachines(int count)
        {
           // Clients.All.TotalCount(count);
            Clients.All.machineCounts(count);
        }
        public void CountTotal()
        {
            Clients.All.Counts(1);
        }
        public void CountMachinesAll(int i)
        {
            Clients.All.CountsMachines(1);
        }

        public void SaveTempData(int d)
        {
            if (keyValues.Count > 0)
            {
                foreach (KeyValuePair<string, string> pair in keyValues)
                {
                    List<string> data = new List<string>();
                    data = pair.Value.Split(',').ToList();
                    Chart chart = new Chart();
                    chart.SaveTempData(pair.Key.ToString(), data);
                }
            }
        }

        public void CountOfMachines(string counts)
        {
            Clients.All.machineCounts(counts);
        }
  
    }
    public class Users
    {
       // public string Name { get; set; }
        public string AuthCookie { get; set; }
        public string ConnectionId { get; set; }
    }
    public class HexEncoding
    {
        public HexEncoding()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static int GetByteCount(string hexString)
        {
            int numHexChars = 0;
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (IsHexDigit(c))
                    numHexChars++;
            }
            // if odd number of characters, discard last character
            if (numHexChars % 2 != 0)
            {
                numHexChars--;
            }
            return numHexChars / 2; // 2 characters per byte
        }
        /// <summary>
        /// Creates a byte array from the hexadecimal string. Each two characters are combined
        /// to create one byte. First two hexadecimal characters become first byte in returned array.
        /// Non-hexadecimal characters are ignored. 
        /// </summary>
        /// <param name="hexString">string to convert to byte array</param>
        /// <param name="discarded">number of characters in string ignored</param>
        /// <returns>byte array, in the same left-to-right order as the hexString</returns>
        public static byte[] GetBytes(string hexString, out int discarded)
        {
            discarded = 0;
            string newString = "";
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (IsHexDigit(c))
                    newString += c;
                else
                    discarded++;
            }
            // if odd number of characters, discard last character
            if (newString.Length % 2 != 0)
            {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }

            int byteLength = newString.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                hex = new string(new char[] { newString[j], newString[j + 1] });
                bytes[i] = HexToByte(hex);
                j = j + 2;
            }
            return bytes;
        }
        public static string ToString(byte[] bytes)
        {
            string hexString = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("X2");
            }
            return hexString;
        }
        /// <summary>
        /// Determines if given string is in proper hexadecimal string format
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static bool InHexFormat(string hexString)
        {
            bool hexFormat = true;

            foreach (char digit in hexString)
            {
                if (!IsHexDigit(digit))
                {
                    hexFormat = false;
                    break;
                }
            }
            return hexFormat;
        }

        /// <summary>
        /// Returns true is c is a hexadecimal digit (A-F, a-f, 0-9)
        /// </summary>
        /// <param name="c">Character to test</param>
        /// <returns>true if hex digit, false if not</returns>
        public static bool IsHexDigit(Char c)
        {
            int numChar;
            int numA = Convert.ToInt32('A');
            int num1 = Convert.ToInt32('0');
            c = Char.ToUpper(c);
            numChar = Convert.ToInt32(c);
            if (numChar >= numA && numChar < (numA + 6))
                return true;
            if (numChar >= num1 && numChar < (num1 + 10))
                return true;
            return false;
        }
        /// <summary>
        /// Converts 1 or 2 character string into equivalant byte value
        /// </summary>
        /// <param name="hex">1 or 2 character string</param>
        /// <returns>byte</returns>
        private static byte HexToByte(string hex)
        {
            if (hex.Length > 2 || hex.Length <= 0)
                throw new ArgumentException("hex must be 1 or 2 characters in length");
            byte newByte = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return newByte;
        }
    }
    
}