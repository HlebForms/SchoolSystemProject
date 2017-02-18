using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Teacher.Models;
using SchoolSystem.MVP.Teacher.Presenters;
using SchoolSystem.MVP.Teacher.Views;
using SchoolSystem.MVP.Teacher.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Teacher.Presenters.ManagingMarksPresenterTests
{
    [TestFixture]
    public class View_EventBindSubjects_Should
    {
        [Test]
        public void BindSubjectsForSpecifiedTeacher_ToModel_WhenArgumentsArevalid()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            var teacherName = It.IsAny<string>();

            var expectedSubjects = new List<SubjectBasicInfoModel>()
            {
                new SubjectBasicInfoModel(),
                new SubjectBasicInfoModel(),
                new SubjectBasicInfoModel()
            };

            mockedManagingMarksView
                .SetupGet(x => x.Model)
                .Returns(new ManagingMarksModel());

            mockedSubjectManagementService
                .Setup(x => x.GetSubjectsPerTeacher(teacherName))
                .Returns(expectedSubjects);

            var managingMarksPrseenter = new ManagingMarksPresenter(
                 mockedManagingMarksView.Object,
                mockedSubjectManagementService.Object,
                mockedClassOfStudentsManagementService.Object,
                mockedStudentManagementService.Object,
                mockedMarkManagementService.Object);

            var args = new BindSubjectsEventArgs()
            {
                TecherName = teacherName
            };

            mockedManagingMarksView.Raise(x => x.EventBindSubjectsForTheSelectedTeacher += null, args);

            CollectionAssert.AreEquivalent(expectedSubjects, mockedManagingMarksView.Object.Model.SubjectsForTheSpecifiedTeacher);
        }
    }
}
