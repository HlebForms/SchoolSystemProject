using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using SchoolSystem.WebForms.CustomControls.Account.Models;
using SchoolSystem.WebForms.CustomControls.Account.Views.EventArguments;
using System;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Account.Views
{
    public interface ILoginView : IView<LoginModel>
    {
        event EventHandler<LoginPageEventtArgs> EventLoginUser;
    }
}
