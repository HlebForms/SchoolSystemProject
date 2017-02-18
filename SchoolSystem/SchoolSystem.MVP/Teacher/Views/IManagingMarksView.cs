using System;
using SchoolSystem.MVP.Teacher.Models;
using SchoolSystem.MVP.Teacher.Views.EventArguments;
using WebFormsMvp;

namespace SchoolSystem.MVP.Teacher.Views
{
    public interface IManagingMarksView : IView<ManagingMarksModel>
    {
        event EventHandler<BindSubjectsEventArgs> EventBindSubjectsForTheSelectedTeacher;

        event EventHandler<BindClassesEventArgs> EventBindClasses;

        event EventHandler<BindSchoolReportCardEventArgs> EventBindSchoolReportCard;

        event EventHandler<InserMarkEventArgs> EventInsertMark;

        event EventHandler<BindStudentsEventArgs> EventBindStudents;

        event EventHandler EventBindMarks;
    }
}
