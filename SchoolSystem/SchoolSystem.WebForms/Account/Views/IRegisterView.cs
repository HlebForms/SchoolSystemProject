using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using System;
using WebFormsMvp;

namespace SchoolSystem.WebForms.Account.Views
{
    public interface IRegisterView : IView<RegistrationModel>
    {
        event EventHandler<RegistrationPageEventArgs> EventRegisterUser;

        event EventHandler<EventArgs> EventBindUserRoles;
    }
}
