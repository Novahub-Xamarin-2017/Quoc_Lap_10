namespace Exercise6.Models
{
    class CallNotification
    {
        public string CallerName { get; set; }
        public string CallTime { get; set; }

        public CallNotification(string callerName, string callTime)
        {
            CallerName = callerName;
            CallTime = callTime;
        }
    }
}