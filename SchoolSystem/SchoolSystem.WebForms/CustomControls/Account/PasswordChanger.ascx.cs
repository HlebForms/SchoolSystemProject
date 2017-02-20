using System;
using System.Web;
using System.Web.UI;

using WebFormsMvp;
using WebFormsMvp.Web;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Views.EventArguments;
using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Views;

namespace SchoolSystem.WebForms.CustomControls.Account
{
    [PresenterBinding(typeof(PasswordChangerPresenter))]
    public partial class PasswordChanger : MvpUserControl<PasswordChangeModel>, IPasswordChangeView
    {
        public event EventHandler<PasswordChangeEventArgs> EventPasswordChange;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ChangePassrodBtn_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                var owinCtx = this.Context.GetOwinContext();

                this.EventPasswordChange(this, new PasswordChangeEventArgs
                {
                    OwinContext = owinCtx,
                    CurrentPassword = this.CurrentPassword.Text,
                    NewPassword = this.NewPassword.Text,
                    LoggedUser = Page.User.Identity
                });

                if (this.Model.ResultOfChangingPassword.Succeeded)
                {
                    this.Response.Redirect("~/Account/Login");
                }
                else
                {
                    this.Notifier.NotifyError(string.Join(Environment.NewLine, this.Model.ResultOfChangingPassword.Errors));
                }
            }
        }
    }
}