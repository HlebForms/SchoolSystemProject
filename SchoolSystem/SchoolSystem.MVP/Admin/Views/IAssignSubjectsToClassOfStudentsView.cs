using System;
using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Views.EventArguments;
using WebFormsMvp;

namespace SchoolSystem.MVP.Admin.Views
{
    public interface IAssignSubjectsToClassOfStudentsView : IView<AssignSubjectsToClassOfStudentsModel>
    {
        event EventHandler EventGetAllClassOfStudents;

        event EventHandler<GetAvailableSubjectsForTheClassEventArgs> EventGetAvailableSubjectsForTheClass;

        event EventHandler<AssignSubjectsToClassOfStudentsEventArgs> EventAssignSubjectsToClassOfStudents;
    }
}