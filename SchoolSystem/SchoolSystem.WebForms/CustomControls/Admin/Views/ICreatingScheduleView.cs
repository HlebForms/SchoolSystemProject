using System;

using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views
{
    public interface ICreatingScheduleView : IView<CreatingScheduleModel>
    {
        event EventHandler<EventArgs> EventBindAllClasses;

        event EventHandler<CreatingScheduleEventArgs> EventBindScheduleData;
    }
}
