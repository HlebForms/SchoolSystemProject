using System;
using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.Data.Models;
using SchoolSystem.Data.Models.Common;
using SchoolSystem.Identity.Managers;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.MVP.Account.Views.EventArguments;
using SchoolSystem.Web.Services.Contracts;
using WebFormsMvp;

namespace SchoolSystem.MVP.Account.Presenters
{
    public class RegistrationPresenter : Presenter<IRegisterView>
    {
        private readonly IRegistrationService registrationService;
        private readonly IAccountManagementService accountManagementSerivce;
        private readonly ISubjectManagementService subjectManagementService;
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;
        private readonly IEmailSenderService emailSender;
        private readonly IPasswordGeneratorService passwordService;

        public RegistrationPresenter(
            IRegisterView view,
            IRegistrationService registrationService,
            ISubjectManagementService subjectManagementService,
            IClassOfStudentsManagementService classOfStudentsManagementService,
            IAccountManagementService accountManagementSerivce,
            IEmailSenderService emailSender,
            IPasswordGeneratorService passwordService)
            : base(view)
        {
            Guard.WhenArgument(registrationService, "registrationService").IsNull().Throw();
            Guard.WhenArgument(subjectManagementService, "subjectManagementService").IsNull().Throw();
            Guard.WhenArgument(classOfStudentsManagementService, "classOfStudentsManagementService").IsNull().Throw();
            Guard.WhenArgument(accountManagementSerivce, "accountManagementSerivce").IsNull().Throw();
            Guard.WhenArgument(emailSender, "emailSender").IsNull().Throw();
            Guard.WhenArgument(passwordService, "passwordService").IsNull().Throw();

            this.registrationService = registrationService;
            this.accountManagementSerivce = accountManagementSerivce;
            this.subjectManagementService = subjectManagementService;
            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.emailSender = emailSender;
            this.passwordService = passwordService;

            this.View.EventRegisterUser += this.RegisterUser;
            this.View.EventGetClassesOfStudents += this.View_EventGetClassesOfStudents;
            this.View.EventGetUserRoles += this.View_EventGetUserRoles;
            this.View.EventGetAvailableSubjects += this.View_EventGetAvailableSubjects;
        }

        private void View_EventGetClassesOfStudents(object sender, EventArgs e)
        {
            this.View.Model.ClassOfStudents = this.classOfStudentsManagementService.GetAllClasses();
        }

        private void View_EventGetUserRoles(object sender, EventArgs e)
        {
            this.View.Model.UserRoles = this.registrationService.GetAllUserRoles();
        }

        private void View_EventGetAvailableSubjects(object sender, EventArgs e)
        {
            this.View.Model.Subjects = this.subjectManagementService.GetAllSubjectsWithoutTeacher();
        }

        private void RegisterUser(object sender, RegistrationPageEventArgs e)
        {
            var isEmailUniqe = this.accountManagementSerivce.IsEmailUnique(e.Email);
            var password = this.passwordService.GenerateRandomPassword();

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

            IdentityResult result = manager.Create(user, password);

            manager.AddToRole(user.Id, e.UserType);

            if (e.UserType == UserType.Teacher)
            {
                this.registrationService.CreateTeacher(user.Id, e.SubjectIds);
            }
            else if (e.UserType == UserType.Student)
            {
                this.registrationService.CreateStudent(user.Id, e.ClassOfSudentsId);
            }
            else
            {
                // no specific need if the user is admin
            }

            if (result.Succeeded)
            {
                this.emailSender.SendEmail(e.Email, password);
            }

            this.View.Model.Result = result;
        }
    }
}