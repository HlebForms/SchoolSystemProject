using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Teacher.Presenters;
using SchoolSystem.MVP.Teacher.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Teacher.Presenters.ManagingMarksPresenterTests
{
    [TestFixture]
    public class Consturctor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContainsSubjectManagementService_WhenSubjectManagementServiceIsNull()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();

            Assert.That(
                () => new ManagingMarksPresenter(
                mockedManagingMarksView.Object,
                null,
                mockedClassOfStudentsManagementService.Object,
                mockedStudentManagementService.Object,
                mockedMarkManagementService.Object),
                Throws.ArgumentNullException.With.Message.Contain("subjectManagementService"));
        }

        [Test]
        public void Throw_ArgumentNullException_WithMessageContainsClassOfStudentsManagementService_WhenClassOfStudentsManagementServiceIsNull()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();

            Assert.That(
                () => new ManagingMarksPresenter(
                mockedManagingMarksView.Object,
                mockedSubjectManagementService.Object,
                null,
                mockedStudentManagementService.Object,
                mockedMarkManagementService.Object),
                Throws.ArgumentNullException.With.Message.Contain("classOfStudentsManagementService"));
        }

        [Test]
        public void Throw_ArgumentNullException_WithMessageContainsMarksManagementService_WhenMarksManagementServiceIsNull()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            Assert.That(
                () => new ManagingMarksPresenter(
                mockedManagingMarksView.Object,
                mockedSubjectManagementService.Object,
                mockedClassOfStudentsManagementService.Object,
                mockedStudentManagementService.Object,
                null),
                Throws.ArgumentNullException.With.Message.Contain("marksManagementService"));
        }

        [Test]
        public void Throw_ArgumentNullException_WithMessageContainsStudentManagementService_WhenStudentManagementServiceIsNull()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();

            Assert.That(
                () => new ManagingMarksPresenter(
                mockedManagingMarksView.Object,
                mockedSubjectManagementService.Object,
                mockedClassOfStudentsManagementService.Object,
                null,
                mockedMarkManagementService.Object),
                Throws.ArgumentNullException.With.Message.Contain("studentManagementService"));
        }

        [Test]
        public void NotThrow_WhenAllArgumentsArevalid()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            Assert.DoesNotThrow(() => new ManagingMarksPresenter(
                 mockedManagingMarksView.Object,
                mockedSubjectManagementService.Object,
                mockedClassOfStudentsManagementService.Object,
                mockedStudentManagementService.Object,
                mockedMarkManagementService.Object));
        }
    }
}
