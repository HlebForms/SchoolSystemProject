using System;
using System.Web;
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
    public class View_EventUploadAvatar_Should
    {
        [TestCase("image/g3fax")]
        [TestCase("image/gif")]
        [TestCase("image/ief")]
        [TestCase("image/tiff")]
        public void NotCallSaveAsMethodFromTheFile_AndSetStatusMessageCorrectly_WhenContentTypesAreInvalid(string contentType)
        {
            var mockedAvatarUploadView = new Mock<IAvatarUploadView>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();

            var mockedModel = new AvatarUploadModel();
            mockedAvatarUploadView.Setup(x => x.Model).Returns(mockedModel);

            var avatarUploadPresenter = new AvatarUploadPresenter(mockedAvatarUploadView.Object, mockedAccountManagementService.Object);
            var mockedFile = new Mock<HttpPostedFileBase>();
            mockedFile.SetupGet(x => x.ContentType).Returns(contentType);

            var args = new AvatarUploadEventArgs() { PostedFile = mockedFile.Object };
            mockedAvatarUploadView.Raise(x => x.EventUploadAvatar += null, args);

            var expectedMessage = "Моля изберете картинка с разширение .png, .jpg или .jpeg";

            mockedFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Never());
            Assert.AreEqual(expectedMessage, mockedAvatarUploadView.Object.Model.StatusMessage);
        }

        [TestCase(1 * 1000 * 1000, "image/jpg")]
        [TestCase(2 * 1000 * 1000, "image/png")]
        [TestCase(3 * 1000 * 1000, "image/jpeg")]
        public void CallSaveAsMethodFromTheFile_Once_AndSetCorrectlyStatusMessage_WhenContentTypesAreValidAndContentLengthIsValid(int contentLength, string contentType)
        {
            var mockedAvatarUploadView = new Mock<IAvatarUploadView>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();

            var mockedModel = new AvatarUploadModel();
            mockedAvatarUploadView.Setup(x => x.Model).Returns(mockedModel);

            var avatarUploadPresenter = new AvatarUploadPresenter(mockedAvatarUploadView.Object, mockedAccountManagementService.Object);
            var mockedFile = new Mock<HttpPostedFileBase>();

            mockedFile.SetupGet(x => x.ContentType).Returns(contentType);
            mockedFile.SetupGet(x => x.ContentLength).Returns(contentLength);

            var args = new AvatarUploadEventArgs() { PostedFile = mockedFile.Object };
            mockedAvatarUploadView.Raise(x => x.EventUploadAvatar += null, args);

            string expectedMessage = "Аватарът е качен";
            mockedFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Once());
            Assert.AreEqual(expectedMessage, mockedAvatarUploadView.Object.Model.StatusMessage);
        }

        [TestCase(6 * 1000 * 1000, "image/jpg")]
        [TestCase(7 * 1000 * 1000, "image/png")]
        [TestCase(82 * 1000 * 1000, "image/jpeg")]
        public void NotCallCallSaveAsMethodFromTheFile_WhenContentTypesAreValidButContentLengthIsInvalid(int contentLength, string contentType)
        {
            var mockedAvatarUploadView = new Mock<IAvatarUploadView>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();

            var mockedModel = new AvatarUploadModel();
            mockedAvatarUploadView.Setup(x => x.Model).Returns(mockedModel);

            var avatarUploadPresenter = new AvatarUploadPresenter(mockedAvatarUploadView.Object, mockedAccountManagementService.Object);
            var mockedFile = new Mock<HttpPostedFileBase>();
            mockedFile.SetupGet(x => x.ContentType).Returns(contentType);
            mockedFile.SetupGet(x => x.ContentLength).Returns(contentLength);

            var args = new AvatarUploadEventArgs() { PostedFile = mockedFile.Object };
            mockedAvatarUploadView.Raise(x => x.EventUploadAvatar += null, args);

            mockedFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Never());
        }

        [TestCase(1 * 1000 * 1000, "image/jpg")]
        [TestCase(2 * 1000 * 1000, "image/png")]
        [TestCase(5 * 1000 * 1000, "image/jpeg")]
        public void Call_UploadAvatar_FromAccountManagementServiceOnceWhenContentTypeAndContentLengthAreValid(int contentLength, string contentType)
        {
            var mockedAvatarUploadView = new Mock<IAvatarUploadView>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();

            var mockedModel = new AvatarUploadModel();
            mockedAvatarUploadView.Setup(x => x.Model).Returns(mockedModel);

            var avatarUploadPresenter = new AvatarUploadPresenter(mockedAvatarUploadView.Object, mockedAccountManagementService.Object);
            var mockedFile = new Mock<HttpPostedFileBase>();
            mockedFile.SetupGet(x => x.ContentType).Returns(contentType);
            mockedFile.SetupGet(x => x.ContentLength).Returns(contentLength);

            var args = new AvatarUploadEventArgs()
            {
                PostedFile = mockedFile.Object,
                LoggedUserUserName = "User1",
                UserAvatarUrl = "~/path"
            };

            mockedAvatarUploadView.Raise(x => x.EventUploadAvatar += null, args);

            mockedAccountManagementService.Verify(x => x.UploadAvatar(args.LoggedUserUserName, args.UserAvatarUrl), Times.Once());
        }

        [TestCase(2 * 1000 * 1000, "image/tiff")]
        [TestCase(10 * 1000 * 1000, "image/jpeg")]
        public void NotCall_UploadAvatar_FromAccountManagementServiceOnceWhenContentTypeOrContentLengthInAreValid(int contentLength, string contentType)
        {
            var mockedAvatarUploadView = new Mock<IAvatarUploadView>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();

            var mockedModel = new AvatarUploadModel();
            mockedAvatarUploadView.Setup(x => x.Model).Returns(mockedModel);

            var avatarUploadPresenter = new AvatarUploadPresenter(mockedAvatarUploadView.Object, mockedAccountManagementService.Object);
            var mockedFile = new Mock<HttpPostedFileBase>();
            mockedFile.SetupGet(x => x.ContentType).Returns(contentType);
            mockedFile.SetupGet(x => x.ContentLength).Returns(contentLength);

            var args = new AvatarUploadEventArgs()
            {
                PostedFile = mockedFile.Object,
                LoggedUserUserName = "User1",
                UserAvatarUrl = "~/path"
            };

            mockedAvatarUploadView.Raise(x => x.EventUploadAvatar += null, args);

            mockedAccountManagementService.Verify(x => x.UploadAvatar(args.LoggedUserUserName, args.UserAvatarUrl), Times.Never());
        }

        [TestCase(1 * 1000 * 1000, "image/jpg")]
        [TestCase(5 * 1000 * 1000, "image/png")]
        public void SetCorrectErrorMessage_WhenExceptionIsThrowsException(int validContentLength, string validContentType)
        {
            var mockedAvatarUploadView = new Mock<IAvatarUploadView>();
            var mockedAccountManagementService = new Mock<IAccountManagementService>();

            var mockedModel = new AvatarUploadModel();
            mockedAvatarUploadView.Setup(x => x.Model).Returns(mockedModel);

            var avatarUploadPresenter = new AvatarUploadPresenter(mockedAvatarUploadView.Object, mockedAccountManagementService.Object);
            var mockedFile = new Mock<HttpPostedFileBase>();
            mockedFile.SetupGet(x => x.ContentType).Returns(validContentType);
            mockedFile.SetupGet(x => x.ContentLength).Returns(validContentLength);

            var args = new AvatarUploadEventArgs()
            {
                PostedFile = mockedFile.Object,
                LoggedUserUserName = "User1",
                UserAvatarUrl = "~/path",
                AvatarStorateLocation = "/random"
            };

            mockedFile.Setup(x => x.SaveAs(args.AvatarStorateLocation)).Throws(new Exception());

            mockedAvatarUploadView.Raise(x => x.EventUploadAvatar += null, args);

            var expectedMessage = "Моля, опитайте отново!";

            Assert.AreSame(expectedMessage, mockedAvatarUploadView.Object.Model.StatusMessage);
        }
    }
}
