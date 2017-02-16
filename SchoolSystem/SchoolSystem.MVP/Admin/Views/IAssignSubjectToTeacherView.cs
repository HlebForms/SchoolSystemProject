using System;

using SchoolSystem.MVP.Admin.Models;
using SchoolSystem.MVP.Admin.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.MVP.Admin.Views
{
    public interface IAssignSubjectToTeacherView : IView<AssignSubjectToTeacherModel>
    {
        event EventHandler EventGetTeacher;

        event EventHandler EventGetSubjectsWithoutTeacher;

        event EventHandler<AssignSubjectsToTeacherEventArgs> EventAssignSubjectsToTeacher;
    }
}
