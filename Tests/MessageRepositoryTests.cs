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

            Assert.AreEqual(message, subject.GetMessages(userName));
        }

    }
}
