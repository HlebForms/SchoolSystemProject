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
    public class CreateSubject_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenSubjectNameIsNull()
        {
            var mockedRepo = new Mock<IRepository<Subject>>().Object;
            var mockedUow = new Mock<IUnitOfWork>().Object;
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new SubjectManagementService(mockedRepo, mockedSubjClassRepo.Object, () => mockedUow);

            Assert.Throws<ArgumentNullException>(() => service.CreateSubject(null, "test"));
        }

        [Test]
        public void ThrowArgumentNullException_WithMsgContainingSubjectName_WhenSubjectNameIsNull()
        {
            var mockedRepo = new Mock<IRepository<Subject>>().Object;
            var mockedUow = new Mock<IUnitOfWork>().Object;
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new SubjectManagementService(mockedRepo, mockedSubjClassRepo.Object, () => mockedUow);

            Assert.That(() => service.CreateSubject(null, "test"),
                        Throws.ArgumentNullException.With.Message.Contain("subjectName"));
        }

        [Test]
        public void ReturnFalse_WhenThereIsSubjectWithThatNameAlready()
        {
            var mockedRepo = new Mock<IRepository<Subject>>();
            var mockedUow = new Mock<IUnitOfWork>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var service = new SubjectManagementService(mockedRepo.Object, mockedSubjClassRepo.Object, () => mockedUow.Object);
            var subject = new Subject() { Name = "test" };

            mockedRepo.Setup(x => x.GetAll()).Returns(new List<Subject>() { subject });

            var result = service.CreateSubject(subject.Name, "test");

            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnTrue_WhenSubjectIsCreatedSuccesfully()
        {
            var mockedRepo = new Mock<IRepository<Subject>>();
            var mockedUow = new Mock<IUnitOfWork>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>().Object;
            mockedUow.Setup(x => x.Commit()).Returns(true);

            var service = new SubjectManagementService(mockedRepo.Object, mockedSubjClassRepo, () => mockedUow.Object);

            mockedRepo.Setup(x => x.GetAll()).Returns(new List<Subject>());

            var result = service.CreateSubject("test", "test");

            Assert.IsTrue(result);
        }


        [Test]
        public void CallAddMethodOfSubjectRepoOnce()
        {
            var mockedSupjectRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();
            var mockedUow = new Mock<IUnitOfWork>();

            mockedSupjectRepo.Setup(x => x.GetAll()).Returns(new List<Subject>());
            var service = new SubjectManagementService(mockedSupjectRepo.Object, mockedSubjClassRepo.Object, () => mockedUow.Object);
            mockedSupjectRepo.Setup(x => x.Add(It.IsAny<Subject>()));

            var result = service.CreateSubject("test", "test");

            mockedSupjectRepo.Verify(x => x.Add(It.IsAny<Subject>()), Times.Once);
        }

        [Test]
        public void CallCommitMethofOfUowOnce()
        {
            var mockedRepo = new Mock<IRepository<Subject>>();
            var mockedSubjClassRepo = new Mock<IRepository<SubjectClassOfStudents>>();

            var mockedUow = new Mock<IUnitOfWork>();

            mockedRepo.Setup(x => x.GetAll()).Returns(new List<Subject>());
            mockedUow.Setup(x => x.Commit());

            var service = new SubjectManagementService(mockedRepo.Object, mockedSubjClassRepo.Object, () => mockedUow.Object);
            var result = service.CreateSubject("test", "test");

            mockedUow.Verify(x => x.Commit(), Times.Once);
        }
    }
}
