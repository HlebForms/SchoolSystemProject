using SchoolSystem.WebForms.CustomControls.Teacher.Models;
using SchoolSystem.WebForms.CustomControls.Teacher.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Teacher.Views
{
    public interface IManagingMarksView : IView<ManagingMarksModel>
    {
        event EventHandler<BindSubjectsEventArgs> EventBindSubjects;

        event EventHandler<BindClassesEventArgs> EventBindClasses;

        event EventHandler<BindMarksEventArgs> EventBindMarks;

        event EventHandler<InserMarkEventArgs> EventInsertMark;
    }
}
