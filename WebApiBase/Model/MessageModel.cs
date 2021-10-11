namespace WebApiBase.Models
{
    /// <summary>
    /// 返回前端消息体
    /// </summary>
    public class MessageModel
    {
        /// <summary>
        /// 结果
        /// </summary>
        public bool result { get; set; } = false;

        /// <summary>
        /// 错误消息
        /// </summary>
        public string message { get; set; } = "";

        /// <summary>
        /// 结果数据
        /// </summary>
        public object data { get; set; } = null;
    }
}