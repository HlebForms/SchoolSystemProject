using SchoolSystem.WebForms.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ninject;
using SchoolSystem.Data;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.Common;

namespace SchoolSystem.WebForms.CustomControls.Home
{
    public partial class NewsfeedControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();

            this.CommentsList.DataSource = context.NewsFeed.Where(n => n.IsImportant == false).OrderByDescending(x => x.CreatedOn).ToList();
            this.CommentsList.DataBind();
        }

        protected void AddComment_Click(object sender, EventArgs e)
        {

            var commentContent = (this.LoginView.FindControl("AddTextbox") as TextBox).Text;
            var context = NinjectWebCommon.Kernel.Get<SchoolSystemDbContext>();
            var loggedUserName = this.Context.User.Identity.Name;
            var user = context.Users.FirstOrDefault(x => x.UserName == loggedUserName);
            var newsfeed = new Newsfeed();

            newsfeed.Content = commentContent;
            newsfeed.CreatedOn = DateTime.Now;
            if (this.Context.User.IsInRole(UserType.Student))
            {
                newsfeed.IsImportant = false;
            }
            else
            {
                newsfeed.IsImportant = true;
            }
            user.NewsFeed.Add(newsfeed);
            context.SaveChanges();


            this.CommentsList.DataSource = context.NewsFeed.Where(n => n.IsImportant == false).OrderByDescending(x => x.CreatedOn).ToList();
            this.CommentsList.DataBind();

            (this.LoginView.FindControl("AddTextbox") as TextBox).Text = string.Empty;
        }
    }
}