using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.ManagingSchedulePresenterTests
{
    [TestFixture]
    public class GetAllClasses_Should
    {
        [Test]
        public void Set_Model_AllClassOfStudents_Property_Correctly()
        {
            var mockedView = new Mock<IManagingScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new ManagingScheduleControlModel();

            mockedView.SetupGet(x => x.Model).Returns(model);

            var presenter = new ManagingSchedulePresenter(
                    mockedView.Object,
                    mockedScheduleService.Object,
                    mockedClassOfStudentsManagementService.Object,
                    mockedSubjectManagementService.Object
                 );

            var expected = new List<ClassOfStudents>();

            mockedClassOfStudentsManagementService
               .Setup(x => x.GetAllClasses())
               .Returns(expected);

            mockedView.Raise(x => x.EventBindAllClasses += null, EventArgs.Empty);

            Assert.AreEqual(expected, mockedView.Object.Model.AllClassOfStudents);
        }
    }
}
