using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models;
using SchoolSystem.MVP.Teacher.Models;
using SchoolSystem.MVP.Teacher.Presenters;
using SchoolSystem.MVP.Teacher.Views;
using SchoolSystem.MVP.Teacher.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Teacher.Presenters.ManagingMarksPresenterTests
{
    [TestFixture]
    public class View_EventBindClasses_Should
    {
        [Test]
        public void BindStudentClasses_ToModel_WhenArgumentsAreValid()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            var subjectId = It.IsAny<int>();

            mockedManagingMarksView
                .SetupGet(x => x.Model)
                .Returns(new ManagingMarksModel());

            var expectedClasses = new List<ClassOfStudents>()
            {
                new ClassOfStudents(),
                new ClassOfStudents(),
                new ClassOfStudents()
            };

            mockedClassOfStudentsManagementService
                .Setup(x => x.GetAllClassesWithSpecifiedSubject(subjectId))
                .Returns(expectedClasses);

            var managingMarksPrseenter = new ManagingMarksPresenter(
                mockedManagingMarksView.Object,
               mockedSubjectManagementService.Object,
               mockedClassOfStudentsManagementService.Object,
               mockedStudentManagementService.Object,
               mockedMarkManagementService.Object);

            var args = new BindClassesEventArgs()
            {
                SubjectId = subjectId
            };

            mockedManagingMarksView.Raise(x => x.EventBindClasses += null, args);

            CollectionAssert.AreEquivalent(expectedClasses, mockedManagingMarksView.Object.Model.StudentClasses);
        }
    }
}
