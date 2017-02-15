using System;

using WebFormsMvp;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using SchoolSystem.MVP.Admin.Models;

namespace SchoolSystem.MVP.Admin.Views
{
    public interface IAssignSubjectsToClassOfStudentsView : IView<AssignSubjectsToClassOfStudentsModel>
    {
        event EventHandler EventGetAllClassOfStudents;

        event EventHandler<GetAvailableSubjectsForTheClassEventArgs> EventGetAvailableSubjectsForTheClass;

        event EventHandler<AssignSubjectsToClassOfStudentsEventArgs> EventAssignSubjectsToClassOfStudents;
    }
}