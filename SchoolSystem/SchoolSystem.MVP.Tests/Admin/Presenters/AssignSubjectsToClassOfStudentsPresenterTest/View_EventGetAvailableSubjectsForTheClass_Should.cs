using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.AssignSubjectsToClassOfStudentsPresenterTest
{
    [TestFixture]
    public class View_EventGetAvailableSubjectsForTheClass_Should
    {
        [Test]
        public void Set_Model_AvailableSubjects_Property_Correctly()
        {
            var mockedView = new Mock<IAssignSubjectsToClassOfStudentsView>();
            var mockedClassOfStudentManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new AssignSubjectsToClassOfStudentsModel();
            var args = new GetAvailableSubjectsForTheClassEventArgs();

            var expected = new List<SubjectBasicInfoModel>();

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedSubjectManagementService
                .Setup(x => x.GetSubjectsNotYetAssignedToTheClass(It.IsAny<int>()))
                .Returns(expected);

            var presenter = new AssignSubjectsToClassOfStudentsPresenter(
                  mockedView.Object,
                  mockedClassOfStudentManagementService.Object,
                  mockedSubjectManagementService.Object);

            mockedView.Raise(x => x.EventGetAvailableSubjectsForTheClass += null, args);

            CollectionAssert.AreEquivalent(expected, mockedView.Object.Model.AvailableSubjects);
        }
    }
}
