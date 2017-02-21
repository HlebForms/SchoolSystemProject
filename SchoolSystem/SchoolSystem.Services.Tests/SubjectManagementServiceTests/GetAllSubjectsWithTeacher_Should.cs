using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.SubjectManagementServiceTests
{
    [TestFixture]
    public class GetAllSubjectsWithTeacher_Should
    {
        [Test]
        public void ReturnAllSubjects_WithTeacher()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            IEnumerable<SubjectBasicInfoModel> expected = null;
            var expectedCount = 2;

            var data = new List<Subject>()
            {
                new Subject() { Id = 1, Name = "Subj1" ,TeacherId = null},
                new Subject() { Id = 3, Name = "Subj3", TeacherId = "SomeId"},
                new Subject() { Id = 2, Name = "Subj2", TeacherId = "SomeId1"}
            };

            mockedSubjectRepo.Setup(x =>
            x.GetAll(It.IsAny<Expression<Func<Subject, bool>>>(), It.IsAny<Expression<Func<Subject, SubjectBasicInfoModel>>>()))
            .Returns((Expression<Func<Subject, bool>> predicate, Expression<Func<Subject, SubjectBasicInfoModel>> select) =>
                expected = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
            );

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService.GetAllSubjectsWithTeacher();

            CollectionAssert.AreEquivalent(expected, result);
            Assert.AreEqual(expectedCount, result.Count());
        }

        [Test]
        public void ReturnEmptyCollection_WhenThereAreNoSunjectsWithTeacher()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            IEnumerable<SubjectBasicInfoModel> expected = null;
            var expectedCount = 0;

            var data = new List<Subject>()
            {
                new Subject() { Id = 1, Name = "Subj1" ,TeacherId = null},
                new Subject() { Id = 3, Name = "Subj3", TeacherId = null},
                new Subject() { Id = 2, Name = "Subj2", TeacherId = null}
            };

            mockedSubjectRepo.Setup(x =>
            x.GetAll(It.IsAny<Expression<Func<Subject, bool>>>(), It.IsAny<Expression<Func<Subject, SubjectBasicInfoModel>>>()))
            .Returns((Expression<Func<Subject, bool>> predicate, Expression<Func<Subject, SubjectBasicInfoModel>> select) =>
                expected = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
            );

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService.GetAllSubjectsWithTeacher();

            CollectionAssert.AreEquivalent(expected, result);
            Assert.AreEqual(expectedCount, result.Count());
        }
    }
}
