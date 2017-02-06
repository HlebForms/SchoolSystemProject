using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.WebForms.CustomControls.Home.Views;
using SchoolSystem.WebForms.CustomControls.Home.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Home.Presenter
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