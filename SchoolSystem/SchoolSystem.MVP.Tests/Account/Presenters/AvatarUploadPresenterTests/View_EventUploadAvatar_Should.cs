using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.MVP.Account.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SchoolSystem.MVP.Tests.Account.Presenters.AvatarUploadPresenterTests
{
    [TestFixture]
    public class View_EventUploadAvatar_Should
    {
        [TestCase("image/g3fax")]
        [TestCase("image/gif")]
        [TestCase("image/ief")]
        [TestCase("image/tiff")]
        public void ShouldNotCallSaveAsMethodFromTheFile_WhenContentTypesAreInvalid(string contentType)
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

            mockedFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Never());
        }

        [TestCase("image/jpg")]
        [TestCase("image/png")]
        [TestCase("image/jpeg")]
        public void ShouldCallSaveAsMethodFromTheFile_Once_WhenContentTypesAreValid(string contentType)
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

            mockedFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Once());
        }
    }
}
