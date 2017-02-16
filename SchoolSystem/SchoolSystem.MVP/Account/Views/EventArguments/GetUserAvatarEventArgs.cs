using System;

namespace SchoolSystem.MVP.Account.Views.EventArguments
{
    public class GetUserAvatarEventArgs : EventArgs
    {
        public string LoggedUseUserName { get; set; }
    }
}