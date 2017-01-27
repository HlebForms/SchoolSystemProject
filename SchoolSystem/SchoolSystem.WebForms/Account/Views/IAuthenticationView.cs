using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using System;
using WebFormsMvp;

namespace SchoolSystem.WebForms.Account.Views
{
    public interface IAuthenticationView : IView<LoginModel>
    {
        event EventHandler<AuhenticationEventArgs> LoginUser;

        event EventHandler<AuhenticationEventArgs> LogoutUser;
    }
}
