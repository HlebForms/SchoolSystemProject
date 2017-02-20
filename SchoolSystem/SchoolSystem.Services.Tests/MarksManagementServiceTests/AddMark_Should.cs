using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.MarksManagementServiceTests
{
    [TestFixture]
    public class AddMark_Should
    {
        [Test]
        public void Add_Mark_Correctly_To_Existing_SubjectStudent()
        {
            var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
            var mockedMarksRepo = new Mock<IRepository<Mark>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new MarksManagementService(
                          mockedSubjectStudentRepo.Object,
                          mockedMarksRepo.Object,
                          () => mockedUnitOfWork.Object);

            var subjStudent1 = new SubjectStudent { Count = 0, SubjectId = 1, MarkId = 1, StudentId = "id1" };
            var subjStudent2 = new SubjectStudent { Count = 0, SubjectId = 2, MarkId = 2, StudentId = "id2" };
            var subjStudent3 = new SubjectStudent { Count = 0, SubjectId = 3, MarkId = 3, StudentId = "id3" };

            var subjectStudent = new List<SubjectStudent>()
            {
                subjStudent1,
                subjStudent2,
                subjStudent3
            };

            var expected = 1;

            mockedUnitOfWork.Setup(x => x.Commit());
            mockedSubjectStudentRepo
                  .Setup(x => x.GetFirst(It.IsAny<Expression<Func<SubjectStudent, bool>>>()))
                  .Returns((Expression<Func<SubjectStudent, bool>> predicate) =>
                        subjectStudent.FirstOrDefault(predicate.Compile()));

            service.AddMark("id1", 1, 1);

            Assert.AreEqual(expected, subjStudent1.Count);
        }

        [Test]
        public void Call_UnitOfWork_Commit_Method_Once_When_ThereIsExistingSubjectstudent()
        {
            var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
            var mockedMarksRepo = new Mock<IRepository<Mark>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new MarksManagementService(
                          mockedSubjectStudentRepo.Object,
                          mockedMarksRepo.Object,
                          () => mockedUnitOfWork.Object);

            var subjStudent1 = new SubjectStudent { Count = 0, SubjectId = 1, MarkId = 1, StudentId = "id1" };
            var subjStudent2 = new SubjectStudent { Count = 0, SubjectId = 2, MarkId = 2, StudentId = "id2" };
            var subjStudent3 = new SubjectStudent { Count = 0, SubjectId = 3, MarkId = 3, StudentId = "id3" };

            var subjectStudent = new List<SubjectStudent>()
            {
                subjStudent1,
                subjStudent2,
                subjStudent3
            };

            mockedUnitOfWork.Setup(x => x.Commit());
            mockedSubjectStudentRepo
                  .Setup(x => x.GetFirst(It.IsAny<Expression<Func<SubjectStudent, bool>>>()))
                  .Returns((Expression<Func<SubjectStudent, bool>> predicate) =>
                        subjectStudent.FirstOrDefault(predicate.Compile()));

            service.AddMark("id1", 1, 1);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void Add_Mark_Correctly_To_Unexisting_SubjectStudent()
        {
            var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
            var mockedMarksRepo = new Mock<IRepository<Mark>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new MarksManagementService(
                          mockedSubjectStudentRepo.Object,
                          mockedMarksRepo.Object,
                          () => mockedUnitOfWork.Object);

            var subjStudent1 = new SubjectStudent { Count = 0, SubjectId = 1, MarkId = 1, StudentId = "id1" };
            var subjStudent2 = new SubjectStudent { Count = 0, SubjectId = 2, MarkId = 2, StudentId = "id2" };
            var subjStudent3 = new SubjectStudent { Count = 0, SubjectId = 3, MarkId = 3, StudentId = "id3" };

            var subjectStudent = new List<SubjectStudent>()
            {
                subjStudent1,
                subjStudent2,
                subjStudent3
            };

            var expected = 4;

            mockedUnitOfWork.Setup(x => x.Commit());
            mockedSubjectStudentRepo
                  .Setup(x => x.GetFirst(It.IsAny<Expression<Func<SubjectStudent, bool>>>()))
                  .Returns((Expression<Func<SubjectStudent, bool>> predicate) =>
                        subjectStudent.FirstOrDefault(predicate.Compile()));
            mockedSubjectStudentRepo
                  .Setup(x => x.Add(It.IsAny<SubjectStudent>()))
                  .Callback((SubjectStudent predicate) =>
                        subjectStudent.Add(predicate));
            
            service.AddMark("id4", 1, 1);

            Assert.AreEqual(expected, subjectStudent.Count());
        }

        [Test]
        public void Call_UnitOfWork_Commit_Method_Once_When_ThereIsUnexistingSubjectstudent()
        {
            var mockedSubjectStudentRepo = new Mock<IRepository<SubjectStudent>>();
            var mockedMarksRepo = new Mock<IRepository<Mark>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var service = new MarksManagementService(
                          mockedSubjectStudentRepo.Object,
                          mockedMarksRepo.Object,
                          () => mockedUnitOfWork.Object);

            var subjStudent1 = new SubjectStudent { Count = 0, SubjectId = 1, MarkId = 1, StudentId = "id1" };
            var subjStudent2 = new SubjectStudent { Count = 0, SubjectId = 2, MarkId = 2, StudentId = "id2" };
            var subjStudent3 = new SubjectStudent { Count = 0, SubjectId = 3, MarkId = 3, StudentId = "id3" };

            var subjectStudent = new List<SubjectStudent>()
            {
                subjStudent1,
                subjStudent2,
                subjStudent3
            };

            mockedUnitOfWork.Setup(x => x.Commit());
            mockedSubjectStudentRepo
                  .Setup(x => x.GetFirst(It.IsAny<Expression<Func<SubjectStudent, bool>>>()))
                  .Returns((Expression<Func<SubjectStudent, bool>> predicate) =>
                        subjectStudent.FirstOrDefault(predicate.Compile()));
            mockedSubjectStudentRepo
                  .Setup(x => x.Add(It.IsAny<SubjectStudent>()))
                  .Callback((SubjectStudent predicate) => subjectStudent.Add(predicate));

            service.AddMark("id4", 1, 1);

            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
    }
}
