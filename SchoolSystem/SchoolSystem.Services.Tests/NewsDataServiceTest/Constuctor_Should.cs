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

namespace SchoolSystem.Services.Tests.NewsDataServiceTest
{
    [TestFixture]
    public class Constuctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_When_NewsfeedRepositoryIsNull()
        {
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    new NewsDataService(null, mockedUserRepo.Object, mockedUnitOfWork.Object);
                });
        }

        [Test]
        public void ThrowArgumentNullException_When_UserRepositoryIsNull()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    new NewsDataService(mockedNewsfeedRepository.Object, null, mockedUnitOfWork.Object);
                });
        }

        [Test]
        public void ThrowArgumentNullException_When_UnitOfWorkIsNull()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();

            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    new NewsDataService(mockedNewsfeedRepository.Object, mockedUserRepo.Object, null);
                });
        }

        [Test]
        public void NotThrow_When_ArgumentsAreValid()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            Assert.DoesNotThrow(
                () =>
                {
                    new NewsDataService(mockedNewsfeedRepository.Object, mockedUserRepo.Object, mockedUnitOfWork.Object);
                });
        }
    }
}
