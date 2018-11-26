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

namespace trythis.Hubsfile
{  
    [HubName("myHub")]
    public class MyHub : Microsoft.AspNet.SignalR.Hub
    {
        //DataTable ScoresTable = HttpContext.Current.Application["ScoresTable"] as DataTable;
        string constr= ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        public void Hello()
        {
            Clients.All.hello();
        }
        public async override Task OnConnected()
        {
            await base.OnConnected();
            SendData();
           
        }
            public void SendMessage(string sender, string data)
        {
            Clients.All.broadcastMessage(sender, data);
        }
        public void SendData()
        {            
            Clients.All.SendToMachine(1);
        }
       public void SendControlKeys(string machine, string code)
        {
            Clients.All.SendControl(machine, code);
        }

        public void GetUsers()
        {
            DataTable dt;
            using (var connection = new SqlConnection(constr))
            {
                string query = "SELECT * from dbo.[CentralControl]";
                try
                {
                    connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Notification = null;
                        dt = new DataTable();
                        DataSet ds = new DataSet();
                        SqlDependency dependency = new SqlDependency(command);
                        dependency.OnChange += dependency_OnChange;                        
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

        //[HubMethodName("sendMessages")]
        //public static void SendMessages()
        //{
        //    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        //    context.Clients.All.updateMessages();     
        //}

        public void GetStatus(string sender, string Message )
        {
            int dis;
            byte[] statusRec=  HexEncoding.GetBytes(Message, out dis);

            Clients.All.broadcastMessage(sender, statusRec);
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