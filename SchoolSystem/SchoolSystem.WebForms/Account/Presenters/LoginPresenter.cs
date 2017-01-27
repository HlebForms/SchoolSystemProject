using Microsoft.VisualStudio.DebuggerVisualizers;
using SchoolSystem.Web.Services.Auth.Contracts;
using SchoolSystem.WebForms.Account.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebFormsMvp;
using SchoolSystem.WebForms.Account.Views.EventArguments;

namespace SchoolSystem.WebForms.Account.Presenters
{
    public class LoginPresenter : Presenter<ILogginView>
    {
        private readonly IAuthService authService;

        public LoginPresenter(ILogginView view, IAuthService authService) : base(view)
        {
            if (authService == null)
            {
                throw new ArgumentNullException("authService");
            }

            this.authService = authService;
            this.View.LoginUser += UserLogin;
        }

        private void UserLogin(object sender, LoginPageEventArgs e)
        {
            this.authService.LoginUser(e.Data.Email, e.Data.Password, e.OwinCtx);
        }
    }
}
