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
        public void RepositoryCallWhenSaveUserMessageInvoked()
        {
            

            var username = "Jane Doe";
            mockRespository.Verify(x => x.Save(username), Times.Once);
            subject = new MessagePoster(mockRespository.Object);


            
        }
    }
}
