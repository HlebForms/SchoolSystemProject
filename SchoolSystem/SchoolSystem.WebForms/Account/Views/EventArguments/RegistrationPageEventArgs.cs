using Microsoft.Owin;
using SchoolSystem.WebForms.Account.Models;
using System;

namespace SchoolSystem.WebForms.Account.Views.EventArguments
{
    public class RegistrationPageEventArgs : EventArgs
    {
        public string Email { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string UserType { get; set; }

        public IOwinContext OwinCtx { get; set; }

        public int SubjectId { get; set; }

        public int ClassOfSudentsId { get; set; }
    }
}