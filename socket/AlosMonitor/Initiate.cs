using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using  System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;

namespace AlosMonitor
{
    /// <summary>
    /// 开始Scoket
    /// </summary>
    public class Initiate
    {
       readonly int _port;
       List<SocketDescribe> list = new List<SocketDescribe>();
        /// <summary>
        /// 端口号
        /// </summary>
        /// <param name="port"></param>
        public Initiate(int port) {
            _port = port;

        }
        /// <summary>
        /// 系统Socket消息
        /// </summary>
        public void Start()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, _port);
          
            socket.Bind(ipEnd);
            socket.Listen(10);
            Monitor(socket);

        }
        /// <summary>
        /// 启动Silverlight策略协议
        /// </summary>
        public void StartSilverlight() {
            Socket silver = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            silver.Bind(new IPEndPoint(IPAddress.Any, 943));
            silver.Listen(4);
            silver.BeginAccept(new AsyncCallback(SilverAccepted), silver);
            
        }
        private  void SilverAccepted(IAsyncResult ar)
        {

            var socket = ar.AsyncState as Socket;

            //这就是客户端的Socket实例，我们后续可以将其保存起来
            var client = socket.EndAccept(ar);
            var bs = new byte[1024];
            client.Receive(bs);
            string config = "<?xml version=\"1.0\" encoding =\"utf-8\"?>" +
                      "<access-policy>" +
                        "<cross-domain-access>" +
                          "<policy>" +
                            "<allow-from>" +
                              "<domain uri=\"*\" />" +
                            "</allow-from>" +
                            "<grant-to>" +
                              "<socket-resource port=\"4502-4530\" protocol=\"tcp\" />" +
                            "</grant-to>" +
                          "</policy>" +
                        "</cross-domain-access>" +
                      "</access-policy>";
            client.Send(Encoding.Default.GetBytes(config));
            client.Close();
            socket.BeginAccept(new AsyncCallback(SilverAccepted), socket);
        }

        public async void Monitor(Socket socket)
        {
            await Task.Run(() =>
            {
                while (true)
                {

                    SocketDescribe socketClient = SocketDescribe.GetSocketDescribe(socket.Accept());
                    list.Add(socketClient);
                    if (Accept != null) {
                        Accept(socketClient);
                    }
                    Thread thread = new Thread(() =>
                    {
                        MonitorClient(socketClient);
                    });
                    thread.Start();
                    
                }
            });
        }

        public void MonitorClient(SocketDescribe socketClient)
        {
            var socket = socketClient.SocketClient;
            var bs = new byte[1024];
            int length = 0;
            bool isRec = true;
            while (isRec)
            {
                try
                {
                    length = socket.Receive(bs);
                    if (Receive != null&&length>0) {
                        socketClient.Receive = bs.Take(length).ToArray();
                        Receive(socketClient);
                    }
                }
                catch {
                    list.Remove(socketClient);
                    isRec = false;
                    if (Close != null) {
                        Close(socketClient);
                    }
                }
                
               
            }
            
        }

        /// <summary>
        /// 向所有客户端发送消息
        /// </summary>
        /// <param name="bytes"></param>
        public void SendAll(byte[] bytes) {
            foreach (var socket in list) {
                socket.SocketClient.Send(bytes);
            }
        }
        public SocketState Send(int index, byte[] bytes)
        {
            var socket = list.LastOrDefault(a => a.Code == index);
            if (socket != null)
            {
                socket.SocketClient.Send(bytes);
                return SocketState.OK;
            }
            else {
               return SocketState.IsNull;
            }
        }
        public event Action<SocketDescribe> Receive;
        /// <summary>
        /// 客户端链接事件
        /// </summary>
        public event Action<SocketDescribe> Accept;
        /// <summary>
        /// 客户端关闭链接事件
        /// </summary>
        public event Action<SocketDescribe> Close;
     
        public IPAddress GetIp()
        {

            var ipe=Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(a=>!a.IsIPv6LinkLocal).ToArray();
           return ipe[0];
        }
    }
}
