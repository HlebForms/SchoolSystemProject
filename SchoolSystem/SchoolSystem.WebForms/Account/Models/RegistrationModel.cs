using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.WebForms.Account.Models
{
    public class RegistrationModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public bool IsSuccessfullyRegistered { get; set; }
    }
}