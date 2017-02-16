using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.Identity.Managers;
using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.MVP.Account.Views.EventArguments;
using System;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SchoolSystem.WebForms.CustomControls.Account
{
    [PresenterBinding(typeof(LoginPresenter))]
    public partial class LoginControl : MvpUserControl<LoginModel>, ILoginView
    {
        public event EventHandler<LoginPageEventtArgs> EventLoginUser;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                var owinCtx = Context.GetOwinContext();
                var model = new LoginModel() { Email = this.Email.Text, Password = this.Password.Text };
                var eventArgs = new LoginPageEventtArgs(model, owinCtx);

                this.EventLoginUser(this, eventArgs);

                SignInStatus result = this.Model.LoggedInStatus;

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl("/", Response);
                        break;
                    case SignInStatus.Failure:
                    default:
                        FailureText.Text = "Грешно потребителско име или парола";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}