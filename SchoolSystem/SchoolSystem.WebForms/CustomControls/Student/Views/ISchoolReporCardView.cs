using SchoolSystem.WebForms.CustomControls.Student.Models;
using SchoolSystem.WebForms.CustomControls.Student.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Student.Views
{
    public interface ISchoolReporCardView : IView<SchoolReportCardModel>
    {
        event EventHandler<GetStudentMarksEventArgs> EvenGetStudentMarks;
    }
}