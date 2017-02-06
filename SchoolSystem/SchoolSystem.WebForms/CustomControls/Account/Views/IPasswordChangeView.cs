using System;

using SchoolSystem.WebForms.CustomControls.Account.Models;
using SchoolSystem.WebForms.CustomControls.Account.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Account.Views
{
    public interface IPasswordChangeView : IView<PasswordChangeModel>
    {
        event EventHandler<PasswordChangeEventArgs> EventPasswordChange;
    }
}