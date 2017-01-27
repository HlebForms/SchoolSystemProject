using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views;
using System;
using System.Web;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using WebFormsMvp;
using SchoolSystem.WebForms.Account.Presenters;

namespace SchoolSystem.WebForms
{
    [PresenterBinding(typeof(AuthenticationPresenter))]
    public partial class Navigation : MvpUserControl<LoginModel>, IAuthenticationView
    {
        public event EventHandler<AuhenticationEventArgs> LoginUser;
        public event EventHandler<AuhenticationEventArgs> LogoutUser;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            var ctx = Context.GetOwinContext();
            this.LogoutUser(this, new AuhenticationEventArgs() { OwinCtx = ctx });
        }
    }
}