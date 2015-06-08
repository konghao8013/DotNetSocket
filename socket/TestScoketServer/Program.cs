using AlosMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message();
            msg.Start();
            Console.ReadLine();
       
        }

      

    }
    
}
