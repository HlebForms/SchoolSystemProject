using System;
using System.Linq;
using System.Web;
using SchoolSystem.WebForms.Account.Presenters;
using WebFormsMvp.Web;
using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SchoolSystem.WebForms.Account
{
    [WebFormsMvp.PresenterBinding(typeof(RegistrationPresenter))]
    public partial class Register : MvpPage<RegistrationModel>, IRegisterView
    {
        public event EventHandler<EventArgs> BindUserRoles;
        public event EventHandler<RegistrationPageEventArgs> EventRegisterUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindUserRoles(this, e);
            this.UserTypeDropDown.DataSource = this.Model.UserRoles;
            this.UserTypeDropDown.DataBind();
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var model = new RegistrationModel() { Email = this.Email.Text, Password = this.Password.Text, ConfirmedPassword = this.ConfirmPassword.Text };

            var owinCtx = Context.GetOwinContext();
            var eventArgs = new RegistrationPageEventArgs(model, owinCtx);

            EventRegisterUser(this, eventArgs);

            var result = this.Model.Result;

            if (result.Succeeded)
            {
                // TODO redirect to login;
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

    }
}