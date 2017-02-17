using Moq;
using NUnit.Framework;

using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;

namespace SchoolSystem.MVP.Tests.Account.Presenters.AvatarUploadPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WithMessageContainsAccount_WhenAccountManagementServiceIsNull()
        {
            var mockedIAvatarUploadView = new Mock<IAvatarUploadView>();

            Assert.That(() => new AvatarUploadPresenter(mockedIAvatarUploadView.Object, null),
                Throws.ArgumentNullException.With.Message.Contain("accountManagementService"));
        }
    }
}
