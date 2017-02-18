using System.Web;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.CreatingSubjectPresenterTests
{
    [TestFixture]
    public class CreateSubject_Should
    {
        [Test]
        public void Call_SaveAs_Method_FromTheFile_Once()
        {
            var mockedView = new Mock<ICreatingSubjectView>();
            var mockedsubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new CreatingSubjcetModel();
            var mockedAvatarFile = new Mock<HttpPostedFileBase>();

            var args = new CreatingSubjectEventArgs()
            {
                AvatarFile = mockedAvatarFile.Object,
                SubjectPictureStoragePath = "store path"
            };

            var presenter = new CreatingSubjectPresenter(
                 mockedView.Object,
                 mockedsubjectManagementService.Object);

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedsubjectManagementService
                .Setup(x => x.CreateSubject(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(It.IsAny<bool>);

            mockedView.Raise(x => x.EventCreateSubject += null, args);

            mockedAvatarFile.Verify(x => x.SaveAs(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void Set_Model_IsSuccesfull_Property_Correctly()
        {
            var mockedView = new Mock<ICreatingSubjectView>();
            var mockedsubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new CreatingSubjcetModel();
            var mockedAvatarFile = new Mock<HttpPostedFileBase>();

            var args = new CreatingSubjectEventArgs()
            {
                AvatarFile = mockedAvatarFile.Object,
                SubjectPictureStoragePath = "store path"
            };

            var presenter = new CreatingSubjectPresenter(
                 mockedView.Object,
                 mockedsubjectManagementService.Object);

            var expected = true;

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedsubjectManagementService
                .Setup(x => x.CreateSubject(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(expected);

            mockedView.Raise(x => x.EventCreateSubject += null, args);

            Assert.AreEqual(expected, mockedView.Object.Model.IsSuccesfull);
        }
    }
}
