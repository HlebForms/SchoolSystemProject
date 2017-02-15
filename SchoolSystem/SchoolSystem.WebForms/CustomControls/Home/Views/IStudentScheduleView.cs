using SchoolSystem.WebForms.CustomControls.Home.Models;
using SchoolSystem.WebForms.CustomControls.Home.Views.EventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Home.Views
{
    public interface IScheduleView : IView<ScheduleControlModel>
    {
        event EventHandler<ScheduleEventargs> EventBindStudentScheduleData;

        event EventHandler<ScheduleEventargs> EventBindTeacherScheduleData;
    }
}
