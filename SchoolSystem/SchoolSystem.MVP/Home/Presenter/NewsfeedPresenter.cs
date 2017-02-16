using System;

using SchoolSystem.MVP.Home.Views;
using SchoolSystem.MVP.Home.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;

using Bytes2you.Validation;
using WebFormsMvp;

namespace SchoolSystem.MVP.Home.Presenter
{
    public class NewsfeedPresenter : Presenter<INewsfeedView>
    {
        private readonly INewsDataService newsDataService;

        public NewsfeedPresenter(INewsfeedView view, INewsDataService newsDataService)
            : base(view)
        {
            Guard.WhenArgument(newsDataService, "newsDataService").IsNull().Throw();

            this.newsDataService = newsDataService;

            this.View.EventAddNews += AddNews;
            this.View.EventBindNewsfeedData += this.BindNewsfeedData;
            this.View.EventBindNewsfeedData += this.BindImportantNewsData;
        }

        private void AddNews(object sender, AddNewsEventargs e)
        {
            this.newsDataService.AddNews(e.Username, e.Content, e.CreatedOn, e.IsImportant);
        }

        private void BindNewsfeedData(object sender, EventArgs e)
        {
            this.View.Model.Newsfeed = newsDataService.GetNews();
        }

        private void BindImportantNewsData(object sender, EventArgs e)
        {
            this.View.Model.ImportantNews = newsDataService.GetImportantNews();
        }
    }
}