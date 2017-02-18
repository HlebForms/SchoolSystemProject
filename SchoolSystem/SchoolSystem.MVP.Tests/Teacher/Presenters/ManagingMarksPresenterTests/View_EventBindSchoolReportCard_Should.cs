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
    public class View_EventBindSchoolReportCard_Should
    {
        [Test]
        public void BindSchoolReportCard_ToModelCorectly_WhenArgumentsAreValid()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            var subjectId = It.IsAny<int>();
            var classId = It.IsAny<int>();

            mockedManagingMarksView
                .SetupGet(x => x.Model)
                .Returns(new ManagingMarksModel());

            var expectedReportCard = new List<SchoolReportCardModel>()
            {
                new SchoolReportCardModel(),
                new SchoolReportCardModel(),
                new SchoolReportCardModel()
            };

            mockedMarkManagementService
                .Setup(x => x.GetMarks(subjectId, classId))
                .Returns(expectedReportCard);

            var managingMarksPrseenter = new ManagingMarksPresenter(
                mockedManagingMarksView.Object,
               mockedSubjectManagementService.Object,
               mockedClassOfStudentsManagementService.Object,
               mockedStudentManagementService.Object,
               mockedMarkManagementService.Object
               );

            var args = new BindSchoolReportCardEventArgs()
            {
                SubjectId = subjectId,
                ClassOfStudentsId = classId
            };

            mockedManagingMarksView.Raise(x => x.EventBindSchoolReportCard += null, args);

            CollectionAssert.AreEquivalent(expectedReportCard, mockedManagingMarksView.Object.Model.SchoolReportCard);
        }
    }
}
