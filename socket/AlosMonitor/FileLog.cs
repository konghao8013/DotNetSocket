using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AlosMonitor
{
    public class FileLog
    {
        public static void WriteString(string msg, string title = "MSG")
        {
            StreamWriter sw = new StreamWriter("error/Msg"+DateTime.Now.ToString("yyyyMMdd")+".txt", true);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t\t" + title);
            sb.AppendLine("msg:"+msg);
            sb.AppendLine("\r\n");
            sw.WriteLine(sb.ToString());
            sw.Close();
        }
    }
}
