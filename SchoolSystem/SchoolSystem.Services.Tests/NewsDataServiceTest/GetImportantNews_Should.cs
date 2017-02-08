using Moq;
using NUnit.Framework;
using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.CustomModels;
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
    public class GetImportantNews_Should
    {
        [Test]
        public void ReturnTheNewsFromTheLast5Days()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                () => mockedUnitOfWork.Object);


            var expectedResult = new List<Newsfeed>()
            {
                new Newsfeed()
                {
                    IsImportant = true,
                    CreatedOn = DateTime.Now,
                    Content = "test content 1",
                    User = new User(){AvatarPictureUrl = "test url 1"}
                },
                new Newsfeed()
                {
                   IsImportant = true,
                   Content = "test content 2",
                   CreatedOn = DateTime.Now.AddDays(-1),
                   User = new User(){AvatarPictureUrl = "test url 2"}
                },
                new Newsfeed()
                {
                   IsImportant = true,
                   Content = "test content 3",
                   CreatedOn = DateTime.Now.AddDays(-2),
                   User = new User(){AvatarPictureUrl = "test url 3"}
                },
                new Newsfeed()
                {
                   IsImportant = true,
                   Content = "test content 4",
                   CreatedOn = DateTime.Now.AddDays(-3),
                   User = new User(){AvatarPictureUrl = "test url 4"}
                },
                new Newsfeed()
                {
                   IsImportant = true,
                   Content = "test content 5",
                   CreatedOn = DateTime.Now.AddDays(-4),
                   User = new User(){AvatarPictureUrl = "test url 5"}
                },
                new Newsfeed()
                {
                   IsImportant = true,
                   Content = "test content 6",
                   CreatedOn = DateTime.Now.AddDays(-5),
                   User = new User(){AvatarPictureUrl = "test url 6"}
                },
                new Newsfeed()
                {
                   IsImportant = true,
                   Content = "test content 7",
                   CreatedOn = DateTime.Now.AddDays(-6),
                   User = new User(){AvatarPictureUrl = "test url 7"}
                }
            };

            mockedNewsfeedRepository
                .Setup(x => x.GetAll(
                    It.IsAny<Expression<Func<Newsfeed, bool>>>(),
                    It.IsAny<Expression<Func<Newsfeed, NewsModel>>>()
                )).Returns(
                    (Expression<Func<Newsfeed, bool>> predicate,
                    Expression<Func<Newsfeed, NewsModel>> projection) =>
                    expectedResult.Where(predicate.Compile()).Select(projection.Compile())
                );

            var actual = newsDataService.GetImportantNews();

            Assert.AreEqual(actual.Count(), 5);
        }

        [Test]
        public void Call_newsfeedRepo_GetAllMethodOnce()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                () => mockedUnitOfWork.Object);

            newsDataService.GetImportantNews();

            mockedNewsfeedRepository
                    .Verify(
                        x => x.GetAll(
                            It.IsAny<Expression<Func<Newsfeed, bool>>>(),
                            It.IsAny<Expression<Func<Newsfeed, NewsModel>>>()),
                        Times.Exactly(1));
        }

        [Test]
        public void OrderItemsDescendingCorrectly()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                () => mockedUnitOfWork.Object);

            var item1 = new Newsfeed()
            {
                IsImportant = true,
                CreatedOn = DateTime.Now.AddDays(-2),
                Content = "test content 1",
                User = new User() { AvatarPictureUrl = "test url 1" }
            };
            var item2 = new Newsfeed()
            {
                IsImportant = true,
                Content = "test content 2",
                CreatedOn = DateTime.Now.AddDays(-1),
                User = new User() { AvatarPictureUrl = "test url 2" }
            };
            var item3 = new Newsfeed()
            {
                IsImportant = true,
                Content = "test content 3",
                CreatedOn = DateTime.Now,
                User = new User() { AvatarPictureUrl = "test url 3" }
            };

            var expectedResult = new List<Newsfeed>() { item1, item2, item3 };

            mockedNewsfeedRepository
                .Setup(x => x.GetAll(
                    It.IsAny<Expression<Func<Newsfeed, bool>>>(),
                    It.IsAny<Expression<Func<Newsfeed, NewsModel>>>()
                )).Returns(
                    (Expression<Func<Newsfeed, bool>> predicate,
                    Expression<Func<Newsfeed, NewsModel>> projection) =>
                    expectedResult.Where(predicate.Compile()).Select(projection.Compile())
                );

            var actualResult = newsDataService.GetImportantNews().ToList();

            Assert.AreEqual(actualResult[2].CreatedOn.ToString("dd:HH:mm:ss"), expectedResult[0].CreatedOn.ToString("dd:HH:mm:ss"));
            Assert.AreEqual(actualResult[1].CreatedOn.ToString("dd:HH:mm:ss"), expectedResult[1].CreatedOn.ToString("dd:HH:mm:ss"));
            Assert.AreEqual(actualResult[0].CreatedOn.ToString("dd:HH:mm:ss"), expectedResult[2].CreatedOn.ToString("dd:HH:mm:ss"));
        }

        [Test]
        public void MapDataCorrectly()
        {
            var mockedNewsfeedRepository = new Mock<IRepository<Newsfeed>>();
            var mockedUserRepo = new Mock<IRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var newsDataService = new NewsDataService(
                mockedNewsfeedRepository.Object,
                mockedUserRepo.Object,
                () => mockedUnitOfWork.Object);

            var mockedData = new List<Newsfeed>() {
                new Newsfeed()
                {
                    IsImportant = true,
                    CreatedOn = DateTime.Now,
                    Content = "test content",
                    User = new User() {
                        AvatarPictureUrl = "test url",
                        UserName = "test username"
                    }
                }
            };

            mockedNewsfeedRepository
                .Setup(x => x.GetAll(
                    It.IsAny<Expression<Func<Newsfeed, bool>>>(),
                    It.IsAny<Expression<Func<Newsfeed, NewsModel>>>()
                )).Returns(
                    (Expression<Func<Newsfeed, bool>> predicate,
                    Expression<Func<Newsfeed, NewsModel>> projection) =>
                    mockedData.Where(predicate.Compile()).Select(projection.Compile())
                );

            var actual = newsDataService.GetImportantNews().First();

            var expected = mockedData.First();

            Assert.AreSame(expected.Content, actual.Content);
            Assert.AreSame(expected.User.AvatarPictureUrl, actual.AvatarPictureUrl);
            Assert.AreSame(expected.User.UserName, actual.Creator);
            Assert.AreEqual(expected.CreatedOn, actual.CreatedOn);

        }
    }
}
