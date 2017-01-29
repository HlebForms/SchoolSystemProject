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
            this.View.EventBindUserRoles += BindUserRoles;
        }

        private void BindUserRoles(object sender, EventArgs e)
        {
            this.View.Model.UserRoles = this.registrationService.GetAllUserRoles();
        }

        private void RegisterUser(object sender, RegistrationPageEventArgs e)
        {
            var manager = e.OwinCtx.GetUserManager<ApplicationUserManager>();

            //TODO: take the subjectID
            int subjectId = 1;
            int classId = 1;

            var user = new User()
            {
                Email = e.Email,
                UserName = e.Email,
                FirstName = e.FirstName,
                LastName = e.LastName
            };

            IdentityResult result = manager.Create(user, e.Password);
            manager.AddToRole(user.Id, e.UserType);

            if (e.UserType == "Teacher")
            {
                this.registrationService.CreateTeacher(user.Id, subjectId);
            }
            else if (e.UserType == "Student")
            {
                this.registrationService.CreateStudent(user.Id, classId);
            }
           
            this.View.Model.Result = result;
        }

    }
}