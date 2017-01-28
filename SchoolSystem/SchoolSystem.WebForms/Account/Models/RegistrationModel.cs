using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.Account.Models
{
    public class RegistrationModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public IdentityResult Result { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }
    }
}