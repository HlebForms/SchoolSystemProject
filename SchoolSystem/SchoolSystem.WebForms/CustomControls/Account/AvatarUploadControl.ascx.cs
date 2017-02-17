using System;

using WebFormsMvp;
using WebFormsMvp.Web;
using System.IO;
using System.Web.UI;
using SchoolSystem.MVP.Account.Views.EventArguments;
using SchoolSystem.MVP.Account.Presenters;
using SchoolSystem.MVP.Account.Models;
using SchoolSystem.MVP.Account.Views;
using System.Web;

namespace SchoolSystem.WebForms.CustomControls.Account
{
    [PresenterBinding(typeof(AvatarUploadPresenter))]
    public partial class AvatarUploadControl : MvpUserControl<AvatarUploadModel>, IAvatarUploadView
    {
        public event EventHandler<GetUserAvatarEventArgs> EventGetUserAvatar;
        public event EventHandler<AvatarUploadEventArgs> EventUploadAvatar;

        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.UploadAvatarBtn);
            if (!this.IsPostBack)
            {
                this.EventGetUserAvatar(this, new GetUserAvatarEventArgs() { LoggedUseUserName = this.Context.User.Identity.Name });
                this.UserAvatar.ImageUrl = this.Model.UserAvatarUrl;
            }
        }

        protected void UploadAvatarBtn_Click(object sender, EventArgs e)
        {
            if (this.AvatarUpload.HasFile)
            {
                var loggedUserUserName = this.Context.User.Identity.Name;
                HttpPostedFile postedFile = this.AvatarUpload.PostedFile;
                HttpPostedFileBase file = new HttpPostedFileWrapper(postedFile);

                string extension = Path.GetExtension(postedFile.FileName);
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


                this.Notifier.NotifySuccess(this.Model.StatusMessage);
            }
            else
            {
                this.Notifier.NotifyError("Моля изберете файл");
            }
        }
    }
}