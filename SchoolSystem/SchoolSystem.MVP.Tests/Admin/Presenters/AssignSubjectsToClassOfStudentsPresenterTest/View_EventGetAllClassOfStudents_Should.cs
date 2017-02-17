using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.AssignSubjectsToClassOfStudentsPresenterTest
{
    [TestFixture]
    public class View_EventGetAllClassOfStudents_Should
    {
        [Test]
        public void Set_Model_ClassOfStudents_Property_Correctly()
        {
            var mockedView = new Mock<IAssignSubjectsToClassOfStudentsView>();
            var mockedClassOfStudentManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new AssignSubjectsToClassOfStudentsModel();

            var expected = new List<ClassOfStudents>();

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedClassOfStudentManagementService
                .Setup(x => x.GetAllClasses())
                .Returns(expected);

            var presenter = new AssignSubjectsToClassOfStudentsPresenter(
                  mockedView.Object,
                  mockedClassOfStudentManagementService.Object,
                  mockedSubjectManagementService.Object
            );

            mockedView.Raise(x => x.EventGetAllClassOfStudents += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(expected, mockedView.Object.Model.ClassOfStudents);
        }
    }
}
