using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.Data.Models.CustomModels;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.ManagingSchedulePresenterTests
{
    [TestFixture]
    public class BindScheduleData_Should
    {
        [Test]
        public void Set_Model_CurrentSchedule_Property_Correctly()
        {
            var mockedView = new Mock<IManagingScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new ManagingScheduleControlModel();
            var args = new ManagingScheduleEventArgs()
            {
                ClassId = 1,
                DayOfWeekId = 2
            };

            mockedView.SetupGet(x => x.Model).Returns(model);

            var presenter = new ManagingSchedulePresenter(
                    mockedView.Object,
                    mockedScheduleService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedSubjectManagementService.Object
                 );

            var expected = new List<ManagingScheduleModel>();

            mockedScheduleService
               .Setup(x => x.GetSchedulePerDay(It.IsAny<int>(), It.IsAny<int>()))
               .Returns(expected);


            mockedView.Raise(x => x.EventBindScheduleData += null, args);

            Assert.AreEqual(expected, mockedView.Object.Model.CurrentSchedule);
        }
    }
}
