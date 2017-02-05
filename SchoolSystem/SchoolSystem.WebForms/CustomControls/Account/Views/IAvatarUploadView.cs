using System;

using SchoolSystem.WebForms.CustomControls.Account.Models;

using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Account.Views.EventArguments;

namespace SchoolSystem.WebForms.CustomControls.Account.Views
{
    public interface IAvatarUploadView: IView<AvatarUploadModel>
    {
        event EventHandler<AvatarUploadEventArgs> EventUploadAvatar;
    }
}