using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using SchoolSystem.Data.Models;
using SchoolSystem.WebForms.Account.Presenters;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views;
using SchoolSystem.WebForms.Account.Views.EventArguments;

namespace SchoolSystem.WebForms.Account
{
    [WebFormsMvp.PresenterBinding(typeof(RegistrationPresenter))]
    public partial class Register : MvpPage<RegistrationModel>, IRegisterView
    {
        public event EventHandler<RegistrationPageEventArgs> EventRegisterUser;

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var model = new RegistrationModel() { Email = this.Email.Text, Password = this.Password.Text, ConfirmedPassword = this.ConfirmPassword.Text };

            var owinCtx = Context.GetOwinContext();
            var eventArgs = new RegistrationPageEventArgs(model, owinCtx);
            // pass the manager
            EventRegisterUser(this, eventArgs);

            var result = this.Model.IsSuccessfullyRegistered;

            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new User() { UserName = Email.Text, Email = Email.Text };
            // var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, Password.Text);

            if (result)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                //signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                //ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}