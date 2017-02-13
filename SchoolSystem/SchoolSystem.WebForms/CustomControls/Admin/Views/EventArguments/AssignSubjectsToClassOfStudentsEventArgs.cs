using System;
using System.Collections.Generic;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments
{
    public class AssignSubjectsToClassOfStudentsEventArgs : EventArgs
    {
        public int ClassOfStudentsId { get; set; }

        public IEnumerable<int> SubjectIdsToBeAdded { get; set; }
    }
}