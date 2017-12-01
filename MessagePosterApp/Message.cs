using System;

namespace MessagePosterApp
{
    public class Message
    {
        private string text;
        private DateTime timeStamp;

        public Message(string text, DateTime utcNow)
        {
            this.text = text;
            this.timeStamp = utcNow;
        }

        public string Text { get => text;}
        public DateTime TimeStamp { get => timeStamp; }
    }
}