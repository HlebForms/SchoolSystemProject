using System;

using WebFormsMvp;
using SchoolSystem.MVP.Teacher.Views.EventArguments;
using SchoolSystem.MVP.Teacher.Models;

namespace SchoolSystem.MVP.Teacher.Views
{
    public interface IManagingMarksView : IView<ManagingMarksModel>
    {
        event EventHandler<BindSubjectsEventArgs> EventBindSubjectsForTheSelectedTeacher;

        event EventHandler<BindClassesEventArgs> EventBindClasses;

        event EventHandler<BindReortCardEventArgs> EventBindSchoolReportCard;

        event EventHandler<InserMarkEventArgs> EventInsertMark;

        event EventHandler<BindStudentsEventArgs> EventBindStudents;

        event EventHandler EventBindMarks;
    }
}
