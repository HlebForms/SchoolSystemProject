using System;

using SchoolSystem.Web.Services;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using Moq;

using NUnit.Framework;

namespace SchoolSystem.Services.Tests.ClassOfStudentsManagemtServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrow_WhenAllArgumentsAreValid()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            Assert.DoesNotThrow(() =>
            {
                var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo, mockedUnitOfWork.Object);
            });
        }


        [Test]
        public void ThrowArgumentNullException_WhenSubjectRepoIsNull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new ClassOfStudentsManagementService(null, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo, mockedUnitOfWork.Object);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContainingSubjectRepo_WhenSubjectRepoIsNull()
        {
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.That(() =>
            {
                var service = new ClassOfStudentsManagementService(null, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo, mockedUnitOfWork.Object);
            }, Throws.ArgumentNullException.With.Message.Contain("subjectsRepo"));

        }

        [Test]
        public void ThrowArgumentNullException_WhenClassOfStudentsRepoIsNull()
        {
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, null, mockedSubjectClassOfStudentsRepo, mockedUnitOfWork.Object);
            });
        }


        [Test]
        public void ThrowArgumentNullException_WithMessageContatiningClassOfStudentsRepo_WhenClassOfStudentsRepoIsNull()
        {
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.That(() =>
            {
                var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, null, mockedSubjectClassOfStudentsRepo, mockedUnitOfWork.Object);
            }, Throws.ArgumentNullException.With.Message.Contain("classOfStudentsRepo"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;


            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo, null);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContatingUnitOfWork_WhenUnitOfWorkIsNull()
        {
            var mockedSubjectsRepo = new Mock<IRepository<Subject>>();
            var mockedClassOfStudentsRepo = new Mock<IRepository<ClassOfStudents>>();
            var mockedSubjectClassOfStudentsRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;


            Assert.That(() =>
            {
                var service = new ClassOfStudentsManagementService(mockedSubjectsRepo.Object, mockedClassOfStudentsRepo.Object, mockedSubjectClassOfStudentsRepo, null);
            }, Throws.ArgumentNullException.With.Message.Contain("unitOfWork"));
        }
    }
}
