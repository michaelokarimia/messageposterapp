using System;

namespace MessagePosterApp
{
    public class MessagePoster
    {
        internal IUserMessageRepository Repository;


        public MessagePoster(IUserMessageRepository repository)
        {
            this.Repository = repository;
        }


        public string GetUserMessages(string name)
        {
            var foundMessages = "User name not found";

            return foundMessages;
        }
    }
}