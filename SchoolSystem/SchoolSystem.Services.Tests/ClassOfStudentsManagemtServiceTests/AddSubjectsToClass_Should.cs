using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.ClassOfStudentsManagemtServiceTests
{
    [TestFixture]
    public class AddSubjectsToClass_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WihMessageContaining_SubjectIds_WhenSubhectsIdsAreNull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);

            Assert.That(
                () => service.AddSubjectsToClass(It.IsAny<int>(), null),
                Throws.ArgumentNullException.With.Message.Contain("subjectIds"));
        }

        [Test]
        public void Call_AddMethodFromSubjectsClassOfStudentsRepo_AsManyTimesAsTheCountOfIdsParams()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);

            IEnumerable<int> subjectIds = Enumerable.Range(1, 10);
            var expectedCalls = subjectIds.Count();

            service.AddSubjectsToClass(It.IsAny<int>(), subjectIds);

            mockedSubjectClassOfStudentsRepo.Verify(
                x => x.Add(It.IsAny<SubjectClassOfStudents>()),
                Times.Exactly(expectedCalls));
        }

        [Test]
        public void ReturnTrue_WhenAddingWasSuccessfull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            mockedUnitOfWork.Setup(x => x.Commit()).Returns(true);

            var service = new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);
            IEnumerable<int> subjectIds = Enumerable.Range(1, 10);

            var result = service.AddSubjectsToClass(It.IsAny<int>(), subjectIds);

            Assert.IsTrue(result);
        }

        [Test]
        public void ReturnFalse_WhenAddingWasSuccessfull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            mockedUnitOfWork.Setup(x => x.Commit()).Returns(false);

            var service = new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo.Object, () => mockedUnitOfWork.Object);
            IEnumerable<int> subjectIds = Enumerable.Range(1, 10);

            var result = service.AddSubjectsToClass(It.IsAny<int>(), subjectIds);

            Assert.False(result);
        }
    }
}
