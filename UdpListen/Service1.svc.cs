using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace UdpListen
{
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
    

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void status()
        {
            AsynchronousSocketListener.StartListening();
        }

       
    }

    public class StateObject
    {
        // Client  socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 20;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousSocketListener
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;

        // Thread signal.  
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public AsynchronousSocketListener()
        {
        }

        public static void StartListening()
        {
            // Establish the local endpoint for the socket.  
            // The DNS name of the computer  
            // running the listener is "host.contoso.com".  

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 1200);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(200);

                while (true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.  
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            allDone.Set();

            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            string ip = ((IPEndPoint)handler.RemoteEndPoint).Address.ToString();
            Console.WriteLine("ip   " + ip);
            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = handler;

            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            string b = "";

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);
            for (int i = 0; i < bytesRead; i++)
            {
                b = b + "  " + state.buffer[i].ToString();
            }
            string ip = ((IPEndPoint)handler.RemoteEndPoint).Address.ToString();
            if (bytesRead > 0)
            {
                if (bytesRead == 20)
                {





                }
            }
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);

        }


        private static void Send(Socket handler)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = new byte[] { 0x8B, 0xB9, 0x00, 0x04, 0x03, 0x02, 0x10, 0x15 };

            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void UpdateData(byte[] receiveBytes, string iP)
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            string[] data = new string[20];

            dr[0] = iP;

            if (receiveBytes[6] == Convert.ToByte(0xc4))
            {
                data[3] = "Online";
            }
            if (receiveBytes[7] == Convert.ToByte(0x00))
            {
                data[4] = "Off";
            }
            else
                data[4] = "On";

            if (receiveBytes[8] == Convert.ToByte(0x00))
            {
                data[6] = "CLOSED";
            }
            else
                data[6] = "OPEN";

            if (receiveBytes[9] == Convert.ToByte(0x00))
            {
                data[15] = "Open";
            }
            else
                data[15] = "Locked";


            if (receiveBytes[10] == Convert.ToByte(0x00))
            {
                data[14] = "Open";
            }
            else
                data[14] = "Locked";


            switch (Convert.ToInt32(receiveBytes[11]))
            {
                case 1:
                    data[12] = "Desktop PC";
                    break;
                case 2:
                    data[12] = "Laptop";
                    break;
                case 3:
                    data[12] = "Digital Booth";
                    break;
                case 4:
                    data[12] = "Digital Equipment";
                    break;
                case 5:
                    data[12] = "DVD";
                    break;
                case 6:
                    data[12] = "Blu-Ray DVD";
                    break;
                case 7:
                    data[12] = "TV set";
                    break;
                case 8:
                    data[12] = "VCR";
                    break;
                case 9:
                    data[12] = "Recording System";
                    break;
                default:
                    data[12] = "No system Detected";
                    break;
            }

            if (receiveBytes[12] == Convert.ToByte(0x00))
            {
                data[13] = "Locked";
            }
            else
                data[13] = "Open";

            if (receiveBytes[13] == Convert.ToByte(0x00))
            {
                data[7] = "Closed";
            }
            else
                data[7] = "Open";

            switch (Convert.ToInt32(receiveBytes[14]))
            {
                case 1:
                    data[10] = "Open";
                    break;
                case 2:
                    data[10] = "Down";
                    break;
                case 0:
                    data[10] = "Stop";
                    break;
            }
            switch (Convert.ToInt32(receiveBytes[15]))
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
            if (receiveBytes[16] == Convert.ToByte(0x00))
            {
                data[11] = "OFF";
            }
            else
                data[11] = "On";
            data[16] = "--";
            data[17] = "--";
            data[18] = "--";
            data[19] = "--";



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
                string delQuery = "delete from dbo.[CentralControl] where CCIP ='" +data[0]+"'";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.OpenAsync();
                            using (SqlCommand delcmd = new SqlCommand(delQuery, con))
                            {

                                delcmd.ExecuteNonQuery();

                            }
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {

                                cmd.ExecuteNonQuery();

                            }
                        } 
                    }
                    finally
                    {
                        con.Close();
                    }
                        
                }
            }
        }
    }
}
