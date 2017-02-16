using System;

namespace SchoolSystem.MVP.Home.Views.EventArguments
{
    public class AddNewsEventargs : EventArgs
    {
        public string Username { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsImportant { get; set; }
    }
}