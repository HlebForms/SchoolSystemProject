using System;

using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using Moq;

using NUnit.Framework;

namespace SchoolSystem.Services.Tests.SubjectManagementServiceTests
{
    [TestFixture]
    public class Constructorr_Should
    {
        [Test]
        public void NotThrow_IfAllArgumentsAreValid()
        {
            var mockedSubjectRepo = new Mock<IRepository<Subject>>().Object;
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;
            var mockedUow = new Mock<IUnitOfWork>().Object;

            Assert.DoesNotThrow(() =>
            {
                var subjectManagementService = new SubjectManagementService(mockedSubjectRepo, mockedSubjClassRepo, () => mockedUow);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WhenSubjectsRepoIsNull()
        {
            var mockedUow = new Mock<IUnitOfWork>().Object;
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var subjectManagementService = new SubjectManagementService(null, mockedSubjClassRepo, () => mockedUow);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMsgContainingSubjectRepo_WhenSubjectsRepoIsNull()
        {
            var mockedUow = new Mock<IUnitOfWork>().Object;
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.That(() => new SubjectManagementService(null, mockedSubjClassRepo, () => mockedUow),
                Throws.ArgumentNullException.With.Message.Contain("subjectRepo"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
        {
            var mockedRepo = new Mock<IRepository<Subject>>().Object;
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var subjectManagementService = new SubjectManagementService(mockedRepo, mockedSubjClassRepo, null);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMsgContainingUnitOfWork_WhenSubjectsRepoIsNull()
        {
            var mockedRepo = new Mock<IRepository<Subject>>().Object;
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;

            Assert.That(() => new SubjectManagementService(mockedRepo, mockedSubjClassRepo, null),
                Throws.ArgumentNullException.With.Message.Contain("unitOfWork"));
        }

        [Test]
        public void ThrowArgumentNllExcepion_WhenSubjectClassOfStudentRepoIsNull()
        {
            var mockedRepo = new Mock<IRepository<Subject>>().Object;
            var mockedUow = new Mock<IUnitOfWork>().Object;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var subjectManagementService = new SubjectManagementService(mockedRepo, null, () => mockedUow);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMsgContainingSubjectClassOfStudents_WhenSubjectsRepoIsNull()
        {
            var mockedRepo = new Mock<IRepository<Subject>>().Object;
            var mockedUow = new Mock<IUnitOfWork>().Object;

            Assert.That(() => new SubjectManagementService(mockedRepo, null, () => mockedUow),
                Throws.ArgumentNullException.With.Message.Contain("subjectClassOfStudentsRepo"));
        }
    }
}
