using System;

using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views
{
    public interface IAssignSubjectsToClassOfStudentsView : IView<AssignSubjectsToClassOfStudentsModel>
    {
        event EventHandler EventGetAllClassOfStudents;

        event EventHandler<GetAvailableSubjectsForTheClassEventArgs> EventGetAvailableSubjectsForTheClass;

        event EventHandler<AssignSubjectsToClassOfStudentsEventArgs> EventAssignSubjectsToClassOfStudents;
    }
}