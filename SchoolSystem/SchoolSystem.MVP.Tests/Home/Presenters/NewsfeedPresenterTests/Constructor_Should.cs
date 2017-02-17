using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Home.Presenter;
using SchoolSystem.MVP.Home.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Home.Presenters.NewsfeedPresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Thorw_ArgumentNullException_WithMessageContain_newsDataService_WhenNewsDataServiceIsNull()
        {
            var mockedNewsfeedView = new Mock<INewsfeedView>();

            Assert.That(() => new NewsfeedPresenter(mockedNewsfeedView.Object, null),
                Throws.ArgumentNullException.With.Message.Contains("newsDataService"));
        }

        [Test]
        public void NotThrow_WhenArgumentsAreValid()
        {
            var mockedNewsfeedView = new Mock<INewsfeedView>();
            var mockedNewsDataService = new Mock<INewsDataService>();

            Assert.DoesNotThrow(() => new NewsfeedPresenter(mockedNewsfeedView.Object, mockedNewsDataService.Object));
        }
    }
}
