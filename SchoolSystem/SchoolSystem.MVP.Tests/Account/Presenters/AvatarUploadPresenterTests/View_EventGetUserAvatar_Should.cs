using Moq;
using NUnit.Framework;

using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.MVP.Account.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Account.Presenters.AvatarUploadPresenterTests
{
    [TestFixture]
    public class View_EventGetUserAvatar_Should
    {
        [TestCase("user1", "~/pics/user1.png")]
        [TestCase("user2", "~/pics/user2.png")]
        [TestCase("user3", "~/pics/user3.png")]
        public void AtachUserAvatarUrlToTheModel(string userName, string userAvatarUrl)
        {
            var mockedAvatarUploadView = new Mock<IAvatarUploadView>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();

            var mockedModel = new AvatarUploadModel();
            mockedAvatarUploadView.Setup(x => x.Model).Returns(mockedModel);
            mockedAccountManagementService.Setup(x => x.GetUserAvatarUrl(userName)).Returns(userAvatarUrl);

            var avatarUploadPresenter = new AvatarUploadPresenter(mockedAvatarUploadView.Object, mockedAccountManagementService.Object);
            var eventArgs = new GetUserAvatarEventArgs() { LoggedUseUserName = userName };

            mockedAvatarUploadView.Raise(x => x.EventGetUserAvatar += null, eventArgs);

            Assert.AreEqual(userAvatarUrl, mockedAvatarUploadView.Object.Model.UserAvatarUrl);
        }
    }
}
