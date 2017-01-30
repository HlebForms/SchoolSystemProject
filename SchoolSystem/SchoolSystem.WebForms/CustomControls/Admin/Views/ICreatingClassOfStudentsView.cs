using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;
using System;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views
{
    public interface ICreatingClassOfStudentsView : IView<CreatingClassOfStudentsModel>
    {
        event EventHandler<CreatingClassOfStudentsEventArgs> EventCreateClassOfStudents;

        event EventHandler<EventArgs> EventGetAllSubjects;
    }
}
