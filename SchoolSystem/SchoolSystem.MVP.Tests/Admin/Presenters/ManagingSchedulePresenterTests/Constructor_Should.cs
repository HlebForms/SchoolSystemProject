using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.ManagingSchedulePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_When_ScheduleService_IsNull()
        {
            var mockedView = new Mock<IManagingScheduleView>();

            // var mockedScheduleService = new Mock<IScheduleDataService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ManagingSchedulePresenter(
                   mockedView.Object,
                   null,
                   mockedClassOfStudentsManagementService.Object,
                   mockedSubjectManagementService.Object));

            Assert.That(ex.ParamName, Is.EqualTo("scheduleService"));
        }

        [Test]
        public void Throw_When_ClassOfStudentsManagementService_IsNull()
        {
            var mockedView = new Mock<IManagingScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();

            // var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var ex = Assert.Throws<ArgumentNullException>(() => new ManagingSchedulePresenter(
                   mockedView.Object,
                   mockedScheduleService.Object,
                   null,
                   mockedSubjectManagementService.Object));

            Assert.That(ex.ParamName, Is.EqualTo("classOfStudentsManagementService"));
        }

        [Test]
        public void Throw_When_SubjectManagementService_IsNull()
        {
            var mockedView = new Mock<IManagingScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();

            // var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var ex = Assert.Throws<ArgumentNullException>(() => new ManagingSchedulePresenter(
                   mockedView.Object,
                   mockedScheduleService.Object,
                   mockedClassOfStudentsManagementService.Object,
                   null));

            Assert.That(ex.ParamName, Is.EqualTo("subjectManagementService"));
        }
    }
}
