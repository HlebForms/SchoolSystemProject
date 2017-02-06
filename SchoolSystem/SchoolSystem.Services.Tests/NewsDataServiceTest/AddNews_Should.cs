using Moq;

using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Services.Tests.NewsDataServiceTest
{
    [TestFixture]
    public class AddNews_Should
    {

        [Test]
        public void Throw_When_UsernameIsNull()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                mockedUnitOfWork.Object);

            Assert.Throws<ArgumentNullException>(() =>
            {
                newsDataService.AddNews(null, "random string", DateTime.Now, false);
            });
        }

        public void Throw_When_UsernameIsEmpty()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                mockedUnitOfWork.Object);

            Assert.Throws<ArgumentNullException>(() =>
            {
                newsDataService.AddNews(string.Empty, "random string", DateTime.Now, false);
            });
        }

        [Test]
        public void Throw_When_ContentIsNull()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                mockedUnitOfWork.Object);

            Assert.Throws<ArgumentNullException>(() =>
            {
                newsDataService.AddNews("username", null, DateTime.Now, false);
            });
        }

        [Test]
        public void Throw_ArhumentException_When_ContentIsEmpty()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<Func<IUnitOfWork>>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                mockedUnitOfWork.Object);

            Assert.Throws<ArgumentException>(() =>
            {
                newsDataService.AddNews("username", string.Empty, DateTime.Now, false);
            });
        }


        [Test]
        public void CorrectlyAddData()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                () => mockedUnitOfWork.Object);

            var user = new User();

            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);

            newsDataService.AddNews("test", "content", DateTime.Now, false);

            Assert.AreEqual(user.NewsFeed.Count, 1);
        }

        [Test]
        public void Throw_When_UserIsNotFound()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                () => mockedUnitOfWork.Object);

            var user = new User();

            mockedUserRepo.Setup(x => x.GetFirst(null)).Returns(user);


            Assert.Throws<ArgumentNullException>(() =>
            {
                newsDataService.AddNews("test", "content", DateTime.Now, false);
            });
        }

        [Test]
        public void Call_UserRepo_GetFirst_MethodOnce()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                () => mockedUnitOfWork.Object);

            var user = new User();

            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);

            newsDataService.AddNews("test", "content", DateTime.Now, false);
            mockedUserRepo.Verify(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);

        }

        [Test]
        public void Call_UnitOfWork_Commit_MethodOnce()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                () => mockedUnitOfWork.Object);

            var user = new User();

            mockedUserRepo.Setup(x => x.GetFirst(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);

            newsDataService.AddNews("test", "content", DateTime.Now, false);
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);

        }
    }
}
