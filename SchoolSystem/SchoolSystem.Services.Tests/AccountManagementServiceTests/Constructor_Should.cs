using System;

using SchoolSystem.Web.Services;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;

using NUnit.Framework;
using Moq;

namespace SchoolSystem.Services.Tests.AccountManagementServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void DoesNotThrow_WhenArgumentsAreValid()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            Assert.DoesNotThrow(() =>
            {
                var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserRepo_IsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new AccountManagementService(null, mockedUoW.Object);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContaining_UserRepo_WhenUserRepo_IsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            Assert.That(() =>
            {
                var service = new AccountManagementService(null, mockedUoW.Object);
            }, Throws.ArgumentNullException.With.Message.Contain("userRepo"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUnitOfWork_IsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new AccountManagementService(mockedUserRepo.Object, null);
            });
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContaining_UnitOfWork_WhenUnitOfWork_IsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            Assert.That(() =>
            {
                var service = new AccountManagementService(mockedUserRepo.Object,null);
            }, Throws.ArgumentNullException.With.Message.Contain("unitOfWork"));
        }
    }
}