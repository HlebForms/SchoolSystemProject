using SchoolSystem.Web.Services.Contracts;
using SchoolSystem.WebForms.CustomControls.Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using SchoolSystem.WebForms.CustomControls.Admin.Views.EventArguments;

namespace SchoolSystem.WebForms.CustomControls.Admin.Presenters
{
    public class CreatingSchedulePresenter : Presenter<ICreatingScheduleView>
    {
        private readonly IScheduleDataService scheduleService;
        private readonly IClassOfStudentsManagementService classOfStudentsManagementService;
        private readonly ISubjectManagementService subjectManagementService;

        public CreatingSchedulePresenter(
            ICreatingScheduleView view,
            IScheduleDataService scheduleService,
            IClassOfStudentsManagementService classOfStudentsManagementService,
            ISubjectManagementService subjectManagementService
            )
            : base(view)
        {
            if (scheduleService == null)
            {
                throw new ArgumentNullException("scheduleService");
            }

            if (classOfStudentsManagementService == null)
            {
                throw new ArgumentNullException("classOfStudentsManagementService");
            }

            if (subjectManagementService==null)
            {
                throw new ArgumentNullException("subjectManagementService");
            }

            this.scheduleService = scheduleService;
            this.classOfStudentsManagementService = classOfStudentsManagementService;
            this.subjectManagementService = subjectManagementService;
            
            this.View.EventBindScheduleData += this.BindScheduleData;
            this.View.EventBindAllClasses += this.GetAllClasses;
            this.View.EventBindDaysOfWeek += this.BindDaysOfWeek;
            this.View.EventBitSubjectForCurrentClass += this.BindSubjectsForSpecificClass;
        }

        private void BindSubjectsForSpecificClass(object sender, BindSubjectsForClassEventArgs e)
        {
            this.View.Model.SubjectForCurrentClass = this.subjectManagementService.GetSubjectsForSpecificClass(e.ClassId);
        }

        private void BindDaysOfWeek(object sender, EventArgs e)
        {
            this.View.Model.DaysOfWeek = this.scheduleService.GetAllDaysOfWeek();
        }

        private void GetAllClasses(object sender, EventArgs e)
        {
            this.View.Model.AllClassOfStudents = this.classOfStudentsManagementService.GetAllClasses();
        }

        private void BindScheduleData(object sender, CreatingScheduleEventArgs e)
        {
            this.View.Model.CurrentSchedule = this.scheduleService.GetTodaysSchedule(
                int.Parse(e.DayOfWeekId), int.Parse(e.ClassId));
        }
    }
}