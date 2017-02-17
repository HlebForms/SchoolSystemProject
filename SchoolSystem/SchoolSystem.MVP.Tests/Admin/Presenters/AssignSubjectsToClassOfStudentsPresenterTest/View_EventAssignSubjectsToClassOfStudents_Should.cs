using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Presenters;
using SchoolSystem.MVP.Admin.Views;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.MVP.Tests.Admin.Presenters.AssignSubjectsToClassOfStudentsPresenterTest
{
    [TestFixture]
    public class View_EventAssignSubjectsToClassOfStudents_Should
    {
        [Test]
        public void Set_Model_IsAddingSubjectsSuccesfull_Property_Correctly()
        {
            var mockedView = new Mock<IAssignSubjectsToClassOfStudentsView>();
            var mockedClassOfStudentManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();

            var model = new AssignSubjectsToClassOfStudentsModel();
            var args = new AssignSubjectsToClassOfStudentsEventArgs();

            mockedView.SetupGet(x => x.Model).Returns(model);
            mockedClassOfStudentManagementService
                .Setup(x => x.AddSubjectsToClass(It.IsAny<int>(), It.IsAny<List<int>>()))
                .Returns(true);

            var presenter = new AssignSubjectsToClassOfStudentsPresenter(
                  mockedView.Object,
                  mockedClassOfStudentManagementService.Object,
                  mockedSubjectManagementService.Object
            );

            mockedView.Raise(x => x.EventAssignSubjectsToClassOfStudents += null, args);

            var expected = true;

            Assert.AreEqual(expected, mockedView.Object.Model.IsAddingSubjectsSuccesfull);
        }
    }
}