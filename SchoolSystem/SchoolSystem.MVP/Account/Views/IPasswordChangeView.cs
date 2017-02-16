using System;

using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.MVP.Account.Views
{
    public interface IPasswordChangeView : IView<PasswordChangeModel>
    {
        event EventHandler<PasswordChangeEventArgs> EventPasswordChange;
    }
}