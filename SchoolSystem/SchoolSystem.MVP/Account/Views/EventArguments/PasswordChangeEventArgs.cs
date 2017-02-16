using System;
using System.Security.Principal;

using Microsoft.Owin;

namespace SchoolSystem.MVP.Account.Views.EventArguments
{
    public class PasswordChangeEventArgs : EventArgs
    {
        public IIdentity LoggedUser { get; set; }

        public string NewPassword { get; set; }

        public string CurrentPassword { get; set; }

        public IOwinContext OwinContext { get; set; }
    }
}