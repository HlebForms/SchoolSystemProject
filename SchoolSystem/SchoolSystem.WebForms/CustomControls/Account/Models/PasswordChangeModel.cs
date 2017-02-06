using Microsoft.AspNet.Identity;
using Microsoft.Owin;

namespace SchoolSystem.WebForms.CustomControls.Account.Models
{
    public class PasswordChangeModel
    {
        public IdentityResult ResultOfChangingPassword { get; set; }
    }
}