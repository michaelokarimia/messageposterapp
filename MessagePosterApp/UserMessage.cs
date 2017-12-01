using System;

namespace MessagePosterApp
{
    public class UserMessage
    {
        private readonly string userName;
        private readonly string message;
        private DateTime timestamp;

        public UserMessage(string userName, string message)
        {
            this.userName = userName;
            this.message = message;
            this.timestamp = DateTime.UtcNow;
        }

        public UserMessage(string userName, string message, DateTime timestamp)
        {
            this.userName = userName;
            this.message = message;
            this.timestamp = timestamp;
        }

        public string UserName { get => userName; }
        public string Message { get => message; }
        public DateTime Timestamp { get => timestamp; }
    }
}