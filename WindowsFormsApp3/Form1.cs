using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {
        Server s;
        // Recieved data buffer
        public static string constr = "Integrated Security=SSPI;Persist Security Info=False;Data Source=WIN-OTVR1M4I567;Initial Catalog=CresijCam";
        public Form1()
        { 
            InitializeComponent();
           
        }
        public  void Updation()
        {
            CresijCamDataSet1.CentralControlDataTable dt = new CresijCamDataSet1.CentralControlDataTable();
            centralControlTableAdapter1.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Refresh();
        }
        public  void UpdateData(byte[] receiveBytes, string iP)
        {
           
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            string[] data = new string[20];

            data[0] = iP;

            if (receiveBytes[6] == Convert.ToByte(0xc4))
            {
                data[2] = "Online";
            }
            if (receiveBytes[7] == Convert.ToByte(0x00))
            {
                data[3] = "Off";
            }
            else
                data[3] = "On";

            if (receiveBytes[8] == Convert.ToByte(0x00))
            {
                data[5] = "CLOSED";
            }
            else
                data[5] = "OPEN";

            if (receiveBytes[9] == Convert.ToByte(0x00))
            {
                data[14] = "Open";
            }
            else
                data[14] = "Locked";


            if (receiveBytes[10] == Convert.ToByte(0x00))
            {
                data[13] = "Open";
            }
            else
                data[14] = "Locked";


            switch (Convert.ToInt32(receiveBytes[11]))
            {
                case 1:
                    data[11] = "Desktop PC";
                    break;
                case 2:
                    data[11] = "Laptop";
                    break;
                case 3:
                    data[11] = "Digital Booth";
                    break;
                case 4:
                    data[11] = "Digital Equipment";
                    break;
                case 5:
                    data[11] = "DVD";
                    break;
                case 6:
                    data[11] = "Blu-Ray DVD";
                    break;
                case 7:
                    data[11] = "TV set";
                    break;
                case 8:
                    data[11] = "VCR";
                    break;
                case 9:
                    data[11] = "Recording System";
                    break;
                default:
                    data[11] = "No system Detected";
                    break;
            }

            if (receiveBytes[12] == Convert.ToByte(0x00))
            {
                data[12] = "Locked";
            }
            else
                data[12] = "Open";

            if (receiveBytes[13] == Convert.ToByte(0x00))
            {
                data[6] = "Closed";
            }
            else
                data[6] = "Open";

            switch (Convert.ToInt32(receiveBytes[14]))
            {
                case 1:
                    data[9] = "Open";
                    break;
                case 2:
                    data[9] = "Down";
                    break;
                case 0:
                    data[9] = "Stop";
                    break;
            }
            switch (Convert.ToInt32(receiveBytes[15]))
            {
                case 1:
                    data[8] = "Open";
                    break;
                case 2:
                    data[8] = "Down";
                    break;
                case 0:
                    data[8] = "Stop";
                    break;
            }
            if (receiveBytes[16] == Convert.ToByte(0x00))
            {
                data[10] = "OFF";
            }
            else
                data[10] = "On";
            data[15] = "--";
            data[16] = "--";
            data[17] = "--";
            data[18] = "--";
            data[1] = "Class2";
            data[19] = "1200";
            data[4] = "--";
            data[7] = "--";



            if (data != null)
            {


                string query = "insert into dbo.[CentralControl] values(";
                for (int k = 0; k < 20; k++)
                {
                    query = query + "'" + data[k] + "',";
                    // Console.WriteLine(data[k].ToString()+"  from  " + ip);
                }
                query = query.Substring(0, query.Length - 1);
                query = query + ")";
                string delQuery = "delete from dbo.[CentralControl] where CCIP ='" + data[0] + "'";



                using (SqlConnection con = new SqlConnection(constr))
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        
                            using (SqlCommand delcmd = new SqlCommand(delQuery, con))
                            {

                                delcmd.ExecuteNonQuery();

                            }
                        }
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {

                                cmd.ExecuteNonQuery();

                            }
                        
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    finally
                    {
                        con.Close();
                    }

                }

                
                Updation();

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string hexString = richTextBox1.Text;
            string ip = textBox1.Text;
            int discarded;
            //string byteCount = ((int)HexEncoding.GetByteCount(hexString)).ToString();
            //string length = hexString.Length.ToString();
            byte[] byteArray = HexEncoding.GetBytes(hexString, out discarded);
          
            
            string discard = discarded.ToString();
            if (s != null)
            {
                for (int i = 0; i < s.clients.Count; i++)
                {
                    if (ip == ((IPEndPoint)s.clients[i].Client.RemoteEndPoint).Address.ToString())
                    {
                        Thread th = new Thread(() =>
                        {
                            s.Sender(byteArray, s.clients[i]);
                        });

                    }
                }
            }
            Updation();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cresijCamDataSet1.CentralControl' table. You can move, or remove it, as needed.
            this.centralControlTableAdapter1.Fill(this.cresijCamDataSet1.CentralControl);
            Server server = new Server(); 
            Task task = new Task(server.Run);
            task.Start(); 
        }

        public static NetworkStream stream;
        public static List<TcpClient> tcpClients;
        public static TcpListener listener;
        public static void Run()
        {
            listener = new TcpListener(IPAddress.Any, 1200);
            listener.Start(100);

            try
            {
                WaitForClients();

            }
            catch (Exception ex)
            {

            }


        }
        public static void WaitForClients()
        {
            try
            {
                listener.BeginAcceptTcpClient(new AsyncCallback(OnConnectedAsync), null);

            }
            catch (Exception ex)
            {
                string message = ex.Message + " from " + ex.Source;
                throw;
            }
        }
        public static void HandleConnectionAsync(TcpClient client)
        {
            byte[] buffer = new byte[client.Client.Available];
            stream = new NetworkStream(client.Client);
            stream.ReadAsync(buffer, 0, client.Client.Available);
            
        }
        public static void OnConnectedAsync(IAsyncResult asyncResult)
        {
            try
            {
                TcpClient client = listener.EndAcceptTcpClient(asyncResult);
                if (client != null)
                {
                    if (!tcpClients.Contains(client))
                        tcpClients.Add(client);
                    HandleConnectionAsync(client);
                    WaitForClients();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message + " from " + ex.Source;
                throw;
            }
        }

        public static void SendData(string ipaddress, byte[] byteToSend)
        {
            for (int i = 0; i < tcpClients.Count; i++)
            {
                if (((IPEndPoint)(tcpClients[i].Client.RemoteEndPoint)).Address.ToString() == ipaddress)
                {
                    stream = new NetworkStream(tcpClients[i].Client);
                    stream.WriteAsync(byteToSend, 0, byteToSend.Length);                     
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
                hex = new String(new Char[] { newString[j], newString[j + 1] });
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
    public class Server
    {
        Form1 f = new Form1();
        public List<TcpClient> clients;
        
        //The main socket on which the server listens to the clients
        TcpListener tcp;
        byte[] byteData = new byte[1024];
        public Server()
        {
            clients = new List<TcpClient>();
        }
       
        public void Sender(byte[] data, TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            
        }
        public async void Run()
        {
             tcp = new TcpListener(IPAddress.Any, 1200);
            
            tcp.Start();
            while (true)
            {
                try
                {
                    TcpClient client = await tcp.AcceptTcpClientAsync();
                    Task t = Process(client);
                    await t;   
                }
                catch (Exception ex)
                {
                    string m = ex.Message;
                }
            }
        }

        private async Task Process(TcpClient tcpClient)
        {
           
            bool hasItem = clients.Contains(tcpClient);
            if(hasItem == false)
            {
                clients.Add(tcpClient);
            }
            IPEndPoint iPEndPoint =(IPEndPoint) tcpClient.Client.RemoteEndPoint;
           
            string ip = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            NetworkStream stream = tcpClient.GetStream();
            byte[] receivedBytes = new byte[20];
            int count = await stream.ReadAsync(receivedBytes, 0, receivedBytes.Length);
            // int count= stream.Read(receivedBytes, 0, receivedBytes.Length);
            if(count>0)
            {
                f.UpdateData(receivedBytes, ip);
            }
            
            else
            {
                tcpClient.Close();
                clients.Remove(tcpClient);
            }
           
        }
        
    }
  



}



