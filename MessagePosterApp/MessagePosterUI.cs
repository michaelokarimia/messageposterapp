using System;

namespace MessagePosterApp
{
    internal class MessagePosterUI
    {
        private readonly MessagePoster messagePoster;

        public MessagePosterUI()
        {
            messagePoster = new MessagePoster(new InMemoryUserMessageRepository());
        }

        internal void Start()
        {
            string input = "";

            Console.WriteLine("Type q to quit application");

            while (input.ToLowerInvariant().Trim() != "q")
            {
                input = Console.ReadLine();

                if (input.Contains(":"))
                {
                    //it's a new message

                    messagePoster.SaveMessage(input);
                }
                else
                {
                    //retrieve a user

                    var messages = messagePoster.GetUserMessages(input);

                    if (messages.Count == 0)
                    {
                        Console.WriteLine("No messages found for username {0}", input);
                    }
                    else
                    {
                        foreach (var msg in messages)
                        {
                            Console.WriteLine("{0} ({1})", msg.Text, msg.TimeStamp);
                        }
                    }
                }

            }
            
        }
    }

}