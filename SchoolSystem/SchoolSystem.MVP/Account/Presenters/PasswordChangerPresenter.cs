using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.Identity.Managers;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.MVP.Account.Views.EventArguments;
using WebFormsMvp;

namespace SchoolSystem.MVP.Account.Presenters
{
    public class PasswordChangerPresenter : Presenter<IPasswordChangeView>
    {
        public PasswordChangerPresenter(IPasswordChangeView view)
            : base(view)
        {
            this.View.EventPasswordChange += this.View_EventPasswordChange;
        }

        private void View_EventPasswordChange(object sender, PasswordChangeEventArgs e)
        {
            var manager = e.OwinContext.GetUserManager<ApplicationUserManager>();

            IdentityResult result = manager.ChangePassword(e.LoggedUser.GetUserId(), e.CurrentPassword, e.NewPassword);

            if (result.Succeeded)
            {
                e.OwinContext.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            }

            this.View.Model.ResultOfChangingPassword = result;
        }
    }
}