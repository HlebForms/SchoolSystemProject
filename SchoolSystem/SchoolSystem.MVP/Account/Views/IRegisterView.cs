using System;

using WebFormsMvp;
using SchoolSystem.MVP.Account.Views.EventArguments;
using SchoolSystem.MVP.Account.Models;

namespace SchoolSystem.MVP.Account.Views
{
    public interface IRegisterView : IView<RegistrationModel>
    {
        event EventHandler<RegistrationPageEventArgs> EventRegisterUser;

        event EventHandler EventGetClassesOfStudents;

        event EventHandler EventGetAvailableSubjects;

        event EventHandler EventGetUserRoles;
    }
}
