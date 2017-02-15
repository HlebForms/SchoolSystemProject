using SchoolSystem.MVP.Home.Views;
using SchoolSystem.MVP.Home.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
using System;
using WebFormsMvp;

namespace SchoolSystem.MVP.Home.Presenter
{
    public class NewsfeedPresenter : Presenter<INewsfeedView>
    {
        private readonly INewsDataService service;

        public NewsfeedPresenter(INewsfeedView view, INewsDataService service)
            : base(view)
        {
            this.service = service;
            this.View.EventAddNews += AddNews;
            this.View.EventBindNewsfeedData += this.BindNewsfeedData;
            this.View.EventBindNewsfeedData += this.BindImportantNewsData;

        }

        private void AddNews(object sender, AddNewsEventargs e)
        {
            this.service.AddNews(e.Username, e.Content, e.CreatedOn, e.IsImportant);
        }

        private void BindNewsfeedData(object sender, EventArgs e)
        {
            this.View.Model.Newsfeed = service.GetNews();
        }

        private void BindImportantNewsData(object sender, EventArgs e)
        {
            this.View.Model.ImportantNews = service.GetImportantNews();
        }
    }
}