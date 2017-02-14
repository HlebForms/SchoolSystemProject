using System;

using SchoolSystem.Web.Services;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;

using NUnit.Framework;
using Moq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Services.Tests.AccountManagementServiceTests
{
    [TestFixture]
    public class IsEmailUnique_Should
    {
        [Test]
        public void Throw_ArgumentException_WithMsgCointainEmail_WhenEmailIsEmpty()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            Assert.That(() => service.IsEmailUnique(string.Empty),
                Throws.ArgumentException.With.Message.Contain("email"));
        }

        [Test]
        public void Throw_ArgumentNullException_WithMsgCointainEmail_WhenEmailIsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            Assert.That(() => service.IsEmailUnique(null),
                Throws.ArgumentNullException.With.Message.Contain("email"));
        }

        [TestCase("pesho@abv.bg")]
        [TestCase("/@abv.bg")]
        [TestCase("@abv.bg")]
        public void CallGetAllMethod_FromUserRepo_Once(string email)
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            service.IsEmailUnique(email);

            mockedUserRepo.Verify(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Expression<Func<User, string>>>()), Times.Once);
        }

        [Test]
        public void Return_TRUE_IfTheEmailisUnique()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);
            string email = "email@abv.bg";

            var users = new List<User>();

            mockedUserRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Expression<Func<User, string>>>()))
               .Returns(
                (Expression<Func<User, bool>> predicate, Expression<Func<User, string>> select) =>
                    users.Where(predicate.Compile())
                    .Select(select.Compile()));

            var result = service.IsEmailUnique(email);

            Assert.IsTrue(result);
        }

        [Test]
        public void Return_Fasle_IfTheEmailisUnique()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);
            string email = "email@abv.bg";

            var users = new List<User>() { new User() { Email = email } };

            mockedUserRepo.Setup(x => x.GetAll(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<Expression<Func<User, string>>>()))
               .Returns(
                (Expression<Func<User, bool>> predicate, Expression<Func<User, string>> select) =>
                    users.Where(predicate.Compile())
                    .Select(select.Compile()));

            var result = service.IsEmailUnique(email);

            Assert.IsFalse(result);
        }
    }
}
