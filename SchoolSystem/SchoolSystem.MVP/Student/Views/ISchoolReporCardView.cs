using SchoolSystem.MVP.Student.Models;
using SchoolSystem.MVP.Student.Views.EventArguments;
using System;
using WebFormsMvp;

namespace SchoolSystem.MVP.Student.Views
{
    public interface ISchoolReporCardView : IView<SchoolReportCardModel>
    {
        event EventHandler<GetStudentMarksEventArgs> EvenGetStudentMarks;
    }
}