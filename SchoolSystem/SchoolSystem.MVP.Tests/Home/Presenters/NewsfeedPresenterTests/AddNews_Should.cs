using System;
using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Home.Presenter;
using SchoolSystem.MVP.Home.Views;
using SchoolSystem.MVP.Home.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Home.Presenters.NewsfeedPresenterTests
{
    [TestFixture]
    public class AddNews_Should
    {
        [Test]
        public void CallAddNewsFromNewsDataService_Once_WithCorrectArguments()
        {
            var mockedNewsfeedView = new Mock<INewsfeedView>();
            var mockedNewsDataService = new Mock<INewsDataService>();

            var newsDataPresenter = new NewsfeedPresenter(mockedNewsfeedView.Object, mockedNewsDataService.Object);
            var args = new AddNewsEventargs()
            {
                Content = It.IsAny<string>(),
                CreatedOn = It.IsAny<DateTime>(),
                IsImportant = It.IsAny<bool>(),
                Username = It.IsAny<string>()
            };

            mockedNewsfeedView.Raise(x => x.EventAddNews += null, args);

            mockedNewsDataService.Verify(x => x.AddNews(args.Username, args.Content, args.CreatedOn, args.IsImportant), Times.Once());
        }
    }
}
