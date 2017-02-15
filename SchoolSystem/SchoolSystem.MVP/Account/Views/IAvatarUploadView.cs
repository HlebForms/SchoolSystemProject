using System;

using WebFormsMvp;
using SchoolSystem.MVP.Account.Views.EventArguments;
using SchoolSystem.MVP.Account.Models;

namespace SchoolSystem.MVP.Account.Views
{
    public interface IAvatarUploadView: IView<AvatarUploadModel>
    {
        event EventHandler<AvatarUploadEventArgs> EventUploadAvatar;

        event EventHandler<GetUserAvatarEventArgs> EventGetUserAvatar;
    }
}