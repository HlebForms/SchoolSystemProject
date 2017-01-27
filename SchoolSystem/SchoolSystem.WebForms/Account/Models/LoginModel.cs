using Microsoft.Owin;

namespace SchoolSystem.WebForms.Account.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public IOwinContext context { get; set; }
    }
}