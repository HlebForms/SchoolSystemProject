using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Home.Presenter;
using SchoolSystem.MVP.Home.Views;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.MVP.Tests.Home.Presenters.SchedulePresenterTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithMessageContainsScheduleDataService_WhenScheduleDataServiceIsNull()
        {
            var mockedScheduleView = new Mock<IScheduleView>();

            Assert.That(
                () => new SchedulePresenter(mockedScheduleView.Object, null),
                Throws.ArgumentNullException.With.Message.Contain("scheduleDataService"));
        }

        public void NotThrow_WhenAllArgumentsAreValide()
        {
            var mockedScheduleView = new Mock<IScheduleView>();
            var mockedScheduleService = new Mock<IScheduleDataService>();

            Assert.DoesNotThrow(() => new SchedulePresenter(mockedScheduleView.Object, mockedScheduleService.Object));
        }
    }
}
