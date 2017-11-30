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
    public class MessagePosterTests
    {
        [Test]
        public void PrintsUserNotFoundForUnknownUsernameEntered()
        {
            MessagePoster subject = new MessagePoster();
            Assert.AreEqual("User name not found", subject.GetUserMessages("joe bloggs"));
        }
    }
}
