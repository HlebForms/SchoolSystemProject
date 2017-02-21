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

namespace SchoolSystem.Services.Tests.SubjectManagementServiceTests
{
    [TestFixture]
    public class AddSubjectsToTeacher_Should
    {
        [Test]
        public void ThrowArgumentNullException_WithMessageContainingTeacherId_WhenTeacheIdIsNUll()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            Assert.That(() => subjectsManagementService.AddSubjectsToTeacher(null, new List<int>()),
                Throws.ArgumentNullException.With.Message.Contain("teacherId"));
        }

        [Test]
        public void ThrowArgumentException_WithMessageContainingTeacherId_WhenTeacheIdIsEmpty()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            Assert.That(() => subjectsManagementService.AddSubjectsToTeacher(string.Empty, new List<int>()),
                Throws.ArgumentException.With.Message.Contain("teacherId"));
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContainingSubjectIds_WhenSubjectIdsAreNull()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            Assert.That(() => subjectsManagementService.AddSubjectsToTeacher("TeacherName", null),
                Throws.ArgumentNullException.With.Message.Contain("subjectIds"));
        }

        [Test]
        public void ReturnFalse_WhenSubjectsToBeAddedHaveTeacher()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>();

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow.Object);

            var subjectIds = new List<int> { 1, 2, 3 };
            var teacherId = "teacherId";
            var data = new List<Subject>()
            {
                new Subject() {Id = 1, TeacherId = "Teacher1" },
                new Subject() {Id = 2, TeacherId = "Teacher1" },
                new Subject() {Id = 3, TeacherId = "Teacher1" }
            };


            IEnumerable<Subject> subjectToAddTeacherTo = null;
            mockedSubjectRepo.Setup(
                x => x.GetAll(
                    It.IsAny<Expression<Func<Subject, bool>>>(),
                    It.IsAny<Expression<Func<Subject, Subject>>>())).
                    Returns((Expression<Func<Subject, bool>> predicate,
                    Expression<Func<Subject, Subject>> select) =>
                    subjectToAddTeacherTo = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
                    );

            var result = subjectsManagementService.AddSubjectsToTeacher(teacherId, subjectIds);

            Assert.IsFalse(result);
            mockedUow.Verify(x => x.Commit(), Times.Never());
        }

        [Test]
        public void ReturnTrue_WhenSubjectsAreAssignedCorectly()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>();
            mockedUow.Setup(x => x.Commit()).Returns(true);

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow.Object);

            var subjectIds = new List<int> { 1, 2, 3 };
            var teacherId = "teacherId";
            var data = new List<Subject>()
            {
                new Subject() {Id = 1 },
                new Subject() {Id = 2 },
                new Subject() {Id = 3 }
            };

            IEnumerable<Subject> subjectToAddTeacherTo = null;
            mockedSubjectRepo.Setup(
                x => x.GetAll(
                    It.IsAny<Expression<Func<Subject, bool>>>(),
                    It.IsAny<Expression<Func<Subject, Subject>>>())).
                    Returns((Expression<Func<Subject, bool>> predicate,
                    Expression<Func<Subject, Subject>> select) =>
                    subjectToAddTeacherTo = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
                    );

            var result = subjectsManagementService.AddSubjectsToTeacher(teacherId, subjectIds);

            Assert.True(result);
            mockedUow.Verify(x => x.Commit(), Times.Once());
        }
    }
}
