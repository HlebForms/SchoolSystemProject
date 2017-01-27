using SchoolSystem.WebForms.Account.Views;
using WebFormsMvp;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using SchoolSystem.WebForms.Identity;
using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.Data.Models;
using Microsoft.AspNet.Identity;

namespace SchoolSystem.WebForms.Account.Presenters
{
    public class RegistrationPresenter : Presenter<IRegisterView>
    {

        public RegistrationPresenter(IRegisterView view)
            : base(view)
        {
            this.View.EventRegisterUser += RegisterUser;
        }

        private void RegisterUser(object sender, RegistrationPageEventArgs e)
        {
            var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();

            var user = new User() { UserName = e.Model.Email, Email = e.Model.Email };

            IdentityResult result = manager.Create(user, e.Model.Password);

            this.View.Model.Result = result;
        }
    }
}