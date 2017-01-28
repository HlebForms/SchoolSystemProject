using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.Account.Models
{
    public class RegistrationModel
    {
        public IdentityResult Result { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }
    }
}