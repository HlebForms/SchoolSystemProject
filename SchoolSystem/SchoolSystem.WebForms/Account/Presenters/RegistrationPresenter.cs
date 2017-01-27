using SchoolSystem.WebForms.Account.Views;
using WebFormsMvp;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using SchoolSystem.Web.Services.Auth.Contracts;

namespace SchoolSystem.WebForms.Account.Presenters
{
    public class RegistrationPresenter : Presenter<IRegisterView>
    {
        private readonly IAuthService authService;

        public RegistrationPresenter(IRegisterView view, IAuthService authService)
            : base(view)
        {
            this.authService = authService;
            this.View.EventRegisterUser += RegisterUser;
        }

        private void RegisterUser(object sender, RegistrationPageEventArgs e)
        {
            this.View.Model.IsSuccessfullyRegistered = this.authService.RegisterUser(e.Model.Email, e.Model.Password, e.OwinCtx);
        }
    }
}