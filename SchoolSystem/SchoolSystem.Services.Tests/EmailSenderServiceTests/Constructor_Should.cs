using System;

using SchoolSystem.Web.Services;
using NUnit.Framework;

namespace SchoolSystem.Services.Tests.EmailSenderServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_SmtpClient_IsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new EmailSenderService(null));
        }
    }
}
