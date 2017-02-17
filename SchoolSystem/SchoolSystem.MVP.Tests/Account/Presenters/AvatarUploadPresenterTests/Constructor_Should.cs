using Moq;
using NUnit.Framework;

using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.Web.Services.Contracts;

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

        [Test]
        public void NotThrow_WithMessageContainsAccount_WhenAccountManagementServiceIsNull()
        {
            var mockedIAvatarUploadView = new Mock<IAvatarUploadView>();
            var mockedAccManagementService = new Mock<IAccountManagementService>();

            Assert.DoesNotThrow(() => new AvatarUploadPresenter(mockedIAvatarUploadView.Object, mockedAccManagementService.Object));
        }
    }
}
