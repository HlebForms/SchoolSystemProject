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

            var service = new SubjectManagementService(mockedRepo, () => mockedUow);

            Assert.Throws<ArgumentNullException>(() =>
            {
                service.CreateSubject(null);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMsgContainingSubjectName_WhenSubjectNameIsNull()
        {
            var mockedRepo = new Mock<IRepository<Subject>>().Object;
            var mockedUow = new Mock<IUnitOfWork>().Object;

            var service = new SubjectManagementService(mockedRepo, () => mockedUow);

            Assert.That(() => service.CreateSubject(null),
                Throws.ArgumentNullException.With.Message.Contain("subjectName"));
        }

        [Test]
        public void ReturnFalse_WhenThereIsSubjectWithThatNameAlready()
        {
            var mockedRepo = new Mock<IRepository<Subject>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;
            var service = new SubjectManagementService(mockedRepo.Object, () => mockedUow);
            var subject = new Subject() { Name = "test" };

            mockedRepo.Setup(x => x.GetAll()).Returns(new List<Subject>() { subject });

            var result = service.CreateSubject(subject.Name);

            Assert.IsFalse(result);
        }

        [Test]
        public void ReturnTrue_WhenSubjectIsCreatedSuccesfully()
        {
            var mockedRepo = new Mock<IRepository<Subject>>();
            var mockedUow = new Mock<IUnitOfWork>().Object;
            var service = new SubjectManagementService(mockedRepo.Object, () => mockedUow);

            mockedRepo.Setup(x => x.GetAll()).Returns(new List<Subject>() {  });

            var result = service.CreateSubject("test");

            Assert.IsTrue(result);
        }


        [Test]
        public void CallAddMethodOfSubjectRepoOnce()
        {
            var mockedRepo = new Mock<IRepository<Subject>>();
            var mockedUow = new Mock<IUnitOfWork>();

            mockedRepo.Setup(x => x.GetAll()).Returns(new List<Subject>());
            var service = new SubjectManagementService(mockedRepo.Object, () => mockedUow.Object);
            mockedRepo.Setup(x => x.Add(It.IsAny<Subject>()));

            var result = service.CreateSubject("test");

            mockedRepo.Verify(x => x.Add(It.IsAny<Subject>()), Times.Once);
        }

        [Test]
        public void CallCommitMethofOfUowOnce()
        {
            var mockedRepo = new Mock<IRepository<Subject>>();
            var mockedUow = new Mock<IUnitOfWork>();

            mockedRepo.Setup(x => x.GetAll()).Returns(new List<Subject>());
            mockedUow.Setup(x => x.Commit());

            var service = new SubjectManagementService(mockedRepo.Object, () => mockedUow.Object);
            var result = service.CreateSubject("test");

            mockedUow.Verify(x => x.Commit(), Times.Once);
        }
    }
}
