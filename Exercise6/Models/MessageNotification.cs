namespace Exercise6.Models
{
    class MessageNotification
    {
        public string SenderName { get; set; }
        public string MessageContent { get; set; }
        public string MessageTime { get; set; }

        public MessageNotification(string senderName, string messageContent, string messageTime)
        {
            SenderName = senderName;
            MessageContent = messageContent;
            MessageTime = messageTime;
        }
    }
}