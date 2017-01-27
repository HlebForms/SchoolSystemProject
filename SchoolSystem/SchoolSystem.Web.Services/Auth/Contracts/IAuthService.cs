using Microsoft.Owin;
using Owin;

namespace SchoolSystem.Web.Services.Auth.Contracts
{
    public interface IAuthService
    {
        void AuthConfig(IAppBuilder app);

        bool RegisterUser(string username, string password, IOwinContext context);

        void LogoutUser(IOwinContext context);

        void LoginUser(string email, string password, IOwinContext context);
    }
}
