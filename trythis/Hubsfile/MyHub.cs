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

namespace WebCresij.Hubsfile
{  
    [HubName("myHub")]
    public class MyHub : Hub
    {
        static Dictionary<string, string> keyValues = new Dictionary<string, string>();        
        public void GetUsers()
        {
            DataTable dt;
            using (var connection = new MySqlConnection(constr))
            {
                string query = "SELECT * from dbo.[CentralControl]";
                try
                {
                    connection.OpenAsync();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        //command.Notification = null;
                        dt = new DataTable();
                        DataSet ds = new DataSet();
                        
                        //SqlDependency dependency = new SqlDependency(command);
                        //dependency.OnChange += dependency_OnChange;
                        if (connection.State == ConnectionState.Closed)
                            connection.OpenAsync();
                        SqlDependency.Start(connection.ConnectionString);
                        var reader = command.ExecuteReader();
                        dt.Load(reader);
                    }
                }
                finally
                {
                    connection.Close();
                }
                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Application.Lock();
                    HttpContext.Current.Application["ScoreTable"] = dt;
                    HttpContext.Current.Application.UnLock();
                }
            }
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.All.recieveNotification(dt);
        }
        void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                MyHub _dataHub = new MyHub();
                _dataHub.GetUsers();
            }
        }
        ///[HubMethodName("sendMessages")]
        ///public static void SendMessages()
        ///{
        ///    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        ///    context.Clients.All.updateMessages();     
        ///}
        ///DataTable ScoresTable = HttpContext.Current.Application["ScoresTable"] as DataTable;
        string constr = ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        public void Hello()
        {
            Clients.All.hello();
        }
        public async override Task OnConnected()
        {
            await base.OnConnected();
            SendData();
           
        }
        ///show status of all machines
        public void SendMessage(string sender, string data)  
        {
            Console.WriteLine("received data from " + sender);
            if (data.Contains("Temp"))
            {
                if (keyValues.ContainsKey(sender))
                {
                    keyValues[sender] = data;
                }
                else
                {
                    keyValues.Add(sender, data);
                }
            }            
            if (data.Contains("Toregister"))
            {
                Clients.All.registerCard(sender, data);
            }
            if (data.Contains("registered"))
            {
                updatecardstatus(sender,data);
               // Clients.All.confirmRegister();
            }
            else if (data.Contains("readerlog"))
            {
                updateCardLogs(sender,data);
                Clients.All.SendControl(sender, "8B B9 00 04 01 0B C4 D4");
            }
            else if (data.Contains("KeyValue"))
            {
               // string query = "";
                string[] values = data.Split(',');
                switch (values[2])
                {
                    case "SystemON":
                        //query = "Insert into ";
                        break;
                }
            }
            else if (data.Contains("Heartbeat"))
            {
                saveStatusinDatebase(sender, data);
            }
            Clients.All.broadcastMessage(sender, data);
        }

        private void saveStatusinDatebase(string sender, string data)
        {
            CentralControl cc = new CentralControl();
            cc.SaveDatainDatabase(sender, data);
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
        public void SendControlKeys(string machine, string code)
        {
            Clients.All.SendControl(machine, code);
        }
        public void GetStatus(string sender, string Message )
        {
            int dis;
            byte[] statusRec=  HexEncoding.GetBytes(Message, out dis);
            Clients.All.broadcastMessage(sender, statusRec);
        }
        ///card status
        public void updatecardstatus(string ip,string data)
        {
            string[] msg=  data.Split(',');
            string cardID = msg[2];            
            PopulateTree tree = new PopulateTree();
            tree.updateStatus(ip, cardID);
        }
        ///card logs
        public void updateCardLogs(string ip, string data)
        {
            string[] msg = data.Split(',');
            string cardID = msg[2];
            string newdata = PopulateTree.insertCardLogs(ip, cardID);
            if(!string.IsNullOrEmpty(newdata))
            Clients.All.logs(newdata);
        }
        public void CountMachines(int count)
        {
            Clients.All.TotalCount(count);
        }
        public void CountTotal()
        {
            Clients.All.Counts(1);
        }
        public void SaveTempData(int d)
        {
            if (keyValues.Count>0)
            {
                foreach(KeyValuePair<string,string> pair in keyValues)
                {
                    List<string> data = new List<string>();
                    data = pair.Value.Split(',').ToList();
                    Chart chart = new Chart();
                    chart.SaveTempData(pair.Key.ToString(), data);
                }  
            }                     
        }
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