using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestScoket
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip ="192.168.1.90";

          



            IPAddress serverIp = IPAddress.Parse(ip);

         

            IPEndPoint iep = new IPEndPoint(serverIp, 7543);

            byte[] byteMessage;

            // do 

            // { 

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(iep);



            byteMessage = Encoding.ASCII.GetBytes("创建SOCKET连接");

            socket.Send(byteMessage);

            socket.Shutdown(SocketShutdown.Both);

            socket.Close(); 
           
        }
    }
}
