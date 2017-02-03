using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.SubjectManagementServiceTests
{
    [TestFixture]
    public class Constructorr_Should
    {
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
    }
}
