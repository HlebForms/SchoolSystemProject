using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using SchoolSystem.WebForms.Identity;
using SchoolSystem.WebForms.CustomControls.Account.Views;
using SchoolSystem.WebForms.CustomControls.Account.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Account.Presenters
{
    public class PasswordChangerPresenter : Presenter<IPasswordChangeView>
    {
        public PasswordChangerPresenter(IPasswordChangeView view)
            : base(view)
        {
            this.View.EventPasswordChange += View_EventPasswordChange;
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