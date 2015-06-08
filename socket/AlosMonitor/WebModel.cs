

namespace AlosMonitor
{
    public class WebModel
    {
        /// <summary>
        /// 会话ID
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 消息类别
        /// </summary>
        public ModelType Type { set; get; }
        /// <summary>
        /// 参数
        /// </summary>
        public string ClassName { set; get; }
        /// <summary>
        /// 方法
        /// </summary>
        public string Method { set; get; }
        /// <summary>
        /// 参数
        /// </summary>
        public object[] Parameter { set; get; }
        /// <summary>
        /// 返回值
        /// </summary>
        public object ReturnValue { set; get; }

    }
}
