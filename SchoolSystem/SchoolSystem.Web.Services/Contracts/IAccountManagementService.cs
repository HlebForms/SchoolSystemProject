using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Web.Services.Contracts
{
    public interface IAccountManagementService
    {
        void UploadAvatar(string userName, string avatarUrl);
    }
}
