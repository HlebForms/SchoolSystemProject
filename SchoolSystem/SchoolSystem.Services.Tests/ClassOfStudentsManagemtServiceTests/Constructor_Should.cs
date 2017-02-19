using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;

namespace SchoolSystem.Services.Tests.ClassOfStudentsManagemtServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            Assert.DoesNotThrow(() =>
            {
                var service = new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo, mockedUnitOfWork.Object);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WhenClassOfStudentsRepoIsNull()
        {
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new ClassOfStudentsManagementService(null, mockedSubjectClassOfStudentsRepo, mockedUnitOfWork.Object);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContatiningClassOfStudentsRepo_WhenClassOfStudentsRepoIsNull()
        {
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.That(
                () => new ClassOfStudentsManagementService(null, mockedSubjectClassOfStudentsRepo, mockedUnitOfWork.Object),
            Throws.ArgumentNullException.With.Message.Contain("classOfStudentsRepo"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.Throws<ArgumentNullException>(
                () => new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo, null));
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContatingUnitOfWork_WhenUnitOfWorkIsNull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.That(
                () => new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo, null),
             Throws.ArgumentNullException.With.Message.Contain("unitOfWork"));
        }

        [Test]
        public void ThrowArgumentNullException_WtithMessageContainingSubjectClassOfStudnetsrepo_WhenSubjectClassOfStudnetsrepoIsNull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            Assert.That(
                () => new ClassOfStudentsManagementService(mockedClassOfStudentsRepo.Object, null, mockedUnitOfWork.Object),
             Throws.ArgumentNullException.With.Message.Contain("subjectClassOfStudnetsrepo"));
        }
    }
}
