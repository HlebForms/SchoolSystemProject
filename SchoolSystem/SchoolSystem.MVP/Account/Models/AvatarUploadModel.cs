﻿namespace SchoolSystem.MVP.Account.Models
{
    public class AvatarUploadModel
    {
        public bool IsFileUploaded { get; set; }

        public string StatusMessage { get; set; }

        public string UserAvatarUrl { get; set; }
    }
}