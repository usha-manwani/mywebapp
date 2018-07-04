using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace trythis
{
    public class ServerSocket
    {
        //server up = new server();
        //Thread t = null;
        //EndPoint ep;
        //const int port = 1200;
        //private readonly UdpClient udp = new UdpClient(port);
        //IAsyncResult ar_ = null;
        //Socket serverSocket = new Socket(AddressFamily.InterNetwork,
        //        SocketType.Dgram, ProtocolType.Udp);
        //public byte[] serverSockets(String IPadd, byte[] dataToSend)
        //{


        //    byte[] receivebytes = new byte[20];
        //    try
        //    {


        //        IPAddress iPAddress = IPAddress.Parse(IPadd);
        //        int port = 1024;
        //        IPEndPoint iPEnd = new IPEndPoint(iPAddress, port);

        //        //Assign the any IP of the machine and listen on port number 1200
        //        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1200);
        //        serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
        //        serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
        //        serverSocket.Bind(ipEndPoint);
        //        ep = (EndPoint)iPEnd;

        //        serverSocket.SendTo(dataToSend, ep);
        //        // Thread.Sleep(1000);
        //        serverSocket.Receive(receivebytes);

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        serverSocket.Dispose();

        //    }

        //    return receivebytes;
        //}


        //private void updates()
        //{
        //    byte[] receivebytes = new byte[20];
        //    try
        //    {
        //        IPEndPoint iPEnd = new IPEndPoint(IPAddress.Any, 1024);
        //        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1200);
        //        serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
        //        //serverSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000);
        //        serverSocket.Bind(ipEndPoint);
        //        ep = (EndPoint)iPEnd;
        //        serverSocket.Listen(100);
        //        serverSocket.ReceiveFrom(receivebytes, ref ep);


        //    }
        //    catch (ThreadInterruptedException e)
        //    {
        //        IPAddress ip = ((IPEndPoint)ep).Address;
        //        up.updateData(receivebytes, ip.ToString());
        //    }
        //}

        //public void Start()
        //{
        //    udp.Dispose();
        //    if (t != null)
        //    {
        //        throw new Exception("Already started, stop first");
        //    }
        //    Console.WriteLine("Started listening");
        //    StartListening();
        //}
        //private void StartListening()
        //{
        //    ar_ = udp.BeginReceive(Receive, new object());
        //}
        //private void Receive(IAsyncResult ar)
        //{
        //    IPEndPoint ip = new IPEndPoint(IPAddress.Any, port);
        //    byte[] bytes = udp.EndReceive(ar, ref ip);
        //    string message = Encoding.ASCII.GetString(bytes);
        //    Console.WriteLine("From {0} received: {1} ", ip.Address.ToString(), message);
        //    StartListening();
        //}



    }
}