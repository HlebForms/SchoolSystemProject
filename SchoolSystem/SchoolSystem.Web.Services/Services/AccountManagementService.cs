using System;
using System.Linq;
using Bytes2you.Validation;
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
            Guard.WhenArgument(userRepo, "userRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.userRepo = userRepo;
            this.unitOfWork = unitOfWork;
        }

        public void UploadAvatar(string userName, string avatarUrl)
        {
            Guard.WhenArgument(userName, "userName").IsNullOrEmpty().Throw();
            Guard.WhenArgument(avatarUrl, "avatarUrl").IsNullOrEmpty().Throw();

            var user = this.userRepo.GetFirst(x => x.UserName == userName);
            if (user != null)
            {
                using (var uow = this.unitOfWork())
                {
                    user.AvatarPictureUrl = avatarUrl;
                    uow.Commit();
                }
            }
        }

        public string GetUserAvatarUrl(string userName)
        {
            Guard.WhenArgument(userName, "userName").IsNullOrEmpty().Throw();

            return this.userRepo.GetFirst(x => x.UserName == userName).AvatarPictureUrl;
        }

        public bool IsEmailUnique(string email)
        {
            Guard.WhenArgument(email, "email").IsNullOrEmpty().Throw();

            return this.userRepo.GetAll(x => x.Email == email, x => x.Email).Count() == 0;
        }
    }
}
