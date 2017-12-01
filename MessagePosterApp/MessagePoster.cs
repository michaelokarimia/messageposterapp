using System.Collections.Generic;

namespace MessagePosterApp
{
    public class MessagePoster
    {
        internal IUserMessageRepository repository;


        public MessagePoster(IUserMessageRepository repository)
        {
            this.repository = repository;
        }


        public List<Message> GetUserMessages(string name)
        {
            var results = repository.GetMessages(name);


            return results;
        }

        public void SaveMessage(string inputstring)
        {
            var inputstringPair = inputstring.Split(':');

            var userMessage = new UserMessage(inputstringPair[0], inputstringPair[1]);
            repository.Save(userMessage);
        }
    }
}