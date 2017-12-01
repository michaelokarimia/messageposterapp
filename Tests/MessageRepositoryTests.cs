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


            Assert.AreEqual(message, messages[0].Text);
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

            Assert.AreEqual(message1, messages[0].Text);
            Assert.AreEqual(message2, messages[1].Text);
        }


        [Test]
        public void MultipleUsersHaveTheirMessagesStored()
        {
            var userNameOne = "David";
            var message1 = "Ground control to Major Tom";
            var message2 = "Take your protein pills and put your helmet on";

            var userNameTwo = "Ziggy";
            var msg1 = "Ziggy played guitar";
            var msg2 = "jamming good with Weird and Gilly";
            var msg3 = "And the spiders from Mars;";

            subject.Save(new UserMessage(userNameOne, message1));
            subject.Save(new UserMessage(userNameOne, message2));

            subject.Save(new UserMessage(userNameTwo, msg1));
            subject.Save(new UserMessage(userNameTwo, msg2));
            subject.Save(new UserMessage(userNameTwo, msg3));

            var messages = subject.GetMessages(userNameTwo);

            Assert.AreEqual(msg1, messages[0].Text);
            Assert.AreEqual(msg2, messages[1].Text);
            Assert.AreEqual(msg3, messages[2].Text);
        }

        [Test]
        public void AgeOfMessageStored()
        {
            DateTime timestamp = DateTime.UtcNow;

            var userName = "David";
            var message1 = "Let's dance";
            var message2 = "Put on your red shoes and sing the blues";


            subject.Save(new UserMessage(userName, message1, timestamp));
            subject.Save(new UserMessage(userName, message2, timestamp));

            var messages = subject.GetMessages(userName);



            Assert.AreEqual(message1, messages[0].Text);
            Assert.AreEqual(timestamp, messages[0].TimeStamp);
        }
        
    }
}
