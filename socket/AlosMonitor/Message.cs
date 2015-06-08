
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlosMonitor
{
    public class Message
    {
        Initiate init;
        public void Start() {

            Initiate init = new Initiate(4522);
            init.StartSilverlight();
            init.Start();
            init.Receive += init_Receive;
            init.Accept += init_Accept;
            init.Close += init_Close;
            FileLog.WriteString("成功启动消息服务");
          
        }

        void init_Close(SocketDescribe obj)
        {
            
        }

        void init_Accept(SocketDescribe obj)
        {
       
        }

        void init_Receive(SocketDescribe obj)
        {

            var model = obj.ReceiveString.Deserialize<WebModel>();
            switch (model.Type) {
                case ModelType.Code: 
                    
                    break;
                case ModelType.Cmd:
                  
                  
                    break;
                case ModelType.Message: 
                    
                    break;
            }
        }
     
}
    
}
