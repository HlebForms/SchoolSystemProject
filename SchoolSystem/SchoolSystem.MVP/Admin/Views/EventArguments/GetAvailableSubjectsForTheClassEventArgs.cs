using System;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class GetAvailableSubjectsForTheClassEventArgs : EventArgs
    {
        public int ClassOfStudentsId { get; set; }
    }
}