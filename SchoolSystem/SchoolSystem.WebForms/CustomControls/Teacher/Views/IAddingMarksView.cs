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
    public interface IAddingMarksView : IView<AddingMarksModel>
    {
        event EventHandler<BindSubjectsEventArgs> EventBindSubjects;
    }
}
