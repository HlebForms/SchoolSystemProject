using Bytes2you.Validation;
using SchoolSystem.MVP.Account.Views;
using SchoolSystem.Web.Services.Contracts;
using System;
using WebFormsMvp;

namespace SchoolSystem.MVP.Account.Presenters
{
    public class AvatarUploadPresenter : Presenter<IAvatarUploadView>
    {
        private const int MaximumSizeOfAvatar = 5 * 1000 * 1000;

        private readonly IAccountManagementService accountManagementService;
        public AvatarUploadPresenter(
            IAvatarUploadView view,
            IAccountManagementService accountManagementService)
            : base(view)
        {
            Guard.WhenArgument(accountManagementService, "accountManagementService").IsNull().Throw();

            this.accountManagementService = accountManagementService;

            this.View.EventUploadAvatar += View_EventUploadAvatar;
            this.View.EventGetUserAvatar += View_EventGetUserAvatar;
        }

        private void View_EventGetUserAvatar(object sender, Views.EventArguments.GetUserAvatarEventArgs e)
        {
            this.View.Model.UserAvatarUrl = this.accountManagementService.GetUserAvatarUrl(e.LoggedUseUserName);
        }

        private void View_EventUploadAvatar(object sender, Views.EventArguments.AvatarUploadEventArgs e)
        {
            var uploadedFile = e.PostedFile;

            if (uploadedFile.ContentType != "image/jpg"
                && uploadedFile.ContentType != "image/png"
                && uploadedFile.ContentType != "image/jpeg")
            {
                this.View.Model.StatusMessage = "Моля изберете картинка с разширение .png, .jpg или .jpeg";
                return;
            }

            if (uploadedFile.ContentLength > MaximumSizeOfAvatar)
            {
                this.View.Model.StatusMessage = $"Аватарът Ви не трябва да е с размер по-голям от {MaximumSizeOfAvatar / (1000 * 1000)}Mb";
                return;
            }

            try
            {
                uploadedFile.SaveAs(e.AvatarStorateLocation);
                // TODO Maaybe make interception
                this.accountManagementService.UploadAvatar(e.LoggedUserUserName, e.UserAvatarUrl);
                this.View.Model.StatusMessage = "Аватарът е качен";
            }
            catch (Exception ex)
            {
                this.View.Model.StatusMessage = "Моля, опитайте отново!";
            }
        }
    }
}