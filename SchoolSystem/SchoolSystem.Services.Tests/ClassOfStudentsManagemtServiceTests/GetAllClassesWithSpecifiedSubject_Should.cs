using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.ClassOfStudentsManagemtServiceTests
{
    [TestFixture]
    public class GetAllClassesWithSpecifiedSubject_Should
    {
        [Test]
        public void Call_GetAllMethod_FromSubjectsClassOfStudentsRepo_Once_AndReturnCorrectResult()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);

            var subjectId = 1;

            var firstClassOofStudents = new ClassOfStudents() { Id = 1 };
            var secondClassOfStudents = new ClassOfStudents() { Id = 2 };
            var thirdClassOfStudents = new ClassOfStudents() { Id = 3 };

            var dataToFilter = new List<SubjectClassOfStudents>()
            {
                new SubjectClassOfStudents() { SubjectId = 1, ClassOfStudents = firstClassOofStudents },
                new SubjectClassOfStudents() { SubjectId = 1, ClassOfStudents = secondClassOfStudents },
                new SubjectClassOfStudents() { SubjectId = 1, ClassOfStudents = thirdClassOfStudents },
            };

            IEnumerable<ClassOfStudents> expected = null;

            mockedSubjectClassOfStudentsRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(), It.IsAny<Expression<Func<SubjectClassOfStudents, ClassOfStudents>>>()))
                .Returns(
                (Expression<Func<SubjectClassOfStudents, bool>> predicate,
                Expression<Func<SubjectClassOfStudents, ClassOfStudents>> select) =>
                   expected = dataToFilter
                    .Where(predicate.Compile())
                    .Select(select.Compile()));

            var result = service.GetAllClassesWithSpecifiedSubject(subjectId);

            mockedSubjectClassOfStudentsRepo
                .Verify(x => x.GetAll(It.IsAny<Expression<Func<SubjectClassOfStudents, bool>>>(), It.IsAny<Expression<Func<SubjectClassOfStudents, ClassOfStudents>>>()), Times.Once);

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}
