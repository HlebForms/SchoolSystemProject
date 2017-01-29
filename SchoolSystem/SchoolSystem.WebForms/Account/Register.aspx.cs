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
using SchoolSystem.Data.Models.Common;

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
                this.ClassContainer.Visible = false;

                this.ClassDropDown.DataSource = this.Model.ClassOfStudents;
                this.ClassDropDown.DataBind();
                this.SubjectContainer.Visible = false;
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var owinCtx = Context.GetOwinContext();
            var selectedRole = this.UserTypeDropDown.SelectedItem.Text;

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

            if (selectedRole == UserType.Teacher)
            {
                eventArgs.SubjectId = int.Parse(this.SubjectDropDown.SelectedItem.Value);
            }
            else if (selectedRole == UserType.Student)
            {
                eventArgs.ClassOfSudentsId = int.Parse(this.ClassDropDown.SelectedItem.Value);
            }

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

        protected void UserTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRole = this.UserTypeDropDown.SelectedItem.Text;

            if (selectedRole == UserType.Teacher)
            {
                this.ClassContainer.Visible = !this.ClassContainer.Visible;
                this.SubjectContainer.Visible = false;
            }
            else if (selectedRole == UserType.Student)
            {
                this.SubjectContainer.Visible = !this.SubjectContainer.Visible;
                this.ClassContainer.Visible = false;
            }
            else
            {
                this.SubjectContainer.Visible = false;
                this.ClassContainer.Visible = false;
            }
        }
    }
}