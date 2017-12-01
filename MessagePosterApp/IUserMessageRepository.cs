using System;
using System.Collections.Generic;

namespace MessagePosterApp
{
    public interface IUserMessageRepository
    {
        void Save(UserMessage userMessage);
        string GetMessages(string userName);
    }


    public class InMemoryUserMessageRepository : IUserMessageRepository
    {
        private readonly Dictionary<string, string> dict;

        public InMemoryUserMessageRepository()
        {
            dict = new Dictionary<string, string>();
        }

        public string GetMessages(string userName)
        {
            var result = "";

            if (dict.ContainsKey(userName))
            {
                result = dict[userName];
            }

            return result;
        }

        public void Save(UserMessage userMessage)
        {
            if (dict.ContainsKey(userMessage.UserName))
            {
                dict[userMessage.UserName] += ", " + userMessage.Message;
            }
            else
            {
                dict.Add(userMessage.UserName, userMessage.Message);
            }
        }
    }
}