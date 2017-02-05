using System;

using SchoolSystem.WebForms.CustomControls.Admin.Models;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;

using WebFormsMvp;

namespace SchoolSystem.WebForms.CustomControls.Admin.Views
{
    public interface IManagingScheduleView : IView<ManagingScheduleControlModel>
    {
        event EventHandler<EventArgs> EventBindAllClasses;

        event EventHandler<EventArgs> EventBindDaysOfWeek;

        event EventHandler<ManagingScheduleEventArgs> EventBindScheduleData;

        event EventHandler<AddingSubjectToScheduleEventArgs> EventAddSubjectToSchedule;

        event EventHandler<BindSubjectsForClassEventArgs> EventBitSubjectForCurrentClass;

        event EventHandler<RemovingSubjectFromScheduleEventArgs> EventRemoveSubjectFromSchedule;
    }
}
