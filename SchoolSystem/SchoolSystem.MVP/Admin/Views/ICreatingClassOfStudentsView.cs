using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using System;
using WebFormsMvp;

namespace SchoolSystem.MVP.Admin.Views
{
    public interface ICreatingClassOfStudentsView : IView<CreatingClassOfStudentsModel>
    {
        event EventHandler<CreatingClassOfStudentsEventArgs> EventCreateClassOfStudents;

        event EventHandler<EventArgs> EventGetAllSubjects;
    }
}
