using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Presenters;
using SchoolSystem.WebForms.Account.Views;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using SchoolSystem.WebForms.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
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