using System;
using System.Web;
using SchoolSystem.WebForms.Account.Presenters;
using WebFormsMvp;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.WebForms.Identity;

namespace SchoolSystem.WebForms.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class Login : MvpPage<LoginModel>, ILoginView
    {
        public event EventHandler<LoginPageEventtArgs> EventLoginUser;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var owinCtx = Context.GetOwinContext();
                var model = new LoginModel() { Email = this.Email.Text, Password = this.Password.Text };
                var eventArgs = new LoginPageEventtArgs(model, owinCtx);

                this.EventLoginUser(this, eventArgs);


                var result = this.Model.LoggedInStatus;


                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}