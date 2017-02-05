using System;

using SchoolSystem.WebForms.CustomControls.Account.Models;
using SchoolSystem.WebForms.CustomControls.Account.Presenters;
using SchoolSystem.WebForms.CustomControls.Account.Views;
using SchoolSystem.WebForms.CustomControls.Account.Views.EventArguments;

using WebFormsMvp;
using WebFormsMvp.Web;
using System.IO;

namespace SchoolSystem.WebForms.CustomControls.Account
{
    [PresenterBinding(typeof(AvatarUploadPresenter))]
    public partial class AvatarUploadControl : MvpUserControl<AvatarUploadModel>, IAvatarUploadView
    {
        public event EventHandler<AvatarUploadEventArgs> EventUploadAvatar;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadAvatarBtn_Click(object sender, EventArgs e)
        {
            if (this.AvatarUpload.HasFile)
            {
                var loggedUserUserName = this.Context.User.Identity.Name;
                var file = this.AvatarUpload.PostedFile;

                string extension = Path.GetExtension(file.FileName);
                string filename = loggedUserUserName + extension;

                string avatarStoragePath = Server.MapPath("~/Images/avatars/") + filename;
                string userAvatarUrl = "~/Images/avatars/" + filename;

                this.EventUploadAvatar(this, new AvatarUploadEventArgs()
                {
                    LoggedUserUserName = loggedUserUserName,
                    PostedFile = file,
                    AvatarStorateLocation = avatarStoragePath,
                    UserAvatarUrl = userAvatarUrl
                });

                this.StatusLabel.Text = this.Model.StatusMessage;
            }
            else
            {
                this.StatusLabel.Text = "Моля изберете файл";
            }
        }
    }
}