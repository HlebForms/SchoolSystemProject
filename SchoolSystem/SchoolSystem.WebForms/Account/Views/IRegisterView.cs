using System;

using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.WebForms.Account.Views
{
    public interface IRegisterView : IView<RegistrationModel>
    {
        event EventHandler<RegistrationPageEventArgs> EventRegisterUser;

        event EventHandler EventGetClassesOfStudents;

        event EventHandler EventGetAvailableSubjects;

        event EventHandler EventGetUserRoles;
    }
}
