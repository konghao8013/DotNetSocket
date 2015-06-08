using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlosMonitor
{
    public enum SocketState
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        Error=0,
        /// <summary>
        /// 发送成功
        /// </summary>
        OK=1,
        /// <summary>
        /// 未找到Socket对象
        /// </summary>
        IsNull=2
    }
}
