using System;

namespace MessagePosterApp
{
    public interface IUserMessageRepository
    {
        void Save(UserMessage userMessage);
        string GetMessages(string userName);
    }
}