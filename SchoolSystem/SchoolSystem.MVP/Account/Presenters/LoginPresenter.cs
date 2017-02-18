using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.Identity.Managers;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.MVP.Account.Views.EventArguments;
using WebFormsMvp;

namespace SchoolSystem.MVP.Account.Presenters
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view) 
            : base(view)
        {
            this.View.EventLoginUser += this.UserLogin;
        }

        private void UserLogin(object sender, LoginPageEventtArgs e)
        {
            var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();
            var signinManager = e.OwinCtx.GetUserManager<ApplicationSignInManager>();

            var result = signinManager.PasswordSignIn(e.Data.Email, e.Data.Password, false, shouldLockout: false);

            this.View.Model.LoggedInStatus = result;
        }
    }
}
