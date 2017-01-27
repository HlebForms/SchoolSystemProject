using Microsoft.Owin;
using Owin;

namespace SchoolSystem.Web.Services.Auth.Contracts
{
    public interface IAuthService
    {
        bool RegisterUser(string username, string password, IOwinContext context);

        void AuthConfig(IAppBuilder app);
    }
}
