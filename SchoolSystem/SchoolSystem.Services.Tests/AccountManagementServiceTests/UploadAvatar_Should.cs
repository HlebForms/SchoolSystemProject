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
    public class UploadAvatar_Should
    {
        private const string NonNullString = "NotNullString";

        [Test]
        public void ThrowArgumentNullException_WithMessageContaining_UserName_WhenUserNameIsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            Assert.That(() => service.UploadAvatar(null, NonNullString),
                Throws.ArgumentNullException.With.Message.Contain("userName"));
        }

        [Test]
        public void ThrowArgumentException_WithMessageContaining_UserName_WhenUserNameEmpty()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            Assert.That(() => service.UploadAvatar(string.Empty, NonNullString),
                Throws.ArgumentException.With.Message.Contain("userName"));
        }


        [Test]
        public void ThrowArgumentNullException_WithMessageContaining_AvatarUrl_WhenAvatarUrlIsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            Assert.That(() => service.UploadAvatar(NonNullString, null),
                Throws.ArgumentNullException.With.Message.Contain("avatarUrl"));
        }

        [Test]
        public void ThrowArgumentNullException_WithMessageContaining_AvatarUrl_WhenAvatarUrlIsEmpty()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            Assert.That(() => service.UploadAvatar(NonNullString, string.Empty),
                Throws.ArgumentException.With.Message.Contain("avatarUrl"));
        }

        [Test]
        public void Call_GetFirst_FromUserRepo()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            service.UploadAvatar(NonNullString, NonNullString);

            mockedUserRepo.Verify(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }

        [Test]
        public void Call_GetFirst_Correct_FromUserRepo()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUoW = new Mock<Func<IUnitOfWork>>();

            var expecedUser = new User() { UserName = NonNullString };

            var list = new List<User>()
            {
               expecedUser,
                new User() {UserName = "alabala" }
            };

            Expression<Func<User, bool>> funcFromMethod = null;
            Expression<Func<User, bool>> expectedString = x => x.UserName == NonNullString;

            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()))
            .Callback<Expression<Func<User, bool>>>(r => funcFromMethod = r);

            var service = new AccountManagementService(mockedUserRepo.Object, mockedUoW.Object);

            service.UploadAvatar(NonNullString, NonNullString);
            var result = list.FirstOrDefault(x => funcFromMethod.Compile()(x));
            Assert.AreSame(expecedUser, result);
        }
    }
}
