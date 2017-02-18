using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Teacher.Models;
using SchoolSystem.MVP.Teacher.Presenters;
using SchoolSystem.MVP.Teacher.Views;
using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.MVP.Teacher.Views.EventArguments;

namespace SchoolSystem.MVP.Tests.Teacher.Presenters.ManagingMarksPresenterTests
{
    [TestFixture]
    public class View_EventBindStudents_Should
    {
        [Test]
        public void BindStudents_ToModelCorectly()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            var expectedStudents = new List<StudentInfoModel>()
            {
                new StudentInfoModel(),
                new StudentInfoModel(),
                new StudentInfoModel()
            };

            mockedManagingMarksView
                .SetupGet(x => x.Model)
                .Returns(new ManagingMarksModel());

            mockedStudentManagementService
                .Setup(x => x.GetAllStudentsFromClass(It.IsAny<int>()))
                .Returns(expectedStudents);

            var managingMarksPrseenter = new ManagingMarksPresenter(
                 mockedManagingMarksView.Object,
                mockedSubjectManagementService.Object,
                mockedClassOfStudentsManagementService.Object,
                mockedStudentManagementService.Object,
                mockedMarkManagementService.Object
                );

            var args = new BindStudentsEventArgs()
            {
                ClassId = It.IsAny<int>()
            };

            mockedManagingMarksView.Raise(x => x.EventBindStudents += null, args);

            CollectionAssert.AreEquivalent(expectedStudents, mockedManagingMarksView.Object.Model.Students);
        }
    }
}
