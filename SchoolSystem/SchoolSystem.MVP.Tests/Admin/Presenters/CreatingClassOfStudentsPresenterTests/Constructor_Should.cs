using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.CreatingClassOfStudentsPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_ClassOfStudentsManagementService_IsNull()
        {
            var mockedView = new Mock<ICreatingClassOfStudentsView>();

            // var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var ex = Assert.Throws<ArgumentNullException>(
                () => new CreatingClassOfStudentsPresenter(
                mockedView.Object,
                null,
                mockedSubjectManagementService.Object));

            Assert.That(ex.ParamName, Is.EqualTo("classOfStudentsManagementService"));
        }

        [Test]
        public void Throw_When_SubjectManagementService_IsNull()
        {
            var mockedView = new Mock<ICreatingClassOfStudentsView>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();

            // var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var ex = Assert.Throws<ArgumentNullException>(() => new CreatingClassOfStudentsPresenter(
                mockedView.Object,
                mockedClassOfStudentsManagementService.Object,
                null));

            Assert.That(ex.ParamName, Is.EqualTo("subjectManagementService"));
        }
    }
}
