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
using Bytes2you.Validation;

namespace SchoolSystem.WebForms.Account.Presenters
{
    public class RegistrationPresenter : Presenter<IRegisterView>
    {
        private readonly IRegistrationService registrationService;
        private readonly IAccountManagementService accountManagementSerivce;
        private readonly IEmailSenderService emailSender;

        public RegistrationPresenter(
            IRegisterView view,
            IRegistrationService registrationService,
            IAccountManagementService accountManagementSerivce,
            IEmailSenderService emailSender)
            : base(view)
        {

            Guard.WhenArgument(registrationService, "registrationService").IsNull().Throw();
            Guard.WhenArgument(accountManagementSerivce, "accountManagementSerivce").IsNull().Throw();
            Guard.WhenArgument(emailSender, "emailSender").IsNull().Throw();

            this.registrationService = registrationService;
            this.accountManagementSerivce = accountManagementSerivce;
            this.emailSender = emailSender;

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
            var isEmailUniqe = this.accountManagementSerivce.IsEmailUnique(e.Email);

            if (!isEmailUniqe)
            {
                this.View.Model.Result = new IdentityResult("Има потребител с такъв имейл!");
                return;
            }

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

            this.emailSender.SendEmail(e.Email, e.Password);

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