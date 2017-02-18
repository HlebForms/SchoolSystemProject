using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.AssignSubjectToTeacherPresenterTests
{
    [TestFixture]
    public class View_EventAssignSubjectsToTeacher_Should
    {
        [Test]
        public void Set_Model_IsAddingSuccessfull_Property_Correctly()
        {
            var mockedView = new Mock<IAssignSubjectToTeacherView>();
            var mockedTeacherManagementService = new Mock<ITeacherManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new AssignSubjectToTeacherModel();
            var args = new AssignSubjectsToTeacherEventArgs();

            var expected = true;

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedSubjectManagementService
                .Setup(x => x.AddSubjectsToTeacher(It.IsAny<string>(), It.IsAny<List<int>>()))
                .Returns(expected);

            var presenter = new AssignSubjectToTeacherPresenter(
                  mockedView.Object,
                  mockedTeacherManagementService.Object,
                  mockedSubjectManagementService.Object);

            mockedView.Raise(x => x.EventAssignSubjectsToTeacher += null, args);

            Assert.AreEqual(expected, mockedView.Object.Model.IsAddingSuccessfull);
        }
    }
}
