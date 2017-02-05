using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.WebForms.CustomControls.Account.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Account.Presenters
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
            if (accountManagementService == null)
            {
                throw new ArgumentNullException("accountManagementService");
            }

            this.accountManagementService = accountManagementService;

            this.View.EventUploadAvatar += View_EventUploadAvatar;
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