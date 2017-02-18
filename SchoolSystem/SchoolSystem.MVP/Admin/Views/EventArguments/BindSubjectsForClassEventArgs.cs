using System;

namespace SchoolSystem.MVP.Admin.Views.EventArguments
{
    public class BindSubjectsForClassEventArgs : EventArgs
    {
        public int ClassId { get; set; }
    }
}