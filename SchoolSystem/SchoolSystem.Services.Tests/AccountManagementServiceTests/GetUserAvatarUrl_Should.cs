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
    public class GetUserAvatarUrl_Should
    {
        [Test]
        public void Throw_ArgumentException_WhenUserNameIsEmptyString_WithMsgContainingUserName()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            Assert.That(() => service.GetUserAvatarUrl(string.Empty),
                Throws.ArgumentException.With.Message.Contain("userName"));
        }

        [Test]
        public void Throw_ArgumentNullException_WhenUserNameIsNull_WithMsgContainingUserName()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            Assert.That(() => service.GetUserAvatarUrl(null),
                Throws.ArgumentNullException.With.Message.Contain("userName"));
        }

        [TestCase("Test")]
        [TestCase("RandomStringHere")]
        [TestCase("WantToBreakIttt")]
        public void Call_GetAllMethod_FromUserRepo_Once_WhenArgumentsAreValid(string userName)
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);
            var userWithavatar = new User()
            {
                AvatarPictureUrl = It.IsAny<string>()
            };
            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>())).Returns(userWithavatar);

            service.GetUserAvatarUrl(userName);

            mockedUserRepo.Verify(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }

        [TestCase("Pesho")]
        [TestCase("Gosho")]
        [TestCase("Ivan")]
        public void Return_CorrectUserUrl(string userName)
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();
            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);
            var userWithavatar = new User()
            {
                UserName = userName,
                AvatarPictureUrl = It.IsAny<string>()
            };
            var users = new List<User>() { userWithavatar };
            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
                .Returns(
                (Expression<Func<User, bool>> predicate) => users.FirstOrDefault(predicate.Compile()));
            var expected = userWithavatar.AvatarPictureUrl;

            var result = service.GetUserAvatarUrl(userName);

            Assert.AreSame(expected, result);
        }
    }
}
