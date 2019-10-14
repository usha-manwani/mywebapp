using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using MySql.Data.MySqlClient;

namespace WebCresij
{
    public class server
    {
        public static string constr = System.Configuration.ConfigurationManager.ConnectionStrings["CresijCamConnectionString"].ConnectionString;
        DataTable dt = new DataTable();
        Thread t = null;
        List<string> clientList;


        //ServerSocket ss;




        public DataTable CC()
        {

            byte[] dataToSend = new byte[] { 0x8B, 0xB9, 0x00, 0x03, 0x05, 0x01, 0x09 };
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "select * from dbo.CentralControl";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            //clientList = dt.AsEnumerable().Select(s => s.Field<string>("CCIP")).ToList();
            //foreach (string s in clientList)
            //{
            //    //ss = new ServerSocket();
            //    // ss.Start();
            //    // updateData(datas, s);
            //   // ss = null;
            //}

            return dt;
        }



        public DataTable updateData(byte[] receiveBytes, string iP,DataTable dt)
        {
            string ips = iP;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString() == ips)
                {
                    if (receiveBytes.Length == 20)
                    {
                        if (receiveBytes[6] == Convert.ToByte(0xc4))
                        {
                            dr[3] = "Online";
                        }
                        if (receiveBytes[8] == Convert.ToByte(0x00))
                        {
                            dr[4] = "Closed";
                        }
                        else
                            dr[4] = "Open";

                        if (receiveBytes[7] == Convert.ToByte(0x00))
                        {
                            dr[6] = "OFF";
                        }
                        else
                            dr[6] = "ON";

                        if (receiveBytes[9] == Convert.ToByte(0x00))
                        {
                            dr[15] = "Locked";
                        }
                        else
                            dr[15] = "Opened";


                        if (receiveBytes[10] == Convert.ToByte(0x00))
                        {
                            dr[14] = "Locked";
                        }
                        else
                            dr[14] = "Opened";


                        switch (Convert.ToInt32(receiveBytes[11]))
                        {
                            case 1:
                                dr[12] = "Desktop PC";
                                break;
                            case 2:
                                dr[12] = "Laptop";
                                break;
                            case 3:
                                dr[12] = "Digital Booth";
                                break;
                            case 4:
                                dr[12] = "Digital Equipment";
                                break;
                            case 5:
                                dr[12] = "DVD";
                                break;
                            case 6:
                                dr[12] = "Blu-Ray DVD";
                                break;
                            case 7:
                                dr[12] = "TV set";
                                break;
                            case 8:
                                dr[12] = "VCR";
                                break;
                            case 9:
                                dr[12] = "Recording System";
                                break;
                            default:
                                dr[12] = "No system Detected";
                                break;
                        }

                        if (receiveBytes[12] == Convert.ToByte(0x00))
                        {
                            dr[13] = "Locked";
                        }
                        else
                            dr[13] = "Open";

                        if (receiveBytes[13] == Convert.ToByte(0x00))
                        {
                            dr[7] = "Closed";
                        }
                        else
                            dr[7] = "Open";

                        switch (Convert.ToInt32(receiveBytes[14]))
                        {
                            case 1:
                                dr[10] = "Open";
                                break;
                            case 2:
                                dr[10] = "Down";
                                break;
                            case 0:
                                dr[10] = "Stop";
                                break;
                        }
                        switch (Convert.ToInt32(receiveBytes[15]))
                        {
                            case 1:
                                dr[9] = "Open";
                                break;
                            case 2:
                                dr[9] = "Down";
                                break;
                            case 0:
                                dr[9] = "Stop";
                                break;
                        }
                        if (receiveBytes[16] == Convert.ToByte(0x00))
                        {
                            dr[11] = "OFF";
                        }
                        else
                            dr[11] = "On";
                    }


                    else
                    {

                        if (receiveBytes[6] == Convert.ToByte(0xc9))
                        {
                            dr[3] = "Offline";
                        }
                    }



                }

            }
            return dt;
            
        }

        Socket serverSocket;

        byte[] byteData = new byte[1024];

        public void tension()
        {
            try
            {
                //We are using UDP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);

                //Assign the any IP of the machine and listen on port number 1200
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1200);

                //Bind this address to the server
                serverSocket.Bind(ipEndPoint);

                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 1024);
                //The epSender identifies the incoming clients
                EndPoint epSender = (EndPoint)ipeSender;
                //Start receiving data
                serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length,
                    SocketFlags.None, ref epSender, new AsyncCallback(OnReceive), epSender);
            }
            catch
            {

            }



        }
        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 1024);
                EndPoint epSender = (EndPoint)ipeSender;

                serverSocket.EndReceiveFrom(ar, ref epSender);
                serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epSender,
                        new AsyncCallback(OnReceive), epSender);
            }
            catch { }
        }
    }
}