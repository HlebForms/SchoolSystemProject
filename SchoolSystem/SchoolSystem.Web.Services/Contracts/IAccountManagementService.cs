namespace SchoolSystem.Web.Services.Contracts
{
    public interface IAccountManagementService
    {
        void UploadAvatar(string userName, string avatarUrl);

        string GetUserAvatarUrl(string userName);

        bool IsEmailUnique(string email);
    }
}
