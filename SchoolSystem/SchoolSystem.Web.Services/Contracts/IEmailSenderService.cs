using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IEmailSenderService
    {
        void SendEmail(string receiver, string password);
    }
}
