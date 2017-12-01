namespace MessagePosterApp
{
    public class UserMessage
    {
        private readonly string userName;
        private readonly string message;

        public UserMessage(string userName, string message)
        {
            this.userName = userName;
            this.message = message;
        }

        public string UserName { get => userName; }
        public string Message { get => message; }
    }
}