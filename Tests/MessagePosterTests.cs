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
            subject = new MessagePoster(mockRespository.Object);
        }

        [Test]
        public void PrintsUserNotFoundForUnknownUsernameEntered()
        {
            Assert.AreEqual("User name not found", subject.GetUserMessages("joe bloggs"));
        }


        [Test]
        public void RepositoryCalledWhenGetUserMessageInvoked()
        {
            //mockRespository.Setup(x=> x.GetMessages(It.IsAny<string>())).Returns("")

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
