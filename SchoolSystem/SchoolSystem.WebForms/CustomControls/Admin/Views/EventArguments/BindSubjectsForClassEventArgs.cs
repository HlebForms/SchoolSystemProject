using System;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class BindSubjectsForClassEventArgs :EventArgs
    {
        public int ClassId { get; set; }
    }
}