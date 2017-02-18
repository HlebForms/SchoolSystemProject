using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.MVP.Student.Models;
using SchoolSystem.MVP.Student.Presenters;
using SchoolSystem.MVP.Student.Views;
using SchoolSystem.MVP.Student.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Student.Presenters.SchoolReportCardPresenterTests
{
    [TestFixture]
    public class View_EvenGetStudentMarks_Should
    {
        [Test]
        public void BindCorrectDataToTheModel_WhenArgumentsAreValuid()
        {
            var mockedSchoolReportCardView = new Mock<ISchoolReporCardView>();
            var mockedMarksManagemetService = new Mock<IMarksManagementService>();

            var studentName = "User1";
            var expectedMarks = new List<StudentMarksModel>()
            {
                new StudentMarksModel(),
                new StudentMarksModel(),
                new StudentMarksModel()
            };

            var mockedModel = new SchoolReportCardViewModel();

            mockedSchoolReportCardView
                .SetupGet(x => x.Model)
                .Returns(mockedModel);

            mockedMarksManagemetService
                .Setup(x => x.GetMarksForStudent(studentName))
                .Returns(expectedMarks);

            var schoolReportCardPresenter = new SchoolReportCardPreseneter(mockedSchoolReportCardView.Object, mockedMarksManagemetService.Object);

            var args = new GetStudentMarksEventArgs()
            {
                StudentName = studentName,
            };

            mockedSchoolReportCardView.Raise(x => x.EvenGetStudentMarks += null, args);

            CollectionAssert.AreEquivalent(expectedMarks, mockedSchoolReportCardView.Object.Model.StudentMarks);
        }
    }
}
