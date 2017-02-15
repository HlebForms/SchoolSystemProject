using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace SchoolSystem.MVP.Account.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public IOwinContext context { get; set; }

        public SignInStatus LoggedInStatus { get; set; }
    }
}