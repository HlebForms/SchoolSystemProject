using SchoolSystem.WebForms.Account.Views;
using WebFormsMvp;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using SchoolSystem.WebForms.Identity;
using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.Data.Models;
using Microsoft.AspNet.Identity;
using SchoolSystem.Web.Services.Contracts;
using System;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using SchoolSystem.Data.Models.Common;

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
                LastName = e.LastName
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
           
            this.View.Model.Result = result;
        }
    }
}