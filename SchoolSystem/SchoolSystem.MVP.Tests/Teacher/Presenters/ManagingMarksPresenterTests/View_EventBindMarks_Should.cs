using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models;
using SchoolSystem.MVP.Teacher.Models;
using SchoolSystem.MVP.Teacher.Presenters;
using SchoolSystem.MVP.Teacher.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Teacher.Presenters.ManagingMarksPresenterTests
{
    [TestFixture]
    public class View_EventBindMarks_Should
    {
        [Test]
        public void BindAllMarks_ToModelCorectly()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            var expectedMarks = new List<Mark>()
            {
                new Mark(),
                new Mark(),
                new Mark()
            };

            mockedManagingMarksView
                .SetupGet(x => x.Model)
                .Returns(new ManagingMarksModel());

            mockedMarkManagementService
                .Setup(x => x.GetAllMarks())
                .Returns(expectedMarks);

            var managingMarksPrseenter = new ManagingMarksPresenter(
                 mockedManagingMarksView.Object,
                mockedSubjectManagementService.Object,
                mockedClassOfStudentsManagementService.Object,
                mockedStudentManagementService.Object,
                mockedMarkManagementService.Object
                );

            mockedManagingMarksView.Raise(x => x.EventBindMarks += null, EventArgs.Empty);

            CollectionAssert.AreEquivalent(expectedMarks, mockedManagingMarksView.Object.Model.Marks);
        }
    }
}
