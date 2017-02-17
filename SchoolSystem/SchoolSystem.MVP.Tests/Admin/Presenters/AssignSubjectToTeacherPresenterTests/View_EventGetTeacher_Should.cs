using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.AssignSubjectToTeacherPresenterTests
{
    [TestFixture]
    public class View_EventGetTeacher_Should
    {
        [Test]
        public void Set_Model_Teachers_Property_Correctly()
        {
            var mockedView = new Mock<IAssignSubjectToTeacherView>();
            var mockedTeacherManagementService = new Mock<ITeacherManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new AssignSubjectToTeacherModel();

            var expected = new List<TeacherBasicInfoModel>();

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedTeacherManagementService
                .Setup(x => x.GetAllTeachers())
                .Returns(expected);

            var presenter = new AssignSubjectToTeacherPresenter(
                mockedView.Object,
                mockedTeacherManagementService.Object,
                mockedSubjectManagementService.Object);

            mockedView.Raise(x => x.EventGetTeacher += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(expected, mockedView.Object.Model.Teachers);
        }
    }
}
