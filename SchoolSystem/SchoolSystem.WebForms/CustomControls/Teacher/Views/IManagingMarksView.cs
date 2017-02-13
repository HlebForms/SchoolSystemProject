using System;

using SchoolSystem.WebForms.CustomControls.Teacher.Models;
using SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Views
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
