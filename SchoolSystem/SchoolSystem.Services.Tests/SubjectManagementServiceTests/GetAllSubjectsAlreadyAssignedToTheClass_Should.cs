using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.SubjectManagementServiceTests
{
    [TestFixture]
    public class GetAllSubjectsAlreadyAssignedToTheClass_Should
    {
        [Test]
        public void CallGetAllWithIdOfTheClass_Once_AndReturnCorectResult()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var classId = 1;
            var subjectId = 1;
            var subject = new Subject()
            {
                TeacherId = "NotNull",
                Id = subjectId
            };

            var data = new List<SubjectClassOfStudents>()
            {
                new SubjectClassOfStudents()
                {
                    ClassOfStudentsId = classId,
                    Subject = subject
                }
            };

            IEnumerable<Subject> expected = null;

            mockedSubjClassRepo.Setup(x =>
            x.GetAll(It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(),
            It.IsAny<Expression<Func<SubjectClassOfStudents, Subject>>>(),
            It.IsAny<Expression<Func<SubjectClassOfStudents, object>>[]>()))
            .Returns((Expression<Func<SubjectClassOfStudents, bool>> predicate,
                      Expression<Func<SubjectClassOfStudents, Subject>> select,
                      Expression<Func<SubjectClassOfStudents, object>>[] include) =>
                expected = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
                );

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService
                  .GetAllSubjectsAlreadyAssignedToTheClass(classId);

            mockedSubjClassRepo.Verify(
                x => x.GetAll(
                It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, Subject>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, object>>>()),
                Times.Once);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void CallGetAllWithIdOfTheClass_Once_AndReturnEmptyCollection_WhenTheSubjectsDoNotHaveTeacher()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var classId = 1;
            var subjectId = 1;
            var subject = new Subject()
            {
                Id = subjectId
            };

            var data = new List<SubjectClassOfStudents>()
            {
                new SubjectClassOfStudents()
                {
                    ClassOfStudentsId = classId,
                    Subject = subject
                }
            };

            IEnumerable<Subject> expected = null;

            mockedSubjClassRepo.Setup(x =>
            x.GetAll(It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(),
            It.IsAny<Expression<Func<SubjectClassOfStudents, Subject>>>(),
            It.IsAny<Expression<Func<SubjectClassOfStudents, object>>[]>()))
            .Returns((Expression<Func<SubjectClassOfStudents, bool>> predicate,
                      Expression<Func<SubjectClassOfStudents, Subject>> select,
                      Expression<Func<SubjectClassOfStudents, object>>[] include) =>
                expected = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
                );

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService
                  .GetAllSubjectsAlreadyAssignedToTheClass(classId);

            mockedSubjClassRepo.Verify(
                x => x.GetAll(
                It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, Subject>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, object>>>()),
                Times.Once);

            Assert.AreEqual(0, result.Count());
            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
