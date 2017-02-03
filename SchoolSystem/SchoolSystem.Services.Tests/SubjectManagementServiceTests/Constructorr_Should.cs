//using Moq;
//using NUnit.Framework;
//using SchoolSystem.Data.Contracts;
//using SchoolSystem.Data.Models;
//using SchoolSystem.Web.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SchoolSystem.Services.Tests.SubjectManagementServiceTests
//{
//    [TestFixture]
//    public class Constructorr_Should
//    {
//        [Test]
//        public void ThrowArgumentNullException_WhenSubjectsRepoIsNull()
//        {
//            var mockedUow = new Mock<IUnitOfWork>().Object;

//            Assert.Throws<ArgumentNullException>(() =>
//            {
//                var subjectManagementService = new SubjectManagementService(null, () => mockedUow);
//            });
//        }

//        [Test]
//        public void ThrowArgumentNullException_WithMsgContainingSubjectRepo_WhenSubjectsRepoIsNull()
//        {
//            var mockedUow = new Mock<IUnitOfWork>().Object;

//            Assert.That(() => new SubjectManagementService(null, () => mockedUow),
//                Throws.ArgumentNullException.With.Message.Contain("subjectRepo"));
//        }

//        [Test]
//        public void ThrowArgumentNullException_WhenUnitOfWorkIsNull()
//        {
//            var mockedRepo = new Mock<IRepository<Subject>>().Object;

//            Assert.Throws<ArgumentNullException>(() =>
//            {
//                var subjectManagementService = new SubjectManagementService(mockedRepo,null);
//            });
//        }

//        [Test]
//        public void ThrowArgumentNullException_WithMsgContainingUnitOfWork_WhenSubjectsRepoIsNull()
//        {
//            var mockedRepo = new Mock<IRepository<Subject>>().Object;

//            Assert.That(() => new SubjectManagementService(mockedRepo,null),
//                Throws.ArgumentNullException.With.Message.Contain("unitOfWork"));
//        }
//    }
//}
