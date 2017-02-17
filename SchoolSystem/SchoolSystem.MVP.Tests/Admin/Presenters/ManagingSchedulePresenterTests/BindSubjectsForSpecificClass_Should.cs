using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
using System.Collections.Generic;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.ManagingSchedulePresenterTests
{
    [TestFixture]
    public class BindSubjectsForSpecificClass_Should
    {
        [Test]
        public void Set_Mode_SubjectForCurrentClass_Property_Correctly()
        {
            var mockedView = new Mock<IManagingScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new ManagingScheduleControlModel();
            var args = new BindSubjectsForClassEventArgs();

            mockedView.SetupGet(x => x.Model).Returns(model);

            var presenter = new ManagingSchedulePresenter(
                    mockedView.Object,
                    mockedScheduleService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedSubjectManagementService.Object
                 );

            var expected = new List<Subject>();

            mockedSubjectManagementService
               .Setup(x => x.GetAllSubjectsAlreadyAssignedToTheClass(It.IsAny<int>()))
               .Returns(expected);

            mockedView.Raise(x => x.EventBitSubjectForCurrentClass += null, args);

            Assert.AreEqual(expected, mockedView.Object.Model.SubjectForCurrentClass);
        }
    }
}
