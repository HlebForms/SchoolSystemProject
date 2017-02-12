using System;
using System.Web;
using WebFormsMvp;
using WebFormsMvp.Web;

using SchoolSystem.Data.Models.Common;
using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Presenters;
using SchoolSystem.WebForms.Account.Views;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using System.Web.UI.WebControls;
using System.Linq;

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

                this.AvailableSubjectsList.DataSource = this.Model.Subjects;
                this.AvailableSubjectsList.DataBind();
                this.SubjectContainer.Visible = false;

                this.ClassDropDown.DataSource = this.Model.ClassOfStudents;
                this.ClassDropDown.DataBind();
                this.ClassContainer.Visible = false;
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
                var subjects = this.AvailableSubjectsList
                    .Items
                    .Cast<ListItem>()
                    .Where(i => i.Selected)
                    .Select(x => int.Parse(x.Value))
                    .ToList();

               eventArgs.SubjectIds = subjects;
            }
            else if (selectedRole == UserType.Student)
            {
                eventArgs.ClassOfSudentsId = int.Parse(this.ClassDropDown.SelectedItem.Value);
            }

            EventRegisterUser(this, eventArgs);

            var result = this.Model.Result;

            if (result.Succeeded)
            {
                this.Notifier.NotifySuccess("Успешно регистрирахте потребител");
                ResetInputInFields();
            }
            else
            {
                this.Notifier.NotifyError(string.Join(Environment.NewLine, result.Errors));
            }
        }

        protected void UserTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRole = this.UserTypeDropDown.SelectedItem.Text;

            if (selectedRole == UserType.Student)
            {
                this.ClassContainer.Visible = !this.ClassContainer.Visible;
                this.SubjectContainer.Visible = false;
            }
            else if (selectedRole == UserType.Teacher)
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

        private void ResetInputInFields()
        {
            this.Email.Text = string.Empty;
            this.FirstNameTextBox.Text = string.Empty;
            this.LastNameTextBox.Text = string.Empty;
            this.Password.Text = string.Empty;
            this.ConfirmPassword.Text = string.Empty;
        }
    }
}