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
    public class GetSubjectsPerTeacher_Should
    {
        [Test]
        public void Return_SubjectsAssignedToTheTeacher_WhenThereAreAny()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var subjectId = 1;
            var teacherId = "teacherId";
            var teacherUserName = "TeacherUserName";

            var teacher = new Teacher()
            {
                User = new User() { Id = teacherId, UserName = teacherUserName }
            };

            var subject = new Subject()
            {
                Teacher = teacher,
                Id = subjectId,
                Name = "Subject1"
            };

            var data = new List<Subject>()
            {
                subject
            };

            IEnumerable<SubjectBasicInfoModel> expected = null;

            mockedSubjectRepo.Setup(x =>
                x.GetAll(It.IsAny<Expression<Func<Subject, bool>>>(),
                It.IsAny<Expression<Func<Subject, SubjectBasicInfoModel>>>(),
                It.IsAny<Expression<Func<Subject, object>>[]>()))
                .Returns((Expression<Func<Subject, bool>> predicate,
                          Expression<Func<Subject, SubjectBasicInfoModel>> select,
                          Expression<Func<Subject, object>>[] include) =>
                    expected = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
                    );

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService
                  .GetSubjectsPerTeacher(teacherUserName);

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void Return_EmtyCollecctionOfSubjectsAssignedToTheTeacher_WhenThereAreNone()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var teacherUserName = "TeacherUserName";

            var data = new List<Subject>();

            IEnumerable<SubjectBasicInfoModel> expected = null;

            mockedSubjectRepo.Setup(x =>
                x.GetAll(It.IsAny<Expression<Func<Subject, bool>>>(),
                It.IsAny<Expression<Func<Subject, SubjectBasicInfoModel>>>(),
                It.IsAny<Expression<Func<Subject, object>>[]>()))
                .Returns((Expression<Func<Subject, bool>> predicate,
                          Expression<Func<Subject, SubjectBasicInfoModel>> select,
                          Expression<Func<Subject, object>>[] include) =>
                    expected = data.Where(predicate.Compile()).Select(select.Compile()).ToList()
                    );

            var subjectsManagementService = new SubjectManagementService(mockedSubjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow);

            var result = subjectsManagementService
                  .GetSubjectsPerTeacher(teacherUserName);

            CollectionAssert.AreEquivalent(expected, result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
