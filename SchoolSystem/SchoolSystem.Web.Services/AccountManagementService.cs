using System;

using SchoolSystem.Data.Contracts;
using SchoolSystem.Data.Models;
using SchoolSystem.Web.Services.Contracts;

namespace SchoolSystem.Web.Services
{
    public class AccountManagementService : IAccountManagementService
    {
        private readonly IRepository<User> userRepo;
        private readonly Func<IUnitOfWork> unitOfWork;

        public AccountManagementService(IRepository<User> userRepo, Func<IUnitOfWork> unitOfWork)
        {
            if (userRepo == null)
            {
                throw new ArgumentNullException("userRepo");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            this.userRepo = userRepo;
            this.unitOfWork = unitOfWork;
        }

        public void UploadAvatar(string userName, string avatarUrl)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }

            if (string.IsNullOrEmpty(avatarUrl))
            {
                throw new ArgumentNullException("avatarUrl");
            }

            var user = this.userRepo.GetFirst(x => x.UserName == userName);
            if (user != null)
            {
                using(var uow = this.unitOfWork())
                {
                    user.AvatarPictureUrl = avatarUrl;
                    uow.Commit();
                }
            }
        }
    }
}
