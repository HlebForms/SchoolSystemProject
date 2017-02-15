using System;
using System.Web.UI.WebControls;
using SchoolSystem.Data.Models.Common;
using WebFormsMvp;
using WebFormsMvp.Web;
using SchoolSystem.MVP.Home.Views.EventArguments;
using SchoolSystem.MVP.Home.Presenter;
using SchoolSystem.MVP.Home.Models;
using SchoolSystem.MVP.Home.Views;

namespace SchoolSystem.WebForms.CustomControls.Home
{
    [PresenterBinding(typeof(NewsfeedPresenter))]
    public partial class NewsfeedControl : MvpUserControl<NewsfeedModel>, INewsfeedView
    {
        public event EventHandler EventBindNewsfeedData;
        public event EventHandler<AddNewsEventargs> EventAddNews;

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        protected override void OnPreRender(EventArgs e)
        {
            this.EventBindNewsfeedData(this, e);

            this.CommentsList.DataSource = this.Model.Newsfeed;
            this.CommentsList.DataBind();

            this.ImportantNewsList.DataSource = this.Model.ImportantNews;
            this.ImportantNewsList.DataBind();
        }
        protected void AddComment_Click(object sender, EventArgs e)
        {
            var loggedUserName = this.Context.User.Identity.Name;
            var commentContent = (this.LoginView.FindControl("AddTextbox") as TextBox).Text;
            var dateNow = DateTime.Now;
            var isImportant = true;

            if (this.Context.User.IsInRole(UserType.Student))
            {
                isImportant = false;
            }

            var addNewsEventargs = new AddNewsEventargs()
            {
                Username = loggedUserName,
                Content = commentContent,
                CreatedOn = dateNow,
                IsImportant = isImportant

            };
            this.EventAddNews(this, addNewsEventargs);

            this.CommentsList.DataSource = this.Model.Newsfeed;
            this.CommentsList.DataBind();

            (this.LoginView.FindControl("AddTextbox") as TextBox).Text = string.Empty;
        }
    }
}