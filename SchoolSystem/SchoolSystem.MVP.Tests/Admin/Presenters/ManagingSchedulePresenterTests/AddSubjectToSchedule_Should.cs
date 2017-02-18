using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.ManagingSchedulePresenterTests
{
    [TestFixture]
    public class AddSubjectToSchedule_Should
    {
        [Test]
        public void Set_Model_IsInsertingSuccessFull_Property_Correctly()
        {
            var mockedView = new Mock<IManagingScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new ManagingScheduleControlModel();
            var args = new AddingSubjectToScheduleEventArgs();

            mockedView.SetupGet(x => x.Model).Returns(model);

            var presenter = new ManagingSchedulePresenter(
                    mockedView.Object,
                    mockedScheduleService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedSubjectManagementService.Object);

            var expected = true;

            mockedScheduleService
               .Setup(x => x.AddSubjectToSchedule(
                   It.IsAny<int>(),
                   It.IsAny<int>(),
                   It.IsAny<int>(),
                   It.IsAny<DateTime>(),
                   It.IsAny<DateTime>()))
               .Returns(expected);

            mockedView.Raise(x => x.EventAddSubjectToSchedule += null, args);

            Assert.AreEqual(expected, mockedView.Object.Model.IsInsertingSuccessFull);
        }
    }
}
