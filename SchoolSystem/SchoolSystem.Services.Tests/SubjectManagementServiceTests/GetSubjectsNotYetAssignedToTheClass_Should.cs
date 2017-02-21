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
    public class GetSubjectsNotYetAssignedToTheClass_Should
    {
        [Test]
        public void ReturnCollecionOfSubjectsThatCorespondsToTheClass_AndAreNotAssignedToItYet_AndTeachersInThemAreNotNull()
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

            var data = new List<SubjectClassOfStudents>();

            IEnumerable<int> alreadyassigndedSubjectIds = new List<int>();

            mockedSubjClassRepo.Setup(x =>
                x.GetAll(It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, int>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, object>>[]>()))
                .Returns((Expression<Func<SubjectClassOfStudents, bool>> predicate,
                          Expression<Func<SubjectClassOfStudents, int>> select,
                          Expression<Func<SubjectClassOfStudents, object>>[] include) =>
                    alreadyassigndedSubjectIds = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
                    );

            var subjects = new List<Subject>()
            {
                new Subject() { Id = 1, Name = "Subj1" ,TeacherId = null},
                new Subject() { Id = 3, Name = "Subj3", TeacherId = "SomeId"},
                new Subject() { Id = 2, Name = "Subj2", TeacherId = "SomeId1"}
            };

            IEnumerable<SubjectBasicInfoModel> expected = null;

            mockedSubjectRepo.Setup(x =>
               x.GetAll(It.IsAny<Expression<Func<Subject, bool>>>(),
               It.IsAny<Expression<Func<Subject, SubjectBasicInfoModel>>>()))
               .Returns((Expression<Func<Subject, bool>> predicate,
                         Expression<Func<Subject, SubjectBasicInfoModel>> select) =>
                   expected = subjects.Where(predicate.Compile()).Select(select.Compile()).ToList()
                   );

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService.GetSubjectsNotYetAssignedToTheClass(classId);

            CollectionAssert.AreEquivalent(expected, result);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void ReturnEmptyCollection_WhenThereAreNotSubjectsAvaiableToAssignForThisClass()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var classId = 1;
            var classOfStudents = new ClassOfStudents() { Id = classId, Name = "classOfStudents" };
            var subject = new Subject() { Id = 1, Name = "Subj1" };

            var subjects = new List<Subject>()
            {
               subject
            };

            var data = new List<SubjectClassOfStudents>();
            {
                new SubjectClassOfStudents() { SubjectId = subject.Id, ClassOfStudentsId = classId };
            };

            subject.SubjecClassOfStudents = data;

            IEnumerable<int> alreadyassigndedSubjectIds = null;

            mockedSubjClassRepo.Setup(x =>
                x.GetAll(It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, int>>>(),
                It.IsAny<Expression<Func<SubjectClassOfStudents, object>>[]>()))
                .Returns((Expression<Func<SubjectClassOfStudents, bool>> predicate,
                          Expression<Func<SubjectClassOfStudents, int>> select) =>
                    alreadyassigndedSubjectIds = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
                    );

            IEnumerable<SubjectBasicInfoModel> expected = null;

            mockedSubjectRepo.Setup(x =>
               x.GetAll(It.IsAny<Expression<Func<Subject, bool>>>(),
               It.IsAny<Expression<Func<Subject, SubjectBasicInfoModel>>>()))
               .Returns((Expression<Func<Subject, bool>> predicate,
                         Expression<Func<Subject, SubjectBasicInfoModel>> select) =>
                   expected = subjects.Where(predicate.Compile()).Select(select.Compile()).ToList()
                   );

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService.GetSubjectsNotYetAssignedToTheClass(classId);

            CollectionAssert.AreEquivalent(expected, result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
