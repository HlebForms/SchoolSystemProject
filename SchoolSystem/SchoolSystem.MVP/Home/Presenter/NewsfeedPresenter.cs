using System;
using Bytes2you.Validation;
using SchoolSystem.MVP.Home.Views;
using SchoolSystem.MVP.Home.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
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

            this.View.EventAddNews += this.AddNews;
            this.View.EventBindNewsfeedData += this.BindNewsfeedData;
        }

        private void AddNews(object sender, AddNewsEventargs e)
        {
            this.newsDataService.AddNews(e.Username, e.Content, e.CreatedOn, e.IsImportant);
        }

        private void BindNewsfeedData(object sender, EventArgs e)
        {
            this.View.Model.Newsfeed = this.newsDataService.GetNews();
            this.View.Model.ImportantNews = this.newsDataService.GetImportantNews();
        }
    }
}