using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using System;
using WebFormsMvp;

namespace SchoolSystem.WebForms.Account.Views
{
    public interface ILoginView : IView<LoginModel>
    {
        event EventHandler<LoginPageEventtArgs> EventLoginUser;
    }
}
