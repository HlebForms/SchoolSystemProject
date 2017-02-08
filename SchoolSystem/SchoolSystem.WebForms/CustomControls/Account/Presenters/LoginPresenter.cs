using SchoolSystem.WebForms.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Account.Views;
using SchoolSystem.WebForms.CustomControls.Account.Views.EventArguments;

namespace SchoolSystem.WebForms.CustomControls.Account.Presenters
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view) 
            : base(view)
        {
            this.View.EventLoginUser += UserLogin;
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
