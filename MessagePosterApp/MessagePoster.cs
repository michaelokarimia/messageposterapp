using System;

namespace MessagePosterApp
{
    public class MessagePoster
    {
        internal IUserMessageRepository repository;


        public MessagePoster(IUserMessageRepository repository)
        {
            this.repository = repository;
        }


        public string GetUserMessages(string name)
        {
           

            var foundMessages = repository.GetMessages(name);

            if (string.IsNullOrEmpty(foundMessages))
                foundMessages = "User name not found";

            return foundMessages;
        }

        public void SaveMessage(string inputstring)
        {
            var inputstringPair = inputstring.Split(':');

            var userMessage = new UserMessage(inputstringPair[0], inputstringPair[1]);
            repository.Save(userMessage);
        }
    }
}