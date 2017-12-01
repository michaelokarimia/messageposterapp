using System.Collections.Generic;

namespace MessagePosterApp
{
    public interface IUserMessageRepository
    {
        void Save(UserMessage userMessage);
        List<string> GetMessages(string userName);
    }


    public class InMemoryUserMessageRepository : IUserMessageRepository
    {
        private readonly Dictionary<string, List<string>> dict;

        public InMemoryUserMessageRepository()
        {
            dict = new Dictionary<string, List<string>>();
        }

        public List<string> GetMessages(string userName)
        {
            var result = new List<string>();

            if (dict.ContainsKey(userName))
            {
                result.AddRange(dict[userName]);            }

            return result;
        }

        public void Save(UserMessage userMessage)
        {
            if (dict.ContainsKey(userMessage.UserName))
            {
                dict[userMessage.UserName].Add(userMessage.Message);
            }
            else
            {
                dict.Add(userMessage.UserName, new List<string> { userMessage.Message });
            }
        }
    }
}