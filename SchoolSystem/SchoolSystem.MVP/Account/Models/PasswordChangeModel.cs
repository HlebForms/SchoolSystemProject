using Microsoft.AspNet.Identity;

namespace SchoolSystem.MVP.Account.Models
{
    public class PasswordChangeModel
    {
        public IdentityResult ResultOfChangingPassword { get; set; }
    }
}