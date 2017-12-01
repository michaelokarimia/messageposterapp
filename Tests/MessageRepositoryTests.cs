using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MessagePosterApp;


namespace Tests
{
    [TestFixture]
    public class InMemoryMessageRepositoryTests
    {

        IUserMessageRepository subject;

        [SetUp]
        public void Setup()
        {
            subject = new InMemoryUserMessageRepository();
        }

        [Test]
        public void CanSaveAndThenRetrieveANewUsersMessage()
        {
            var userName = "David";
            var message = "Ground control to Major Tom";

            subject.Save(new UserMessage(userName, message));

            var messages = subject.GetMessages(userName);


            Assert.AreEqual(message, messages[0]);
        }

        [Test]
        public void SavesAndThenRetrieveMultipleMessagesOfANewUser()
        {
            var userName = "David";
            var message1 = "Ground control to Major Tom";
            var message2 = "Take your protein pills and put your helmet on";

            subject.Save(new UserMessage(userName, message1));
            subject.Save(new UserMessage(userName, message2));

            var messages = subject.GetMessages(userName);

            Assert.AreEqual(message1, messages[0]);
            Assert.AreEqual(message2, messages[1]);
        }

    }
}
