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
    public class RemoveSubjectFromSchedule_Should
    {
        [Test]
        public void Call_ScheduleService_RemoveSubjectFromSchedule_Method_Once()
        {
            var mockedView = new Mock<IManagingScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new ManagingScheduleControlModel();
            var args = new RemovingSubjectFromScheduleEventArgs();
            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedScheduleService.Setup(x => x.RemoveSubjectFromSchedule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()));

            var presenter = new ManagingSchedulePresenter(
                    mockedView.Object,
                    mockedScheduleService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedSubjectManagementService.Object
                 );

            mockedView.Raise(x => x.EventRemoveSubjectFromSchedule += null, args);

            mockedScheduleService.Verify(x => x.RemoveSubjectFromSchedule(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
    }
}
