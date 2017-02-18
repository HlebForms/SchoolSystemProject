using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Teacher.Models;
using SchoolSystem.MVP.Teacher.Presenters;
using SchoolSystem.MVP.Teacher.Views;
using SchoolSystem.MVP.Teacher.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Teacher.Presenters.ManagingMarksPresenterTests
{
    [TestFixture]
    public class View_EventInsertMark_Should
    {
        [Test]
        public void Call_AddMarkMethodWithCorectParams()
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            mockedManagingMarksView
                .SetupGet(x => x.Model)
                .Returns(new ManagingMarksModel());

            var managingMarksPrseenter = new ManagingMarksPresenter(
                mockedManagingMarksView.Object,
               mockedSubjectManagementService.Object,
               mockedClassOfStudentsManagementService.Object,
               mockedStudentManagementService.Object,
               mockedMarkManagementService.Object
               );

            var args = new InserMarkEventArgs()
            {
                MarkId = It.IsAny<int>(),
                StudentId = It.IsNotNull<string>(),
                SubjectId = It.IsAny<int>()
            };

            mockedManagingMarksView.Raise(x => x.EventInsertMark += null, args);

            mockedMarkManagementService
                .Verify(x => x.AddMark(args.StudentId, args.SubjectId, args.MarkId),
                    Times.Once());
        }

        [TestCase("random", 1, 1)]
        [TestCase("alabala", 2, 2)]
        [TestCase("some-str", 3, 3)]
        public void NotCall_AddMarkMethodWithIncorectParams(string notFromEventArgsStudentId, int notFromEventArgsSubjectId, int notFromEventArgsMarkId)
        {
            var mockedManagingMarksView = new Mock<IManagingMarksView>();
            var mockedSubjectManagementService = new Mock<ISubjectManagementService>();
            var mockedClassOfStudentsManagementService = new Mock<IClassOfStudentsManagementService>();
            var mockedMarkManagementService = new Mock<IMarksManagementService>();
            var mockedStudentManagementService = new Mock<IStudentManagementService>();

            mockedManagingMarksView
                .SetupGet(x => x.Model)
                .Returns(new ManagingMarksModel());

            var managingMarksPrseenter = new ManagingMarksPresenter(
                mockedManagingMarksView.Object,
               mockedSubjectManagementService.Object,
               mockedClassOfStudentsManagementService.Object,
               mockedStudentManagementService.Object,
               mockedMarkManagementService.Object
               );

            var args = new InserMarkEventArgs()
            {
                MarkId = It.IsAny<int>(),
                StudentId = It.IsNotNull<string>(),
                SubjectId = It.IsAny<int>()
            };

            mockedManagingMarksView.Raise(x => x.EventInsertMark += null, args);

            mockedMarkManagementService
                .Verify(x => x.AddMark(notFromEventArgsStudentId, notFromEventArgsSubjectId, notFromEventArgsMarkId),
                    Times.Never());
        }
    }
}
