using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AlosMonitor
{
    public class SocketDescribe
    {
        static int index=0;
        public Socket SocketClient{
        set;get;
        }
        private SocketDescribe() { 
        }
        public static SocketDescribe GetSocketDescribe(Socket socket) {
            index++;
            
            return new SocketDescribe{Code=index,SocketClient=socket};
        }
        public byte[] Receive{set;get;}
        public int Code{set;get;}
        public string ReceiveString {
            get {
                return Encoding.UTF8.GetString(Receive);
            }
        }

    }
}
