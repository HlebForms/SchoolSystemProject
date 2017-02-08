using System;
using SchoolSystem.WebForms.Account.Views;
using SchoolSystem.WebForms.Account.Views.EventArguments;

using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.Data.Models.Common;
using SchoolSystem.WebForms.Identity;

using WebFormsMvp;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace SchoolSystem.WebForms.Account.Presenters
{
    public class RegistrationPresenter : Presenter<IRegisterView>
    {
        private readonly IRegistrationService registrationService;

        public RegistrationPresenter(IRegisterView view, IRegistrationService registrationService)
            : base(view)
        {
            if (registrationService == null)
            {
                throw new ArgumentNullException("service");
            }

            this.registrationService = registrationService;

            this.View.EventRegisterUser += RegisterUser;
            this.View.EventBindPageData += BindPageData;
        }

        private void BindPageData(object sender, EventArgs e)
        {
            this.View.Model.UserRoles = this.registrationService.GetAllUserRoles();
            this.View.Model.ClassOfStudents = this.registrationService.GetClassOfStudents();
            this.View.Model.Subjects = this.registrationService.GetAllSubjects();
        }

        private void RegisterUser(object sender, RegistrationPageEventArgs e)
        {
            var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();

            var user = new User()
            {
                Email = e.Email,
                UserName = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName,
                AvatarPictureUrl = "~/Images/avatars/modified-avatar.png"
            };

            IdentityResult result = manager.Create(user, e.Password);
            manager.AddToRole(user.Id, e.UserType);

            if (e.UserType == UserType.Teacher)
            {
                this.registrationService.CreateTeacher(user.Id, e.SubjectId);
            }
            else if (e.UserType == UserType.Student)
            {
                this.registrationService.CreateStudent(user.Id, e.ClassOfSudentsId);
            }
            else
            {
                // no specific need if the user is admin
            }

            this.View.Model.Result = result;
        }
    }
}