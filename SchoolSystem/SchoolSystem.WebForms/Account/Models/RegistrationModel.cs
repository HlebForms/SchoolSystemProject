using Microsoft.AspNet.Identity;

namespace SchoolSystem.WebForms.Account.Models
{
    public class RegistrationModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public IdentityResult Result { get; set; }
    }
}