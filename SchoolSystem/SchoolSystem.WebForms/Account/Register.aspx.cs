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
using WebFormsMvp;

namespace SchoolSystem.WebForms.Account
{
    [PresenterBinding(typeof(RegistrationPresenter))]
    public partial class Register : MvpPage<RegistrationModel>, IRegisterView
    {
        public event EventHandler<EventArgs> EventBindPageData;
        public event EventHandler<RegistrationPageEventArgs> EventRegisterUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.EventBindPageData(this, e);
                this.UserTypeDropDown.DataSource = this.Model.UserRoles;
                this.UserTypeDropDown.DataBind();

                this.SubjectDropDown.DataSource = this.Model.Subjects;
                this.SubjectDropDown.DataBind();

                this.ClassDropDown.DataSource = this.Model.ClassOfStudents;
                this.ClassDropDown.DataBind();
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var owinCtx = Context.GetOwinContext();
            var eventArgs = new RegistrationPageEventArgs()
            {
                OwinCtx = owinCtx,
                Email = this.Email.Text,
                FirstName = this.FirstNameTextBox.Text,
                LastName = this.LastNameTextBox.Text,
                UserName = this.Email.Text,
                UserType = this.UserTypeDropDown.SelectedItem.Text,
                Password = this.Password.Text,
                ConfirmedPassword = this.ConfirmPassword.Text
            };

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