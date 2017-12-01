using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MessagePosterApp;
using Moq;

namespace Tests
{
    [TestFixture]
    public class MessagePosterTests
    {
        MessagePoster subject;
        Mock<IUserMessageRepository> mockRespository;

        [SetUp]
        public void Setup()
        {
            mockRespository = new Mock<IUserMessageRepository>();
            mockRespository.Setup(x => x.GetMessages(It.IsAny<string>())).Returns(new List<Message>());

            subject = new MessagePoster(mockRespository.Object);
        }

        [Test]
        public void ReturnsNoMessagesWhenForUnknownUsernameEntered()
        {
            mockRespository.Setup(x => x.GetMessages(It.IsAny<string>())).Returns(new List<Message>());

            subject = new MessagePoster(mockRespository.Object);

            var messages = subject.GetUserMessages("joe bloggs");

            Assert.AreEqual(0, messages.Count);
        }


        [Test]
        public void RepositoryCalledWhenGetUserMessageInvoked()
        {
            string userName = "Eric Idle";

            subject.GetUserMessages(userName);

            mockRespository.Verify(x => x.GetMessages(userName), Times.Once);
        }

        [Test]
        public void RepositoryCalledWhenSaveMessageInvoked()
        {
            var message = "Message";
            var username = "Jane Doe";
            var inputstring = string.Format("{0}:{1}", username, message);
            

            var userMessage = new UserMessage(username, message);

            subject = new MessagePoster(mockRespository.Object);



            subject.SaveMessage(inputstring);

            mockRespository.Verify(x => x.Save(It.IsAny<UserMessage>()), Times.Once);


        }


     
    }
}
