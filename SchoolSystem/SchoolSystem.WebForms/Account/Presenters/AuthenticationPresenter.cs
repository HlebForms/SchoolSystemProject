using SchoolSystem.Web.Services.Auth.Contracts;
using SchoolSystem.WebForms.Account.Views;
using System;
using WebFormsMvp;
using SchoolSystem.WebForms.Account.Views.EventArguments;

namespace SchoolSystem.WebForms.Account.Presenters
{
    public class AuthenticationPresenter : Presenter<IAuthenticationView>
    {
        private readonly IAuthService authService;

        public AuthenticationPresenter(IAuthenticationView view, IAuthService authService) : base(view)
        {
            if (authService == null)
            {
                throw new ArgumentNullException("authService");
            }

            this.authService = authService;
            this.View.LoginUser += UserLogin;
            this.View.LogoutUser += LogoutUser;
        }

        private void LogoutUser(object sender, AuhenticationEventArgs e)
        {
            this.authService.LogoutUser(e.OwinCtx);
        }

        private void UserLogin(object sender, AuhenticationEventArgs e)
        {
            this.authService.LoginUser(e.Data.Email, e.Data.Password, e.OwinCtx);
        }
    }
}
