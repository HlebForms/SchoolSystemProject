using Moq;
using NUnit.Framework;
using SchoolSystem.MVP.Home.Presenter;
using SchoolSystem.MVP.Home.Views;
using SchoolSystem.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var newsDataPresenter = new  NewsfeedPresenter(mockedNewsfeedView.Object, mockedNewsDataService.Object);
        }
    }
}
