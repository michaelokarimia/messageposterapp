using System;

namespace MessagePosterApp
{
    public interface IUserMessageRepository
    {
        void Save(UserMessage userMessage);
        string GetMessages(string userName);
    }


    public class InMemoryUserMessageRepository : IUserMessageRepository
    {
        public string GetMessages(string userName)
        {
            throw new NotImplementedException();
        }

        public void Save(UserMessage userMessage)
        {
            throw new NotImplementedException();
        }
    }
}