using System.Collections.Generic;

namespace MessagePosterApp
{
    public interface IUserMessageRepository
    {
        void Save(UserMessage userMessage);
        List<Message> GetMessages(string userName);
    }


    public class InMemoryUserMessageRepository : IUserMessageRepository
    {
        private readonly Dictionary<string, List<Message>> dict;

        public InMemoryUserMessageRepository()
        {
            dict = new Dictionary<string, List<Message>>();
        }



        public List<Message> GetMessages(string userName)
        {
            var result = new List<Message>();

            if (dict.ContainsKey(userName))
            {
                result.AddRange(dict[userName]);
            }

            return result;
        }

        public void Save(UserMessage userMessage)
        {
            if (dict.ContainsKey(userMessage.UserName))
            {
                var currentMessages = dict[userMessage.UserName];

                currentMessages.Add(new Message(userMessage.Message, System.DateTime.UtcNow));
            }
            else
            {
                dict.Add(userMessage.UserName, new List<Message> { new Message(userMessage.Message, System.DateTime.UtcNow) });
            }
        }
    }
}
