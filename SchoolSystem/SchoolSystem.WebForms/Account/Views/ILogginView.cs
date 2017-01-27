using SchoolSystem.WebForms.Account.Models;
using SchoolSystem.WebForms.Account.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SchoolSystem.WebForms.Account.Views
{
    public interface ILogginView : IView<LoginModel>
    {
        event EventHandler<LoginPageEventArgs> LoginUser;
    }
}
