using System;
using SchoolSystem.MVP.Student.Models;
using SchoolSystem.MVP.Student.Views.EventArguments;
using WebFormsMvp;

namespace SchoolSystem.MVP.Student.Views
{
    public interface ISchoolReporCardView : IView<SchoolReportCardViewModel>
    {
        event EventHandler<GetStudentMarksEventArgs> EvenGetStudentMarks;
    }
}